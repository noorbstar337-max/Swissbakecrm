
Partial Class ComposeMessage
    Inherits System.Web.UI.Page
    Dim pro As New Procedure
    Dim EmailFrom As String
    Dim EmailPassword As String
    Dim SSL As Boolean
    Dim Port As String
    Dim ServerName As String
    Dim Type As String
    Dim Typeid As Integer
    Dim returnurl As String
    Dim Pdfpath As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub
    'Public Sub FillOwner()
    '    Try
    '        ddowner.DataSource = MainBLL.Dropdown("UserDropDown")
    '        ddowner.DataTextField = "U_FirstName"
    '        ddowner.DataValueField = "U_ID"
    '        ddowner.DataBind()
    '        ddowner.SelectedValue = Session("UserId")
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("ComposeMessage", "FillOwner", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Protected Sub btnsend_Click(sender As Object, e As EventArgs) Handles btnsend.Click
        Try
            Dim dt As DataSet = MainBLL.ViewByID(Session("UserId"), "UserImapViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            If IsDBNull(drLogin("U_Email")) Or drLogin("U_Email") = "" Then
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please configure Email-Id')", True)
            Else
                EmailFrom = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_Email").ToString())
                If IsDBNull(drLogin("U_EmailPassword")) Or drLogin("U_EmailPassword") = "" Then
                    ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please configure password')", True)
                Else
                    EmailPassword = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_EmailPassword").ToString())
                    If IsDBNull(drLogin("U_SSL")) Then
                        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please configure SSL')", True)
                    Else
                        SSL = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_SSL").ToString())
                        If IsDBNull(drLogin("U_ServerPort")) Or drLogin("U_ServerPort") = "" Then
                            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please configure Port Number')", True)
                        Else
                            Port = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_ServerPort").ToString())
                            If IsDBNull(drLogin("U_EmailServerName")) Or drLogin("U_EmailServerName") = "" Then
                                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Please configure Server Name')", True)
                            Else
                                ServerName = DynamicparcelDataManipulation.FixNullFromDB(drLogin("U_EmailServerName").ToString())
                                Try
                                    Dim al As ArrayList = New ArrayList
                                    Dim dl As Hashtable = New Hashtable
                                    Dim Paths As String
                                    Dim fExtension As String
                                    '   If Request.QueryString("QID") <> Nothing Then
                                    '       'Dim path2 As String = Server.MapPath(hfpath.Value)
                                    '       'al.Add(path2)
                                    '       pro.DynamicSendMail(txtto.Text.Trim, drLogin("U_Email").ToString(), drLogin("U_EmailPassword").ToString(), drLogin("U_SSL"),
                                    'drLogin("U_ServerPort"), txtmessge.Value, txtsubject.Text.Trim, drLogin("U_EmailServerName").ToString(), al)
                                    '       Typeid = EmailBLL.Insert(ddrelatedtype.SelectedValue, ddrelatedtypeid.SelectedValue, Session("UserId"), txtsubject.Text.Trim, txtmessge.Value,
                                    '                     EmailFrom, txtto.Text.Trim, "", "", Session("UserId"), "Sent")
                                    '       returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                                    '       DocumentBLL.Insert(hfpath.Value, ".pdf", "Email", Typeid, txtsubject.Text.Trim, Session("UserId"), Session("UserId"))
                                    '       ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "window.location='" + returnurl + "';", True)
                                    '   Else
                                    Dim uploads As HttpFileCollection = HttpContext.Current.Request.Files
                                    For i As Integer = 0 To uploads.Count - 1
                                        Dim upload As HttpPostedFile = uploads(i)
                                        Dim MyDate As DateTime = DateTime.Now
                                        Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + upload.FileName)
                                        Paths = "img/Document/" + filename
                                        Dim path2 As String = Server.MapPath("~/img/Document/" + filename)
                                        fExtension = Path.GetExtension(upload.FileName)
                                        If upload.FileName = "" Then
                                        Else
                                            upload.SaveAs(path2)
                                        End If
                                        If upload.ContentLength = 0 Then
                                            Continue For
                                        End If
                                        Dim c As String = System.IO.Path.GetFileName(upload.FileName)
                                        Try
                                            al.Add(path2)
                                            dl.Add(Paths, fExtension)
                                            Span1.InnerHtml = "Upload(s) Successful."
                                        Catch ex As Exception
                                            Span1.InnerHtml = "Upload(s) FAILED."
                                        End Try
                                    Next
                                    pro.DynamicSendMail(txtto.Text.Trim, drLogin("U_Email").ToString(), drLogin("U_EmailPassword").ToString(), drLogin("U_SSL"),
                              drLogin("U_ServerPort"), txtmessge.Value, txtsubject.Text.Trim, drLogin("U_EmailServerName").ToString(), al)
                                    If ddrelatedtype.SelectedValue = "None" Then
                                        Type = "None"
                                        Typeid = 0
                                    Else
                                        Type = ddrelatedtype.SelectedValue
                                        Typeid = ddrelatedtypeid.SelectedValue
                                    End If
                                    Typeid = EmailBLL.Insert(Type, Typeid, Session("UserId"), txtsubject.Text.Trim, txtmessge.Value,
                                                  EmailFrom, txtto.Text.Trim, "", "", Session("UserId"), "Sent")
                                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                                    For i As Integer = 0 To dl.Count - 1
                                        DocumentBLL.Insert(dl.Keys(i), dl.Values(i), "Email", Typeid, txtsubject.Text.Trim, Session("UserId"), Session("UserId"))
                                    Next
                                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "window.location='" + returnurl + "';", True)
                                    'End If
                                Catch ex As Exception
                                    EmailBLL.Insert(ddrelatedtype.SelectedValue, ddrelatedtypeid.SelectedValue, Session("UserId"), txtsubject.Text.Trim, txtmessge.Value,
                                                  EmailFrom, txtto.Text.Trim, "", "", Session("UserId"), "Not Sent")
                                    Dim error1 As String = ex.Message.Replace(Chr(34), "")
                                    error1 = error1.Replace(Chr(39), "")
                                    ExecptionBLL.Insert("ComposeMessage", "btnsend_Click", error1, Session("UserId"))
                                    returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
                                    Response.Redirect(returnurl)
                                End Try
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "btnsend_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
        'pro.SendMail("", "", "Your India2biz.com account is now active")
    End Sub

    Protected Sub ddrelatedtype_TextChanged(sender As Object, e As EventArgs) Handles ddrelatedtype.TextChanged
        Try
            If ddrelatedtype.SelectedValue = "Lead" Then
                Dim ds As DataSet = MainBLL.DropdownWithID("LeadContactDropDown", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Lead_Name"
                    ddrelatedtypeid.DataValueField = "Lead_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    GridView1.DataSource = ""
                    GridView1.DataBind()
                    txtto.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No lead found").ToString + "')", True)
                End If
            ElseIf (ddrelatedtype.SelectedValue = "Prospect") Then
                Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Prospect", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Acc_Name"
                    ddrelatedtypeid.DataValueField = "Acc_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    GridView1.DataSource = ""
                    GridView1.DataBind()
                    txtto.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No prospect found").ToString + "')", True)
                End If
                ElseIf (ddrelatedtype.SelectedValue = "Account") Then
                    Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Acc_Name"
                    ddrelatedtypeid.DataValueField = "Acc_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    GridView1.DataSource = ""
                    GridView1.DataBind()
                    txtto.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No account found").ToString + "')", True)
                End If
                ElseIf (ddrelatedtype.SelectedValue = "Opportunity") Then
                    Dim ds As DataSet = MainBLL.DropdownWithID("OpportunityDropDown", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Opportunity_Name"
                    ddrelatedtypeid.DataValueField = "Opportunity_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    GridView1.DataSource = ""
                    GridView1.DataBind()
                    txtto.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No opportunity found").ToString + "')", True)
                End If
                ElseIf (ddrelatedtype.SelectedValue = "Quotation") Then
                    Dim ds As DataSet = MainBLL.DropdownWithID("QuotationDropDown", Session("UserId"))
                If ds.Tables(0).Rows.Count >= 1 Then
                    ddrelatedtypeid.DataSource = ds
                    ddrelatedtypeid.DataTextField = "Name"
                    ddrelatedtypeid.DataValueField = "Quotation_Id"
                    ddrelatedtypeid.DataBind()
                Else
                    ddrelatedtype.SelectedValue = "None"
                    ddrelatedtypeid.DataSource = ""
                    ddrelatedtypeid.DataBind()
                    GridView1.DataSource = ""
                    GridView1.DataBind()
                    txtto.Text = ""
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("No quotation found").ToString + "')", True)
                End If
            ElseIf (ddrelatedtype.SelectedValue = "None") Then
                ddrelatedtypeid.DataSource = ""
                ddrelatedtypeid.DataBind()
                GridView1.DataSource = ""
                GridView1.DataBind()
                txtto.Text = ""
                End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "ddrelatedtype_TextChanged", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnselectcontact_Click(sender As Object, e As EventArgs) Handles btnselectcontact.Click
        Try
            mpe.Show()
            If ddrelatedtype.SelectedValue = "Account" Or ddrelatedtype.SelectedValue = "Prospect" Then
                GridView1.DataSource = ContactBLL.ContactByID(ddrelatedtype.SelectedValue, ddrelatedtypeid.SelectedValue, 0)
                GridView1.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Lead" Then
                GridView1.DataSource = MainBLL.DropdownWithID("LeadContactDropDownMail", ddrelatedtypeid.SelectedValue)
                GridView1.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Opportunity" Then
                GridView1.DataSource = ContactBLL.SelectContactByID(ddrelatedtypeid.SelectedValue)
                GridView1.DataBind()
            ElseIf ddrelatedtype.SelectedValue = "Quotation" Then
                Dim dt As DataSet = MainBLL.ViewByID(ddrelatedtypeid.SelectedValue, "QuotationType")
                Dim dtUser As New DataTable
                dtUser = dt.Tables(0)
                Dim drLogin As DataRow
                drLogin = dtUser.Rows(0)
                GridView1.DataSource = MainBLL.DropdownWithtypeAndID("MessageContacttDropDown", drLogin("Quotation_Type").ToString(), drLogin("Quotation_TypeID").ToString())
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "btnselectcontact_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "SelectContact" Then
            Try
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Dim row As GridViewRow = GridView1.Rows(index)
                Dim ltemail As Literal = DirectCast(row.FindControl("ltemail"), Literal)
                txtto.Text = ltemail.Text
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ComposeMessage", "GridView1_RowCommand", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            mpe.Hide()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "btnsave_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then

                'FillOwner()
                If Request.QueryString("Id") <> Nothing And Request.QueryString("type") <> Nothing Then
                    Typeid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    Type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
                    ddrelatedtype.SelectedValue = Type
                    ddrelatedtype_TextChanged(Nothing, Nothing)
                    ddrelatedtypeid.SelectedValue = Typeid
                Else
                End If
                If Request.QueryString("Id") <> Nothing And Request.QueryString("QID") <> Nothing Then
                    'FillProforma()
                    Typeid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("QID")))
                    Type = "Quotation"
                    ddrelatedtype.SelectedValue = Type
                    ddrelatedtype_TextChanged(Nothing, Nothing)
                    ddrelatedtypeid.SelectedValue = Typeid
                    divedit.Visible = True
                    divview.Visible = False
                End If
                If Request.QueryString("Id") <> Nothing And Request.QueryString("chk") <> Nothing Then
                    FillDetail()
                    fillDocument()
                    divedit.Visible = False
                    divview.Visible = True
                Else
                    divedit.Visible = True
                    divview.Visible = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillProforma()
        Try
            Typeid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Typeid, "ProfromabyID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            hyppdf.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_No").ToString())
            hyppdf.NavigateUrl = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_Pdf").ToString())
            hfpath.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Proforma_Pdf").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ViewAccount", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            Typeid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Typeid, "MailViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drLogin As DataRow
            drLogin = dtUser.Rows(0)
            ddrelatedtype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Type").ToString())
            ddrelatedtype_TextChanged(Nothing, Nothing)
            ddrelatedtypeid.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_TypeId").ToString())
            ' ddowner.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Owner").ToString())
            txtsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Subject").ToString())
            ltsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Subject").ToString())
            txtmessge.Value = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Message").ToString())
            ltmessgae.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_Message").ToString())
            txtto.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_To").ToString())
            ltemailto.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_To").ToString())
            ltdate.Text = DynamicparcelDataManipulation.DateFormatWithTime(drLogin("Email_CreatedDate").ToString())
            ltemailfrom.Text = DynamicparcelDataManipulation.FixNullFromDB(drLogin("Email_From").ToString())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Try
            returnurl = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl")))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "window.location='" + returnurl + "';", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "btnback_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillDocument()
        Try
            Typeid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            dtattachent.DataSource = DocumentBLL.NewFillDocument("Email", Typeid)
            dtattachent.DataBind()
            If dtattachent.Items.Count > 1 Then
                lblattahment.Text = "Attachment"
            Else
                lblattahment.Text = "No Attachment"
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub hfcancel_Click(sender As Object, e As EventArgs) Handles hfcancel.Click
        Try
            Response.Redirect(Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("returnurl"))))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ComposeMessage", "hfcancel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
End Class

