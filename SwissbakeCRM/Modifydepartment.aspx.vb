Imports DynamicparcelEnumerations
Partial Class Modifydepartment
    Inherits System.Web.UI.Page
    Dim SCid As Integer
    Dim path3 As String
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
            If Request.QueryString("chk") = "v" Then
                txtdepartname.ReadOnly = True
                btnadd.Visible = False
            End If
        Else
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
            If Request.QueryString("chk") = "v" Then
                txtdepartname.ReadOnly = True
                btnadd.Visible = False
            End If
        End If
        End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                SCid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If SCid = "0" Then
                    divdate.Visible = False
                Else
                    FillDetail()
                End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    'DepartmentBLL.Update(txtdepartname.Text, Session("UserId"))
                    Response.Redirect("department.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    'DepartmentBLL.Insert(txtdepartname.Text.Trim, Session("UserId"), Session("UserId"))
                    Response.Redirect("department.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        SCid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If SCid = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        ElseIf SCid > 0 Then
            SaveProduct(DML_OPERATION.UPDATE)
        End If
    End Sub

    Public Sub FillDetail()
        Try
            SCid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(SCid, "DepartmentViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txtdepartname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Deprt_DeptName").ToString())
            txtcreatedate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Deprt_CreatedDate").ToString())
            txtmodifieddate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Deprt_ModifiedDate").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
