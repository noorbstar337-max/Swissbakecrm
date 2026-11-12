Imports DynamicparcelEnumerations
Partial Class ModifyCampaign
    Inherits System.Web.UI.Page
    Dim Mainid As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Try
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("CRMindex.aspx")
            End If
            CheckPrivilage()
            'DynamicparcelGridview.CheckPrivilageForModify(Session("UserRoleID"), Button1, btnadd, "Campaign.aspx")
            If Request.QueryString("chk") = "v" Then

                btnadd.Visible = False
                Button1.Visible = False
                ddlacc.CssClass = "form-control"
                ddlacc.Enabled = False
                ddluser.CssClass = "form-control"
                ddluser.Enabled = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwner", "Page_Init", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='CRMindex.aspx';", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            If Not IsPostBack Then

                Try

                    Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))

                    fillAccount()
                    fillUser()
                    FillDetail()

                    Dim script As String =
"$(window).on('load', function () {" &
"$('#" & ddluser.ClientID & "').multiselect({" &
"includeSelectAllOption:true," &
"enableFiltering:true," &
"enableCaseInsensitiveFiltering:true," &
"filterPlaceholder:'Search Owner'," &
"buttonWidth:'100%'," &
"nonSelectedText:'Select Owner'," &
"maxHeight:300" &
"});" &
"$('.multiSelect').next('.btn-group').prev().hide();" &
"});"

                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "MultiSelect", script, True)

                Catch ex As Exception
                    Response.Redirect("CRMindex.aspx")
                End Try

            End If

        Catch ex As Exception

            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            ExecptionBLL.Insert("AccountOwner", "Page_Load", error1, Session("UserId"))

            ScriptManager.RegisterStartupScript(Page, Me.GetType(), "Call", "alert('" & error1 & "')", True)

        End Try
    End Sub


    Public Sub fillAccount()
        Try
            ddlacc.DataSource = MainBLL.DropdownWithtype("ALLAccountDropDown", "Account")
            ddlacc.DataTextField = "Acc_Name"
            ddlacc.DataValueField = "Acc_Id"
            ddlacc.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwner", "fillAccount", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub fillUser()
        Try
            ddluser.DataSource = MainBLL.Dropdown("UserDropDown")
            ddluser.DataTextField = "U_FirstName"
            ddluser.DataValueField = "U_ID"
            ddluser.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwner", "fillUser", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Mainid, "Accountowner")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddlacc.SelectedValue = Mainid
            ddlacc.CssClass = "form-control"
            ddlacc.Enabled = False

            'Clear previous selections
            For Each li As ListItem In ddluser.Items
                li.Selected = False
            Next

            'Get all assigned owners
            Dim dsOwner As DataSet = AccountBLL.GetAssignedOwner(Mainid)

            If dsOwner IsNot Nothing AndAlso dsOwner.Tables.Count > 0 Then

                For Each dr As DataRow In dsOwner.Tables(0).Rows
                    'Response.Write("OwnerID = " & dr("Assignto_UserID").ToString() & "<br/>")

                    Dim li As ListItem = ddluser.Items.FindByValue(dr("Assignto_UserID").ToString())

                    If li IsNot Nothing Then
                        li.Selected = True
                    End If
                Next
            End If
            'ddluser.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Acc_OwnerID").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwner", "FillDetail", error1, Session("UserId"))
            ' ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    'Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
    '    Select Case enumOperation
    '        Case DML_OPERATION.UPDATE
    '            Try
    '                ' AccountBLL.UpdateOwner(Mainid, ddluser.SelectedValue, Session("Audlog_Id"))
    '                For Each li As ListItem In ddluser.Items
    '                    Response.Write(li.Text & " = " & li.Selected & "<br/>")
    '                    If li.Selected Then
    '                        AccountBLL.UpdateOwner(Mainid, Convert.ToInt32(li.Value), Session("Audlog_Id"))
    '                    End If
    '                Next
    '                Response.Redirect("AccountOwnerlist.aspx")
    '            Catch ex As Exception
    '                Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '                error1 = error1.Replace(Chr(39), "")
    '                ExecptionBLL.Insert("AccountOwner", "update", error1, Session("UserId"))
    '                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '            End Try
    '    End Select
    'End Sub
    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)

        Select Case enumOperation

            Case DML_OPERATION.UPDATE

                Try

                    'Clear existing Account owners
                    AccountBLL.ClearAccountOwners(Mainid)

                    Dim FirstOwner As Boolean = True

                    For Each li As ListItem In ddluser.Items

                        If li.Selected Then

                            AccountBLL.UpdateOwner(Mainid, Convert.ToInt32(li.Value), Session("Audlog_Id"))

                            FirstOwner = False

                        End If

                    Next

                    Response.Redirect("AccountOwnerlist.aspx")

                Catch ex As Exception

                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                    error1 = error1.Replace(Chr(39), "")

                    ExecptionBLL.Insert("AccountOwner", "update", error1, Session("UserId"))

                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call",
                    "alert('" + error1 + "')", True)

                End Try

        End Select

    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            SaveProduct(DML_OPERATION.UPDATE)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AccountOwner", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Public Sub CheckPrivilage()
        If Not Session("UserRoleID") = 1 Then
            Throw New Exception("You don't have right to view this page\n Please contact admin!")
        End If
    End Sub

End Class
