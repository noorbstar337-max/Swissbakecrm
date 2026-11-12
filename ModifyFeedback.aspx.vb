Imports DynamicparcelEnumerations
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports System.Collections
Partial Class ModifyFeedback
    Inherits _PageBaseClass
    Dim Flag As Integer
    Dim Flag1 As Integer
    Dim MainID As Integer
    Dim cattype As String
    Dim Rid As Integer
    Dim strvat As New List(Of String)
    Dim LargeImagePath As String
    Dim C1 As Integer = 0, C2 As Integer = 0, C3 As Integer = 0

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If Session("LMSUserId") = Nothing Then

                TryCast(Me.Master, LMSMasterPage).MaintainSession()
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("LMSDashboard.aspx")
                End If
                If Request.QueryString("chk") = "v" Then
                    DisableViewMode()
                Else

                End If
                LMSBLL.CheckLMSPrivilegeForModify(Session("LMSUserRoleID"), "Feedback.aspx")
            Else
                If Session("LMSUserId") = 1 Then
                    btnTrialDisapprove.Visible = True
                    btnRejNCrtNew.Visible = True
                    btnTrialSaveApprove.Visible = True
                    divStatusRemark.Visible = True
                Else
                    btnTrialDisapprove.Visible = False
                    btnRejNCrtNew.Visible = False
                    btnTrialSaveApprove.Visible = False
                    divStatusRemark.Visible = False
                End If
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("LMSDashboard.aspx")
                End If
                If Request.QueryString("chk") = "v" Then
                    DisableViewMode()
                Else

                End If
                LMSBLL.CheckLMSPrivilegeForModify(Session("LMSUserRoleID"), "Feedback.aspx")
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='LMSDashboard.aspx';", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Dim dt As DataSet = LMSPrivilegeBLL.CheckLMSPrivilege(Session("LMSUserId"), "FeedBack.aspx")
                Dim dtprivilage As New DataTable
                dtprivilage = dt.Tables(0)
                If dtprivilage.Rows.Count > 0 Then
                    If Request.QueryString("chk") = "e" Then  'For Edit
                        If dtprivilage.Rows(0)("Prvg_RUpdate") = True Then
                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    ElseIf Request.QueryString("chk") = "v" Then  'For View
                        If dtprivilage.Rows(0)("Prvg_Rview") = True Then

                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    Else         ' for add new 
                        If dtprivilage.Rows(0)("Prvg_RAdd") = True Then

                        Else
                            Response.Redirect("LMSDashboard.aspx")
                        End If
                    End If
                Else
                    Response.Redirect("LMSDashboard.aspx")
                End If
                'liTrial.Attributes("class") = "active"
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                'rp_gallery.DataSource = MultivieBLL.FillDetailbyID("Image", MainID)
                'rp_gallery.DataBind()
                If Request.QueryString("Rid") <> Nothing Then
                    Rid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Rid")))
                    ddlrecipie.SelectedValue = Rid
                    ddlrecipie_SelectedIndexChanged(Nothing, Nothing)
                End If
                LMSassigncontrol.Uhftype.Value = "Feedback"
                LMSassigncontrol.Uhftypeid.Value = MainID

                If MainID = "0" Then
                    divPopup.Visible = False
                    divSingallery.Visible = False
                    modifyspan.Visible = False
                    'AddEvaluationFirstRow()
                    FillTrialNo()
                    ' ''ddltype_SelectedIndexChanged(Nothing, Nothing)
                    '*********
                    Fillddrecipie()
                    btnTrialSaveApprove.Visible = False
                    btnTrialDisapprove.Visible = False
                    btnRejNCrtNew.Visible = False
                    divStatusRemark.Visible = False
                    btnTrialSave.Visible = True

                    btnprint.Visible = False
                    btnprintblank.Visible = False
                    If Rid = "0" Then
                        'Fillddrecipie()
                        FillTrialNo()
                        AddEvaluationFirstRow()
                    Else
                        ViewState("Recipe_Id") = Rid
                        FillTrialNo()
                        ddlrecipie_SelectedIndexChanged(Nothing, Nothing)
                        ddlrecipie.Enabled = False
                        ' pnlMain.Visible = True
                        AddEvaluationFirstRow()
                    End If
                Else
                    modifyspan.Visible = True
                    divPopup.Visible = True
                    divSingallery.Visible = True
                    'AddEvaluationFirstRow()
                    ' FillTrialNo()
                    Fillddrecipie()
                    'If Session("LMSUserId") = 1 Then
                    '    btnTrialSaveApprove.Visible = True
                    '    btnTrialDisapprove.Visible = True
                    'Else
                    '    btnTrialSaveApprove.Visible = False
                    '    btnTrialDisapprove.Visible = False
                    'End If
                    btnTrialSave.Visible = True
                    btnprint.Visible = True
                    btnprintblank.Visible = True
                    If Rid = "0" Then
                        'Fillddrecipie()
                        pnlMain.Visible = True
                        DivEvalMethod.Visible = True
                        'AddEvaluationFirstRow()
                        FillDetailTrial()
                        'upddlRecipe.Visible = True
                        'divddlRecipe.Visible = True

                    Else
                        pnlMain.Visible = True
                        DivEvalMethod.Visible = True
                        'Fillddrecipie()
                        AddEvaluationFirstRow()
                        FillDetailTrial()
                    End If

                    If Request.QueryString("chk") = "v" Then
                        DisableViewMode()
                    End If
                End If
                Session("CompareTrial") = Nothing
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        FillSearch()
                    Else
                        FillgvRecipePopUp()
                    End If
                End If
            End If
            'Dim tablecheck1 As Boolean = AreTablesSameForAssignControl()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

#Region "Trial"

    Public Sub FillDetailTrial()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            ViewState("Trial_Id") = MainID
            Dim CatType As String
            If Request.QueryString("Rid") <> Nothing Then
                Rid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Rid")))
            End If
            If Session("LMSUserId") = 1 Then
                btnTrialDisapprove.Visible = True
                btnRejNCrtNew.Visible = True
                btnTrialSaveApprove.Visible = True
                divStatusRemark.Visible = True
            Else
                btnTrialDisapprove.Visible = False
                btnRejNCrtNew.Visible = False
                btnTrialSaveApprove.Visible = False
                divStatusRemark.Visible = False
            End If
            btnTrialSave.Visible = True

            Dim dt As DataSet
            dt = LMSBLL.FillGridByID(MainID, "DisplayTrial")

            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Session("EvalViewMode") = dt.Tables(0)
            Dim drLogin As DataRow
            If dtUser.Rows.Count > 0 Then

                drLogin = dtUser.Rows(0)
                txtAppDisApp.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_StatusRemark"))
                If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Approved")) = "Approved" Then
                    lblapproved.Text = "Approved"
                    btnTrialSaveApprove.Visible = False
                    btnTrialDisapprove.Visible = False
                    btnRejNCrtNew.Visible = False
                    divStatusRemark.Visible = True
                    txtAppDisApp.Enabled = False
                ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Approved")) = "Pending" Then
                    lblapproved.Text = "Pending"
                    If Session("LMSUserId") = 1 Then
                        btnTrialDisapprove.Visible = True
                        btnRejNCrtNew.Visible = True
                        btnTrialSaveApprove.Visible = True
                        divStatusRemark.Visible = True
                    Else
                        btnTrialDisapprove.Visible = False
                        btnRejNCrtNew.Visible = False
                        btnTrialSaveApprove.Visible = False
                        divStatusRemark.Visible = False
                    End If
                Else
                    lblapproved.Text = "Rejected"
                    btnTrialSaveApprove.Visible = False
                    btnTrialDisapprove.Visible = False
                    btnRejNCrtNew.Visible = False
                    divStatusRemark.Visible = True
                    txtAppDisApp.Enabled = False
                End If
                lblTrialNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_No"))
                LMSassigncontrol.UhfTypeCode.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_No"))

                ddltype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Type"))
                CatType = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))
                'CategoryType(CatType)
            Else
                DivEvalMethod.Visible = False
            End If
            gvEvalMethod.DataSource = dt.Tables(0)
            Session("EvalMethodItems") = dt.Tables(0)
            If dt.Tables(0).Rows.Count = 0 Then
                AddEvaluationFirstRow()
            Else
                If CatType = "Bread & Improvers" Then
                    gvEvalMethod.DataSource = dt.Tables(0)
                    gvEvalMethod.DataBind()
                    ViewState("EvalMethodItems") = dt.Tables(0)
                    SetEvalMPreviousData()
                End If
            End If

            Dim dtEval As New DataTable
            dtEval = dt.Tables(1)
            Dim drEval As DataRow

            If dtEval.Rows.Count > 1 Or ddltype.SelectedValue = "Compare" Then
                drEval = dtEval.Rows(0)
                'Dim CatType1 As String = DynamicparcelDataManipulation.FixNullFromDB(drEval("Formulation_ProdCategory"))
                'CategoryType(CatType1)
                CategoryType(CatType)
                ' hfTrId.Value = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_TRId"))
                ' Rid = DynamicparcelDataManipulation.FixNullFromDB(drEval("TR_RecipeId"))

                'ddlrecipie.SelectedValue = Rid
                ''ddlrecipie_SelectedIndexChanged(Nothing, Nothing)
                'ddlrecipie.Enabled = False
                txtremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_Remarks"))
                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("U_FirstName"))
                lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_ModifiedDate")).ToString())

                gvMultiEval.DataSource = dt.Tables(1)
                gvMultiEval.DataBind()
                rp_gallery.DataSource = MultivieBLL.FillDetailbyID("Image", MainID)
                rp_gallery.DataBind()
                Dim totalcount As Integer = rp_gallery.Items.Count
                If totalcount > 0 Then
                    lblRecipePop.Text = "Gallery (" + totalcount.ToString + ")"
                Else
                    'divRecipeHistory.Visible = False
                    lblRecipePop.Text = "No data in gallery"
                End If
            ElseIf dtEval.Rows.Count = 1 Then
                drEval = dtEval.Rows(0)
                txtcentreHeightVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CenterHeightVal"))
                txtcentreHeightcom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CenterHeightCom"))

                txtLeftHeightVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_LeftHeightVal"))
                txtLeftHeightcom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_LeftHeightCom"))

                txtrightHeightVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_RightHeightVal"))
                txtrightHeightcom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_RightHeightCom"))

                txtsweetVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_SweetnessVal"))
                txtsweetcom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_SweetnessCom"))

                txtflavorval.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_FlavourVal"))
                txtflavorcom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_FlavourCom"))

                txtbatterval.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_BatterGravityVal"))
                txtbattercom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_BatterGravityCom"))

                txtVolumeVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_VolumeVal"))
                txtVolumeCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_VolumeCom"))

                txtWeightVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_WeightVal"))
                txtWeightCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_WeightCom"))

                txtDimensionVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_DimensionVal"))
                txtDimensionCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_DimensionCom"))

                txtCrumbTextVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrumbTextureVal"))
                txtCrumbTextCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrumbTextureCom"))

                txtCrumbColVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrumbColorVal"))
                txtCrumbColCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrumbColorCom"))

                txtCrustTextVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrustTextureVal"))
                txtCrustTextCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrustTextureCom"))

                txtCrustColVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrustColorVal"))
                txtCrustColCom.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_CrustColorCom"))

                txtTasteVal.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_Taste"))

                txtremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_Remarks"))
                lblTrialNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_No"))
                LMSassigncontrol.UhfTypeCode.Value = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_No"))
                ' lblapproved.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_Approved"))

                lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("U_FirstName"))
                lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_ModifiedDate")).ToString())
                'If lblapproved.Text = "True" Then
                '    lblapproved.Text = "Approved"
                'ElseIf lblapproved.Text = "False" Then
                '    lblapproved.Text = "Reject"
                'Else
                '    lblapproved.Text = ""
                'End If
                Dim CatType1 As String = DynamicparcelDataManipulation.FixNullFromDB(drEval("Formulation_ProdCategory"))
                CategoryType(CatType1)
                'CategoryType(CatType)
                hfTrId.Value = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_TRId"))
                Rid = DynamicparcelDataManipulation.FixNullFromDB(drEval("TR_RecipeId"))

                ddlrecipie.SelectedValue = Rid
                'ddlrecipie_SelectedIndexChanged(Nothing, Nothing)
                ddlrecipie.Enabled = False

                rp_galleryA1.DataSource = MultivieBLL.FillDetailbyID("Image", MainID)
                rp_galleryA1.DataBind()
                Dim totalcount As Integer = rp_galleryA1.Items.Count
                If totalcount > 0 Then
                    lblImageprod.Text = "Gallery (" + totalcount.ToString + ")"
                Else
                    'divRecipeHistory.Visible = False
                    lblImageprod.Text = "No data in gallery"
                End If
            Else
                AddgvMultiEvalFirstRow()
            End If
            ViewState("MultiEvalItems") = dt.Tables(1)

            ddltype.Enabled = False
            ddlrecipie.Enabled = False
            If Session("LMSUserId") = 1 Then
                If ddltype.SelectedValue = "Single" Then
                    FillTrialSingle()
                    divAccordSingle.Visible = True
                    divAccordCompare.Visible = False
                Else
                    FillTrialCompare()
                    divAccordSingle.Visible = False
                    divAccordCompare.Visible = True
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub DisableViewMode()
        Try
            ddltype.Enabled = False
            ddlrecipie.Enabled = False
            btnShowPop.Visible = False
            gvEvalMethod.Enabled = False
            gvMultiEval.Enabled = False
            txtremark.Enabled = False
            txtremark.CssClass = "form-control"
            divStatusRemark.Visible = False
            btnTrialSaveApprove.Visible = False
            btnTrialDisapprove.Visible = False
            btnRejNCrtNew.Visible = False
            btnTrialSave.Visible = False
            btnsavenew.Visible = False

            MuImageA1.Enabled = False

            txtcentreHeightVal.Enabled = False
            txtcentreHeightcom.Enabled = False

            txtLeftHeightVal.Enabled = False
            txtLeftHeightcom.Enabled = False

            txtrightHeightVal.Enabled = False
            txtrightHeightcom.Enabled = False

            txtsweetVal.Enabled = False
            txtsweetcom.Enabled = False

            txtflavorval.Enabled = False
            txtflavorcom.Enabled = False

            txtbatterval.Enabled = False
            txtbattercom.Enabled = False

            txtVolumeVal.Enabled = False
            txtVolumeCom.Enabled = False

            txtWeightVal.Enabled = False
            txtWeightCom.Enabled = False

            txtDimensionVal.Enabled = False
            txtDimensionCom.Enabled = False

            txtCrumbTextVal.Enabled = False
            txtCrumbTextCom.Enabled = False

            txtCrumbColVal.Enabled = False
            txtCrumbColCom.Enabled = False

            txtCrustTextVal.Enabled = False
            txtCrustTextCom.Enabled = False

            txtCrustColVal.Enabled = False
            txtCrustColCom.Enabled = False

            txtTasteVal.Enabled = False

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "Evaluation Method"
    Private Sub FillTrialNo()
        Try
            Dim TrialNo As String = LMSBLL.TrailNo()
            lblTrialNo.Text = TrialNo
            LMSassigncontrol.UhfTypeCode.Value = TrialNo
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    '' ''Private Sub InsertTrial()
    '' ''    Try
    '' ''        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

    '' ''        If MainID = 0 Then
    '' ''            insert()
    '' ''        Else
    '' ''            update()
    '' ''        End If
    '' ''    Catch ex As Exception
    '' ''        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '' ''        error1 = error1.Replace(Chr(39), "")
    '' ''        ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
    '' ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '' ''    End Try
    '' ''End Sub
    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Try
            Select Case enumOperation
                Case DML_OPERATION.UPDATE

                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    Dim Trial_Id As Integer = MainID

                    LMSBLL.Updatetrial(MainID, Session("LMSUserId"), txtremark.Text)
                    LMSBLL.DeleteTrialChild(MainID)
                    Dim TR_Id As Integer
                    If gvMultiEval.Visible = True Then
                        Dim trid, trid1 As String
                        For i As Integer = 0 To gvMultiEval.Rows.Count - 1
                            Dim lblRecipeID As Label = DirectCast(gvMultiEval.Rows(i).FindControl("lblRecipeID"), Label)

                            'If ddltype.SelectedValue = "Single" Then
                            '    TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)
                            'Else
                            '    TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, lblRecipeID.Text)
                            'End If
                            If ddltype.SelectedValue = "Single" Then
                                TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)

                                trid = TR_Id
                            Else
                                TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, lblRecipeID.Text)
                                trid1 = TR_Id
                                trid = trid + trid1.ToString() + "-"
                            End If

                            Dim txtcentreHtVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtcentreHtVal"), TextBox)
                            Dim txtcentreHtcom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtcentreHtcom"), TextBox)
                            Dim txtLeftHeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtLeftHeightVal"), TextBox)
                            Dim txtLeftHeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtLeftHeightCom"), TextBox)
                            Dim txtrightHeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtrightHeightVal"), TextBox)
                            Dim txtrightHeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtrightHeightCom"), TextBox)
                            Dim txtsweetVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtsweetVal"), TextBox)
                            Dim txtsweetCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtsweetCom"), TextBox)
                            Dim txtflavorVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtflavorVal"), TextBox)
                            Dim txtflavorCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtflavorCom"), TextBox)
                            Dim txtBatterVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtBatterVal"), TextBox)
                            Dim txtBatterCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtBatterCom"), TextBox)
                            Dim txtVolumeVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtVolumeVal"), TextBox)
                            Dim txtVolumeCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtVolumeCom"), TextBox)
                            Dim txtWeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtWeightVal"), TextBox)
                            Dim txtWeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtWeightCom"), TextBox)
                            Dim txtDimensionVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtDimensionVal"), TextBox)
                            Dim txtDimensionCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtDimensionCom"), TextBox)
                            Dim txtCrumbTextVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbTextVal"), TextBox)
                            Dim txtCrumbTextCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbTextCom"), TextBox)
                            Dim txtCrumbColVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbColVal"), TextBox)
                            Dim txtCrumbColCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbColCom"), TextBox)
                            Dim txtCrustTextVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustTextVal"), TextBox)
                            Dim txtCrustTextCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustTextCom"), TextBox)
                            Dim txtCrustColVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustColVal"), TextBox)
                            Dim txtCrustColCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustColCom"), TextBox)
                            Dim txtTasteVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtTasteVal"), TextBox)

                            LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                               txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                               txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, TR_Id, Session("LMSUserId"),
                                               txtcentreHtVal.Text, txtcentreHtcom.Text, txtLeftHeightVal.Text, txtLeftHeightCom.Text, txtrightHeightVal.Text, txtrightHeightCom.Text,
                                               txtsweetVal.Text, txtsweetCom.Text, txtflavorVal.Text, txtflavorCom.Text, txtBatterVal.Text, txtBatterCom.Text)

                            If gvEvalMethod.Visible = True Then
                                Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                                Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                                Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                                Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                                Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                                Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                                Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                                Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                                LMSBLL.InserttrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                                         txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), TR_Id)
                            End If
                        Next
                        addimage(trid)
                    Else
                        TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)
                        LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                               txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                               txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, TR_Id, Session("LMSUserId"),
                                               txtcentreHeightVal.Text, txtcentreHeightcom.Text, txtLeftHeightVal.Text, txtLeftHeightcom.Text, txtrightHeightVal.Text, txtrightHeightcom.Text,
                                               txtsweetVal.Text, txtsweetcom.Text, txtflavorval.Text, txtflavorcom.Text, txtbatterval.Text, txtbattercom.Text)

                        If gvEvalMethod.Visible = True Then
                            For i As Integer = 0 To gvEvalMethod.Rows.Count - 1
                                Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                                Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                                Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                                Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                                Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                                Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                                Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                                Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                                LMSBLL.InserttrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                                         txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), hfTrId.Value)

                            Next
                        End If
                        addimageA1(TR_Id)
                    End If
                    'LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                    '                         txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                    '                         txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, hfTrId.Value, Session("LMSUserId"),
                    '                         txtcentreHeightVal.Text, txtcentreHeightcom.Text, txtLeftHeightVal.Text, txtLeftHeightcom.Text, txtrightHeightVal.Text, txtrightHeightcom.Text,
                    '                         txtsweetVal.Text, txtsweetcom.Text, txtflavorval.Text, txtflavorcom.Text, txtbatterval.Text, txtbattercom.Text)

                    LMSassigncontrol.AddLMSAssignTo(MainID)

                Case DML_OPERATION.INSERT
                    '  Try
                    Dim Trial_Id As Integer
                    If ddltype.SelectedValue = "Single" Then
                        Trial_Id = LMSBLL.Inserttrial(lblTrialNo.Text, Session("LMSUserId"), txtremark.Text, "Single")
                        'ViewState("Trial_Id") = LMSBLL.Inserttrial(lblTrialNo.Text, ViewState("Recipe_Id"), "Single", Session("LMSUserId"), txtremark.Text)
                    Else
                        Trial_Id = LMSBLL.Inserttrial(lblTrialNo.Text, Session("LMSUserId"), txtremark.Text, "Compare")
                    End If
                    Dim TR_Id As Integer
                    'If ddltype.SelectedValue = "Single" Then
                    '    TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)
                    'Else
                    '    TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)
                    'End If

                    If gvMultiEval.Visible = True Then
                        Dim trid, trid1 As String
                        For i As Integer = 0 To gvMultiEval.Rows.Count - 1
                            Dim lblRecipeID As Label = DirectCast(gvMultiEval.Rows(i).FindControl("lblRecipeID"), Label)

                            If ddltype.SelectedValue = "Single" Then
                                TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)

                                trid = TR_Id
                            Else
                                TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, lblRecipeID.Text)
                                trid1 = TR_Id
                                trid = trid + trid1.ToString() + "-"
                            End If

                            Dim txtcentreHtVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtcentreHtVal"), TextBox)
                            Dim txtcentreHtcom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtcentreHtcom"), TextBox)
                            Dim txtLeftHeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtLeftHeightVal"), TextBox)
                            Dim txtLeftHeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtLeftHeightCom"), TextBox)
                            Dim txtrightHeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtrightHeightVal"), TextBox)
                            Dim txtrightHeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtrightHeightCom"), TextBox)
                            Dim txtsweetVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtsweetVal"), TextBox)
                            Dim txtsweetCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtsweetCom"), TextBox)
                            Dim txtflavorVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtflavorVal"), TextBox)
                            Dim txtflavorCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtflavorCom"), TextBox)
                            Dim txtBatterVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtBatterVal"), TextBox)
                            Dim txtBatterCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtBatterCom"), TextBox)
                            Dim txtVolumeVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtVolumeVal"), TextBox)
                            Dim txtVolumeCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtVolumeCom"), TextBox)
                            Dim txtWeightVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtWeightVal"), TextBox)
                            Dim txtWeightCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtWeightCom"), TextBox)
                            Dim txtDimensionVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtDimensionVal"), TextBox)
                            Dim txtDimensionCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtDimensionCom"), TextBox)
                            Dim txtCrumbTextVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbTextVal"), TextBox)
                            Dim txtCrumbTextCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbTextCom"), TextBox)
                            Dim txtCrumbColVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbColVal"), TextBox)
                            Dim txtCrumbColCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrumbColCom"), TextBox)
                            Dim txtCrustTextVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustTextVal"), TextBox)
                            Dim txtCrustTextCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustTextCom"), TextBox)
                            Dim txtCrustColVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustColVal"), TextBox)
                            Dim txtCrustColCom As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtCrustColCom"), TextBox)
                            Dim txtTasteVal As TextBox = DirectCast(gvMultiEval.Rows(i).FindControl("txtTasteVal"), TextBox)
                            Dim MuImage As FileUpload = CType(gvMultiEval.Rows(i).FindControl("MuImage"), FileUpload)

                            LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                               txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                               txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, TR_Id, Session("LMSUserId"),
                                               txtcentreHtVal.Text, txtcentreHtcom.Text, txtLeftHeightVal.Text, txtLeftHeightCom.Text, txtrightHeightVal.Text, txtrightHeightCom.Text,
                                               txtsweetVal.Text, txtsweetCom.Text, txtflavorVal.Text, txtflavorCom.Text, txtBatterVal.Text, txtBatterCom.Text)
                            If gvEvalMethod.Visible = True Then
                                Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                                Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                                Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                                Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                                Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                                Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                                Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                                Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                                LMSBLL.InserttrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                                         txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), TR_Id)
                            End If
                        Next
                        addimage(trid)
                    Else
                        TR_Id = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)
                        LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                               txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                               txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, TR_Id, Session("LMSUserId"),
                                               txtcentreHeightVal.Text, txtcentreHeightcom.Text, txtLeftHeightVal.Text, txtLeftHeightcom.Text, txtrightHeightVal.Text, txtrightHeightcom.Text,
                                               txtsweetVal.Text, txtsweetcom.Text, txtflavorval.Text, txtflavorcom.Text, txtbatterval.Text, txtbattercom.Text)


                        If gvEvalMethod.Visible = True Then
                            For i As Integer = 0 To gvEvalMethod.Rows.Count - 1
                                Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                                Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                                Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                                Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                                Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                                Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                                Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                                Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                                LMSBLL.InserttrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                                         txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), TR_Id)

                            Next
                        End If
                        addimageA1(TR_Id)
                    End If
                    LMSBLL.UpdateStatus(Trial_Id, Session("LMSUserId"), "UpdateFormCompStatus", Session("Audlog_Id")) ''MUBYN***
                    Dim TrialNo As String = LMSBLL.TrialNoForInsert(Trial_Id)
                    LMSassigncontrol.UhfTypeCode.Value = TrialNo
                    LMSassigncontrol.AddLMSAssignTo(Trial_Id)

            End Select

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub addimage(ByVal trid As String)
        For i As Integer = 0 To 0
            Dim MuImage As FileUpload = CType(gvMultiEval.Rows(i).FindControl("MuImage"), FileUpload)
            Dim lblRecipeNo = CType(gvMultiEval.Rows(i).FindControl("lblRecipeNo"), Label)
            If MuImage.HasFiles Then
                Dim _HttpFileCollection As HttpFileCollection = Request.Files
                Dim id As String() = trid.Split("-")
                Dim x As Integer = 0
                For m As Integer = 0 To _HttpFileCollection.Count - 1
                    Dim name As String = _HttpFileCollection.Keys(m)

                    Dim _HttpPostedFile As HttpPostedFile = _HttpFileCollection(m)
                    If _HttpPostedFile.FileName <> "" Then
                        Dim newname As String
                        If m <> 0 Then
                            newname = _HttpFileCollection.Keys(m - 1)
                        Else
                            newname = name
                        End If

                        If name = newname Then
                            x = x
                        Else
                            x = x + 1
                        End If
                        Dim imagename As String = "RC" + id(x).ToString + "-" + m.ToString
                        imagename = Replace(imagename, " ", "-")
                        Dim UploadedFile As [String] = _HttpPostedFile.FileName
                        Dim path1 As String = Server.MapPath("~/img/Trial/")
                        Dim ExtractPos As Integer = UploadedFile.LastIndexOf("/") + 1
                        Dim UploadedFileName As [String] = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos)
                        'File1.PostedFile.SaveAs(Directory & "/AccountImage/" & UploadedFileName)
                        Dim directory1 As String = Server.MapPath("~/img/Trial/" + UploadedFileName)
                        Dim directory2 As String = Server.MapPath("~/img/Trial/")
                        'File1.PostedFile.SaveAs(Directory & "/AccountAward/" & UploadedFileName)
                        Dim fExtension As String = Path.GetExtension(_HttpPostedFile.FileName)
                        _HttpPostedFile.SaveAs(directory1)
                        Dim imageUrl As [String] = UploadedFileName
                        Dim imageHeight As Integer
                        Dim imageWidth As Integer
                        imageUrl = "~/img/Trial/" & imageUrl
                        '  Dim vPath As String = imageUrl.Replace("D:\India2Biz\India2biz Project", "~").Replace("\", "/")
                        Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath(imageUrl))

                        Dim dummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

                        Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)
                        imageWidth = 400
                        imageHeight = 400
                        Dim resizedImage As System.Drawing.Image = FixedSize(fullSizeImg, imageWidth, imageHeight)
                        Dim MyDate As DateTime = DateTime.Now
                        Dim MyString As [String] = imagename + "-" + MyDate.ToString("ddMMyyhhmmss") + "1" + fExtension
                        resizedImage.Save(directory2 + MyString)
                        LargeImagePath = "/img/Trial/" + MyString
                        resizedImage.Dispose()
                        thumbNailImg.Dispose()

                        fullSizeImg.Dispose()

                        Dim info1 As New FileInfo(directory1)
                        If info1.Exists Then
                            System.IO.File.Delete(directory1)
                        End If

                        'Dim namepath As String = Server.MapPath("~/img/Trial/" & Path.GetFileName(Date.Now.Date.ToString("dd-MM-yyyy") + (_HttpPostedFile.FileName).Replace("/", "").Replace("\", "").Replace("?", "")))
                        ' Dim fExtension As String = Path.GetExtension(_HttpPostedFile.FileName)
                        ' Dim namepath1 As String = ("img/Trial/" & Path.GetFileName(Date.Now.Date.ToString("dd-MM-yyyy") + (_HttpPostedFile.FileName).Replace(_HttpPostedFile.FileName, "RC" + id(x).ToString() + m.ToString() + fExtension).Replace("/", "").Replace("\", "").Replace("?", "")))
                        '  If _HttpPostedFile.ContentLength > 0 Then _HttpPostedFile.SaveAs(namepath1)
                        LMSBLL.InsertTrialImage(id(x), LargeImagePath)
                    End If

                Next
            End If
        Next
    End Sub
    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function
    Friend Shared Function FixedSize(imgPhoto As System.Drawing.Image, Width As Integer, Height As Integer) As System.Drawing.Image
        Dim sourceWidth As Integer = Convert.ToInt32(imgPhoto.Width)
        Dim sourceHeight As Integer = Convert.ToInt32(imgPhoto.Height)
        Dim sourceX As Integer = 0
        Dim sourceY As Integer = 0
        Dim destX As Integer = 0
        Dim destY As Integer = 0

        Dim nPercent As Single = 0
        Dim nPercentW As Single = 0
        Dim nPercentH As Single = 0

        nPercentW = (CSng(Width) / CSng(sourceWidth))
        nPercentH = (CSng(Height) / CSng(sourceHeight))
        If (nPercentH < nPercentW) Then
            nPercent = nPercentH
            destX = System.Convert.ToInt16((Width - (sourceWidth * nPercent)) / 2)
        Else

            nPercent = nPercentW
            destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2)
        End If

        Dim destWidth As Integer = CInt(Math.Truncate(sourceWidth * nPercent))
        Dim destHeight As Integer = CInt(Math.Truncate(sourceHeight * nPercent))

        Dim bmPhoto As New Drawing.Bitmap(Width, Height, Drawing.Imaging.PixelFormat.Format24bppRgb)
        '  bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

        Dim grPhoto As Drawing.Graphics = Drawing.Graphics.FromImage(bmPhoto)
        grPhoto.Clear(Drawing.Color.White)
        grPhoto.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

        grPhoto.DrawImage(imgPhoto, 0, 0, Width, Height)

        grPhoto.Dispose()
        Return bmPhoto
    End Function

    Public Sub insert()
        Try
            Dim Trial_Id As Integer
            If ddltype.SelectedValue = "Single" Then
                Trial_Id = LMSBLL.Inserttrial(lblTrialNo.Text, Session("LMSUserId"), txtremark.Text, "Single")
                'ViewState("Trial_Id") = LMSBLL.Inserttrial(lblTrialNo.Text, ViewState("Recipe_Id"), "Single", Session("LMSUserId"), txtremark.Text)
            Else
                Trial_Id = LMSBLL.Inserttrial(lblTrialNo.Text, Session("LMSUserId"), txtremark.Text, "Compare")
            End If

            Dim TR_Id As Integer = LMSBLL.InsertTrialRecipe(Trial_Id, ddlrecipie.SelectedValue)

            LMSBLL.InserttrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                   txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                   txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, ViewState("TR_Id"), Session("LMSUserId"),
                                   txtcentreHeightVal.Text, txtcentreHeightcom.Text, txtLeftHeightVal.Text, txtLeftHeightcom.Text, txtrightHeightVal.Text, txtrightHeightcom.Text,
                                   txtsweetVal.Text, txtsweetcom.Text, txtflavorval.Text, txtflavorcom.Text, txtbatterval.Text, txtbattercom.Text)
            If gvEvalMethod.Visible = True Then
                For i As Integer = 0 To gvEvalMethod.Rows.Count - 1
                    Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                    Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                    Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                    Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                    Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                    Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                    Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                    Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                    LMSBLL.InserttrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                             txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), ViewState("TR_Id"))

                Next
            End If
            LMSassigncontrol.AddLMSAssignTo(TR_Id)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub gvEvaluation_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvEvalMethod.RowCommand
        Try
            Flag = 0
            If e.CommandName = "AddEvalMNewRow" Then
                AddEvalMNewRow()
            ElseIf e.CommandName = "deleteEvalMLink" Then
                SetEvalMPreviousData()
                If ViewState("EvalMethodItems") IsNot Nothing Then
                    Dim dt As DataTable = DirectCast(ViewState("EvalMethodItems"), DataTable)
                    Dim drCurrentRow As DataRow = Nothing
                    Dim rowIndex As Integer = Convert.ToInt32(e.CommandArgument)
                    If dt.Rows.Count > 0 Then
                        dt.Rows.Remove(dt.Rows(rowIndex))
                        drCurrentRow = dt.NewRow()

                        ViewState("EvalMethodItems") = dt
                        Flag = rowIndex

                        gvEvalMethod.DataSource = dt
                        gvEvalMethod.DataBind()

                        If gvEvalMethod.Rows.Count <= 1 Then
                            Dim lnkdelete As LinkButton = DirectCast(gvEvalMethod.Rows(0).FindControl("lnkdelete"), LinkButton)
                            lnkdelete.Visible = False
                        Else
                            For i As Integer = 0 To gvEvalMethod.Rows.Count - 1
                                Dim lnkdelete As LinkButton = DirectCast(gvEvalMethod.Rows(i).FindControl("lnkdelete"), LinkButton)
                                lnkdelete.Visible = True
                            Next
                        End If
                        For i As Integer = 0 To gvEvalMethod.Rows.Count - 2
                            gvEvalMethod.Rows(i).Cells(0).Text = Convert.ToString(i + 1)
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
    Private Sub AddEvaluationFirstRow()
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Recipe_Id", GetType(String)))
            dt.Columns.Add(New DataColumn("Recipe_No", GetType(String)))

            dt.Columns.Add(New DataColumn("TrialMethod_DoughTemperature", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_OnBenchTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_ScaleTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_ScaleWeight", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_InProoferTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_InOvenTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_OutOvenTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_Steam", GetType(String)))
            dt.Columns.Add(New DataColumn("Bulk_fermentation", GetType(String)))
            dt.Columns.Add(New DataColumn("Proofing", GetType(String)))
            dt.Columns.Add(New DataColumn("Baking_Time", GetType(String)))
            Dim dtcomparetrial As DataTable = Session("CompareTrial")
            Dim dtcount As Integer
            If ddltype.SelectedValue = "Compare" Then
                dtcount = dtcomparetrial.Rows.Count
            Else
                dtcount = 1

            End If
            Dim count As Integer = 1
            For i As Integer = 0 To dtcount - 1
                dr = dt.NewRow()
                dr("RowNumber") = count
                strrowcount.Value = dr("RowNumber")
                If ddltype.SelectedValue = "Compare" Then
                    dr("Recipe_Id") = dtcomparetrial.Rows(i)("Recipe_Id")
                    dr("Recipe_No") = dtcomparetrial.Rows(i)("Recipe_No")
                Else
                    dr("Recipe_Id") = String.Empty
                    dr("Recipe_No") = String.Empty
                End If


                dr("TrialMethod_DoughTemperature") = String.Empty
                ' Dim twentyFourHour As String = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & ":" & Now.Second.ToString("00")
                ' txtBenchTime.Text = twentyFourHour.ToString()
                dr("TrialMethod_OnBenchTime") = String.Empty
                dr("TrialMethod_ScaleTime") = String.Empty
                dr("TrialMethod_ScaleWeight") = String.Empty
                dr("TrialMethod_InProoferTime") = String.Empty
                dr("TrialMethod_InOvenTime") = String.Empty
                dr("TrialMethod_OutOvenTime") = String.Empty
                dr("TrialMethod_Steam") = String.Empty
                dr("Bulk_fermentation") = String.Empty
                dr("Proofing") = String.Empty
                dr("Baking_Time") = String.Empty
                count += 1


                dt.Rows.Add(dr)
            Next

            ViewState("EvalMethodItems") = dt

            gvEvalMethod.DataSource = dt
            gvEvalMethod.DataBind()

            SetEvalMPreviousData()
            Dim lnkdelete As LinkButton = DirectCast(gvEvalMethod.Rows(0).FindControl("lnkdelete"), LinkButton)
            If dt.Rows.Count > 1 Then
                lnkdelete.Visible = True
            Else
                lnkdelete.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddEvalMNewRow()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("EvalMethodItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("EvalMethodItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtDoughTemp"), TextBox)
                        Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtBenchTime"), TextBox)
                        Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtScaleTime"), TextBox)
                        Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtScaleWeight"), TextBox)
                        Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtInProoferTime"), TextBox)
                        Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtInOvenTime"), TextBox)
                        Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtOutOvenTime"), TextBox)
                        Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("ddlSteam"), DropDownList)
                        Dim lblBulkferment As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblBulkferment"), Label)
                        Dim lblProofing As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblProofing"), Label)
                        Dim lblBakingTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblBakingTime"), Label)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        drCurrentRow("Bulk_fermentation") = 0
                        drCurrentRow("Proofing") = 0
                        drCurrentRow("Baking_Time") = 0

                        dtCurrentTable.Rows(i - 1)("TrialMethod_DoughTemperature") = txtDoughTemp.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_OnBenchTime") = txtBenchTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_ScaleTime") = txtScaleTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_ScaleWeight") = txtScaleWeight.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_InProoferTime") = txtInProoferTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_InOvenTime") = txtInOvenTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_OutOvenTime") = txtOutOvenTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_Steam") = ddlSteam.SelectedValue
                        dtCurrentTable.Rows(i - 1)("Bulk_fermentation") = lblBulkferment.Text
                        dtCurrentTable.Rows(i - 1)("Proofing") = lblProofing.Text
                        dtCurrentTable.Rows(i - 1)("Baking_Time") = lblBakingTime.Text

                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("EvalMethodItems") = dtCurrentTable
                    gvEvalMethod.DataSource = dtCurrentTable
                    gvEvalMethod.DataBind()
                End If
            End If
            'SetEvaluationPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SetEvalMPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("EvalMethodItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("EvalMethodItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim lblRecipeID As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblRecipeID"), Label)

                        Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtDoughTemp"), TextBox)
                        Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(1).FindControl("txtBenchTime"), TextBox)
                        Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(2).FindControl("txtScaleTime"), TextBox)
                        Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(3).FindControl("txtScaleWeight"), TextBox)
                        Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(4).FindControl("txtInProoferTime"), TextBox)
                        Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(5).FindControl("txtInOvenTime"), TextBox)
                        Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(6).FindControl("txtOutOvenTime"), TextBox)
                        Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(7).FindControl("ddlSteam"), DropDownList)
                        Dim lblBulkferment As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(8).FindControl("lblBulkferment"), Label)
                        Dim lblProofing As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(9).FindControl("lblProofing"), Label)
                        Dim lblBakingTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(10).FindControl("lblBakingTime"), Label)

                        gvEvalMethod.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        dt.Rows(i)("Recipe_Id") = lblRecipeID.Text
                        dt.Rows(i)("TrialMethod_DoughTemperature") = txtDoughTemp.Text
                        dt.Rows(i)("TrialMethod_OnBenchTime") = txtBenchTime.Text
                        dt.Rows(i)("TrialMethod_ScaleTime") = txtScaleTime.Text
                        dt.Rows(i)("TrialMethod_ScaleWeight") = txtScaleWeight.Text
                        dt.Rows(i)("TrialMethod_InProoferTime") = txtInProoferTime.Text
                        dt.Rows(i)("TrialMethod_InOvenTime") = txtInOvenTime.Text
                        dt.Rows(i)("TrialMethod_OutOvenTime") = txtOutOvenTime.Text
                        If ddlSteam.SelectedValue = 1 Then
                            dt.Rows(i)("TrialMethod_Steam") = True
                        Else
                            dt.Rows(i)("TrialMethod_Steam") = False
                        End If

                        'dt.Rows(i)("Bulk_fermentation") = txtBenchTime.Text - txtScaleTime.Text
                        ''dt.Rows(i)("Bulk_fermentation") = Replace(txtBenchTime.Text, "", 0) - Replace(txtScaleTime.Text, "", 0)
                        'dt.Rows(i)("Proofing") = Replace(txtInProoferTime.Text, "", 0) - Replace(txtInOvenTime.Text, "", 0)
                        'dt.Rows(i)("Baking_Time") = Replace(txtInOvenTime.Text, "", 0) - Replace(txtOutOvenTime.Text, "", 0)
                        dt.Rows(i)("Bulk_fermentation") = lblBulkferment.Text
                        dt.Rows(i)("Proofing") = lblProofing.Text
                        dt.Rows(i)("Baking_Time") = lblBakingTime.Text

                        rowIndex += 1

                        txtDoughTemp.Text = dt.Rows(i)("TrialMethod_DoughTemperature").ToString
                        txtBenchTime.Text = dt.Rows(i)("TrialMethod_OnBenchTime").ToString
                        txtScaleTime.Text = dt.Rows(i)("TrialMethod_ScaleTime").ToString
                        txtScaleWeight.Text = dt.Rows(i)("TrialMethod_ScaleWeight").ToString
                        txtInProoferTime.Text = dt.Rows(i)("TrialMethod_InProoferTime").ToString
                        txtInOvenTime.Text = dt.Rows(i)("TrialMethod_InOvenTime").ToString
                        txtOutOvenTime.Text = dt.Rows(i)("TrialMethod_OutOvenTime").ToString
                        ddlSteam.SelectedValue = dt.Rows(i)("TrialMethod_Steam").ToString
                        'lblBulkferment.Text = Replace(txtBenchTime.Text, "", 0) - Replace(txtScaleTime.Text, "", 0)
                        'lblProofing.Text = Replace(txtInProoferTime.Text, "", 0) - Replace(txtInOvenTime.Text, "", 0)
                        'lblBakingTime.Text = Replace(txtInOvenTime.Text, "", 0) - Replace(txtOutOvenTime.Text, "", 0)
                        lblBulkferment.Text = dt.Rows(i)("Bulk_fermentation").ToString
                        lblProofing.Text = dt.Rows(i)("Proofing").ToString
                        lblBakingTime.Text = dt.Rows(i)("Baking_Time").ToString

                        If i < dt.Rows.Count - 1 Then
                            txtDoughTemp.Enabled = False
                        End If

                    Next
                    ViewState("EvalMethodItems") = dt
                    gvEvalMethod.DataSource = dt
                    gvEvalMethod.DataBind()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region
#End Region

    Public Sub Fillddrecipie()
        Try
            Dim ds As DataSet
            If Session("LMSUserRoleID") = 1 Then
                If MainID = 0 Then
                    ds = LMSBLL.DropdownById("FillRecipeForTrailAdmin", Session("LMSUserId"))
                Else
                    ds = LMSBLL.DropdownById("FillRecipeForTrailEditAdmin", Session("LMSUserId"))
                End If
            Else
                If MainID = 0 Then
                    ds = LMSBLL.DropdownById("FillRecipeForTrail", Session("LMSUserId"))
                Else
                    ds = LMSBLL.DropdownById("FillRecipeForTrailEdit", Session("LMSUserId"))
                End If
            End If
            ' '' '' '' '' ds = LMSBLL.DropdownById("FillTrialDD", Session("LMSUserId"))     'commented by MUBYN due changes made in sqlQuery
            ddlrecipie.DataSource = ds.Tables(0)
            ddlrecipie.DataTextField = "Recipe_No"
            ddlrecipie.DataValueField = "Recipe_Id"
            ddlrecipie.DataBind()
            ' ddlrecipie.Items.Insert(0, "Select Recipe")
            ddlrecipie.Items.Insert(0, New ListItem("Select Trial", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CategoryType(catetype As String)
        Try
            If catetype = "Bread & Improvers" Then
                pnlMain.Visible = True
                DivEvalMethod.Visible = True
                If ddltype.SelectedValue = "Single" Then
                    divSingallery.Visible = True
                    tblSingleEval.Visible = True
                    If MainID = 0 Then
                        AddEvaluationFirstRow()
                    End If

                    gvEvalMethod.Columns(2).Visible = False
                    'gvMultiEval.Columns(3).Visible = False
                    '''''''
                    divddlRecipe.Visible = True
                    divChooseFileSingle.Visible = True
                Else
                    divSingallery.Visible = False
                    tblSingleEval.Visible = False
                    'AddgvMultiEvalFirstRow()
                    gvEvalMethod.Columns(2).Visible = True
                    tblCompareEval.Visible = True
                    gvMultiEval.Visible = True
                    gvMultiEval.Columns(3).Visible = True
                    gvMultiEval.Columns(4).Visible = False
                    gvMultiEval.Columns(5).Visible = False
                    gvMultiEval.Columns(6).Visible = False
                    gvMultiEval.Columns(7).Visible = False
                    gvMultiEval.Columns(8).Visible = False
                    gvMultiEval.Columns(9).Visible = False
                    ddlrecipie.SelectedValue = 0
                    ''''''
                    divddlRecipe.Visible = False
                    divChooseFileSingle.Visible = False
                End If
                lbltype.Text = catetype
                lbltype1.Text = catetype
                trc1.Visible = False
                trc2.Visible = False
                trc3.Visible = False
                trc4.Visible = False
                trc5.Visible = False
                trc6.Visible = False
            ElseIf catetype = "Cake & Desserts" Then
                pnlMain.Visible = True
                DivEvalMethod.Visible = False
                If ddltype.SelectedValue = "Single" Then
                    divSingallery.Visible = True
                    tblSingleEval.Visible = True
                    divChooseFileSingle.Visible = True
                    If MainID = 0 Then
                        AddEvaluationFirstRow()
                    End If
                    gvEvalMethod.Columns(2).Visible = False
                    'gvMultiEval.Columns(3).Visible = False
                    '''''''
                    divddlRecipe.Visible = True
                Else
                    divSingallery.Visible = False
                    tblSingleEval.Visible = False
                    'AddgvMultiEvalFirstRow()
                    tblCompareEval.Visible = True
                    gvMultiEval.Columns(3).Visible = True
                    gvMultiEval.Columns(4).Visible = True
                    gvMultiEval.Columns(5).Visible = True
                    gvMultiEval.Columns(6).Visible = True
                    gvMultiEval.Columns(7).Visible = True
                    gvMultiEval.Columns(8).Visible = True
                    gvMultiEval.Columns(9).Visible = True
                    '''''''
                    divddlRecipe.Visible = False
                    divChooseFileSingle.Visible = False
                End If
                lbltype.Text = catetype
                lbltype1.Text = catetype
                trc1.Visible = True
                trc2.Visible = True
                trc3.Visible = True
                trc4.Visible = True
                trc5.Visible = True
                trc6.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlrecipie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlrecipie.SelectedIndexChanged
        Try
            Session("CompareTrial") = Nothing
            ViewState("Recipe_Id") = ddlrecipie.SelectedValue
            Dim dt As DataSet = LMSBLL.DropdownById("getTrialcatagory", ddlrecipie.SelectedValue)
            If dt.Tables(0).Rows.Count = 1 Then
                cattype = dt.Tables(0).Rows(0)(0)

            End If
            CategoryType(cattype)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnFormulationCancel_Click(sender As Object, e As EventArgs) Handles btnFormulationCancel.Click
        Try
            Response.Redirect("Feedback.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnTrialDisapprove_Click(sender As Object, e As EventArgs) Handles btnTrialDisapprove.Click
        Try
            If txtAppDisApp.Text <> "" Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If Page.IsValid Then
                    If MainID = 0 Then
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        SaveProduct(DML_OPERATION.UPDATE)
                    End If
                End If
                UpdateTrialReject()
                Response.Redirect("Feedback.aspx")
                divStatusRemark.Visible = False
                btnTrialSaveApprove.Visible = False
                btnTrialDisapprove.Visible = False
                btnRejNCrtNew.Visible = False
                btnTrialSave.Visible = False
                lblapproved.Text = "Rejected"
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please enter remarks')", True)
                txtAppDisApp.Focus()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnTrialSave_Click(sender As Object, e As EventArgs) Handles btnTrialSave.Click
        Try

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
                If MainID = 0 Then
                    SaveProduct(DML_OPERATION.INSERT)
                ElseIf MainID > 0 Then
                    SaveProduct(DML_OPERATION.UPDATE)
                End If
            End If

            'InsertTrial()
            'Response.Redirect("ModifyTrial.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(ViewState("Trial_Id"))))
            Response.Redirect("Feedback.aspx")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnTrialSaveApprove_Click(sender As Object, e As EventArgs) Handles btnTrialSaveApprove.Click
        Try
            If txtAppDisApp.Text <> "" Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If Page.IsValid Then
                    If MainID = 0 Then
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        SaveProduct(DML_OPERATION.UPDATE)
                    End If
                End If
                'InsertTrial()
                If txtAppDisApp.Text <> "" Then
                    UpdateTrialApprove()
                    Response.Redirect("Feedback.aspx")
                    divStatusRemark.Visible = False
                    btnTrialSaveApprove.Visible = False
                    btnTrialDisapprove.Visible = False
                    btnRejNCrtNew.Visible = False
                    btnTrialSave.Visible = False
                    lblapproved.Text = "Approved"
                Else
                    Dim url As String = "ModifyFeedback.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)) + "&returnurl=y"
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Insert remark for approval.');window.location='" + url + "'", True)
                    ' ''ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Insert remark for approval')", True)
                    txtAppDisApp.Focus()
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please enter remarks')", True)
                txtAppDisApp.Focus()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub UpdateTrialApprove()
        Try
            LMSBLL.UpdateApprove("UpdateTrialApprove", ViewState("Trial_Id"), Session("LMSUserId"), txtAppDisApp.Text)
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Recipe has been approved')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub UpdateTrialReject()
        Try
            LMSBLL.UpdateApprove("UpdateTrialDisApprove", ViewState("Trial_Id"), Session("LMSUserId"), txtAppDisApp.Text)
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Recipe has been rejected')", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Function AreTablesSame() As Boolean
        Dim tbl1 As DataTable = Session("EvalViewMode")
        Dim tbl2 As DataTable
        '----starts
        Dim dtN As New DataTable()
        dtN.Columns.Add("RowNumber", GetType(String))
        dtN.Columns.Add("TrialMethod_DoughTemperature", GetType(String))
        dtN.Columns.Add("TrialMethod_OnBenchTime", GetType(String))
        dtN.Columns.Add("TrialMethod_ScaleTime", GetType(String))
        dtN.Columns.Add("TrialMethod_ScaleWeight", GetType(String))
        dtN.Columns.Add("TrialMethod_InProoferTime", GetType(String))
        dtN.Columns.Add("TrialMethod_InOvenTime", GetType(String))
        dtN.Columns.Add("TrialMethod_OutOvenTime", GetType(String))
        dtN.Columns.Add("TrialMethod_Steam", GetType(String))

        For Each row In gvEvalMethod.Rows
            Dim ltFrom As Literal = DirectCast(row.FindControl("ltFrom"), Literal)
            Dim txtDoughTemp As TextBox = DirectCast(row.FindControl("txtDoughTemp"), TextBox)
            Dim txtBenchTime As TextBox = DirectCast(row.FindControl("txtBenchTime"), TextBox)
            Dim txtScaleTime As TextBox = DirectCast(row.FindControl("txtScaleTime"), TextBox)
            Dim txtScaleWeight As TextBox = DirectCast(row.FindControl("txtScaleWeight"), TextBox)
            Dim txtInProoferTime As TextBox = DirectCast(row.FindControl("txtInProoferTime"), TextBox)
            Dim txtInOvenTime As TextBox = DirectCast(row.FindControl("txtInOvenTime"), TextBox)
            Dim txtOutOvenTime As TextBox = DirectCast(row.FindControl("txtOutOvenTime"), TextBox)
            Dim ddlSteam As DropDownList = DirectCast(row.FindControl("ddlSteam"), DropDownList)
            Dim steam As String
            If ddlSteam.SelectedValue = 1 Then
                steam = "True"
            Else
                steam = "False"
            End If
            dtN.Rows.Add(ltFrom.Text, txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text, txtInOvenTime.Text, txtOutOvenTime.Text, steam)
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
            If Not Equals(tbl1.Rows(i)(6).ToString(), tbl2.Rows(i)(4).ToString()) Then
                'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(7).ToString(), tbl2.Rows(i)(5).ToString()) Then
                'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(8).ToString(), tbl2.Rows(i)(6).ToString()) Then
                'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(9).ToString(), tbl2.Rows(i)(7).ToString()) Then
                'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If
            If Not Equals(tbl1.Rows(i)(10).ToString(), tbl2.Rows(i)(8).ToString()) Then
                'If Not Equals(tbl1.Rows(i)(12).ToString(), tbl2.Rows(i)(5).ToString()) Then
                Return False
            End If

        Next
        Return True
    End Function

    Public Sub update()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            LMSBLL.Updatetrial(MainID, Session("LMSUserId"), txtremark.Text)
            LMSBLL.UpdatetrialEval(txtVolumeVal.Text, txtVolumeCom.Text, txtWeightVal.Text, txtWeightCom.Text, txtDimensionVal.Text, txtDimensionCom.Text, txtCrumbTextVal.Text,
                                   txtCrumbTextCom.Text, txtCrumbColVal.Text, txtCrumbColCom.Text, txtCrustTextVal.Text, txtCrustTextCom.Text,
                                   txtCrustColVal.Text, txtCrustColCom.Text, txtTasteVal.Text, MainID, Session("LMSUserId"),
                                   txtcentreHeightVal.Text, txtcentreHeightcom.Text, txtLeftHeightVal.Text, txtLeftHeightcom.Text, txtrightHeightVal.Text, txtrightHeightcom.Text,
                                   txtsweetVal.Text, txtsweetcom.Text, txtflavorval.Text, txtflavorcom.Text, txtbatterval.Text, txtbattercom.Text)
            If gvEvalMethod.Visible = True Then
                Dim tablecheck As Boolean = AreTablesSame()
                If tablecheck = False Then
                    For i As Integer = 0 To gvEvalMethod.Rows.Count - 1
                        Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtDoughTemp"), TextBox)
                        Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtBenchTime"), TextBox)
                        Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleTime"), TextBox)
                        Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtScaleWeight"), TextBox)
                        Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInProoferTime"), TextBox)
                        Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtInOvenTime"), TextBox)
                        Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(i).FindControl("txtOutOvenTime"), TextBox)
                        Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(i).FindControl("ddlSteam"), DropDownList)

                        LMSBLL.UpdatetrialMethod(txtDoughTemp.Text, txtBenchTime.Text, txtScaleTime.Text, txtScaleWeight.Text, txtInProoferTime.Text,
                                                 txtInOvenTime.Text, txtOutOvenTime.Text, ddlSteam.SelectedValue, "", Session("LMSUserId"), MainID)

                    Next
                End If
            End If
            LMSassigncontrol.AddLMSAssignTo(ViewState("Trial_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddMethodFirstRow()
        Try
            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CenterHeightVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_OnBenchTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_ScaleTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_ScaleWeight", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_InProoferTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_InOvenTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_OutOvenTime", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialMethod_Steam", GetType(String)))
            dt.Columns.Add(New DataColumn("Bulk_fermentation", GetType(String)))
            dt.Columns.Add(New DataColumn("Proofing", GetType(String)))
            dt.Columns.Add(New DataColumn("Baking_Time", GetType(String)))

            dr = dt.NewRow()
            dr("RowNumber") = 1
            strrowcount.Value = dr("RowNumber")

            dr("TrialMethod_DoughTemperature") = String.Empty
            ' Dim twentyFourHour As String = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & ":" & Now.Second.ToString("00")
            ' txtBenchTime.Text = twentyFourHour.ToString()
            dr("TrialMethod_OnBenchTime") = String.Empty ' twentyFourHour.ToString()
            ' String.Empty ' Format(Replace("00:00:00", ".", ""), "00:00:00") ' & """"
            ' String.Empty ' Timer.ReferenceEquals("00:00:00", "00:00:00")
            dr("TrialMethod_ScaleTime") = String.Empty
            dr("TrialMethod_ScaleWeight") = String.Empty
            dr("TrialMethod_InProoferTime") = String.Empty
            dr("TrialMethod_InOvenTime") = String.Empty
            dr("TrialMethod_OutOvenTime") = String.Empty
            dr("TrialMethod_Steam") = String.Empty
            dr("Bulk_fermentation") = String.Empty
            dr("Proofing") = String.Empty
            dr("Baking_Time") = String.Empty

            dt.Rows.Add(dr)
            ViewState("EvalMethodItems") = dt

            gvEvalMethod.DataSource = dt
            gvEvalMethod.DataBind()

            SetEvalMPreviousData()

            Dim lnkdelete As LinkButton = DirectCast(gvEvalMethod.Rows(0).FindControl("lnkdelete"), LinkButton)
            lnkdelete.Visible = False
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub AddMethodNewRow()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("EvalMethodItems") IsNot Nothing Then
                Dim dtCurrentTable As DataTable = DirectCast(ViewState("EvalMethodItems"), DataTable)
                Dim drCurrentRow As DataRow = Nothing
                If dtCurrentTable.Rows.Count > 0 Then
                    For i As Integer = 1 To dtCurrentTable.Rows.Count
                        Dim txtDoughTemp As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtDoughTemp"), TextBox)
                        Dim txtBenchTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtBenchTime"), TextBox)
                        Dim txtScaleTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtScaleTime"), TextBox)
                        Dim txtScaleWeight As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtScaleWeight"), TextBox)
                        Dim txtInProoferTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtInProoferTime"), TextBox)
                        Dim txtInOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtInOvenTime"), TextBox)
                        Dim txtOutOvenTime As TextBox = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtOutOvenTime"), TextBox)
                        Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("ddlSteam"), DropDownList)
                        Dim lblBulkferment As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblBulkferment"), Label)
                        Dim lblProofing As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblProofing"), Label)
                        Dim lblBakingTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblBakingTime"), Label)

                        drCurrentRow = dtCurrentTable.NewRow()
                        drCurrentRow("RowNumber") = i + 1
                        strrowcount.Value = drCurrentRow("RowNumber")
                        drCurrentRow("Bulk_fermentation") = 0
                        drCurrentRow("Proofing") = 0
                        drCurrentRow("Baking_Time") = 0

                        dtCurrentTable.Rows(i - 1)("TrialMethod_DoughTemperature") = txtDoughTemp.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_OnBenchTime") = txtBenchTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_ScaleTime") = txtScaleTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_ScaleWeight") = txtScaleWeight.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_InProoferTime") = txtInProoferTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_InOvenTime") = txtInOvenTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_OutOvenTime") = txtOutOvenTime.Text
                        dtCurrentTable.Rows(i - 1)("TrialMethod_Steam") = ddlSteam.SelectedValue
                        dtCurrentTable.Rows(i - 1)("Bulk_fermentation") = lblBulkferment.Text
                        dtCurrentTable.Rows(i - 1)("Proofing") = lblProofing.Text
                        dtCurrentTable.Rows(i - 1)("Baking_Time") = lblBakingTime.Text

                        rowIndex += 1
                    Next
                    dtCurrentTable.Rows.Add(drCurrentRow)
                    ViewState("EvalMethodItems") = dtCurrentTable
                    gvEvalMethod.DataSource = dtCurrentTable
                    gvEvalMethod.DataBind()
                End If
            End If
            'SetEvaluationPreviousData()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddltype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddltype.SelectedIndexChanged
        Try
            Session("CompareTrial") = Nothing
            If ddltype.SelectedValue = "Single" Then
                divddlRecipe.Visible = True
                pnlMain.Visible = False
                DivEvalMethod.Visible = False
                tblSingleEval.Visible = False
                tblCompareEval.Visible = False
                ddlrecipie.SelectedValue = 0
                btnShowPop.Visible = False
                divChooseFileSingle.Visible = True
            Else
                divddlRecipe.Visible = False
                pnlMain.Visible = False
                DivEvalMethod.Visible = False
                tblSingleEval.Visible = False
                tblCompareEval.Visible = False
                mpe.Show()
                btnShowPop.Visible = True
                ' AddRecipePopUpFirstRow()
                FillgvRecipePopUp()
                divChooseFileSingle.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rbMixType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rbMixType.SelectedIndexChanged
        Try
            mpe.Show()
            FillgvRecipePopUp()
            txtsearch.Text = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnShowPop_Click(sender As Object, e As EventArgs) Handles btnShowPop.Click
        Try
            If ddltype.SelectedValue = "Compare" Then
                mpe.Show()
                ' AddRecipePopUpFirstRow()
                FillgvRecipePopUp()

            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            FillgvRecipePopUp()
            txtsearch.Text = ""
            mpe.Show()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub FillgvRecipePopUp()
        Try
            If Session("CompareTrial") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("CompareTrial"), DataTable)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim a As String = ""
                        strvat.Add(row("Recipe_Id").ToString)
                    Next
                End If
            End If
            If Session("LMSUserRoleID") = 1 Then
                gvRecipePopUp.DataSource = LMSBLL.FillRecipeForPop("FillRecipeForPopAdmin", rbMixType.SelectedValue, Session("LMSUserId"))
            Else
                gvRecipePopUp.DataSource = LMSBLL.FillRecipeForPop("FillRecipeForPop", rbMixType.SelectedValue, Session("LMSUserId"))
            End If
            gvRecipePopUp.DataBind()

            For Each value As String In strvat
                For Each row As GridViewRow In gvRecipePopUp.Rows
                    Dim lblRecipe_Id = DirectCast(row.FindControl("lblRecipe_Id"), Label)
                    If lblRecipe_Id.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnPopAdd_Click(sender As Object, e As EventArgs) Handles btnPopAdd.Click
        Try
            'hfRadioCheck.Value = rbMixType.SelectedValue
            If rbMixType.SelectedValue = "Bread & Improvers" Then
                CategoryType("Bread & Improvers")
            Else
                CategoryType("Cake & Desserts")
            End If

            addproduct()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsaveclose_Click(sender As Object, e As EventArgs) Handles btnsaveclose.Click

    End Sub

    Public Sub FillSearch()
        Try
            If Session("LMSUserRoleID") = 1 Then
                gvRecipePopUp.DataSource = LMSBLL.SearchRecipeForPop("SearchRecipeForPopAdmin", rbMixType.SelectedValue, txtsearch.Text.Trim)
            Else
                gvRecipePopUp.DataSource = LMSBLL.SearchRecipeForPop("SearchRecipeForPop", rbMixType.SelectedValue, txtsearch.Text.Trim)
            End If
            gvRecipePopUp.DataBind()
            mpe.Show()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub addproduct()
        Try
            If hfRadioCheck.Value <> rbMixType.SelectedValue Then
                Session("CompareTrial") = Nothing
            End If
            Dim count As Integer
            If Session("CompareTrial") Is Nothing Then
                count = 0
                Dim dt As New DataTable
                dt.Columns.Add("row", GetType(Integer))
                dt.Columns.Add("Recipe_Id", GetType(Integer))
                dt.Columns.Add("Recipe_No", GetType(String))
                dt.Columns.Add("Formulation_Type", GetType(String))

                For Each row As GridViewRow In gvRecipePopUp.Rows
                    Dim lblRecipe_Id = DirectCast(row.FindControl("lblRecipe_Id"), Label)
                    Dim lblRecipe_No = DirectCast(row.FindControl("lblRecipe_No"), Label)
                    Dim lblFormulation_Type = DirectCast(row.FindControl("lblFormulation_Type"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        dt.Rows.Add(count, lblRecipe_Id.Text, lblRecipe_No.Text, lblFormulation_Type.Text)
                        count = count + 1
                    End If
                Next
                Session("CompareTrial") = dt
            Else
                Dim dt As DataTable = DirectCast(Session("CompareTrial"), DataTable)
                count = dt.Rows.Count
                For Each row As GridViewRow In gvRecipePopUp.Rows
                    Dim lblRecipe_Id = DirectCast(row.FindControl("lblRecipe_Id"), Label)
                    Dim lblRecipe_No = DirectCast(row.FindControl("lblRecipe_No"), Label)
                    Dim lblFormulation_Type = DirectCast(row.FindControl("lblFormulation_Type"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        dt.Rows.Add(count, lblRecipe_Id.Text, lblRecipe_No.Text, lblFormulation_Type.Text)
                        count = count + 1
                    End If
                    ' End If
                Next
                Session("CompareTrial") = dt
            End If
            ' FillMainProduct()
            FillgvRecipePopUp()
            AddEvaluationFirstRow()
            AddgvMultiEvalFirstRow()
            hfRadioCheck.Value = rbMixType.SelectedValue
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub AddgvMultiEvalFirstRow()
        Try

            Dim dt As New DataTable()
            Dim dr As DataRow = Nothing
            dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
            dt.Columns.Add(New DataColumn("Recipe_Id", GetType(String)))
            dt.Columns.Add(New DataColumn("Recipe_No", GetType(String)))

            dt.Columns.Add(New DataColumn("TrialEval_CenterHeightVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CenterHeightCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_LeftHeightVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_LeftHeightCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_RightHeightVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_RightHeightCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_SweetnessVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_SweetnessCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_FlavourVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_FlavourCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_BatterGravityVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_BatterGravityCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_VolumeVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_VolumeCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_WeightVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_WeightCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_DimensionVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_DimensionCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrumbTextureVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrumbTextureCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrumbColorVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrumbColorCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrustTextureVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrustTextureCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrustColorVal", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_CrustColorCom", GetType(String)))
            dt.Columns.Add(New DataColumn("TrialEval_Taste", GetType(String)))
            Dim dtcomparetrial As DataTable = Session("CompareTrial")
            Dim dtcount As Integer
            If ddltype.SelectedValue = "Compare" Then
                dtcount = dtcomparetrial.Rows.Count
            Else
                dtcount = 1

            End If
            Dim count As Integer = 1
            For i As Integer = 0 To dtcount - 1
                dr = dt.NewRow()
                dr("RowNumber") = count
                strrowcount.Value = dr("RowNumber")
                If ddltype.SelectedValue = "Compare" Then
                    dr("Recipe_Id") = dtcomparetrial.Rows(i)("Recipe_Id")
                    dr("Recipe_No") = dtcomparetrial.Rows(i)("Recipe_No")
                Else
                    dr("Recipe_Id") = String.Empty
                    dr("Recipe_No") = String.Empty
                End If


                dr("TrialEval_CenterHeightVal") = String.Empty
                dr("TrialEval_CenterHeightCom") = String.Empty
                dr("TrialEval_LeftHeightVal") = String.Empty
                dr("TrialEval_LeftHeightCom") = String.Empty
                dr("TrialEval_RightHeightVal") = String.Empty
                dr("TrialEval_RightHeightCom") = String.Empty
                dr("TrialEval_SweetnessVal") = String.Empty
                dr("TrialEval_SweetnessCom") = String.Empty
                dr("TrialEval_FlavourVal") = String.Empty
                dr("TrialEval_FlavourCom") = String.Empty
                dr("TrialEval_BatterGravityVal") = String.Empty
                dr("TrialEval_BatterGravityCom") = String.Empty
                dr("TrialEval_VolumeVal") = String.Empty
                dr("TrialEval_VolumeCom") = String.Empty
                dr("TrialEval_WeightVal") = String.Empty
                dr("TrialEval_WeightCom") = String.Empty
                dr("TrialEval_DimensionVal") = String.Empty
                dr("TrialEval_DimensionCom") = String.Empty
                dr("TrialEval_CrumbTextureVal") = String.Empty
                dr("TrialEval_CrumbTextureCom") = String.Empty
                dr("TrialEval_CrumbColorVal") = String.Empty
                dr("TrialEval_CrumbColorCom") = String.Empty
                dr("TrialEval_CrustTextureVal") = String.Empty
                dr("TrialEval_CrustTextureCom") = String.Empty
                dr("TrialEval_CrustColorVal") = String.Empty
                dr("TrialEval_CrustColorCom") = String.Empty
                dr("TrialEval_Taste") = String.Empty

                count += 1

                dt.Rows.Add(dr)
            Next
            ViewState("MultiEvalItems") = dt

            gvMultiEval.DataSource = dt
            gvMultiEval.DataBind()

            SetgvMultiEvalPreviousData()
            'SetEvalMPreviousData()

            Dim lnkdelete As LinkButton = DirectCast(gvMultiEval.Rows(0).FindControl("lnkdelete"), LinkButton)
            If dt.Rows.Count > 1 Then
                lnkdelete.Visible = True
            Else
                lnkdelete.Visible = False
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Private Sub SetgvMultiEvalPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("MultiEvalItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("MultiEvalItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim lblRecipeID As Label = DirectCast(gvMultiEval.Rows(rowIndex).Cells(0).FindControl("lblRecipeID"), Label)
                        Dim lblRecipeNo As Label = DirectCast(gvMultiEval.Rows(rowIndex).Cells(1).FindControl("lblRecipeNo"), Label)

                        Dim txtcentreHtVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(2).FindControl("txtcentreHtVal"), TextBox)
                        Dim txtcentreHtcom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(2).FindControl("txtcentreHtcom"), TextBox)
                        Dim txtLeftHeightVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(3).FindControl("txtLeftHeightVal"), TextBox)
                        Dim txtLeftHeightCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(3).FindControl("txtLeftHeightCom"), TextBox)
                        Dim txtrightHeightVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(4).FindControl("txtrightHeightVal"), TextBox)
                        Dim txtrightHeightCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(4).FindControl("txtrightHeightCom"), TextBox)
                        Dim txtsweetVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(5).FindControl("txtsweetVal"), TextBox)
                        Dim txtsweetCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(5).FindControl("txtsweetCom"), TextBox)
                        Dim txtflavorVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(6).FindControl("txtflavorVal"), TextBox)
                        Dim txtflavorCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(6).FindControl("txtflavorCom"), TextBox)
                        Dim txtBatterVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(7).FindControl("txtBatterVal"), TextBox)
                        Dim txtBatterCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(7).FindControl("txtBatterCom"), TextBox)
                        Dim txtVolumeVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(8).FindControl("txtVolumeVal"), TextBox)
                        Dim txtVolumeCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(8).FindControl("txtVolumeCom"), TextBox)
                        Dim txtWeightVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(9).FindControl("txtWeightVal"), TextBox)
                        Dim txtWeightCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(9).FindControl("txtWeightCom"), TextBox)
                        Dim txtDimensionVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(10).FindControl("txtDimensionVal"), TextBox)
                        Dim txtDimensionCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(10).FindControl("txtDimensionCom"), TextBox)
                        Dim txtCrumbTextVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(11).FindControl("txtCrumbTextVal"), TextBox)
                        Dim txtCrumbTextCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(11).FindControl("txtCrumbTextCom"), TextBox)
                        Dim txtCrumbColVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(12).FindControl("txtCrumbColVal"), TextBox)
                        Dim txtCrumbColCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(12).FindControl("txtCrumbColCom"), TextBox)
                        Dim txtCrustTextVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(13).FindControl("txtCrustTextVal"), TextBox)
                        Dim txtCrustTextCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(13).FindControl("txtCrustTextCom"), TextBox)
                        Dim txtCrustColVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(14).FindControl("txtCrustColVal"), TextBox)
                        Dim txtCrustColCom As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(14).FindControl("txtCrustColCom"), TextBox)
                        Dim txtTasteVal As TextBox = DirectCast(gvMultiEval.Rows(rowIndex).Cells(15).FindControl("txtTasteVal"), TextBox)
                        Dim MuImage As FileUpload = DirectCast(gvMultiEval.Rows(rowIndex).Cells(16).FindControl("MuImage"), FileUpload)

                        gvMultiEval.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

                        dt.Rows(i)("Recipe_No") = lblRecipeNo.Text
                        dt.Rows(i)("TrialEval_CenterHeightVal") = txtcentreHtVal.Text
                        dt.Rows(i)("TrialEval_CenterHeightCom") = txtcentreHtcom.Text
                        dt.Rows(i)("TrialEval_LeftHeightVal") = txtLeftHeightVal.Text
                        dt.Rows(i)("TrialEval_LeftHeightCom") = txtLeftHeightCom.Text
                        dt.Rows(i)("TrialEval_RightHeightVal") = txtrightHeightVal.Text
                        dt.Rows(i)("TrialEval_RightHeightCom") = txtrightHeightCom.Text
                        dt.Rows(i)("TrialEval_SweetnessVal") = txtsweetVal.Text
                        dt.Rows(i)("TrialEval_SweetnessCom") = txtsweetCom.Text
                        dt.Rows(i)("TrialEval_FlavourVal") = txtflavorVal.Text
                        dt.Rows(i)("TrialEval_FlavourCom") = txtflavorCom.Text
                        dt.Rows(i)("TrialEval_BatterGravityVal") = txtBatterVal.Text
                        dt.Rows(i)("TrialEval_BatterGravityCom") = txtBatterCom.Text
                        dt.Rows(i)("TrialEval_VolumeVal") = txtVolumeVal.Text
                        dt.Rows(i)("TrialEval_VolumeCom") = txtVolumeCom.Text
                        dt.Rows(i)("TrialEval_WeightVal") = txtWeightVal.Text
                        dt.Rows(i)("TrialEval_WeightCom") = txtWeightCom.Text
                        dt.Rows(i)("TrialEval_DimensionVal") = txtDimensionVal.Text
                        dt.Rows(i)("TrialEval_DimensionCom") = txtDimensionCom.Text
                        dt.Rows(i)("TrialEval_CrumbTextureVal") = txtCrumbTextVal.Text
                        dt.Rows(i)("TrialEval_CrumbTextureCom") = txtCrumbTextCom.Text
                        dt.Rows(i)("TrialEval_CrumbColorVal") = txtCrumbColVal.Text
                        dt.Rows(i)("TrialEval_CrumbColorCom") = txtCrumbColCom.Text
                        dt.Rows(i)("TrialEval_CrustTextureVal") = txtCrustTextVal.Text
                        dt.Rows(i)("TrialEval_CrustTextureCom") = txtCrustTextCom.Text
                        dt.Rows(i)("TrialEval_CrustColorVal") = txtCrustColVal.Text
                        dt.Rows(i)("TrialEval_CrustColorCom") = txtCrustColCom.Text
                        dt.Rows(i)("TrialEval_Taste") = txtTasteVal.Text

                        rowIndex += 1

                        lblRecipeNo.Text = dt.Rows(i)("Recipe_No").ToString
                        txtcentreHtVal.Text = dt.Rows(i)("TrialEval_CenterHeightVal").ToString
                        txtcentreHtcom.Text = dt.Rows(i)("TrialEval_CenterHeightCom").ToString
                        txtLeftHeightVal.Text = dt.Rows(i)("TrialEval_LeftHeightVal").ToString
                        txtLeftHeightCom.Text = dt.Rows(i)("TrialEval_LeftHeightCom").ToString
                        txtrightHeightVal.Text = dt.Rows(i)("TrialEval_RightHeightVal").ToString
                        txtrightHeightCom.Text = dt.Rows(i)("TrialEval_RightHeightCom").ToString
                        txtsweetVal.Text = dt.Rows(i)("TrialEval_SweetnessVal").ToString
                        txtsweetCom.Text = dt.Rows(i)("TrialEval_SweetnessCom").ToString
                        txtflavorVal.Text = dt.Rows(i)("TrialEval_FlavourVal").ToString
                        txtflavorCom.Text = dt.Rows(i)("TrialEval_FlavourCom").ToString
                        txtBatterVal.Text = dt.Rows(i)("TrialEval_BatterGravityVal").ToString
                        txtBatterCom.Text = dt.Rows(i)("TrialEval_BatterGravityCom").ToString
                        txtVolumeVal.Text = dt.Rows(i)("TrialEval_VolumeVal").ToString
                        txtVolumeCom.Text = dt.Rows(i)("TrialEval_VolumeCom").ToString
                        txtWeightVal.Text = dt.Rows(i)("TrialEval_WeightVal").ToString
                        txtWeightCom.Text = dt.Rows(i)("TrialEval_WeightCom").ToString
                        txtDimensionVal.Text = dt.Rows(i)("TrialEval_DimensionVal").ToString
                        txtDimensionCom.Text = dt.Rows(i)("TrialEval_DimensionCom").ToString
                        txtCrumbTextVal.Text = dt.Rows(i)("TrialEval_CrumbTextureVal").ToString
                        txtCrumbTextCom.Text = dt.Rows(i)("TrialEval_CrumbTextureCom").ToString
                        txtCrumbColVal.Text = dt.Rows(i)("TrialEval_CrumbColorVal").ToString
                        txtCrumbColCom.Text = dt.Rows(i)("TrialEval_CrumbColorCom").ToString
                        txtCrustTextVal.Text = dt.Rows(i)("TrialEval_CrustTextureVal").ToString
                        txtCrustTextCom.Text = dt.Rows(i)("TrialEval_CrustTextureCom").ToString
                        txtCrustColVal.Text = dt.Rows(i)("TrialEval_CrustColorVal").ToString
                        txtCrustColCom.Text = dt.Rows(i)("TrialEval_CrustColorCom").ToString
                        txtTasteVal.Text = dt.Rows(i)("TrialEval_Taste").ToString



                        If i < dt.Rows.Count - 1 Then
                            txtcentreHtVal.Enabled = False
                        End If

                    Next
                    ViewState("MultiEvalItems") = dt
                    gvMultiEval.DataSource = dt
                    gvMultiEval.DataBind()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub gvEvalMethod_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvEvalMethod.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim txtBenchTime As TextBox = DirectCast(e.Row.FindControl("txtBenchTime"), TextBox)
                Dim txtScaleTime As TextBox = DirectCast(e.Row.FindControl("txtScaleTime"), TextBox)
                Dim txtInProoferTime As TextBox = DirectCast(e.Row.FindControl("txtInProoferTime"), TextBox)
                Dim txtInOvenTime As TextBox = DirectCast(e.Row.FindControl("txtInOvenTime"), TextBox)
                Dim txtOutOvenTime As TextBox = DirectCast(e.Row.FindControl("txtOutOvenTime"), TextBox)
                Dim ddlSteam As DropDownList = DirectCast(e.Row.FindControl("ddlSteam"), DropDownList)
                Dim ltSteam As Literal = DirectCast(e.Row.FindControl("ltSteam"), Literal)

                Dim lblBulkferment As Label = DirectCast(e.Row.FindControl("lblBulkferment"), Label)
                Dim lblProofing As Label = DirectCast(e.Row.FindControl("lblProofing"), Label)
                Dim lblBakingTime As Label = DirectCast(e.Row.FindControl("lblBakingTime"), Label)

                If ltSteam.Text = "True" Then
                    ddlSteam.SelectedValue = 1
                Else
                    ddlSteam.SelectedValue = 0
                End If
                If (txtBenchTime.Text <> "" And txtScaleTime.Text <> "") Then
                    lblBulkferment.Text = diffTime(txtBenchTime.Text, txtScaleTime.Text)
                End If


                If (txtInProoferTime.Text <> "" And txtInOvenTime.Text <> "") Then

                    lblProofing.Text = diffTime(txtInProoferTime.Text, txtInOvenTime.Text)
                End If



                If (txtInOvenTime.Text <> "" And txtOutOvenTime.Text <> "") Then
                    lblBakingTime.Text = diffTime(txtInOvenTime.Text, txtOutOvenTime.Text)
                End If




            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Shared Function pad(ByVal num As String) As String
        If num > 9 Then
            Return (num.ToString())
        Else

            Return ("0" + num.ToString())
        End If
    End Function

    Public Shared Function diffTime(ByVal start As String, ByVal ending As String) As String
        Dim s = start.Split(":"), sMin = +s(1) + s(0) * 60, e = ending.Split(":"), eMin = +e(1) + e(0) * 60, diff = eMin - sMin

        If diff < 0 Then
            sMin -= 12 * 60
            diff = eMin - sMin
        End If

        Dim h = Math.Floor(diff / 60), m = diff Mod 60
        Return "" & pad(h) & ":" + pad(m)
    End Function

    Protected Sub btnprint_Click(sender As Object, e As EventArgs) Handles btnprint.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'Response.Redirect("PrintTrial.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)))
            Dim Url As String = "PrintTrial.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID))
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" + Url + "','_blank');", True)
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnprintblank_Click(sender As Object, e As EventArgs) Handles btnprintblank.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'Response.Redirect("PrintTrial.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)) + "&print=b")
            Dim Url As String = "PrintTrial.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID)) + "&print=b"
            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "OpenWindow", "window.open('" + Url + "','_blank');", True)
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub gvMultiEval_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvMultiEval.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim MuImage As FileUpload = DirectCast(e.Row.FindControl("MuImage"), FileUpload)
                If Request.QueryString("chk") = "v" Then
                    MuImage.Enabled = False
                    MuImage.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub rp_galleryA1_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rp_galleryA1.ItemCommand
        If e.CommandName = "Delete" Then
            If deletestatus.Value = "yes" Then
                Dim Imageindex As Integer = Convert.ToInt32(e.CommandArgument)
                Dim dt2 As DataSet = MainBLL.ViewByID(Imageindex, "ImageViewById")
                Dim dtImg As New DataTable
                Dim drProductRow As DataRow
                dtImg = dt2.Tables(0)
                drProductRow = dtImg.Rows(0)
                Dim ImgName As String = DynamicparcelDataManipulation.FixNullFromDB(drProductRow("Img_Path").ToString())
                Dim Faname As String = ImgName
                Dim directory As String = Server.MapPath(Faname)
                File.Delete(directory)
                ''''''''''''''''MainBLL.DeleteSI(Imageindex, Session("UserId"), "ImageDeleteSi")
                Dim ProductID As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("ID")))
                Dim dt As DataSet = MainBLL.ViewByID(ProductID, "ProductByID")
                Dim dtProduct As New DataTable
                Dim dtProduct1 As New DataTable
                dtProduct1 = dt.Tables(1)
                rp_gallery.DataSource = dt.Tables(1)
                rp_gallery.DataBind()
                Dim totalcount As Integer = rp_gallery.Items.Count
                If totalcount > 0 Then
                    lblImageprod.Text = "Gallery (" + totalcount.ToString + ")"
                Else

                    lblImageprod.Text = "No data in Gallery"
                End If

            End If
        End If
    End Sub
    Public Sub addimageA1(ByVal Pid As String)
        '  For i As Integer = 0 To 0
        '  Dim MuImage As FileUpload = CType(gvMultiEval.Rows(i).FindControl("MuImage"), FileUpload)
        '  Dim lblRecipeNo = CType(gvMultiEval.Rows(i).FindControl("lblRecipeNo"), Label)
        If MuImageA1.HasFiles Then
            Dim _HttpFileCollection As HttpFileCollection = Request.Files
            Dim id As String() = Pid.Split("-")
            C3 = C1 + C2 + C3
            Dim x As Integer = 0
            'For m As Integer = 0 To _HttpFileCollection.Count - 1
            For m As Integer = C3 To _HttpFileCollection.Count - 1
                Dim name As String = _HttpFileCollection.Keys(m)

                Dim _HttpPostedFile As HttpPostedFile = _HttpFileCollection(m)
                If _HttpPostedFile.FileName <> "" Then
                    Dim newname As String
                    If m <> 0 Then
                        newname = _HttpFileCollection.Keys(m - 1)
                    Else
                        newname = name
                    End If

                    If name = newname Then
                        x = x
                    Else
                        x = x '+ 1
                    End If
                    Dim imagename As String = "RC" + id(x).ToString + "-" + m.ToString
                    ' ''imagename = Replace(imagename, " ", "-")
                    ' ''Dim imagename As String = txtProductname.Text.Replace("\", "").Replace("/", "").Replace("&", "").Replace(" ", "-").Trim + "-" + ddlpacking.SelectedItem.Text.Replace(" ", "") + "-Prod" + id(x).ToString + "-" + m.ToString
                    'imagename = Replace(imagename, " ", "-")
                    imagename = imagename.Replace("--", "-").Replace("---", "-")
                    Dim UploadedFile As [String] = _HttpPostedFile.FileName
                    Dim path1 As String = Server.MapPath("~/img/Trial/")
                    Dim ExtractPos As Integer = UploadedFile.LastIndexOf("/") + 1
                    Dim UploadedFileName As [String] = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos)
                    'File1.PostedFile.SaveAs(Directory & "/AccountImage/" & UploadedFileName)
                    Dim directory1 As String = Server.MapPath("~/img/Trial/" + UploadedFileName)
                    Dim directory2 As String = Server.MapPath("~/img/Trial/")
                    'File1.PostedFile.SaveAs(Directory & "/AccountAward/" & UploadedFileName)
                    Dim fExtension As String = Path.GetExtension(_HttpPostedFile.FileName)
                    _HttpPostedFile.SaveAs(directory1)
                    Dim imageUrl As [String] = UploadedFileName
                    Dim imageHeight As Integer
                    Dim imageWidth As Integer
                    imageUrl = "~/img/Trial/" & imageUrl
                    '  Dim vPath As String = imageUrl.Replace("D:\India2Biz\India2biz Project", "~").Replace("\", "/")
                    Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(Server.MapPath(imageUrl))

                    Dim dummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

                    Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)
                    imageWidth = 400
                    imageHeight = 400
                    Dim resizedImage As System.Drawing.Image = FixedSize(fullSizeImg, imageWidth, imageHeight)
                    Dim MyDate As DateTime = DateTime.Now
                    Dim MyString As [String] = imagename + "-" + MyDate.ToString("ddMMyyhhmmss") + "1" + fExtension
                    resizedImage.Save(directory2 + MyString)
                    LargeImagePath = "/img/Trial/" + MyString
                    resizedImage.Dispose()
                    thumbNailImg.Dispose()

                    fullSizeImg.Dispose()

                    Dim info1 As New FileInfo(directory1)
                    If info1.Exists Then
                        System.IO.File.Delete(directory1)
                    End If

                    'Dim namepath As String = Server.MapPath("~/images/product/" & Path.GetFileName(Date.Now.Date.ToString("dd-MM-yyyy") + (_HttpPostedFile.FileName).Replace("/", "").Replace("\", "").Replace("?", "")))
                    'Dim fExtension1 As String = Path.GetExtension(_HttpPostedFile.FileName)

                    LMSBLL.InsertTrialImage(id(x), LargeImagePath)
                    ''''ImageBLL.Insert(Pid, LargeImagePath, imagename, Session("UserId"))

                End If

            Next
        End If
        'Next
    End Sub

    Protected Sub btnRejNCrtNew_Click(sender As Object, e As EventArgs) Handles btnRejNCrtNew.Click
        Try
            If txtAppDisApp.Text <> "" Then
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If Page.IsValid Then
                    If MainID = 0 Then
                        SaveProduct(DML_OPERATION.INSERT)
                    ElseIf MainID > 0 Then
                        SaveProduct(DML_OPERATION.UPDATE)
                    End If
                End If
                UpdateTrialReject()
                'Dim antId As Integer = ddlrecipie.SelectedValue
                Dim dsAnt As DataSet = LMSBLL.FillGridByID(MainID, "GetFormAntId")
                'Dim drAnt As DataRow
                'drAnt = dsAnt.Tables(0).Rows(0)
                Dim antId As Integer = DynamicparcelDataManipulation.FixNullFromDB(dsAnt.Tables(0).Rows(0)("Recipe_FormulationId"))
                Response.Redirect("ModifyTrials.aspx?ID=" + HttpUtility.UrlEncode(Security.Encrypt(0)) + "&ant=" + HttpUtility.UrlEncode(Security.Encrypt(antId)) + "&returnurl=y")
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Please enter remarks')", True)
                txtAppDisApp.Focus()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#Region "Accordian"
    Public Sub FillTrialSingle()
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        Dim dsAnt As DataSet = LMSBLL.FillGridByID(ddlrecipie.SelectedValue, "GetFIdFrmRId")
        Dim FormId As Integer = DynamicparcelDataManipulation.FixNullFromDB(dsAnt.Tables(0).Rows(0)("Recipe_FormulationId"))
        rpForm.DataSource = LMSBLL.FillGridByID(FormId, "DisplayFormulation")
        rpForm.DataBind()
        Dim DS As DataSet = DirectCast(rpForm.DataSource, DataSet)
        Dim totalcount As Integer = DS.Tables(0).Rows.Count
        If totalcount > 0 Then
            'lblsamplereq.Text = "Trials (" + totalcount.ToString + ")"
            lblsamplereq.Text = "Trial Details"
        Else
            lblsamplereq.Text = "No Trial Details"
        End If
        ''****
        Dim dsRec As DataSet
        dsRec = LMSBLL.FillGridByID(ddlrecipie.SelectedValue, "DispRecipeIngredients")
        'txtFormTab.Text = DynamicparcelDataManipulation.FixNullFromDB(dsRec.Tables(1).Rows(0)("RecipeIngredient_Value"))
        'dsRec.Tables(1).Rows.Remove(dsRec.Tables(1).Rows(0))
        rpIng.DataSource = dsRec.Tables(1)
        rpIng.DataBind()

        rpProc.DataSource = dsRec.Tables(2)
        rpProc.DataBind()
    End Sub
    Public Sub FillTrialCompare()
        Try
            Dim dsTC As DataSet = LMSBLL.FillGridByID(MainID, "FillTrialWidRId")
            rpRecipe.DataSource = dsTC.Tables(0)
            rpRecipe.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub rpRecipe_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpRecipe.ItemCommand
        Try
            If e.CommandName = "edit" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                'Response.Redirect("LabManagement.aspx?view=FormulationView" + "&id=" + Security.Encrypt(HttpUtility.UrlEncode(index)))
                Response.Redirect("ModifyTrials.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt(index)) + "&returnurl=y")

            ElseIf e.CommandName = "view" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Response.Redirect("ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(index)) + "&returnurl=y")
                'Response.Redirect("Modify_Customer.aspx?chk=v&Customer_Id=" + HttpUtility.UrlEncode(Security.Encrypt(index)))

            ElseIf e.CommandName = "delete" Then
                If deletestatus.Value = "yes" Then
                    Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                    Try
                        LMSBLL.DeleteRecipe(index, Session("LMSUserId"), "DeleteRecipe")
                        FillTrialCompare()
                    Catch ex As Exception
                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error While Updating Status')", True)
                    End Try
                End If

            ElseIf e.CommandName = "Prioritylink" Then
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                LMSBLL.UpdateStatus(index, Session("LMSUserId"), "FCompStatus", Session("Audlog_Id"))
                FillTrialCompare()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
#End Region

End Class

