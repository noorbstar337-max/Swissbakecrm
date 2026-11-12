

'Imports System.Data
'Imports System.Data.SqlClient
'Imports System.Configuration
'Partial Class FreeSample
'    Inherits System.Web.UI.Page


'    Private ReadOnly conString As String =
'        ConfigurationManager.ConnectionStrings("connectionString").ConnectionString


'    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

'        If Not IsPostBack Then

'            LoadProducts()

'            LoadFreeSamples()

'        End If

'    End Sub


'    '=========================================================
'    ' LOAD PRODUCT DROPDOWN
'    '=========================================================

'    Private Sub LoadProducts()

'        Using con As New SqlConnection(conString)

'            Dim query As String = ""

'            query &= "SELECT Product_Id, Product_Name, Product_Code,Product_Rate "
'            query &= "FROM tblProduct "
'            query &= "WHERE Product_Status = @Status "
'            query &= "ORDER BY Product_Name"

'            Using cmd As New SqlCommand(query, con)

'                cmd.Parameters.AddWithValue("@Status", "Active")

'                con.Open()

'                Using dr As SqlDataReader = cmd.ExecuteReader()

'                    ddlProduct.DataSource = dr
'                    ddlProduct.DataTextField = "Product_Name"
'                    ddlProduct.DataValueField = "Product_Id"
'                    ddlProduct.DataBind()

'                End Using

'            End Using

'        End Using

'        ddlProduct.Items.Insert(0,
'        New ListItem("-- Select Product --", "0"))

'    End Sub

'    '=========================================================
'    ' LOAD FREE SAMPLE GRID
'    '=========================================================
'    Private Sub LoadFreeSamples()

'        Using con As New SqlConnection(conString)

'            Dim query As String = ""

'            query &= "SELECT "
'            query &= "FS.FreeSample_Id, "
'            query &= "FS.FreeSample_ProductId, "
'            query &= "P.Product_Name, "
'            query &= "P.Product_Code, "
'            query &= "ISNULL(FS.FreeSample_Amount, P.Product_Rate) AS FreeSample_Amount "
'            query &= "FROM tblFreeSample FS "
'            query &= "INNER JOIN tblProduct P "
'            query &= "ON P.Product_Id = FS.FreeSample_ProductId "
'            query &= "ORDER BY FS.FreeSample_Id DESC"

'            Using cmd As New SqlCommand(query, con)

'                Dim dt As New DataTable()

'                Using da As New SqlDataAdapter(cmd)
'                    da.Fill(dt)
'                End Using

'                gvFreeSample.DataSource = dt
'                gvFreeSample.DataBind()

'            End Using

'        End Using

'    End Sub

'    '=========================================================
'    ' ADD FREE SAMPLE
'    '=========================================================

'    Protected Sub btnAddSample_Click(sender As Object,
'                                      e As EventArgs)

'        lblMessage.Text = ""

'        Dim productId As Integer =
'            Convert.ToInt32(ddlProduct.SelectedValue)

'        If productId = 0 Then

'            lblMessage.Text = "Please select a product."

'            Return

'        End If


'        Using con As New SqlConnection(conString)

'            'Prevent duplicate product

'            Dim checkQuery As String = ""

'            checkQuery &= "SELECT COUNT(*) "
'            checkQuery &= "FROM tblFreeSample "
'            checkQuery &= "WHERE FreeSample_ProductId = @ProductId"

'            Using checkCmd As New SqlCommand(checkQuery, con)

'                checkCmd.Parameters.AddWithValue(
'                    "@ProductId",
'                    productId)

'                con.Open()

'                Dim count As Integer =
'                    Convert.ToInt32(checkCmd.ExecuteScalar())

'                If count > 0 Then

'                    LoadFreeSamples()
'                    lblMessage.Text =
'                        "This product is already added."
'                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "hideDuplicateMsg", "hideMessage();", True)

'                    Return

'                End If

'            End Using


'            'Insert product

'            Dim insertQuery As String = ""

'            insertQuery &= "INSERT INTO tblFreeSample "
'            insertQuery &= "(FreeSample_ProductId, "
'            insertQuery &= "FreeSample_CreatedBy, "
'            insertQuery &= "FreeSample_CreatedDate) "
'            insertQuery &= "VALUES "
'            insertQuery &= "(@ProductId, @CreatedBy, GETDATE())"


'            Using cmd As New SqlCommand(insertQuery, con)

'                cmd.Parameters.AddWithValue(
'                    "@ProductId",
'                    productId)

'                cmd.Parameters.AddWithValue(
'                    "@CreatedBy",
'                    GetUserId())

'                cmd.ExecuteNonQuery()

'            End Using

'        End Using


'        ddlProduct.SelectedValue = "0"

'        LoadFreeSamples()

'        lblMessage.Text =
'            "Free sample added successfully."
'        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "hideInsertMsg", "hideMessage();", True)
'    End Sub


'    '=========================================================
'    ' DELETE FREE SAMPLE
'    '=========================================================

'    'Protected Sub gvFreeSample_RowCommand(
'    '    sender As Object,
'    '    e As GridViewCommandEventArgs)

'    '    If e.CommandName = "DeleteSample" Then

'    '        Dim freeSampleId As Integer =
'    '            Convert.ToInt32(e.CommandArgument)

'    '        DeleteFreeSample(freeSampleId)

'    '        LoadFreeSamples()

'    '    End If

'    'End Sub

'    Protected Sub gvFreeSample_RowCommand(
'    sender As Object,
'    e As GridViewCommandEventArgs)

'        If e.CommandName = "UpdateAmount" Then

'            Dim freeSampleId As Integer =
'            Convert.ToInt32(e.CommandArgument)

'            Dim row As GridViewRow =
'            CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)

'            Dim txtAmount As TextBox =
'            CType(row.FindControl("txtAmount"), TextBox)

'            Dim amount As Decimal

'            If Not Decimal.TryParse(txtAmount.Text, amount) OrElse amount < 0 Then

'                lblMessage.Text = "Please enter a valid amount."
'                Return

'            End If

'            Using con As New SqlConnection(conString)

'                Dim query As String =
'                "UPDATE tblFreeSample " &
'                "SET FreeSample_Amount = @Amount " &
'                "WHERE FreeSample_Id = @FreeSampleId"

'                Using cmd As New SqlCommand(query, con)

'                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = amount
'                    cmd.Parameters("@Amount").Precision = 18
'                    cmd.Parameters("@Amount").Scale = 2

'                    cmd.Parameters.Add("@FreeSampleId", SqlDbType.Int).Value =
'                    freeSampleId

'                    con.Open()
'                    cmd.ExecuteNonQuery()

'                End Using

'            End Using

'            LoadFreeSamples()

'            lblMessage.Text = "Free sample amount updated successfully."
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "hideUpdateMsg", "hideMessage();", True)
'        ElseIf e.CommandName = "DeleteSample" Then

'            Dim freeSampleId As Integer =
'            Convert.ToInt32(e.CommandArgument)

'            DeleteFreeSample(freeSampleId)

'            LoadFreeSamples()

'            lblMessage.Text = "Free sample deleted successfully."
'            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "hideDeleteMsg", "hideMessage();", True)
'        End If

'    End Sub
'    Private Sub DeleteFreeSample(freeSampleId As Integer)

'        Using con As New SqlConnection(conString)

'            Dim query As String = ""

'            query &= "DELETE FROM tblFreeSample "
'            query &= "WHERE FreeSample_Id = @FreeSampleId"

'            Using cmd As New SqlCommand(query, con)

'                cmd.Parameters.AddWithValue(
'                    "@FreeSampleId",
'                    freeSampleId)

'                con.Open()

'                cmd.ExecuteNonQuery()

'            End Using

'        End Using

'    End Sub


'    '=========================================================
'    ' GET CURRENT USER
'    '=========================================================

'    Private Function GetUserId() As Integer

'        If Session("UserId") IsNot Nothing Then

'            Return Convert.ToInt32(Session("UserId"))

'        End If

'        Return 0

'    End Function
'End Class

Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Class FreeSample
    Inherits System.Web.UI.Page

    Private ReadOnly conString As String =
        ConfigurationManager.ConnectionStrings("connectionString").ConnectionString

    '=========================================================
    ' GET ORDER ID FROM QUERY STRING
    '=========================================================
    Private ReadOnly Property OrderID As Integer
        Get
            Dim id As Integer

            If Integer.TryParse(Request.QueryString("OrderID"), id) Then
                Return id
            End If

            Return 0
        End Get
    End Property

    '=========================================================
    ' PAGE LOAD
    '=========================================================
    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    '    If OrderID <= 0 Then
    '        lblMessage.Text = "Invalid Order ID."
    '        btnAddSample.Enabled = False
    '        Return
    '    End If

    '    If Not IsPostBack Then
    '        LoadProducts()
    '        LoadFreeSamples()
    '    End If

    'End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then

            LoadProducts()

            If OrderID > 0 Then
                LoadFreeSamples()
            Else
                lblMessage.Text = "Order ID missing. Please open Free Sample from Order Edit page."
                btnAddSample.Enabled = False
            End If

        End If

    End Sub

    '=========================================================
    ' LOAD PRODUCT DROPDOWN
    '=========================================================
    Private Sub LoadProducts()

        Using con As New SqlConnection(conString)

            Dim query As String = ""
            query &= "SELECT Product_Id, Product_Name, Product_Code, Product_Rate "
            query &= "FROM tblProduct "
            query &= "WHERE Product_Status = @Status "
            query &= "ORDER BY Product_Name"

            Using cmd As New SqlCommand(query, con)

                cmd.Parameters.AddWithValue("@Status", "Active")

                con.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    ddlProduct.DataSource = dr
                    ddlProduct.DataTextField = "Product_Name"
                    ddlProduct.DataValueField = "Product_Id"
                    ddlProduct.DataBind()

                End Using

            End Using

        End Using

        ddlProduct.Items.Insert(0, New ListItem("-- Select Product --", "0"))

    End Sub

    '=========================================================
    ' LOAD FREE SAMPLES FOR CURRENT ORDER
    '=========================================================
    Private Sub LoadFreeSamples()

        Using con As New SqlConnection(conString)

            Dim query As String = ""
            query &= "SELECT "
            query &= "FS.FreeSample_Id, "
            query &= "FS.FreeSample_ProductId, "
            query &= "P.Product_Name, "
            query &= "P.Product_Code, "
            query &= "ISNULL(FS.FreeSample_Amount, P.Product_Rate) AS FreeSample_Amount "
            query &= "FROM tblFreeSample FS "
            query &= "INNER JOIN tblProduct P "
            query &= "ON P.Product_Id = FS.FreeSample_ProductId "
            query &= "WHERE FS.FreeSample_OrderId = @OrderID "
            query &= "ORDER BY FS.FreeSample_Id DESC"

            Using cmd As New SqlCommand(query, con)

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID

                Dim dt As New DataTable()

                Using da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                gvFreeSample.DataSource = dt
                gvFreeSample.DataBind()

                'Calculate total sample amount
                Dim total As Decimal = 0

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row("FreeSample_Amount")) Then
                        total += Convert.ToDecimal(row("FreeSample_Amount"))
                    End If
                Next

                lblTotalAmount.Text =
                    "Total Free Sample Amount: " & total.ToString("0.00")

            End Using

        End Using

    End Sub

    '=========================================================
    ' ADD FREE SAMPLE
    '=========================================================
    Protected Sub btnAddSample_Click(sender As Object, e As EventArgs)

        lblMessage.Text = ""

        If OrderID <= 0 Then
            lblMessage.Text = "Invalid Order ID."
            Return
        End If

        Dim productId As Integer

        If Not Integer.TryParse(ddlProduct.SelectedValue, productId) OrElse productId = 0 Then
            lblMessage.Text = "Please select a product."
            Return
        End If

        Using con As New SqlConnection(conString)

            con.Open()

            'Check duplicate product within the same order
            Dim checkQuery As String = ""
            checkQuery &= "SELECT COUNT(*) "
            checkQuery &= "FROM tblFreeSample "
            checkQuery &= "WHERE FreeSample_ProductId = @ProductId "
            checkQuery &= "AND FreeSample_OrderId = @OrderID"

            Using checkCmd As New SqlCommand(checkQuery, con)

                checkCmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId
                checkCmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID

                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If count > 0 Then
                    lblMessage.Text = "This product is already added to this order."
                    LoadFreeSamples()
                    ScriptManager.RegisterStartupScript(
                        Me, Me.GetType(), "hideDuplicateMsg",
                        "hideMessage();", True)
                    Return
                End If

            End Using

            'Insert product with its actual product price
            Dim insertQuery As String = ""
            insertQuery &= "INSERT INTO tblFreeSample "
            insertQuery &= "(FreeSample_OrderId, FreeSample_ProductId, "
            insertQuery &= "FreeSample_Amount, FreeSample_CreatedBy, FreeSample_CreatedDate) "
            insertQuery &= "SELECT @OrderID, Product_Id, "
            insertQuery &= "ISNULL(Product_Rate, 0), @CreatedBy, GETDATE() "
            insertQuery &= "FROM tblProduct "
            insertQuery &= "WHERE Product_Id = @ProductId"

            Using cmd As New SqlCommand(insertQuery, con)

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID
                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId
                cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = GetUserId()

                cmd.ExecuteNonQuery()

            End Using

        End Using

        ddlProduct.SelectedValue = "0"

        LoadFreeSamples()

        lblMessage.Text = "Free sample added successfully."

        ScriptManager.RegisterStartupScript(
            Me, Me.GetType(), "hideInsertMsg",
            "hideMessage();", True)

    End Sub

    '=========================================================
    ' UPDATE AMOUNT / DELETE SAMPLE
    '=========================================================
    Protected Sub gvFreeSample_RowCommand(
        sender As Object,
        e As GridViewCommandEventArgs)

        If e.CommandName = "UpdateAmount" Then

            Dim freeSampleId As Integer =
                Convert.ToInt32(e.CommandArgument)

            Dim row As GridViewRow =
                CType(CType(e.CommandSource, Control).NamingContainer, GridViewRow)

            Dim txtAmount As TextBox =
                CType(row.FindControl("txtAmount"), TextBox)

            Dim amount As Decimal

            If Not Decimal.TryParse(txtAmount.Text, amount) OrElse amount < 0 Then

                lblMessage.Text = "Please enter a valid amount."
                Return

            End If

            Using con As New SqlConnection(conString)

                Dim query As String = ""
                query &= "UPDATE tblFreeSample "
                query &= "SET FreeSample_Amount = @Amount "
                query &= "WHERE FreeSample_Id = @FreeSampleId "
                query &= "AND FreeSample_OrderId = @OrderID"

                Using cmd As New SqlCommand(query, con)

                    Dim amountParam As SqlParameter =
                        cmd.Parameters.Add("@Amount", SqlDbType.Decimal)

                    amountParam.Precision = 18
                    amountParam.Scale = 2
                    amountParam.Value = amount

                    cmd.Parameters.Add("@FreeSampleId", SqlDbType.Int).Value =
                        freeSampleId

                    cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value =
                        OrderID

                    con.Open()
                    cmd.ExecuteNonQuery()

                End Using

            End Using

            LoadFreeSamples()

            lblMessage.Text = "Free sample amount updated successfully."

            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(), "hideUpdateMsg",
                "hideMessage();", True)

        ElseIf e.CommandName = "DeleteSample" Then

            Dim freeSampleId As Integer =
                Convert.ToInt32(e.CommandArgument)

            DeleteFreeSample(freeSampleId)

            LoadFreeSamples()

            lblMessage.Text = "Free sample deleted successfully."

            ScriptManager.RegisterStartupScript(
                Me, Me.GetType(), "hideDeleteMsg",
                "hideMessage();", True)

        End If

    End Sub

    '=========================================================
    ' DELETE FREE SAMPLE FOR CURRENT ORDER
    '=========================================================
    Private Sub DeleteFreeSample(freeSampleId As Integer)

        Using con As New SqlConnection(conString)

            Dim query As String = ""
            query &= "DELETE FROM tblFreeSample "
            query &= "WHERE FreeSample_Id = @FreeSampleId "
            query &= "AND FreeSample_OrderId = @OrderID"

            Using cmd As New SqlCommand(query, con)

                cmd.Parameters.Add("@FreeSampleId", SqlDbType.Int).Value =
                    freeSampleId

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value =
                    OrderID

                con.Open()
                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub

    '=========================================================
    ' GET CURRENT USER
    '=========================================================
    Private Function GetUserId() As Integer

        If Session("UserId") IsNot Nothing Then
            Return Convert.ToInt32(Session("UserId"))
        End If

        Return 0

    End Function

End Class
