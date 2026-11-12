
Partial Class todyaEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sb As New StringBuilder
        sb = SendTodayMail1()
        ltvalue.Text = sb.ToString
    End Sub

    Public Shared Function SendTodayMail1() As StringBuilder
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim sb As New StringBuilder
        ds = ActivityBLL.ActivityOwnerList()
        If ds.Tables(0).Rows.Count >= 1 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'sb.Append("<div><hr id='ecxstopSpelling'/>Subject:SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "<br><br><title>Today Activity Email Notification</title>")
                'sb.Append("<table bgcolor='#FFFFFF' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='100'><tbody><tr height='20' bgcolor=""><td width='1000' height='102'><table border='1' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='1'><tbody>")

                sb.Append("<table id='tablee' border='1' style='border-color:gray;width:960px;' cellspacing='0'>")
                ' sb.Append("<tr height='20' bgcolor='C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: center;'><b>Swiss Bake Ingredients Pvt Ltd  : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</b></th> </tr><tr height='20' bgcolor='#C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: left;'><b>&nbsp;Today Activity</b></th></tr>")
                sb.Append("<tr style='background-color: rgb(196, 218, 255);'><td colspan='10' style='text-align:center; color: #1274c0;font-weight:bold;font-family: sans-serif;padding: 6px;'>Swiss Bake Ingredients Pvt Ltd : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</td></tr>")
                sb.Append("<tr style='background-color: rgb(196, 218, 255);'><td colspan='10' style='  color: #1274c0;font-weight:bold;font-family: sans-serif;padding: 6px;'>Today Activity</td></tr>")
                sb.Append("<tr>")

                sb.Append("<th>S.No</th>")
                sb.Append("<th>Related To</th>")
                sb.Append("<th>Name</th>")
                sb.Append("<th style='width:150px;'>Subject</th>")
                sb.Append("<th>Activity Type</th>")
                sb.Append("<th>From</th>")
                sb.Append("<th>To</th>")
                sb.Append("<th>Priority</th>")
                sb.Append("<th>Status</th>")
                sb.Append("<th>AssingTo</th>")
                sb.Append("</tr>")

                ds1 = ActivityBLL.TodayActivityMailByOwner(ds.Tables(0).Rows(i)("U_Id").ToString)
                If ds1.Tables(0).Rows.Count >= 1 Then
                    For k As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        Dim temp As Integer = k + 1
                        sb.Append("<tr>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + temp.ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Related Type").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Name").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Subject").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Activity Type").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("From").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("To").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Priority").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Status").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("AssignTo").ToString + "</td>")
                        sb.Append("</tr>")
                    Next
                End If
                sb.Append("</table>")
                ' sb.Append("<tr><td colspan='10' height='15'><font face='Verdana' size='1'><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u></font></td></tr><tr><td width='100%' colspan='10' style='word-wrap: break-word;'><font face='Verdana' size='1'></font><br><div align='justify'><font face='Verdana' size='1'>&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. If you have received this message in error, please contact support@salesbabu.com and delete the message. Thank you. </font></div></td></tr>")
                ' sb.Append("</tbody></table></td></tr></tbody></table><br><font size='1' color='#666666'>Sent by SalesBabu CRM</font><br></div>")
                If ds1.Tables(0).Rows.Count >= 1 Then
                    ActivityBLL.SendActivityMail("irfan.bstar@gmail.com", sb.ToString, "SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "")
                    sb.Clear()
                End If
            Next
            Return sb
        End If
    End Function
End Class
