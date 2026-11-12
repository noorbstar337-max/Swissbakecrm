
Partial Class CRMIndex
    Inherits System.Web.UI.Page




    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("UserRoleID") IsNot Nothing AndAlso
       Session("UserRoleID").ToString() = "9" Then

            ' Hide all other Home cards
            divAddLead.Visible = False
            divAddProspect.Visible = False
            divAddQuotation.Visible = False
            divAddAccount.Visible = False
            divAddOrder.Visible = False

            ' Show only Complaint and DSR
            divAddComplaint.Visible = True
            divAddDSR.Visible = True

        End If

    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        Dim host As String = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) ' HttpContext.Current.Request.Url.Host

        If host = "http://mcrm.swissbake.ch" Then
            Response.Redirect("index1.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        End If
        If host = "http://lms.swissbake.ch" Then
            Response.Redirect("lmsdashboard.aspx")
            'Else
            '    Response.Redirect("index.aspx")
        End If
        If Session("UserRoleID") = "3" Then
            Response.Redirect("index.aspx")
        ElseIf Session("UserRoleID") = "4" Then
            Response.Redirect("SupportDashBoard.aspx")
        End If
    End Sub
End Class
