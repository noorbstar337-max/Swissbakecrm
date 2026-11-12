Imports DynamicparcelEnumerations

Partial Class ModifySalesTarget
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim Count As Integer = 0
    Dim SalesTargetID As Integer
    Dim strNames As New List(Of String)



    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If (Request.QueryString("ID") = Nothing) Then
            Else
                UserSss()
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    FillMISType()

                    FillMISTypeForCAT()

                    dduser_TextChanged(Nothing, Nothing)
                    lbltitle1.Text = "New Sales Target"
                    lbltitle2.Text = "New Sales Target"
                    divsalestarget.Visible = True
                Else
                    FillSalestarget()
                    FillYear()
                    ddsalestarget.SelectedValue = "Monthly"
                    FillMISTypeForCAT()
                    dduser.Enabled = False
                    ddfinancilayear.Enabled = False
                    lbltitle1.Text = "Modify Sales Target"
                    lbltitle2.Text = "Modify Sales Target"
                    divsalestarget.Visible = False
                End If
            End If
        End If
    End Sub

    Public Sub FillSalestarget()
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        Dim dt As DataSet = MainBLL.ViewByID(MainID, "ViewSalesTargetByID")
        Dim dtUser As New DataTable
        dtUser = dt.Tables(0)
        If dtUser.Rows.Count > 0 Then
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddfinancilayear.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("SalesTarget_YearID").ToString())
            dduser.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("SalesTarget_userID").ToString())
        End If
        grdsalesorder.DataSource = MainBLL.ViewByID(MainID, "ViewSalesTargetDTByID")
        grdsalesorder.DataBind()
    End Sub

    Public Sub FillMISType()
        Try
            Dim dt As New DataTable()
            If ddsalestarget.SelectedValue = "Quarterly" Then

                'dt.Columns.AddRange(New DataColumn() {New DataColumn("monthname", GetType(String))})
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String)), _
                                                  New DataColumn("lead", GetType(Integer)), _
                                                      New DataColumn("LeadAchived", GetType(Integer)), _
                                                  New DataColumn("account", GetType(Integer)), _
                                                       New DataColumn("AccountAchived", GetType(Integer)), _
                                                  New DataColumn("prospect", GetType(Integer)), _
                                                       New DataColumn("prospectAchived", GetType(Integer)), _
                                                  New DataColumn("sales", GetType(Double)), New DataColumn("SalesAchived", GetType(Double))})
                dt.Rows.Add("April-May-June-July", "April-July", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("August-September-October-November", "August-November", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("December-January-February-March", "December-March", 0, 0, 0, 0, 0, 0, 0, 0)
                grdsalesorder.DataSource = dt
                grdsalesorder.DataBind()
            ElseIf ddsalestarget.SelectedValue = "Monthly" Then
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String)), _
                                                  New DataColumn("lead", GetType(Integer)), _
                                                      New DataColumn("LeadAchived", GetType(Integer)), _
                                                  New DataColumn("account", GetType(Integer)), _
                                                       New DataColumn("AccountAchived", GetType(Integer)), _
                                                  New DataColumn("prospect", GetType(Integer)), _
                                                       New DataColumn("prospectAchived", GetType(Integer)), _
                                                  New DataColumn("sales", GetType(Double)), New DataColumn("SalesAchived", GetType(Double))})
                dt.Rows.Add("", "April", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "May", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "June", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "July", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "August", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "September", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "October", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "November", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "December", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "January", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "February", 0, 0, 0, 0, 0, 0, 0, 0)
                dt.Rows.Add("", "March", 0, 0, 0, 0, 0, 0, 0, 0)
                grdsalesorder.DataSource = dt
                grdsalesorder.DataBind()
            ElseIf ddsalestarget.SelectedValue = "Annually" Then
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String)), _
                                                  New DataColumn("lead", GetType(Integer)), _
                                                      New DataColumn("LeadAchived", GetType(Integer)), _
                                                  New DataColumn("account", GetType(Integer)), _
                                                       New DataColumn("AccountAchived", GetType(Integer)), _
                                                  New DataColumn("prospect", GetType(Integer)), _
                                                       New DataColumn("prospectAchived", GetType(Integer)), _
                                                  New DataColumn("sales", GetType(Double)), New DataColumn("SalesAchived", GetType(Double))})
                dt.Rows.Add("April-May-June-July-August-September-October-November-December-January-February-March", "Each Month", 0, 0, 0, 0, 0, 0, 0, 0)
                grdsalesorder.DataSource = dt
                grdsalesorder.DataBind()
            End If
            Catch ex As Exception

        End Try
    End Sub

    Public Sub UserSss()
        dduser.DataSource = MainBLL.Dropdown("UserDropDown")
        dduser.DataTextField = "U_FirstName"
        dduser.DataValueField = "U_ID"
        dduser.DataBind()

    End Sub

    Public Sub FillYear()
        ddfinancilayear.DataSource = MainBLL.Dropdown("FinancialYearAdd")
        ddfinancilayear.DataTextField = "Year"
        ddfinancilayear.DataValueField = "Year_ID"
        ddfinancilayear.DataBind()
    End Sub



    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            If Page.IsValid Then
                If MainID = 0 Then
                    SaveProduct(DML_OPERATION.INSERT)
                ElseIf MainID > 0 Then
                    SaveProduct(DML_OPERATION.UPDATE)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyAccount", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    CalculateSumofAll()
                    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    SalesTargetBLL.DeleteSalesTargetDetail(MainID, Session("Audlog_Id"))
                    Count = SalesTargetBLL.MaxSalesTargetDt
                    Dim sb As New StringBuilder
                    Dim sbSTC As New StringBuilder
                    sb.Append("<root>")
                    For i As Integer = 0 To grdsalesorder.Rows.Count - 1
                        Dim ltmonthname As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonthname"), Literal)
                        Dim txtprospect As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtprospect"), TextBox)
                        Dim txtlead As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtlead"), TextBox)
                        Dim txtaccount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtaccount"), TextBox)
                        Dim txtsalesamount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtsalesamount"), TextBox)
                        If txtprospect.Text = "" Then
                            txtprospect.Text = 0
                        End If
                        If txtlead.Text = "" Then
                            txtlead.Text = 0
                        End If
                        If txtaccount.Text = "" Then
                            txtaccount.Text = 0
                        End If
                        If txtsalesamount.Text = "" Then
                            txtsalesamount.Text = 0
                        End If
                        sb.Append("<row SalesTargetDT_Id='" & Count.ToString & "' SalesTargetDT_TargetID='" & MainID &
                                 "' SalesTargetDT_MonthName='" & ltmonthname.Text & "' SalesTargetDT_Lead='" & txtlead.Text & "' SalesTargetDT_Prospect='" & txtprospect.Text &
                                 "' SalesTargetDT_Sales='" & txtsalesamount.Text & "' SalesTargetDT_Account='" & txtaccount.Text & "' SalesTargetDT_CreatedDate='" & DateAndTime.DateString &
                                 "' SalesTargetDT_ModifiedDate='" & DateAndTime.DateString &
                                 "' SalesTargetDT_Status='Active' />")
                        Count = Count + 1
                    Next
                    sb.Append("</root>")

                    sbSTC.Append("<root>")
                    For i As Integer = 0 To RPTtarget.Items.Count - 1
                        Dim lblmonthname As Literal = DirectCast(RPTtarget.Items(i).FindControl("lblmonthname"), Literal)
                        Dim grdcatgTarget As GridView = DirectCast(RPTtarget.Items(i).FindControl("grdcatgTarget"), GridView)
                        Dim ltmonth As Literal = DirectCast(RPTtarget.Items(i).FindControl("ltmonth"), Literal)
                        Dim total As New Integer
                        For m As Integer = 0 To grdcatgTarget.Rows.Count - 1
                            Dim lblSTC_ID As Literal = DirectCast(grdcatgTarget.Rows(m).FindControl("lblSTC_ID"), Literal)
                            Dim txtTargetsalesamount As TextBox = DirectCast(grdcatgTarget.Rows(m).FindControl("txtTargetsalesamount"), TextBox)
                            sbSTC.Append("<row STCD_TargetID='" & MainID & "' STCD_TargetCategoryID='" & lblSTC_ID.Text &
                                 "' STCD_MonthName='" & lblmonthname.Text & "' STCD_SalesAmt='" & txtTargetsalesamount.Text & "' />")
                            total = total + Convert.ToDouble(txtTargetsalesamount.Text)
                        Next
                        sbSTC.Append("<row STCD_TargetID='" & MainID & "' STCD_TargetCategoryID='1' STCD_MonthName='" & lblmonthname.Text & "' STCD_SalesAmt='" & total.ToString & "' />")
                    Next
                    sbSTC.Append("</root>")
                    SalesTargetBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), sbSTC.ToString)
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("ModifyAccount", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    CalculateSumofAll()
                    If ddsalestarget.SelectedValue = "Quaterly" Then
                        SalesTargetID = SalesTargetBLL.Insert(ddfinancilayear.SelectedValue, dduser.SelectedValue, Session("UserId"), Session("Audlog_Id"))
                        Count = SalesTargetBLL.MaxSalesTargetDt
                        Dim sb As New StringBuilder
                        Dim sbSTC As New StringBuilder
                        sb.Append("<root>")
                        For i As Integer = 0 To grdsalesorder.Rows.Count - 1
                            Dim ltmonthname As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonthname"), Literal)
                            Dim txtprospect As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtprospect"), TextBox)
                            Dim txtlead As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtlead"), TextBox)
                            Dim txtaccount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtaccount"), TextBox)
                            Dim txtsalesamount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtsalesamount"), TextBox)
                            Dim ltmonth As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonth"), Literal)
                            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(ltmonth.Text)
                            Dim strArr() As String
                            strArr = str.Split("-")
                            For t As Integer = 0 To strArr.Count - 1
                                sb.Append("<row SalesTargetDT_Id='" & Count.ToString & "' SalesTargetDT_TargetID='" & SalesTargetID &
                                     "' SalesTargetDT_MonthName='" & strArr(t) & "' SalesTargetDT_Lead='" & txtlead.Text & "' SalesTargetDT_Prospect='" & txtprospect.Text &
                                     "' SalesTargetDT_Sales='" & txtsalesamount.Text & "' SalesTargetDT_Account='" & txtaccount.Text & "' SalesTargetDT_CreatedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_ModifiedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_Status='Active' />")
                                Count = Count + 1
                            Next
                        Next
                        sb.Append("</root>")

                        sbSTC.Append("<root>")
                        For i As Integer = 0 To RPTtarget.Items.Count - 1
                            Dim lblmonthname As Literal = DirectCast(RPTtarget.Items(i).FindControl("lblmonthname"), Literal)
                            Dim grdcatgTarget As GridView = DirectCast(RPTtarget.Items(i).FindControl("grdcatgTarget"), GridView)
                            Dim ltmonth As Literal = DirectCast(RPTtarget.Items(i).FindControl("ltmonth"), Literal)
                            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(ltmonth.Text)
                            Dim strArr() As String
                            strArr = str.Split("-")

                            For t As Integer = 0 To strArr.Count - 1
                                Dim total As New Integer
                                For m As Integer = 0 To grdcatgTarget.Rows.Count - 1
                                    Dim lblSTC_ID As Literal = DirectCast(grdcatgTarget.Rows(m).FindControl("lblSTC_ID"), Literal)
                                    Dim txtTargetsalesamount As TextBox = DirectCast(grdcatgTarget.Rows(m).FindControl("txtTargetsalesamount"), TextBox)
                                    sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='" & lblSTC_ID.Text &
                                         "' STCD_MonthName='" & strArr(t) & "' STCD_SalesAmt='" & txtTargetsalesamount.Text & "' />")
                                    total = total + Convert.ToDouble(txtTargetsalesamount.Text)
                                Next
                                sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='1' STCD_MonthName='" & strArr(t) & "' STCD_SalesAmt='" & total.ToString & "' />")
                            Next
                        Next
                        sbSTC.Append("</root>")
                        SalesTargetBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), sbSTC.ToString)
                    ElseIf ddsalestarget.SelectedValue = "Monthly" Then
                        SalesTargetID = SalesTargetBLL.Insert(ddfinancilayear.SelectedValue, dduser.SelectedValue, Session("UserId"), Session("Audlog_Id"))
                        Count = SalesTargetBLL.MaxSalesTargetDt
                        Dim sb As New StringBuilder
                        Dim sbSTC As New StringBuilder
                        sb.Append("<root>")
                        For i As Integer = 0 To grdsalesorder.Rows.Count - 1
                            Dim ltmonthname As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonthname"), Literal)
                            Dim txtprospect As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtprospect"), TextBox)
                            Dim txtlead As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtlead"), TextBox)
                            Dim txtaccount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtaccount"), TextBox)
                            Dim txtsalesamount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtsalesamount"), TextBox)
                            If txtprospect.Text = "" Then
                                txtprospect.Text = 0
                            End If
                            If txtlead.Text = "" Then
                                txtlead.Text = 0
                            End If
                            If txtaccount.Text = "" Then
                                txtaccount.Text = 0
                            End If
                            If txtsalesamount.Text = "" Then
                                txtsalesamount.Text = 0
                            End If
                            sb.Append("<row SalesTargetDT_Id='" & Count.ToString & "' SalesTargetDT_TargetID='" & SalesTargetID &
                                     "' SalesTargetDT_MonthName='" & ltmonthname.Text & "' SalesTargetDT_Lead='" & txtlead.Text & "' SalesTargetDT_Prospect='" & txtprospect.Text &
                                     "' SalesTargetDT_Sales='" & txtsalesamount.Text & "' SalesTargetDT_Account='" & txtaccount.Text & "' SalesTargetDT_CreatedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_ModifiedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_Status='Active' />")
                            Count = Count + 1
                        Next
                        sb.Append("</root>")

                        sbSTC.Append("<root>")
                        For i As Integer = 0 To RPTtarget.Items.Count - 1
                            Dim lblmonthname As Literal = DirectCast(RPTtarget.Items(i).FindControl("lblmonthname"), Literal)
                            Dim grdcatgTarget As GridView = DirectCast(RPTtarget.Items(i).FindControl("grdcatgTarget"), GridView)
                            Dim ltmonth As Literal = DirectCast(RPTtarget.Items(i).FindControl("ltmonth"), Literal)
                            Dim total As New Integer
                            For m As Integer = 0 To grdcatgTarget.Rows.Count - 1
                                Dim lblSTC_ID As Literal = DirectCast(grdcatgTarget.Rows(m).FindControl("lblSTC_ID"), Literal)
                                Dim txtTargetsalesamount As TextBox = DirectCast(grdcatgTarget.Rows(m).FindControl("txtTargetsalesamount"), TextBox)
                                sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='" & lblSTC_ID.Text &
                                     "' STCD_MonthName='" & lblmonthname.Text & "' STCD_SalesAmt='" & txtTargetsalesamount.Text & "' />")
                                total = total + Convert.ToDouble(txtTargetsalesamount.Text)
                            Next
                            sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='1' STCD_MonthName='" & lblmonthname.Text & "' STCD_SalesAmt='" & total.ToString & "' />")
                        Next
                        sbSTC.Append("</root>")
                        SalesTargetBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), sbSTC.ToString)
                    ElseIf ddsalestarget.SelectedValue = "Annually" Then
                        SalesTargetID = SalesTargetBLL.Insert(ddfinancilayear.SelectedValue, dduser.SelectedValue, Session("UserId"), Session("Audlog_Id"))
                        Count = SalesTargetBLL.MaxSalesTargetDt
                        Dim sb As New StringBuilder
                        Dim sbSTC As New StringBuilder
                        sb.Append("<root>")
                        For i As Integer = 0 To grdsalesorder.Rows.Count - 1
                            Dim ltmonthname As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonthname"), Literal)
                            Dim txtprospect As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtprospect"), TextBox)
                            Dim txtlead As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtlead"), TextBox)
                            Dim txtaccount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtaccount"), TextBox)
                            Dim txtsalesamount As TextBox = DirectCast(grdsalesorder.Rows(i).FindControl("txtsalesamount"), TextBox)
                            Dim ltmonth As Literal = DirectCast(grdsalesorder.Rows(i).FindControl("ltmonth"), Literal)
                            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(ltmonth.Text)
                            Dim strArr() As String
                            strArr = str.Split("-")
                            If txtprospect.Text = "" Then
                                txtprospect.Text = 0
                            End If
                            If txtlead.Text = "" Then
                                txtlead.Text = 0
                            End If
                            If txtaccount.Text = "" Then
                                txtaccount.Text = 0
                            End If
                            If txtsalesamount.Text = "" Then
                                txtsalesamount.Text = 0
                            End If
                            For t As Integer = 0 To strArr.Count - 1
                                sb.Append("<row SalesTargetDT_Id='" & Count.ToString & "' SalesTargetDT_TargetID='" & SalesTargetID &
                                     "' SalesTargetDT_MonthName='" & strArr(t) & "' SalesTargetDT_Lead='" & txtlead.Text & "' SalesTargetDT_Prospect='" & txtprospect.Text &
                                     "' SalesTargetDT_Sales='" & txtsalesamount.Text & "' SalesTargetDT_Account='" & txtaccount.Text & "' SalesTargetDT_CreatedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_ModifiedDate='" & DateAndTime.DateString &
                                     "' SalesTargetDT_Status='Active' />")
                                Count = Count + 1
                            Next
                        Next
                        sb.Append("</root>")

                        sbSTC.Append("<root>")
                        For i As Integer = 0 To RPTtarget.Items.Count - 1
                            Dim lblmonthname As Literal = DirectCast(RPTtarget.Items(i).FindControl("lblmonthname"), Literal)
                            Dim grdcatgTarget As GridView = DirectCast(RPTtarget.Items(i).FindControl("grdcatgTarget"), GridView)
                            Dim ltmonth As Literal = DirectCast(RPTtarget.Items(i).FindControl("ltmonth"), Literal)
                            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(ltmonth.Text)
                            Dim strArr() As String
                            strArr = str.Split("-")

                            For t As Integer = 0 To strArr.Count - 1
                                Dim total As New Integer
                                For m As Integer = 0 To grdcatgTarget.Rows.Count - 1
                                    Dim lblSTC_ID As Literal = DirectCast(grdcatgTarget.Rows(m).FindControl("lblSTC_ID"), Literal)
                                    Dim txtTargetsalesamount As TextBox = DirectCast(grdcatgTarget.Rows(m).FindControl("txtTargetsalesamount"), TextBox)
                                    sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='" & lblSTC_ID.Text &
                                         "' STCD_MonthName='" & strArr(t) & "' STCD_SalesAmt='" & txtTargetsalesamount.Text & "' />")
                                    total = total + Convert.ToInt32(txtTargetsalesamount.Text)
                                Next
                                sbSTC.Append("<row STCD_TargetID='" & SalesTargetID & "' STCD_TargetCategoryID='1' STCD_MonthName='" & strArr(t) & "' STCD_SalesAmt='" & total.ToString & "' />")
                            Next
                        Next
                        sbSTC.Append("</root>")
                        SalesTargetBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), sbSTC.ToString)
                    End If
                    Dim dt As DataSet = MainBLL.ViewByID(SalesTargetID, "ViewSalesTargetByID")
                    Dim dtUser As New DataTable
                    dtUser = dt.Tables(0)
                    If dtUser.Rows.Count > 0 Then
                        Dim drLogin As DataRow
                        drLogin = dtUser.Rows(0)
                        ddfinancilayear.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("SalesTarget_YearID").ToString())
                        dduser.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("SalesTarget_userID").ToString())
                    End If
                    grdsalesorder.DataSource = MainBLL.ViewByID(SalesTargetID, "ViewSalesTargetDTByID")
                    grdsalesorder.DataBind()
                    Response.Redirect("salestarget.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("SaveProduct", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select

    End Sub

    Protected Sub dduser_TextChanged(sender As Object, e As EventArgs) Handles dduser.TextChanged
        ddfinancilayear.DataSource = MainBLL.DropdownWithID("FinancialYear", dduser.SelectedValue)
        ddfinancilayear.DataTextField = "Year"
        ddfinancilayear.DataValueField = "Year_ID"
        ddfinancilayear.DataBind()
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        Response.Redirect("SalesTarget.aspx")
    End Sub

    Protected Sub ddsalestarget_TextChanged(sender As Object, e As EventArgs) Handles ddsalestarget.TextChanged
        FillMISType()

        FillMISTypeForCAT() ''------------------------mandar
    End Sub

    ''------------------------mandar
    Public Sub FillMISTypeForCAT()
        Try
            Dim dt As New DataTable()
            If ddsalestarget.SelectedValue = "Quarterly" Then

                'dt.Columns.AddRange(New DataColumn() {New DataColumn("monthname", GetType(String))})
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String))})
                dt.Rows.Add("April-May-June-July", "April-July")
                dt.Rows.Add("August-September-October-November", "August-November")
                dt.Rows.Add("December-January-February-March", "December-March")
                RPTtarget.DataSource = dt
                RPTtarget.DataBind()
            ElseIf ddsalestarget.SelectedValue = "Monthly" Then
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String))})
                dt.Rows.Add("", "April")
                dt.Rows.Add("", "May")
                dt.Rows.Add("", "June")
                dt.Rows.Add("", "July")
                dt.Rows.Add("", "August")
                dt.Rows.Add("", "September")
                dt.Rows.Add("", "October")
                dt.Rows.Add("", "November")
                dt.Rows.Add("", "December")
                dt.Rows.Add("", "January")
                dt.Rows.Add("", "February")
                dt.Rows.Add("", "March")
                RPTtarget.DataSource = dt
                RPTtarget.DataBind()
            ElseIf ddsalestarget.SelectedValue = "Annually" Then
                dt.Columns.AddRange(New DataColumn() {New DataColumn("month", GetType(String)), _
                                                       New DataColumn("monthname", GetType(String))})
                dt.Rows.Add("April-May-June-July-August-September-October-November-December-January-February-March", "Each Month")
                RPTtarget.DataSource = dt
                RPTtarget.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub RPTtarget_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RPTtarget.ItemDataBound
        If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
            If MainID = 0 Then
                Dim scriptMan As ScriptManager = ScriptManager.GetCurrent(Me)
                Dim grdcatgTarget As GridView = DirectCast(e.Item.FindControl("grdcatgTarget"), GridView)
                scriptMan.RegisterAsyncPostBackControl(grdcatgTarget)
                Dim dt As DataTable = MainBLL.Dropdown("TargetCategory").Tables(0)
                Dim Targetsales As DataColumn = New DataColumn
                With Targetsales
                    .ColumnName = "Targetsales"
                    .DataType = System.Type.GetType("System.Int32")
                    .DefaultValue = 0
                End With
                dt.Columns.Add(Targetsales)
                Dim TargetSalesAchived As DataColumn = New DataColumn
                With TargetSalesAchived
                    .ColumnName = "TargetSalesAchived"
                    .DataType = System.Type.GetType("System.Int32")
                    .DefaultValue = 0
                End With
                dt.Columns.Add(TargetSalesAchived)
                grdcatgTarget.DataSource = dt
                grdcatgTarget.DataBind()
            Else
                Dim grdcatgTarget As GridView = DirectCast(e.Item.FindControl("grdcatgTarget"), GridView)
                Dim lblmonthname As Literal = DirectCast(e.Item.FindControl("lblmonthname"), Literal)

                Dim dt As DataTable = TargetCategoryBLL.ViewSTCDetailByID(lblmonthname.Text, MainID).Tables(0)
                grdcatgTarget.DataSource = dt
                grdcatgTarget.DataBind()
            End If
        End If
    End Sub

   
    Protected Sub txtTargetsalesamount_TextChanged(sender As Object, e As EventArgs)
        Dim grdcatgTarget As GridView = DirectCast(DirectCast(sender, TextBox).Parent.Parent.Parent.Parent, GridView)
        Dim Sum As Double = 0
        For Each row As GridViewRow In grdcatgTarget.Rows
            Dim txtTargetsalesamount As TextBox = DirectCast(row.FindControl("txtTargetsalesamount"), TextBox)
            If Not String.IsNullOrEmpty(txtTargetsalesamount.Text) Then
                If IsNumeric(txtTargetsalesamount.Text) Then
                    Sum = Sum + Convert.ToDouble(txtTargetsalesamount.Text)
                End If
            End If
        Next
        Dim RPTtargetrow As RepeaterItem = DirectCast(DirectCast(sender, TextBox).Parent.Parent.Parent.Parent.Parent, RepeaterItem)
        Dim lblmonthname As Literal = DirectCast(RPTtargetrow.FindControl("lblmonthname"), Literal)

        For Each salesrow As GridViewRow In grdsalesorder.Rows
            Dim txtsalesamount As TextBox = DirectCast(salesrow.FindControl("txtsalesamount"), TextBox)
            Dim ltmonthname As Literal = DirectCast(salesrow.FindControl("ltmonthname"), Literal)
            If ltmonthname.Text = lblmonthname.Text Then
                txtsalesamount.Text = Sum.ToString
                Exit For
            End If
        Next
        DirectCast(sender, TextBox).Focus()
    End Sub

    Public Sub CalculateSumofAll()
        For Each salesrow As GridViewRow In grdsalesorder.Rows
            Dim txtsalesamount As TextBox = DirectCast(salesrow.FindControl("txtsalesamount"), TextBox)
            Dim ltmonthname As Literal = DirectCast(salesrow.FindControl("ltmonthname"), Literal)
            For Each targetitem As RepeaterItem In RPTtarget.Items
                Dim lblmonthname As Literal = DirectCast(targetitem.FindControl("lblmonthname"), Literal)
                If ltmonthname.Text = lblmonthname.Text Then
                    Dim grdcatgTarget As GridView = DirectCast(targetitem.FindControl("grdcatgTarget"), GridView)
                    Dim mysum As Integer = 0
                    For Each targetsrow As GridViewRow In grdcatgTarget.Rows
                        Dim txtTargetsalesamount As TextBox = DirectCast(targetsrow.FindControl("txtTargetsalesamount"), TextBox)
                        mysum = mysum + Convert.ToDouble(txtTargetsalesamount.Text)
                    Next
                    txtsalesamount.Text = mysum.ToString
                End If
            Next
        Next
    End Sub

End Class
