Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Namespace APPCODE.DAL
    Public Class DBBridge
        Public Sub New()
        End Sub

        ''' <summary>
        ''' [METHOD] connect to the db
        ''' </summary>
        ''' <returns>TRUE, if it is saved</returns>
        Public Shared Function DBConnection() As String
            Try
                Return System.Configuration.ConfigurationManager.ConnectionStrings("connectionString").ToString
            Catch ce As Exception

                Throw New ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" & Convert.ToString(ce))
            End Try
        End Function


        Public Shared Function ExecuteNonQuery(storedProcedure As String, param As SqlParameter()) As Integer
            Try
                Return SQLHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure, param)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteNonQuerywithTrans(storedProcedure As String, param As SqlParameter()) As Integer
            Dim conTrans As New SqlConnection(DBConnection())
            Dim sqlTrans As SqlTransaction
            conTrans.Open()
            Dim returnResult As Integer = 0
            sqlTrans = conTrans.BeginTransaction()
            Try
                returnResult = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param)
                sqlTrans.Commit()
                Return returnResult
            Catch sq As Exception
                sqlTrans.Rollback()
                Throw sq
            Finally
                conTrans.Close()
            End Try

        End Function

        Public Shared Function ExecuteNonQuery(storedProcedure As String) As Integer
            Try
                Return SQLHelper.ExecuteNonQuery(DBConnection(), CommandType.StoredProcedure, storedProcedure)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteNonQuerySQL(sqlquery As String) As Integer
            Try
                Return SQLHelper.ExecuteNonQuery(DBConnection(), CommandType.Text, sqlquery)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteNonQuerywithTrans(storedProcedure As String) As Integer
            Dim conTrans As New SqlConnection(DBConnection())
            Dim sqlTrans As SqlTransaction
            conTrans.Open()
            Dim returnResult As Integer = 0
            sqlTrans = conTrans.BeginTransaction()
            Try
                returnResult = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure)
                sqlTrans.Commit()
                Return returnResult
            Catch sq As Exception
                sqlTrans.Rollback()
                Throw sq
            Finally
                conTrans.Close()
            End Try

        End Function

        Public Shared Function ExecuteNonQuerywithTransfromFrontEnd(sqlTrans As SqlTransaction, storedProcedure As String, param As SqlParameter()) As Integer
            Try
                Dim returnResult As Integer = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param)
                Return returnResult
            Catch sq As SqlException
                sqlTrans.Rollback()
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteDataset(storedProcedure As String, param As SqlParameter()) As DataSet
            Try
                Return SQLHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure, param)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteDatasetSQL(storedProcedure As String) As DataSet
            Try
                Return SQLHelper.ExecuteDataset(DBConnection(), CommandType.Text, storedProcedure)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteDataset(storedProcedure As String) As DataSet
            Try
                Return SQLHelper.ExecuteDataset(DBConnection(), CommandType.StoredProcedure, storedProcedure)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteScalar(storedProcedure As String, param As SqlParameter()) As Object
            Try
                Return SQLHelper.ExecuteScalar(DBConnection(), CommandType.StoredProcedure, storedProcedure, param)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteScalar(sqlTrans As SqlTransaction, storedProcedure As String, param As SqlParameter()) As Object
            Try
                Return SQLHelper.ExecuteScalar(sqlTrans, CommandType.StoredProcedure, storedProcedure, param)
            Catch sq As SqlException
                Throw sq
            End Try
        End Function
        Public Shared Function ExecuteReader(storedProcedure As String, param As SqlParameter()) As SqlDataReader
            Dim reader As SqlDataReader = Nothing
            Try
                reader = SQLHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure, param)
                Return reader
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteReader(storedProcedure As String) As SqlDataReader
            Dim reader As SqlDataReader = Nothing
            Try
                reader = SQLHelper.ExecuteReader(DBConnection(), CommandType.StoredProcedure, storedProcedure)
                Return reader
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteReaderSQL(sqlquery As String) As SqlDataReader
            Dim reader As SqlDataReader = Nothing
            Try
                reader = SQLHelper.ExecuteReader(DBConnection(), CommandType.Text, sqlquery)
                Return reader
            Catch sq As SqlException
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteNonQuerywithMultipleTrans(sqlTrans As SqlTransaction, storedProcedure As String) As Integer
            Dim returnResult As Integer = 0
            Try
                returnResult = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure)
                Return returnResult
            Catch sq As Exception
                Throw sq
            End Try
        End Function

        Public Shared Function ExecuteNonQuerywithMultipleTrans(sqlTrans As SqlTransaction, storedProcedure As String, param As SqlParameter()) As Integer
            Dim returnResult As Integer = 0
            Try
                returnResult = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, storedProcedure, param)
                Return returnResult
            Catch sq As Exception
                Throw sq
            End Try
        End Function
    End Class
End Namespace