Imports DynamicparcelEnumerations

Partial Class UserControl_Back_NoteControl
    Inherits System.Web.UI.UserControl
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

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                Else
                    fillNote()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Try
            txtname.Text = ""
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "btnShow_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveProduct(DML_OPERATION.INSERT)
            fillNote()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillNote()
        Try
            lvnote.DataSource = NoteBLL.FillNoteByType(hftype.Value, hftypeid.Value, Session("UserId"))
            lvnote.DataBind()
            If lvnote.Items.Count > 0 Then
                lbldoc.Text = "Note (" + lvnote.Items.Count.ToString + ")"
                If lvnote.Items.Count > 5 Then
                    DataPager1.Visible = True
                Else
                    DataPager1.Visible = False
                End If
            Else
                lbldoc.Text = "No Note"
                DataPager1.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "fillNote", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
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
                    NoteBLL.Insert(txtname.Text.Trim, hftype.Value, hftypeid.Value, Session("Audlog_Id"), Session("UserId"))
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("NoteControl", "SaveProduct", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub DataPager1_PreRender(sender As Object, e As EventArgs) Handles DataPager1.PreRender
        Try
            fillNote()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "DataPager1_PreRender", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub lvnote_ItemCommand(sender As Object, e As ListViewCommandEventArgs) Handles lvnote.ItemCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim lblnoteid As Integer = CInt((CType(e.Item.FindControl("lblnoteid"), Label)).Text)
                NoteBLL.delete(lblnoteid, Session("UserId"), Session("Audlog_Id"), hftype.Value)
                fillNote()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("NoteControl", "lvnote_ItemCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub Edit_Command(sender As Object, e As ListViewEditEventArgs)
        Try
            lvnote.EditIndex = e.NewEditIndex
            fillNote()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "Edit_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Sub Cancel_Command(sender As Object, e As ListViewCancelEventArgs)
        Try
            lvnote.EditIndex = -1
            fillNote()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteControl", "Cancel_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Sub Update_Command(sender As Object, e As ListViewUpdateEventArgs)
        Try
            Dim txtnote As String = (CType(lvnote.Items(e.ItemIndex).FindControl("txtnote"), TextBox)).Text
            Dim lblnoteid As Integer = CInt(lvnote.DataKeys(e.ItemIndex).Value.ToString)
            'DocumentBLL.Update(docname, ltid, Session("UserId"))
            NoteBLL.Update(txtnote.Trim, lblnoteid, Session("UserId"), Session("Audlog_Id"), hftype.Value)
            lvnote.EditIndex = -1
            fillNote()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("NoteUserControl", "Update_Command", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
