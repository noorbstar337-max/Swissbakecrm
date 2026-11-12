
Imports System.Web.UI

Public MustInherit Class PageBaseClass
    Inherits System.Web.UI.Page
    Private _MetaKeywords As String
    Private _MetaDescription As String
    Private _MetaTitle As String

    Public Overloads Property MetaKeywords() As String
        Get
            Return _MetaKeywords
        End Get
        Set(ByVal value As String)
            _MetaKeywords = value
        End Set
    End Property

    Public Overloads Property MetaDescription() As String
        Get
            Return _MetaDescription
        End Get
        Set(ByVal value As String)
            _MetaDescription = value
        End Set
    End Property

    Public Overloads Property MetaTitle() As String
        Get
            Return _MetaTitle
        End Get
        Set(ByVal value As String)
            _MetaTitle = value
        End Set
    End Property

    Private Sub Page_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Dim tagHtmlMeta As New HtmlMeta
            Dim tagHtmlHead As HtmlHead = CType(Page.Header, HtmlHead)

            'Add the Meta Description and Keywords Tags
            tagHtmlMeta.Attributes.Add("name", "description")
            If Not String.IsNullOrEmpty(_MetaDescription) Then
                tagHtmlMeta.Attributes.Add("content", _MetaDescription)
            Else
                tagHtmlMeta.Attributes.Add("content", GetGlobalResourceObject("Kartris", "ContentText_DefaultMetaDescription"))
            End If
            tagHtmlHead.Controls.Add(tagHtmlMeta)

            tagHtmlMeta = New HtmlMeta
            tagHtmlMeta.Attributes.Add("name", "keywords")
            If Not String.IsNullOrEmpty(_MetaKeywords) Then
                tagHtmlMeta.Attributes.Add("content", _MetaKeywords)
            Else
                tagHtmlMeta.Attributes.Add("content", GetGlobalResourceObject("Kartris", "ContentText_DefaultMetaKeywords"))
            End If
            tagHtmlHead.Controls.Add(tagHtmlMeta)

            tagHtmlMeta = New HtmlMeta
            tagHtmlMeta.Attributes.Add("name", "Title")
            If Not String.IsNullOrEmpty(_MetaTitle) Then
                tagHtmlMeta.Attributes.Add("content", _MetaTitle)
            Else
                tagHtmlMeta.Attributes.Add("content", GetGlobalResourceObject("Kartris", "ContentText_DefaultMetaKeywords"))
            End If
            tagHtmlHead.Controls.Add(tagHtmlMeta)
        End If
    End Sub
End Class
