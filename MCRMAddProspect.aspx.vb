
Partial Class MCRMAddProspect
    Inherits _PageBaseClass
    Private MainId As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillddlState()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillddlState()
        Try
            ddlState.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", 105)
            ddlState.DataSource = ds.Tables(0)
            ddlState.DataTextField = "StateName"
            ddlState.DataValueField = "Id"
            ddlState.DataBind()
            ddlState.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            SaveProspect()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SaveProspect()
        Try
            Dim CheckPageName As String = MainBLL.CheckPageName(txtProspectname.Text.Trim, "AccProNameCheck")
            If (CheckPageName = "Already Exist") Then
                lblname.Text = "Name already exist in Prospect"
                txtProspectname.Focus()
            Else
                'If String.IsNullOrEmpty(txtopenbal.Text) Then
                '    txtopenbal.Text = "0"
                'End If
                'MainId = ProspectBLL.Insert(txtProspectname.Text.Trim, ddlindustry.SelectedValue, txtdiscription.Text, ddlsource.SelectedValue, ddlcamp.SelectedValue, Session("UserId"), ddlcompnytype.SelectedValue, txtwebsite.Text.Trim, txtturnover.Text.Trim, Session("UserId"), Session("Audlog_Id"), "", "Prospect", "", "0", "", txtvat.Text, txtpan.Text, txttin.Text, "Prospect", txtopenbal.Text.Trim, txtGST.Text.Trim, ddCategory.SelectedValue.Trim, ddlDueDate.SelectedValue)
                'MainId = ProspectBLL.Insert(Acc_Name,Acc_SourceID,Acc_OwnerID:=,companyID,createdid,

                MainId = MCRMBLL.InsertMCRMAccount(txtProspectname.Text.Trim, 0, 0, 0, Session("UserId"), 0, Session("UserId"), Session("Audlog_Id"), "account", txtemail.Text.Trim, "Prospect", 0, 45)



                'ProspectContactBLL.Insert(ddltitle.SelectedValue, txtname.Text.Trim, ddldesignation.SelectedValue, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, Session("UserId"), "Prospect", MainId, Session("Audlog_Id"), "True", "", 0, Date.Now(), "", "", 0, "", ddlnotifyby.SelectedItem.Text)


                MCRMBLL.InsertMCRMAccContact(txtContPerson.Text.Trim, 0, 0, txtmob.Text.Trim, txtofficeno.Text.Trim, txtextention.Text.Trim, txtemail.Text.Trim, 0, 1, "Prospect", MainId, Session("UserId"), "Email", Session("Audlog_Id"))

                'ProspectAddressBLL.Insert(MainId, "Billing", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"))


                MCRMBLL.InsertMCRMAccAddr(MainId, "Billing", txtProspectname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtAddress.Text.Trim, txtCity.Text.Trim, ddlState.SelectedValue, 105, txtPin.Text.Trim, Session("UserId"), Session("Audlog_Id"))
                MCRMBLL.InsertMCRMAccAddr(MainId, "Shipping", txtProspectname.Text.Trim, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, txtAddress.Text.Trim, txtCity.Text.Trim, ddlState.SelectedValue, 105, txtPin.Text.Trim, Session("UserId"), Session("Audlog_Id"))
                'If chksameadd.Checked Then
                '    ProspectAddressBLL.Insert(MainId, "Shipping", txtaddname.Text.Trim, txtaddemail.Text.Trim, "", txtaddphone.Text, "", txtaddressbill.Text.Trim, txtcitybill.Text, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"))
                'Else
                '    ProspectAddressBLL.Insert(MainId, "Shipping", txtaddnameship.Text.Trim, txtaddemailship.Text.Trim, "", txtaddphoneship.Text, "", txtaddship.Text.Trim, txtcityship.Text, ddlstateship.SelectedValue, ddlcountryship.SelectedValue, txtpincodeship.Text, Session("UserId"))
                'End If
                assigncontrol.AddAssignTo(MainId)

                'If Request.QueryString("returnurl") = "y" Then
                '    Response.Redirect("ViewProspect.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainId.ToString())))
                'Else
                Response.Redirect("index1.aspx")
                'End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyProspect", "INSERT", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
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
End Class
