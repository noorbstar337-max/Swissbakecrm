Imports DynamicparcelEnumerations

Partial Class ModifyVendor
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim dt As New Data.DataTable
    Dim addrowtype As New Label
    Dim Temptable As DataTable
    '  Dim SDropdown As String


    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Vendor"
                    lbltitle2.Text = "Modify Vendor"
                Else
                    lbltitle1.Text = "New Vendor"
                    lbltitle2.Text = "New Vendor"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                If Request.QueryString("chk") = "e" Then
                    lbltitle1.Text = "Modify Vendor"
                    lbltitle2.Text = "Modify Vendor"
                Else
                    lbltitle1.Text = "New Vendor"
                    lbltitle2.Text = "New Vendor"
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Vendor.aspx")
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                FillCountry()
                FillStatebill()
                FillPStatebill()
                fillVendortype()
                'fillRcptDtl()
                FirstGridViewRow()
                FirstGridView2Row()

                If Not MainID = "0" Then
                    FillDetail()
                    disableradiobtn()
                    modifyspan.Visible = True
                Else
                    selectradiobtn()
                    modifyspan.Visible = False
                End If
              
            Catch ex As Exception
                'Response.Redirect("index.aspx")
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyVendor", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
        If txtTermDays.Text = "" Then
            txtTermDays.Text = 15
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    Dim flag As Boolean = False
                    For Each row As GridViewRow In GridView2.Rows
                        If flag = False Then
                            ' Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
                            Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                            Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
                            Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
                            Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
                            Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)
                            If ckselect.Checked = True And contactperson.Text = "" And mobile.Text = "" Then
                                flag = True
                                Exit For
                            End If

                        End If
                    Next

                    If flag = False Then

                        Dim x As Int32 = 0
                        VendorBLL.UpdateVendor(txtVendorname.Text, ddltype.SelectedValue, txtaddressbill.Text, txtcitybill.Text, ddlstatebill.SelectedValue,
                                                           ddlcountrybill.SelectedValue, txtpincodebill.Text, Session("UserId"), MainID, txtCstNo.Text, txtVatTinNo.Text, txtPaymentTerms.Text, txtgstno.Text, Convert.ToInt32(txtTermDays.Text))
                        For Each row As GridViewRow In GridView2.Rows
                            Dim ltcontactid = DirectCast(row.FindControl("ltcontactID"), Literal)
                            'Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
                            Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)

                            Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
                            Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
                            Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
                            Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)

                            If contactperson.Text <> "" Or email.Text <> "" Or mobile.Text <> "" Or phone.Text <> "" Then
                                If ltcontactid.Text = "" Then
                                    VendorBLL.InsertContact(contactperson.Text, email.Text, mobile.Text, phone.Text, 0, MainID, Session("UserId"), ckselect.Checked)
                                Else
                                    If x = 0 Then
                                        VendorBLL.UpdateContact(contactperson.Text, email.Text, mobile.Text, phone.Text, 1, Session("UserId"), ltcontactid.Text, ckselect.Checked)
                                    Else

                                        VendorBLL.UpdateContact(contactperson.Text, email.Text, mobile.Text, phone.Text, 0, Session("UserId"), ltcontactid.Text, ckselect.Checked)

                                    End If
                                End If
                            Else
                                If ltcontactid.Text <> "" Then
                                    VendorBLL.DeleteContact(ltcontactid.Text)
                                End If

                            End If
                            x += 1
                        Next
                        VendorBLL.DeletePrinciple(MainID)
                        For Each row As GridViewRow In GridView1.Rows
                            Dim ltattid = DirectCast(row.FindControl("ltattid"), Literal)
                            Dim dd_p = DirectCast(row.FindControl("ddprinciple"), DropDownList)
                            Dim p_name = DirectCast(row.FindControl("lblcontact"), Label)
                            Dim p_mobile = DirectCast(row.FindControl("lblmobile"), Label)
                            Dim p_email = DirectCast(row.FindControl("lblemail"), Label)
                            Dim p_city = DirectCast(row.FindControl("lblcity"), Label)

                            VendorBLL.InsertPrinciple(dd_p.SelectedValue, Session("UserId"), MainID)


                        Next


                        Response.Redirect("Vendor.aspx")
                    Else

                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please fill all details of selected primary contact')", True)


                    End If

                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyVendor", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    Dim flag As Boolean = False
                    For Each row As GridViewRow In GridView2.Rows
                        If flag = False Then
                            ' Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
                            Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                            Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
                            Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
                            Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
                            Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)
                            If ckselect.Checked = True And contactperson.Text = "" And mobile.Text = "" Then
                                flag = True

                            End If

                        End If
                    Next

                    If flag = False Then
                        Dim i As Int32 = 0
                        Dim VendorId As String
                        VendorId = VendorBLL.Insertvendor(txtVendorname.Text.Trim, ddltype.SelectedValue, txtaddressbill.Text, txtcitybill.Text.Trim, ddlstatebill.SelectedValue, ddlcountrybill.SelectedValue, txtpincodebill.Text.Trim, Session("UserId"), txtCstNo.Text, txtVatTinNo.Text, txtPaymentTerms.Text, txtgstno.Text, Convert.ToInt32(txtTermDays.Text))
                        For Each row As GridViewRow In GridView2.Rows
                            'Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
                            Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)

                            Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
                            Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
                            Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
                            Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)
                            'If radioselect.Checked = True Then
                            '    If contactperson.Text = "" Then
                            '        VendorBLL.DeleteVendor(VendorId)
                            '        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please select the valid contact person...')", True)
                            '    Else
                            '        VendorBLL.InsertContact(contactperson.Text, email.Text, mobile.Text, phone.Text, radioselect.Checked, VendorId, Session("UserId"))
                            '    End If
                            'Else
                            If contactperson.Text <> "" Or email.Text <> "" Or mobile.Text <> "" Or phone.Text <> "" Then
                                If i = 0 Then
                                    VendorBLL.InsertContact(contactperson.Text, email.Text, mobile.Text, phone.Text, 1, VendorId, Session("UserId"), 1)
                                Else

                                    VendorBLL.InsertContact(contactperson.Text, email.Text, mobile.Text, phone.Text, 0, VendorId, Session("UserId"), ckselect.Checked)
                                End If
                            End If
                            i += 1
                            'End If
                        Next
                        'If VendorId = "" Then
                        'Else
                        For Each row As GridViewRow In GridView1.Rows
                            Dim dd_p = DirectCast(row.FindControl("ddprinciple"), DropDownList)
                            Dim p_name = DirectCast(row.FindControl("lblcontact"), Label)
                            Dim p_mobile = DirectCast(row.FindControl("lblmobile"), Label)
                            Dim p_email = DirectCast(row.FindControl("lblemail"), Label)
                            Dim p_city = DirectCast(row.FindControl("lblcity"), Label)

                            VendorBLL.InsertPrinciple(dd_p.SelectedValue, Session("UserId"), VendorId)
                        Next
                        ''ProspectContactBLL.Insert("Mr.", txtname.Text.Trim, 0, txtemail.Text.Trim, txtmob.Text.Trim, txtofficeno.Text.Trim, "", Session("UserId"), "Vendor", MainID, Session("Audlog_Id"), "True", "", 0, Date.Now(), "", "", 0, "")
                        ' addPrincipleDetail(MainID)
                        Response.Redirect("Vendor.aspx")
                        'End If
                    Else

                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please fill all details of selected primary contact')", True)


                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyVendor", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub addPrincipleDetail(ByVal Pri_ID As Integer)
        Try
            If Pri_ID > 0 Then
                MainBLL.Delete(Pri_ID, "deletePrincipleDetail")
            End If

            'For i As Integer = 0 To GridView1.Rows.Count - 1
            '    Dim ddprinciple As DropDownList = DirectCast(GridView1.Rows(i).FindControl("ddprinciple"), DropDownList)
            '    Dim lblcontact As Label = DirectCast(GridView1.Rows(i).FindControl("lblcontact"), Label)
            '    Dim lblmobile As Label = DirectCast(GridView1.Rows(i).FindControl("lblmobile"), Label)
            '    Dim lblcity As Label = DirectCast(GridView1.Rows(i).FindControl("lblcity"), Label)
            '    Dim lblemail As Label = DirectCast(GridView1.Rows(i).FindControl("lblemail"), Label)
            'Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
                'For Each row As GridViewRow In GridView2.Rows
                '    ' Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
                '    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                '    Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
                '    Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
                '    Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
                '    Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)
                '    If ckselect.Checked = True And contactperson.Text <> "" And mobile.Text <> "" Then
                If MainID = 0 Then
                    SaveProduct(DML_OPERATION.INSERT)
                ElseIf MainID > 0 Then
                    SaveProduct(DML_OPERATION.UPDATE)
                End If
                'Else
                '    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please fill all details of selected primary contact')", True)
                'End If
                'Next
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "VendorViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            If dtUser.Rows.Count > 0 Then
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                txtVendorname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Name").ToString())
                txtCstNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_CstNo").ToString())
                txtVatTinNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_VatTinNo").ToString())
                txtgstno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_gstNo").ToString())
                ddltype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Type").ToString())
                txtaddressbill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Address").ToString())
                txtpincodebill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_PinCode").ToString())
                txtcitybill.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_City").ToString())
                ddlcountrybill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_Country").ToString())
                ddlcountrybill_SelectedIndexChanged(Nothing, Nothing)
                ddlstatebill.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_State").ToString())
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
                lblmodifieddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Vendor_ModifiedDate").ToString())
                'MyRadioButton1_CheckedChanged(Nothing, Nothing)
                txtPaymentTerms.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_PaymentTerms").ToString())
                txtTermDays.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Vendor_PaymentTermsDays").ToString())
                FillGridView2Data(dt)

                FillPrincipleViewByID(dt)
                For Each row As GridViewRow In GridView2.Rows
                    Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)

                    Dim rfvcntctprsn = DirectCast(row.FindControl("rfvcntctprsn"), RequiredFieldValidator)

                    rfvcntctprsn.Enabled = False
                Next

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillPrincipleViewByID(ByVal viewPrinciple As DataSet)
        Dim dsRcptDtl As DataSet
        Try
            'dsRcptDtl = VendorBLL.FillGridView("fillPrinciple")
            'Temptable = dsRcptDtl.Tables(0)
            'ViewState("CurrentTable") = Temptable
            'GridView1.DataSource = dsRcptDtl
            'GridView1.DataBind()

            dsRcptDtl = VendorBLL.FillGridViewByID("fillPrincipleByVendor", MainID)
            Temptable = dsRcptDtl.Tables(0)
            If Temptable.Rows.Count > 1 Then
                ViewState("Dropdown") = "None"
            Else
                ViewState("Dropdown") = ""
            End If
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()


        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("RcptDtlList", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillCountry()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("CountryDropDown")
            ddlcountrybill.DataSource = ds.Tables(0)
            ddlcountrybill.DataTextField = "CountryName"
            ddlcountrybill.DataValueField = "Id"
            ddlcountrybill.DataBind()
            ddlcountrybill.Items.Insert(0, New ListItem("Select Country", "0"))
            ddlcountrybill.SelectedValue = 105
            'ddlpCountry.DataSource = ds.Tables(0)
            'ddlpCountry.DataTextField = "CountryName"
            'ddlpCountry.DataValueField = "Id"
            'ddlpCountry.DataBind()
            'ddlpCountry.Items.Insert(0, New ListItem("Select Country", "0"))
            'ddlpCountry.SelectedValue = 105
            'ddlpCountry.CssClass = "form-control"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillStatebill()
        Try
            ddlstatebill.Items.Clear()
            Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountrybill.SelectedValue)
            ddlstatebill.DataSource = ds.Tables(0)
            ddlstatebill.DataTextField = "StateName"
            ddlstatebill.DataValueField = "Id"
            ddlstatebill.DataBind()
            ddlstatebill.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub FillPStatebill()
        Try
            'ddlpstate.Items.Clear()
            'Dim ds As DataSet = MainBLL.DropdownWithID("StateDropDown", ddlcountrybill.SelectedValue)
            'ddlpstate.DataSource = ds.Tables(0)
            'ddlpstate.DataTextField = "StateName"
            'ddlpstate.DataValueField = "Id"
            'ddlpstate.DataBind()
            'ddlpstate.Items.Insert(0, New ListItem("Select State", "0"))
            'ddlpstate.CssClass = "form-control"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FillStatebill", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Protected Sub ddlcountrybill_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlcountrybill.SelectedIndexChanged
        Try
            FillStatebill()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "ddlcountrybill_SelectedIndexChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Sub AtLeastOneContact_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
    '    If txtemail.Text & txtofficeno.Text & txtmob.Text <> "" Then
    '        args.IsValid = True
    '    Else
    '        args.IsValid = False
    '    End If
    'End Sub
    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Request.QueryString("returnurl") = "y" And MainID <> 0 Then
                Response.Redirect("ViewVendor.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
            ElseIf Request.QueryString("is") = "c" Then
                Response.Redirect("Importstatus.aspx")
            ElseIf Request.QueryString("returnurl") = Nothing And Request.QueryString("is") = Nothing Then
                Response.Redirect("Vendor.aspx")
            ElseIf Request.QueryString("returnurl") = "y" And MainID = 0 Then
                Response.Redirect("Vendor.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
  


    ''Created by ajay on 24-12-2016 for new updates     
    Public Sub fillRcptDtl()
        Dim dsRcptDtl As DataSet
        Try
            dsRcptDtl = VendorBLL.FillGridView("fillPrinciple")
            Temptable = dsRcptDtl.Tables(0)
            ViewState("CurrentTable") = Temptable
            GridView1.DataSource = dsRcptDtl
            GridView1.DataBind()

        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert("RcptDtlList", "fillRcptDtl", errorMsg, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Try
            If e.CommandName = "AddNewRow" Then
                AddNewRow()
            ElseIf e.CommandName = "Add" Then
                ViewState("Dropdown") = ""
                FirstGridViewRow()
            ElseIf e.CommandName = "deletelink" Then
                If ViewState("CurrentTable") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()
                        ViewState("CurrentTable") = dt
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        For i As Integer = 0 To GridView1.Rows.Count - 2
                            GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next
                    End If
                End If
                SetPreviousData()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVisa", "Gridview4_RowCommand", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)

        End Try
    End Sub
    Private Sub FirstGridViewRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ID", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ContactPerson", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_MobileNo", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_City", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_EmailID", GetType(String)))
            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            dr("Principle_ID") = String.Empty
            dr("Principle_ContactPerson") = String.Empty
            dr("Principle_MobileNo") = String.Empty
            dr("Principle_City") = String.Empty
            dr("Principle_EmailID") = String.Empty

            dt.Rows.Add(dr)
            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVisa", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddNewRow()
        Try
            Dim rowIndex As Integer = 0
            'addrowtype.Text = "NEW"

            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim ddprinciple As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddprinciple"), DropDownList)
                        Dim lblcontact As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblcontact"), Label)
                        Dim lblmobile As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblmobile"), Label)
                        Dim lblemail As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblemaillblcity"), Label)
                        Dim lblcity As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblcity"), Label)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        'drCurrentRow("RcptDtl_ID") = "0"

                        dtCurrentTable.Rows(i - 1)("Principle_ID") = ddprinciple.SelectedValue
                        rowIndex += 1
                    Next

                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("CurrentTable") = dtCurrentTable
                    GridView1.DataSource = dtCurrentTable
                    GridView1.DataBind()
                End If
            Else
                Response.Write("ViewState is null")
            End If
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVisa", "AddNewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("CurrentTable") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("CurrentTable"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ddprinciple As DropDownList = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("ddprinciple"), DropDownList)
                        Dim lblcontact As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblcontact"), Label)
                        Dim lblmobile As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblmobile"), Label)
                        Dim lblemail As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblemail"), Label)
                        Dim lblcity As Label = DirectCast(GridView1.Rows(rowIndex).Cells(0).FindControl("lblcity"), Label)
                        GridView1.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        ddprinciple.SelectedValue = dt.Rows(i)("Principle_ID").ToString
                        lblcontact.Text = dt.Rows(i)("Principle_ContactPerson").ToString
                        lblmobile.Text = dt.Rows(i)("Principle_MobileNo").ToString
                        lblcity.Text = dt.Rows(i)("Principle_City").ToString
                        lblemail.Text = dt.Rows(i)("Principle_EmailID").ToString
                        rowIndex += 1
                    Next
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim ddprinciple As DropDownList = DirectCast(e.Row.FindControl("ddprinciple"), DropDownList)
            Dim ddprinciple As DropDownList = TryCast(e.Row.FindControl("ddprinciple"), DropDownList)
            Dim ltattid As Literal = DirectCast(e.Row.FindControl("ltattid"), Literal)

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ds As New DataSet

                ds = MainBLL.Dropdown("PrincipleDropDown")
               
                If ViewState("Dropdown") = "None" Then
                    For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
                        Dim dr As DataRow = ds.Tables(0).Rows(i)
                        If dr("Principle_CompanyName") = "None" Then
                            dr.Delete()
                            ViewState("PrincpleDropdown") = ds
                        End If
                    Next
                    ds = ViewState("PrincpleDropdown")
               
                End If
                ddprinciple.DataSource = ds.Tables(0)
                'ddprinciple.DataSource = MainBLL.Dropdown("PrincipleDropDown")
                ddprinciple.DataTextField = "Principle_CompanyName"
                ddprinciple.DataValueField = "Principle_ID"
                ddprinciple.DataBind()
                ddprinciple.Items.Insert(0, "Select Principle")
                ddprinciple.SelectedValue = ltattid.Text
            End If

        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddprinciple_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            Dim ddprinciple As DropDownList = DirectCast(sender, DropDownList)
            Dim row As GridViewRow = DirectCast(ddprinciple.NamingContainer, GridViewRow)
            Dim lblcontact As Label = DirectCast(row.FindControl("lblcontact"), Label)
            Dim lblmobile As Label = DirectCast(row.FindControl("lblmobile"), Label)
            Dim lblemail As Label = DirectCast(row.FindControl("lblemail"), Label)
            Dim lblcity As Label = DirectCast(row.FindControl("lblcity"), Label)
            Dim ltattid As Literal = DirectCast(row.FindControl("ltattid"), Literal)
            Dim lnkadd As LinkButton = DirectCast(GridView1.FooterRow.FindControl("lnkadd"), LinkButton)
            Dim rfvddprinciple As RequiredFieldValidator = DirectCast(row.FindControl("rfvddprinciple"), RequiredFieldValidator)
            Dim ds As New DataSet
            ds = MainBLL.Dropdown("PrincipleDropDown")
           
            If ddprinciple.SelectedValue = "Select Principle" Then


                rfvddprinciple.Enabled = True
                lblcontact.Text = ""
                lblmobile.Text = ""
                lblemail.Text = ""
                lblcity.Text = ""
            Else

                hfbarcodechk.Value = ddprinciple.SelectedValue
                If hfbarcodechk.Value = 0 Then
                    lnkadd.Visible = False
                    ViewState("Dropdown") = ""
                Else

                    lnkadd.Visible = True
                    ViewState("Dropdown") = "None"
                    For i As Integer = ds.Tables(0).Rows.Count - 1 To 0 Step -1
                        Dim dr As DataRow = ds.Tables(0).Rows(i)
                        If dr("Principle_CompanyName") = "None" Then
                            dr.Delete()
                            ViewState("PrincpleDropdown") = ds
                        End If
                    Next
                    ddprinciple.DataSource = ds.Tables(0)
                    ddprinciple.DataTextField = "Principle_CompanyName"
                    ddprinciple.DataValueField = "Principle_ID"
                    ddprinciple.DataBind()


                End If







                'Dim ds As New DataSet
                ds = MainBLL.ViewByID(ddprinciple.SelectedValue, "GetPrincipleRecordViewByID")
                Dim dt As New DataTable
                dt = ds.Tables(0)

                If dt.Rows.Count > 0 Then
                    Dim dr As DataRow = dt.Rows(0)
                    lblcontact.Text = ds.Tables(0).Rows(0)(2)
                    lblmobile.Text = ds.Tables(0).Rows(0)(4)
                    lblemail.Text = ds.Tables(0).Rows(0)(3)
                    lblcity.Text = ds.Tables(0).Rows(0)(6)
                    'dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
                    'dr = dt.NewRow()
                    'If strrowcount Is Nothing Then
                    '    dr("RowNumber") = 1
                    'Else
                    '    dr("RowNumber") = strrowcount.Value
                    'End If
                    'ViewState("CurrentTable") = dt


                    'dr("RowNumber") = strrowcount.Value + 1
                    'strrowcount.Value = dr("RowNumber")

                    'drCurrentRow("RcptDtl_ID") = "0"
                    'If ViewState("CurrentTable") Is Nothing Then
                    '    ViewState("CurrentTable") = dt
                    'Else
                    '    Dim dtmerg As New DataTable
                    '    Dim dr2 As DataRow = Nothing
                    '    dr2 = dt.NewRow()
                    '    dt.Rows.Add(dr2)
                    '    ViewState("CurrentTable") = dt
                    'End If
                    Dim dtviewcount As DataTable = ViewState("CurrentTable")
                    If dtviewcount.Rows.Count = 1 Then
                        dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
                        dt.Rows(0)("RowNumber") = 1
                        ViewState("CurrentTable") = dt

                    Else
                        'Dim dtCurrentTsble As DataTable = ViewState("CurrentTable")
                        'dtCurrentTsble.Merge(dt, True, MissingSchemaAction.Ignore)
                        ''dtCurrentTsble.Merge(dt)
                        'dtCurrentTsble.AcceptChanges()
                        'ViewState("CurrentTable") = dtCurrentTsble
                        Dim getrowno As Integer = dtviewcount.Rows.Count - 1


                        dtviewcount.Rows(getrowno)("Principle_ID") = hfbarcodechk.Value
                        dtviewcount.Rows(getrowno)("Principle_ContactPerson") = lblcontact.Text
                        dtviewcount.Rows(getrowno)("Principle_MobileNo") = lblmobile.Text
                        dtviewcount.Rows(getrowno)("Principle_City") = lblcity.Text
                        dtviewcount.Rows(getrowno)("Principle_EmailID") = lblemail.Text
                        '  dtviewcount.Rows.InsertAt(dr, dtviewcount.Rows.Count)
                    End If


                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FirstGridViewRowWithPenelty(ByVal amt As Double)
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ID", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_ContactPerson", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_MobileNo", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_City", GetType(String)))
            dt.Columns.Add(New DataColumn("Principle_EmailID", GetType(String)))

            dr = dt.NewRow()
            dr("RowNumber") = 1
            dr("Principle_ID") = "1"
            dr("Principle_ContactPerson") = String.Empty
            dr("Principle_MobileNo") = String.Empty
            dr("Principle_City") = String.Empty
            dr("Principle_EmailID") = String.Empty

            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("RowNumber") = 2
            dr("Principle_ID") = String.Empty
            dr("Principle_ContactPerson") = String.Empty
            dr("Principle_MobileNo") = String.Empty
            dr("Principle_City") = String.Empty
            dr("Principle_EmailID") = String.Empty
            dt.Rows.Add(dr)


            ViewState("CurrentTable") = dt
            GridView1.DataSource = dt
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVisa", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub FirstGridView2Row()
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Id", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_ContactPerson", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Mobile", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Landline", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Email", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Primary", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_IsSecondary", GetType(String)))

            For rowcount As Integer = 1 To 5
                dr = dt.NewRow()
                dr("RowNumber") = rowcount
                dr("Contact_Id") = String.Empty
                dr("Contact_ContactPerson") = String.Empty
                dr("Contact_Mobile") = String.Empty
                dr("Contact_Landline") = String.Empty
                dr("Contact_Email") = String.Empty
                dr("Contact_Primary") = String.Empty
                dr("Contact_IsSecondary") = String.Empty

                dt.Rows.Add(dr)
            Next
            
            GridView2.DataSource = dt
            GridView2.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FirstGridViewRow", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub FillGridView2Data(ByVal ViewData As DataSet)
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Id", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_ContactPerson", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Mobile", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Landline", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Email", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_Primary", GetType(String)))
            dt.Columns.Add(New DataColumn("Contact_IsSecondary", GetType(String)))
            'For rowcount As Integer = 1 To 5
            '    dr = dt.NewRow()
            '    dr("RowNumber") = rowcount
            '    dr("Contact_Id") = DynamicparcelDataManipulation.FixNullFromDB("Contact_Id")
            '    dr("Contact_ContactPerson") = DynamicparcelDataManipulation.FixNullFromDB("Contact_ContactPerson")
            '    dr("Contact_Mobile") = DynamicparcelDataManipulation.FixNullFromDB("Contact_Mobile")
            '    dr("Contact_Landline") = DynamicparcelDataManipulation.FixNullFromDB("Contact_Landline")
            '    dr("Contact_Email") = DynamicparcelDataManipulation.FixNullFromDB("Contact_Email")
            '    dt.Rows.Add(dr)
            'Next

            Dim dtLogin As New DataTable
            Dim rowcount As Integer
            dtLogin = ViewData.Tables(0)
            If dtLogin.Rows.Count > 0 Then
                Dim drLogin As DataRow
                For Each drLogin In dtLogin.Rows
                    dr = dt.NewRow()
                    rowcount = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RowNumber").ToString())
                    dr("RowNumber") = rowcount
                    dr("Contact_Id") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Id").ToString())
                    dr("Contact_ContactPerson") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_ContactPerson"))
                    dr("Contact_Mobile") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Mobile"))
                    dr("Contact_Landline") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Landline"))
                    dr("Contact_Email") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Email"))
                    dr("Contact_Primary") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_Primary"))
                    dr("Contact_IsSecondary") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Contact_IsSecondary"))

                    dt.Rows.Add(dr)

                Next
                If rowcount <= 5 Then
                    For rCount As Integer = rowcount + 1 To 5
                        dr = dt.NewRow()
                        dr("RowNumber") = rCount
                        dr("Contact_Id") = String.Empty
                        dr("Contact_ContactPerson") = String.Empty
                        dr("Contact_Mobile") = String.Empty
                        dr("Contact_Landline") = String.Empty
                        dr("Contact_Email") = String.Empty
                        dr("Contact_Primary") = String.Empty
                        dr("Contact_IsSecondary") = String.Empty

                        dt.Rows.Add(dr)
                    Next

                End If
            End If
            For Each row As GridViewRow In GridView2.Rows

                Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)

                Dim rfvcntctprsn As RequiredFieldValidator = DirectCast(row.FindControl("rfvcntctprsn"), RequiredFieldValidator)
                rfvcntctprsn.Enabled = False

            Next
            GridView2.DataSource = dt
            GridView2.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "FillGridView2Data", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub MyRadioButton1_CheckedChanged(sender As Object, e As EventArgs)
        deselectradiobutton()
        Dim SenderRB As RadioButton = sender
        SenderRB.Checked = True

    End Sub
    Protected Sub ckselect_CheckedChanged(sender As Object, e As EventArgs)
        'For Each row As GridViewRow In GridView2.Rows
        '    ' Dim radioselect = DirectCast(row.FindControl("MyRadioButton1"), RadioButton)
        '    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
        '    Dim contactperson = DirectCast(row.FindControl("txtserialno4"), TextBox)
        '    Dim email = DirectCast(row.FindControl("txtserialno2"), TextBox)
        '    Dim mobile = DirectCast(row.FindControl("txtserialno3"), TextBox)
        '    Dim phone = DirectCast(row.FindControl("txtserialno1"), TextBox)
        '    Dim rfv As RequiredFieldValidator = DirectCast(row.FindControl("rfvcntctprsn"), RequiredFieldValidator)

        '    If ckselect.Checked = True And contactperson.Text = "" And mobile.Text = "" Then
        '        rfv.Enabled = True
        '    Else
        '        rfv.Enabled = False
        '    End If
        'Next
        'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please fill all details of selected primary contact')", True)
    End Sub
    Protected Sub deselectradiobutton()
        Dim gvr As GridViewRow
        Dim i As Int32
        For Each gvr In GridView2.Rows
            Dim rb As RadioButton
            rb = DirectCast(GridView2.Rows(i).FindControl("MyRadioButton1"), RadioButton)
            rb.Checked = False
            i += 1
        Next
    End Sub
    Protected Sub radioselected()
        Dim gvr As GridViewRow
        Dim i As Int32
        For Each gvr In GridView2.Rows
            Dim rb As RadioButton
            rb = DirectCast(GridView2.Rows(i).FindControl("MyRadioButton1"), RadioButton)
            If rb.Checked = True Then
                rb.Checked = True

            Else
                rb.Checked = False
            End If
            i += 1
        Next
    End Sub
    Public Sub disableradiobtn()
        Dim gvr As GridViewRow
        Dim i As Int32
        For Each gvr In GridView2.Rows
            'Dim rb As RadioButton
            Dim cb As CheckBox
            cb = DirectCast(gvr.FindControl("ckselect"), CheckBox)
            '  rb = DirectCast(gvr.FindControl("MyRadioButton1"), RadioButton)

            Dim rfv As RequiredFieldValidator = DirectCast(gvr.FindControl("rfvcntctprsn"), RequiredFieldValidator)

            If i = 0 Then
                '  cb.Checked = True
                cb.Enabled = False
                rfv.Enabled = True
            Else
                ' cb.Checked = False
                ' rfv.Enabled = False
            End If
            i = i + 1
        Next
    End Sub

    Public Sub selectradiobtn()
        Dim gvr As GridViewRow
        Dim i As Int32
        For Each gvr In GridView2.Rows
            'Dim rb As RadioButton
            Dim cb As CheckBox
            cb = DirectCast(gvr.FindControl("ckselect"), CheckBox)
            '  rb = DirectCast(gvr.FindControl("MyRadioButton1"), RadioButton)

            Dim rfv As RequiredFieldValidator = DirectCast(gvr.FindControl("rfvcntctprsn"), RequiredFieldValidator)

            If i = 0 Then
                cb.Checked = True
                cb.Enabled = False
                rfv.Enabled = True
            Else
                cb.Checked = False
                rfv.Enabled = False
            End If
            i = i + 1
        Next
    End Sub





    Public Sub fillVendortype()
        Try
            ddltype.DataSource = MainBLL.Dropdown("VendorTypeDropDown")
            ddltype.DataTextField = "VendorType_Name"
            ddltype.DataValueField = "VendorType_ID"
            ddltype.DataBind()
            ddltype.Items.Insert(0, "Select Vendor Type")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyVendor", "fillVendortype", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub




End Class
