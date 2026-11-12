Imports APPCODE.DAL

Public Class GetRateBLL
    Private Shared _spname As String = "_spGetRate"

    Public Shared Function getRate(ByVal vCountry As String, ByVal vWeight As Double, ByVal vMode As String) As DataSet
        Dim dt As New DataSet
        dt.Tables.Add()
        dt.Tables(0).Columns.Add("Ven_ID")
        dt.Tables(0).Columns.Add("Ven_Code")
        dt.Tables(0).Columns.Add("Ven_Name")
        dt.Tables(0).Columns.Add("Ven_Logo")
        dt.Tables(0).Columns.Add("Country_Name")
        dt.Tables(0).Columns.Add("Zone_Code")
        dt.Tables(0).Columns.Add("Vrcd_Rate")
        dt.Tables(0).Columns.Add("Ven_FC")
        dt.Tables(0).Columns.Add("S_Tax")
        dt.Tables(0).Columns.Add("Total")
        Dim vProdCode As String

        Dim getERate As New DataSet

        If vWeight > 0.5 Then
            vProdCode = "ISPX"
        Else
            vProdCode = "IDOX"
        End If

        Dim sqlparams(2) As SqlParameter
        Try
            If vMode = "Express" Then
                sqlparams(0) = New SqlParameter("@Mode", "VendorProdLinkEX")
            Else
                sqlparams(0) = New SqlParameter("@Mode", "VendorProdLinkEC")
            End If
            sqlparams(1) = New SqlParameter("@Country_Name", vCountry)
            sqlparams(2) = New SqlParameter("@prd_Code", vProdCode)
            getERate = DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try


        For i = 0 To getERate.Tables(0).Rows.Count - 1
            Dim vRate As New DataSet
            Dim sqlparams1(4) As SqlParameter
            Try
                If getERate.Tables(0).Rows(i)("Zone_Code") = "IN" Then
                    sqlparams1(0) = New SqlParameter("@Mode", "VendorCountryRate")
                Else
                    sqlparams1(0) = New SqlParameter("@Mode", "VendorZoneRate")
                End If
                sqlparams1(1) = New SqlParameter("@Ven_Code", getERate.Tables(0).Rows(i)("Ven_Code"))
                sqlparams1(2) = New SqlParameter("@prd_Code", vProdCode)
                sqlparams1(3) = New SqlParameter("@Zone_Code", getERate.Tables(0).Rows(i)("Zone_Code"))
                sqlparams1(4) = New SqlParameter("@Wight", vWeight)
                vRate = DBBridge.ExecuteDataset(_spname, sqlparams1)
                For j = 0 To vRate.Tables(0).Rows.Count - 1
                    dt.Tables(0).Rows.Add(vRate.Tables(0).Rows(j).ItemArray)
                Next

            Catch ex As Exception
                Throw ex
            End Try
        Next
        Return dt

    End Function


    Public Shared Function getVendorServices(ByVal _Code As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillVendorService")
            sqlparams(1) = New SqlParameter("@Ven_Code", _Code)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getVendorDetails(ByVal _Code As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillVenderDetails")
            sqlparams(1) = New SqlParameter("@Ven_ID", _Code)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getVendorRestriction(ByVal _Code As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillVenderRestriction")
            sqlparams(1) = New SqlParameter("@Ven_ID", _Code)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function getVendorBreakdown(ByVal _Code As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillVenderBreakdown")
            sqlparams(1) = New SqlParameter("@Ven_ID", _Code)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
