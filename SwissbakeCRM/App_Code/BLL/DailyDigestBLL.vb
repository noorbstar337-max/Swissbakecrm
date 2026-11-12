Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class DailyDigestBLL
    Public Shared Sub SendDailyDigest()

        Dim phone As New ArrayList()
        Dim dt As DataTable = SmsBLL.AllUserNo.Tables(0)
        For Each dataRow As DataRow In dt.Rows
            Dim ds As DataSet = CountBLL.IndexCount("IndexCount", dataRow.Item("U_ID"))

            'phone.Add(String.Join(";", dataRow.ItemArray.[Select](Function(item) item.ToString())))
        Next

        For row1 As Integer = 0 To phone.Count - 1

            'SendUsingSMPP.SendSMS("*ACTIVITIES FOR "+Date.Now.ToString+"* Dear " +#BDONAME+", you have "+#TODAYPHONE+" phone calls, "+#TODAYEMAIL+" emails, "+#TODAYMEET+" meetings, "+#TODAYDEMO+" demos, "+#TODAYSAMPLING+" sampling and "+#TODAYOTHERACT+" other activities planned for today.", SmsBLL.UserNo())
        Next




    End Sub
End Class
