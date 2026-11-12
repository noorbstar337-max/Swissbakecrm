Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser


Partial Class MonthlyPerformanceReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If (Session("UserId") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            FillUserName()
            ddluser.SelectedValue = Session("UserId")
            txtmonth.Text = Date.Now.ToString("yyyy-MM")
            Dim now As DateTime = DateTime.Now
            fillST(now, Session("UserId"))
            fillSTIndividual(now, Session("UserId"))
            If Session("UserId").ToString = "1" Then
                divusername.Visible = True
            Else
                divusername.Visible = False
            End If
        End If
    End Sub

    Public Sub fillST(ByVal mydate As DateTime, ByVal UID As Int32)

        Dim startDate = New DateTime(mydate.Year, mydate.Month, 1)
        Dim endDate = startDate.AddMonths(1).AddDays(-1)

        lblmonth.Text = startDate.ToString("dd-MMM-yyyy") + " To " + endDate.ToString("dd-MMM-yyyy")
        lblcMonth.Text = startDate.ToString("MMMM")
        lblLMonth.Text = startDate.AddMonths(-1).ToString("MMMM")
        lblcMonth1.Text = startDate.ToString("MMMM")
        lblLMonth1.Text = startDate.AddMonths(-1).ToString("MMMM")
        Dim ds As DataSet = CountBLL.MonthlyReport("CurrentMonthReportByUserID", UID, startDate.ToString("yyyy-MM-dd"))
        If ds.Tables.Count > 0 Then
            lblCMA.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("TeamAchivedSalesMonthCount").ToString())).ToString("N2")
            lblCMST.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(1).Rows(0)("TeamTargetSalesMonthCount").ToString())).ToString("N2")
            lblCMQTY.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(2).Rows(0)("TeamAchivedQTYMonthCount").ToString())).ToString("N")

            If Not Convert.ToDouble(lblCMA.Text) = 0.0 Then
                If Not Convert.ToDouble(lblCMST.Text) = 0.0 Then
                    lblCMAP.Text = (Convert.ToDouble(lblCMA.Text) * 100 / Convert.ToDouble(lblCMST.Text)).ToString("N2")
                Else
                    lblCMAP.Text = "0.00"
                End If
            Else
                lblCMAP.Text = "0.00"
            End If

            lblLMA.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(3).Rows(0)("LMTeamAchivedSalesMonthCount").ToString())).ToString("N2")
            lblLMST.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(4).Rows(0)("LMTeamTargetSalesMonthCount").ToString())).ToString("N2")
            lblLMQTY.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(5).Rows(0)("LMTeamAchivedQTYMonthCount").ToString())).ToString("N")

            If Not Convert.ToDouble(lblLMA.Text) = 0.0 Then
                If Not Convert.ToDouble(lblLMST.Text) = 0.0 Then
                    lblLMAP.Text = (Convert.ToDouble(lblLMA.Text) * 100 / Convert.ToDouble(lblLMST.Text)).ToString("N2")
                Else
                    lblLMAP.Text = "0.00"
                End If
            Else
                lblLMAP.Text = "0.00"
            End If


            GrdGroupwise.DataSource = ds.Tables(6)
            GrdGroupwise.DataBind()

            Dim strScript As New StringBuilder()
            strScript.Append("<div id='columnchart_material'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & " google.charts.load('current', { 'packages': ['bar','corechart'] });" & vbCr & vbLf & " google.charts.setOnLoadCallback(drawChart);" & vbCr & vbLf & " function drawChart() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Month', 'Sales Target', 'Achieved']," & vbCr & vbLf & "  ['" & lblcMonth.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblCMST.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblCMA.Text)).ToString & "]," & vbCr & vbLf & " ['" & lblLMonth.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblLMST.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblLMA.Text)).ToString & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & "  chart: {" & vbCr & vbLf & " title: 'Team Sales Performance'" & vbCr & vbLf & "  },colors: ['#dc3912','#3366cc'], " & vbCr & vbLf & "  height:287," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & "  var chart = new google.charts.Bar(document.getElementById('columnchart_material'));" & vbCr & vbLf & "  chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            lblsalestarget.Text = strScript.ToString

            Dim strBARScript As New StringBuilder()
            strBARScript.Append("<div id='barchart_material'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & "google.charts.setOnLoadCallback(drawChart);" & vbCr & vbLf & " function drawChart() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Group ', 'Sales Target', 'Achieved'],")
            For i As Integer = 0 To ds.Tables(6).Rows.Count - 1
                strBARScript.Append(" ['" & ds.Tables(6).Rows(i)("TC_Name") & "', " & ds.Tables(6).Rows(i)("STCD_SalesAmt") & ", " & ds.Tables(6).Rows(i)("TargetSalesAchived") & "],")
            Next
            strBARScript.ToString.Remove(strBARScript.ToString.LastIndexOf(","), 1)
            strBARScript.Append(" ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & " chart: {" & vbCr & vbLf & " title: 'Team Group Wise Detail'," & vbCr & vbLf & "  },colors: ['#990099','#0099c6']," & vbCr & vbLf & " bars: 'horizontal', // Required for Material Bar Charts." & vbCr & vbLf & "  height:260," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & " var chart = new google.charts.Bar(document.getElementById('barchart_material'));" & vbCr & vbLf & " chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            lblgrouptarget.Text = strBARScript.ToString

            ''-----------------activity report

            taskPerform.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(7).Rows(0)("taskPerform").ToString())
            taskMissed.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(8).Rows(0)("taskMissed").ToString())
            taskClose.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(9).Rows(0)("taskClosePostpone").ToString())
            taskTotal.Text = Convert.ToDouble(Convert.ToInt32(taskPerform.Text) + Convert.ToInt32(taskMissed.Text) + Convert.ToInt32(taskClose.Text)).ToString

            demoPerform.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(10).Rows(0)("eventPerform").ToString())
            demoMissed.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(11).Rows(0)("eventMissed").ToString())
            demoClose.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(12).Rows(0)("eventClosePostpone").ToString())
            demoTotal.Text = Convert.ToDouble(Convert.ToInt32(demoPerform.Text) + Convert.ToInt32(demoMissed.Text) + Convert.ToInt32(demoClose.Text)).ToString

            phonePerform.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(13).Rows(0)("callPerform").ToString())
            phoneMissed.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(14).Rows(0)("callMissed").ToString())
            phoneClose.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(15).Rows(0)("callClosePostpone").ToString())
            phoneTotal.Text = Convert.ToDouble(Convert.ToInt32(phonePerform.Text) + Convert.ToInt32(phoneMissed.Text) + Convert.ToInt32(phoneClose.Text)).ToString

            totalPerform.Text = Convert.ToDouble(Convert.ToInt32(taskPerform.Text) + Convert.ToInt32(demoPerform.Text) + Convert.ToInt32(phonePerform.Text)).ToString
            totalkMissed.Text = Convert.ToDouble(Convert.ToInt32(taskMissed.Text) + Convert.ToInt32(demoMissed.Text) + Convert.ToInt32(phoneMissed.Text)).ToString
            totalClose.Text = Convert.ToDouble(Convert.ToInt32(taskClose.Text) + Convert.ToInt32(demoClose.Text) + Convert.ToInt32(phoneClose.Text)).ToString

            totalTotal.Text = Convert.ToDouble(Convert.ToInt32(totalPerform.Text) + Convert.ToInt32(totalkMissed.Text) + Convert.ToInt32(totalClose.Text)).ToString



            If (totalTotal.Text = 0) Then
                pertaskPerform.Text = "0%"
                pertaskMissed.Text = "0%"
                pertaskClose.Text = "0%"

                pertaskTotal.Text = "0%"

            Else
                pertaskPerform.Text = Convert.ToDouble(taskPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                pertaskMissed.Text = Convert.ToDouble(taskMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                pertaskClose.Text = Convert.ToDouble(taskClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

                pertaskTotal.Text = Convert.ToDouble(taskTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
            End If

            If (totalTotal.Text = 0) Then
                perdemoPerform.Text = "0%"
                perdemoMissed.Text = "0%"
                perdemoClose.Text = "0%"

                perdemoTotal.Text = "0%"

            Else

                perdemoPerform.Text = Convert.ToDouble(demoPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                perdemoMissed.Text = Convert.ToDouble(demoMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                perdemoClose.Text = Convert.ToDouble(demoClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

                perdemoTotal.Text = Convert.ToDouble(demoTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"

            End If

            If (totalTotal.Text = 0) Then
                perphonePerform.Text = "0%"
                perphoneMissed.Text = "0%"
                perphoneClose.Text = "0%"

                perphoneTotal.Text = "0%"
            Else
                perphonePerform.Text = Convert.ToDouble(phonePerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                perphoneMissed.Text = Convert.ToDouble(phoneMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                perphoneClose.Text = Convert.ToDouble(phoneClose.Text / phoneTotal.Text * 100).ToString("#,##0.00") + "%"

                perphoneTotal.Text = Convert.ToDouble(phoneTotal.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"


            End If
            If (totalTotal.Text = 0) Then
                pertotalPerform.Text = "0%"
                pertotalkMissed.Text = "0%"
                pertotalClose.Text = "0%"
                pertotalTotal.Text = "0%"
            Else


                pertotalPerform.Text = Convert.ToDouble(totalPerform.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                pertotalkMissed.Text = Convert.ToDouble(totalkMissed.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                pertotalClose.Text = Convert.ToDouble(totalClose.Text / totalTotal.Text * 100).ToString("#,##0.00") + "%"
                pertotalTotal.Text = "100%"
            End If
            ''--------------------activity report


            Dim strStackScript As New StringBuilder()
            strStackScript.Append("<div id='barchart_stack'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & " google.charts.setOnLoadCallback(drawBasic);" & vbCr & vbLf & " function drawBasic() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Activity', 'Perform', 'Missed', 'Close Postpone']," & vbCr & vbLf & "['Task'," & taskPerform.Text & ", " & taskMissed.Text & ", " & taskClose.Text & "]," & vbCr & vbLf & " ['Sampling/Demo'," & demoPerform.Text & ", " & demoMissed.Text & ", " & demoClose.Text & "]," & vbCr & vbLf & " ['Phone & Email', " & phonePerform.Text & ", " & phoneMissed.Text & ", " & phoneClose.Text & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = { title: 'Team Activity Report',colors: ['#4285f4','#db4437','#f4b400'],height:225," & vbCr & vbLf & " legend: { position: 'top', maxLines: 1 }," & vbCr & vbLf & " bar: { groupWidth: '75%' }," & vbCr & vbLf & "isStacked:  'percent'," & vbCr & vbLf & " hAxis: {" & vbCr & vbLf & " minValue: 0, ticks: [0, .3, .6, .8, 1]" & vbCr & vbLf & " }" & vbCr & vbLf & " };" & vbCr & vbLf & " var chart = new google.visualization.BarChart(document.getElementById('barchart_stack'));" & vbCr & vbLf & " chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "</script>")
            lblstacked.Text = strStackScript.ToString


            ''-------------------Conversions / Productivity
            lblCLead.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(16).Rows(0)("TeamAchivedLeadMonthCount").ToString())
            lblCLeadTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(17).Rows(0)("TeamTargetLeadMonthCount").ToString())
            lblCProspect.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(20).Rows(0)("TeamAchivedProspectMonthCount").ToString())
            lblCProspectTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(21).Rows(0)("TeamTargetProspectMonthCount").ToString())
            lblCAccount.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(24).Rows(0)("TeamAchivedAccountMonthCount").ToString())
            lblCAccountTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(25).Rows(0)("TeamTargetAccountMonthCount").ToString())
            If Not lblCAccount.Text = "0" And Not lblCProspect.Text = "0" Then
                lblCProductivity.Text = Math.Round((Convert.ToInt32(lblCAccount.Text) / Convert.ToInt32(lblCProspect.Text)), 2).ToString
            Else
                lblCProductivity.Text = "0"
            End If
            lblLLead.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(18).Rows(0)("TeamAchivedLeadMonthCountLM").ToString())
            lblLLeadTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(19).Rows(0)("TeamTargetLeadMonthCountLM").ToString())
            lblLProspect.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(22).Rows(0)("TeamAchivedProspectMonthCountLM").ToString())
            lblLProspectTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(23).Rows(0)("TeamTargetProspectMonthCountLM").ToString())
            lblLAccount.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(26).Rows(0)("TeamAchivedAccountMonthCountLM").ToString())
            lblLAccountTarget.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(27).Rows(0)("TeamTargetAccountMonthCountLM").ToString())
            If Not lblLAccount.Text = "0" And Not lblLProspect.Text = "0" Then
                lblLProductivity.Text = Math.Round((Convert.ToInt32(lblLAccount.Text) / Convert.ToInt32(lblLProspect.Text)), 2).ToString
            Else
                lblLProductivity.Text = "0"
            End If

            Dim strPieScript As New StringBuilder()
            strPieScript.Append("<div id='piechart_diff'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & "  google.charts.setOnLoadCallback(drawChart3);" & vbCr & vbLf & " function drawChart3() {" & vbCr & vbLf & " var oldData = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Productivity', 'Count']," & vbCr & vbLf & " ['Leads', " & lblCLead.Text & "]," & vbCr & vbLf & " ['Prospects', " & lblCProspect.Text & "]," & vbCr & vbLf & " ['Accounts', " & lblCAccount.Text & "]" & vbCr & vbLf & "]);" & vbCr & vbLf & " var newData = google.visualization.arrayToDataTable([" & vbCr & vbLf & "['Productivity', 'Count']," & vbCr & vbLf & " ['Leads', " & lblLLead.Text & "]," & vbCr & vbLf & " ['Prospects', " & lblLProspect.Text & "]," & vbCr & vbLf & " ['Accounts', " & lblLAccount.Text & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = {title: 'Team Conversions / Productivity'," & vbCr & vbLf & " pieSliceText: 'value', " & vbCr & vbLf & " height: '275'," & vbCr & vbLf & " legend: { position: 'top' },colors: ['#673AB7','#F50057','#2196F3']" & vbCr & vbLf & " };" & vbCr & vbLf & " var chartDiff = new google.visualization.PieChart(document.getElementById('piechart_diff'));" & vbCr & vbLf & " var diffData = chartDiff.computeDiff(oldData, newData);" & vbCr & vbLf & " chartDiff.draw(diffData, options);" & vbCr & vbLf & "}" & vbCr & vbLf & "</script>")
            lblpie.Text = strPieScript.ToString
            ''--------------------Conversions / Productivity

            lblbodname.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(28).Rows(0)("UName").ToString())
        End If

    End Sub

    Public Sub fillSTIndividual(ByVal mydate As DateTime, ByVal UID As Int32)

        Dim startDate = New DateTime(mydate.Year, mydate.Month, 1)
        Dim endDate = startDate.AddMonths(1).AddDays(-1)

        lblcMonthI.Text = startDate.ToString("MMMM")
        lblLMonthI.Text = startDate.AddMonths(-1).ToString("MMMM")
        lblcMonth1I.Text = startDate.ToString("MMMM")
        lblLMonth1I.Text = startDate.AddMonths(-1).ToString("MMMM")
        Dim ds As DataSet = CountBLL.MonthlyReport("IndividualCurrentMonthReportByUserID", UID, startDate.ToString("yyyy-MM-dd"))
        If ds.Tables.Count > 0 Then
            lblCMAI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(0)("TeamAchivedSalesMonthCount").ToString())).ToString("N2")
            lblCMSTI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(1).Rows(0)("TeamTargetSalesMonthCount").ToString())).ToString("N2")
            lblCMQTYI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(2).Rows(0)("TeamAchivedQTYMonthCount").ToString())).ToString("N")

            If Not Convert.ToDouble(lblCMAI.Text) = 0.0 Then
                If Not Convert.ToDouble(lblCMSTI.Text) = 0.0 Then
                    lblCMAPI.Text = (Convert.ToDouble(lblCMAI.Text) * 100 / Convert.ToDouble(lblCMSTI.Text)).ToString("N2")
                Else
                    lblCMAPI.Text = "0.00"
                End If
            Else
                lblCMAPI.Text = "0.00"
            End If

            lblLMAI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(3).Rows(0)("LMTeamAchivedSalesMonthCount").ToString())).ToString("N2")
            lblLMSTI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(4).Rows(0)("LMTeamTargetSalesMonthCount").ToString())).ToString("N2")
            lblLMQTYI.Text = Convert.ToDouble(DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(5).Rows(0)("LMTeamAchivedQTYMonthCount").ToString())).ToString("N")

            If Not Convert.ToDouble(lblLMAI.Text) = 0.0 Then
                If Not Convert.ToDouble(lblLMSTI.Text) = 0.0 Then
                    lblLMAPI.Text = (Convert.ToDouble(lblLMAI.Text) * 100 / Convert.ToDouble(lblLMSTI.Text)).ToString("N2")
                Else
                    lblLMAPI.Text = "0.00"
                End If
            Else
                lblLMAPI.Text = "0.00"
            End If


            GrdGroupwiseI.DataSource = ds.Tables(6)
            GrdGroupwiseI.DataBind()

            Dim strScriptI As New StringBuilder()
            strScriptI.Append("<div id='columnchart_material1'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & " google.charts.setOnLoadCallback(drawChart);" & vbCr & vbLf & " function drawChart() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Month', 'Sales Target', 'Achieved']," & vbCr & vbLf & "  ['" & lblcMonthI.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblCMSTI.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblCMAI.Text)).ToString & "]," & vbCr & vbLf & " ['" & lblLMonthI.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblLMSTI.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblLMAI.Text)).ToString & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & "  chart: {" & vbCr & vbLf & " title: 'Individual Sales Performance'" & vbCr & vbLf & "  },colors: ['#ff9900','#109618'], " & vbCr & vbLf & "  height:287," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & "  var chart = new google.charts.Bar(document.getElementById('columnchart_material1'));" & vbCr & vbLf & "  chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            lblsalestargetI.Text = strScriptI.ToString

            Dim strBARScriptI As New StringBuilder()
            strBARScriptI.Append("<div id='barchart_materialI'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & "google.charts.setOnLoadCallback(drawChart1);" & vbCr & vbLf & " function drawChart1() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Group ', 'Sales Target', 'Achieved'],")
            For i As Integer = 0 To ds.Tables(6).Rows.Count - 1
                strBARScriptI.Append(" ['" & ds.Tables(6).Rows(i)("TC_Name") & "', " & ds.Tables(6).Rows(i)("STCD_SalesAmt") & ", " & ds.Tables(6).Rows(i)("TargetSalesAchived") & "],")
            Next
            strBARScriptI.ToString.Remove(strBARScriptI.ToString.LastIndexOf(","), 1)
            strBARScriptI.Append(" ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & " chart: {" & vbCr & vbLf & " title: 'Individual Group Wise Detail'," & vbCr & vbLf & "  },colors: ['#dd4477','#66aa00']," & vbCr & vbLf & " bars: 'horizontal', // Required for Material Bar Charts." & vbCr & vbLf & "  height:260," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & " var chart = new google.charts.Bar(document.getElementById('barchart_materialI'));" & vbCr & vbLf & " chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            lblgrouptargetI.Text = strBARScriptI.ToString

            ''-----------------activity report

            taskPerformI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(7).Rows(0)("taskPerform").ToString())
            taskMissedI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(8).Rows(0)("taskMissed").ToString())
            taskCloseI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(9).Rows(0)("taskClosePostpone").ToString())
            taskTotalI.Text = Convert.ToDouble(Convert.ToInt32(taskPerformI.Text) + Convert.ToInt32(taskMissedI.Text) + Convert.ToInt32(taskCloseI.Text)).ToString

            demoPerformI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(10).Rows(0)("eventPerform").ToString())
            demoMissedI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(11).Rows(0)("eventMissed").ToString())
            demoCloseI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(12).Rows(0)("eventClosePostpone").ToString())
            demoTotalI.Text = Convert.ToDouble(Convert.ToInt32(demoPerformI.Text) + Convert.ToInt32(demoMissedI.Text) + Convert.ToInt32(demoCloseI.Text)).ToString

            phonePerformI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(13).Rows(0)("callPerform").ToString())
            phoneMissedI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(14).Rows(0)("callMissed").ToString())
            phoneCloseI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(15).Rows(0)("callClosePostpone").ToString())
            phoneTotalI.Text = Convert.ToDouble(Convert.ToInt32(phonePerformI.Text) + Convert.ToInt32(phoneMissedI.Text) + Convert.ToInt32(phoneCloseI.Text)).ToString

            totalPerformI.Text = Convert.ToDouble(Convert.ToInt32(taskPerformI.Text) + Convert.ToInt32(demoPerformI.Text) + Convert.ToInt32(phonePerformI.Text)).ToString
            totalkMissedI.Text = Convert.ToDouble(Convert.ToInt32(taskMissedI.Text) + Convert.ToInt32(demoMissedI.Text) + Convert.ToInt32(phoneMissedI.Text)).ToString
            totalCloseI.Text = Convert.ToDouble(Convert.ToInt32(taskCloseI.Text) + Convert.ToInt32(demoCloseI.Text) + Convert.ToInt32(phoneCloseI.Text)).ToString

            totalTotalI.Text = Convert.ToDouble(Convert.ToInt32(totalPerformI.Text) + Convert.ToInt32(totalkMissedI.Text) + Convert.ToInt32(totalCloseI.Text)).ToString



            If (totalTotalI.Text = 0) Then
                pertaskPerformI.Text = "0%"
                pertaskMissedI.Text = "0%"
                pertaskCloseI.Text = "0%"

                pertaskTotalI.Text = "0%"

            Else
                pertaskPerformI.Text = Convert.ToDouble(taskPerformI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                pertaskMissedI.Text = Convert.ToDouble(taskMissedI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                pertaskCloseI.Text = Convert.ToDouble(taskCloseI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"

                pertaskTotalI.Text = Convert.ToDouble(taskTotalI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
            End If

            If (totalTotalI.Text = 0) Then
                perdemoPerformI.Text = "0%"
                perdemoMissedI.Text = "0%"
                perdemoCloseI.Text = "0%"

                perdemoTotalI.Text = "0%"

            Else

                perdemoPerformI.Text = Convert.ToDouble(demoPerformI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                perdemoMissedI.Text = Convert.ToDouble(demoMissedI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                perdemoCloseI.Text = Convert.ToDouble(demoCloseI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"

                perdemoTotalI.Text = Convert.ToDouble(demoTotalI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"

            End If

            If (totalTotalI.Text = 0) Then
                perphonePerformI.Text = "0%"
                perphoneMissedI.Text = "0%"
                perphoneCloseI.Text = "0%"

                perphoneTotalI.Text = "0%"
            Else
                perphonePerformI.Text = Convert.ToDouble(phonePerformI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                perphoneMissedI.Text = Convert.ToDouble(phoneMissedI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                perphoneCloseI.Text = Convert.ToDouble(phoneCloseI.Text / phoneTotalI.Text * 100).ToString("#,##0.00") + "%"

                perphoneTotalI.Text = Convert.ToDouble(phoneTotalI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"


            End If
            If (totalTotalI.Text = 0) Then
                pertotalPerformI.Text = "0%"
                pertotalkMissedI.Text = "0%"
                pertotalCloseI.Text = "0%"
                pertotalTotalI.Text = "0%"
            Else


                pertotalPerformI.Text = Convert.ToDouble(totalPerformI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                pertotalkMissedI.Text = Convert.ToDouble(totalkMissedI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                pertotalCloseI.Text = Convert.ToDouble(totalCloseI.Text / totalTotalI.Text * 100).ToString("#,##0.00") + "%"
                pertotalTotalI.Text = "100%"
            End If
            ''--------------------activity report


            Dim strStackScriptI As New StringBuilder()
            strStackScriptI.Append("<div id='barchart_stack1'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & " google.charts.setOnLoadCallback(drawBasicI);" & vbCr & vbLf & " function drawBasicI() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Activity', 'Perform', 'Missed', 'Close Postpone']," & vbCr & vbLf & "['Task'," & taskPerformI.Text & ", " & taskMissedI.Text & ", " & taskCloseI.Text & "]," & vbCr & vbLf & " ['Sampling/Demo'," & demoPerformI.Text & ", " & demoMissedI.Text & ", " & demoCloseI.Text & "]," & vbCr & vbLf & " ['Phone & Email', " & phonePerformI.Text & ", " & phoneMissedI.Text & ", " & phoneCloseI.Text & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = { title: 'Individual Activity Report',colors: ['#491D72','#BB302D','#CBBE00'],height:225," & vbCr & vbLf & " legend: { position: 'top', maxLines: 1 }," & vbCr & vbLf & " bar: { groupWidth: '75%' }," & vbCr & vbLf & "isStacked:  'percent'," & vbCr & vbLf & " hAxis: {" & vbCr & vbLf & " minValue: 0, ticks: [0, .3, .6, .8, 1]" & vbCr & vbLf & " }" & vbCr & vbLf & " };" & vbCr & vbLf & " var chart = new google.visualization.BarChart(document.getElementById('barchart_stack1'));" & vbCr & vbLf & " chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "</script>")
            lblstackedI.Text = strStackScriptI.ToString


            ''-------------------Conversions / Productivity
            lblCLeadI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(16).Rows(0)("TeamAchivedLeadMonthCount").ToString())
            lblCLeadTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(17).Rows(0)("TeamTargetLeadMonthCount").ToString())
            lblCProspectI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(20).Rows(0)("TeamAchivedProspectMonthCount").ToString())
            lblCProspectTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(21).Rows(0)("TeamTargetProspectMonthCount").ToString())
            lblCAccountI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(24).Rows(0)("TeamAchivedAccountMonthCount").ToString())
            lblCAccountTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(25).Rows(0)("TeamTargetAccountMonthCount").ToString())
            If Not lblCAccountI.Text = "0" And Not lblCProspectI.Text = "0" Then
                lblCProductivityI.Text = Math.Round((Convert.ToInt32(lblCAccountI.Text) / Convert.ToInt32(lblCProspectI.Text)), 2).ToString
            Else
                lblCProductivityI.Text = "0"
            End If
            lblLLeadI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(18).Rows(0)("TeamAchivedLeadMonthCountLM").ToString())
            lblLLeadTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(19).Rows(0)("TeamTargetLeadMonthCountLM").ToString())
            lblLProspectI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(22).Rows(0)("TeamAchivedProspectMonthCountLM").ToString())
            lblLProspectTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(23).Rows(0)("TeamTargetProspectMonthCountLM").ToString())
            lblLAccountI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(26).Rows(0)("TeamAchivedAccountMonthCountLM").ToString())
            lblLAccountTargetI.Text = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(27).Rows(0)("TeamTargetAccountMonthCountLM").ToString())
            If Not lblLAccountI.Text = "0" And Not lblLProspectI.Text = "0" Then
                lblLProductivityI.Text = Math.Round((Convert.ToInt32(lblLAccountI.Text) / Convert.ToInt32(lblLProspectI.Text)), 2).ToString
            Else
                lblLProductivityI.Text = "0"
            End If

            Dim strPieScriptI As New StringBuilder()
            strPieScriptI.Append("<div id='piechart_diff1'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & "  google.charts.setOnLoadCallback(drawChart2);" & vbCr & vbLf & " function drawChart2() {" & vbCr & vbLf & " var oldData = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Productivity', 'Count']," & vbCr & vbLf & " ['Leads', " & lblCLeadI.Text & "]," & vbCr & vbLf & " ['Prospects', " & lblCProspectI.Text & "]," & vbCr & vbLf & " ['Accounts', " & lblCAccountI.Text & "]" & vbCr & vbLf & "]);" & vbCr & vbLf & " var newData = google.visualization.arrayToDataTable([" & vbCr & vbLf & "['Productivity', 'Count']," & vbCr & vbLf & " ['Leads', " & lblLLeadI.Text & "]," & vbCr & vbLf & " ['Prospects', " & lblLProspectI.Text & "]," & vbCr & vbLf & " ['Accounts', " & lblLAccountI.Text & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = {title: 'Individual Conversions / Productivity'," & vbCr & vbLf & " pieSliceText: 'value', " & vbCr & vbLf & " height: '275'," & vbCr & vbLf & " legend: { position: 'top' },colors: ['#243F9A','#BB302D','#F58225']" & vbCr & vbLf & " };" & vbCr & vbLf & " var chartDiff = new google.visualization.PieChart(document.getElementById('piechart_diff1'));" & vbCr & vbLf & " var diffData = chartDiff.computeDiff(oldData, newData);" & vbCr & vbLf & " chartDiff.draw(diffData, options);" & vbCr & vbLf & "}" & vbCr & vbLf & "</script>")
            lblpieI.Text = strPieScriptI.ToString
            ''--------------------Conversions / Productivity

        End If

    End Sub

    Protected Sub btnreport_Click(sender As Object, e As EventArgs) Handles btnreport.Click
        fillST(txtmonth.Text, ddluser.SelectedValue)
        fillSTIndividual(txtmonth.Text, ddluser.SelectedValue)
    End Sub

    Public Sub FillUserName()
        Try
            Dim ds As DataSet = MainBLL.Dropdown("UserDropDown")
            ddluser.DataSource = ds.Tables(0)
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub ExportToImage(sender As Object, e As EventArgs)
        'Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(",")(1)
        'Dim bytes As Byte() = Convert.FromBase64String(base64)
        'Response.Clear()
        'Response.ContentType = "image/png"
        'Response.AddHeader("Content-Disposition", "attachment; filename=HTML.png")
        'Response.Buffer = True
        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.BinaryWrite(bytes)
        'Response.End()

        Dim base64 As String = Request.Form(hfImageData.UniqueID).Split(","c)(1)
        Dim bytes As Byte() = Convert.FromBase64String(base64)
        File.WriteAllBytes(Server.MapPath("~/images/" + ddluser.SelectedItem.Text + ".png"), bytes)


        'Dim pdfpath As String = Server.MapPath("Images")
        Dim imagepath As String = Server.MapPath("Images")
        'Dim doc As New Document()
        'Try
        '    PdfWriter.GetInstance(doc, New FileStream(pdfpath & Convert.ToString("/Images.pdf"), FileMode.Create))
        '    doc.Open()

        '    Dim gif As Image = Image.GetInstance(imagepath & Convert.ToString("/Tahir.png"))
        '    doc.Add(gif)
        '    'Log error;
        'Catch ex As Exception
        'Finally
        '    doc.Close()
        'End Try

        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=" + ddluser.SelectedItem.Text + ".pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Dim sw As New StringWriter()
        'Dim hw As New HtmlTextWriter(sw)
        'Me.Page.RenderControl(hw)
        'Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 45.0F, 25.0F, 25.0F, 10.0F)
        'Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        Dim gif As Image = Image.GetInstance(imagepath & Convert.ToString("/" + ddluser.SelectedItem.Text + ".png"))
        gif.SetDpi(300, 300)
        gif.ScalePercent(29.0F)
        pdfDoc.Add(gif)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()

    End Sub
End Class
