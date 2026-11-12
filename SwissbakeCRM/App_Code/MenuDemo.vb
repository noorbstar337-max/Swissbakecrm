Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Configuration
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Data
Imports System.Data.SqlClient

Public Class MenuDemo
    Private ConnectionString As String, ErrorMsg As String

    Public Sub New()
        'Read Connection String From web.config
        ConnectionString = ConfigurationManager.ConnectionStrings("DynamicParcelConnectionString").ConnectionString
    End Sub


    Public Function ExecuteXSLTransformation() As String
        Dim HtmlTags As String, XsltPath As String
        Dim DataStream As MemoryStream = Nothing
        Dim streamReader As StreamReader = Nothing

        Try
            If Not HttpRuntime.Cache("DynamicparcelMenu") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelMenu")
            'Path of XSLT file
            XsltPath = HttpContext.Current.Server.MapPath("XsltFormatFolder/XsltTransformer.xslt")

            'Encode all Xml format string to bytes
            Dim bytes As Byte() = Encoding.ASCII.GetBytes(GenerateXmlFormat())

            DataStream = New MemoryStream(bytes)

            'Create Xmlreader from memory stream

            Dim reader As XmlReader = XmlReader.Create(DataStream)

            ' Load the XML 
            Dim document As New XPathDocument(reader)


            Dim XsltFormat As New XslCompiledTransform()

            ' Load the style sheet.
            XsltFormat.Load(XsltPath)

            DataStream = New MemoryStream()

            Dim writer As New XmlTextWriter(DataStream, Encoding.ASCII)


            'Apply transformation from xml format to html format and save it in xmltextwriter
            XsltFormat.Transform(document, writer)

            streamReader = New StreamReader(DataStream)

            DataStream.Position = 0

            HtmlTags = streamReader.ReadToEnd()
            HttpRuntime.Cache.Add("DynamicparcelMenu", HtmlTags, Nothing, Date.MaxValue, TimeSpan.Zero, _
                                   CacheItemPriority.Normal, Nothing)
            Return HtmlTags
        Catch ex As Exception
            ErrorMsg = ex.Message
            Return ErrorMsg
        End Try
    End Function

    Public Function GenerateXmlFormat() As String
        Dim SqlCommand As String
        Dim DbMenu As DataSet
        Dim relation As DataRelation

        Using conn As New SqlConnection(ConnectionString)

            SqlCommand = "Select Menu_ID, Menu_Name,Menu_Url, Menu_ParentID from tblMenu where Menu_Status='Active' order by Menu_ID"

            DbMenu = New DataSet()

            Dim Adapter As New SqlDataAdapter(SqlCommand, conn)

            Adapter.Fill(DbMenu)

            Adapter.Dispose()
        End Using

        DbMenu.DataSetName = "Menus"

        DbMenu.Tables(0).TableName = "Menu"
        Dim count As Integer = 0
        For Each row As DataRow In DbMenu.Tables(0).Rows
            If row(3).ToString = "0" Then
                DbMenu.Tables(0).Rows(count)(3) = DBNull.Value
            End If
            count = count + 1
        Next

        'create Relation Parent and Child
        relation = New DataRelation("ParentChild", DbMenu.Tables("Menu").Columns("Menu_ID"), DbMenu.Tables("Menu").Columns("Menu_ParentID"), True)


        relation.Nested = True

        DbMenu.Relations.Add(relation)

        Return DbMenu.GetXml()
    End Function
End Class
