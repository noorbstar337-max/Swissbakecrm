Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class MainWebsiteBLL

#Region "Main Function"
    Public Shared Function MainWebsiteFill(ByVal _Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", _Mode)
            Return DBBridge.ExecuteDataset("_spMainWebsiteData", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Partner(ByVal _Mode As String) As DataSet
        If Not HttpRuntime.Cache("DynamicparcelPartner") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelPartner")
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", _Mode)
            HttpRuntime.Cache.Add("DynamicparcelPartner", DBBridge.ExecuteDataset("_spMainWebsiteData", sqlparams), Nothing, Date.MaxValue, TimeSpan.Zero, _
                               CacheItemPriority.Normal, Nothing)
            Return DirectCast(HttpRuntime.Cache("DynamicparcelPartner"), DataSet)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SiteMasterVendor() As DataSet
        If Not HttpRuntime.Cache("DynamicparcelMasterVendor") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelMasterVendor")
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "VendorMasterWebsite")
            HttpRuntime.Cache.Add("DynamicparcelMasterVendor", DBBridge.ExecuteDataset("_spMainWebsiteData", sqlparams), Nothing, Date.MaxValue, TimeSpan.Zero, _
                           CacheItemPriority.Normal, Nothing)
            Return DirectCast(HttpRuntime.Cache("DynamicparcelMasterVendor"), DataSet)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function BottomSlider() As DataSet
        If Not HttpRuntime.Cache("DynamicparcelSlider") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelSlider")
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillHomeImage")
            HttpRuntime.Cache.Add("DynamicparcelSlider", DBBridge.ExecuteDataset("_spMainWebsiteData", sqlparams), Nothing, Date.MaxValue, TimeSpan.Zero, _
                           CacheItemPriority.Normal, Nothing)
            Return DirectCast(HttpRuntime.Cache("DynamicparcelSlider"), DataSet)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UserControlMasterVendor() As DataSet
        If Not HttpRuntime.Cache("DynamicparcelUserControlVendor") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelUserControlVendor")
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "VendorWebsite")
            HttpRuntime.Cache.Add("DynamicparcelUserControlVendor", DBBridge.ExecuteDataset("_spMainWebsiteData", sqlparams), Nothing, Date.MaxValue, TimeSpan.Zero, _
                           CacheItemPriority.Normal, Nothing)
            Return DirectCast(HttpRuntime.Cache("DynamicparcelUserControlVendor"), DataSet)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
   
#Region "Cache Function"
    Public Shared Function GetSiteMasterVendorFromcache() As DataSet
        If HttpRuntime.Cache("DynamicparcelMasterVendor") Is Nothing Then
            MainWebsiteBLL.SiteMasterVendor()
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelMasterVendor"), DataSet)
    End Function

    Public Shared Function GetBottomSliderFromcache() As DataSet
        If HttpRuntime.Cache("DynamicparcelSlider") Is Nothing Then
            MainWebsiteBLL.BottomSlider()
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelSlider"), DataSet)
    End Function

    Public Shared Function GetUserControlMasterVendorFromcache() As DataSet
        If HttpRuntime.Cache("DynamicparcelUserControlVendor") Is Nothing Then
            MainWebsiteBLL.UserControlMasterVendor()
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelUserControlVendor"), DataSet)
    End Function

    Public Shared Function DynamicparcelPartner(ByVal _Mode As String) As DataSet
        If HttpRuntime.Cache("DynamicparcelPartner") Is Nothing Then
            MainWebsiteBLL.Partner(_Mode)
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelPartner"), DataSet)
    End Function
#End Region

End Class
