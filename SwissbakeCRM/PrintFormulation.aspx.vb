
Partial Class PrintFormulation
    Inherits System.Web.UI.Page
    Dim Mainid As Integer
    Dim fid As Integer
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If Not IsPostBack Then
            If (Request.QueryString("print") = "b") Then
                divblank.Visible = True
                divfill.Visible = False
                FillDetailFormulation()
            Else
                FillDetailFormulation()
                divblank.Visible = False
                divfill.Visible = True
            End If
        End If

    End Sub
    Public Sub FillDetailFormulation()
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = LMSBLL.FillGridByID(Mainid, "DisplayFormulation")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            If DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Approved")) = "Approved" Then
                lblapproved.Text = "Approved"
                ' btnFormulationSaveApprove.Visible = False
            ElseIf DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Approved")) = "Pending" Then
                lblapproved.Text = "Pending"
            Else
                lblapproved.Text = "Rejected"
            End If
           
            lblFormulationno.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
            lblFormulationno.Text = Replace(lblFormulationno.Text, "FR", "TR")
            'lblformulationno2.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_No"))
            lblformulationno2.Text = lblFormulationno.Text
            lblformulationqty.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Qty"))
            lblformulationtype.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
            lblmixtype.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdCategory"))
            lblproductcode.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProdName"))
            Dim ProdID As Integer = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_ProductID"))
            Dim FType As String = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Formulation_Type"))
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

            rpformulation.DataSource = dt.Tables(0)
            rpformulation.DataBind()

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub rpformulation_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles rpformulation.ItemDataBound
        If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim ddlRM As DropDownList = CType(e.Item.FindControl("ddlRM"), DropDownList)
            Dim lblname As Label = CType(e.Item.FindControl("lblname"), Label)
            Dim lblpname As Label = CType(e.Item.FindControl("lblpname"), Label)

            Dim ds As New DataSet

            ds = LMSBLL.Dropdown("FillRawMaterial")
            ddlRM.DataSource = ds.Tables(0)
            ddlRM.DataTextField = "Rm_Name"
            ddlRM.DataValueField = "Rm_ID"
            ddlRM.DataBind()
            ddlRM.SelectedValue = lblname.Text
            ddlRM.Enabled = False
            lblpname.Text = ddlRM.SelectedItem.Text
        End If
    End Sub
End Class
