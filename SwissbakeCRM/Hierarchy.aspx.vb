
Partial Class Hierarchy
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            fillReportingTo()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub fillReportingTo()
        Try
            Dim ds As DataSet = UserBLL.ReportingTo("ReportingTo")
            'Dim strScriptI As New StringBuilder()
            'strScriptI.Append("<div id='columnchart_material1'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & " google.charts.setOnLoadCallback(drawChart);" & vbCr & vbLf & " function drawChart() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Month', 'Sales Target', 'Achieved']," & vbCr & vbLf & "  ['" & lblcMonthI.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblCMSTI.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblCMAI.Text)).ToString & "]," & vbCr & vbLf & " ['" & lblLMonthI.Text & "', " & Convert.ToInt32(Convert.ToDouble(lblLMSTI.Text)).ToString & ", " & Convert.ToInt32(Convert.ToDouble(lblLMAI.Text)).ToString & "]" & vbCr & vbLf & " ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & "  chart: {" & vbCr & vbLf & " title: 'Individual Sales Performance'" & vbCr & vbLf & "  },colors: ['#ff9900','#109618'], " & vbCr & vbLf & "  height:287," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & "  var chart = new google.charts.Bar(document.getElementById('columnchart_material1'));" & vbCr & vbLf & "  chart.draw(data, options);" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            'lblsalestargetI.Text = strScriptI.ToString

            Dim strBARScriptI As New StringBuilder()
            strBARScriptI.Append("<div id='barchart_materialI'></div>" & vbCr & vbLf & "<script type='text/javascript'>" & vbCr & vbLf & "google.charts.load('current', {packages:[""orgchart""]});" & vbCr & vbLf & "google.charts.setOnLoadCallback(drawChart1);" & vbCr & vbLf & " function drawChart1() {" & vbCr & vbLf & " var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & " ['Name ', 'Manager', 'Tooltip'],")
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'strBARScriptI.Append(" ['" & ds.Tables(0).Rows(i)("EMP") & "', " & ds.Tables(0).Rows(i)("ReportingTo") & ", " & ds.Tables(0).Rows(i)("Designation") & "],")
                strBARScriptI.Append(" [{v:'" & ds.Tables(0).Rows(i)("EMP") & "', f:'" & ds.Tables(0).Rows(i)("EMP") & "<div style=""color:red; font-style:italic"">" & ds.Tables(0).Rows(i)("Designation") & "</div>'},'" & ds.Tables(0).Rows(i)("ReportingTo") & "', '" & ds.Tables(0).Rows(i)("Designation") & "'],")
                'Faisal', 'BDM']")
            Next
            strBARScriptI.ToString.Remove(strBARScriptI.ToString.LastIndexOf(","), 1)
            strBARScriptI.Append(" ]);" & vbCr & vbLf & " var options = {" & vbCr & vbLf & " chart: {" & vbCr & vbLf & " title: 'Individual Group Wise Detail'," & vbCr & vbLf & "  },colors: ['#dd4477','#66aa00']," & vbCr & vbLf & " bars: 'horizontal', // Required for Material Bar Charts." & vbCr & vbLf & "  height:260," & vbCr & vbLf & " bar: { groupWidth: '95%' }," & vbCr & vbLf & "  chartArea: { width: '100%', height: '100%' }," & vbCr & vbLf & " legend: { position: 'in' }," & vbCr & vbLf & " titlePosition:  'in', axisTitlesPosition: 'in'," & vbCr & vbLf & " hAxis: { textPosition: 'in' }, vAxis: { textPosition: 'in' , format: 'decimal'}" & vbCr & vbLf & "  };" & vbCr & vbLf & " var chart = new google.visualization.OrgChart(document.getElementById('barchart_materialI'));" & vbCr & vbLf & " chart.draw(data, {allowHtml:true});" & vbCr & vbLf & " }" & vbCr & vbLf & "  </script>")
            lblgrouptargetI.Text = strBARScriptI.ToString

        Catch ex As Exception

        End Try
    End Sub
End Class
