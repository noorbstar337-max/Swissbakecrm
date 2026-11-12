Imports System.Drawing

Partial Class ProductAccounts
    Inherits _PageBaseClass
    Dim ProductID As Integer
    Dim StartDate As String
    Dim EndDate As String


    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                GridView1.AllowCustomPaging = True
                fillAccount()
            End If

            
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Lead", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillAccount()
        Try
            ProductID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            StartDate = Request.QueryString("Sdate")
            EndDate = Request.QueryString("Edate")

            If String.IsNullOrEmpty(DynamicparcelDataManipulation.DateFormat(StartDate)) And String.IsNullOrEmpty(DynamicparcelDataManipulation.DateFormat(EndDate)) Then
                GridView1.DataSource = reportBLL.productaccount(ProductID)
                GridView1.DataBind()
            Else
                GridView1.DataSource = reportBLL.productaccountdate(ProductID, DynamicparcelDataManipulation.DateFormat(StartDate), DynamicparcelDataManipulation.DateFormat(EndDate))
                GridView1.DataBind()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("TopProduct", "fillProduct", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            ProductID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            StartDate = Request.QueryString("Sdate")
            EndDate = Request.QueryString("Edate")

            If String.IsNullOrEmpty(DynamicparcelDataManipulation.DateFormat(StartDate)) And String.IsNullOrEmpty(DynamicparcelDataManipulation.DateFormat(EndDate)) Then
                GridView1.DataSource = reportBLL.productaccount(ProductID)
                GridView1.DataBind()
            Else
                GridView1.DataSource = reportBLL.productaccountdate(ProductID, DynamicparcelDataManipulation.DateFormat(StartDate), DynamicparcelDataManipulation.DateFormat(EndDate))
                GridView1.DataBind()
            End If

            GridView1.RenderControl(hw)

            'style to format numbers to string 
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ProductAccounts", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            ' Throw ex
        End Try
    End Sub
End Class
