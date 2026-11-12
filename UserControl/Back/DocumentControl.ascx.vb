
Partial Class UserControl_Back_DocumentControl
    Inherits System.Web.UI.UserControl
    Dim HashDocument As Hashtable = New Hashtable
    Dim Paths As String
    Dim Count As Integer
    Dim DID As Integer
#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                fillDocument()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DocumentUserControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim MyDate As DateTime = DateTime.Now
            Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + fpdocument.PostedFile.FileName)
            Paths = "img/Document/" + filename
            Dim path2 As String = Server.MapPath("~/img/Document/" + filename)
            fpdocument.PostedFile.SaveAs(path2)
            Dim fExtension As String = Path.GetExtension(fpdocument.PostedFile.FileName)
            Dim Docid As Hashtable = If(Session("documenthash") IsNot Nothing, DirectCast(Session("documenthash"), Hashtable), Nothing)
            If Docid IsNot Nothing Then
                HashDocument = Session("documenthash")
                HashDocument.Add(Paths, txtname.Text.Trim + "," + fExtension)
                Session("documenthash") = HashDocument
            Else
                HashDocument.Add(Paths, txtname.Text.Trim + "," + fExtension)
                Session("documenthash") = HashDocument
            End If
            grddcoument.DataSource = HashDocument
            grddcoument.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DocumentUserControl", "btnsave Add", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
     
       End Sub

    Protected Sub grddcoument_ItemCommand(source As Object, e As DataListCommandEventArgs) Handles grddcoument.ItemCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As DataListItem = TryCast(btn.NamingContainer, DataListItem)
                Dim ltid As Literal = TryCast(row.FindControl("ltid"), Literal)
                Dim HCatid As Hashtable = If(Session("documenthash") IsNot Nothing, DirectCast(Session("documenthash"), Hashtable), Nothing)
                If HCatid IsNot Nothing Then
                    HashDocument = Session("documenthash")
                    HashDocument.Remove(ltid.Text)
                    Session("documenthash") = HashDocument
                Else
                    HashDocument.Remove(ltid.Text)
                    Session("documenthash") = HashDocument
                End If
                grddcoument.DataSource = HashDocument
                grddcoument.DataBind()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("DocumentUserControl", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub AddDocument(ByVal DID As Integer)
        Try
            If DID > 0 Then
                DocumentBLL.DeleteDocument("Product", DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("documenthash") IsNot Nothing, DirectCast(Session("documenthash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashDocument = Session("documenthash")
            Else
            End If
            count = DocumentBLL.MaxDocuemntID()
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashDocument.Count - 1
                Dim temp As String = HashDocument.Values(i)
                Dim str As String() = temp.Split(",")
                sb.Append("<row Doc_Id='" & Count.ToString & "' Doc_Name='" & str(0).ToString & "' Doc_Path='" & HashDocument.Keys(i) &
                        "' Doc_Extention='" & str(1).ToString & "' Doc_Type='" & hftype.Value & "' Doc_TypeId='" & DID & "' Doc_CreatedID='" & Session("UserId") &
                         "' Doc_CreatedDate='" & DateAndTime.DateString & "' Doc_ModifiedID='" & Session("UserId") & "' Doc_ModifiedDate='" & DateAndTime.DateString &
                          "' Doc_Del='0' Doc_Status='Active' />")
                count = count + 1
            Next
            sb.Append("</root>")
            DocumentBLL.XMLInsert(sb.ToString, Session("Audlog_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DocumentUserControl", "AddDocument", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillDocument()
        Try
            If hftypeid.Value > 0 Then
                Dim dttemp As DataSet = DocumentBLL.FillDocument(hftype.Value, hftypeid.Value)
                For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                    HashDocument.Add(dttemp.Tables(0).Rows(j)("Doc_Path").ToString(), dttemp.Tables(0).Rows(j)("Value").ToString())
                Next
                Session("documenthash") = HashDocument
                grddcoument.DataSource = HashDocument
                grddcoument.DataBind()
            Else
                grddcoument.DataSource = ""
                grddcoument.DataBind()
                Session("documenthash") = Nothing
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("DocumentUserControl", "fillDocument", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

  
End Class
