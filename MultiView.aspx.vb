
Partial Class MultiView
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim version As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim totalkg As Double = 0.0
    Dim letters As String = String.Empty
    Dim numbers As String = String.Empty
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("LMSUserRoleID") = 1 Then
        Else

            Response.Redirect("LMSDashboard.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Fillformultaion()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub Fillformultaion()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Not Request.QueryString("Levl") = Nothing Then
                'Dim Levl As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Levl")))
                Dim Levl As String = Request.QueryString("Levl")
                For Each c As Char In Levl

                    If Char.IsLetter(c) Then
                        letters += c
                    End If

                    If Char.IsNumber(c) Then
                        numbers += c
                    End If
                Next

            End If

            If letters = "P" Then

            ElseIf letters = "PR" Then
                MainID = MultivieBLL.getMainID("getformidbyrcp", numbers)
            ElseIf letters = "PT" Then
                MainID = MultivieBLL.getMainID("getformidbytrial", numbers)
            End If
            '  Dim ChildId As Integer = MultivieBLL.getChildIdByQId("getChildIdByQId", MainID)
      
            rptmaidq.DataSource = MultivieBLL.FillDetailbyID("GetformtnHistory", MainID)
            rptmaidq.DataBind()

            version = rptmaidq.Items.Count
            For i As Integer = 0 To rptmaidq.Items.Count - 1
                Dim lblversion As Label = TryCast(rptmaidq.Items(i).FindControl("lblversion"), Label)
                ' For j As Integer = rptmaidq.Items.Count To 0 Step -rptmaidq.Items.Count
                '  Dim lblversion As Label = DirectCast(grditemproduct.Parent.FindControl("lblversion"), Label)
                lblversion.Text = (CDbl(1) + CDbl(version / 100)).ToString("")
                version = version - 1
                'Exit For
                ' Next
            Next
            Dim totalcount As Integer = rptmaidq.Items.Count
            If totalcount > 0 Then
                lblitemdt.Text = "Formulation History (" + totalcount.ToString + ")"
            Else
                lblitemdt.Text = "No Formulation History"
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rptmaidq_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptmaidq.ItemDataBound
        Try

            Dim lblqtn As Label = DirectCast(e.Item.FindControl("lblqtn"), Label)

            Dim grditemproduct As GridView = TryCast(e.Item.FindControl("grditemproduct"), GridView)

            grditemproduct.DataSource = MultivieBLL.Fillinner("Fillform", Convert.ToInt32(lblqtn.Text))
            grditemproduct.DataBind()


            If grditemproduct.Rows.Count > 0 Then
                Dim lttotalamount As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalamount"), Literal)
                Dim lttotalkg As Literal = DirectCast(grditemproduct.FooterRow.FindControl("lttotalkg"), Literal)
                '   Dim lblfreight As Label = DirectCast(grditemproduct.FooterRow.FindControl("lblfreight"), Label)

                Dim ltamount As Literal = TryCast(grditemproduct.FindControl("ltamount"), Literal)
                Dim lblvat As Literal = TryCast(grditemproduct.FindControl("lblvat"), Literal)
                Dim ltkg As Literal = TryCast(grditemproduct.FindControl("ltkg"), Literal)
                '  lblvatinrs.Text = VAT.ToString("N2")
                '  ltamount.Text = Math.Round(Convert.ToDouble(ltamount.Text)).ToString("N2")

                'If String.IsNullOrEmpty(lblfreight.Text) Then
                '    lblfreight.Text = "0.00"
                'End If
                FooterTotalAmount = 0.0
                totalkg = 0.0
                For i As Integer = 0 To grditemproduct.Rows.Count - 1
                    ltamount = DirectCast(grditemproduct.Rows(i).FindControl("ltamount"), Literal)
                    ltkg = DirectCast(grditemproduct.Rows(i).FindControl("ltkg"), Literal)
                    totalkg = totalkg + ltkg.Text
                    FooterTotalAmount = FooterTotalAmount + ltamount.Text
                Next
                lttotalamount.Text = Math.Round(FooterTotalAmount).ToString("N2")
                lttotalkg.Text = Math.Round(totalkg).ToString("N2")



                Dim lblamt As Label = DirectCast(grditemproduct.Parent.FindControl("lblamt"), Label)
                lblamt.Text = "₹ " + lttotalamount.Text
            End If

            ' rep1.DataSource = QuotationBLL.FillQDetailbyID("getQuotationDetailsById", Convert.ToInt32(lblqtn.Text))
            ' rep1.DataBind()

            '  Next

            Dim rptmainRcp As Repeater = TryCast(e.Item.FindControl("rptmainRcp"), Repeater)
            rptmainRcp.DataSource = MultivieBLL.FillDetailbyID("getrecipe", CInt(lblqtn.Text))
            rptmainRcp.DataBind()

            
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub
 


    

    Protected Sub rptmainRcp_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim lblrcpid As Label = DirectCast(e.Item.FindControl("lblrcpid"), Label)

        Dim grditemproduct As GridView = TryCast(e.Item.FindControl("grditemproduct"), GridView)

        grditemrcp.DataSource = MultivieBLL.Fillinner("FillRecp", Convert.ToInt32(lblrcpid.Text))
        grditemrcp.DataBind()
        Dim rptmaintrial As Repeater = TryCast(e.Item.FindControl("rptmaintrial"), Repeater)
        rptmaintrial.DataSource = MultivieBLL.FillDetailbyID("gettrial", CInt(lblrcpid.Text))
        rptmaintrial.DataBind()

    End Sub

    Protected Sub rptmaintrial_ItemDataBound(sender As Object, e As RepeaterItemEventArgs)
        Dim lblTrialid As Label = DirectCast(e.Item.FindControl("lblTrialid"), Label)
        Dim CatType As String
        Dim grditemtrial As GridView = TryCast(e.Item.FindControl("grditemtrial"), GridView)

        Dim dt As DataSet
        dt = LMSBLL.FillGridByID(lblTrialid.Text, "DisplayTrial")

        Dim dtUser As New DataTable
        dtUser = dt.Tables(0)
        Session("EvalViewMode") = dt.Tables(0)
        Dim drLogin As DataRow
        If dtUser.Rows.Count > 0 Then

            drLogin = dtUser.Rows(0)
            
            lblTrialNo.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_No"))
            '   ddltype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Trial_Type"))
            CatType = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))
            'CategoryType(CatType)
        Else
            DivEvalMethod.Visible = False
        End If
        gvEvalMethod.DataSource = dt.Tables(0)
        Session("EvalMethodItems") = dt.Tables(0)
        '  If dt.Tables(0).Rows.Count = 0 Then
        'AddEvaluationFirstRow()
        '  Else
        If CatType = "Bread" Then
            gvEvalMethod.DataSource = dt.Tables(0)
            gvEvalMethod.DataBind()
            ViewState("EvalMethodItems") = dt.Tables(0)
            SetEvalMPreviousData()
        End If
        'End If

        Dim dtEval As New DataTable
        dtEval = dt.Tables(1)
        Dim drEval As DataRow

        If dtEval.Rows.Count > 0 Then
            drEval = dtEval.Rows(0)
            'Dim CatType1 As String = DynamicparcelDataManipulation.FixNullFromDB(drEval("Formulation_ProdCategory"))
            'CategoryType(CatType1)
            CategoryType(CatType)

            gvMultiEval.DataSource = dt.Tables(1)
            gvMultiEval.DataBind()

            ' grditemtrial.DataSource = MultivieBLL.Fillinner("Filltrial", Convert.ToInt32(lblTrialid.Text))
            'grditemtrial.DataBind()
        End If

    End Sub
    'Private Sub AddEvaluationFirstRow()
    '    Try

    '        Dim dt As New DataTable()
    '        Dim dr As DataRow = Nothing
    '        dt.Columns.Add(New DataColumn("RowNumber", GetType(String)))
    '        dt.Columns.Add(New DataColumn("Recipe_Id", GetType(String)))
    '        dt.Columns.Add(New DataColumn("Recipe_No", GetType(String)))

    '        dt.Columns.Add(New DataColumn("TrialMethod_DoughTemperature", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_OnBenchTime", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_ScaleTime", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_ScaleWeight", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_InProoferTime", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_InOvenTime", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_OutOvenTime", GetType(String)))
    '        dt.Columns.Add(New DataColumn("TrialMethod_Steam", GetType(String)))
    '        dt.Columns.Add(New DataColumn("Bulk_fermentation", GetType(String)))
    '        dt.Columns.Add(New DataColumn("Proofing", GetType(String)))
    '        dt.Columns.Add(New DataColumn("Baking_Time", GetType(String)))
    '        Dim dtcomparetrial As DataTable = Session("comparetrial")
    '        Dim dtcount As Integer
    '        ' If ddltype.SelectedValue = "Compare" Then
    '        dtcount = dtcomparetrial.Rows.Count
    '        'Else
    '        '    dtcount = 1

    '        'End If
    '        Dim count As Integer = 1
    '        For i As Integer = 0 To dtcount - 1
    '            dr = dt.NewRow()
    '            dr("RowNumber") = count
    '            strrowcount.Value = dr("RowNumber")
    '            ' If ddltype.SelectedValue = "Compare" Then
    '            dr("Recipe_Id") = dtcomparetrial.Rows(i)("Recipe_Id")
    '            dr("Recipe_No") = dtcomparetrial.Rows(i)("Recipe_No")
    '            'Else
    '            '    dr("Recipe_Id") = String.Empty
    '            '    dr("Recipe_No") = String.Empty
    '            'End If


    '            dr("TrialMethod_DoughTemperature") = String.Empty
    '            ' Dim twentyFourHour As String = Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & ":" & Now.Second.ToString("00")
    '            ' txtBenchTime.Text = twentyFourHour.ToString()
    '            dr("TrialMethod_OnBenchTime") = String.Empty
    '            dr("TrialMethod_ScaleTime") = String.Empty
    '            dr("TrialMethod_ScaleWeight") = String.Empty
    '            dr("TrialMethod_InProoferTime") = String.Empty
    '            dr("TrialMethod_InOvenTime") = String.Empty
    '            dr("TrialMethod_OutOvenTime") = String.Empty
    '            dr("TrialMethod_Steam") = String.Empty
    '            dr("Bulk_fermentation") = String.Empty
    '            dr("Proofing") = String.Empty
    '            dr("Baking_Time") = String.Empty
    '            count += 1


    '            dt.Rows.Add(dr)
    '        Next
    '        ViewState("EvalMethodItems") = dt

    '        gvEvalMethod.DataSource = dt
    '        gvEvalMethod.DataBind()

    '        SetEvalMPreviousData()

    '        Dim lnkdelete As LinkButton = DirectCast(gvEvalMethod.Rows(0).FindControl("lnkdelete"), LinkButton)
    '        lnkdelete.Visible = False
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub
    Private Sub SetEvalMPreviousData()
        Try
            Dim rowIndex As Integer = 0
            If ViewState("EvalMethodItems") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(ViewState("EvalMethodItems"), DataTable)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim lblRecipeID As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("lblRecipeID"), Label)

                        Dim txtDoughTemp As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(0).FindControl("txtDoughTemp"), Label)
                        Dim txtBenchTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(1).FindControl("txtBenchTime"), Label)
                        Dim txtScaleTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(2).FindControl("txtScaleTime"), Label)
                        Dim txtScaleWeight As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(3).FindControl("txtScaleWeight"), Label)
                        Dim txtInProoferTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(4).FindControl("txtInProoferTime"), Label)
                        Dim txtInOvenTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(5).FindControl("txtInOvenTime"), Label)
                        Dim txtOutOvenTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(6).FindControl("txtOutOvenTime"), Label)
                        Dim ddlSteam As DropDownList = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(7).FindControl("ddlSteam"), DropDownList)
                        Dim lblBulkferment As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(8).FindControl("lblBulkferment"), Label)
                        Dim lblProofing As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(9).FindControl("lblProofing"), Label)
                        Dim lblBakingTime As Label = DirectCast(gvEvalMethod.Rows(rowIndex).Cells(10).FindControl("lblBakingTime"), Label)

                        gvEvalMethod.Rows(i).Cells(0).Text = Convert.ToString(i + 1)

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
    Public Sub CategoryType(catetype As String)
        Try
            If catetype = "Bread" Then
                '  pnlMain.Visible = True
                DivEvalMethod.Visible = True
                
                    'AddgvMultiEvalFirstRow()
                    gvEvalMethod.Columns(2).Visible = True

                    gvMultiEval.Visible = True
                    gvMultiEval.Columns(3).Visible = True
                    gvMultiEval.Columns(4).Visible = False
                    gvMultiEval.Columns(5).Visible = False
                    gvMultiEval.Columns(6).Visible = False
                    gvMultiEval.Columns(7).Visible = False
                    gvMultiEval.Columns(8).Visible = False
                    gvMultiEval.Columns(9).Visible = False
                    

                lbltype.Text = catetype
               
            ElseIf catetype = "Cake" Then
                ' pnlMain.Visible = True
                DivEvalMethod.Visible = False
                
                    gvMultiEval.Columns(3).Visible = True
                    gvMultiEval.Columns(4).Visible = True
                    gvMultiEval.Columns(5).Visible = True
                    gvMultiEval.Columns(6).Visible = True
                    gvMultiEval.Columns(7).Visible = True
                    gvMultiEval.Columns(8).Visible = True
                    gvMultiEval.Columns(9).Visible = True
                    '''''''
                     
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

    Protected Sub gvEvalMethod_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvEvalMethod.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim txtBenchTime As Label = DirectCast(e.Row.FindControl("txtBenchTime"), Label)
                Dim txtScaleTime As Label = DirectCast(e.Row.FindControl("txtScaleTime"), Label)
                Dim txtInProoferTime As Label = DirectCast(e.Row.FindControl("txtInProoferTime"), Label)
                Dim txtInOvenTime As Label = DirectCast(e.Row.FindControl("txtInOvenTime"), Label)
                Dim txtOutOvenTime As Label = DirectCast(e.Row.FindControl("txtOutOvenTime"), Label)

                Dim lblBulkferment As Label = DirectCast(e.Row.FindControl("lblBulkferment"), Label)
                Dim lblProofing As Label = DirectCast(e.Row.FindControl("lblProofing"), Label)
                Dim lblBakingTime As Label = DirectCast(e.Row.FindControl("lblBakingTime"), Label)

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
End Class
