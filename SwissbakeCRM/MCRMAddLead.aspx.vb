Imports DynamicparcelEnumerations

Partial Class MCRMAddLead
    Inherits _PageBaseClass
    Private MainId As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                txtleaddate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveLead()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveLead()
        Try
            Dim CheckPageName As String = MainBLL.CheckPageName(txtleadname.Text.Trim, "AccProNameCheck")
            If (CheckPageName = "Already Exist") Then
                lblname.Text = "Name already exist in Lead"
                txtleadname.Focus()
            Else
                MainId = LeadBLL.QuickInsert(txtleaddate.Text.Trim, txtleadname.Text.Trim, 1, Session("UserId"), Session("UserId"), Session("Audlog_Id"))
                LeadContactBLL.QuickInsert(txtContPerson.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), MainId, Session("Audlog_Id"), True, ddlnotifyby.SelectedItem.Text)
                LeadAddressBLL.Insert("", "", 0, 105, "", Session("UserId"), MainId, "Billing", Session("Audlog_Id"))
                Dim count As Integer = 0
                count = AssignToBLL.MaxAssignTo
                Dim sb As New StringBuilder
                sb.Append("<root>")
                sb.Append("<row Assignto_ID='" & count.ToString & "' Assignto_UserID='" & Session("UserId") &
                         "' Assignto_Type='" & "Lead" & "' Assignto_TypeID='" & MainId & "' Assignto_CreatedID='" & Session("UserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                count = count + 1
                sb.Append("</root>")
                AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), "Lead")
                assigncontrol.AddAssignTo(MainId)
                Response.Redirect("index1.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MCRMAddLead", "SaveLead", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            Response.Redirect("index1.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyLead", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub
End Class
