#region " [ Using ] "
using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
#endregion


public partial class frmPieChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Bind Gridview
            BindGvData();

            // Bind Charts
            BindChart();
        }
    }

    private void BindGvData()
    {
        gvData.DataSource = GetChartData();
        gvData.DataBind();
    }


    private void BindChart()
    {
        DataTable dsChartData = new DataTable();
        StringBuilder strScript = new StringBuilder();

        try
        {
            dsChartData = GetChartData();

            strScript.Append(@"<script type='text/javascript'>
                    google.load('visualization', '1', {packages: ['corechart']}); </script>
                    
                    <script type='text/javascript'>
                   
                    function drawChart() {       
                    var data = google.visualization.arrayToDataTable([
                    ['Task', 'Hours of Day'],");

            foreach (DataRow row in dsChartData.Rows)
            {
                strScript.Append("['" + row["Task"] + "'," + row["Hours"] + "],");
            }
            strScript.Remove(strScript.Length - 1, 1);
            strScript.Append("]);");

            strScript.Append(@" var options = {   
                                    title: 'My Daily Schedule',          
                                    is3D: true,        
                                    };   ");

            strScript.Append(@"var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));        
                                chart.draw(data, options);      
                                }  
                            google.setOnLoadCallback(drawChart);
                            ");
            strScript.Append(" </script>");

            ltScripts.Text = strScript.ToString();
        }
        catch
        {
        }
        finally
        {
            dsChartData.Dispose();
            strScript.Clear();
        }
    }

    /// <summary>
    /// fetch data from mdf file saved in app_data
    /// </summary>
    /// <returns>DataTable</returns>
    private DataTable GetChartData()
    {
        DataSet dsData = new DataSet();
        try
        {
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            SqlDataAdapter sqlCmd = new SqlDataAdapter("GetPieChartData", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;

            sqlCon.Open();

            sqlCmd.Fill(dsData);

            sqlCon.Close();
        }
        catch
        {
            throw;
        }
        return dsData.Tables[0];
    }
}