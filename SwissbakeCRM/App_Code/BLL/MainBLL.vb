Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Public Class MainBLL

    Public Shared Function FillGridView(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteDataset("_spFillUserByPaging", sqlparams)
        Catch ex As Exception
			Throw ex
			'polist.aspx search
		End Try
    End Function
    'Public Shared Function FillGridViewDiscount(ByVal Mode As String, ByVal Id As Integer) As DataSet
    '    Dim sqlparams(1) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", Mode)
    '        sqlparams(1) = New SqlParameter("@Id", Id)
    '        Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    'Public Shared Function FillGridViewDiscountbyid(ByVal Mode As String, ByVal Id As Integer, ByVal Product_id As Integer) As DataSet
    '    Dim sqlparams(3) As SqlParameter
    '    Try
    '        sqlparams(0) = New SqlParameter("@Mode", Mode)
    '        sqlparams(1) = New SqlParameter("@Id", Id)
    '        sqlparams(2) = New SqlParameter("@Product_id", Product_id)
    '        Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
     Public Shared Function FillGridViewById(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Id As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '==================================GAYATRI 22-07-2017==========================================
    Public Shared Function FillGridViewById(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Id As Integer, ByVal Mode As String, ByVal Status As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Id", Id)
            sqlparams(4) = New SqlParameter("@Status", Status)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '==============================================================================================

    Public Shared Function ColoumName(ByVal TableName As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ColoumName")
            sqlparams(1) = New SqlParameter("@AudtTrail_PageName", TableName)
            Return DBBridge.ExecuteDataset("_spAuditTrail", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ConactTypeDropdown(ByVal ConactType As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ConactTypeDropdown")
            sqlparams(1) = New SqlParameter("@Type", ConactType)
            Return DBBridge.ExecuteDataset("_spTypeandTypeID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DynamicColoumPaging(ByVal Coloum As String, ByVal PageIndex As Integer, ByVal PageSize As Integer,
                                               ByVal PrimaryID As String, ByVal Del As String, ByVal table As String, ByVal UseriD As Integer) As DataSet
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@DyamicColoum", Coloum)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@PrimaryID", PrimaryID)
            sqlparams(4) = New SqlParameter("@Del", Del)
            sqlparams(5) = New SqlParameter("@table", table)
            sqlparams(6) = New SqlParameter("@UserId", UseriD)
            Return DBBridge.ExecuteDataset("_spdynamicfillpaging", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function GetCode(ByVal Mode As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteScalar("_spCode", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''Created by ajay on 18-01-2017 for quattion    
    Public Shared Function GetGodownCode(ByVal Mode As String, Optional ByVal Id As Integer = 0) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", Id)
            Return DBBridge.ExecuteScalar("_spCode", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    ''Created by ajay on 18-01-2017 for quattion  

    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset("_spSearchUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '============================gayatri 22-07-2017==============================================================
    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String, ByVal Status As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@Status", Status)
            Return DBBridge.ExecuteDataset("_spSearchUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '===============================================================================================================

    Public Shared Function SearchGridViewByID(ByVal SearchValue As String, ByVal Id As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@id", Id)
            Return DBBridge.ExecuteDataset("_spSearchById", sqlparams)
        Catch ex As Exception
			Throw ex
			'polist.aspx search
		End Try
    End Function
    ' =============================================Gayatri 21-07-2017========================================================================================
    Shared Function SearchGridViewByID(ByVal SearchValue As String, ByVal Id As Integer, ByVal Mode As String, ByVal Status As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@id", Id)
            sqlparams(3) = New SqlParameter("@Status", Status)
            Return DBBridge.ExecuteDataset("_spSearchById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '=====================================================================================================================================
    Public Shared Function SearchGridstatusID(ByVal SearchValue As String, ByVal status As String, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@status", status)
            Return DBBridge.ExecuteDataset("_spSearchById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TotalRowInGridview(ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteScalar("_spTotalNumberOfUserRecord", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function TotalRowInGridviewBYID(ByVal Mode As String, ByVal ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", ID)
            Return DBBridge.ExecuteScalar("_spTotalNumberOfUserRecordByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SortingGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spFillAllUserRecordForSorting", sqlparams)
        Catch ex As Exception
            'Polist.aspx sort
            Throw ex
        End Try
    End Function
    '==========================================gayatri 21-07-2017=================================================
    Public Shared Function SortingGridView(ByVal Mode As String, ByVal status As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Status", status)
            Return DBBridge.ExecuteDataset("_spFillAllUserRecordForSorting", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function TotalRowInGridviewBYID(ByVal Mode As String, ByVal ID As Integer, ByVal status As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", ID)
            sqlparams(2) = New SqlParameter("@Status", status)
            Return DBBridge.ExecuteScalar("_spTotalNumberOfUserRecordByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '====================================================================================================

    Public Shared Function SortingGridViewById(ByVal Mode As String, ByVal Id As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spAllRecordForSortingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Use on POlist Cancel button to cancel polist.aspx
    Public Shared Function DeleteSI(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String, ByVal AudtTrail_LogId As Integer) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar("_spDeleteSiUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Delete(ByVal ID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            Return DBBridge.ExecuteScalar("_spDeleteSiUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Restore(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            Return DBBridge.ExecuteScalar("_spRestore", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateStatus(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar("_spUpdateUserStatus", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateStatusHomepageImage(ByVal ID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)

            Return DBBridge.ExecuteScalar("_spUpdateUserStatus", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewByID(ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function ViewByDateID(ByVal ID As Integer, ByVal Mode As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Shared Function ViewByDateCity(ByVal City As String, ByVal Mode As String, ByVal StartDate As Date, ByVal EndDate As Date) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@City", City)
            sqlparams(2) = New SqlParameter("@StartDate", StartDate)
            sqlparams(3) = New SqlParameter("@EndDate", EndDate)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateTheme(ByVal ID As Integer, ByVal U_Theme As String, ByVal Mode As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_Theme", U_Theme)

            Return DBBridge.ExecuteScalar("_spInsertUser", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ThemeViewByID(ByVal ID As Integer, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Dropdown(ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CRMDiscountDropdown(ByVal Mode As String, ByVal type As String, ByVal Catagory As String, ByVal id As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@type", type)
            sqlparams(2) = New SqlParameter("@Catagory", Catagory)
            sqlparams(3) = New SqlParameter("@id", id)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
        ' 05-03-18 Altaf added ret in query for discount.aspx
    End Function

    'gayatri added this on 16-08-2017
    Public Shared Function Dropdown(ByVal Mode As String, ByVal CategoryId As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Product_CategoryId", CategoryId)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownByuser(ByVal Mode As String, ByVal ID As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownWithtype(ByVal Mode As String, ByVal Type As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownWithtypeAndID(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
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
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownWithID(ByVal Mode As String, ByVal _ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownWithname(ByVal Mode As String, ByVal _country As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@type", _country)
            Return DBBridge.ExecuteDataset("_spDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPageName(ByVal _Value As String, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckSequenceNo(ByVal ID As Integer, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function CheckPageNameWithID(ByVal _Value As String, ByVal _ID As Integer, ByVal Mode As String) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPageNameWithType(ByVal _Value As String, ByVal _Type As String, ByVal Mode As String) As String
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            sqlparams(2) = New SqlParameter("@Type", _Type)
            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function MenuParentID(ByVal ID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            Return DBBridge.ExecuteScalar("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillRecycleBin(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spFillrecyclebin", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DynamicparcelMenu() As String
        If HttpRuntime.Cache("DynamicparcelMenu") Is Nothing Then
            Dim spoorfishMenu As New MenuDemo
            spoorfishMenu.ExecuteXSLTransformation()
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelMenu"), String)
    End Function

    Public Shared Function DynamicparcelMenuFooter() As String
        If HttpRuntime.Cache("DynamicparcelMenuFooter") Is Nothing Then

        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelMenuFooter"), String)
    End Function

    Public Shared Sub AddDynamicparcelMenuFooter(ByVal _Html As String)
        If Not HttpRuntime.Cache("DynamicparcelMenuFooter") Is Nothing Then HttpRuntime.Cache.Remove("DynamicparcelMenuFooter")
        HttpRuntime.Cache.Add("DynamicparcelMenuFooter", _Html, Nothing, Date.MaxValue, TimeSpan.Zero, _
                                  CacheItemPriority.Normal, Nothing)
    End Sub

    Public Shared Function DynamicparcelMenuFooterChild(ByVal _ID As Integer) As DataSet
        If HttpRuntime.Cache("DynamicparcelMenuFooterChild") Is Nothing Then
            Return MenuFooterBLL.ChildFooter(_ID)
        End If
        Return DirectCast(HttpRuntime.Cache("DynamicparcelMenuFooterChild"), DataSet)
    End Function

    Public Shared Function GetUserName(ByVal ID As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_spGetUserName", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DeleteSIWithModifiedType(ByVal ID As Integer, ByVal ModifiedType As String, ByVal ModifiedID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedType", ModifiedType)
            sqlparams(3) = New SqlParameter("@U_ModifiedID", ModifiedID)
            Return DBBridge.ExecuteScalar("_spDelete", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateStatusWithModifiedType(ByVal ID As Integer, ByVal ModifiedType As String, ByVal ModifiedID As Integer, ByVal Mode As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedType", ModifiedType)
            sqlparams(3) = New SqlParameter("@U_ModifiedID", ModifiedID)
            Return DBBridge.ExecuteScalar("_spUpdateStatus", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NumbersToWords(ByVal inputNumber As Integer) As String
        Dim inputNo As Integer = inputNumber

        If inputNo = 0 Then
            Return "Zero"
        End If

        Dim numbers As Integer() = New Integer(3) {}
        Dim first As Integer = 0
        Dim u As Integer, h As Integer, t As Integer
        Dim sb As New System.Text.StringBuilder()

        If inputNo < 0 Then
            sb.Append("Minus ")
            inputNo = -inputNo
        End If

        Dim words0 As String() = {"", "One ", "Two ", "Three ", "Four ", "Five ", _
         "Six ", "Seven ", "Eight ", "Nine "}
        Dim words1 As String() = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", _
         "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "}
        Dim words2 As String() = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", _
         "Eighty ", "Ninety "}
        Dim words3 As String() = {"Thousand ", "Lakh ", "Crore "}

        numbers(0) = inputNo Mod 1000
        ' units
        numbers(1) = inputNo \ 1000
        numbers(2) = inputNo \ 100000
        numbers(1) = numbers(1) - 100 * numbers(2)
        ' thousands
        numbers(3) = inputNo \ 10000000
        ' crores
        numbers(2) = numbers(2) - 100 * numbers(3)
        ' lakhs
        For i As Integer = 3 To 1 Step -1
            If numbers(i) <> 0 Then
                first = i
                Exit For
            End If
        Next
        For i As Integer = first To 0 Step -1
            If numbers(i) = 0 Then
                Continue For
            End If
            u = numbers(i) Mod 10
            ' ones
            t = numbers(i) \ 10
            h = numbers(i) \ 100
            ' hundreds
            t = t - 10 * h
            ' tens
            If h > 0 Then
                sb.Append(words0(h) & "Hundred ")
            End If
            If u > 0 OrElse t > 0 Then
                If h > 0 OrElse i = 0 Then
                    sb.Append(" ")
                End If
                If t = 0 Then
                    sb.Append(words0(u))
                ElseIf t = 1 Then
                    sb.Append(words1(u))
                Else
                    sb.Append(words2(t - 2) & words0(u))
                End If
            End If
            If i <> 0 Then
                sb.Append(words3(i - 1))
            End If
        Next
        Return sb.ToString().TrimEnd()
    End Function


    Public Shared Function QResponseViewByID(ByVal ID As Integer, ByVal VID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@VendorID", VID)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function CheckVendorName(ByVal _Value As String, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
            'modifyVendor.aspx addnew textchange --- Altaf 17-feb-2018 
        End Try
    End Function

    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String, ByVal Type As String, ByVal id As Integer) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            sqlparams(2) = New SqlParameter("@ID", id)
            sqlparams(3) = New SqlParameter("@Type", Type)
            Return DBBridge.ExecuteDataset("_spSearchUser", sqlparams)
        Catch ex As Exception
            Throw ex
            'altaf added Type for productlist.aspx 6-mar-18
        End Try
    End Function


    Public Shared Function FillGridViewDiscountbyid(ByVal Mode As String, ByVal Id As Integer, ByVal Product_id As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Product_id", Product_id)
            Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
        Catch ex As Exception
            Throw ex
            'Discount.aspx altaf add Packing_packing 06-mar-2018
        End Try
    End Function

    Public Shared Function FillGridViewDiscount(ByVal Mode As String, ByVal Id As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
        Catch ex As Exception
            Throw ex
            'Discount.aspx altaf add Packing_packing 06-mar-2018
        End Try
    End Function

    Public Shared Function getemailbyid(ByVal type As String, ByVal Id As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@type", type)
            sqlparams(2) = New SqlParameter("@Id ", Id)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
            'ModifyCustomerComplaint.aspx altaf 
        End Try
    End Function
    Public Shared Function BlockByID(ByVal ID As Integer, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
            'Modifysalesorder.aspx altaf
        End Try
    End Function
    Public Shared Function CheckEmail(ByVal _Value As String, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            Return DBBridge.ExecuteScalar("_spCheckExist", sqlparams)
        Catch ex As Exception
            Throw ex
            'altaf 16-apr-18 lead.aspx  quick insert modifylead.aspx/ ModifyAccount.aspx / ModifyProspect.aspx
        End Try
    End Function
    Public Shared Function Email(ByVal usserid As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getowneremail")
            sqlparams(1) = New SqlParameter("@U_ID", usserid)
            Return DBBridge.ExecuteScalar("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
            'add by altaf 02-apr-2018 cart.aspx sendinding email
        End Try
    End Function
    Public Shared Function CustEmail(ByVal usserid As Integer) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "getCustemail")
            sqlparams(1) = New SqlParameter("@U_ID", usserid)
            Return DBBridge.ExecuteScalar("_spUser", sqlparams)
        Catch ex As Exception
            Throw ex
            'add by altaf 02-apr-2018 multipleipay.aspx sendinding email
        End Try
    End Function

    Public Shared Function AccTypeByID(ByVal Mode As String, ByVal Id As Integer) As String '--Added by MUBYN used in ModifyCustomerComplaint.aspx on 01-08-2018----
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteScalar("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ViewByIDs(ByVal ID As Integer, ByVal ID1 As Integer, ByVal Mode As String) As DataSet   'added by nilesh used in view lead,prospect,account
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            sqlparams(2) = New SqlParameter("@ID1", ID1)
            Return DBBridge.ExecuteDataset("_ViewByID", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
	  Public Shared Function FillGridByID(ByVal Mode As String, ByVal Id As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillGrid(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spFillByPaging", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function NewDropdownWithtypeAndID(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            Return DBBridge.ExecuteDataset("_spNewDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function NewDropdownWithtypeAndID1(ByVal Mode As String, ByVal Type As String, ByVal _ID As Integer, ByVal QuatationType As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Type", Type)
            sqlparams(2) = New SqlParameter("@ID", _ID)
            sqlparams(3) = New SqlParameter("@QuatationType", QuatationType)
            Return DBBridge.ExecuteDataset("_spNewDropdown", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillLeadFilter(ByVal Mode As String, ByVal Id As Integer, ByVal Lead_Name As String, ByVal LeadContact_Name As String, ByVal LeadContact_OfficeNo As String,
                                          ByVal LeadContact_Email As String, ByVal LeadContact_MobileNo As String, ByVal City As String, ByVal Stage_Name As String,
                                          ByVal Source_Name As String, ByVal AssignTo As String) As DataSet
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Lead_Name", Lead_Name)
            sqlparams(3) = New SqlParameter("@LeadContact_Name", LeadContact_Name)
            sqlparams(4) = New SqlParameter("@LeadContact_OfficeNo", LeadContact_OfficeNo)
            sqlparams(5) = New SqlParameter("@LeadContact_Email", LeadContact_Email)
            sqlparams(6) = New SqlParameter("@LeadContact_MobileNo", LeadContact_MobileNo)
            sqlparams(7) = New SqlParameter("@City", City)
            sqlparams(8) = New SqlParameter("@AssignTo", AssignTo)
            sqlparams(9) = New SqlParameter("@Stage_Name", Stage_Name)
            sqlparams(10) = New SqlParameter("@Source_Name", Source_Name)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillProspectFilter(ByVal Mode As String, ByVal Id As Integer, ByVal Acc_Name As String, ByVal Contact_ContactPerson As String, ByVal Contact_Landline As String,
                                          ByVal Contact_Email As String, ByVal Contact_Mobile As String, ByVal City As String, ByVal AssignTo As String) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(3) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            sqlparams(4) = New SqlParameter("@Contact_Landline", Contact_Landline)
            sqlparams(5) = New SqlParameter("@Contact_Email", Contact_Email)
            sqlparams(6) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            sqlparams(7) = New SqlParameter("@City", City)
            sqlparams(8) = New SqlParameter("@AssignTo", AssignTo)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillAccountFilter(ByVal Mode As String, ByVal Id As Integer, ByVal Acc_Name As String, ByVal Contact_ContactPerson As String, ByVal Contact_Landline As String,
                                         ByVal Contact_Email As String, ByVal Contact_Mobile As String, ByVal City As String, ByVal AssignTo As String,
                                         ByVal U_FirstName As String, ByVal CreatedBy As String, ByVal Acc_OpenFrom As String) As DataSet
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(3) = New SqlParameter("@Contact_ContactPerson", Contact_ContactPerson)
            sqlparams(4) = New SqlParameter("@Contact_Landline", Contact_Landline)
            sqlparams(5) = New SqlParameter("@Contact_Email", Contact_Email)
            sqlparams(6) = New SqlParameter("@Contact_Mobile", Contact_Mobile)
            sqlparams(7) = New SqlParameter("@City", City)
            sqlparams(8) = New SqlParameter("@AssignTo", AssignTo)
            sqlparams(9) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(10) = New SqlParameter("@CreatedBy", CreatedBy)
            sqlparams(11) = New SqlParameter("@Acc_OpenFrom", Acc_OpenFrom)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillSalesOrderFilter(ByVal Mode As String, ByVal Id As Integer, ByVal Order_Code As String, ByVal Order_CreatedDate As String,
                                                ByVal Acc_Name As String, ByVal amount As String, ByVal City As String, ByVal Order_OrderStatus As String,
                                                ByVal AccountOwner As String, ByVal AssignTo As String, ByVal AccCreatedBy As String, ByVal Order_type As String) As DataSet
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Order_Code", Order_Code)
            sqlparams(3) = New SqlParameter("@Order_CreatedDate", Order_CreatedDate)
            sqlparams(4) = New SqlParameter("@Acc_Name", Acc_Name)
            sqlparams(5) = New SqlParameter("@amount", amount)
            sqlparams(6) = New SqlParameter("@City", City)
            sqlparams(7) = New SqlParameter("@Order_OrderStatus", Order_OrderStatus)
            sqlparams(8) = New SqlParameter("@AccountOwner", AccountOwner)
            sqlparams(9) = New SqlParameter("@AssignTo", AssignTo)
            sqlparams(10) = New SqlParameter("@AccCreatedBy", AccCreatedBy)
            sqlparams(11) = New SqlParameter("@Order_type", Order_type)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillActivityFilter(ByVal Mode As String, ByVal ID As Integer, ByVal SearchValue As String, ByVal Type As String,
                                              ByVal RelatedType As String, ByVal Name As String,
                                              ByVal Subject As String, ByVal ActivityType As String, ByVal From1 As String, ByVal To1 As String,
                                              ByVal Priority As String, ByVal Status As String, ByVal AssignTo As String, ByVal Activity_Description As String) As DataSet
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Activity_Id", ID)
            sqlparams(2) = New SqlParameter("@SearchValue", SearchValue)
            If Type = "" Then
                sqlparams(3) = New SqlParameter("@Type", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Type", Type)
            End If
            sqlparams(4) = New SqlParameter("@RelatedType", RelatedType)
            sqlparams(5) = New SqlParameter("@Name", Name)
            sqlparams(6) = New SqlParameter("@Subject", Subject)
            sqlparams(7) = New SqlParameter("@ActivityType", ActivityType)
            sqlparams(8) = New SqlParameter("@From1", From1)
            sqlparams(9) = New SqlParameter("@To1", To1)
            sqlparams(10) = New SqlParameter("@Priority", Priority)
            sqlparams(11) = New SqlParameter("@Status", Status)
            sqlparams(12) = New SqlParameter("@AssignTo", AssignTo)
            sqlparams(13) = New SqlParameter("@Activity_Description", Activity_Description)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillQuotationFilter(ByVal Mode As String, ByVal Id As Integer, ByVal Quotation_No As String, ByVal Quotation_Date As String, ByVal Quotation_QuoStatus As String,
                                               ByVal Acc_name As String, ByVal FinalAmount As String, ByVal AssignTo As String) As DataSet
        Dim sqlparams(8) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@Quotation_No", Quotation_No)
            sqlparams(3) = New SqlParameter("@Quotation_Date", Quotation_Date)
            sqlparams(4) = New SqlParameter("@Quotation_QuoStatus", Quotation_QuoStatus)
            sqlparams(5) = New SqlParameter("@Acc_name", Acc_name)
            sqlparams(6) = New SqlParameter("@FinalAmount", FinalAmount)
            sqlparams(7) = New SqlParameter("@AssignTo", AssignTo)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillSampleReqFilter(ByVal Mode As String, ByVal Id As Integer, ByVal SampleRequest_No As String, ByVal SampleRequest_Date As String,
                                               ByVal CompanyName As String, ByVal ContactName As String, ByVal qty As String, ByVal AssignTo As String,
                                               ByVal SampleRequest_SampleStatus As String) As DataSet
        Dim sqlparams(9) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@SampleRequest_No", SampleRequest_No)
            sqlparams(3) = New SqlParameter("@SampleRequest_Date", SampleRequest_Date)
            sqlparams(4) = New SqlParameter("@CompanyName", CompanyName)
            sqlparams(5) = New SqlParameter("@ContactName", ContactName)
            sqlparams(6) = New SqlParameter("@qty", qty)
            sqlparams(7) = New SqlParameter("@AssignTo", AssignTo)
            sqlparams(8) = New SqlParameter("@SampleRequest_SampleStatus", SampleRequest_SampleStatus)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillPOListFilter(ByVal Mode As String, ByVal Id As Integer, ByVal QuotationRequest_No As String, ByVal PONO As String,
                                            ByVal PODate As String, ByVal Vendor_Name As String, ByVal Rm_Name As String, ByVal Quantity As String,
                                            ByVal Amount As String, ByVal Per_Unit As String, ByVal Tax As String, ByVal Total As String, ByVal PurchaseOrder_EmailVendor As String) As DataSet
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@QuotationRequest_No", QuotationRequest_No)
            sqlparams(3) = New SqlParameter("@PONO", PONO)
            sqlparams(4) = New SqlParameter("@PODate", PODate)
            sqlparams(5) = New SqlParameter("@Vendor_Name", Vendor_Name)
            sqlparams(6) = New SqlParameter("@Rm_Name", Rm_Name)
            sqlparams(7) = New SqlParameter("@Quantity", Quantity)
            sqlparams(8) = New SqlParameter("@Amount", Amount)
            sqlparams(9) = New SqlParameter("@Per_Unit", Per_Unit)
            sqlparams(10) = New SqlParameter("@Tax", Tax)
            sqlparams(11) = New SqlParameter("@Total", Total)
            sqlparams(12) = New SqlParameter("@PurchaseOrder_EmailVendor", PurchaseOrder_EmailVendor)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillQuotRespFilter(ByVal Mode As String, ByVal Id As Integer, ByVal QuotationRequest_No As String, ByVal Vendor_Name As String,
                                              ByVal Rm_Name As String, ByVal Quantity As String, ByVal Amount As String, ByVal Per_Unit As String,
                                              ByVal Tax As String, ByVal Freight As String, ByVal Total As String, ByVal QuotationResponse_Status As String) As DataSet
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@QuotationRequest_No", QuotationRequest_No)
            sqlparams(3) = New SqlParameter("@Vendor_Name", Vendor_Name)
            sqlparams(4) = New SqlParameter("@Rm_Name", Rm_Name)
            sqlparams(5) = New SqlParameter("@Quantity", Quantity)
            sqlparams(6) = New SqlParameter("@Amount", Amount)
            sqlparams(7) = New SqlParameter("@Per_Unit", Per_Unit)
            sqlparams(8) = New SqlParameter("@Tax", Tax)
            sqlparams(9) = New SqlParameter("@Freight", Freight)
            sqlparams(10) = New SqlParameter("@Total", Total)
            sqlparams(11) = New SqlParameter("@QuotationResponse_Status", QuotationResponse_Status)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillQuotRequestFilter(ByVal Mode As String, ByVal Id As Integer, ByVal QuotationRequest_No As String, ByVal QuotationRequest_Date As String,
                                             ByVal Godown_Name As String, ByVal Rm_Name As String, ByVal QRRawMaterial_Quantity As String) As DataSet
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@QuotationRequest_No", QuotationRequest_No)
            sqlparams(3) = New SqlParameter("@QuotationRequest_Date", QuotationRequest_Date)
            sqlparams(4) = New SqlParameter("@Godown_Name", Godown_Name)
            sqlparams(5) = New SqlParameter("@Rm_Name", Rm_Name)
            sqlparams(6) = New SqlParameter("@QRRawMaterial_Quantity", QRRawMaterial_Quantity)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillNewFilter(ByVal Mode As String, ByVal Id As Integer, ByVal WhereClause As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Id", Id)
            sqlparams(2) = New SqlParameter("@WhereClause", WhereClause)
            Return DBBridge.ExecuteDataset("_spFillPagingById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	Public Shared Function DefaultBank(ByVal Acc_Id As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DefaultBank")
            sqlparams(1) = New SqlParameter("@Acc_Id", Acc_Id)
            Return DBBridge.ExecuteDataset("_spBank", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
	
	Public Shared Function GetOrderBankDetails(ByVal OrderId As Integer) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "GetOrderBankDetails")
            sqlparams(1) = New SqlParameter("@OrderId", OrderId)
            Return DBBridge.ExecuteDataset("_spBank", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

Public Shared Function GetTotalOrderAmount(ByVal PanCard As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@PANCARD", PanCard)
            Return DBBridge.ExecuteDataset("_SpGetTotalOrderAmount", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Bank Detail 
    Public Shared Function GetBankById(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("sp_GetBankDetailsById", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
