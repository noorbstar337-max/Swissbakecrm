
Partial Class Support_Ticket
    Inherits System.Web.UI.Page
    Dim ComID As Integer
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Filldepartment()
            fillaccount()
        End If
    End Sub

    Public Sub Filldepartment()
        Dim ds As DataSet
        ds = MainBLL.Dropdown("DepartmentDropDown")

        ddldepartment.DataSource = ds.Tables(0)
        ddldepartment.DataTextField = "Deprt_Name"
        ddldepartment.DataValueField = "Deprt_Id"
        ddldepartment.DataBind()
    End Sub
    Public Sub fillaccount()
        Try
            'Dim ds As DataSet = MainBLL.DropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"))
            Dim ds As DataSet = MainBLL.NewDropdownWithtypeAndID("AccountDropDown", "Account", Session("UserId"), "")
            ddrelatedtypeid.DataSource = ds
            ddrelatedtypeid.DataTextField = "Acc_Name"
            ddrelatedtypeid.DataValueField = "Acc_Id"
            ddrelatedtypeid.DataBind()
            ddrelatedtypeid.Items.Insert(0, "---Select Account Name---")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifySalesOrder", "fillaccount", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    'Public Sub Insert()
    '    Try
    '        Dim Document As String = ""
    '        If FileUpload1.HasFile Then
    '            Try
    '                Dim MyDate As DateTime = DateTime.Now
    '                Dim fExtension As String = Path.GetExtension(FileUpload1.FileName)
    '                'Dim filename As String = Path.GetFileName(FileUpload1.FileName)
    '                Dim filename As String = Path.GetFileNameWithoutExtension(FileUpload1.FileName)
    '                Dim path3 As String = "img/Document/" + filename + MyDate.ToString("ddMMyyhhmmss") + fExtension
    '                Dim path2 As String = Server.MapPath("img/Document/" + filename + MyDate.ToString("ddMMyyhhmmss") + fExtension)
    '                FileUpload1.SaveAs(path2)

    '                Document = path3
    '            Catch ex As Exception

    '            End Try
    '        End If

    '        If Document = "" Then
    '            Document = "#"
    '        End If

    '        ComID = ComplaintBLL.InsertCrm(ddldepartment.SelectedValue, ddrelatedtypeid.SelectedValue, ddsubject.SelectedItem.Text, txtaddress.Text, Document, Session("UserId"))
    '        RegistrationMail(ComID)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Public Sub Insert()
        Try
            Dim Document As String = ""
            If FileUpload1.HasFile Then
                Try
                    Dim MyDate As DateTime = DateTime.Now
                    Dim fExtension As String = Path.GetExtension(FileUpload1.FileName)
                    'Dim filename As String = Path.GetFileName(FileUpload1.FileName)
                    Dim filename As String = Path.GetFileNameWithoutExtension(FileUpload1.FileName)
                    Dim path3 As String = "img/Document/" + filename + MyDate.ToString("ddMMyyhhmmss") + fExtension
                    Dim path2 As String = Server.MapPath("img/Document/" + filename + MyDate.ToString("ddMMyyhhmmss") + fExtension)
                    FileUpload1.SaveAs(path2)

                    Document = path3
                Catch ex As Exception

                End Try
            End If

            If Document = "" Then
                Document = "#"
            End If
            'Session("Acc_Name") = ddrelatedtypeid.SelectedItem.Text
            '  Fetch account email directly here
            'Dim accountId As String = ddrelatedtypeid.SelectedValue
            'Dim CustEmail As String = ""
            'Dim ds As DataSet = MainBLL.CustEmail(accountId, "getCustemail")

            'If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            '    CustEmail = If(ds.Tables(0).Rows(0)("Cust_EmailId") IsNot DBNull.Value, ds.Tables(0).Rows(0)("Cust_EmailId").ToString(), "")
            'End If

            ''  Store in session
            'Session("Acc_Name") = ddrelatedtypeid.SelectedItem.Text
            'Session("Cust_EmailId") = CustEmail
            '  Fetch email directly using your BLL function
            Dim accountId As Integer = Convert.ToInt32(ddrelatedtypeid.SelectedValue)
            Dim CustEmail As String = MainBLL.CustEmail(accountId)

            ' Store values in session
            Session("Acc_Name") = ddrelatedtypeid.SelectedItem.Text
            Session("Cust_EmailId") = CustEmail
            Session("CustId") = ddrelatedtypeid.SelectedValue  ' Store Account ID


            ComID = ComplaintBLL.InsertCrm(ddldepartment.SelectedValue, ddrelatedtypeid.SelectedValue, ddsubject.SelectedItem.Text, txtaddress.Text, Document, Session("UserId"))
            RegistrationMail(ComID)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub RegistrationMail(ByVal ComID As String)
        Dim sb As New StringBuilder
        Dim count As Integer = 1
        Dim s As String = ""
        Dim body As String = String.Empty
        Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/ResponseCopmlaint.html")) 'complaint.html
        body = reader.ReadToEnd
        body = body.Replace("#NAME", Session("CustName"))
        Dim ds As DataSet = ComplaintBLL.FillTicket_ByID(ComID)
        Dim dt As DataTable = ds.Tables(0)

        For Each dr As DataRow In dt.Rows
            body = body.Replace("#TICKETID", ComID)
            body = body.Replace("#TICKETDATE", dr(7).ToString)
            body = body.Replace("#SUBJECT", dr(3).ToString)
            body = body.Replace("#TICKETDETAILS", dr(4).ToString)


        Next
        'stop temporary
        'SendMailBLL.SendMail(Session("CustEmail"), body.ToString, "Communication (" + ComID + ") received from your SwissBake account")
        ' SendUsingSMPP.SendSMS("Dear " + Session("CustName").Replace(" ", "_") + ", We have received your concerns against ticket " + ComID + " and will get back to you within 3 working days. Please check for updates by login into your account at www.swissbake.in.", SmsBLL.CustomerNo(Session("CustId")))
        'SendUsingSMPP.SendSMS("*NEW COMPLAINT* Ticked no " + ComID + " has been raised by " + Session("CustName").Replace(" ", "_") + " for " + ddsubject.SelectedItem.Text.Replace(" ", "_") + ".", SmsBLL.AdminNo)
        '        SendUsingSMPP.SendSMS("*NEW COMPLAINT* Hi " + HomeBLL.FillManager(Session("CustId")).Tables(0).Rows(0)(0).ToString.Replace(" ", "_") + ", Your customer " + Session("CustName").Replace(" ", "_") + " has raised a new complaint for " + ddsubject.SelectedItem.Text.Replace(" ", "_") + ". Please check Ticket no " + ComID + " for more details.", SmsBLL.UserNoFromCust(Session("CustId")))

        ' SMS to customer
        '        SendUsingSMPP.SendSMS(
        '    "Dear " & Session("CustName").ToString().Replace(" ", "_") &
        '    ", we have received your concern against ticket " & ComID &
        '    " and will get back to you within 3 working days. Please check for updates by logging into your account at www.swissbake.co.in.",
        '    "9167263664"
        ')

        Dim customerName As String = Session("Acc_Name").ToString()
        Dim ticketId As String = ComID
        Dim accountId As String = Session("CustId").ToString()
        Dim complaintParams As New List(Of String) From {
         customerName,
         ticketId
}
        'Comment after live uncomment it later
        'Dim customerMobile As String = SmsBLL.CustomerNo(accountId)
        'If Not String.IsNullOrEmpty(customerMobile) Then
        '    '  Send WhatsApp message dynamically
        '    SendUsingSMPP.SendWhatsAppMessage(customerMobile, "ticket_user", complaintParams)
        'Else

        'End If
        'END after live Uncomment 

        ' Send WhatsApp message to customer "9167263664"
        'SendUsingSMPP.SendWhatsAppMessage(SmsBLL.CustomerNo(Session("CustId")), "complaint_ticket_received", complaintParams)
        SendUsingSMPP.SendWhatsAppMessage("9167263664", "complaint_ticket_received", complaintParams)
        ' SMS to admin

        'For now comment after uploadiing on live uncomment it later

        '        Dim adminPhone As String = SmsBLL.AdminNo
        '        Dim adminParams As New List(Of String) From {
        '    ComID,
        '    Session("Acc_Name").ToString(),
        '    ddsubject.SelectedItem.Text
        '}

        '        System.Diagnostics.Debug.WriteLine("Admin WhatsApp No: " & adminPhone)
        '        SendUsingSMPP.SendWhatsAppMessage(adminPhone, "admin_support", adminParams)


        ' Temporarily hardcode the admin phone number for testing purposes
        Dim adminPhone As String = "8309252022"

        Dim adminParams As New List(Of String) From {
    ComID,
    Session("Acc_Name").ToString(),
    ddsubject.SelectedItem.Text
}

        System.Diagnostics.Debug.WriteLine("Admin WhatsApp No: " & adminPhone)
        SendUsingSMPP.SendWhatsAppMessage(adminPhone, "admin_support", adminParams)



        ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Support Tickect has been Send Successfully.')", True)
        'reader.Dispose()
    End Sub
    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Insert()

        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Ticket Added Sucessfully')", True)
        clear()

    End Sub

    Public Sub clear()
        txtaddress.Text = ""
        'txtsubject.Text = ""
    End Sub

    Protected Sub Page_PreInit(sender As Object, e As EventArgs) Handles Me.PreInit
        'Default Private Property Item(ByVal Optional  As MasterPageFile = "~/MasterPage2.master") 
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host
        ' Dim url As String

        If host = "http://mcrm.swissbake.ch" Then
            Me.MasterPageFile = "MCRMMaster.master"

        End If

    End Sub

End Class
