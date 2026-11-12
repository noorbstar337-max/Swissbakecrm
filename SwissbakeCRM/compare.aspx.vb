
Partial Class compare
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim version As Double = 0.0
    Dim letters As String = String.Empty
    Dim numbers As String = String.Empty

    Dim FooterTotalAmount As Double = 0.0
    Dim totalkg As Double = 0.0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                'If Session("AccessFor") = "Formulation" Then
                '    Dim rptRaw As Repeater = TryCast(rptmaidq.FindControl("rptRaw"), Repeater)
                '    Dim rptmainRcp As Repeater = TryCast(rptmaidq.FindControl("rptmainRcp"), Repeater)
                '    rptRaw.Visible = True
                '    rptmainRcp.Visible = False
                'ElseIf Session("AccessFor") = "Recipe" Then

                'ElseIf Session("AccessFor") = "Both" Then

                'Else
                '    Response.Redirect("LMSDashboard.aspx")
                'End If

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

            rptmaidq.DataSource = MultivieBLL.FillDetailbyID("GetformtnHistory", MainID)
            '    rptmaidq.DataSource = MultivieBLL.FillDetailbyID("DisplayFormulation", MainID)
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
           

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rptmaidq_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptmaidq.ItemCommand
        Try

            If e.CommandName = "copyfom" Then
                'code here
                Dim lblqtn As Label = DirectCast(e.Item.FindControl("lblqtn"), Label)
                Session("FormulationIDForFill") = lblqtn.Text

                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Now paste it into formulation section')", True)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub rptmainRcp_ItemCommand(source As Object, e As RepeaterCommandEventArgs)
        Try

            If e.CommandName = "copyrecp" Then
                'code here
                Dim lblrcpid As Label = DirectCast(e.Item.FindControl("lblrcpid"), Label)
                Session("RecipeIDForFill") = lblrcpid.Text
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Now paste it into receipe section')", True)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub rptmaidq_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rptmaidq.ItemDataBound
        Try

            Dim lblqtn As Label = DirectCast(e.Item.FindControl("lblqtn"), Label)
            Dim lblProdName As Label = DirectCast(e.Item.FindControl("lblProdName"), Label)
            Dim lttotalamount As Label = DirectCast(e.Item.FindControl("lblTotalCost"), Label)
            Dim lttotalkg As Label = DirectCast(e.Item.FindControl("lblQuantityFoot"), Label)
            Dim lblCostPerKg As Label = DirectCast(e.Item.FindControl("lblCostPerKg"), Label)

            Dim trFormTableHead As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("trFormTableHead"), System.Web.UI.HtmlControls.HtmlTableRow)
            Dim trFormTableBody As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("trFormTableBody"), System.Web.UI.HtmlControls.HtmlTableRow)
            Dim trFormTableFooter1 As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("trFormTableFooter1"), System.Web.UI.HtmlControls.HtmlTableRow)
            Dim trFormTableFooter2 As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("trFormTableFooter2"), System.Web.UI.HtmlControls.HtmlTableRow)
            Dim trFormTableFooter3 As System.Web.UI.HtmlControls.HtmlTableRow = DirectCast(e.Item.FindControl("trFormTableFooter3"), System.Web.UI.HtmlControls.HtmlTableRow)

            Dim grditemproduct As Repeater = TryCast(e.Item.FindControl("rptRaw"), Repeater)

            If Session("LMSUserRoleID") = 1 Then
                lblProdName.Visible = True
            Else
                lblProdName.Visible = True
            End If

            'grditemproduct.DataSource = MultivieBLL.Fillinner("GetformtnHistory", Convert.ToInt32(lblqtn.Text))
            grditemproduct.DataSource = MultivieBLL.Fillinner("DisplayFormulation", Convert.ToInt32(lblqtn.Text))
            grditemproduct.DataBind()


            If grditemproduct.Items.Count > 0 Then

                Dim Costing As Double = 0
                Dim FinalCost As Double = 0
                Dim ltamount As Literal = TryCast(grditemproduct.FindControl("ltcost"), Literal)
                Dim ltRawMID As Literal = TryCast(grditemproduct.FindControl("ltRawMID"), Literal)
                Dim ltqtyper As Literal = TryCast(grditemproduct.FindControl("ltqtyper"), Literal)
                '  Dim lblvat As Literal = TryCast(grditemproduct.FindControl("lblvat"), Literal)
                Dim ltkg As Literal = TryCast(grditemproduct.FindControl("ltqtykg"), Literal)
                FooterTotalAmount = 0.0
                totalkg = 0.0
                For i As Integer = 0 To grditemproduct.Items.Count - 1
                    ltamount = DirectCast(grditemproduct.Items(i).FindControl("ltcost"), Literal)
                    ltRawMID = DirectCast(grditemproduct.Items(i).FindControl("ltRawMID"), Literal)
                    ltqtyper = DirectCast(grditemproduct.Items(i).FindControl("ltqtyper"), Literal)
                    ltkg = DirectCast(grditemproduct.Items(i).FindControl("ltqtykg"), Literal)
                    'Costing = LMSBLL.Costing(ltRawMID.Text)
                    'FinalCost = Costing * (1 * ltqtyper.Text / 100)
                    'ltamount.Text = FinalCost
                    totalkg = totalkg + ltkg.Text
                    FooterTotalAmount = FooterTotalAmount + ltamount.Text
                Next
                lttotalamount.Text = (FooterTotalAmount)
                lttotalkg.Text = (totalkg)
                lblCostPerKg.Text = (FooterTotalAmount / totalkg).ToString("N2")
                'lblCostPerKg.Text = (FooterTotalAmount / totalkg * 1000).ToString("N2")


                Dim lblamt As Label = DirectCast(grditemproduct.Parent.FindControl("lblamt"), Label)
                lblamt.Text = "₹ " + lttotalamount.Text
            End If



            Dim rptmainRcp As Repeater = TryCast(e.Item.FindControl("rptmainRcp"), Repeater)
            rptmainRcp.DataSource = MultivieBLL.FillDetailbyID("getrecipe", CInt(lblqtn.Text))
            rptmainRcp.DataBind()
            If Session("AccessFor") = "Formulation" Then
                'Dim rptRaw As Repeater = TryCast(rptmaidq.FindControl("rptRaw"), Repeater)
                'Dim rptmainRcp As Repeater = TryCast(rptmaidq.FindControl("rptmainRcp"), Repeater)
                grditemproduct.Visible = True
                rptmainRcp.Visible = False
            ElseIf Session("AccessFor") = "Recipe" Then
                trFormTableHead.Visible = False
                trFormTableBody.Visible = False
                trFormTableFooter1.Visible = False
                trFormTableFooter2.Visible = False
                trFormTableFooter3.Visible = False
                grditemproduct.Visible = False
                rptmainRcp.Visible = True
            ElseIf Session("AccessFor") = "Both" Then
                grditemproduct.Visible = True
                rptmainRcp.Visible = True
            Else
                Response.Redirect("LMSDashboard.aspx")
            End If

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

        'Dim grditemproduct As GridView = TryCast(e.Item.FindControl("grditemproduct"), GridView)

        'grditemrcp.DataSource = MultivieBLL.Fillinner("FillRecp", Convert.ToInt32(lblrcpid.Text))
        'grditemrcp.DataBind()
        Dim rptRcpIng As Repeater = TryCast(e.Item.FindControl("rptRcpIng"), Repeater)
        Dim RptProcedure As Repeater = TryCast(e.Item.FindControl("RptProcedure"), Repeater)
        'rptRcpIng.DataSource = MultivieBLL.Fillinner("FillRecp", Convert.ToInt32(lblrcpid.Text)) 'MultivieBLL.FillDetailbyID("gettrial", CInt(lblrcpid.Text))
        'rptRcpIng.DataBind()


        'rptRcpIng.DataSource = MultivieBLL.Fillinner("FillRecp", Convert.ToInt32(lblrcpid.Text)) 'MultivieBLL.FillDetailbyID("gettrial", CInt(lblrcpid.Text))
        'rptRcpIng.DataBind()


        Dim dt As DataSet = LMSBLL.FillGridByID(Convert.ToInt32(lblrcpid.Text), "DispRecipeIngredients")
        rptRcpIng.DataSource = dt.Tables(1)
        rptRcpIng.DataBind()


        RptProcedure.DataSource = dt.Tables(2)
        RptProcedure.DataBind()
        
    End Sub

   
End Class
