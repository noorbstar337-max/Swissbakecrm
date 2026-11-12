
Partial Class Reports_DashBoard
    Inherits System.Web.UI.Page



    Private Sub BindChart()
        Dim dsChartData As New DataTable()
        Dim strScript As New StringBuilder()

        Try
            dsChartData = DashBoardBLL.ViewById("LeadByIndustry", "", DateTime.Now.ToString(), DateTime.Now.ToString())

            strScript.Append("<script type='text/javascript'>" & vbCr & vbLf & "                    google.load('visualization', '1', {packages: ['corechart']});</script>" & vbCr & vbLf & vbCr & vbLf & "                    <script type='text/javascript'>" & vbCr & vbLf & "                    function drawVisualization() {       " & vbCr & vbLf & "                    var data = google.visualization.arrayToDataTable([" & vbCr & vbLf & "                    ['lead_id', 'Industry_Name', 'Ecuador', 'Madagascar', 'Average'],")

            For Each row As DataRow In dsChartData.Rows
                strScript.Append("['" + row("lead_id").ToString + "'," + row("Industry_Name").ToString + "],")
            Next
            strScript.Remove(strScript.Length - 1, 1)
            strScript.Append("]);")

            strScript.Append("var options = { title : 'lead_idly Coffee Production by Country', vAxis: {title: 'Cups'},  hAxis: {title: 'lead_id'}, seriesType: 'bars', series: {3: {type: 'area'}} };")
            strScript.Append(" var chart = new google.visualization.ComboChart(document.getElementById('chart_div'));  chart.draw(data, options); } google.setOnLoadCallback(drawVisualization);")
            strScript.Append(" </script>")

            ltScripts.Text = strScript.ToString()
        Catch
        Finally
            dsChartData.Dispose()
            strScript.Clear()
        End Try
    End Sub


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        BindChart()
    End Sub
End Class
