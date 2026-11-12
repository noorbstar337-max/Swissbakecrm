
Partial Class UserControl_Back_PageUrlControl
    Inherits System.Web.UI.UserControl
#Region "Control Property"
    Public Property UtxtStatic() As TextBox
        Get
            Return Me.txtstaticurl
        End Get
        Set(value As TextBox)
            Me.txtstaticurl = value
        End Set
    End Property
    Public Property UddPage() As DropDownList
        Get
            Return Me.ddpageurl
        End Get
        Set(value As DropDownList)
            Me.ddpageurl = value
        End Set
    End Property

    Public Property UddPageSeo() As DropDownList
        Get
            Return Me.ddpageseo
        End Get
        Set(value As DropDownList)
            Me.ddpageseo = value
        End Set
    End Property

   Public Property Uckpagelist() As RadioButtonList
        Get
            Return Me.ckpagelist
        End Get
        Set(value As RadioButtonList)
            Me.ckpagelist = value
        End Set
    End Property

    Public Property UckSeoList() As RadioButtonList
        Get
            Return Me.rdpagetype
        End Get
        Set(value As RadioButtonList)
            Me.rdpagetype = value
        End Set
    End Property
#End Region
   

    Public Sub FillPageUrl()
        Try
            Dim ds As DataSet
            ds = MainBLL.Dropdown("PageDropDown")
            ddpageurl.DataSource = ds.Tables(0)
            ddpageurl.DataTextField = "Page_SeoUrl"
            ddpageurl.DataValueField = "Page_SeoUrl"
            ddpageurl.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "FillPageUrl", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillPageSeoUrl()
        Try
            Dim ds As DataSet
            ds = MainBLL.Dropdown("PageSeoDropDown")
            ddpageseo.DataSource = ds.Tables(0)
            ddpageseo.DataTextField = "PSeo_PageName"
            ddpageseo.DataValueField = "PSeo_SeoUrl"
            ddpageseo.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "FillPageSeoUrl", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ckpagelist_TextChanged(sender As Object, e As EventArgs) Handles ckpagelist.TextChanged
        Try
            CheckUrlType()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "ckpagelist_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                If Request.QueryString("MenuId") = Nothing Then
                Else
                    'FillMenu()
                    FillPageUrl()
                    FillPageSeoUrl()
                    ddpageurl.Items.Insert(0, ("Select Page url"))
                    ddpageseo.Items.Insert(0, ("Select Page Seo url"))
                    If Request.QueryString("chk") = "v" Then
                        ckpagelist.Enabled = False
                        ddpageurl.Enabled = False
                        txtstaticurl.ReadOnly = True
                        ddpageseo.Enabled = False
                    End If
                    Dim MenuId As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("MenuId")))
                    If MenuId = 0 Then
                    Else
                        CheckUrlType()
                        If ddpageseo.SelectedValue = "Select Page Seo url" Then
                            rdpagetype.SelectedValue = "Page"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        ElseIf ddpageurl.SelectedValue = "Select Page url" Then
                            rdpagetype.SelectedValue = "PageSeo"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        End If

                    End If
                End If
                If Request.QueryString("MfId") = Nothing Then
                Else
                    'FillMenuFooter()
                    FillPageUrl()
                    FillPageSeoUrl()
                    ddpageurl.Items.Insert(0, ("Select Page url"))
                    ddpageseo.Items.Insert(0, ("Select Page Seo url"))
                    If Request.QueryString("chk") = "v" Then
                        ckpagelist.Enabled = False
                        ddpageseo.Enabled = False
                        ddpageurl.Enabled = False
                        txtstaticurl.ReadOnly = True
                    End If
                    Dim MenuId As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("MfId")))
                    If MenuId = 0 Then
                    Else
                        CheckUrlType()
                        If ddpageseo.SelectedValue = "Select Page Seo url" Then
                            rdpagetype.SelectedValue = "Page"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        ElseIf ddpageurl.SelectedValue = "Select Page url" Then
                            rdpagetype.SelectedValue = "PageSeo"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        End If
                    End If
                End If

                If Request.QueryString("MenuItemId") = Nothing Then
                Else
                    FillPageUrl()
                    FillPageSeoUrl()
                    ddpageurl.Items.Insert(0, ("Select Page url"))
                    ddpageseo.Items.Insert(0, ("Select Page Seo url"))
                    If Request.QueryString("chk") = "v" Then
                        ckpagelist.Enabled = False
                        ddpageseo.Enabled = False
                        ddpageurl.Enabled = False
                        txtstaticurl.ReadOnly = True
                    End If
                    Dim MenuId As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("MenuItemId")))
                    If MenuId = 0 Then
                    Else
                        CheckUrlType()
                        If ddpageseo.SelectedValue = "Select Page Seo url" Then
                            rdpagetype.SelectedValue = "Page"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        ElseIf ddpageurl.SelectedValue = "Select Page url" Then
                            rdpagetype.SelectedValue = "PageSeo"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        End If
                    End If
                End If

                If Request.QueryString("MifId") = Nothing Then
                Else
                    FillPageUrl()
                    FillPageSeoUrl()
                    ddpageurl.Items.Insert(0, ("Select Page url"))
                    ddpageseo.Items.Insert(0, ("Select Page Seo url"))
                    If Request.QueryString("chk") = "v" Then
                        ckpagelist.Enabled = False
                        ddpageseo.Enabled = False
                        ddpageurl.Enabled = False
                        txtstaticurl.ReadOnly = True
                    End If
                    Dim MenuId As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("MifId")))
                    If MenuId = 0 Then
                    Else
                        CheckUrlType()
                        If ddpageseo.SelectedValue = "Select Page Seo url" Then
                            rdpagetype.SelectedValue = "Page"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        ElseIf ddpageurl.SelectedValue = "Select Page url" Then
                            rdpagetype.SelectedValue = "PageSeo"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        End If
                    End If
                End If

                If Request.QueryString("id") = Nothing Then
                Else
                    FillPageUrl()
                    FillPageSeoUrl()
                    ddpageurl.Items.Insert(0, ("Select Page url"))
                    ddpageseo.Items.Insert(0, ("Select Page Seo url"))
                    If Request.QueryString("chk") = "v" Then
                        ckpagelist.Enabled = False
                        ddpageseo.Enabled = False
                        ddpageurl.Enabled = False
                        txtstaticurl.ReadOnly = True
                    End If
                    Dim MenuId As String = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    If MenuId = 0 Then
                    Else
                        CheckUrlType()
                        If ddpageseo.SelectedValue = "Select Page Seo url" Then
                            rdpagetype.SelectedValue = "Page"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        ElseIf ddpageurl.SelectedValue = "Select Page url" Then
                            rdpagetype.SelectedValue = "PageSeo"
                            rdpagetype_TextChanged(Nothing, Nothing)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub CheckUrlType()
        Try
            If (ckpagelist.SelectedValue = "Page") Then
                div_dropdown.Visible = True
                div_static.Visible = False
                rqstaticurl.Enabled = False
                rqddpage.Enabled = True
                div_rdpagetype.Visible = True
            ElseIf (ckpagelist.SelectedValue = "Static") Then
                div_dropdown.Visible = False
                div_static.Visible = True
                rqstaticurl.Enabled = True
                rqddpage.Enabled = False
                div_rdpagetype.Visible = False
            ElseIf (ckpagelist.SelectedValue = "None") Then
                div_dropdown.Visible = False
                div_static.Visible = False
                rqstaticurl.Enabled = False
                div_rdpagetype.Visible = False
                rqddpage.Enabled = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "CheckUrlType", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub rdpagetype_TextChanged(sender As Object, e As EventArgs) Handles rdpagetype.TextChanged
        Try
            If (rdpagetype.SelectedValue = "Page") Then
                div_dropdown.Visible = True
                div_static.Visible = False
                rqstaticurl.Enabled = False
                rqddpage.Enabled = True
                div_PageSeo.Visible = False
                rqpageseo.Enabled = False
            ElseIf rdpagetype.SelectedValue = "PageSeo" Then
                div_dropdown.Visible = False
                div_static.Visible = False
                rqstaticurl.Enabled = False
                rqddpage.Enabled = False
                div_PageSeo.Visible = True
                rqpageseo.Enabled = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("PageUrlControl", "rdpagetype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class
