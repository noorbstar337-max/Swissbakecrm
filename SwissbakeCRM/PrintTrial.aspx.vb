
Partial Class PrintTrial
    Inherits System.Web.UI.Page
    Dim Mainid As Integer
    Dim Rid As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If Not IsPostBack Then
            If (Request.QueryString("print") = "b") Then
                FillDetailTrial()
                divblank.Visible = True
                divfill.Visible = False
            Else
                FillDetailTrial()
                divblank.Visible = False
                divfill.Visible = True
            End If
        End If

    End Sub
    Public Sub FillDetailTrial()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            'ViewState("Trial_Id") = MainID
            If Request.QueryString("Rid") <> Nothing Then
                Rid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Rid")))
            End If
            Dim dt As DataSet
            'If MainID = 0 Then
            '    dt = LMSBLL.FillGridByID(ViewState("RecipeIDForFill"), "DispRecipeIngredients")
            'Else
           
            dt = LMSBLL.FillGridByID(MainID, "DisplayTrial")
            'End If
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim dtUser1 As New DataTable
            dtUser1 = dt.Tables(1)
            Session("EvalViewMode") = dt.Tables(0)
            Dim drLogin As DataRow
            Dim drLogin1 As DataRow
            If dtUser1.Rows.Count > 0 Then
                drLogin1 = dtUser1.Rows(0)
                lblremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin1("Trial_remarks"))
            End If
            If dtUser.Rows.Count > 0 Then

                drLogin = dtUser.Rows(0)
                If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Approved")) = "Approved" Then
                    lblapproved.Text = "Approved"
                ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Approved")) = "Pending" Then
                    lblapproved.Text = "Pending"
                Else
                    lblapproved.Text = "Rejected"
                End If
                lblTrialNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_No"))
                lblTrialNo2.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_No"))
                lblRecipecode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                lblRecipecode2.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                CategoryType(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory")))
            Else
                DivEvalMethod.Visible = False
                'DivEvalMethod2.Visible = False
            End If
            rpEvalMethod.DataSource = dt.Tables(0)
            rpEvalMethod2.DataSource = dt.Tables(0)
            Session("EvalMethodItems") = dt.Tables(0)
            If dt.Tables(0).Rows.Count = 0 Then
                AddEvaluationFirstRow()
            Else
                rpEvalMethod2.DataBind()

                rpEvalMethod.DataBind()
                ViewState("EvalMethodItems") = dt.Tables(0)

            End If

            Dim dtEval As New DataTable
            dtEval = dt.Tables(1)
            Dim drEval As DataRow

            If dtEval.Rows.Count = 1 Then
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

                lblremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_Remarks"))
                lblTrialNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_No"))
                lblTrialNo2.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_No"))
                'divRecipecode.Visible = True
                'divRecipecode2.Visible = True
                tblSingleEval.Visible = True
                tblSingleEval2.Visible = True
                tblCompareEval.Visible = False
                tblCompareEval2.Visible = False
                ' lblapproved.Text = DynamicparcelDataManipulation.FixNullFromDB(drEval("Trial_Approved"))
                ' CategoryType(DynamicparcelDataManipulation.FixNullFromDB(drEval("Formulation_ProdCategory")))
                ' hfTrId.Value = DynamicparcelDataManipulation.FixNullFromDB(drEval("TrialEval_TRId"))
                ' Rid = DynamicparcelDataManipulation.FixNullFromDB(drEval("TR_RecipeId"))

                'ddlrecipie.SelectedValue = Rid
                'ddlrecipie_SelectedIndexChanged(Nothing, Nothing)
                'ddlrecipie.Enabled = False
            Else
                tblSingleEval.Visible = False
                tblSingleEval2.Visible = False
                tblCompareEval.Visible = True
                tblCompareEval2.Visible = True
                gvMultiEval.DataSource = dt.Tables(1)
                gvMultiEval.DataBind()
                gvMultiEval2.DataSource = dt.Tables(1)
                gvMultiEval2.DataBind()
            End If
            Session("ProcedureViewMode") = dt.Tables(1)
            ViewState("gvProcedureItems") = dt.Tables(1)
            ' gvProcedure.DataBind()
            'SetProcedurePreviousData()

            'Dim dtProc As New DataTable
            'dtProc = dt.Tables(2)
            'Dim drProc As DataRow
            'If dtProc.Rows.Count > 0 Then
            '    drProc = dtProc.Rows(0)


            '    'Else
            '    '    AddProcedureFirstRow()
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
    Public Sub CategoryType(catetype As String)
        Try
            hfCategory.Value = catetype
            If catetype = "Bread & Improvers" Then
                ' pnlMain.Visible = True
                hr1.Visible = True
                hr3.Visible = True
                hr2.Visible = False
                hr4.Visible = False
                DivEvalMethod.Visible = True
                DivEvalMethod2.Visible = True
                gvMultiEval.Visible = True
                '******
                'gvMultiEval.Columns(3).Visible = True
                'gvMultiEval.Columns(4).Visible = False
                'gvMultiEval.Columns(5).Visible = False
                'gvMultiEval.Columns(6).Visible = False
                'gvMultiEval.Columns(7).Visible = False
                'gvMultiEval.Columns(8).Visible = False
                'gvMultiEval.Columns(9).Visible = False

                lbltype.Text = catetype
                lbltype2.Text = catetype
                trc1.Visible = False
                trc2.Visible = False
                trc3.Visible = False
                trc4.Visible = False
                trc5.Visible = False
                trc6.Visible = False
                tr1.Visible = False
                tr2.Visible = False
                tr3.Visible = False
                tr4.Visible = False
                tr5.Visible = False
                tr6.Visible = False
                'If RepeaterItemEventArgs.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'Dim dt As DataTable = ViewState("gvProcedureItems")
                'Dim dt As DataTable = Session("EvalViewMode")
                'For i As Integer = 0 To dt.Rows.Count - 1
                '    'mH1.Visible = False
                '    Dim mE1 As HtmlTableCell = DirectCast(gvMultiEval2.FindControl("mE1"), HtmlTableCell)
                '    mE1.Visible = False
                'Next
                'End If
                'DirectCast(gvMultiEval2.FindControl("mE1"), HtmlTableCell).Visible = False
            ElseIf catetype = "Cake & Desserts" Then
                ' pnlMain.Visible = True
                hr1.Visible = False
                hr3.Visible = False
                hr2.Visible = False
                hr4.Visible = False
                DivEvalMethod.Visible = False
                DivEvalMethod2.Visible = False
                'If ddltype.SelectedValue = "Single" Then
                tblSingleEval.Visible = True
                tblSingleEval2.Visible = True
                If Mainid = 0 Then
                    ' AddEvaluationFirstRow()
                End If
                ' gvEvalMethod.Columns(2).Visible = False
                'gvMultiEval.Columns(3).Visible = False
                '''''''
                'divddlRecipe.Visible = True
                'Else
                tblSingleEval.Visible = False
                tblSingleEval2.Visible = False
                'AddgvMultiEvalFirstRow()
                tblCompareEval.Visible = True
                tblCompareEval2.Visible = True
                '********
                'gvMultiEval.Columns(3).Visible = True
                'gvMultiEval.Columns(4).Visible = True
                'gvMultiEval.Columns(5).Visible = True
                'gvMultiEval.Columns(6).Visible = True
                'gvMultiEval.Columns(7).Visible = True
                'gvMultiEval.Columns(8).Visible = True
                'gvMultiEval.Columns(9).Visible = True
                '''''''
                'divddlRecipe.Visible = False
                'End If
                lbltype.Text = catetype
                lbltype2.Text = catetype
                trc1.Visible = True
                trc2.Visible = True
                trc3.Visible = True
                trc4.Visible = True
                trc5.Visible = True
                trc6.Visible = True
                tr1.Visible = True
                tr2.Visible = True
                tr3.Visible = True
                tr4.Visible = True
                tr5.Visible = True
                tr6.Visible = True
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

    Protected Sub rpEvalMethod_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpEvalMethod.ItemDataBound
        Try
            If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim txtBenchTime As Label = DirectCast(e.Item.FindControl("txtBenchTime"), Label)
                Dim txtScaleTime As Label = DirectCast(e.Item.FindControl("txtScaleTime"), Label)
                Dim txtInProoferTime As Label = DirectCast(e.Item.FindControl("txtInProoferTime"), Label)
                Dim txtInOvenTime As Label = DirectCast(e.Item.FindControl("txtInOvenTime"), Label)
                Dim txtOutOvenTime As Label = DirectCast(e.Item.FindControl("txtOutOvenTime"), Label)
                Dim ddlSteam As Label = DirectCast(e.Item.FindControl("ddlSteam"), Label)
                Dim ltSteam As Label = DirectCast(e.Item.FindControl("ltSteam"), Label)

                Dim lblBulkferment As Label = DirectCast(e.Item.FindControl("lblBulkferment"), Label)
                Dim lblProofing As Label = DirectCast(e.Item.FindControl("lblProofing"), Label)
                Dim lblBakingTime As Label = DirectCast(e.Item.FindControl("lblBakingTime"), Label)

                If ltSteam.Text = "True" Then
                    ltSteam.Text = "Yes"
                Else
                    ltSteam.Text = "No"
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
            'If ddltype.SelectedValue = "Compare" Then
            '    dtcount = dtcomparetrial.Rows.Count
            'Else
            '    dtcount = 1

            'End If
            Dim count As Integer = 1
            For i As Integer = 0 To dtcount - 1
                dr = dt.NewRow()
                dr("RowNumber") = count
                'strrowcount.Value = dr("RowNumber")
                'If ddltype.SelectedValue = "Compare" Then
                dr("Recipe_Id") = dtcomparetrial.Rows(i)("Recipe_Id")
                dr("Recipe_No") = dtcomparetrial.Rows(i)("Recipe_No")
                'Else
                '    dr("Recipe_Id") = String.Empty
                '    dr("Recipe_No") = String.Empty
                'End If


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

            rpEvalMethod2.DataSource = dt
            rpEvalMethod2.DataBind()

            'SetEvalMPreviousData()
            'Dim lnkdelete As LinkButton = DirectCast(rpEvalMethod2.Rows(0).FindControl("lnkdelete"), LinkButton)
            'If dt.Rows.Count > 1 Then
            '    lnkdelete.Visible = True
            'Else
            '    lnkdelete.Visible = False
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub gvMultiEval2_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles gvMultiEval2.ItemDataBound
        Try
            If hfCategory.Value = "Bread & Improvers" Then
                If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
                    Dim mE1 As HtmlTableCell = DirectCast(e.Item.FindControl("mE1"), HtmlTableCell)
                    Dim mE2 As HtmlTableCell = DirectCast(e.Item.FindControl("mE2"), HtmlTableCell)
                    Dim mE3 As HtmlTableCell = DirectCast(e.Item.FindControl("mE3"), HtmlTableCell)
                    Dim mE4 As HtmlTableCell = DirectCast(e.Item.FindControl("mE4"), HtmlTableCell)
                    Dim mE5 As HtmlTableCell = DirectCast(e.Item.FindControl("mE5"), HtmlTableCell)
                    Dim mE6 As HtmlTableCell = DirectCast(e.Item.FindControl("mE6"), HtmlTableCell)
                    ' Dim mH1 As HeaderElement = DirectCast(e.Item.FindControl("mH1"), HeaderElement)
                    'Dim mH1 As HtmlHead = DirectCast(Header.FindControl("mHt"), HtmlHead)
                    ''Dim mH1 = gvMultiEval2.Controls(0).Controls(0).FindControl("ctrlID")
                    'Dim mH2 As HtmlTableCell = DirectCast(e.Item.FindControl("mH2"), HtmlTableCell)
                    'Dim mH3 As HtmlTableCell = DirectCast(e.Item.FindControl("mH3"), HtmlTableCell)
                    'Dim mH4 As HtmlTableCell = DirectCast(e.Item.FindControl("mH4"), HtmlTableCell)
                    'Dim mH5 As HtmlTableCell = DirectCast(e.Item.FindControl("mH5"), HtmlTableCell)
                    'Dim mH6 As HtmlTableCell = DirectCast(e.Item.FindControl("mH6"), HtmlTableCell)

                    mE1.Visible = False
                    mE2.Visible = False
                    mE3.Visible = False
                    mE4.Visible = False
                    mE5.Visible = False
                    mE6.Visible = False

                    mH1.Visible = False
                    mH2.Visible = False
                    mH3.Visible = False
                    mH4.Visible = False
                    mH5.Visible = False
                    mH6.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvMultiEval_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles gvMultiEval.ItemDataBound
        Try
            If hfCategory.Value = "Bread & Improvers" Then
                If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
                    Dim mE1 As HtmlTableCell = DirectCast(e.Item.FindControl("mE1"), HtmlTableCell)
                    Dim mE2 As HtmlTableCell = DirectCast(e.Item.FindControl("mE2"), HtmlTableCell)
                    Dim mE3 As HtmlTableCell = DirectCast(e.Item.FindControl("mE3"), HtmlTableCell)
                    Dim mE4 As HtmlTableCell = DirectCast(e.Item.FindControl("mE4"), HtmlTableCell)
                    Dim mE5 As HtmlTableCell = DirectCast(e.Item.FindControl("mE5"), HtmlTableCell)
                    Dim mE6 As HtmlTableCell = DirectCast(e.Item.FindControl("mE6"), HtmlTableCell)
                    ' Dim mH1 As HeaderElement = DirectCast(e.Item.FindControl("mH1"), HeaderElement)
                    'Dim mH1 As HtmlHead = DirectCast(Header.FindControl("mHt"), HtmlHead)
                    ''Dim mH1 = gvMultiEval2.Controls(0).Controls(0).FindControl("ctrlID")
                    'Dim mH2 As HtmlTableCell = DirectCast(e.Item.FindControl("mH2"), HtmlTableCell)
                    'Dim mH3 As HtmlTableCell = DirectCast(e.Item.FindControl("mH3"), HtmlTableCell)
                    'Dim mH4 As HtmlTableCell = DirectCast(e.Item.FindControl("mH4"), HtmlTableCell)
                    'Dim mH5 As HtmlTableCell = DirectCast(e.Item.FindControl("mH5"), HtmlTableCell)
                    'Dim mH6 As HtmlTableCell = DirectCast(e.Item.FindControl("mH6"), HtmlTableCell)

                    mE1.Visible = False
                    mE2.Visible = False
                    mE3.Visible = False
                    mE4.Visible = False
                    mE5.Visible = False
                    mE6.Visible = False

                    Td1.Visible = False
                    Td2.Visible = False
                    Td3.Visible = False
                    Td4.Visible = False
                    Td5.Visible = False
                    Td6.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
