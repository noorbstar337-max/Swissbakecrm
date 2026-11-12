Imports Microsoft.VisualBasic
Imports System.Security.Cryptography
Imports System.IO

Public Class Security
    Public Shared Function Encrypt(clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
                    cs.Write(clearBytes, 0, clearBytes.Length)
                    cs.Close()
                End Using
                clearText = Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
        Return clearText
    End Function

    Public Shared Function Decrypt(cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        cipherText = cipherText.Replace(" ", "+")
        Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        Using encryptor As Aes = Aes.Create()
            Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
             &H65, &H64, &H76, &H65, &H64, &H65, _
             &H76})
            encryptor.Key = pdb.GetBytes(32)
            encryptor.IV = pdb.GetBytes(16)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
                    cs.Write(cipherBytes, 0, cipherBytes.Length)
                    cs.Close()
                End Using
                cipherText = Encoding.Unicode.GetString(ms.ToArray())
            End Using
        End Using
        Return cipherText
    End Function
    Shared Function checkSentStatusINR(ByVal status As String) As String 'created by altaf polist.aspx
        If status <> "INR" Then
            Return "label label-success"
        Else
            'Return "label label-danger"
        End If
    End Function
    Shared Function checkImportStatus(ByVal status As String) As String
        If status = "Success" Then
            Return "label label-success"
        Else
            Return "label label-danger"
        End If
    End Function

    Shared Function checkStatus(ByVal status As String) As String
        If status = "Active" Then
            Return "label label-success"
        Else
            Return "label label-danger"
        End If
    End Function
    Shared Function checkSRStatus(ByVal status As String) As String
		If status = "Requested" Then
			Return "label label-primary"
		ElseIf status = "Dispatched" Then
			Return "label label-success"
		ElseIf status = "Approved" Then
			Return "label label-info"
		ElseIf status = "Authorized" Then
			Return "label label-warning"
		ElseIf status = "Rejected" Then
			Return "label label-danger"
		ElseIf status = "Feedback Received" Then
			Return "label label-default"
		End If
    End Function

    Shared Function checkStatuscss(ByVal status As String) As String
        If status = "Pending" Then
            Return "label label-warning"
        ElseIf status = "Close Postpone" Then
            Return "label label-info"
        End If
    End Function 
    Shared Function checkpriority(ByVal priority As String) As String
        If priority = "High" Then
            Return "label label-danger"
        ElseIf priority = "Highest" Then
            Return "label label-danger"
        ElseIf priority = "Lowest" Then
            Return "label label-warning"
        ElseIf priority = "Low" Then
            Return "label label-warning"
        ElseIf priority = "Normal" Then
            Return "label label-info"
        End If
    End Function

    Shared Function checkValid(ByVal status As String) As String
        If status = "Valid" Then
            Return "label label-success"
        Else
            Return "label label-danger"
        End If
    End Function

    Shared Function checkSentStatus(ByVal status As String) As String
        If status = "Sent" Then
            Return "label label-success"
        Else
            Return "label label-danger"
        End If
    End Function


    Shared Function checkValidsupport(ByVal status As String) As String
        If status = "Pending" Then
            Return "label label-danger"

        Else
            Return "label label-success"
        End If
    End Function

    Shared Function OrderFrom(ByVal status As String) As String
        If status = "CRM" Then
            Return "label label-info"
        Else
            Return "label label-warning"
        End If
    End Function
    Shared Function checkOrderStatus(ByVal status As String) As String      ' Created by MUBYN
        If status = "Placed" Then
            Return "label label-success"
        ElseIf status = "On Hold" Then
            Return "label label-primary"
        ElseIf status = "Cancelled" Then
            Return "label label-info"
        ElseIf status = "Dispatched" Then
            Return "label label-warning"
        ElseIf status = "Pending" Then
            Return "label label-danger"
        ElseIf status = "Part Dispatched" Then
            Return "label label-default"
        End If
    End Function
    Shared Function UniversalStatus(ByVal status As String) As String
        If status = "Pending" Then
            Return "pend"
        ElseIf status = "In-Process" Then
            Return "pend"

        ElseIf status = "Pending Approval" Then
            Return "pend"

        ElseIf status = "Complete" Then
            Return "Complet"
        ElseIf status = "Paid" Then
            Return "Complet"

        ElseIf status = "Confirmation Sent" Then
            Return "Approve"

        ElseIf status = "Resolved" Then
            Return "Complet"

        ElseIf status = "Approved" Then
            Return "Approve"

        ElseIf status = "Placed" Then
            Return "Place"

        ElseIf status = "Cancelled" Then
            Return "cancel"
        ElseIf status = "Cancel" Then
            Return "cancel"
        ElseIf status = "Invoice Sent" Then
            Return "sent"
        ElseIf status = "Delivered" Then
            Return "Complet"
        ElseIf status = "Dispatched" Then
            Return "sent"
        ElseIf status = "Part Dispatched" Then
            Return "PartDisp"
        ElseIf status = "Partial" Then
            Return "PartDisp"
        ElseIf status = "On Hold" Then
            Return "onhold"
        End If

    End Function
    Shared Function checkpriorityLMS(ByVal priority As String) As String
        If priority = "High" Then
            Return "label label-danger"
        ElseIf priority = "Medium" Then
            Return "label label-warning"
        ElseIf priority = "Low" Then
            Return "label label-info"
        ElseIf priority = "Complete" Then
            Return "Complet"
        ElseIf priority = "Incomplete" Then
            Return "label label-warning"
        ElseIf priority = "Pending" Then
            Return "label label-warning"
        ElseIf priority = "Rejected" Then
            Return "label label-info"
        ElseIf priority = "Approved" Then
            Return "label label-success"
        End If
    End Function
End Class
