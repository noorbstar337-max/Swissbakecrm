Imports DynamicparcelEnumerations
Partial Class ModifyComplaint
    Inherits System.Web.UI.Page
    Dim Mainid As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
        Else
            If (Request.QueryString("Id") = Nothing) Then
                Response.Redirect("index.aspx")
            End If
        End If
    End Sub

    

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Try
                    Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                    FillDetail()
                    FillReplyView()
                Catch ex As Exception
                    Response.Redirect("index.aspx")
                End Try
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            FillComplaintStatus()
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim dt As DataSet = MainBLL.ViewByID(Mainid, "ComplaintViewByID")
            Dim dtComplaint As New DataTable
            dtComplaint = dt.Tables(0)
            Dim drComplaintRow As DataRow
            drComplaintRow = dtComplaint.Rows(0)
            lblcomplaintno.Text = Mainid
            Dim download As String = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Attachment").ToString())
            lblCustomerName.Text = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Acc_Name").ToString())
            Session("CustId") = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Custid").ToString())
            hfcustname.Value = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Acc_Name").ToString())
            hfemail.Value = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Cust_EmailId").ToString())
            lbldep.Text = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Deprt_Name").ToString())
            lblsubject.Text = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Subject").ToString())
            lblstatus.Text = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_CompStatus").ToString())
            ddcompStatus.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_CompStatus").ToString())
            lblcomplaint.Text = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Discription").ToString())
            lblCreatedDate.Text = "on " + DynamicparcelDataManipulation.DateFormat(drComplaintRow("Complaint_CreatedDate").ToString())
            hfcreateddate.Value = DynamicparcelDataManipulation.DateFormatWithTime(drComplaintRow("Complaint_CreatedDate").ToString())
            'Hypercompattach.NavigateUrl = "../" + DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Attachment").ToString())

            Dim Attach As String ' = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow1("Complaint_Attachment").ToString())
            Dim str As String = DynamicparcelDataManipulation.FixNullFromDB(drComplaintRow("Complaint_Attachment").ToString())
            Dim strArr() As String
            'Dim count As Integer
            strArr = str.Split("/")
            Attach = strArr(1)
            Dim host As String = HttpContext.Current.Request.Url.Host
            If host = "localhost" Then
                If Attach = "Complaint" Then
                    Hypercompattach.NavigateUrl = "http://localhost:56361/Admin/" + str
                ElseIf Attach = "Document" Then
                    Hypercompattach.NavigateUrl = "../" + str
                ElseIf Attach = "Content" Then
                    Hypercompattach.NavigateUrl = "www.swissbake.in/" + str
                End If
            Else
                If Attach = "Complaint" Then
                    Hypercompattach.NavigateUrl = "b2b.swissbake.ch/" + str
                ElseIf Attach = "Document" Then
                    Hypercompattach.NavigateUrl = "crm.swissbake.ch/" + str
                ElseIf Attach = "Content" Then
                    Hypercompattach.NavigateUrl = "www.swissbake.in/" + str
                End If
            End If

            If download = "#" Then
                Hypercompattach.Visible = False
            Else
                Hypercompattach.Visible = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "FillDetail", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub


    Protected Sub Button_Delete(ByVal sender As Object, ByVal e As EventArgs)
        If deletestatus.Value = "yes" Then
            Dim btndelete As LinkButton = CType(sender, LinkButton)
            Dim commandArgument As String = btndelete.CommandArgument

            Dim replayId As Integer = commandArgument

            MainBLL.DeleteSI(replayId, Session("UserId"), "FrontReplyDeleteSi", Session("Audlog_Id"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Delete record Sucessfully')", True)
            FillReplyView()
        End If

    End Sub

    Public Sub FillReplyView()
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim ds As DataSet = MainBLL.ViewByID(Mainid, "ReplyViewByID")
            Repeater1.DataSource = ds
            Repeater1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "FillReplyView", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub Repeater1_ItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles Repeater1.ItemDataBound
        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim HyperLink1 As HyperLink = CType(e.Item.FindControl("rpatachment"), HyperLink)
                If HyperLink1.NavigateUrl = "../#" Then
                    HyperLink1.Visible = False
                End If
                HyperLink1.Attributes.Add("download", "")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "Repeater1_ItemDataBound", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Public Sub FillComplaintStatus()
        Try
            Dim ds As DataSet
            ds = StatusBLL.Dropdown("Complaint")
            ddcompStatus.DataSource = ds.Tables(0)
            ddcompStatus.DataTextField = "Status_Name"
            ddcompStatus.DataValueField = "Status_Name"
            ddcompStatus.DataBind()
            'ddcompStatus.Items.Insert(0, "Select Complaint Status")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "FillComplaintStatus", error1, Session("UserId"))
            Throw ex
        End Try
    End Sub

    Protected Sub btnsubmit_Click(sender As Object, e As EventArgs) Handles btnsubmit.Click
        Try
            Mainid = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Insert()
            SendUsingSMPP.SendSMS("Dear " + hfcustname.Value.ToString() + ", You complaint record " + Mainid.ToString + " has been updated. Please login into your account at www.swissbake.in to check. Thank you.", SmsBLL.CustomerNo(Session("CustId")))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('Profile Updated Sucessfully')", True)
            'Temporary stop email 06-10-2023 by Noor
            ''responseMail(Mainid, txtreply.Text, hfcreateddate.Value, lblsubject.Text, lblcomplaint.Text, hfcustname.Value, hfemail.Value)
            Response.Redirect(Request.RawUrl)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "btnsubmit_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Private Sub responseMail(ByVal ComplaintID As Integer, ByRef response As String, ByVal CreatedDate As String, ByVal subject As String, ByVal complaint As String, ByVal Custname As String, ByVal email As String)
        Try
            Dim body As String = String.Empty
            Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/ResponseCopmlaint.html"))
            body = reader.ReadToEnd
            body = body.Replace("#TICKETID", ComplaintID)
            body = body.Replace("#TICKETDATE", CreatedDate)
            body = body.Replace("#SUBJECT", subject)
            body = body.Replace("#TICKETDETAILS", complaint)
            body = body.Replace("#RESPONSE", response)
            body = body.Replace("#NAME", Custname)
            Dim Oemail As String = MainBLL.Email(Session("CustId"))
            Dim emailC As String = MainBLL.CustEmail(Session("CustId"))
            If email = "" Then
                email = Oemail + "," + email
            Else
                email = email + "," + Oemail
            End If
            SendMailBLL.SendMail(email, body, "Updates for Communication (" + ComplaintID.ToString + ") on your swissbake.in account")
            reader.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Insert()
        Try
            Dim Document As String = ""
            If FileUpload1.HasFile Then
                Try
                    Dim filename As String = Path.GetFileName(FileUpload1.FileName)
                    Dim path3 As String = "../Document/" + filename
                    Dim path2 As String = Server.MapPath("../Document/" + filename)
                    FileUpload1.SaveAs(path2)
                    Document = path3
                Catch ex As Exception
                End Try
            End If
            If Document = "" Then
                Document = "#"
            End If
            ComplaintBLL.Update(txtreply.Text, Document, Session("UserId"), Mainid, ddcompStatus.SelectedValue)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyComplaint", "Insert", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Protected Sub lkback_Click(sender As Object, e As EventArgs) Handles lkback.Click
        If Session("UserRoleID") = 4 Then
            Response.Redirect("SupportComplaint.aspx?type=NFUHfhdSFeW")
        Else
            Response.Redirect("Support.aspx")
        End If
    End Sub
End Class
