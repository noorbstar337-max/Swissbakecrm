Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class ReplyBLL
    Private Shared _spname As String = "_spReply"

    Public Shared Function FillReply_ByID(ByVal _Reply_CompaintId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillReplyById")
            sqlparams(1) = New SqlParameter("@Reply_CompaintId", _Reply_CompaintId)

            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FrontInsert(ByVal _Reply_CompaintId As Integer, ByVal _Reply_Type As String, ByVal _Reply_TypeId As Integer, ByVal _Reply_Discription As String, ByVal _Reply_Attachment As String) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FrontInsert")
            sqlparams(1) = New SqlParameter("@Reply_CompaintId", _Reply_CompaintId)
            sqlparams(2) = New SqlParameter("@Reply_Type", _Reply_Type)
            sqlparams(3) = New SqlParameter("@Reply_TypeId", _Reply_TypeId)
            sqlparams(4) = New SqlParameter("@Reply_Discription", _Reply_Discription)
            sqlparams(5) = New SqlParameter("@Reply_Attachment", _Reply_Attachment)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

   


End Class
