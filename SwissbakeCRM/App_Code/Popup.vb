Imports Microsoft.VisualBasic
Imports System.Web.UI
Imports System.Web

Public Class Popup




    Public Shared Sub ShowModalError(ex As Exception, page As Page, Optional errorDialogTitle As String = "")
        If ex IsNot Nothing Then
            ' show error
            Dim dialogTitle As String = [String].Empty

            If Not [String].IsNullOrEmpty(errorDialogTitle) Then
                dialogTitle = ", '" + errorDialogTitle + "'"
            End If

            Dim errorMessage As String = Popup.RemoveSpecialChars(ex.Message)
            ScriptManager.RegisterStartupScript(page, page.[GetType](), "err_msg", "ShowError('" + errorMessage + "'" + dialogTitle + ");", True)
        End If
    End Sub

    Public Shared Sub ShowModalHtmlError(errorMessage As String, page As Page, errorDialogTitle As String)
        ' show error
        Dim dialogTitle As String = [String].Empty

        If Not [String].IsNullOrEmpty(errorDialogTitle) Then
            dialogTitle = ", '" + errorDialogTitle + "'"
        End If

        ScriptManager.RegisterStartupScript(page, page.[GetType](), "err_msg", "ShowHtmlError('" + errorMessage + "'" + dialogTitle + ");", True)
    End Sub

    Public Shared Function RoundToNearestTens(number As Integer) As Integer
        Return CInt(Math.Round(Convert.ToDecimal((number + 9) \ 10)) * 10)
    End Function

    Private Shared Function RemoveSpecialChars(text As String) As String
        Dim regex As New Regex("[^a-zA-Z0-9 -]")
        Return regex.Replace(text, "")
    End Function

    Public Shared Function Msgbox(ByVal message As String) As StringBuilder

        Dim sb As New StringBuilder
        
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(message)
        sb.Append("')};")
        sb.Append("</script>")

        Return sb
    End Function

    Private Shared Function ClientScript() As Object
        Throw New NotImplementedException
    End Function

End Class
