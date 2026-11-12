Imports DynamicparcelEnumerations

Partial Class ModifyTargetCategory
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim strvat As New List(Of String)

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), btnadd, btnadd, "TargetCategory.aspx")
            If Request.QueryString("chk") = "v" Then
                txttargetcategoryname.ReadOnly = True
                btnadd.Visible = False
            Else
                lbltitle1.Text = "Modify Target Category"
                lbltitle2.Text = "Modify Target Category"
                btnadd.Visible = True
            End If
        Else
            DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), btnadd, btnadd, "TargetCategory.aspx")
            If Request.QueryString("chk") = "v" Then
                txttargetcategoryname.ReadOnly = True
                btnadd.Visible = False
            Else
                lbltitle1.Text = "Modify Target Category"
                lbltitle2.Text = "Modify Target Category"
                btnadd.Visible = True
            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = "0" Then
                    lbltitle1.Text = "New Target Category"
                    lbltitle2.Text = "New Target Category"
                    modifyspan.Visible = False
                Else
                    FillDetail()
                    fillProductViewEdit()
                    modifyspan.Visible = True
                End If
            Catch ex As Exception
                'Response.Redirect("index.aspx")
            End Try
        End If
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        ElseIf MainID > 0 Then
            SaveProduct(DML_OPERATION.UPDATE)
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    TargetCategoryBLL.Update(txttargetcategoryname.Text.Trim, Session("UserId"), MainID)
                    TargetCategoryBLL.TCProductDeleteSi(MainID)
                    Dim sb As New StringBuilder
                    sb.Append("<root>")
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)

                        sb.Append("<row TCP_TCID='" & MainID & "' TCP_ProductID='" & ltproductid.Text & "' />")
                    Next
                    sb.Append("</root>")
                    TargetCategoryBLL.XMLInsert(sb.ToString)
                    Response.Redirect("TargetCategory.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTargetCategory", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    MainID = TargetCategoryBLL.Insert(txttargetcategoryname.Text.Trim, Session("UserId"))

                    Dim sb As New StringBuilder
                    sb.Append("<root>")
                    For i As Integer = 0 To grditemproduct.Rows.Count - 1
                        Dim ltproductid As Label = DirectCast(grditemproduct.Rows(i).FindControl("ltproductid"), Label)
                       
                        sb.Append("<row TCP_TCID='" & MainID & "' TCP_ProductID='" & ltproductid.Text & "' />")
                    Next
                    sb.Append("</root>")
                    TargetCategoryBLL.XMLInsert(sb.ToString)


                    Response.Redirect("TargetCategory.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyTargetCategory", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "TargetCategoryViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txttargetcategoryname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("TC_Name").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_FirstName").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("TC_ModifiedDate").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "FillDetail", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillProductViewEdit()
        Try
            Dim dtbl As New DataTable
            dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
            dtbl.Columns.Add("Product_Id", GetType(Integer))
            dtbl.Columns.Add("Product_Name", GetType(String))
            dtbl.Columns.Add("Product_Code", GetType(String))
            dtbl.Columns.Add("Packing_Packing", GetType(String))
            dtbl.Columns.Add("PrdCategory_Name", GetType(String))
            dtbl = ProductBLL.TargetCategoryProductView(MainID).Tables(0)
            Session("OrderProduct") = dtbl
            grditemproduct.DataSource = dtbl
            grditemproduct.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "fillProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub btnopen_Click(sender As Object, e As EventArgs) Handles btnopen.Click
        Try
            mpe.Show()
            FillProductGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnopen_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillProductGrid()
        Try

            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    For Each row As DataRow In dt.Rows
                        Dim a As String = ""
                        strvat.Add(row("Product_Id").ToString)

                    Next
                End If
            End If

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            GridView1.DataSource = ProductBLL.TargetCategoryProductADD(MainID)
            GridView1.DataBind()

            For Each value As String In strvat
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    If lblproductId.Text = value Then
                        row.Visible = False
                    End If
                Next
            Next
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "FillProductGrid", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dtbl As New DataTable
                dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
                dtbl.Columns.Add("Product_Id", GetType(Integer))
                dtbl.Columns.Add("Product_Name", GetType(String))
                dtbl.Columns.Add("Product_Code", GetType(String))
                dtbl.Columns.Add("Packing_Packing", GetType(String))
                dtbl.Columns.Add("PrdCategory_Name", GetType(String))
                Dim myrow As DataRow
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
                    Dim lblCategory = DirectCast(row.FindControl("lblCategory"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Product_Id") = lblproductId.Text
                        myrow("Product_Name") = lblname.Text
                        myrow("Product_Code") = lblcode.Text
                        myrow("Packing_Packing") = lblunit.Text
                        myrow("PrdCategory_Name") = lblCategory.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            Else
                Dim myrow As DataRow
                Dim dtbl As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                count = dtbl.Rows.Count
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
                    Dim lblCategory = DirectCast(row.FindControl("lblCategory"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Product_Id") = lblproductId.Text
                        myrow("Product_Name") = lblname.Text
                        myrow("Product_Code") = lblcode.Text
                        myrow("Packing_Packing") = lblunit.Text
                        myrow("PrdCategory_Name") = lblCategory.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            End If
            FillMainProduct()
            FillProductGrid()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillMainProduct()
        Try
            If Session("OrderProduct") IsNot Nothing Then
                Dim dt As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count > 0 Then
                    grditemproduct.DataSource = Session("OrderProduct")
                    grditemproduct.DataBind()
                Else
                    grditemproduct.DataSource = Nothing
                    grditemproduct.DataBind()
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "FillMainProduct", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsaveclose_Click(sender As Object, e As EventArgs) Handles btnsaveclose.Click
        Try
            Dim count As Integer
            If Session("OrderProduct") Is Nothing Then
                count = 0
                Dim dtbl As New DataTable
                dtbl.Columns.Add("ItemDt_ID", GetType(Integer))
                dtbl.Columns.Add("Product_Id", GetType(Integer))
                dtbl.Columns.Add("Product_Name", GetType(String))
                dtbl.Columns.Add("Product_Code", GetType(String))
                dtbl.Columns.Add("Packing_Packing", GetType(String))
                dtbl.Columns.Add("PrdCategory_Name", GetType(String))
                Dim myrow As DataRow
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
                    Dim lblCategory = DirectCast(row.FindControl("lblCategory"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Product_Id") = lblproductId.Text
                        myrow("Product_Name") = lblname.Text
                        myrow("Product_Code") = lblcode.Text
                        myrow("Packing_Packing") = lblunit.Text
                        myrow("PrdCategory_Name") = lblCategory.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            Else
                Dim dtbl As DataTable = DirectCast(Session("OrderProduct"), DataTable)
                Dim myrow As DataRow
                count = dtbl.Rows.Count
                For Each row As GridViewRow In GridView1.Rows
                    Dim lblproductId = DirectCast(row.FindControl("lblproductId"), Label)
                    Dim lblname = DirectCast(row.FindControl("lblname"), Label)
                    Dim lblcode = DirectCast(row.FindControl("lblcode"), Label)
                    Dim lblunit = DirectCast(row.FindControl("lblunit"), Label)
                    Dim lblCategory = DirectCast(row.FindControl("lblCategory"), Label)
                    Dim ckselect = DirectCast(row.FindControl("ckselect"), CheckBox)
                    If ckselect.Checked = True Then
                        myrow = dtbl.NewRow()
                        myrow("ItemDt_ID") = count
                        myrow("Product_Id") = lblproductId.Text
                        myrow("Product_Name") = lblname.Text
                        myrow("Product_Code") = lblcode.Text
                        myrow("Packing_Packing") = lblunit.Text
                        myrow("PrdCategory_Name") = lblCategory.Text
                        ' dtbl.Rows.Add(count, lblproductId.Text, lblname.Text, lblcode.Text, lblunit.Text, lblCategory.Text)
                        dtbl.Rows.Add(myrow)
                        count = count + 1
                    End If
                Next
                Session("OrderProduct") = dtbl
            End If
            FillMainProduct()
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyTargetCategory", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grditemproduct.RowCommand
        If e.CommandName = "deletelink" Then
            Try
                Dim btn As LinkButton = TryCast(e.CommandSource, LinkButton)
                Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
                Dim ltitemid As Label = TryCast(row.FindControl("ltitemid"), Label)
                Dim dt As DataTable
                dt = DirectCast(Session("OrderProduct"), DataTable)
                If dt.Rows.Count >= 0 Then
                    For Each rows As DataRow In dt.Rows
                        Dim a As Integer
                        If rows("ItemDt_ID").ToString = ltitemid.Text Then
                            a = CDbl(rows("ItemDt_ID").ToString)
                            dt.Rows.Remove(rows)
                            Session("OrderProduct") = dt
                            FillMainProduct()
                            Exit For
                        End If
                    Next
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyTargetCategory", "deletelink", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
       
        End If
    End Sub
End Class
