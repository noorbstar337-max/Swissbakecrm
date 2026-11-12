Imports DynamicparcelEnumerations
Partial Class ModifyTax
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim TaxCharge As Boolean
    Dim HashAssignTo As Hashtable = New Hashtable
    Dim taxid As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
        If (Request.QueryString("Id") = Nothing) Then
            Response.Redirect("index.aspx")
        End If
        If Request.QueryString("chk") = "v" Then
            divpart1.Visible = True
            btnadd.Visible = False
            btnsavecharge.Visible = False
            rdbtaxprincipal.Enabled = False
            rdbtaxtax.Enabled = False
            rdbaddition.Enabled = False
            rdbsubtraction.Enabled = False
            txttaxname.ReadOnly = True
            txttaxpercent.ReadOnly = True
            txtsequence.ReadOnly = True
            chkaddprincipal.Enabled = False
            chkeditable.Enabled = False
            rdbtaxtax_CheckedChanged(Nothing, Nothing)
            rdbtaxtaxmod_CheckedChanged(Nothing, Nothing)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "Page_Init", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                MappingTaxNameControl.Uhftypeid.Value = MainID
                If MainID = "0" Then
                    divpart2.Visible = True
                    divpart1.Visible = False
                    txtsequencemod.Text = MainBLL.GetCode("TaxSequenceNo")
                    txtseq_chargemod.Text = MainBLL.GetCode("AddChargeSequenceNo")
                    divtaxmapcontrol.Visible = False
                    divtaxmapcontrolmod.Visible = False
                Else
                    divpart2.Visible = False
                    divpart1.Visible = True
                    FillDetail()
                    FillDetailAddCharges()
                    rdbtaxtax_CheckedChanged(Nothing, Nothing)
                    checkTab()
                End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub checkTab()
        Try
            If txttaxname.Text = Nothing Then
                addcharge.Attributes("class") = "active"
                tabss.Visible = True
                tabsss.Visible = False
            Else
                taxx.Attributes("class") = "active"
                tabsss.Visible = True
                tabss.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "checkTab", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub SaveTax(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    If txttaxname.Text <> "" Then
                        TaxCharge = "True"
                    Else
                        TaxCharge = "False"
                    End If

                    Dim CheckPageName As String = ""
                    If Not txtsequence.Text = hfTax.Value Then
                        CheckPageName = MainBLL.CheckSequenceNo(txtsequence.Text.Trim, "CheckTaxSequenceNo")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lbltaxseqno.Text = "Sequence number already exist"
                        txtsequence.Focus()
                    Else
                        TaxBLL.Update(txttaxname.Text.Trim, txttaxpercent.Text, chkeditable.Checked, chkaddprincipal.Checked, rdbaddition.Checked, rdbsubtraction.Checked, rdbtaxprincipal.Checked, rdbtaxtax.Checked, TaxCharge, txtsequence.Text, Session("UserId"), MainID, Session("Audlog_Id"))
                        MappingTaxNameControl.AddAssignTo(MainID, MainID)
                        Response.Redirect("Tax.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTax", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If txttaxnamemod.Text <> "" Then
                        TaxCharge = "True"
                    Else
                        TaxCharge = "False"
                    End If

                    Dim CheckPageName As String = MainBLL.CheckSequenceNo(txtsequencemod.Text.Trim, "CheckTaxSequenceNo")
                    If (CheckPageName = "Already Exist") Then
                        lbltaxseqnomod.Text = "Sequence number already exist"
                        txtsequencemod.Focus()
                    Else
                        taxid = TaxBLL.Insert(txttaxnamemod.Text.Trim, txttaxpercentmod.Text, chkeditablemod.Checked, chkaddprincipalmod.Checked, rdbadditionmod.Checked, rdbsubtractionmod.Checked, rdbtaxprincipalmod.Checked, rdbtaxtaxmod.Checked, TaxCharge, txtsequencemod.Text, Session("UserId"), Session("Audlog_Id"))
                        MappingTaxNameControl.AddAssignTo(MainID, taxid)
                        Response.Redirect("Tax.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTax", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveTax(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveTax(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "TaxViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            If dtUser.Rows.Count > 0 Then
                drLogin = dtUser.Rows(0)
                txttaxname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Name").ToString())
                txttaxpercent.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Percentage").ToString())
                chkeditable.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Editable").ToString())
                chkaddprincipal.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_AddtoPrincipal").ToString())
                rdbtaxprincipal.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_TaxOnPrincipal").ToString())
                rdbtaxtax.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Tax").ToString())
                txtsequence.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_SortOrder").ToString())
                hfTax.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_SortOrder").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDetailAddCharges()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "AddChargeViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            If dtUser.Rows.Count > 0 Then
                drLogin = dtUser.Rows(0)
                txttaxname_charge.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Name").ToString())
                txtaddcharge_charge.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Percentage").ToString())
                chkeditax_charge.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Editable").ToString())
                chkaddprin_charge.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_AddtoPrincipal").ToString())
                rdbaddition.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Addtion").ToString())
                rdbsubtraction.Checked = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_Subtraction").ToString())
                txtseq_charge.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_SortOrder").ToString())
                hfaddcharge.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Tax_SortOrder").ToString())
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "FillDetailAddCharges", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnsavecharge_Click(sender As Object, e As EventArgs) Handles btnsavecharge.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If MainID = 0 Then
                SaveTaxAddcharge(DML_OPERATION.INSERT)
            ElseIf MainID > 0 Then
                SaveTaxAddcharge(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "btnsavecharge_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Private Sub SaveTaxAddcharge(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try

                    If txttaxname_charge.Text <> "" Then
                        TaxCharge = "False"
                    Else
                        TaxCharge = "True"
                    End If

                    Dim CheckPageName As String = ""
                    If Not txtseq_charge.Text = hfaddcharge.Value Then
                        CheckPageName = MainBLL.CheckSequenceNo(txtseq_charge.Text.Trim, "CheckAddChargeSequenceNo")
                    End If

                    If (CheckPageName = "Already Exist") Then
                        lbladdcharge.Text = "Sequence number already exist"
                        txtseq_charge.Focus()
                    Else
                        TaxBLL.Update(txttaxname_charge.Text.Trim, txtaddcharge_charge.Text, chkeditax_charge.Checked, chkaddprin_charge.Checked, rdbaddition.Checked, rdbsubtraction.Checked, rdbtaxprincipal.Checked, rdbtaxtax.Checked, TaxCharge, txtseq_charge.Text, Session("UserId"), MainID, Session("Audlog_Id"))
                        Response.Redirect("Tax.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTax", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If txttaxname_chargemod.Text <> "" Then
                        TaxCharge = "False"
                    Else
                        TaxCharge = "True"
                    End If
                    Dim CheckPageName As String = MainBLL.CheckSequenceNo(txtseq_chargemod.Text.Trim, "CheckAddChargeSequenceNo")
                    If (CheckPageName = "Already Exist") Then
                        lbladdchargemod.Text = "Sequence number already exist"
                        txtseq_chargemod.Focus()
                    Else
                        TaxBLL.Insert(txttaxname_chargemod.Text.Trim, txtaddcharge_chargemod.Text, chkeditax_chargemod.Checked, chkaddprin_chargemod.Checked, rdbadditionmod.Checked, rdbsubtractionmod.Checked, rdbtaxprincipalmod.Checked, rdbtaxtaxmod.Checked, TaxCharge, txtseq_chargemod.Text, Session("UserId"), Session("Audlog_Id"))
                        Response.Redirect("Tax.aspx")
                    End If
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTax", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub rdbtaxtax_CheckedChanged(sender As Object, e As EventArgs) Handles rdbtaxtax.CheckedChanged
        Try
        If rdbtaxtax.Checked Then
            divtaxmapcontrol.Visible = True
            chkaddprincipal.Visible = False
        Else
            divtaxmapcontrol.Visible = False
            chkaddprincipal.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "rdbtaxtax_CheckedChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rdbtaxtaxmod_CheckedChanged(sender As Object, e As EventArgs) Handles rdbtaxtaxmod.CheckedChanged
        Try
        If rdbtaxtaxmod.Checked Then
            divtaxmapcontrolmod.Visible = True
            chkaddprincipalmod.Visible = False
        Else
            divtaxmapcontrolmod.Visible = False
            chkaddprincipalmod.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "rdbtaxtaxmod_CheckedChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnaddmod_Click(sender As Object, e As EventArgs) Handles btnaddmod.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveTax(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveTax(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "btnaddmod_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsavechargemod_Click(sender As Object, e As EventArgs) Handles btnsavechargemod.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveTaxAddcharge(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveTaxAddcharge(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTax", "btnsavechargemod_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


End Class
