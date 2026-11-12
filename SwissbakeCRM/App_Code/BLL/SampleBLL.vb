Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class SampleBLL
    Public Shared Function InsertProductLinkCrm(ByVal ProductLink_TypeId As Integer, ByVal ProductLink_Type As String, ByVal ProductLink_ProductId As Integer, ByVal ProductLink_CreatedId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertProductLinkCrm")
            sqlparams(1) = New SqlParameter("@ProductLink_TypeId", ProductLink_TypeId)
            sqlparams(2) = New SqlParameter("@ProductLink_Type", ProductLink_Type)
            sqlparams(3) = New SqlParameter("@ProductLink_ProductId", ProductLink_ProductId)
            sqlparams(4) = New SqlParameter("@ProductLink_CreatedId", ProductLink_CreatedId)
            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteProductLinkCrm(ByVal ProductLink_TypeId As Integer, ByVal ProductLink_Type As String) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteProductLinkCrm")
            sqlparams(1) = New SqlParameter("@ProductLink_TypeId", ProductLink_TypeId)
            sqlparams(2) = New SqlParameter("@ProductLink_Type", ProductLink_Type)
         Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    ''' <summary>
    ''' Coppied from mainbll
    ''' </summary>
    ''' <param name="PageIndex"></param>
    ''' <param name="PageSize"></param>
    ''' <param name="Id"></param>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks> by sufiyan on 06-01-2018 </remarks>
    Public Shared Function FillGridViewById(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Id As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''' <summary>
    '''  Coppied from mainbll
    ''' </summary>
    ''' <param name="SearchValue"></param>
    ''' <param name="Id"></param>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks> by sufiyan on 06-01-2018 </remarks>
    Public Shared Function SearchGridViewByID(ByVal SearchValue As String, ByVal Id As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@id", Id)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''  Coppied from mainbll
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <param name="Id"></param>
    ''' <returns></returns>
    ''' <remarks> by sufiyan on 06-01-2018 </remarks>
    Public Shared Function SortingGridViewById(ByVal Mode As String, ByVal Id As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''   Coppied from mainbll
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks> by sufiyan on 06-01-2018</remarks>
    Public Shared Function TotalRowInGridviewBYID(ByVal Mode As String, ByVal ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", ID)
            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    '''   Coppied from mainbll
    ''' </summary>
    ''' <param name="Mode"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks> by sufiyan on 08-01-2018</remarks>
    Public Shared Function DeleteSI(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String, ByVal AudtTrail_LogId As Integer) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function ViewByID(ByVal ID As Integer, ByVal Mode As String, ByVal Type As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@Type", Type)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewItemDetail(ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ViewSampleItemDetail")
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function





    'Copied from MainBLL and Changed Sp Name
    Public Shared Function Dropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function ViewByID(ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertSampleRequest(ByVal SampleRequest_No As String, ByVal SampleRequest_Date As String, ByVal SampleRequest_Type As String, ByVal SampleRequest_TypeId As Integer, ByVal SampleRequest_CreatedId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertSampleRequest")
            'sqlparams(1) = New SqlParameter("@SampleRequest_Id", ID)
            ' sqlparams(2) = New SqlParameter("@SampleRequest_No", SampleRequest_No)
            sqlparams(3) = New SqlParameter("@SampleRequest_Date", SampleRequest_Date)
            sqlparams(4) = New SqlParameter("@SampleRequest_Type", SampleRequest_Type)
            sqlparams(5) = New SqlParameter("@SampleRequest_TypeId", SampleRequest_TypeId)
            'sqlparams(6) = New SqlParameter("@SampleRequest_ViewFlag", ID)
            'sqlparams(7) = New SqlParameter("@SampleRequest_SampleStatus", SampleRequest_SampleStatus)
            sqlparams(8) = New SqlParameter("@SampleRequest_CreatedId", SampleRequest_CreatedId)

            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertSampleRequestDetail(ByVal SampleRequestDetail_SampleRequestId As Integer, ByVal SampleRequestDetail_ProductId As Integer, ByVal SampleRequestDetail_ProductQnty As Double, ByVal SampleRequestDetail_Remark As String, ByVal SampleRequestDetail_Feedback As String, ByVal SampleRequestDetail_Approved As Boolean, ByVal SampleRequestDetail_Ordered As Boolean, ByVal SampleRequestDetail_CreatedId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertSampleRequestDetail")
            sqlparams(1) = New SqlParameter("@SampleRequestDetail_SampleRequestId", SampleRequestDetail_SampleRequestId)
            sqlparams(2) = New SqlParameter("@SampleRequestDetail_ProductId", SampleRequestDetail_ProductId)
            sqlparams(3) = New SqlParameter("@SampleRequestDetail_ProductQnty", SampleRequestDetail_ProductQnty)
            sqlparams(4) = New SqlParameter("@SampleRequestDetail_Remark", SampleRequestDetail_Remark)
            sqlparams(5) = New SqlParameter("@SampleRequestDetail_Feedback", SampleRequestDetail_Feedback)
            sqlparams(6) = New SqlParameter("@SampleRequestDetail_Approved", SampleRequestDetail_Approved)
            sqlparams(7) = New SqlParameter("@SampleRequestDetail_Ordered", SampleRequestDetail_Ordered)
            sqlparams(8) = New SqlParameter("@SampleRequestDetail_CreatedId", SampleRequestDetail_CreatedId)

            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DeleteSampleRequestDetail(ByVal Id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteSampleRequestDetail")
            sqlparams(1) = New SqlParameter("@Id", Id)
            ' sqlparams(2) = New SqlParameter("@ProductLink_Type", ProductLink_Type)
            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownWithtypeAndID1(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillBillingAddr(ByVal Mode As String, ByVal _ID As Integer) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            'sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            'sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function InsertSampleRequestAddress(ByVal SamReqAddr_SampleRequestId As Integer, ByVal SamReqAddr_Address As String, ByVal SamReqAddr_Pincode As String, ByVal SamReqAddr_Country As Integer, ByVal SamReqAddr_State As Integer, ByVal SamReqAddr_City As String, ByVal SamReqAddr_CreatedId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertSampleRequestAddress")
            sqlparams(1) = New SqlParameter("@SamReqAddr_SampleRequestId", SamReqAddr_SampleRequestId)
            sqlparams(2) = New SqlParameter("@SamReqAddr_Address", SamReqAddr_Address)
            sqlparams(3) = New SqlParameter("@SamReqAddr_Pincode", SamReqAddr_Pincode)
            sqlparams(4) = New SqlParameter("@SamReqAddr_Country", SamReqAddr_Country)
            sqlparams(5) = New SqlParameter("@SamReqAddr_State", SamReqAddr_State)
            sqlparams(6) = New SqlParameter("@SamReqAddr_City", SamReqAddr_City)
            sqlparams(7) = New SqlParameter("@SamReqAddr_CreatedId", SamReqAddr_CreatedId)
            'sqlparams(8) = New SqlParameter("@SampleRequestDetail_CreatedId", SampleRequestDetail_CreatedId)

            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdateSampleRequestAddress(ByVal SamReqAddr_SampleRequestId As Integer, ByVal SamReqAddr_Address As String, ByVal SamReqAddr_Pincode As String, ByVal SamReqAddr_Country As Integer, ByVal SamReqAddr_State As Integer, ByVal SamReqAddr_City As String, ByVal SamReqAddr_ModifiedId As Integer) As Integer
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateSampleRequestAddress")
            sqlparams(1) = New SqlParameter("@SamReqAddr_SampleRequestId", SamReqAddr_SampleRequestId)
            sqlparams(2) = New SqlParameter("@SamReqAddr_Address", SamReqAddr_Address)
            sqlparams(3) = New SqlParameter("@SamReqAddr_Pincode", SamReqAddr_Pincode)
            sqlparams(4) = New SqlParameter("@SamReqAddr_Country", SamReqAddr_Country)
            sqlparams(5) = New SqlParameter("@SamReqAddr_State", SamReqAddr_State)
            sqlparams(6) = New SqlParameter("@SamReqAddr_City", SamReqAddr_City)
            sqlparams(7) = New SqlParameter("@SamReqAddr_ModifiedId", SamReqAddr_ModifiedId)
            'sqlparams(8) = New SqlParameter("@SampleRequestDetail_CreatedId", SampleRequestDetail_CreatedId)
            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateStatus(ByVal Mode As String, ByVal _ID As Integer, ByVal Status As String, ByVal ModifiedID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Status", Status)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@ModifiedID", ModifiedID)
            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function UpdateView(ByVal Mode As String, ByVal _ID As Integer) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", _ID)

            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GenerateCode(ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' 'Copied From MainBll
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="Mode"></param>
    ''' <returns></returns>
    ''' <remarks>Sufiyan on 12-01-2018</remarks>
    Public Shared Function CheckPageNameWithID(ByVal _Value As String, ByVal _ID As Integer, ByVal Mode As String) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteScalar("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateDesc(ByVal Mode As String, ByVal _ID As Integer, ByVal Value As String, ByVal Type As String, ByVal ModifiedId As Integer) As Integer
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", _ID)
            sqlparams(2) = New SqlParameter("@Value", Value)
            sqlparams(3) = New SqlParameter("@Type", Type)
            sqlparams(4) = New SqlParameter("@ModifiedID", ModifiedId)
            Return DBBridge.ExecuteNonQuery("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownForAccountContact(ByVal Mode As String, ByVal Type As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownWithtype(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function comanyDropdownWithID(ByVal Mode As String, ByVal id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", id)

            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownWithPrevDate(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UserDropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spReport", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function InsertCity(ByVal Mode As String, ByVal _ID As Integer, ByVal Type As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteDataset("_spSample", sqlparams)
        Catch ex As Exception
            Throw ex
            'ModifySampleRequest.aspx Add By Altaf 16-Apr-2018
        End Try
    End Function
    Public Shared Function DropdownWithtypeAndID(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            Return DBBridge.ExecuteDataset("_spsample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
   
    Public Shared Function ddbyaccID(ByVal Mode As String, ByVal _ID As Integer) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            'sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteDataset("_spsample", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Shared Function LiveDropdownWithtypeAndID(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String, ByVal value As String) As DataSet
    '    Dim sqlparams(5) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", Mode)
    '        sqlparams(1) = New SqlParameter("@Type", Type)
    '        sqlparams(2) = New SqlParameter("@ID", _ID)
    '        sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
    '        sqlparams(4) = New SqlParameter("@value", value)
    '        Return DBBridge.ExecuteDataset("_spsample", sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Shared Function LiveDropdownWithtypeAndID(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String, ByVal value As String) As DataSet
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            sqlparams(4) = New SqlParameter("@value", value)
            Return DBBridge.ExecuteDataset("_spNewDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
