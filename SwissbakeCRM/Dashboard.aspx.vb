Imports System.Web.Services

Partial Class Dashboard
    Inherits _PageBaseClass
    Dim pro As New Procedure
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillUserName()
                txtStartDate.Text = DynamicparcelDataManipulation.DateFormat(DateAndTime.Now.ToString("yyyy-MM-dd"))
                txtendDate.Text = DynamicparcelDataManipulation.DateFormat(DateAndTime.Now.ToString("yyyy-MM-dd"))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.DropdownWithID("UserAssignDropDown", Session("UserId"))
            ddluser.DataSource = ds.Tables(0)
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyUser", "FillUserName", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub




    Protected Sub btnGetReport_Click(sender As Object, e As EventArgs)
        Clear()
        Select Case (ddlModule.SelectedValue.ToString.Trim)
            Case "Lead"
                If ddlType.SelectedIndex = 0 Then
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalLeadCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("ConvertLeadCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("IdelLeadCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("JunkLeadCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("LeadByIndustryByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Lead By Industry ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("LeadBySourceByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Lead By Source ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("LeadOwnerByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Lead By Team", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("ConvertedLeadOwnerByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Convert Lead By Team", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("IdelLeadOwnerbyTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Idel Lead By Team", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl6.Text = pro.BindChartPie(DashBoardBLL.ViewById("JunkLeadOwnerbyTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Junk Lead By Team", 1).ToString
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalLeadCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("ConvertLeadCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("IdelLeadCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("JunkLeadCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("LeadByIndustryByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Lead By Industry ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("LeadBySourceByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Lead By Source ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl3.Text = ""
                        DivLitrl4.Text = ""
                        DivLitrl5.Text = ""
                        DivLitrl6.Text = ""
                        'DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("ConvertedLeadOwnerByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Convert Lead By User", 2).ToString
                        'DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("IdelLeadOwnerbyUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Idel Lead By User", 2).ToString
                        'DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("JunkLeadOwnerbyUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), "Junk Lead By User", 2).ToString
                    Catch ex As Exception

                    End Try
                End If
            Case "Prospects"
                Try
                    If ddlType.SelectedIndex = 0 Then
                        Try
                            ltrltop1count.Text = DashBoardBLL.Count("TotalProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop2count.Text = DashBoardBLL.Count("ConvertedProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop3count.Text = DashBoardBLL.Count("IdelProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop4count.Text = DashBoardBLL.Count("ActiveProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ProspectByIndustryByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Prospect By Industry ", 2).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ProspectBySourceByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Prospect By Source ", 2).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("ProspectsOwnerByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Prospect By Team ", 1).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("ConvertedProspectByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Convert Prospect By Team ", 1).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("IdelProspectByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Idel Prospect By Team ", 1).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl6.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActiveProspectByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Active Prospect By Team ", 1).ToString
                        Catch ex As Exception

                        End Try
                    Else
                        Try
                            ltrltop1count.Text = DashBoardBLL.Count("TotalProspectsCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop2count.Text = DashBoardBLL.Count("ConvertedProspectsCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop3count.Text = DashBoardBLL.Count("IdelProspectsCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            ltrltop4count.Text = DashBoardBLL.Count("ActiveProspectsCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                            System.Threading.Thread.Sleep(10)
                            DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ProspectByIndustryByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Prospect By Industry ", 2).ToString
                            System.Threading.Thread.Sleep(10)
                            DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ProspectBySourceByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Prospect By Source ", 2).ToString
                            System.Threading.Thread.Sleep(10)
                        Catch ex As Exception

                        End Try
                    End If


                Catch ex As Exception

                End Try
            Case "Accounts"
                If ddlType.SelectedIndex = 0 Then
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalAccountCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        'ltrltop2count.Text = DashBoardBLL.Count("ConvertedProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        'System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("IdelAccountCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("ActiveAccountCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("AccountByIndustryByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Account By Industry ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("AccountBySourceByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Account By Source ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("AccountsOwnerByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Account By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("ConvertedAccountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Convert Account By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("IdelAccountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Idel Account By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl6.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActiveAccountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Active Account By Team ", 1).ToString
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalAccountCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        'ltrltop2count.Text = DashBoardBLL.Count("ConvertedProspectsCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        'System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("IdelAccountCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("ActiveAccountCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("AccountByIndustryByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Account By Industry ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("AccountBySourceByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Account By Source ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                    Catch ex As Exception

                    End Try
                End If
            Case "Activity"
                If ddlType.SelectedIndex = 0 Then
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalActivityCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("TotalActivityCallCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("TotalActivityEventCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("TotalActivityTaskCountByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Close By Status ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityMissedAndDueByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Missed Or Due By Team ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Total Activity By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityCallByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Phone/Email By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityEventByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Sampling/Demo By Team ", 1).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl6.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityTaskByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Task By Team ", 1).ToString
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalActivityCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("TotalActivityCallCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("TotalActivityEventCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("TotalActivityTaskCountByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Close By Status ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                        DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityMissedAndDueByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Missed Or Due By User ", 2).ToString
                        System.Threading.Thread.Sleep(10)
                    Catch ex As Exception

                    End Try
                End If
                'BY M@ndar on 05-08-2015
            Case "Order"
                If ddlType.SelectedIndex = 0 Then
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalOrderAmtByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("PendingOrderAmtByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("invoiceAmtByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("PaidByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        'DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Close By Status ", 2).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityMissedAndDueByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Missed Or Due By Team ", 2).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl3.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Total Activity By Team ", 1).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl4.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityCallByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Phone/Email By Team ", 1).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl5.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityEventByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Sampling/Demo By Team ", 1).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl6.Text = pro.BindChartPie(DashBoardBLL.ViewById("TotalActivityTaskByTeam", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Task By Team ", 1).ToString
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        ltrltop1count.Text = DashBoardBLL.Count("TotalOrderAmtByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop2count.Text = DashBoardBLL.Count("PendingOrderAmtByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop3count.Text = DashBoardBLL.Count("invoiceAmtByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        System.Threading.Thread.Sleep(10)
                        ltrltop4count.Text = DashBoardBLL.Count("PaidByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text)
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl1.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Close By Status ", 2).ToString
                        'System.Threading.Thread.Sleep(10)
                        'DivLitrl2.Text = pro.BindChartPie(DashBoardBLL.ViewById("ActivityMissedAndDueByUser", ddluser.SelectedValue.ToString, txtStartDate.Text, txtendDate.Text), " Activity Missed Or Due By User ", 2).ToString
                        'System.Threading.Thread.Sleep(10)
                    Catch ex As Exception

                    End Try
                End If
        End Select
    End Sub

    Protected Sub ddlModule_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlModule.SelectedIndexChanged
        Clear()
        Select Case (ddlModule.SelectedValue.ToString.Trim)
            Case "Lead"
                ltrltop1.Text = " Total Lead "
                ltrltop2.Text = " Converted Lead "
                ltrltop3.Text = " Idle Lead "
                ltrltop4.Text = " Junk Lead "
            Case "Prospects"
                ltrltop1.Text = " Total Prospects "
                ltrltop2.Text = " Converted Prospects "
                ltrltop3.Text = " Idle Prospects "
                ltrltop4.Text = " Active Prospects "
            Case "Accounts"
                ltrltop1.Text = " Total Accounts "
                ltrltop2.Text = "  "
                ltrltop3.Text = " Idle Accounts "
                ltrltop4.Text = " Active Accounts "
                DivTop2.Visible = False
            Case "Activity"
                ltrltop1.Text = " Total Activity "
                ltrltop2.Text = " Total Phone/Email "
                ltrltop3.Text = " Total Sampling/Demo "
                ltrltop4.Text = " Total Task "
            Case "Order"
                ltrltop1.Text = " Total Order Amount "
                ltrltop2.Text = " Total Pending Order "
                ltrltop3.Text = " Invoice Generated "
                ltrltop4.Text = " Total Paid Amount "
        End Select
    End Sub

    Public Sub Clear()
        ltrltop1count.Text = ""
        ltrltop2count.Text = ""
        ltrltop3count.Text = ""
        ltrltop4count.Text = ""
        DivLitrl1.Text = ""
        DivLitrl2.Text = ""
        DivLitrl3.Text = ""
        DivLitrl4.Text = ""
        DivLitrl5.Text = ""
        DivLitrl6.Text = ""

    End Sub

End Class
