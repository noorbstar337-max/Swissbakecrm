<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VBCode.aspx.vb" Inherits="VBCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>jQuery Google Pie Chart Example in asp.net</title>
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://www.google.com/jsapi" type="text/javascript"></script>
    <script type="text/javascript">
        // Global variable to hold data
        google.load('visualization', '1', { packages: ['corechart'] });
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                url: 'VBCode.aspx/GetChartData',
                data: '{}',
                success:
                    function (response) {
                        drawchart(response.d);
                    },

                error: function () {
                    alert("Error loading data! Please try again.");
                }
            });
        })
        function drawchart(dataValues) {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Column Name');
            data.addColumn('number', 'Column Value');
            for (var i = 0; i < dataValues.length; i++) {
                data.addRow([dataValues[i].Industry_Name, dataValues[i].lead_id]);
            }

           //  Donut Parameter
            var options = {
                title: 'My Daily Activities',
                pieHole: 0.4,
            };

          
            var chart = new google.visualization.PieChart(document.getElementById('chartdiv'));
            chart.draw(data, options);

            new google.visualization.PieChart(document.getElementById('chartdiv')).
                draw(data, options);
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="chartdiv" style="width: 600px; height: 350px;">
    </div>
    </form>
</body>
</html>