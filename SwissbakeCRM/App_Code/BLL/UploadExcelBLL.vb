
Imports APPCODE.DAL

Public Class UploadExcelBLL
    Private Shared _spname As String = ""

    Public Shared Function GetDataset(ByVal cValue As String, ByVal vMode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", vMode)
            sqlparams(1) = New SqlParameter("@ColValue", cValue)
            Return DBBridge.ExecuteDataset("_spGetId", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetId(ByVal vDataset As DataSet) As Integer
        Dim dt As New DataTable
        Dim code As Integer
        dt = vDataset.Tables(0)
        If dt.Rows.Count > 0 Then
            code = dt.Rows(0)(0)
        Else
            code = 0
        End If
        Return code
    End Function

    Public Shared Function GetVrcmId() As Integer
        Dim vrcmid As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MAX_VRCM_ID")
            vrcmid = DBBridge.ExecuteScalar("_spGetId", sqlparams)
            Return vrcmid
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Shared Function Insert(ByVal cid As Integer, ByVal pid As String, ByVal vid As Integer, ByVal zid As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Vpl_CountryID", cid)
            sqlparams(2) = New SqlParameter("@Vpl_ProductID", pid)
            sqlparams(3) = New SqlParameter("@Vpl_VendorID", vid)
            sqlparams(4) = New SqlParameter("@Vpl_ZoneID", zid)
            Return DBBridge.ExecuteNonQuery("_spVendorProdLink", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertRate(ByVal cid As Integer, ByVal pid As String, ByVal vid As Integer, ByVal zid As Integer, ByVal Dest As String) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Insert")
            sqlparams(1) = New SqlParameter("@Vrcm_CountryID", cid)
            sqlparams(2) = New SqlParameter("@Vrcm_ProductID", pid)
            sqlparams(3) = New SqlParameter("@Vrcm_VendorID", vid)
            sqlparams(4) = New SqlParameter("@Vrcm_ZoneID", zid)
            sqlparams(5) = New SqlParameter("@Vrcm_Dest", Dest)
            Return DBBridge.ExecuteNonQuery("_spVendorRateMast", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertRateDetails(ByVal vrcmId As Integer, ByVal vSlab As Integer, ByVal vLower As Double, ByVal vUpper As Double, ByVal vRate As Double) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertD")
            sqlparams(1) = New SqlParameter("@Vrcm_ID", vrcmId)
            sqlparams(2) = New SqlParameter("@Vrcd_SlabNo", vSlab)
            sqlparams(3) = New SqlParameter("@Vrcd_Lower", vLower)
            sqlparams(4) = New SqlParameter("@Vrcd_Upper", vUpper)
            sqlparams(5) = New SqlParameter("@Vrcd_Rate", vRate)
            Return DBBridge.ExecuteNonQuery("_spVendorRateMast", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function DeleteZone() As Integer
        Dim sqlparams(0) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Delete")
            Return DBBridge.ExecuteNonQuery("_spVendorProdLink", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteRate(ByVal vid As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Delete")
            sqlparams(1) = New SqlParameter("@Vrcm_VendorID", vid)
            Return DBBridge.ExecuteNonQuery("_spVendorRateMast", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




End Class

