Imports DynamicparcelEnumerations

Partial Class Opportunity
    Inherits System.Web.UI.Page
    Dim MainID As Integer
    Dim Type As String
    Dim TypeID As Integer
    Dim SourceType As String
    Dim SourceTypeId As Integer
    Dim returnurl As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Session("UserId") = Nothing Then
                TryCast(Me.Master, MainPage).MaintainSession()
                If Not IsPostBack Then
                    If (Request.QueryString("Id") = Nothing) Then
                        Response.Redirect("index.aspx")
                    Else
                        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                        assigncontrol.Uhftype.Value = "Opportunity"
                        assigncontrol.Uhftypeid.Value = MainID
                        FillOwner()
                        FillSource()
                        FillStage()
                        ddstage_TextChanged(Nothing, Nothing)
                        If MainID = 0 Then
                            lbltitle1.Text = "New Opportunity"
                            lbltitle2.Text = "New Opportunity"
                            ddowner.SelectedValue = Session("UserId")
                            itemdtcontrol.Visible = False
                        Else
                            FillDetail()
                            lbltitle1.Text = "Modify Opportunity"
                            lbltitle2.Text = "Modify Opportunity"
                            itemdtcontrol.Visible = True
                            itemdtcontrol.Uhftype.Value = hftype.Value
                            itemdtcontrol.Uhftypeid.Value = hftypeid.Value
                            itemdtcontrol.Uhfopptype.Value = "Opportunity"
                            itemdtcontrol.Uhfopptypeid.Value = MainID
                            ddtype.Enabled = False
                            ddtypeid.Enabled = False
                            ddtypeid.CssClass = "form-control"
                        End If
                    End If
                End If
            Else
                If Not IsPostBack Then
                    If (Request.QueryString("Id") = Nothing) Then
                        Response.Redirect("index.aspx")
                    Else
                        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                        assigncontrol.Uhftype.Value = "Opportunity"
                        assigncontrol.Uhftypeid.Value = MainID
                        FillOwner()
                        FillSource()
                        FillStage()
                        ddstage_TextChanged(Nothing, Nothing)
                        If MainID = 0 Then
                            lbltitle1.Text = "New Opportunity"
                            lbltitle2.Text = "New Opportunity"
                            ddowner.SelectedValue = Session("UserId")
                            itemdtcontrol.Visible = False
                        Else
                            FillDetail()
                            lbltitle1.Text = "Modify Opportunity"
                            lbltitle2.Text = "Modify Opportunity"
                            itemdtcontrol.Visible = True
                            itemdtcontrol.Uhftype.Value = hftype.Value
                            itemdtcontrol.Uhftypeid.Value = hftypeid.Value
                            itemdtcontrol.Uhfopptype.Value = "Opportunity"
                            itemdtcontrol.Uhfopptypeid.Value = MainID
                            ddtype.Enabled = False
                            ddtypeid.Enabled = False
                            ddtypeid.CssClass = "form-control"
                        End If
                    End If
                End If
            End If
            Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillOwner()
        Try
            ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
            ddowner.DataTextField = "U_FirstName"
            ddowner.DataValueField = "U_ID"
            ddowner.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "FillOwner", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillStage()
        Try
            ddstage.DataSource = MainBLL.Dropdown("OpporStageDropDown")
            ddstage.DataTextField = "OppStage_Name"
            ddstage.DataValueField = "OppStage_ID"
            ddstage.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "FillStage", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddsourcetype_TextChanged(sender As Object, e As EventArgs) Handles ddsourcetype.TextChanged

    End Sub

    Protected Sub ddtype_TextChanged(sender As Object, e As EventArgs) Handles ddtype.TextChanged
        Try
            If ddtype.SelectedValue = "Account" Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Account")
                End If
                ddtypeid.DataSource = ds
                ddtypeid.DataTextField = "Acc_Name"
                ddtypeid.DataValueField = "Acc_Id"
                ddtypeid.DataBind()
                If ddtypeid.Items.Count >= 1 Then
                Else
                    ddtype.SelectedValue = "None"
                    ddtypeid.DataSource = ""
                    ddtypeid.DataBind()
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No account found").ToString + "')", True)
                End If
            ElseIf ddtype.SelectedValue = "Prospect" Then
                Dim ds As DataSet
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    ds = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Prospect", Session("UserId"))
                Else
                    ds = MainBLL.DropdownWithtype("EditAccountDropDown", "Prospect")
                End If
                ddtypeid.DataSource = ds
                ddtypeid.DataTextField = "Acc_Name"
                ddtypeid.DataValueField = "Acc_Id"
                ddtypeid.DataBind()
                If ddtypeid.Items.Count >= 1 Then
                Else
                    ddtype.SelectedValue = "None"
                    ddtypeid.DataSource = ""
                    ddtypeid.DataBind()
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No prospect found").ToString + "')", True)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "ddtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSource()
        Try
            ddsourcetypeid.DataSource = MainBLL.Dropdown("SourceDropDown")
            ddsourcetypeid.DataTextField = "Source_Name"
            ddsourcetypeid.DataValueField = "Source_Id"
            ddsourcetypeid.DataBind()
            'ddlsource.Items.Insert(0, New ListItem("Select Source", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "FillSource", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Select Case enumOperation
            Case DML_OPERATION.UPDATE
                Try
                    If ddtype.SelectedValue = "None" Then
                        Type = "None"
                        TypeID = 0
                    Else
                        Type = ddtype.SelectedValue
                        TypeID = ddtypeid.SelectedValue
                    End If
                    If ddsourcetype.SelectedValue = "Other" Then
                        SourceTypeId = 0
                        SourceType = "Other"
                    Else
                        SourceTypeId = ddsourcetypeid.SelectedValue
                        SourceType = "Other"
                    End If
                    If txtamount.Text = "" Then
                        txtamount.Text = 0
                    End If
                    OpportunityBLL.Update(ddowner.SelectedValue, txtname.Text.Trim, txtnextstep.Text.Trim, txtdec.Text.Trim, txtduedate.Text.Trim,
                   SourceTypeId, SourceType, Type, TypeID, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), MainID, txtamount.Text)
                    assigncontrol.AddAssignTo(MainID)
                    If hfcheckstageid.Value = ddstage.SelectedValue Then
                    Else
                        OpporStageHistoryBLL.Insert(txtduedate.Text, "Opportunity", MainID, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), txtamount.Text)
                    End If
                    'assigncontrol.AddAssignTo(MainID)

                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                    Response.Redirect(returnurl)
                   
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Opportunity", "UPDATE", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
            Case DML_OPERATION.INSERT
                Try
                    If ddtype.SelectedValue = "None" Then
                        Type = "None"
                        TypeID = 0
                    Else
                        Type = ddtype.SelectedValue
                        TypeID = ddtypeid.SelectedValue
                    End If
                    If ddsourcetype.SelectedValue = "Other" Then
                        SourceTypeId = 0
                        SourceType = "Other"
                    Else
                        SourceTypeId = ddsourcetypeid.SelectedValue
                        SourceType = "Other"
                    End If
                    If txtamount.Text = "" Then
                        txtamount.Text = 0
                    End If
                    MainID = OpportunityBLL.Insert(ddowner.SelectedValue, txtname.Text.Trim, txtnextstep.Text.Trim, txtdec.Text.Trim, txtduedate.Text.Trim,
                    SourceTypeId, SourceType, Type, TypeID, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), txtamount.Text)
                    OpporStageHistoryBLL.Insert(txtduedate.Text, "Opportunity", MainID, ddstage.SelectedValue, Session("Audlog_Id"), Session("UserId"), txtamount.Text)
                    assigncontrol.AddAssignTo(MainID)
                    'assigncontrol.AddAssignTo(MainID)
                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                    Response.Redirect(returnurl)
                Catch ex As Exception
                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")
                    ExecptionBLL.Insert("Opportunity", "INSERT", error1, Session("UserId"))
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
                End Try
        End Select
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
        MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
        If MainID = 0 Then
            SaveProduct(DML_OPERATION.INSERT)
        Else
            SaveProduct(DML_OPERATION.UPDATE)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(MainID, "OpporViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            txtname.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Name").ToString())
            ddtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Type").ToString())
            ddtype_TextChanged(Nothing, Nothing)
            ddtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_TypeId").ToString())
            ddsourcetype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_SourceType").ToString())
            ddsourcetype_TextChanged(Nothing, Nothing)
            ddsourcetypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_SourceId").ToString())
            ddstage.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_StageId").ToString())
            hfcheckstageid.Value = ddstage.SelectedValue
            ddstage_TextChanged(Nothing, Nothing)
            txtduedate.Text = DynamicparcelDataManipulation.DateFormat(drLogin("Opportunity_ExpectedDate").ToString())
            txtnextstep.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_NextType").ToString())
            txtamount.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Amount").ToString())
            txtdec.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Desc").ToString())
            ddowner.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Owner").ToString())
            hftype.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_Type").ToString())
            hftypeid.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Opportunity_TypeId").ToString())
            txtrevenue.Text = Math.Round(CDbl(DynamicparcelDataManipulation.FixNullFromDB(drLogin("Revenue").ToString())), 2)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub ddstage_TextChanged(sender As Object, e As EventArgs) Handles ddstage.TextChanged
        Try
        lbprobability.Text = OpportunityBLL.GetProbability(ddstage.SelectedValue) + "%"
        divprogress.Style("width") = lbprobability.Text
        divprogress.InnerHtml = lbprobability.Text
        lbprobability.Text = lbprobability.Text.Replace("%", "")
        If lbprobability.Text >= 0 And lbprobability.Text <= 20 Then
            divprogress.Attributes("class") = "progress-bar progress-bar-danger"
        ElseIf lbprobability.Text >= 20 And lbprobability.Text <= 40 Then
            divprogress.Attributes("class") = "progress-bar progress-bar-warning"
        ElseIf lbprobability.Text >= 40 And lbprobability.Text <= 60 Then
            divprogress.Attributes("class") = "progress-bar progress-bar-info"
        ElseIf lbprobability.Text >= 60 Then
            divprogress.Attributes("class") = "progress-bar progress-bar-success"
        End If
            txtrevenue.Text = (lbprobability.Text * txtamount.Text) / 100
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "ddstage_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub txtamount_TextChanged(sender As Object, e As EventArgs) Handles txtamount.TextChanged
        Try
            txtrevenue.Text = (lbprobability.Text * txtamount.Text) / 100
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "txtamount_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
            If Request.QueryString("chk") = "e" Then
                Response.Redirect(returnurl)
                'Response.Redirect("ViewOpportunity.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(MainID.ToString())))
            Else
                Response.Redirect("MainOpportunity.aspx")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("Opportunity", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
