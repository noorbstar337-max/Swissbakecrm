Imports DynamicparcelEnumerations

Partial Class UserControl_Back_NewDocumentControl
    Inherits System.Web.UI.UserControl
    Dim Paths As String
    Dim Count As Integer
    Dim DID As Integer
    Dim MainID As Integer

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

#Region "Method"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'If MainID = 0 Then
            'Else
            fillDocument()
            'End If
        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveProduct(DML_OPERATION.INSERT)
            fillDocument()
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
                DocumentBLL.NewDeleteDocument(hftype.Value, hftypeid.Value, Session("Audlog_Id"), ltid.Text)
                fillDocument()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("DocumentUserControl", "Delete Document", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Public Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try

                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim MyDate As DateTime = DateTime.Now
                    Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + fpdocument.PostedFile.FileName)
                    Paths = "img/Document/" + filename
                    Dim path2 As String = Server.MapPath("~/img/Document/" + filename)
                    fpdocument.PostedFile.SaveAs(path2)
                    Dim fExtension As String = Path.GetExtension(fpdocument.PostedFile.FileName)
                    DocumentBLL.Insert(Paths, fExtension, hftype.Value, hftypeid.Value, txtname.Text.Trim, Session("Audlog_Id"), Session("UserId"))
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("DocumentUserControl", "SaveProduct", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub fillDocument()
        Try
            grddcoument.DataSource = DocumentBLL.NewFillDocument(hftype.Value, hftypeid.Value)
            grddcoument.DataBind()
            If grddcoument.Items.Count > 0 Then
                lbldoc.Text = "Documents (" + grddcoument.Items.Count.ToString + ")"
            Else
                lbldoc.Text = "No Document"
            End If
          Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

#End Region

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Try
            txtname.Text = ""
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NewDocumentUserControl", "btnShow_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Sub Edit_Command(sender As Object, e As DataListCommandEventArgs)
        Try
            grddcoument.EditItemIndex = e.Item.ItemIndex
            fillDocument()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NewDocumentUserControl", "Edit_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Sub Cancel_Command(sender As Object, e As DataListCommandEventArgs)
        Try
            grddcoument.EditItemIndex = -1
            fillDocument()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NewDocumentUserControl", "Cancel_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Sub Update_Command(sender As Object, e As DataListCommandEventArgs)
        Try
            Dim docname As String = (CType(e.Item.FindControl("txtdocname"), TextBox)).Text
            Dim ltid As Integer = CInt((CType(e.Item.FindControl("ltid"), Literal)).Text)
            DocumentBLL.Update(docname, ltid, Session("UserId"))
            grddcoument.EditItemIndex = -1
            fillDocument()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NewDocumentUserControl", "Update_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
