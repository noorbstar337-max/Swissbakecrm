Imports DynamicparcelEnumerations
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Partial Class ModifyTrials
    Inherits System.Web.UI.Page
    Dim Flag As Integer
    Dim Flag1 As Integer
    Dim MainID As Integer
    Dim PageID As Integer
    Dim Fid As Integer
    Dim M As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                'Dim dsPriv As DataSet = LMSPrivilegeBLL.ChkLMSPrivilegeTrails(2)
                Dim dsPriv As DataSet = LMSPrivilegeBLL.ChkLMSPrivilegeTrails(Session("LMSUserRoleID"))
                Dim dtPriv As DataTable = dsPriv.Tables(0)
                If dtPriv.Rows.Count > 0 Then
                    If Request.QueryString("chk") = "e" Then  'For Edit
                        If dtPriv.Rows(0)("Prvg_RUpdate") = True And dtPriv.Rows(1)("Prvg_RUpdate") = False Then
                            hfAccessFor.Value = "Formulation"
                        ElseIf dtPriv.Rows(0)("Prvg_RUpdate") = False And dtPriv.Rows(1)("Prvg_RUpdate") = True Then
                            hfAccessFor.Value = "Recipe"
                        ElseIf dtPriv.Rows(0)("Prvg_RUpdate") = True And dtPriv.Rows(1)("Prvg_RUpdate") = True Then
                            hfAccessFor.Value = "Both"
                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    ElseIf Request.QueryString("chk") = "v" Then  'For View
                        If dtPriv.Rows(0)("Prvg_Rview") = True And dtPriv.Rows(1)("Prvg_Rview") = False Then
                            hfAccessFor.Value = "Formulation"
                        ElseIf dtPriv.Rows(0)("Prvg_Rview") = False And dtPriv.Rows(1)("Prvg_Rview") = True Then
                            hfAccessFor.Value = "Recipe"
                        ElseIf dtPriv.Rows(0)("Prvg_Rview") = True And dtPriv.Rows(1)("Prvg_Rview") = True Then
                            hfAccessFor.Value = "Both"
                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    Else         ' for add new 
                        If dtPriv.Rows(0)("Prvg_RAdd") = True And dtPriv.Rows(1)("Prvg_RAdd") = False Then
                            hfAccessFor.Value = "Formulation"
                        ElseIf dtPriv.Rows(0)("Prvg_RAdd") = False And dtPriv.Rows(1)("Prvg_RAdd") = True Then
                            'hfAccessFor.Value = "Recipe"
                            Response.Redirect("LMSDashboard.aspx")
                        ElseIf dtPriv.Rows(0)("Prvg_RAdd") = True And dtPriv.Rows(1)("Prvg_RAdd") = True Then
                            hfAccessFor.Value = "Both"
                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    End If
                Else
                    Response.Redirect("LMSDashboard.aspx")
                End If

                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                'LMSassigncontrol.Uhftype.Value = "Formulation"
                ''LMSassigncontrol.Uhftypeid.Value = MainID
                TextBox1.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                txtGetdate.Text = Date.Now.Date.AddDays(-1).ToString("yyyy-MM-dd")
                ddlDate.Text = Date.Now.Date.ToString("yyyy-MM-dd")
                ddlDate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
                If hfAccessFor.Value = "Formulation" Then
                    LMSassigncontrol1.Uhftype.Value = "Formulation"
                    LMSassigncontrol1.Uhftypeid.Value = PageID
                    LoadFormulation()
                    divRecipe1.Visible = False
                    Session("AccessFor") = "Formulation"
                ElseIf hfAccessFor.Value = "Recipe" Then
                    divFormulation.Visible = False
                    Fillcomparebutton()
                    FillRecipeId()
                    LoadRecipe()

                    LMSassigncontrol1.Uhftype.Value = "Recipe"
                    LMSassigncontrol1.Uhftypeid.Value = ViewState("Recipe_Id")
                    btnOnlyRecipeSave.Visible = True
                    btnBothFormReciSave.Visible = False
                    Session("AccessFor") = "Recipe"
                ElseIf hfAccessFor.Value = "Both" Then
                    btnOnlyRecipeSave.Visible = False
                    btnBothFormReciSave.Visible = True
                    LoadFormulation()
                    'LoadRecipe()
                    LMSassigncontrol1.Uhftype.Value = "Both"
                    LMSassigncontrol1.Uhftypeid.Value = ViewState("Recipe_Id")
                    Session("AccessFor") = "Both"

                Else
                    Response.Redirect("LMSDashboard.aspx")
                End If

                'LoadFormulation()
                ' ''ddlDate.Attributes("min") = DateTime.Now.ToString("yyyy-MM-dd")
            End If

        Catch ex As Exception

        End Try
    End Sub
   
    Private Sub LoadFormulation()
        PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If PageID = 0 Then
            lblTrialCode.Visible = False
            'LMSassigncontrol.Uhftype.Value = "Formulation"
            btnprint.Visible = False
            btnprintblank.Visible = False
            modifyspan.Visible = False

            FillddlProductForm()
            FillFormulationNo()
            ddlFormulationType_SelectedIndexChanged(Nothing, Nothing)
        Else
            lblTrialCode.Visible = True
            pnlForm.Enabled = False
            ViewState("Formulation_Id") = PageID
            btnSubmit.Visible = False
            ' ''btnprint.Visible = False
            ' ''btnprintblank.Visible = False
            btnprint.Visible = True
            btnprintblank.Visible = True
            modifyspan.Visible = True

            DisableProdz()
            FillddlProductForm()
            gvLMS.Visible = True
            'btnFormulationSaveNext.Visible = True
            btnFormulationSave.Visible = True
            If Session("LMSUserRoleID") = 1 Then
                btnFormulationSaveApprove.Visible = True
                btnCalc.Visible = True
            Else
                btnFormulationSaveApprove.Visible = False
                btnCalc.Visible = False
            End If
            ' ''btnCalc.Visible = True
            FillDetailForm()
            getMaxFormIDByProdId()
            btnCalc_Click(Nothing, Nothing)
            'FillFormulationHistory()
            'btnCompareForm.Visible = True
            'LMSassigncontrol1.Uhftype.Value = "Recipe"
            If hfAccessFor.Value = "Both" Then
                btnFormulationCancel.Visible = False
                btnFormulationSaveApprove.Visible = False
                btnFormulationSave.Visible = False
                LoadRecipe()
            End If

            ''If divRecipe1.Visible = True Then
            ''    btnFormulationSave.Visible = False
            ''    btnFormulationSaveApprove.Visible = False
            ''    btnFormulationCancel.Visible = False
            ''Else
            ''    btnFormulationSave.Visible = True
            ''    btnFormulationSaveApprove.Visible = True
            ''    btnFormulationCancel.Visible = True
            ''End If
            If Request.QueryString("chk") = "v" Then
                DisableViewMode()
            End If
        End If
    End Sub
#Region "Formulation"
    Public Sub Fillcomparebutton()
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

        Dim dt As DataSet = LMSBLL.FillGridByID(MainID, "DisplayFormulation")
        Dim dtUser As New DataTable
        dtUser = dt.Tables(0)
        'If dtUser.Rows.Count > 0 Then
        Dim drLogin As DataRow
        drLogin = dtUser.Rows(0)
        Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
        Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))


        If FType = "Product" And ProdID = 0 Then
            ddlFormulationType.SelectedValue = 1
        ElseIf FType = "Competitor" And ProdID = 0 Then
            ddlFormulationType.SelectedValue = 2
        ElseIf FType = "Product" And ProdID <> 0 Then
            ddlFormulationType.SelectedValue = 0
        End If
        If ProdID = 0 Then
            txtProduct.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdName"))
        Else

            ddlProduct.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
        End If
        ddlMixTypeForm.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))

    End Sub
    Public Sub FillddlProductForm()
        Try
            Dim ds As DataSet
            ds = LMSBLL.Dropdown("FillProductByMixType")
            ddlProduct.DataSource = ds.Tables(0)
            ddlProduct.DataTextField = "Product_Name"
            ddlProduct.DataValueField = "Product_Id"
            ddlProduct.DataBind()
            ddlProduct.Items.Insert(0, New ListItem("Select Product", "-1"))

            ddlLinkProd.DataSource = ds.Tables(0)
            ddlLinkProd.DataTextField = "Product_Name"
            ddlLinkProd.DataValueField = "Product_Id"
            ddlLinkProd.DataBind()
            ddlLinkProd.Items.Insert(0, New ListItem("Select Product", "-1"))
            'ddlProduct.Items.Insert(0, "Select Product")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub FillFormulationNo()
        Try
            Dim FormulationNo As String = LMSBLL.FormulationNo()
            lblFormulationNo.Text = FormulationNo
            hfFRNo.Value = FormulationNo
            ''LMSassigncontrol.UhfTypeCode.Value = FormulationNo
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub DisableProdz()
        Try
            ddlFormulationType.Enabled = False
            ddlProduct.Enabled = False
            txtProduct.Enabled = False
            ddlMixTypeForm.Enabled = False
            ddlDate.Enabled = False
            ddlPriority.Enabled = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub
    Private Sub DisableViewMode()
        Try
            DisableProdz()
            txtQuantityForm.Enabled = False
            ddlDate.Enabled = False
            btnSubmit.Visible = False
            gvLMS.Enabled = False
            btnCalc.Visible = False
            btnCompareForm.Visible = False
            lblCompForm.Visible = False
            divCompForm.Visible = False
            btnFormulationSaveApprove.Visible = False
            btnFormulationSaveNext.Visible = False
            btnFormulationSave.Visible = False
            Dim lnkadd As LinkButton = DirectCast(gvLMS.FooterRow.FindControl("lnkadd"), LinkButton)
            lnkadd.Visible = False
            For i As Integer = 0 To gvLMS.Rows.Count - 1
                Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(i).FindControl("lnkdelete"), LinkButton)
                lnkdelete.Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub
    Protected Sub ddlFormulationType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFormulationType.SelectedIndexChanged
        Try
            If ddlFormulationType.SelectedValue = 0 Then
                divDDLProduct.Visible = True
                divTxtProduct.Visible = False
                divCompeteProd.Visible = False
                ' gvLMS.Visible = True
                ddlMixTypeForm.Enabled = False
                ddlProduct_SelectedIndexChanged(Nothing, Nothing)
            Else
                If ddlFormulationType.SelectedValue = 2 Then
                    divCompeteProd.Visible = True
                    ddlMixTypeForm.Enabled = False
                Else
                    divCompeteProd.Visible = False
                    ddlMixTypeForm.Enabled = True
                End If
                divDDLProduct.Visible = False
                divTxtProduct.Visible = True
                gvLMS.Visible = False
                lblMixError.Visible = False
                'txtQuantityForm.Text = ""
                txtProduct.Text = ""
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddlProduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlProduct.SelectedIndexChanged
        Try
            Dim MixType As String = LMSBLL.MixTypeById(ddlProduct.SelectedValue)
            If MixType = "Bread" Then
                ddlMixTypeForm.SelectedValue = "Bread & Improvers"
            ElseIf MixType = "Cake" Then
                ddlMixTypeForm.SelectedValue = "Cake & Desserts"
            ElseIf MixType = "Cream" Then
                ddlMixTypeForm.SelectedValue = "Cream & Filling"
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlLinkProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlLinkProd.SelectedIndexChanged
        Try
            Dim MixType As String = LMSBLL.MixTypeById(ddlLinkProd.SelectedValue)
            If MixType = "Bread" Then
                ddlMixTypeForm.SelectedValue = "Bread & Improvers"
            ElseIf MixType = "Cake" Then
                ddlMixTypeForm.SelectedValue = "Cake & Desserts"
            ElseIf MixType = "Cream" Then
                ddlMixTypeForm.SelectedValue = "Cream & Filling"
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillDetailForm()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'hfBtnPrint.Value = MainID
            Dim dt As DataSet = LMSBLL.FillGridByID(MainID, "DisplayFormulation")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            'If dtUser.Rows.Count > 0 Then
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Approved")) = "Approved" Then
                lblapproved.Text = "Approved"
                btnFormulationSaveApprove.Visible = False
            ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Approved")) = "Pending" Then
                lblapproved.Text = "Pending"
            Else
                lblapproved.Text = "Rejected"
                btnFormulationSaveApprove.Visible = False
            End If
            'Else
            '    lblapproved.Text = ""
            'End If
            hfFormVersion.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Version"))
            lblFormulationNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
            lblTrialCode.Text = Replace(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No")), "FR", "TR")
            txtQuantityForm.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Qty"))
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName"))
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ModifiedDate")).ToString())
            Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
            If dt.Tables(1).Rows.Count > 0 Then
                ViewState("Recipe_Id") = (dt.Tables(1).Rows(0)("Recipe_Id"))
            Else
                ViewState("Recipe_Id") = 0
            End If

            If FType = "Product" And ProdID = 0 Then
                ddlFormulationType.SelectedValue = 1
            ElseIf FType = "Competitor" And ProdID = 0 Then
                ddlFormulationType.SelectedValue = 2
            ElseIf FType = "Product" And ProdID <> 0 Then
                ddlFormulationType.SelectedValue = 0
            End If
            If ProdID = 0 Then
                If ddlFormulationType.SelectedValue = 2 Then
                    divCompeteProd.Visible = True
                    ddlLinkProd.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_LinkedProd"))
                Else
                    divCompeteProd.Visible = False
                End If
                divDDLProduct.Visible = False
                divTxtProduct.Visible = True
                txtProduct.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdName"))
            Else
                divDDLProduct.Visible = True
                divTxtProduct.Visible = False
                ddlProduct.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            End If
            ddlMixTypeForm.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))
            ddlPriority.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Priority"))
            ddlDate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Formulation_ExecutionDate"))
            'ddlMixTypeForm.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))

            gvLMS.DataSource = dt.Tables(0)
            Session("FormulationViewMode") = dt.Tables(0)
            ViewState("GridRowItems") = dt.Tables(0)
            gvLMS.DataBind()
            'End If
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            If lblMixError.Visible = True Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please update Mix Type of selected Product')", True)
            Else
                txtQuantityForm.Enabled = False
                gvLMS.Visible = True
                AddFormulaFirstRow()
                ' ''btnCalc.Visible = True
                'btnFormulationSaveNext.Visible = True
                btnFormulationSave.Visible = True
                If Session("LMSUserRoleID") = 1 Then
                    btnFormulationSaveApprove.Visible = True
                    btnCalc.Visible = True
                Else
                    btnFormulationSaveApprove.Visible = False
                    btnCalc.Visible = False
                End If
                'divFormulationHistory.Visible = True
                'FillRecipeHistory()
                'FillFormulationHistory()
                getMaxFormIDByProdId()
                'btnCompareForm.Visible = True
                If hfAccessFor.Value = "Both" Then
                    btnFormulationCancel.Visible = False
                    btnFormulationSaveApprove.Visible = False
                    btnFormulationSave.Visible = False
                    LoadRecipe()
                End If
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnCompareForm_Click(sender As Object, e As EventArgs) Handles btnCompareForm.Click
        Try
            btnPasteCompareForm.Visible = True
            btnPasteCompareRecipe.Visible = True
            Dim Url As String = "compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=P" + (hfCompareID.Value).ToString()
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" + Url + "','_blank');", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnPasteCompareForm_Click(sender As Object, e As EventArgs) Handles btnPasteCompareForm.Click
        Try
            If Session("FormulationIDForFill") = Nothing Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please Copy Formulation first.')", True)
            Else
                hfCopyFormId.Value = Session("FormulationIDForFill")
                CopyFormulation()
                'TryCast(Me.Master, LMSMasterPage).MaintainSession()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "FormGrid"

    Protected Sub gvLMS_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvLMS.RowCommand
        Try
            Flag = 0
            If e.CommandName = "AddFormulaNewRow" Then
                AddFormulaNewRow()

            ElseIf e.CommandName = "deleteLink" Then
                If ViewState("GridRowItems") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("GridRowItems"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()
                        ViewState("GridRowItems") = dt
                        Flag = rowIndex

                        gvLMS.DataSource = dt
                        gvLMS.DataBind()

                        If gvLMS.Rows.Count <= 1 Then
                            Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(0).FindControl("lnkdelete"), LinkButton)
                            lnkdelete.Visible = False
                        Else
                            For i As Integer = 0 To gvLMS.Rows.Count - 1
                                Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(i).FindControl("lnkdelete"), LinkButton)
                                lnkdelete.Visible = True
                            Next
                        End If
                        For i As Integer = 0 To gvLMS.Rows.Count - 2
                            gvLMS.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next
                    End If
                    SetPreviousData()
                End If
            ElseIf e.CommandName = "TotalCost" Then
                TotalCost()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)

        End Try
    End Sub
    Protected Sub gvLMS_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvLMS.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddlRM As DropDownList = DirectCast(e.Row.FindControl("ddlRM"), DropDownList)
                Dim txtPercentage As TextBox = DirectCast(e.Row.FindControl("txtPercentage"), TextBox)
                Dim txtQ_kg As TextBox = DirectCast(e.Row.FindControl("txtQ_kg"), TextBox)
                Dim txtQ_gm As TextBox = DirectCast(e.Row.FindControl("txtQ_gm"), TextBox)
                Dim txtCost As TextBox = DirectCast(e.Row.FindControl("txtCost"), TextBox)
                Dim ltRMat As Literal = DirectCast(e.Row.FindControl("ltRMat"), Literal)

                Dim ds As New DataSet

                ds = LMSBLL.Dropdown("FillRawMaterial")
                ddlRM.DataSource = ds.Tables(0)
                ddlRM.DataTextField = "Rm_Name"
                ddlRM.DataValueField = "Rm_ID"
                ddlRM.DataBind()
                ddlRM.SelectedValue = ltRMat.Text

                If ltRMat.Text <> "" Then
                    'If CInt(ltRMat.Text) <> 0 Then
                    For x As Integer = 0 To gvLMS.Rows.Count - 1
                        Dim ddRM1 As DropDownList = TryCast(gvLMS.Rows(x).FindControl("ddlRM"), DropDownList)

                        ddlRM.Items.Remove(ddlRM.Items.FindByValue(ddRM1.Text))
                    Next

                End If

                If txtPercentage.Text = 0 Then
                    txtPercentage.Text = ""
                End If
                If txtQ_kg.Text = 0 Then
                    txtQ_kg.Text = ""
                End If
                If txtQ_gm.Text = 0 Then
                    txtQ_gm.Text = ""
                End If
                If txtCost.Text = 0 Then
                    txtCost.Text = 0
                    'txtCost.Text = ""
                End If
            End If
        Catch ex As Exception
            Dim errorMsg As String = ex.Message.Replace(Chr(34), "")
            errorMsg = errorMsg.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, errorMsg, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (errorMsg.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddFormulaFirstRow()
        Try
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0

            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing

            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("FRawM_RawMID", GetType(String)))
            dt.Columns.Add(New DataColumn("FRawM_Percentage", GetType(String)))
            dt.Columns.Add(New DataColumn("FRawM_QtyKg", GetType(String)))
            dt.Columns.Add(New DataColumn("FRawM_QtyGm", GetType(String)))
            dt.Columns.Add(New DataColumn("FRawM_Cost", GetType(String)))
            'dt.Columns.Add(New DataColumn("Unit_gm", GetType(String)))

            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            dr("FRawM_RawMID") = 1
            dr("FRawM_Percentage") = 0
            'dr("FRawM_Percentage") = String.Empty
            Dim UnitKg As Integer = CDbl(txtQuantityForm.Text) * CInt(dr("FRawM_Percentage")) / 100
            dr("FRawM_QtyKg") = UnitKg
            ''dr("FRawM_QtyKg") = String.Empty
            dr("FRawM_QtyGm") = UnitKg * 1000
            ''dr("FRawM_QtyGm") = String.Empty

            Costing = LMSBLL.Costing(CInt(dr("FRawM_RawMID")))
            FinalCost = Costing * (txtQuantityForm.Text * CInt(dr("FRawM_Percentage")) / 100)
            dr("FRawM_Cost") = FinalCost
            ''dr("FRawM_Cost") = String.Empty

            dt.Rows.Add(dr)
            ViewState("GridRowItems") = dt

            gvLMS.DataSource = dt
            gvLMS.DataBind()

            SetPreviousData()

            Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(0).FindControl("txtPercentage"), TextBox)
            txtPercentage.Text = ""

            Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(0).FindControl("txtQ_kg"), TextBox)
            txtQ_kg.Text = ""

            Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(0).FindControl("txtQ_gm"), TextBox)
            txtQ_gm.Text = ""

            Dim txtCost As TextBox = DirectCast(gvLMS.Rows(0).FindControl("txtCost"), TextBox)
            txtCost.Text = ""

            Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(0).FindControl("lnkdelete"), LinkButton)
            lnkdelete.Visible = False

            Dim lblQuantityFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQuantityFoot"), Label)
            Dim lnkadd As LinkButton = DirectCast(gvLMS.FooterRow.FindControl("lnkadd"), LinkButton)
            Dim lblQFootError As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQFootError"), Label)
            If (CDbl(lblQuantityFoot.Text) = CDbl(txtQuantityForm.Text)) Then
                lblQFootError.Text = "Reduce selected material to add new"
                lblQFootError.Attributes.Add("Style", "color:darkcyan")
                lblQFootError.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
        End Try
    End Sub
    Private Sub AddFormulaNewRow()
        Try
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0
            Dim rowIndex As Integer = 0
            If ViewState("GridRowItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("GridRowItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("ddlRM"), DropDownList)
                        Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtPercentage"), TextBox)
                        Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_kg"), TextBox)
                        Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_gm"), TextBox)
                        Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")

                        ' drCurrentRow("FRawM_RawMID") = ltRMat.Text
                        drCurrentRow("FRawM_RawMID") = 0
                        drCurrentRow("FRawM_Percentage") = CDbl((txtQuantityForm.Text - ViewState("Qtotal")) / txtQuantityForm.Text * 100)

                        Dim UnitKg As Double = CDbl((txtQuantityForm.Text - ViewState("Qtotal")))
                        '   Dim UnitKg As Double = txtQuantity.Text * CInt(drCurrentRow("FRawM_Percentage")) / 100
                        drCurrentRow("FRawM_QtyKg") = UnitKg
                        drCurrentRow("FRawM_QtyGm") = UnitKg * 1000
                        'Costing = LMSBLL.Costing(CInt(drCurrentRow("FRawM_RawMID")))
                        'FinalCost = Costing * (txtQuantity.Text * CInt(drCurrentRow("FRawM_Percentage")) / 100)
                        'drCurrentRow("FRawM_Cost") = FinalCost
                        drCurrentRow("FRawM_Cost") = FinalCost

                        dtCurrentTable.Rows(i - 1)("FRawM_RawMID") = ddlRM.SelectedValue
                        dtCurrentTable.Rows(i - 1)("FRawM_Percentage") = txtPercentage.Text
                        dtCurrentTable.Rows(i - 1)("FRawM_QtyKg") = txtQ_kg.Text
                        dtCurrentTable.Rows(i - 1)("FRawM_QtyGm") = txtQ_gm.Text
                        'dtCurrentTable.Rows(i - 1)("FRawM_QtyKg") = txtQuantity.Text * txtPercentage.Text / 100
                        'dtCurrentTable.Rows(i - 1)("FRawM_QtyGm") = txtQuantity.Text * txtPercentage.Text * 10
                        dtCurrentTable.Rows(i - 1)("FRawM_Cost") = txtCost.Text

                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("GridRowItems") = dtCurrentTable
                    gvLMS.DataSource = dtCurrentTable
                    gvLMS.DataBind()
                End If
            End If
            SetPreviousData()

            Dim txtPercentageLast As TextBox = DirectCast(gvLMS.Rows(rowIndex).FindControl("txtPercentage"), TextBox)
            txtPercentageLast.Text = ""

            Dim txtQ_kgLast As TextBox = DirectCast(gvLMS.Rows(rowIndex).FindControl("txtQ_kg"), TextBox)
            txtQ_kgLast.Text = ""

            Dim txtQ_gmLast As TextBox = DirectCast(gvLMS.Rows(rowIndex).FindControl("txtQ_gm"), TextBox)
            txtQ_gmLast.Text = ""

            Dim txtCostLast As TextBox = DirectCast(gvLMS.Rows(rowIndex).FindControl("txtCost"), TextBox)
            txtCostLast.Text = ""

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub
    Private Sub SetPreviousData()
        Try
            Dim rowIndex As Integer = 0
            Dim PerTotal As Double = 0
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0
            If ViewState("GridRowItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("GridRowItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(1).FindControl("ddlRM"), DropDownList)
                        Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(2).FindControl("txtPercentage"), TextBox)
                        Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(3).FindControl("txtQ_kg"), TextBox)
                        Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(4).FindControl("txtQ_gm"), TextBox)
                        Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(5).FindControl("txtCost"), TextBox)

                        gvLMS.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        If txtPercentage.Text = "" Then
                            txtPercentage.Text = 0
                        End If
                        If txtQ_kg.Text = "" Then
                            txtQ_kg.Text = 0
                        End If
                        If txtQ_gm.Text = "" Then
                            txtQ_gm.Text = 0
                        End If
                        PerTotal = PerTotal + txtQ_kg.Text
                        If txtQuantityForm.Text = "" Then
                            txtQuantityForm.Text = 0
                        End If

                        dt.Rows(i)("FRawM_RawMID") = ddlRM.SelectedValue
                        dt.Rows(i)("FRawM_Percentage") = txtPercentage.Text
                        dt.Rows(i)("FRawM_QtyKg") = txtQ_kg.Text
                        dt.Rows(i)("FRawM_QtyGm") = txtQ_gm.Text
                        'dt.Rows(i)("FRawM_Cost") = FinalCost
                        'If txtCost.Text = "" Or txtCost.Text = "0" Or txtCost.Text = "0.00" Then
                        If txtCost.Text = "" Then
                            Costing = LMSBLL.Costing(ddlRM.SelectedValue)
                            FinalCost = Costing * (txtQ_kg.Text)
                            dt.Rows(i)("FRawM_Cost") = FinalCost
                        Else
                            dt.Rows(i)("FRawM_Cost") = txtCost.Text
                        End If
                        '' ''  dt.Rows(i)("FRawM_Cost") = txtCost.Text
                        '' ''dt.Rows(i)("Unit_gm") = FinalCost / 1000
                        ViewState("Qtotal") = CDec(PerTotal)
                        '' ''ViewState("Qtotal") = PerTotal * txtQuantity.Text / 100
                        rowIndex += 1

                        ddlRM.SelectedValue = dt.Rows(i)("FRawM_RawMID").ToString
                        txtPercentage.Text = dt.Rows(i)("FRawM_Percentage").ToString
                        txtQ_kg.Text = dt.Rows(i)("FRawM_QtyKg").ToString
                        txtQ_gm.Text = dt.Rows(i)("FRawM_QtyGm").ToString
                        txtCost.Text = dt.Rows(i)("FRawM_Cost").ToString
                        If i < dt.Rows.Count - 1 Then
                            ddlRM.Enabled = False
                        End If
                    Next
                    ViewState("GridRowItems") = dt
                    gvLMS.DataSource = dt
                    gvLMS.DataBind()
                    Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(0).FindControl("lnkdelete"), LinkButton)
                    If gvLMS.Rows.Count <= 1 Then
                        lnkdelete.Visible = False
                    Else
                        For i As Integer = 0 To gvLMS.Rows.Count - 1
                            'Dim lnkdelete As LinkButton = DirectCast(gvLMS.Rows(i).FindControl("lnkdelete"), LinkButton)
                            lnkdelete.Visible = True
                        Next
                    End If
                    Dim lblQuantityFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQuantityFoot"), Label)
                    Dim lnkadd As LinkButton = DirectCast(gvLMS.FooterRow.FindControl("lnkadd"), LinkButton)
                    Dim lblQFootError As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQFootError"), Label)
                    lblQuantityFoot.Text = ViewState("Qtotal")
                    If (CDbl(lblQuantityFoot.Text) < CDbl(txtQuantityForm.Text)) Then
                        lnkadd.Visible = True
                        lblQFootError.Text = "Raw Material usage Preceeding"
                        lblQFootError.Visible = True
                    Else
                        lnkadd.Visible = False
                        If (CDbl(lblQuantityFoot.Text) > CDbl(txtQuantityForm.Text)) Then
                            lblQFootError.Visible = True
                        Else
                            lblQFootError.Visible = False
                        End If
                        'If (CDbl(lblQuantityFoot.Text) = CDbl(txtQuantity.Text)) Then
                        '    'lblQFootError.Text = "Reduce selected material to add new"
                        '    'lblQFootError.Attributes.Add("Style", "color:darkcyan")
                        '    'lblQFootError.Visible = True
                        'End If
                    End If

                    'If (CDbl(lblQuantityFoot.Text) = CDbl(txtQuantity.Text)) Then
                    '    ' btnCalc.Visible = True
                    '    btnSave.Visible = True
                    'Else
                    '    '  btnCalc.Visible = False
                    '    btnSave.Visible = False
                    'End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub ddlRM_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0
            Dim ddlRM As DropDownList = CType(sender, DropDownList)
            Dim gvRow As GridViewRow = CType(ddlRM.Parent.Parent, GridViewRow)
            Dim rowIndex As Integer = Convert.ToInt32(gvRow.RowIndex)
            Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtPercentage"), TextBox)
            If txtPercentage.Text = "" Then
                txtPercentage.Text = 0
            End If
            'Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_kg"), TextBox)
            'Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_gm"), TextBox)
            Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)
            Costing = LMSBLL.Costing(ddlRM.SelectedValue)
            FinalCost = Costing * (txtQuantityForm.Text * txtPercentage.Text / 100)
            txtCost.Text = FinalCost
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub txtPercentage_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim Costing As Decimal = 0
            Dim FinalCost As Decimal = 0
            Dim txtPercentage As TextBox = CType(sender, TextBox)
            Dim gvRow As GridViewRow = CType(txtPercentage.Parent.Parent, GridViewRow)
            Dim rowIndex As Integer = Convert.ToInt32(gvRow.RowIndex)
            Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("ddlRM"), DropDownList)
            Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_kg"), TextBox)
            Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_gm"), TextBox)
            Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)
            If txtPercentage.Text = "" Then
                txtPercentage.Text = 0
            End If
            If txtPercentage.Text > 100 Then
                txtPercentage.Text = 100
            End If

            'Dim cost As Double = txtCost.Text / txtQ_kg.Text
            ' '' ''Dim KG As Double = txtQuantityForm.Text * txtPercentage.Text / 100
            ' '' ''txtQ_kg.Text = CDec(KG)
            ' '' ''txtQ_kg.Text = CDec(txtQ_kg.Text)
            txtQ_kg.Text = CDec(txtQuantityForm.Text * txtPercentage.Text / 100).ToString
            txtQ_gm.Text = txtQ_kg.Text * 1000
            'txtCost.Text = cost * txtQ_kg.Text
            Costing = LMSBLL.Costing(ddlRM.SelectedValue)
            FinalCost = Costing * (txtQuantityForm.Text * txtPercentage.Text / 100)
            txtCost.Text = FinalCost

            SetPreviousData()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub txtQ_kg_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0
            Dim txtQ_kg As TextBox = CType(sender, TextBox)
            Dim gvRow As GridViewRow = CType(txtQ_kg.Parent.Parent, GridViewRow)
            Dim rowIndex As Integer = Convert.ToInt32(gvRow.RowIndex)
            Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("ddlRM"), DropDownList)
            Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtPercentage"), TextBox)
            Dim txtQ_gm As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_gm"), TextBox)
            Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)

            'Dim cost As Double = txtCost.Text / (txtQuantity.Text * txtPercentage.Text / 100)
            txtPercentage.Text = txtQ_kg.Text / txtQuantityForm.Text * 100
            txtQ_gm.Text = txtQ_kg.Text * 1000
            'txtCost.Text = cost * txtQ_kg.Text
            Costing = LMSBLL.Costing(ddlRM.SelectedValue)
            FinalCost = Costing * (txtQuantityForm.Text * txtPercentage.Text / 100)
            txtCost.Text = FinalCost

            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub txtQ_gm_TextChanged(sender As Object, e As EventArgs)
        Try
            Dim Costing As Double = 0
            Dim FinalCost As Double = 0
            Dim txtQ_gm As TextBox = CType(sender, TextBox)
            Dim gvRow As GridViewRow = CType(txtQ_gm.Parent.Parent, GridViewRow)
            Dim rowIndex As Integer = Convert.ToInt32(gvRow.RowIndex)
            Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("ddlRM"), DropDownList)
            Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtPercentage"), TextBox)
            Dim txtQ_kg As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtQ_kg"), TextBox)
            Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)
            'Dim lblQuantityFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQuantityFoot"), Label)
            If txtQ_gm.Text = "" Or txtQ_gm.Text = "0" Or txtQ_gm.Text = "0.00" Then
                txtQ_gm.Text = 0
                txtQ_kg.Text = 0
                txtPercentage.Text = 0
                txtCost.Text = 0
            Else
                txtQ_kg.Text = CDec(txtQ_gm.Text / 1000)
                'Dim cost As Double = txtCost.Text / txtQ_kg.Text
                txtPercentage.Text = CDec(txtQ_kg.Text / txtQuantityForm.Text * 100)
                'txtCost.Text = cost * txtQ_kg.Text
                Costing = LMSBLL.Costing(ddlRM.SelectedValue)
                FinalCost = Costing * (txtQuantityForm.Text * txtPercentage.Text / 100)
                txtCost.Text = FinalCost
            End If
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub txtCost_TextChanged(sender As Object, e As EventArgs)
        Try
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Try
            TotalCost()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub TotalCost()
        Try
            Dim rowIndex As Integer = 0
            Dim CTotal As Double = 0
            If ViewState("GridRowItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("GridRowItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 0 To dtCurrentTable.Rows.Count - 1
                        Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("ddlRM"), DropDownList)
                        Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtPercentage"), TextBox)
                        Dim txtCost As TextBox = DirectCast(gvLMS.Rows(rowIndex).Cells(0).FindControl("txtCost"), TextBox)

                        If txtCost.Text = "" Then
                            txtCost.Text = 0
                        End If
                        CTotal = CTotal + txtCost.Text

                        rowIndex += 1
                    Next
                End If
            End If
            SetPreviousData()
            Dim lblQuantityFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQuantityFoot"), Label)
            Dim lblQGmfoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQGmfoot"), Label)
            Dim lblPercentFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblPercentFoot"), Label)
            Dim lblTotalCost As Label = DirectCast(gvLMS.FooterRow.FindControl("lblTotalCost"), Label)
            Dim lblTotCostGm As Label = DirectCast(gvLMS.FooterRow.FindControl("lblTotCostGm"), Label)
            Dim lblTotCost As Label = DirectCast(gvLMS.FooterRow.FindControl("lblTotCost"), Label)
            Dim lblTotCostKg As Label = DirectCast(gvLMS.FooterRow.FindControl("lblTotCostKg"), Label)
            Dim lblQuanFoot As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQuanFoot"), Label)
            Dim hr1 As HtmlGenericControl = DirectCast(gvLMS.FooterRow.FindControl("hr1"), HtmlGenericControl)
            Dim hr2 As HtmlGenericControl = DirectCast(gvLMS.FooterRow.FindControl("hr2"), HtmlGenericControl)
            Dim hr3 As HtmlGenericControl = DirectCast(gvLMS.FooterRow.FindControl("hr3"), HtmlGenericControl)
            Dim hr4 As HtmlGenericControl = DirectCast(gvLMS.FooterRow.FindControl("hr4"), HtmlGenericControl)
            lblQuantityFoot.Visible = True
            lblQuantityFoot.Text = ViewState("Qtotal")
            lblQGmfoot.Text = lblQuantityFoot.Text * 1000
            lblPercentFoot.Text = CDec(lblQuantityFoot.Text / txtQuantityForm.Text * 100)
            If Session("LMSUserRoleID") = 1 Then
                lblTotCost.Visible = True
                lblTotalCost.Visible = True
                lblTotCostKg.Visible = True
                lblTotCostGm.Visible = True
                hr1.Visible = True
                hr2.Visible = True
                hr3.Visible = True
                hr4.Visible = True
                gvLMS.Columns(6).Visible = True
                lblQuantityFoot.Visible = True
                lblQuanFoot.Visible = True
            Else
                lblTotCost.Visible = False
                lblTotalCost.Visible = False
                lblTotCostKg.Visible = False
                lblTotCostGm.Visible = False
                hr1.Visible = False
                hr2.Visible = False
                hr3.Visible = False
                hr4.Visible = False
                gvLMS.Columns(6).Visible = False
                lblQuantityFoot.Visible = False
                lblQuanFoot.Visible = False
            End If
            ' ''lblQuanFoot.Visible = True

            ' ''hr1.Visible = True
            ' ''hr2.Visible = True
            ' ''hr3.Visible = True
            ' ''hr4.Visible = True
            lblTotalCost.Text = "₹" + CTotal.ToString("N2")
            lblTotCostGm.Text = "₹" + (CTotal / txtQuantityForm.Text).ToString("N2") + "/KG"
            lblQuantityFoot.Text = (CDec(lblQuantityFoot.Text)).ToString + " KG"
            'lblQuantityFoot.Text = CDbl(lblQuantityFoot.Text).ToString("N2") + " KG"
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub

#End Region
    Protected Sub btnFormulationSave_Click(sender As Object, e As EventArgs) Handles btnFormulationSave.Click
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim lblQFootError As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQFootError"), Label)
            If lblQFootError.Visible = False Then
                If PageID = 0 Then
                    InsertFormulation()
                    InsertRecipeFromFormulation()
                    InsertAssignTo()
                    Response.Redirect("Trials.aspx")
                Else
                    InsertFormulation()
                    InsertAssignTo()
                    Response.Redirect("Trials.aspx")
                End If
            End If
            'Response.Redirect("ModifyTrials.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Formulation_Id"))) + "&returnurl=y")
            ''divRecipe1.Visible = True
            ''btnFormulationSave.Visible = False
            ''btnFormulationSaveApprove.Visible = False
            ''btnFormulationCancel.Visible = False

            ''LoadRecipe()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnFormulationSaveApprove_Click(sender As Object, e As EventArgs) Handles btnFormulationSaveApprove.Click
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If PageID = 0 Then
                InsertFormulation()
                UpdateFormulationApprove()
                InsertRecipeFromFormulation()
                UpdateRecipeApprove()
                InsertAssignTo()
                ''divRecipe1.Visible = True
                ''btnFormulationSave.Visible = False
                ''btnFormulationSaveApprove.Visible = False
                ''btnFormulationCancel.Visible = False
                'LoadRecipe()
            Else
                InsertFormulation()
                UpdateFormulationApprove()
                UpdateRecipeApprove()
                InsertAssignTo()
                ''divRecipe1.Visible = True
                ''btnFormulationSave.Visible = False
                ''btnFormulationSaveApprove.Visible = False
                ''btnFormulationCancel.Visible = False
            End If
            Response.Redirect("Trials.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub InsertRecipeFromFormulation()
        Try
            Dim Recipe_Id As Integer = LMSBLL.InsertRecipe(lblRecipeNo.Text, ViewState("Formulation_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))
            ViewState("Recipe_Id") = Recipe_Id

            LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), "", "", "", txtRemarkIngre.Text, Session("LMSUserId"))

            LMSBLL.InsertRecipeProcedure(ViewState("Recipe_Id"), "", "", "", txtRemarkProc.Text, Session("LMSUserId"))

            Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(Recipe_Id)
            LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
            LMSassigncontrol1.Uhftype.Value = "Recipe"
            LMSassigncontrol1.Uhftypeid.Value = Recipe_Id
            Session("FirstAssignto") = Nothing
            LMSassigncontrol1.AddLMSAssignToWithoutSMS(ViewState("Recipe_Id"))
            ''LMSassigncontrol1.AddLMSRecipeAssignToNoSMS(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UpdateFormulationApprove()
        Try
            'If ddlFormulationType.SelectedValue = 0 Then
            '    LMSBLL.UpdateFormulationApprove("UpdateFormulationApprove", ViewState("Formulation_Id"), Session("LMSUserId"), ddlProduct.SelectedValue, 0)
            'Else
            '    LMSBLL.UpdateFormulationApprove("UpdateFormulationApprove", ViewState("Formulation_Id"), Session("LMSUserId"), txtProduct.Text, 1)
            'End If
            LMSBLL.UpdateApprove("UpdateFormulationApprove", ViewState("Formulation_Id"), Session("LMSUserId"), txtAppDisApp.Text)
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Formulation has been approved')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    Private Sub UpdateFormulationDisApprove()
        Try
            LMSBLL.UpdateApprove("UpdateFormulationDisApprove", ViewState("Formulation_Id"), Session("LMSUserId"), txtAppDisApp.Text)
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Formulation has been approved')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    Private Sub UpdateFormulationMain()
        Try
            'ViewState("Formulation_Id") = MainID
            Dim tablecheck As Boolean
            tablecheck = AreTablesTheSame()
            If tablecheck = False Then
                LMSBLL.DeleteFormChild(ViewState("Formulation_Id"))
                For i As Integer = 0 To gvLMS.Rows.Count - 1
                    Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(i).FindControl("ddlRM"), DropDownList)
                    Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtPercentage"), TextBox)
                    Dim txtCost As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtCost"), TextBox)

                    LMSBLL.InsertFRawMaterial(ViewState("Formulation_Id"), ddlRM.SelectedValue, txtPercentage.Text, txtCost.Text, Session("LMSUserId"))
                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub InsertFormulation()
        Try
            hfCopyFormId.Value = hfCopyFormId.Value
            hfCompareID.Value = hfCompareID.Value
            If hfCompareID.Value = Nothing Then
                hfCompareID.Value = 0
            End If
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If PageID = 0 Then
                'Dim Formulation_Id As Integer
                If ddlFormulationType.SelectedValue = 0 Then
                    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(ddlProduct.SelectedValue, ddlProduct.SelectedItem.Text, ddlMixTypeForm.SelectedValue,
                                                                           lblFormulationNo.Text, "Product", txtQuantityForm.Text, 0.01, Session("LMSUserId"),
                                                                           hfCompareID.Value, ddlPriority.SelectedValue, ddlDate.Text, False, -1)
                ElseIf ddlFormulationType.SelectedValue = 1 Then
                    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(0, txtProduct.Text, ddlMixTypeForm.SelectedValue, lblFormulationNo.Text, "Product",
                                                                           txtQuantityForm.Text, 0.01, Session("LMSUserId"), hfCompareID.Value, ddlPriority.SelectedValue, ddlDate.Text,
                                                                           False, -1)
                ElseIf ddlFormulationType.SelectedValue = 2 Then
                    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(0, txtProduct.Text, ddlMixTypeForm.SelectedValue, lblFormulationNo.Text, "Competitor",
                                                                           txtQuantityForm.Text, 0.01, Session("LMSUserId"), hfCompareID.Value, ddlPriority.SelectedValue, ddlDate.Text,
                                                                           False, ddlLinkProd.SelectedValue)
                End If
                For i As Integer = 0 To gvLMS.Rows.Count - 1
                    Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(i).FindControl("ddlRM"), DropDownList)
                    Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtPercentage"), TextBox)
                    Dim txtCost As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtCost"), TextBox)

                    LMSBLL.InsertFRawMaterial(ViewState("Formulation_Id"), ddlRM.SelectedValue, txtPercentage.Text, txtCost.Text, Session("LMSUserId"))
                Next
                ''Dim FormulationNo As String = LMSBLL.FormulationNoForInsert(ViewState("Formulation_Id"))
                ''LMSassigncontrol.UhfTypeCode.Value = FormulationNo
                ''LMSassigncontrol.AddLMSAssignTo(ViewState("Formulation_Id"))

            Else
                ViewState("Formulation_Id") = PageID
                UpdateFormulationMain()
                ''Dim tablecheck As Boolean
                ''tablecheck = AreTablesTheSame()
                ''If tablecheck = False Then
                ''    ''If ddlFormulationType.SelectedValue = 0 Then
                ''    ''    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(ddlProduct.SelectedValue, ddlProduct.SelectedItem.Text, ddlMixTypeForm.SelectedValue, lblFormulationNo.Text, "Product", txtQuantityForm.Text, hfFormVersion.Value + 0.01, Session("LMSUserId"), MainID)
                ''    ''ElseIf ddlFormulationType.SelectedValue = 1 Then
                ''    ''    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(0, txtProduct.Text, ddlMixTypeForm.SelectedValue, lblFormulationNo.Text, "Product", txtQuantityForm.Text, 0.0, Session("LMSUserId"), MainID)
                ''    ''ElseIf ddlFormulationType.SelectedValue = 2 Then
                ''    ''    ViewState("Formulation_Id") = LMSBLL.InsertFormulation(0, txtProduct.Text, ddlMixTypeForm.SelectedValue, lblFormulationNo.Text, "Competitor", txtQuantityForm.Text, 0.0, Session("LMSUserId"), MainID)
                ''    ''End If
                ''    ''For i As Integer = 0 To gvLMS.Rows.Count - 1
                ''    ''    Dim ddlRM As DropDownList = DirectCast(gvLMS.Rows(i).FindControl("ddlRM"), DropDownList)
                ''    ''    Dim txtPercentage As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtPercentage"), TextBox)
                ''    ''    Dim txtCost As TextBox = DirectCast(gvLMS.Rows(i).FindControl("txtCost"), TextBox)

                ''    ''    LMSBLL.InsertFRawMaterial(ViewState("Formulation_Id"), ddlRM.SelectedValue, txtPercentage.Text, txtCost.Text, Session("LMSUserId"))
                ''    ''Next
                ''End If
                If divRecipe1.Visible = False Then
                    ''Dim FormulationNo As String = LMSBLL.FormulationNoForInsert(ViewState("Formulation_Id"))
                    ''LMSassigncontrol.UhfTypeCode.Value = FormulationNo
                    ''LMSassigncontrol.AddLMSAssignTo(ViewState("Formulation_Id"))
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Function AreTablesTheSame() As Boolean

        Dim tbl1 As DataTable = Session("FormulationViewMode")
        Dim tbl2 As DataTable
        '----starts
        Dim dtN As New DataTable()
        '   For i As Integer = 0 To grditemproduct.Columns.Count - 1
        'dtN.Columns.Add("column" + i.ToString())
        'Dim count As Integer = 82
        dtN.Columns.Add("RowNumber", GetType(String))
        dtN.Columns.Add("FRawM_RawMID", GetType(String))
        dtN.Columns.Add("FRawM_Percentage", GetType(String))
        dtN.Columns.Add("FRawM_QtyKg", GetType(String))
        dtN.Columns.Add("FRawM_QtyGm", GetType(String))
        dtN.Columns.Add("FRawM_Cost", GetType(String))

        For Each row In gvLMS.Rows
            Dim ltRowNumber As Literal = DirectCast(row.FindControl("ltRowNumber"), Literal)
            Dim ddlRM As DropDownList = DirectCast(row.FindControl("ddlRM"), DropDownList)
            Dim txtPercentage As TextBox = DirectCast(row.FindControl("txtPercentage"), TextBox)
            Dim txtQ_kg As TextBox = DirectCast(row.FindControl("txtQ_kg"), TextBox)
            Dim txtQ_gm As TextBox = DirectCast(row.FindControl("txtQ_gm"), TextBox)
            Dim txtCost As TextBox = DirectCast(row.FindControl("txtCost"), TextBox)

            dtN.Rows.Add(ltRowNumber.Text, ddlRM.SelectedValue, txtPercentage.Text, txtQ_kg.Text, txtQ_gm.Text, txtCost.Text)
            'dtN.Rows.Add(count, ltProductId.Text, ltproductname.Text, ltproductcode.Text, ltpackingpacking.Text,
            '             ltproductWeight.Text, ltrate1.Text.Replace(",", ""), txtquantity.Text, ltkg.Text, ltsumamount.Text.Replace(",", ""),
            '             ltproductrate.Text.Replace(",", ""),
            '             ltmarginp.Text, lblprductcost.Text, ltsumamount.Text.Replace(",", ""), ltproductrate.Text.Replace(",", ""), txtdmarginp.Text)
            'count = count + 1
            ''check txtquantity.Text(7)
            '' ltsumamount.Text(9)
            ''ltrate.Text(10)
        Next
        tbl2 = dtN
        'If tbl1.Rows.Count <> tbl2.Rows.Count OrElse tbl1.Columns.Count <> tbl2.Columns.Count Then
        If tbl1.Rows.Count <> tbl2.Rows.Count Then
            Return False
        End If


        For i As Integer = 0 To tbl1.Rows.Count - 1
            If Not Equals(tbl1.Rows(i)(10).ToString(), tbl2.Rows(i)(1).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(11).ToString(), tbl2.Rows(i)(2).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If

        Next

        Return True
    End Function
#End Region
#Region "Formulation History"
    Protected Sub rpFormHist_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpFormHist.ItemCommand
        Try
            If e.CommandName = "CopyFormulation" Then
                Dim btnCopyForm As LinkButton = DirectCast(e.Item.FindControl("btnCopyForm"), LinkButton)
                Dim HypLnkFormNo As HyperLink = DirectCast(e.Item.FindControl("HypLnkFormNo"), HyperLink)
                Dim lblForm_Id As Label = DirectCast(e.Item.FindControl("lblForm_Id"), Label)
                hfCopyFormId.Value = lblForm_Id.Text
                CopyFormulation()
                '' '' '' '' ''ViewState("RecipeIDForFill") = lblRecipe_Id.Text 
                '' '' '' '' ''Response.Redirect("PrintFormulation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(lblForm_Id.Text)))
                '' '' '' '' ''CopyDetailRecipe()
                '' '' '' '' ''FillDetailRecipe()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CopyFormulation()
        Try

            Dim dt As DataSet = LMSBLL.FillGridByID(hfCopyFormId.Value, "DisplayFormulation")
            'Dim dtUser As New DataTable
            'dtUser = dt.Tables(0)
            'Dim drLogin As DataRow
            'drLogin = dtUser.Rows(0)
            'If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Approved")) = True Then
            '    lblapproved.Text = "Approved"
            '    btnFormulationSaveApprove.Visible = False
            'Else
            '    lblapproved.Text = ""
            'End If
            'hfFormVersion.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Version"))
            'txtQuantityForm.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Qty"))
            'lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName"))
            'lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ModifiedDate")).ToString())
            'Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            'Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
            'If FType = "Product" And ProdID = 0 Then
            '    ddlFormulationType.SelectedValue = 1
            'ElseIf FType = "Competitor" And ProdID = 0 Then
            '    ddlFormulationType.SelectedValue = 2
            'ElseIf FType = "Product" And ProdID <> 0 Then
            '    ddlFormulationType.SelectedValue = 0
            'End If
            'If ProdID = 0 Then
            '    divDDLProduct.Visible = False
            '    divTxtProduct.Visible = True
            '    txtProduct.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdName"))
            'Else
            '    divDDLProduct.Visible = True
            '    divTxtProduct.Visible = False
            '    ddlProduct.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            'End If
            'ddlMixTypeForm.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))

            gvLMS.DataSource = dt.Tables(0)
            '   Session("FormulationViewMode") = dt.Tables(0)
            ViewState("GridRowItems") = dt.Tables(0)
            gvLMS.DataBind()
            SetPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    'Public Sub CopyDetailRecipe()
    '    Try

    '        Dim dt As DataSet
    '        'If MainID = 0 Then
    '        dt = LMSBLL.FillGridByID(ViewState("RecipeIDForFill"), "DispRecipeIngredients")

    '        Dim dtUser As New DataTable
    '        dtUser = dt.Tables(0)
    '        Dim drLogin As DataRow
    '        If dtUser.Rows.Count > 0 Then

    '            drLogin = dtUser.Rows(0)
    '            ddlFormulationNo.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
    '            hfFRNo.Value = ddlFormulationNo.SelectedItem.Text
    '            ViewState("Formulation_Id") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
    '            Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
    '            Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
    '            If FType = "Product" And ProdID = 0 Then
    '                ddlFormulationType.SelectedValue = 1
    '            ElseIf FType = "Competitor" And ProdID = 0 Then
    '                ddlFormulationType.SelectedValue = 2
    '            ElseIf FType = "Product" And ProdID <> 0 Then
    '                ddlFormulationType.SelectedValue = 0
    '            End If

    '            'lblRecipeNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
    '            ddlMixer.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mixer"))
    '            ddlBlade.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Blade"))
    '            ddlMould.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mould"))
    '            ddlOven.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Oven"))
    '            txtRemarkIngre.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RecipeIngredient_Remarks"))
    '        End If


    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        Throw ex
    '    End Try
    'End Sub
    Public Sub getMaxFormIDByProdId()
        Try
            Dim ds1 As DataSet = LMSBLL.DropdownByIdNType("getMaxFormIDByProdId", ddlProduct.SelectedValue, ddlFormulationType.SelectedValue, txtProduct.Text)
            If ds1.Tables(0).Rows.Count <> 0 Then

                hfCompareID.Value = ds1.Tables(0).Rows(0)("CompareID")
                If hfCompareID.Value > 0 Then
                    btnCompareForm.Visible = True
                    btnCompareRecipe.Visible = True
                    'If Request.QueryString("chk") = "v" Then
                    '    lblCompForm.Visible = False
                    '    lblCompRecipe.Visible = False
                    'Else
                    lblCompForm.Visible = True
                    lblCompRecipe.Visible = True
                    'End If
                Else
                    btnCompareForm.Visible = False
                    btnCompareRecipe.Visible = False
                    btnPasteCompareForm.Visible = False
                    btnPasteCompareRecipe.Visible = False
                    lblCompForm.Visible = False
                    lblCompRecipe.Visible = False
                End If

            Else
                btnCompareForm.Visible = False
                btnCompareRecipe.Visible = False
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillFormulationHistory()
        Try
            Dim ds1 As DataSet = LMSBLL.DropdownById("getFormByProdId", ddlProduct.SelectedValue)
            Dim dtCopy As New DataTable
            dtCopy = ds1.Tables(0)
            rpFormHist.DataSource = dtCopy
            rpFormHist.DataBind()

            hfCompareID.Value = ds1.Tables(1).Rows(0)("CompareID")

            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region

#Region "Recipe"
    Private Sub LoadRecipe()
        Try
            Dim pageID As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            divRecipe1.Visible = True
            If divFormulation.Visible = False Then
                FillddlProductForm()
                FillDetailForm()
            End If
            getMaxFormIDByProdId()
            'btnCompareRecipe.Visible = True
            'LMSassigncontrol1.Uhftype.Value = "Recipe"
            'If pageID <> 0 Then

            MainID = ViewState("Recipe_Id")
            Fid = ViewState("Formulation_Id")
            ''LMSassigncontrol.Visible = False
            LMSassigncontrol1.Visible = True
            '*LMSassigncontrol1.Uhftype.Value = "Recipe"
            '''''''''''''''''''''''''''LMSassigncontrol1.Uhftypeid.Value = MainID
            'btnRecipeSaveApprove.Visible = True
            'btnRecipeDisApprove.Visible = False
            'btnRecipeDisApprove.Visible = True
            'btnOnlyRecipeSave.Visible = True
            If MainID = "0" Then
                btnprintRec.Visible = False
                btnprtBlankRec.Visible = False
                ''btnprint.Visible = False
                ''btnprintblank.Visible = False
                modifyspanRec.Visible = False
                'btnRecipeSaveApprove.Visible = False
                'btnRecipeDisApprove.Visible = False
                'btnOnlyRecipeSave.Visible = False
                If Fid = "0" Then
                    divRecipeHistory.Visible = False
                    divFormulationType.Visible = False
                    ddlFormulationNo.Visible = True
                    FillddlProductRecipe()
                    FillRecipeNo()
                    AddRecipeFirstRow()
                    AddProcedureFirstRow()
                Else
                    ViewState("Formulation_Id") = Fid
                    divFormulationType.Visible = False
                    divFormulationNo.Visible = False
                    ''divDDLProductRecipe.Visible = False
                    ''divTxtProductRecipe.Visible = False
                    divRecipeHistory.Visible = False
                    FillddlProductRecipe()
                    FillRecipeNo()
                    AddRecipeFirstRow()
                    AddProcedureFirstRow()
                    'btnRecipeSaveApprove.Visible = True
                    'btnRecipeDisApprove.Visible = True
                    'btnOnlyRecipeSave.Visible = True
                    btnRecipeSaveNew.Visible = False
                    'btnRecipeSaveNew.Visible = True
                End If
            Else
                ''btnprint.Visible = False
                ''btnprintblank.Visible = False
                btnprintRec.Visible = True
                btnprtBlankRec.Visible = True
                pnlRecipe.Enabled = False
                If Fid = "0" Then
                    'divRecipeHistory.Visible = False
                    divFormulationType.Visible = False
                    divFormulationNo.Visible = False
                    ''divDDLProductRecipe.Visible = False
                    ''divTxtProductRecipe.Visible = False
                    FillddlProductRecipe()
                    AddRecipeFirstRow()
                    AddProcedureFirstRow()
                    DisableFormulation()
                    FillDetailRecipe()
                    getMaxFormIDByProdId()
                    '-------
                    'divRecipeHistory.Visible = True
                    'FillRecipeHistory()
                    '--------
                    gvIngredient.HeaderRow.Visible = False
                    ' FillRecipeHistory()
                Else
                    '' ''If Request.QueryString("M") <> Nothing Then
                    '' ''    M = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("M")))
                    '' ''End If
                    '' ''If M = 0 Then
                    divRecipeHistory.Visible = False
                    divFormulationType.Visible = False
                    divFormulationNo.Visible = False
                    ''divDDLProductRecipe.Visible = False
                    ''divTxtProductRecipe.Visible = False
                    FillddlProductRecipe()
                    AddRecipeFirstRow()
                    AddProcedureFirstRow()
                    DisableFormulation()
                    FillDetailRecipe()
                    '--------
                    'divRecipeHistory.Visible = True
                    'FillRecipeHistory()
                    '---------
                    gvIngredient.HeaderRow.Visible = False
                    '' ''Else
                    '' ''    'FillPopUp()
                    '' ''    'mpe.Show()
                    '' ''End If

                    Dim Check As String = LMSBLL.CheckExist("RecipeCheckExist", ViewState("Recipe_Id"))
                    If Check = "Already Exist" Then
                        'rfvSeoURL.IsValid = False
                        btnAddFeedback.Visible = False
                        btnViewFeedback.Visible = True
                    Else
                        btnAddFeedback.Visible = True
                        btnViewFeedback.Visible = False
                    End If

                End If
                If Request.QueryString("chk") = "v" Then
                    DisableViewModeRecipe()
                End If

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub
    Private Sub FillRecipeId()
        Try
            ViewState("Formulation_Id") = PageID
            Dim dt As DataSet = LMSBLL.FillGridByID(PageID, "DisplayFormulation")
            If dt.Tables(1).Rows.Count > 0 Then
                ViewState("Recipe_Id") = (dt.Tables(1).Rows(0)("Recipe_Id"))
            Else
                ViewState("Recipe_Id") = 0
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "Fill Recipe Details"

    Public Sub FillddlProductRecipe()
        Try
            Dim ds As DataSet
            ds = LMSBLL.DropdownWithUserId("FillProductByID", Session("LMSUserId"), Session("LMSUserRoleID"))
            ddlProductRecipe.DataSource = ds.Tables(0)
            ddlProductRecipe.DataTextField = "Product_Name"
            ddlProductRecipe.DataValueField = "Product_Id"
            ddlProductRecipe.DataBind()
            ddlProductRecipe.Items.Insert(0, New ListItem("Select Product", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub FillRecipeNo()
        Try
            Dim RecipeNo As String = LMSBLL.RecipeNo()
            lblRecipeNo.Text = RecipeNo
            LMSassigncontrol1.UhfTypeCode.Value = RecipeNo
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetailRecipe()
        Try
            MainID = ViewState("Recipe_Id")
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Request.QueryString("Fid") <> Nothing Then
                Fid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Fid")))
            End If
            Dim dt As DataSet
            If MainID = 0 Then
                'If Fid = 0 Then
                dt = LMSBLL.FillGridByID(ViewState("RecipeIDForFill"), "DispRecipeIngredients")
                'Else
                '    dt = LMSBLL.FillGridByID(Fid, "DispRecipeIngredients")
                'End If

            Else
                If Session("LMSUserId") = 1 Then
                    divStatusRemark.Visible = True
                    btnRecipeSaveApprove.Visible = True
                    btnRecipeDisApprove.Visible = True
                    'btnRecipeDisApprove.Visible = False
                Else
                    divStatusRemark.Visible = False
                    btnRecipeSaveApprove.Visible = False
                    btnRecipeDisApprove.Visible = False
                End If
                ''btnOnlyRecipeSave.Visible = True
                btnRecipeSaveNew.Visible = False
                'btnRecipeSaveNew.Visible = True
                dt = LMSBLL.FillGridByID(MainID, "DispRecipeIngredients")
            End If
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            If dtUser.Rows.Count > 0 Then
                drLogin = dtUser.Rows(0)
                If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Approved")) = "Approved" Then
                    lblRecApproved.Text = "Approved"
                    divStatusRemark.Visible = True
                    txtAppDisApp.Enabled = False
                    btnRecipeSaveApprove.Visible = False
                    btnRecipeDisApprove.Visible = False
                ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Approved")) = "Pending" Then
                    lblRecApproved.Text = "Pending"
                    If Session("LMSUserId") = 1 Then
                        divStatusRemark.Visible = True
                        btnRecipeSaveApprove.Visible = True
                        'btnRecipeDisApprove.Visible = False
                        btnRecipeDisApprove.Visible = True
                    Else
                        divStatusRemark.Visible = False
                        btnRecipeSaveApprove.Visible = False
                        btnRecipeDisApprove.Visible = False
                    End If
                Else
                    lblRecApproved.Text = "Rejected"
                    divStatusRemark.Visible = True
                    txtAppDisApp.Enabled = False
                    btnRecipeSaveApprove.Visible = False
                    btnRecipeDisApprove.Visible = False
                End If
                'lblFormulationNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                txtAppDisApp.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_StatusRemark"))
                lblType.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))
                lblmodifiednameRecipe.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName"))
                lblmodifieddateRecipe.Text = DynamicparcelDataManipulation.AlphaDateFormat(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_ModifiedDate")).ToString())
                ddlFormulationNo.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
                If ddlFormulationNo.SelectedValue <> "" Then
                    hfFRNo.Value = ddlFormulationNo.SelectedItem.Text
                    ' ViewState("hfFRNo") = ddlFormulationNo.SelectedItem.Text
                Else
                    hfFRNo.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                    ' ViewState("hfFRNo") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                End If
                'hfFRNo.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                ViewState("Formulation_Id") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
                Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
                Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
                If FType = "Product" And ProdID = 0 Then
                    ddlFormulationType.SelectedValue = 1
                ElseIf FType = "Competitor" And ProdID = 0 Then
                    ddlFormulationType.SelectedValue = 2
                ElseIf FType = "Product" And ProdID <> 0 Then
                    ddlFormulationType.SelectedValue = 0
                End If
                'If ProdID = 0 Then
                '    divDDLProductRecipe.Visible = False
                '    divTxtProductRecipe.Visible = True
                '    txtProductRecipe.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdName"))
                'Else
                '    divDDLProductRecipe.Visible = True
                '    divTxtProductRecipe.Visible = False
                '    ddlProductRecipe.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
                'End If
                'txtRemarkProc.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RecipeIngredient_Remarks"))
                lblRecipeNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                LMSassigncontrol1.UhfTypeCode.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                ddlMixer.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mixer"))
                ddlBlade.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Blade"))
                ddlMould.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mould"))
                ddlOven.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Oven"))
                txtRemarkIngre.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RecipeIngredient_Remarks"))
            Else
                AddRecipeFirstRow()
            End If
            txtFormTab.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("RecipeIngredient_Value"))
            dt.Tables(1).Rows.Remove(dt.Tables(1).Rows(0))
            gvIngredient.DataSource = dt.Tables(1)
            Session("IngredientViewMode") = dt.Tables(1)
            ViewState("gvIngredientItems") = dt.Tables(1)
            Dim dtIng As New DataTable
            dtIng = dt.Tables(1)
            ' Dim drIng As DataRow
            If dtIng.Rows.Count > 0 Then
                'drIng = dtIng.Rows(0)
                gvIngredient.DataBind()
                SetRecipePreviousData()
            Else
                AddRecipeFirstRow()
            End If

            gvProcedure.DataSource = dt.Tables(2)
            Session("ProcedureViewMode") = dt.Tables(2)
            ViewState("gvProcedureItems") = dt.Tables(2)
            gvProcedure.DataBind()
            SetProcedurePreviousData()

            Dim dtProc As New DataTable
            dtProc = dt.Tables(2)
            Dim drProc As DataRow
            If dtProc.Rows.Count > 0 Then
                drProc = dtProc.Rows(0)
                txtRemarkProc.Text = DynamicparcelDataManipulation.FixNullFromDB(drProc("RecipeProcedure_Remarks"))
            Else
                AddProcedureFirstRow()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnCompareRecipe_Click(sender As Object, e As EventArgs) Handles btnCompareRecipe.Click
        Try
            btnPasteCompareForm.Visible = True
            btnPasteCompareRecipe.Visible = True
            Dim Url As String = "compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=P" + (hfCompareID.Value).ToString()
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" + Url + "','_blank');", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnPasteCompareRecipe_Click(sender As Object, e As EventArgs) Handles btnPasteCompareRecipe.Click
        Try
            If Session("RecipeIDForFill") = Nothing Then
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please Copy Recipe first.')", True)
            Else
                ViewState("RecipeIDForFill") = Session("RecipeIDForFill")
                CopyDetailRecipe()
                'CopyFormulation()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnOnlyRecipeSave_Click(sender As Object, e As EventArgs) Handles btnOnlyRecipeSave.Click
        Try
            InsertOnlyRecipe()
            InsertAssignTo()
            Response.Redirect("Trials.aspx")
            'InsertFormulation()
            'InsertRecipe()
            'UpdateFormulationMain()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnBothFormReciSave_Click(sender As Object, e As EventArgs) Handles btnBothFormReciSave.Click
        Try
            Dim lblQFootError As Label = DirectCast(gvLMS.FooterRow.FindControl("lblQFootError"), Label)
            If lblQFootError.Visible = False Then
                InsertFormulation()
                InsertRecipeWidFormulation()
                InsertAssignTo()
                Response.Redirect("Trials.aspx")
            Else
                'lblQFootError.Focus()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnRecipeSaveApprove_Click(sender As Object, e As EventArgs) Handles btnRecipeSaveApprove.Click
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If btnOnlyRecipeSave.Visible = True Then
                InsertOnlyRecipe()
                InsertAssignTo()
                UpdateRecipeApprove()
                UpdateFormulationApprove()
            ElseIf btnBothFormReciSave.Visible = True Then
                InsertFormulation()
                InsertRecipeWidFormulation()
                InsertAssignTo()
                UpdateRecipeApprove()
                UpdateFormulationApprove()
            End If
            Response.Redirect("Trials.aspx")

            ' ''If PageID = 0 Then
            ' ''    InsertRecipe()
            ' ''    UpdateRecipeApprove()
            ' ''    UpdateFormulationApprove()
            ' ''    UpdateFormulationMain()
            ' ''    btnRecipeSaveApprove.Visible = False
            ' ''    btnRecipeDisApprove.Visible = False
            ' ''    'btnOnlyRecipeSave.Visible = False
            ' ''    'btnRecipeSave.Visible = False
            ' ''    lblRecApproved.Text = "Approved"
            ' ''Else
            ' ''    InsertRecipe()
            ' ''    UpdateRecipeApprove()
            ' ''    UpdateFormulationMain()
            ' ''    ' Response.Redirect("Recipe.aspx")
            ' ''    btnRecipeSaveApprove.Visible = False
            ' ''    btnRecipeDisApprove.Visible = False
            ' ''    'btnOnlyRecipeSave.Visible = False
            ' ''    'btnRecipeSave.Visible = False
            ' ''    lblRecApproved.Text = "Approved"
            ' ''End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnRecipeDisApprove_Click(sender As Object, e As EventArgs) Handles btnRecipeDisApprove.Click
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If btnOnlyRecipeSave.Visible = True Then
                InsertOnlyRecipe()
                InsertAssignTo()
                UpdateRecipeDisApprove()
                UpdateFormulationDisApprove()
            ElseIf btnBothFormReciSave.Visible = True Then
                InsertFormulation()
                InsertRecipeWidFormulation()
                InsertAssignTo()
                UpdateRecipeDisApprove()
                UpdateFormulationDisApprove()
            End If
            Response.Redirect("Trials.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub UpdateRecipeApprove()
        Try
            'If ddlFormulationType.SelectedValue = 0 Then
            '    LMSBLL.UpdateApprove("UpdateRecipeApprove", ViewState("Recipe_Id"), Session("LMSUserId"))
            'Else
            LMSBLL.UpdateApprove("UpdateRecipeApprove", ViewState("Recipe_Id"), Session("LMSUserId"), "")
            'End If
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Recipe has been approved')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    Private Sub UpdateRecipeDisApprove()
        Try
            LMSBLL.UpdateApprove("UpdateRecipeDisApprove", ViewState("Recipe_Id"), Session("LMSUserId"), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Recipe has been approved')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub

    Private Sub InsertRecipe1()
        Try
            Dim Recipe_Id As Integer = LMSBLL.InsertRecipe(lblRecipeNo.Text, ViewState("Formulation_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))
            ViewState("Recipe_Id") = Recipe_Id
            LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), lblFormNoTab.Text, txtFormTab.Text, "100", txtRemarkIngre.Text, Session("LMSUserId"))
            For i As Integer = 0 To gvIngredient.Rows.Count - 1
                Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIName"), TextBox)
                Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIValue"), TextBox)
                Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIPercent"), TextBox)

                LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), txtIName.Text, txtIValue.Text, txtIPercent.Text, txtRemarkIngre.Text, Session("LMSUserId"))
            Next
            For i As Integer = 0 To gvProcedure.Rows.Count - 1
                Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcStep"), TextBox)
                Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTerm"), TextBox)
                Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTime"), TextBox)

                LMSBLL.InsertRecipeProcedure(ViewState("Recipe_Id"), txtProcStep.Text, txtProcTerm.Text, txtProcTime.Text, txtRemarkProc.Text, Session("LMSUserId"))
            Next
            Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(Recipe_Id)
            LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
            LMSassigncontrol1.Uhftype.Value = "Recipe"
            Session("FirstAssignto") = Nothing
            'LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
            LMSassigncontrol1.AddLMSBothAssignTo(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub

    Private Sub InsertAssignTo()
        Try
            If hfAccessFor.Value = "Formulation" Then
                LMSassigncontrol1.Uhftype.Value = "Formulation"
                Dim FormulationNo As String = LMSBLL.FormulationNoForInsert(ViewState("Formulation_Id"))
                LMSassigncontrol1.UhfTypeCode.Value = FormulationNo
                LMSassigncontrol1.AddLMSAssignTo(ViewState("Formulation_Id"))
            ElseIf hfAccessFor.Value = "Recipe" Then
                LMSassigncontrol1.Uhftype.Value = "Recipe"
                Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(ViewState("Recipe_Id"))
                LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
                Session("FirstAssignto") = Nothing
                LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
                'LMSassigncontrol1.AddLMSBothAssignTo(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
            ElseIf hfAccessFor.Value = "Both" Then
                LMSassigncontrol1.Uhftype.Value = "Both"
                Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(ViewState("Recipe_Id"))
                LMSassigncontrol1.UhfTypeCode.Value = Recipe_No

                Dim FormulationNo As String = LMSBLL.FormulationNoForInsert(ViewState("Formulation_Id"))
                LMSassigncontrol1.UhfFormulationCode.Value = FormulationNo
                'Session("FirstAssignto") = Nothing
                'LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
                LMSassigncontrol1.AddLMSBothAssignTo(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
            Else
                Response.Redirect("LMSDashboard.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub

    Private Sub InsertRecipeWidFormulation()
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If PageID = 0 Then

                Dim Recipe_Id As Integer = LMSBLL.InsertRecipe(lblRecipeNo.Text, ViewState("Formulation_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))
                ViewState("Recipe_Id") = Recipe_Id
                LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), lblFormNoTab.Text, txtFormTab.Text, "100", txtRemarkIngre.Text, Session("LMSUserId"))
                For i As Integer = 0 To gvIngredient.Rows.Count - 1
                    Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIName"), TextBox)
                    Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIValue"), TextBox)
                    Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIPercent"), TextBox)

                    LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), txtIName.Text, txtIValue.Text, txtIPercent.Text, txtRemarkIngre.Text, Session("LMSUserId"))
                Next
                For i As Integer = 0 To gvProcedure.Rows.Count - 1
                    Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcStep"), TextBox)
                    Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTerm"), TextBox)
                    Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTime"), TextBox)

                    LMSBLL.InsertRecipeProcedure(ViewState("Recipe_Id"), txtProcStep.Text, txtProcTerm.Text, txtProcTime.Text, txtRemarkProc.Text, Session("LMSUserId"))
                Next
                Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(Recipe_Id)
                '*''LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
                '*''LMSassigncontrol1.Uhftype.Value = "Recipe"
                '*''LMSassigncontrol1.Uhftypeid.Value = Recipe_Id
                '* ''Session("FirstAssignto") = Nothing
                '* ''LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
                '*''LMSassigncontrol1.AddLMSRecipeAssignToNoSMS(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
            Else
                Dim IngredientCheck As Boolean = AreTablesSameIngredient()
                Dim ProcedureCheck As Boolean = AreTablesSameProcedure()
                LMSBLL.UpdateRecipe(ViewState("Recipe_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))

                If IngredientCheck = False Or ProcedureCheck = False Then
                    UpdateRecipeChild()
                End If
                '* Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(ViewState("Recipe_Id"))
                '*''LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
                '*''LMSassigncontrol1.Uhftype.Value = "Recipe"
                '*''LMSassigncontrol1.Uhftypeid.Value = ViewState("Recipe_Id")
                '* ''Session("FirstAssignto") = Nothing
                '* ''LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
                '*''LMSassigncontrol1.AddLMSRecipeAssignToNoSMS(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    Private Sub InsertOnlyRecipe()
        Try
            PageID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            MainID = ViewState("Recipe_Id")

            Fid = ViewState("Formulation_Id")
            If PageID = 0 Then

                Dim Recipe_Id As Integer = LMSBLL.InsertRecipe(lblRecipeNo.Text, ViewState("Formulation_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))
                ViewState("Recipe_Id") = Recipe_Id
                LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), lblFormNoTab.Text, txtFormTab.Text, "100", txtRemarkIngre.Text, Session("LMSUserId"))
                For i As Integer = 0 To gvIngredient.Rows.Count - 1
                    Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIName"), TextBox)
                    Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIValue"), TextBox)
                    Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIPercent"), TextBox)

                    LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), txtIName.Text, txtIValue.Text, txtIPercent.Text, txtRemarkIngre.Text, Session("LMSUserId"))
                Next
                For i As Integer = 0 To gvProcedure.Rows.Count - 1
                    Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcStep"), TextBox)
                    Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTerm"), TextBox)
                    Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTime"), TextBox)

                    LMSBLL.InsertRecipeProcedure(ViewState("Recipe_Id"), txtProcStep.Text, txtProcTerm.Text, txtProcTime.Text, txtRemarkProc.Text, Session("LMSUserId"))
                Next
                ' ''Dim Recipe_No As String = LMSBLL.RecipeNoForInsert(Recipe_Id)
                ' ''LMSassigncontrol1.UhfTypeCode.Value = Recipe_No
                ' ''LMSassigncontrol1.Uhftype.Value = "Recipe"
                ' ''LMSassigncontrol1.Uhftypeid.Value = Recipe_Id
                '' ''Session("FirstAssignto") = Nothing
                '' ''LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
                ' ''LMSassigncontrol1.AddLMSRecipeAssignToNoSMS(ViewState("Recipe_Id"), ViewState("Formulation_Id"))

            Else
                ViewState("Recipe_Id") = MainID
                Dim IngredientCheck As Boolean = AreTablesSameIngredient()
                Dim ProcedureCheck As Boolean = AreTablesSameProcedure()
                LMSBLL.UpdateRecipe(ViewState("Recipe_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))

                If IngredientCheck = False Or ProcedureCheck = False Then
                    UpdateRecipeChild()
                End If
            End If
            'FillRecipeNo()
            ' ''LMSassigncontrol1.Uhftype.Value = "Recipe"
            '' ''LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
            ' ''LMSassigncontrol1.AddLMSBothAssignTo(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub InsertRecipe()
        Try
            MainID = ViewState("Recipe_Id")

            Fid = ViewState("Formulation_Id")
            If MainID = 0 Then
                Dim IngredientCheck As Boolean = AreTablesSameIngredient()
                Dim ProcedureCheck As Boolean = AreTablesSameProcedure()
                'ViewState("Recipe_Id") = MainID
                If Fid = 0 Then
                    If IngredientCheck = False Or ProcedureCheck = False Then
                        UpdateRecipeChild()
                    End If
                Else
                    If IngredientCheck = False Or ProcedureCheck = False Then
                        UpdateRecipeChild()
                    Else
                        If ddlFormulationNo.SelectedValue <> "" Then
                            'Insert()
                            InsertRecipe1()
                        End If
                    End If

                End If

            Else
                ViewState("Recipe_Id") = MainID
                Dim IngredientCheck As Boolean = AreTablesSameIngredient()
                Dim ProcedureCheck As Boolean = AreTablesSameProcedure()
                LMSBLL.UpdateRecipe(ViewState("Recipe_Id"), ddlMixer.SelectedValue, ddlBlade.SelectedValue, ddlMould.SelectedValue, ddlOven.SelectedValue, "", Session("LMSUserId"))

                If IngredientCheck = False Or ProcedureCheck = False Then
                    UpdateRecipeChild()
                End If
            End If
            'FillRecipeNo()
            LMSassigncontrol1.Uhftype.Value = "Recipe"
            'LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
            LMSassigncontrol1.AddLMSBothAssignTo(ViewState("Recipe_Id"), ViewState("Formulation_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub UpdateRecipeChild()
        Try
            LMSBLL.DeleteRecipeChild(ViewState("Recipe_Id"))
            LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), lblFormNoTab.Text, txtFormTab.Text, "100", txtRemarkIngre.Text, Session("LMSUserId"))
            For i As Integer = 0 To gvIngredient.Rows.Count - 1
                Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIName"), TextBox)
                Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIValue"), TextBox)
                Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(i).FindControl("txtIPercent"), TextBox)

                LMSBLL.InsertRecipeIngredient(ViewState("Recipe_Id"), txtIName.Text, txtIValue.Text, txtIPercent.Text, txtRemarkIngre.Text, Session("LMSUserId"))
            Next
            For i As Integer = 0 To gvProcedure.Rows.Count - 1
                Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcStep"), TextBox)
                Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTerm"), TextBox)
                Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(i).FindControl("txtProcTime"), TextBox)

                LMSBLL.InsertRecipeProcedure(ViewState("Recipe_Id"), txtProcStep.Text, txtProcTerm.Text, txtProcTime.Text, txtRemarkProc.Text, Session("LMSUserId"))
            Next
            'LMSassigncontrol1.AddLMSAssignTo(ViewState("Recipe_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
        End Try
    End Sub
    Public Function AreTablesSameIngredient() As Boolean
        Dim tbl1 As DataTable = Session("IngredientViewMode")
        If tbl1 IsNot Nothing Then

            Dim tbl2 As DataTable
            '----starts
            Dim dtN As New DataTable()
            '   For i As Integer = 0 To grditemproduct.Columns.Count - 1
            'dtN.Columns.Add("column" + i.ToString())
            'Dim count As Integer = 82
            dtN.Columns.Add("ltRowNumberIng", GetType(String))
            dtN.Columns.Add("txtIName", GetType(String))
            dtN.Columns.Add("txtIValue", GetType(String))
            dtN.Columns.Add("txtIPercent", GetType(String))

            For Each row In gvIngredient.Rows
                Dim ltRowNumberIng As Literal = DirectCast(row.FindControl("ltRowNumberIng"), Literal)
                Dim txtIName As TextBox = DirectCast(row.FindControl("txtIName"), TextBox)
                Dim txtIValue As TextBox = DirectCast(row.FindControl("txtIValue"), TextBox)
                Dim txtIPercent As TextBox = DirectCast(row.FindControl("txtIPercent"), TextBox)

                dtN.Rows.Add(ltRowNumberIng.Text, txtIName.Text, txtIValue.Text, txtIPercent.Text)
            Next
            tbl2 = dtN
            If tbl1.Rows.Count <> tbl2.Rows.Count Then
                Return False
            End If

            For i As Integer = 0 To tbl1.Rows.Count - 1
                If Not Equals(tbl1.Rows(i)(3).ToString(), tbl2.Rows(i)(1).ToString()) Then
                    'If Not Equals(tbl1.Rows(i)(10).ToString(), tbl2.Rows(i)(1).ToString()) Then
                    Return False
                End If
                If Not Equals(tbl1.Rows(i)(4).ToString(), tbl2.Rows(i)(2).ToString()) Then
                    'If Not Equals(tbl1.Rows(i)(11).ToString(), tbl2.Rows(i)(2).ToString()) Then
                    Return False
                End If
                If Not Equals(tbl1.Rows(i)(5).ToString(), tbl2.Rows(i)(3).ToString()) Then
                    'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                    Return False
                End If

            Next

        End If
        Return True
    End Function

    Public Function AreTablesSameProcedure() As Boolean
        Dim tbl1 As DataTable = Session("ProcedureViewMode")
        If tbl1 IsNot Nothing Then
            Dim tbl2 As DataTable

            Dim dtN As New DataTable()

            dtN.Columns.Add("RowNumber", GetType(String))
            dtN.Columns.Add("txtProcStep", GetType(String))
            dtN.Columns.Add("txtProcTerm", GetType(String))
            dtN.Columns.Add("txtProcTime", GetType(String))

            For Each row In gvProcedure.Rows
                Dim ltRowNumberProc As Literal = DirectCast(row.FindControl("ltRowNumberProc"), Literal)
                Dim txtProcStep As TextBox = DirectCast(row.FindControl("txtProcStep"), TextBox)
                Dim txtProcTerm As TextBox = DirectCast(row.FindControl("txtProcTerm"), TextBox)
                Dim txtProcTime As TextBox = DirectCast(row.FindControl("txtProcTime"), TextBox)

                dtN.Rows.Add(ltRowNumberProc.Text, txtProcStep.Text, txtProcTerm.Text, txtProcTime.Text)
            Next
            tbl2 = dtN
            If tbl1.Rows.Count <> tbl2.Rows.Count Then
                Return False
            End If


            For i As Integer = 0 To tbl1.Rows.Count - 1
                If Not Equals(tbl1.Rows(i)(3).ToString(), tbl2.Rows(i)(1).ToString()) Then
                    Return False
                End If
                If Not Equals(tbl1.Rows(i)(4).ToString(), tbl2.Rows(i)(2).ToString()) Then
                    Return False
                End If
                If Not Equals(tbl1.Rows(i)(5).ToString(), tbl2.Rows(i)(3).ToString()) Then
                    Return False
                End If

            Next
        End If
        Return True
    End Function

#End Region
#Region "Recipe History"
    Public Sub FillRecipeHistory()
        Try
            MainID = ViewState("Recipe_Id")

            ' ''MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ' ''If Request.QueryString("Fid") <> Nothing Then
            ' ''    Fid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Fid")))
            ' ''End If
            Fid = ViewState("Formulation_Id")

            If MainID = 0 Then
                If Fid = 0 Then
                    Dim value As String() = ddlProduct.SelectedValue.Split("^")

                    If value(1) = 0 Then
                        rpRecipeHistory.DataSource = LMSBLL.DropdownByIDName("getRecipeNoByName", Session("LMSUserRoleID"), value(0))
                        'rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), ddlProduct.SelectedValue)
                    Else
                        rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), value(1))
                    End If
                    'rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), ddlFormulationNo.SelectedValue)
                Else
                    rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), Fid)
                End If
            Else
                ' ''If Fid = 0 Then
                ' ''    rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), MainID)
                ' ''Else
                ' ''    rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), Fid)
                ' ''End If
                rpRecipeHistory.DataSource = LMSBLL.DropdownWithUserId("getRecipeNo", Session("LMSUserRoleID"), ddlProduct.SelectedValue)
            End If
            'If MainID = 0 Then
            '    If Fid = 0 Then
            '        rpRecipeHistory.DataSource = LMSBLL.FillGridByID(ddlFormulationNo.SelectedValue, "getRecipeCode")
            '    Else
            '        rpRecipeHistory.DataSource = LMSBLL.FillGridByID(Fid, "getRecipeCode")
            '    End If
            'Else
            '    If Fid = 0 Then
            '        rpRecipeHistory.DataSource = LMSBLL.FillGridByID(MainID, "getRecipeCode")
            '    Else
            '        rpRecipeHistory.DataSource = LMSBLL.FillGridByID(Fid, "getRecipeCode")
            '    End If
            'End If
            rpRecipeHistory.DataBind()

            Dim totalcount As Integer = rpRecipeHistory.Items.Count
            If totalcount > 0 Then
                lblRecipeHistory.Text = "Recipe History (" + totalcount.ToString + ")"
            Else
                divRecipeHistory.Visible = False
                'lblRecipeHistory.Text = "No Recipe History"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub rpRecipeHistory_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpRecipeHistory.ItemCommand
        Try
            If e.CommandName = "CopyRecipe" Then
                Dim btnCopyRecipe As LinkButton = DirectCast(e.Item.FindControl("btnCopyRecipe"), LinkButton)
                Dim lblRecipe_Id As Label = DirectCast(e.Item.FindControl("lblRecipe_Id"), Label)
                ViewState("RecipeIDForFill") = lblRecipe_Id.Text
                CopyDetailRecipe()
                'FillDetailRecipe()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub CopyDetailRecipe()
        Try

            Dim dt As DataSet

            dt = LMSBLL.FillGridByID(ViewState("RecipeIDForFill"), "DispRecipeIngredients")

            '  Dim dtUser As New DataTable
            '  dtUser = dt.Tables(0)
            '  Dim drLogin As DataRow
            ' If dtUser.Rows.Count > 0 Then

            'drLogin = dtUser.Rows(0)

            'Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            'Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
            'If FType = "Product" And ProdID = 0 Then
            '    ddlFormulationType.SelectedValue = 1
            'ElseIf FType = "Competitor" And ProdID = 0 Then
            '    ddlFormulationType.SelectedValue = 2
            'ElseIf FType = "Product" And ProdID <> 0 Then
            '    ddlFormulationType.SelectedValue = 0
            'End If


            'ddlMixer.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mixer"))
            'ddlBlade.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Blade"))
            'ddlMould.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mould"))
            'ddlOven.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Oven"))
            'txtRemarkIngre.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RecipeIngredient_Remarks"))
            '  Else
            '   AddRecipeFirstRow()
            '  AddProcedureFirstRow()
            '  End If

            txtFormTab.Text = DynamicparcelDataManipulation.FixNullFromDB(dt.Tables(1).Rows(0)("RecipeIngredient_Value"))
            dt.Tables(1).Rows.Remove(dt.Tables(1).Rows(0))
            gvIngredient.DataSource = dt.Tables(1)
            ' Session("IngredientViewMode") = dt.Tables(1)
            ViewState("gvIngredientItems") = dt.Tables(1)
            Dim dtIng As New DataTable
            dtIng = dt.Tables(2)
            If dtIng.Rows.Count > 0 Then
                gvIngredient.DataBind()
                SetRecipePreviousData()
            Else
                AddRecipeFirstRow()
            End If

            gvProcedure.DataSource = dt.Tables(2)
            '  Session("ProcedureViewMode") = dt.Tables(2)
            ViewState("gvProcedureItems") = dt.Tables(2)
            gvProcedure.DataBind()
            SetProcedurePreviousData()

            Dim dtProc As New DataTable
            dtProc = dt.Tables(2)
            '    Dim drProc As DataRow
            If dtProc.Rows.Count > 0 Then
                '  drProc = dtProc.Rows(0)
                ' txtRemarkProc.Text = DynamicparcelDataManipulation.FixNullFromDB(drProc("RecipeProcedure_Remarks"))
            Else
                AddProcedureFirstRow()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
#End Region
#Region "Ingredients"
    Protected Sub gvIngredient_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvIngredient.RowCommand
        Try
            Flag = 0
            If e.CommandName = "AddRecipeNewRow" Then
                AddRecipeNewRow()
            ElseIf e.CommandName = "deleteRecipeLink" Then
                SetRecipePreviousData()
                If ViewState("gvIngredientItems") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("gvIngredientItems"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()

                        ViewState("gvIngredientItems") = dt
                        Flag = rowIndex

                        gvIngredient.DataSource = dt
                        gvIngredient.DataBind()

                        If gvIngredient.Rows.Count <= 1 Then
                            Dim lnkdelete As LinkButton = DirectCast(gvIngredient.Rows(0).FindControl("lnkdelete"), LinkButton)
                            lnkdelete.Visible = False
                        Else
                            For i As Integer = 0 To gvIngredient.Rows.Count - 1
                                Dim lnkdelete As LinkButton = DirectCast(gvIngredient.Rows(i).FindControl("lnkdelete"), LinkButton)
                                lnkdelete.Visible = True
                            Next
                        End If
                        For i As Integer = 0 To gvIngredient.Rows.Count - 2
                            gvIngredient.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next

                    End If
                    SetRecipePreviousData()
                End If
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)

        End Try
    End Sub
    Private Sub AddRecipeFirstRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            'dt.Columns.Add(New DataColumn("Rm_Index", GetType(String)))
            'dt.Columns.Add(New DataColumn("FRNo", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeIngredient_Name", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeIngredient_Value", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeIngredient_Percent", GetType(String)))

            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            'dr("Rm_Index") = 1
            dr("RecipeIngredient_Name") = String.Empty
            dr("RecipeIngredient_Value") = String.Empty
            dr("RecipeIngredient_Percent") = String.Empty

            dt.Rows.Add(dr)
            ViewState("gvIngredientItems") = dt

            gvIngredient.DataSource = dt
            gvIngredient.DataBind()
            'Dim lblFRNo As Label = DirectCast(gvIngredient.HeaderRow.FindControl("lblFRNo"), Label)
            'lblFRNo.Text = "FRNo"
            'Dim lblFormNo As Label = DirectCast(gvIngredient.Rows(0).Cells(0).FindControl("lblFormNo"), Label)
            SetRecipePreviousData()

            Dim lnkdelete As LinkButton = DirectCast(gvIngredient.Rows(0).FindControl("lnkdelete"), LinkButton)
            lnkdelete.Visible = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddRecipeNewRow()
        Try

            Dim rowIndex As Integer = 0
            If ViewState("gvIngredientItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("gvIngredientItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        'Dim ltIndex As Literal = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("ltIndex"), Literal)
                        'Dim lblFRNo As Label = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("lblFRNo"), Label)
                        Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("txtIName"), TextBox)
                        Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("txtIValue"), TextBox)
                        Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("txtIPercent"), TextBox)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        '  drCurrentRow("RecipeIngredient_Percent") = 1
                        'drCurrentRow("RecipeIngredient_Name") = 0
                        'drCurrentRow("RecipeIngredient_Value") = (txtQuantity.Text - ViewState("Qtotal")) / txtQuantity.Text * 100
                        'dtCurrentTable.Rows(i - 1)("RecipeIngredient_Name") = txtIName.Text
                        dtCurrentTable.Rows(i - 1)("RecipeIngredient_Name") = txtIName.Text
                        dtCurrentTable.Rows(i - 1)("RecipeIngredient_Value") = txtIValue.Text
                        dtCurrentTable.Rows(i - 1)("RecipeIngredient_Percent") = txtIPercent.Text

                        'lblFRNo.Text = "FRNo"
                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("gvIngredientItems") = dtCurrentTable
                    gvIngredient.DataSource = dtCurrentTable
                    gvIngredient.DataBind()
                End If
            End If
            SetRecipePreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex

        End Try
    End Sub
    Private Sub SetRecipePreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("gvIngredientItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("gvIngredientItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim txtIName As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(1).FindControl("txtIName"), TextBox)
                        Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(2).FindControl("txtIValue"), TextBox)
                        Dim txtIPercent As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(3).FindControl("txtIPercent"), TextBox)


                        gvIngredient.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        dt.Rows(i)("RecipeIngredient_Name") = txtIName.Text
                        dt.Rows(i)("RecipeIngredient_Value") = txtIValue.Text
                        dt.Rows(i)("RecipeIngredient_Percent") = txtIPercent.Text
                        rowIndex += 1

                        txtIName.Text = dt.Rows(i)("RecipeIngredient_Name").ToString
                        txtIValue.Text = dt.Rows(i)("RecipeIngredient_Value").ToString
                        txtIPercent.Text = dt.Rows(i)("RecipeIngredient_Percent").ToString

                        If i < dt.Rows.Count - 1 Then
                            txtIName.Enabled = False
                        End If

                    Next
                    ViewState("gvIngredientItems") = dt
                    gvIngredient.DataSource = dt
                    gvIngredient.DataBind()
                    IngTotal()
                    'Dim lblFRNo As Label = DirectCast(gvIngredient.HeaderRow.FindControl("lblFRNo"), Label)
                    'lblFRNo.Text = hfFRNo.Value
                    'Dim lblFormNo As Label = DirectCast(gvIngredient.Rows(0).Cells(0).FindControl("lblFormNo"), Label)
                    'lblFormNo.Text = hfFRNo.Value
                    'If ddlFormulationNo.DataSource IsNot Nothing Then

                    '    If ddlFormulationNo.SelectedValue IsNot "" Or ddlFormulationNo.SelectedValue IsNot "0" Then
                    '        hfFRNo.Value = ddlFormulationNo.SelectedItem.Text
                    '    End If
                    'End If
                    lblFormNoTab.Text = hfFRNo.Value
                    'lblFormNoTab.Text = ViewState("hfFRNo")
                    Dim lnkdelete As LinkButton = DirectCast(gvIngredient.Rows(0).FindControl("lnkdelete"), LinkButton)
                    If gvIngredient.Rows.Count <= 1 Then
                        lnkdelete.Visible = False
                    Else
                        For i As Integer = 0 To gvIngredient.Rows.Count - 1
                            lnkdelete.Visible = True
                        Next
                    End If
                End If
            End If
            gvIngredient.HeaderRow.Visible = False
            lblFormNoTab.Visible = True
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region
#Region "Procedure"
    Protected Sub gvProcedure_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvProcedure.RowCommand
        Try
            Flag = 0
            If e.CommandName = "AddProcedureNewRow" Then
                AddProcedureNewRow()
            ElseIf e.CommandName = "deleteProcedureLink" Then
                SetProcedurePreviousData()
                If ViewState("gvProcedureItems") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("gvProcedureItems"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()

                        ViewState("gvProcedureItems") = dt
                        Flag = rowIndex

                        gvProcedure.DataSource = dt
                        gvProcedure.DataBind()

                        If gvProcedure.Rows.Count <= 1 Then
                            Dim lnkdelete As LinkButton = DirectCast(gvProcedure.Rows(0).FindControl("lnkdelete"), LinkButton)
                            lnkdelete.Visible = False
                        Else
                            For i As Integer = 0 To gvProcedure.Rows.Count - 1
                                Dim lnkdelete As LinkButton = DirectCast(gvProcedure.Rows(i).FindControl("lnkdelete"), LinkButton)
                                lnkdelete.Visible = True
                            Next
                        End If
                        For i As Integer = 0 To gvProcedure.Rows.Count - 2
                            gvProcedure.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
                        Next


                    End If
                    SetProcedurePreviousData()
                End If
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddProcedureFirstRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            'dt.Columns.Add(New DataColumn("Rm_Index", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeProcedure_Step", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeProcedure_Term", GetType(String)))
            dt.Columns.Add(New DataColumn("RecipeProcedure_Time", GetType(String)))


            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")
            'dr("Rm_Index") = 1
            dr("RecipeProcedure_Step") = String.Empty
            dr("RecipeProcedure_Term") = String.Empty
            dr("RecipeProcedure_Time") = String.Empty

            dt.Rows.Add(dr)
            ViewState("gvProcedureItems") = dt

            gvProcedure.DataSource = dt
            gvProcedure.DataBind()

            SetProcedurePreviousData()

            Dim lnkdelete As LinkButton = DirectCast(gvProcedure.Rows(0).FindControl("lnkdelete"), LinkButton)
            lnkdelete.Visible = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddProcedureNewRow()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("gvProcedureItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("gvProcedureItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(0).FindControl("txtProcStep"), TextBox)
                        Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(0).FindControl("txtProcTerm"), TextBox)
                        Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(0).FindControl("txtProcTime"), TextBox)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        '   drCurrentRow("RecipeProcedure_Time") = "00:00"

                        dtCurrentTable.Rows(i - 1)("RecipeProcedure_Step") = txtProcStep.Text
                        dtCurrentTable.Rows(i - 1)("RecipeProcedure_Term") = txtProcTerm.Text
                        dtCurrentTable.Rows(i - 1)("RecipeProcedure_Time") = txtProcTime.Text
                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("gvProcedureItems") = dtCurrentTable
                    gvProcedure.DataSource = dtCurrentTable
                    gvProcedure.DataBind()
                End If
            End If
            SetProcedurePreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SetProcedurePreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("gvProcedureItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("gvProcedureItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim txtProcStep As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(1).FindControl("txtProcStep"), TextBox)
                        Dim txtProcTerm As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(2).FindControl("txtProcTerm"), TextBox)
                        Dim txtProcTime As TextBox = DirectCast(gvProcedure.Rows(rowIndex).Cells(3).FindControl("txtProcTime"), TextBox)

                        gvProcedure.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        dt.Rows(i)("RecipeProcedure_Step") = txtProcStep.Text
                        dt.Rows(i)("RecipeProcedure_Term") = txtProcTerm.Text
                        dt.Rows(i)("RecipeProcedure_Time") = txtProcTime.Text
                        rowIndex += 1

                        txtProcStep.Text = dt.Rows(i)("RecipeProcedure_Step").ToString
                        txtProcTerm.Text = dt.Rows(i)("RecipeProcedure_Term").ToString
                        txtProcTime.Text = dt.Rows(i)("RecipeProcedure_Time").ToString

                        If i < dt.Rows.Count - 1 Then
                            txtProcStep.Enabled = False
                        End If

                    Next
                    ViewState("gvProcedureItems") = dt
                    gvProcedure.DataSource = dt
                    gvProcedure.DataBind()
                    Dim lnkdelete As LinkButton = DirectCast(gvProcedure.Rows(0).FindControl("lnkdelete"), LinkButton)
                    If gvProcedure.Rows.Count <= 1 Then
                        lnkdelete.Visible = False
                    Else
                        For i As Integer = 0 To gvProcedure.Rows.Count - 1
                            lnkdelete.Visible = True
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub DisableFormulation()
        Try
            ddlFormulationType.Enabled = False
            ddlProductRecipe.Enabled = False
            txtProductRecipe.Enabled = False
            'ddlMixTypeRecipe.Enabled = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub DisableViewModeRecipe()
        Try
            DisableFormulation()
            ddlFormulationNo.Enabled = False
            ddlMixer.Enabled = False
            ddlBlade.Enabled = False
            ddlMould.Enabled = False
            ddlOven.Enabled = False
            gvIngredient.Enabled = False
            txtRemarkIngre.Enabled = False
            gvProcedure.Enabled = False
            txtRemarkProc.Enabled = False
            btnCompareRecipe.Visible = False
            lblCompRecipe.Visible = False
            btnRecipeSaveApprove.Visible = False
            btnRecipeDisApprove.Visible = False
            btnOnlyRecipeSave.Visible = False
            btnBothFormReciSave.Visible = False
            btnRecipeSaveNew.Visible = False
            Dim lnkadd As LinkButton = DirectCast(gvIngredient.FooterRow.FindControl("lnkadd"), LinkButton)
            lnkadd.Visible = False
            For i As Integer = 0 To gvIngredient.Rows.Count - 1
                Dim lnkdelete As LinkButton = DirectCast(gvIngredient.Rows(i).FindControl("lnkdelete"), LinkButton)
                lnkdelete.Visible = False
            Next
            Dim lnkadd1 As LinkButton = DirectCast(gvProcedure.FooterRow.FindControl("lnkadd"), LinkButton)
            lnkadd1.Visible = False
            For i As Integer = 0 To gvProcedure.Rows.Count - 1
                Dim lnkdelete As LinkButton = DirectCast(gvProcedure.Rows(i).FindControl("lnkdelete"), LinkButton)
                lnkdelete.Visible = False
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region

#End Region

    ''Protected Sub btnCompareForm_Click(sender As Object, e As EventArgs) Handles btnCompareForm.Click
    ''    Try
    ''        Dim Url As String = "compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=P" + (hfCompareID.Value).ToString()
    ''        ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Call", "alert('Proposal saved successfully !');window.open('Proposal.aspx',_newtab)", True)

    ''        'Response.Redirect("<script>window.open('http://www.google.com/','_blank');</script>")
    ''        'btnCompareForm.target = "_blank"
    ''        'Response.Redirect("compare.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(hfCompareID.Value.ToString())) + "&&Levl=P" + (hfCompareID.Value).ToString())
    ''    Catch ex As Exception

    ''    End Try
    ''End Sub

   
    
    Protected Sub btnprint_ServerClick(sender As Object, e As EventArgs) Handles btnprint.ServerClick
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Response.Redirect("PrintFormulation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Formulation_Id"))))
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnprintblank_ServerClick(sender As Object, e As EventArgs) Handles btnprintblank.ServerClick
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Response.Redirect("PrintFormulation.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Formulation_Id"))) + "&print=b")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnprintRec_ServerClick(sender As Object, e As EventArgs) Handles btnprintRec.ServerClick
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Response.Redirect("Printrecipe.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Recipe_Id"))))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnprtBlankRec_ServerClick(sender As Object, e As EventArgs) Handles btnprtBlankRec.ServerClick
        Try
            'MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Insert remark for approval.');window.location='" + url + "'", True)
            Response.Redirect("Printrecipe.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Recipe_Id"))) + "&print=b")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewFeedback_Click(sender As Object, e As EventArgs) Handles btnViewFeedback.Click
        Try
            Dim TrId As Integer = LMSBLL.IdById("getTrialIdByRecipe", ViewState("Recipe_Id"))
            Response.Redirect("ModifyFeedback.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(TrId)) + "&returnurl=y")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnAddFeedback_Click(sender As Object, e As EventArgs) Handles btnAddFeedback.Click
        Try
            Response.Redirect("ModifyFeedback.aspx?&ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&RId=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Recipe_Id"))))
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnRecipeCancel_Click(sender As Object, e As EventArgs) Handles btnRecipeCancel.Click
        Response.Redirect("Trials.aspx")
    End Sub

    Protected Sub btnFormulationCancel_Click(sender As Object, e As EventArgs) Handles btnFormulationCancel.Click
        Response.Redirect("Trials.aspx")
    End Sub

    Private Sub IngTotal()
        Try
            Dim rowIndex As Integer = 0
            Dim ITotal As Double = 0
            If gvIngredient.Rows.Count > 0 Then
                For i As Integer = 0 To gvIngredient.Rows.Count - 1
                    Dim txtIValue As TextBox = DirectCast(gvIngredient.Rows(rowIndex).Cells(0).FindControl("txtIValue"), TextBox)

                    If txtIValue.Text = "" Then
                        txtIValue.Text = 0
                    End If
                    ITotal = ITotal + txtIValue.Text

                    rowIndex += 1
                Next
            End If
            If txtFormTab.Text = "" Then
                txtFormTab.Text = 0
            End If
            ITotal = ITotal + txtFormTab.Text
            ' ''SetPreviousData()
            Dim lblsubtotalf As Label = DirectCast(gvIngredient.FooterRow.FindControl("lblsubtotalf"), Label)
            lblsubtotalf.Text = ITotal
           
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex

        End Try
    End Sub

End Class
