Imports System.Web.Services

Partial Class CreateMultiPO
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim countrate As Double = 0.0
    Dim countrate1 As Double = 0.0
    Dim FooterTotalAmount As Double = 0.0
    Dim VatAmount As Double = 0.0
    Dim countrydt As DataTable
    Dim statedt As DataTable
    Dim strvat As New List(Of String)
    Dim smstotalamount As String = 0
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        Else
            Try
                If Not IsPostBack Then

                    '  txtorderdate.Text = DateAndTime.Now.ToString("yyyy-MM-ddTHH:mm")
                    '  txtpodate.Text = DateAndTime.Now.ToString("yyyy-MM-dd")
                    fillvendor()
                    '

                End If



            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")

                ExecptionBLL.Insert(System.IO.Path.GetFileName(Request.Url.AbsolutePath), System.Reflection.MethodBase.GetCurrentMethod().Name, error1, Session("UserId")) 'ExpenseReportByName", "fillUser", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If



    End Sub

    Public Sub fillvendor()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("VendorDropDown")
            ddvendor.DataSource = ds
            ddvendor.DataTextField = "Vendor_Name"
            ddvendor.DataValueField = "Vendor_ID"

            ddvendor.DataBind()
            ddvendor.Items.Insert(0, "Select Vendor")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "fillaccount", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddvendor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddvendor.SelectedIndexChanged
        divgrid.Visible = True
        GridView1.DataSource = MainBLL.ViewByID(ddvendor.SelectedValue, "FillQResponsebyvendor")
        GridView1.DataBind()
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Dim qrId As Integer
        Dim qrespId As Integer
        Dim qrespcode As String
        Dim qrVId As Integer
        Dim amount As Double = 0.0
        Dim tax As Double = 0.0
        Dim freight As Double = 0.0
        If GridView1.Rows.Count > 0 Then
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim CheckBox1 = DirectCast(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
                Dim lblAmount As Literal = DirectCast(GridView1.Rows(i).FindControl("lblAmount1"), Literal)
                Dim lblTax As Literal = DirectCast(GridView1.Rows(i).FindControl("lblTax1"), Literal)
                Dim lblFreight As Literal = DirectCast(GridView1.Rows(i).FindControl("lblFreight1"), Literal)
                Dim lblRMID As Literal = DirectCast(GridView1.Rows(i).FindControl("lblRMID"), Literal)
                Dim lblQResponse_Code As Literal = DirectCast(GridView1.Rows(i).FindControl("lblQResponse_Code"), Literal)
                Dim lblQty As Literal = DirectCast(GridView1.Rows(i).FindControl("lblQty1"), Literal)
                Dim LblR As Literal = DirectCast(GridView1.Rows(i).FindControl("LblR"), Literal)
                Dim LblV As Literal = DirectCast(GridView1.Rows(i).FindControl("LblV"), Literal)
                Dim lblrespid As Literal = DirectCast(GridView1.Rows(i).FindControl("lblrespid"), Literal)

                If CheckBox1.Checked = True Then


                    'Dim getstring As String() = lblQty.Text.ToString().Split(New Char() {"-"c})
                    'Dim Qty, unit As String
                    'Qty = getstring(0)
                    'unit = getstring(1)

                    qrId = CInt(LblR.Text)
                    qrespId = CInt(lblrespid.Text)
                    qrVId = CInt(LblV.Text)
                    qrespcode = lblQResponse_Code.Text
                    amount = amount + CDbl(lblAmount.Text)
                    freight = freight + CDbl(lblFreight.Text)
                    tax = tax + CDbl(lblTax.Text)



                End If
            Next
            Dim PurchaseOrder_ID As Integer = PurchaseOrderBLL.InsertPurchaseOrder(qrId, "MULTIPLE", qrVId, amount, tax, freight, Session("UserId"), Session("Audlog_Id"))
            For i As Integer = 0 To GridView1.Rows.Count - 1
                Dim CheckBox1 = DirectCast(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
                Dim lblAmount As Literal = DirectCast(GridView1.Rows(i).FindControl("lblAmount1"), Literal)
                Dim lblTax As Literal = DirectCast(GridView1.Rows(i).FindControl("lblTax1"), Literal)
                Dim lblPerUnit1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblPerUnit1"), Literal)
                Dim lblFreight As Literal = DirectCast(GridView1.Rows(i).FindControl("lblFreight1"), Literal)
                Dim lblRMID As Literal = DirectCast(GridView1.Rows(i).FindControl("lblRMID"), Literal)
                Dim lblQResponse_Code As Literal = DirectCast(GridView1.Rows(i).FindControl("lblQResponse_Code"), Literal)
                Dim lblQty As Literal = DirectCast(GridView1.Rows(i).FindControl("lblQty1"), Literal)
                Dim LblR As Literal = DirectCast(GridView1.Rows(i).FindControl("LblR"), Literal)
                Dim LblV As Literal = DirectCast(GridView1.Rows(i).FindControl("LblV"), Literal)
                Dim lblrespid As Literal = DirectCast(GridView1.Rows(i).FindControl("lblrespid"), Literal)


                If CheckBox1.Checked = True Then


                    Dim getstring As String() = lblQty.Text.ToString().Split(New Char() {"-"c})
                    Dim Qty, unit As String
                    Qty = getstring(0)
                    unit = getstring(1)

                    'qrId = CInt(LblR.Text)
                    qrespId = CInt(lblrespid.Text)
                    'qrVId = CInt(LblV.Text)
                    'qrespcode = lblQResponse_Code.Text
                    'amount = amount + CDbl(lblAmount.Text)
                    'freight = freight + CDbl(lblFreight.Text)
                    'tax = tax + CDbl(lblTax.Text)



                    PurchaseOrderBLL.InsertPORawMaterial(lblRMID.Text, PurchaseOrder_ID, Qty, unit, Session("UserId"), Session("Audlog_Id"))

                    QuotationResponseBLL.PoIDQrespUpdate(PurchaseOrder_ID, qrespId)
                    PurchaseOrderBLL.UpdatePORawMaterial(lblRMID.Text, PurchaseOrder_ID, CDbl(lblPerUnit1.Text), CDbl(IIf(lblTax.Text = "", "0", lblTax.Text)), lblAmount.Text)

                End If
            Next
            Response.Redirect("Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(qrId)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(ddvendor.SelectedValue)))
        End If
    End Sub
End Class
