Imports DynamicparcelEnumerations
Partial Class ModifyCampaign
    Inherits System.Web.UI.Page
    Dim Mainid As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Campaign.aspx")
                If Request.QueryString("chk") = "v" Then
                    txtbudget.ReadOnly = True
                    txtenddate.ReadOnly = True
                    txtlead.ReadOnly = True
                    btnadd.Visible = False
                    Button1.Visible = False
                    ddcampaign_type.CssClass = "form-control"
                    txtremark.ReadOnly = True
                    txtstartdate.ReadOnly = True
                    txttitle.ReadOnly = True
                    ddcampaign_type.Enabled = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCampaign", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        Else
            Try
                If (Request.QueryString("Id") = Nothing) Then
                    Response.Redirect("index.aspx")
                End If
                DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Campaign.aspx")
                If Request.QueryString("chk") = "v" Then
                    txtbudget.ReadOnly = True
                    txtenddate.ReadOnly = True
                    txtlead.ReadOnly = True
                    btnadd.Visible = False
                    Button1.Visible = False
                    ddcampaign_type.CssClass = "form-control"
                    txtremark.ReadOnly = True
                    txtstartdate.ReadOnly = True
                    txttitle.ReadOnly = True
                    ddcampaign_type.Enabled = False
                End If
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCampaign", "Page_Init", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
         End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
        If Not IsPostBack Then
            Try
                Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                fillCampaignType()
                If Mainid = "0" Then
                    modifyspan.Visible = False
                Else
                    modifyspan.Visible = True
                    FillDetail()
                    End If
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCampaign", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    
    Public Sub fillCampaignType()
        Try
            ddcampaign_type.DataSource = MainBLL.Dropdown("CampaignDropDown")
            ddcampaign_type.DataTextField = "CampaignType_Name"
            ddcampaign_type.DataValueField = "CampaignType_Id"
            ddcampaign_type.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCampaign", "fillCampaignType", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Mainid, "CampaignViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddcampaign_type.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_TypeId").ToString())
            txttitle.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_Name").ToString())
            txtbudget.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_Invest").ToString())
            txtenddate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_EndDate").ToString())
            txtlead.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_NoOfLead").ToString())
            txtremark.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_Remark").ToString())
            txtstartdate.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Campaign_StartDate").ToString())
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drLogin("Campaign_ModifiedDate").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("ModfName").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCampaign", "FillDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    CampaignBLL.Update(Mainid, txttitle.Text, ddcampaign_type.SelectedValue, txtstartdate.Text, txtenddate.Text, txtbudget.Text, txtlead.Text, Session("UserId"), txtremark.Text, Session("UserId"), Session("Audlog_Id"))
                    Response.Redirect("Campaign.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Campaign", "update", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If String.IsNullOrEmpty(txtlead.Text) Then
                        txtlead.Text = "0"
                    End If
                    CampaignBLL.Insert(ddcampaign_type.SelectedValue, txttitle.Text, txtstartdate.Text, txtenddate.Text, txtbudget.Text, txtlead.Text, Session("UserId"), txtremark.Text, Session("UserId"), Session("UserId"), Session("Audlog_Id"))

                    Response.Redirect("Campaign.aspx")
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Campaign", "insert", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
        Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If Mainid = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        ElseIf Mainid > 0 Then
            SaveProduct(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Campaign", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
