Imports APPCODE.DAL

Public Class OrderParcelBLL
    Private Shared _spname As String = "_spOrderParcel"

    Public Shared Function InsertOrder(ByVal _OrdPar_OrderId As Integer, ByVal _OrdPar_ParcelContent As String, ByVal _OrdPar_Value As Double, ByVal _OrdPar_CurrencyId As Integer,
           ByVal _OrdPar_ActualWeight As Double, ByVal _OrdPar_UOMId As Integer, ByVal _OrdPar_length As Double, ByVal _OrdPar_Width As Double,
           ByVal _OrdPar_Height As Double, ByVal _OrdPar_lenUOMId As Integer, ByVal _OrdPar_ChargedWeight As Double, ByVal _OrdPar_CreatedID As Integer
          ) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@OrdPar_OrderId", _OrdPar_OrderId)
            sqlparams(2) = New SqlParameter("@OrdPar_ParcelContent", _OrdPar_ParcelContent)
            sqlparams(3) = New SqlParameter("@OrdPar_Value", _OrdPar_Value)
            sqlparams(4) = New SqlParameter("@OrdPar_CurrencyId", _OrdPar_CurrencyId)
            sqlparams(5) = New SqlParameter("@OrdPar_ActualWeight", _OrdPar_ActualWeight)
            sqlparams(6) = New SqlParameter("@OrdPar_UOMId", _OrdPar_UOMId)
            sqlparams(7) = New SqlParameter("@OrdPar_length", _OrdPar_length)
            sqlparams(8) = New SqlParameter("@OrdPar_Width", _OrdPar_Width)
            sqlparams(9) = New SqlParameter("@OrdPar_Height", _OrdPar_Height)
            sqlparams(10) = New SqlParameter("@OrdPar_lenUOMId", _OrdPar_lenUOMId)
            sqlparams(11) = New SqlParameter("@OrdPar_ChargedWeight", _OrdPar_ChargedWeight)
            sqlparams(12) = New SqlParameter("@OrdPar_CreatedID", _OrdPar_CreatedID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
