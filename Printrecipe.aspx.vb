
Partial Class Printrecipe
    Inherits System.Web.UI.Page
    Dim Mainid As Integer
    Dim fid As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If Not IsPostBack Then
            If (Request.QueryString("print") = "b") Then
                divblank.Visible = True
                divfill.Visible = False
                FillDetailRecipe()
            Else
                FillDetailRecipe()
                divblank.Visible = False
                divfill.Visible = True
            End If
        End If

    End Sub
    Public Sub FillDetailRecipe()
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Request.QueryString("Fid") <> Nothing Then
                Fid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Fid")))
            End If
            Dim dt As DataSet
            If Mainid = 0 Then
                dt = LMSBLL.FillGridByID(ViewState("RecipeIDForFill"), "DispRecipeIngredients")
            Else
                dt = LMSBLL.FillGridByID(Mainid, "printrecipe")
            End If
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            If dtUser.Rows.Count > 0 Then

                drLogin = dtUser.Rows(0)
                If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Approved")) = "Approved" Then
                    lblapproved.Text = "Approved"
                ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Approved")) = "Pending" Then
                    lblapproved.Text = "Pending"
                Else
                    lblapproved.Text = "Rejected"
                End If
                'ddlFormulationNo.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
                'ViewState("Formulation_Id") = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_FormulationId"))
                'Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
                'Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
                'If FType = "Product" And ProdID = 0 Then
                '    ddlFormulationType.SelectedValue = 1
                'ElseIf FType = "Competitor" And ProdID = 0 Then
                '    ddlFormulationType.SelectedValue = 2
                'ElseIf FType = "Product" And ProdID <> 0 Then
                '    ddlFormulationType.SelectedValue = 0
                'End If
                lblFormno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                lblFormno.Text = Replace(lblFormno.Text, "FR", "TR")
                lblFormno1.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
                ' ''lblrecno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                ' ''lblrecipeno2.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_No"))
                lblrecno.Text = lblFormno.Text
                lblrecipeno2.Text = lblFormno.Text

                lblpremark.Text = dt.Tables(2).Rows(0)(6)
                lblrremar.Text = dt.Tables(1).Rows(0)(6)
                lblproductcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Code"))
                lblproductcode1.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Product_Code"))
                lblmix.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mixer"))
                lblblade.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Blade"))
                lblMould.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Mould"))
                lbloven.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Recipe_Oven"))
                'lblremark.text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("RecipeIngredient_Remarks"))
            End If

            rping.DataSource = dt.Tables(1)
            'Session("IngredientViewMode") = dt.Tables(1)
            'ViewState("gvIngredientItems") = dt.Tables(1)
            rping.DataBind()
            'SetRecipePreviousData()

            rpprod.DataSource = dt.Tables(2)
            'Session("ProcedureViewMode") = dt.Tables(2)
            'ViewState("gvProcedureItems") = dt.Tables(2)
            rpprod.DataBind()
            'SetProcedurePreviousData()

            'Dim dtProc As New DataTable
            'dtProc = dt.Tables(2)
            'Dim drProc As DataRow
            'If dtProc.Rows.Count > 0 Then
            '    drProc = dtProc.Rows(0)
            '    txtRemarkProc.Text = DynamicparcelDataManipulation.FixNullFromDB(drProc("RecipeProcedure_Remarks"))
            'Else
            '    AddProcedureFirstRow()
            'End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
End Class
