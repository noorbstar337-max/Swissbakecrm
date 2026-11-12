Imports Microsoft.VisualBasic
Imports APPCODE.DAL

Public Class LMSBLL
    Public Shared Function Dropdown(ByVal Mode As String) As DataSet        '---------Created By MUBYN used in LMS.aspx and LMSUser.aspx ModifyRecipe.aspx
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownWithUserId(ByVal Mode As String, ByVal U_ID As Integer, ByVal LevelId As Integer) As DataSet        '---------Created By MUBYN used in  ModifyRecipe.aspx
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", U_ID)
            sqlparams(2) = New SqlParameter("@LevelId", LevelId)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Costing(ByVal PORawMaterial_RawID As Integer) As Integer      '---------Created By MUBYN used in LMS.aspx 
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ProdCost")
            sqlparams(1) = New SqlParameter("@PORawMaterial_RawID", PORawMaterial_RawID)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FormulationNo() As String         '---------Created By MUBYN used in LMS.aspx and ModifyFormulation.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FormulationCode")
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FormulationNoForInsert(ByVal Formulation_Id As Integer) As String         '---------Created By MUBYN used in ModifyFormulation.aspx 
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FormulationNoForInsert")
            sqlparams(1) = New SqlParameter("@Formulation_Id", Formulation_Id)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in LMS.aspx 
    Public Shared Function InsertFormulation(ByVal Formulation_ProductID As Integer, ByVal Formulation_ProdName As String, ByVal Formulation_ProdCategory As String,
                                             ByVal Formulation_No As String, ByVal Formulation_Type As String, ByVal Formulation_Qty As Double,
                                             ByVal Formulation_Version As Double, ByVal Formulation_CreatedId As Integer, ByVal Formulation_IsChild As Integer,
                                             ByVal Formulation_Priority As String, ByVal Formulation_ExecutionDate As String, ByVal Formulation_CompleteStatus As Boolean,
                                             ByVal Formulation_LinkedProd As Integer) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFormulation")
            sqlparams(1) = New SqlParameter("@Formulation_ProductID", Formulation_ProductID)
            sqlparams(2) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)
            sqlparams(3) = New SqlParameter("@Formulation_ProdCategory", Formulation_ProdCategory)
            sqlparams(4) = New SqlParameter("@Formulation_No", Formulation_No)
            sqlparams(5) = New SqlParameter("@Formulation_Type", Formulation_Type)
            sqlparams(6) = New SqlParameter("@Formulation_Qty", Formulation_Qty)
            sqlparams(7) = New SqlParameter("@Formulation_Version", Formulation_Version)
            sqlparams(8) = New SqlParameter("@Formulation_CreatedId", Formulation_CreatedId)
            If Formulation_IsChild = 0 Then
                sqlparams(9) = New SqlParameter("@Formulation_IsChild", DBNull.Value)
            Else
                sqlparams(9) = New SqlParameter("@Formulation_IsChild", Formulation_IsChild)
            End If
            sqlparams(10) = New SqlParameter("@Formulation_Priority", Formulation_Priority)
            sqlparams(11) = New SqlParameter("@Formulation_ExecutionDate", Formulation_ExecutionDate)
            sqlparams(12) = New SqlParameter("@Formulation_CompleteStatus", Formulation_CompleteStatus)
            If Formulation_LinkedProd = -1 Then
                sqlparams(13) = New SqlParameter("@Formulation_LinkedProd", DBNull.Value)
            Else
                sqlparams(13) = New SqlParameter("@Formulation_LinkedProd", Formulation_LinkedProd)
            End If

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in LMS.aspx 
    Public Shared Function InsertFRawMaterial(ByVal FRawM_FormulationId As Integer, ByVal FRawM_RawMID As Integer, ByVal FRawM_Percentage As Double,
                                            ByVal FRawM_Cost As Double, ByVal FRawM_CreatedId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFRawMaterial")
            sqlparams(1) = New SqlParameter("@FRawM_FormulationId", FRawM_FormulationId)
            sqlparams(2) = New SqlParameter("@FRawM_RawMID", FRawM_RawMID)
            sqlparams(3) = New SqlParameter("@FRawM_Percentage", FRawM_Percentage)
            sqlparams(4) = New SqlParameter("@FRawM_Cost", FRawM_Cost)
            sqlparams(5) = New SqlParameter("@FRawM_CreatedId", FRawM_CreatedId)

            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecipeNo() As String         '---------Created By MUBYN used in LMS.aspx and ModifyRecipe.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "RecipeCode")
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function RecipeNoForInsert(ByVal Recipe_Id As Integer) As String         '---------Created By MUBYN used in ModifyRecipe.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "RecipeNoForInsert")
            sqlparams(1) = New SqlParameter("@Recipe_Id", Recipe_Id)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMS.aspx 
    Public Shared Function InsertRecipe(ByVal Recipe_No As String, ByVal Recipe_FormulationId As Integer,
                                             ByVal Recipe_Mixer As String, ByVal Recipe_Blade As String, ByVal Recipe_Mould As String,
                                             ByVal Recipe_Oven As String, ByVal Recipe_Remarks As String, ByVal Recipe_CreatedId As Integer) As Integer
        Dim sqlparams(10) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertRecipe")
            sqlparams(1) = New SqlParameter("@Recipe_No", Recipe_No)
            'sqlparams(2) = New SqlParameter("@Recipe_ProductId", Recipe_ProductId)
            sqlparams(2) = New SqlParameter("@Recipe_FormulationId", Recipe_FormulationId)
            sqlparams(3) = New SqlParameter("@Recipe_Mixer", Recipe_Mixer)
            sqlparams(4) = New SqlParameter("@Recipe_Blade", Recipe_Blade)
            sqlparams(5) = New SqlParameter("@Recipe_Mould", Recipe_Mould)
            sqlparams(6) = New SqlParameter("@Recipe_Oven", Recipe_Oven)
            sqlparams(7) = New SqlParameter("@Recipe_Remarks", Recipe_Remarks)
            sqlparams(8) = New SqlParameter("@Recipe_CreatedId", Recipe_CreatedId)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in LMS.aspx 
    Public Shared Function InsertRecipeIngredient(ByVal RecipeIngredient_RecipeId As Integer, ByVal RecipeIngredient_Name As String, ByVal RecipeIngredient_Value As String,
                                             ByVal RecipeIngredient_Percent As String, ByVal RecipeIngredient_Remarks As String, ByVal RecipeIngredient_CreatedId As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertRecipeIngredient")
            sqlparams(1) = New SqlParameter("@RecipeIngredient_RecipeId", RecipeIngredient_RecipeId)
            sqlparams(2) = New SqlParameter("@RecipeIngredient_Name", RecipeIngredient_Name)
            sqlparams(3) = New SqlParameter("@RecipeIngredient_Value", RecipeIngredient_Value)
            sqlparams(4) = New SqlParameter("@RecipeIngredient_Percent", RecipeIngredient_Percent)
            sqlparams(5) = New SqlParameter("@RecipeIngredient_Remarks", RecipeIngredient_Remarks)
            sqlparams(6) = New SqlParameter("@RecipeIngredient_CreatedId", RecipeIngredient_CreatedId)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in LMS.aspx 
    Public Shared Function InsertRecipeProcedure(ByVal RecipeProcedure_RecipeId As Integer, ByVal RecipeProcedure_Step As String, ByVal RecipeProcedure_Term As String,
                                           ByVal RecipeProcedure_Time As String, ByVal RecipeProcedure_Remarks As String, ByVal RecipeProcedure_CreatedId As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertRecipeProcedure")
            sqlparams(1) = New SqlParameter("@RecipeProcedure_RecipeId", RecipeProcedure_RecipeId)
            sqlparams(2) = New SqlParameter("@RecipeProcedure_Step", RecipeProcedure_Step)
            sqlparams(3) = New SqlParameter("@RecipeProcedure_Term", RecipeProcedure_Term)
            sqlparams(4) = New SqlParameter("@RecipeProcedure_Time", RecipeProcedure_Time)
            sqlparams(5) = New SqlParameter("@RecipeProcedure_Remarks", RecipeProcedure_Remarks)
            sqlparams(6) = New SqlParameter("@RecipeProcedure_CreatedId", RecipeProcedure_CreatedId)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function FillGridByID(ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function MixTypeById(ByVal ID As Integer) As String         '---------Created By MUBYN used in LMS.aspx 
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "MixTypeById")
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#Region "LMSUser"
    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function FillGridView(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function TotalRowInGridview(ByVal Mode As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function SortingGridView(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            'Polist.aspx sort
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function DeleteSI(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String, ByVal AudtTrail_LogId As Integer) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function UpdateStatus(ByVal ID As Integer, ByVal ModifiedID As Integer, ByVal Mode As String, ByVal AudtTrail_LogId As Integer) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", ID)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", ModifiedID)
            sqlparams(3) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function SearchGridView(ByVal SearchValue As String, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function CheckPageName(ByVal _Value As String, ByVal Mode As String) As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", _Value)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in LMSUser.aspx 
    Public Shared Function QuickInsert(ByVal U_FirstName As String, ByVal U_Password As String, ByVal U_Email As String, ByVal U_LevelId As Integer, ByVal U_Mobile As String, ByVal U_CreatedID As Integer, ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertLMSUser")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_Password", U_Password)
            sqlparams(3) = New SqlParameter("@U_Email", U_Email)
            sqlparams(4) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(5) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(6) = New SqlParameter("@Audlog_Id", Audlog_Id)
            sqlparams(7) = New SqlParameter("@U_LevelId", U_LevelId)
            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in ModifyLMSUser.aspx 
    Public Shared Function InsertLMSUser(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Password As String, ByVal U_Email As String, ByVal U_Mobile As String, ByVal U_LevelId As Integer,
                                 ByVal U_DeptId As Integer, ByVal U_ReportingTo As Integer, ByVal U_DesignationId As Integer, ByVal U_CreatedID As Integer, ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertLMSUser")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            sqlparams(3) = New SqlParameter("@U_Password", U_Password)
            sqlparams(4) = New SqlParameter("@U_Email", U_Email)
            sqlparams(5) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(6) = New SqlParameter("@U_ReportingTo", U_ReportingTo)
            sqlparams(6) = New SqlParameter("@U_DeptId", U_DeptId)
            'sqlparams(7) = New SqlParameter("@U_EmployeeId", U_EmployeeId)
            sqlparams(8) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(9) = New SqlParameter("@U_DesignationId", U_DesignationId)
            'sqlparams(10) = New SqlParameter("@U_TypeId", U_TypeId)
            sqlparams(11) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(12) = New SqlParameter("@Audlog_Id", Audlog_Id)
            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in ModifyLMSUser.aspx 
    Public Shared Function UpdateLMSUser(ByVal U_FirstName As String, ByVal U_LastName As String, ByVal U_Email As String, ByVal U_Mobile As String, ByVal U_LevelId As Integer, ByVal U_DeptId As Integer,
                                         ByVal U_ReportingTo As Integer, ByVal U_DesignationId As Integer, ByVal U_CreatedID As Integer, ByVal ID As Integer, ByVal Audlog_Id As Integer) As Integer
        Dim sqlparams(27) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateLMSUser")
            sqlparams(1) = New SqlParameter("@U_FirstName", U_FirstName)
            sqlparams(2) = New SqlParameter("@U_LastName", U_LastName)
            'sqlparams(3) = New SqlParameter("@U_Password", U_Password)
            sqlparams(4) = New SqlParameter("@U_Email", U_Email)
            sqlparams(5) = New SqlParameter("@U_Mobile", U_Mobile)
            sqlparams(6) = New SqlParameter("@U_ReportingTo", U_ReportingTo)
            sqlparams(7) = New SqlParameter("@U_DeptId", U_DeptId)
            'sqlparams(7) = New SqlParameter("@U_EmployeeId", U_EmployeeId)
            sqlparams(8) = New SqlParameter("@U_LevelId", U_LevelId)
            sqlparams(9) = New SqlParameter("@U_DesignationId", U_DesignationId)
            'sqlparams(10) = New SqlParameter("@U_TypeId", U_TypeId)
            sqlparams(11) = New SqlParameter("@U_CreatedID", U_CreatedID)
            sqlparams(12) = New SqlParameter("@U_ID", ID)
            sqlparams(13) = New SqlParameter("@Audlog_Id", Audlog_Id)
            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function NoOfUser() As String
        'Public Shared Function NoOfLMSUser() As String
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "NoOfLMSUser")
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in ModifyLMSUser.aspx 
    Public Shared Function ChangeLMSPass(ByVal _Password As String, ByVal ID As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ChangeLMSPass")
            sqlparams(1) = New SqlParameter("@U_Password", _Password)
            sqlparams(2) = New SqlParameter("@U_ID", ID)
            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Formulation and Recipe"
    '---------Created By MUBYN used in Formulation.aspx and Recipe.aspx
    Public Shared Function FillRepeater(ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            'sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            'sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    '---------Created By MUBYN used in Formulation.aspx 
    Public Shared Function DeleteFormulation(ByVal Formulation_Id As Integer, ByVal Formulation_ModifiedId As Integer, ByVal Mode As String) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Formulation_Id", Formulation_Id)
            sqlparams(2) = New SqlParameter("@Formulation_ModifiedId", Formulation_ModifiedId)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in Recipe.aspx
    Public Shared Function DeleteRecipe(ByVal Recipe_Id As Integer, ByVal Recipe_ModifiedId As Integer, ByVal Mode As String) As String
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Recipe_Id", Recipe_Id)
            sqlparams(2) = New SqlParameter("@Recipe_ModifiedId", Recipe_ModifiedId)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownById(ByVal Mode As String, ByVal ID As Integer) As DataSet        '---------Created By MUBYN used in ModifyRecipe.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownByIdNType(ByVal Mode As String, ByVal ID As Integer, ByVal Type As String, ByVal productname As String) As DataSet        '---------Created By MUBYN used in ModifyTrials.aspx 28-09-2018
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            If Type = 0 Then
                sqlparams(2) = New SqlParameter("@Formulation_Type", "Existing")
                ' sqlparams(3) = New SqlParameter("@Formulation_Type", "Existing")
            Else
                sqlparams(2) = New SqlParameter("@Formulation_Type", "different")
                sqlparams(3) = New SqlParameter("@Formulation_ProdName", productname)
            End If
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

    '#Region "Recipe"
    '    '---------Created By MUBYN used in Recipe.aspx 
    '    Public Shared Function FillRecipe(ByVal Mode As String) As DataSet
    '        Dim sqlparams(2) As SqlParameter
    '        Try
    '            sqlparams(0) = New SqlParameter("@Mode", Mode)
    '            'sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
    '            'sqlparams(2) = New SqlParameter("@PageSize", PageSize)
    '            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
    '        Catch ex As Exception
    '            Throw ex
    '            'polist.aspx search
    '        End Try
    '    End Function
    '#End Region


    Public Shared Function Fillgridwitid(ByVal Mode As String, ByVal id As Integer, ByVal Type As String) As DataSet
        '---------Created By Altaf used in Recipe.aspx 
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@Assignto_Type", Type)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    '---------Created By Altaf used in ModifyFormulation.aspx 
    Public Shared Function UpdateFormulationApprove(ByVal Mode As String, ByVal id As Integer, ByVal Modifiedid As Integer, ByVal product As String, ByVal type As Integer) As DataSet
        Dim sqlparams(5) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", Modifiedid)
            sqlparams(3) = New SqlParameter("@Formulation_Product", product)
            sqlparams(4) = New SqlParameter("@type", type)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'Modifyformulation.aspx add by altaf 14-may-18
        End Try
    End Function

    'Public Sub CheckPrivilege(Repeater1 As Repeater, ByVal Session As Integer, ByVal PageName As String)
    '    Try
    '        Dim dt As DataSet = LMSPrivilegeBLL.CheckLMSPrivilege(Session, PageName)
    '        Dim dtprivilage As New DataTable
    '        dtprivilage = dt.Tables(0)
    '        Dim drprivilage As DataRow
    '        If dtprivilage.Rows.Count = 0 Then
    '            For Each Item In Repeater1.Items
    '                Dim tdview As HtmlTableCell = DirectCast(Item.FindControl("tdview"), HtmlTableCell)
    '                tdview.Visible = False
    '                Dim tdedit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
    '                tdedit.Visible = False
    '                Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
    '                tddelete.Visible = False
    '            Next
    '            thview.Visible = False
    '            thEdit.Visible = False
    '            thDelete.Visible = False
    '            Repeater1.Items(0).Visible = False
    '            Repeater1.Items(1).Visible = False
    '            Repeater1.Items(2).Visible = False
    '        Else
    '            drprivilage = dtprivilage.Rows(0)
    '            If (drprivilage("Prvg_RAdd").ToString()) = True Then

    '            Else

    '            End If
    '            If (drprivilage("Prvg_RUpdate").ToString()) = True Then

    '            Else
    '                For Each Item In Repeater1.Items
    '                    Dim tdedit As HtmlTableCell = DirectCast(Item.FindControl("tdedit"), HtmlTableCell)
    '                    tdedit.Visible = False
    '                Next
    '                thEdit.Visible = False
    '            End If
    '            If (drprivilage("Prvg_RDelete").ToString()) = True Then

    '            Else
    '                For Each Item In Repeater1.Items
    '                    Dim tddelete As HtmlTableCell = DirectCast(Item.FindControl("tddelete"), HtmlTableCell)
    '                    tddelete.Visible = False
    '                Next
    '                thDelete.Visible = False
    '            End If
    '            If (drprivilage("Prvg_Rview").ToString()) = True Then

    '            Else
    '                For Each Item In Repeater1.Items
    '                    Dim tdview As HtmlTableCell = DirectCast(Item.FindControl("tdview"), HtmlTableCell)
    '                    tdview.Visible = False
    '                Next
    '                thview.Visible = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Public Shared Sub CheckLMSPrivilegeForModify(ByVal ID As Integer, _Page As String)
        Try
            Dim dt As DataSet = LMSPrivilegeBLL.CheckLMSPrivilege(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                'save.Visible = False
                'upsave.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Or (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    'save.Visible = True
                    'upsave.Visible = True
                Else
                    'save.Visible = False
                    'upsave.Visible = False
                    Throw New Exception("You don't have permission \n please contact admin")
                End If
                'If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                '    'save.Visible = True
                '    'upsave.Visible = True
                'Else
                '    'save.Visible = False
                '    'upsave.Visible = False
                '    Throw New Exception("You don't have permission \n please contact admin")
                'End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Shared Function TrailNo() As String         '---------Created By MUBYN used in LMS.aspx and ModifyTrial.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TrialCode")
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function TrialNoForInsert(ByVal Trial_Id As Integer) As String         '---------Created By MUBYN used in ModifyTrial.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TrialNoForInsert")
            sqlparams(1) = New SqlParameter("@Trial_Id", Trial_Id)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function Inserttrial(ByVal Trial_No As String, ByVal userid As Integer, ByVal Trial_Remarks As String, ByVal Trial_Type As String) As Integer
        'Public Shared Function Inserttrial(ByVal Trial_No As String, ByVal Trial_RecipeId As Integer, ByVal Trial_Type As String,
        '                                   ByVal userid As Integer, ByVal Trial_Remarks As String) As Integer
        '====== Created by Altaf Modified by MUBYN used in ModifiedTrial.aspx
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertTrial")
            sqlparams(1) = New SqlParameter("@Trial_No", Trial_No)
            'sqlparams(2) = New SqlParameter("@Trial_RecipeId", Trial_RecipeId)
            'sqlparams(3) = New SqlParameter("@Trial_Type", Trial_Type)
            sqlparams(4) = New SqlParameter("@userid", userid)
            sqlparams(5) = New SqlParameter("@Trial_Remarks", Trial_Remarks)
            sqlparams(6) = New SqlParameter("@Trial_Type", Trial_Type)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '====== Created by Altaf Modified by MUBYN used in ModifiedTrial.aspx
    Public Shared Function InserttrialEval(ByVal TrialEval_VolumeVal As String, ByVal TrialEval_VolumeCom As String, ByVal TrialEval_WeightVal As String,
                                        ByVal TrialEval_WeightCom As String, ByVal TrialEval_DimensionVal As String,
       ByVal TrialEval_DimensionCom As String, ByVal TrialEval_CrumbTextureVal As String, ByVal TrialEval_CrumbTextureCom As String,
       ByVal TrialEval_CrumbColorVal As String, ByVal TrialEval_CrumbColorCom As String, ByVal TrialEval_CrustTextureVal As String, ByVal TrialEval_CrustTextureCom As String,
       ByVal TrialEval_CrustColorVal As String, ByVal TrialEval_CrustColorCom As String, ByVal TrialEval_Taste As String, ByVal TR_Id As Integer,
       ByVal userid As Integer, ByVal TrialEval_CenterHeightVal As String, ByVal TrialEval_CenterHeightCom As String, ByVal TrialEval_LeftHeightVal As String, ByVal TrialEval_LeftHeightCom As String, ByVal TrialEval_RightHeightVal As String,
       ByVal TrialEval_RightHeightCom As String, ByVal TrialEval_SweetnessVal As String, ByVal TrialEval_SweetnessCom As String, ByVal TrialEval_FlavourVal As String, ByVal TrialEval_FlavourCom As String,
       ByVal TrialEval_BatterGravityVal As String, ByVal TrialEval_BatterGravityCom As String) As Integer
        Dim sqlparams(30) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InserttrialEvaluation")
            sqlparams(1) = New SqlParameter("@TrialEval_VolumeVal", TrialEval_VolumeVal)
            sqlparams(2) = New SqlParameter("@TrialEval_VolumeCom", TrialEval_VolumeCom)
            sqlparams(3) = New SqlParameter("@TrialEval_WeightVal", TrialEval_WeightVal)
            sqlparams(4) = New SqlParameter("@TrialEval_WeightCom", TrialEval_WeightCom)
            sqlparams(5) = New SqlParameter("@TrialEval_DimensionVal", TrialEval_DimensionVal)
            sqlparams(6) = New SqlParameter("@TrialEval_DimensionCom", TrialEval_DimensionCom)
            sqlparams(7) = New SqlParameter("@TrialEval_CrumbTextureVal", TrialEval_CrumbTextureVal)
            sqlparams(8) = New SqlParameter("@TrialEval_CrumbTextureCom", TrialEval_CrumbTextureCom)

            sqlparams(9) = New SqlParameter("@TrialEval_CrumbColorVal", TrialEval_CrumbColorVal)
            sqlparams(10) = New SqlParameter("@TrialEval_CrumbColorCom", TrialEval_CrumbColorCom)
            sqlparams(11) = New SqlParameter("@TrialEval_CrustTextureVal", TrialEval_CrustTextureVal)
            sqlparams(12) = New SqlParameter("@TrialEval_CrustTextureCom", TrialEval_CrustTextureCom)
            sqlparams(13) = New SqlParameter("@TrialEval_CrustColorVal", TrialEval_CrustColorVal)
            sqlparams(14) = New SqlParameter("@TrialEval_CrustColorCom", TrialEval_CrustColorCom)
            sqlparams(15) = New SqlParameter("@TrialEval_Taste", TrialEval_Taste)
            sqlparams(16) = New SqlParameter("@TR_Id", TR_Id)
            sqlparams(17) = New SqlParameter("@TrialEval_CenterHeightVal", TrialEval_CenterHeightVal)
            sqlparams(18) = New SqlParameter("@TrialEval_CenterHeightCom", TrialEval_CenterHeightCom)
            sqlparams(19) = New SqlParameter("@TrialEval_LeftHeightVal", TrialEval_LeftHeightVal)
            sqlparams(20) = New SqlParameter("@TrialEval_LeftHeightCom", TrialEval_LeftHeightCom)
            sqlparams(21) = New SqlParameter("@TrialEval_RightHeightVal", TrialEval_RightHeightVal)
            sqlparams(22) = New SqlParameter("@TrialEval_RightHeightCom", TrialEval_RightHeightCom)
            sqlparams(23) = New SqlParameter("@TrialEval_SweetnessVal", TrialEval_SweetnessVal)
            sqlparams(24) = New SqlParameter("@TrialEval_SweetnessCom", TrialEval_SweetnessCom)
            sqlparams(25) = New SqlParameter("@TrialEval_FlavourVal", TrialEval_FlavourVal)
            sqlparams(26) = New SqlParameter("@TrialEval_FlavourCom", TrialEval_FlavourCom)
            sqlparams(27) = New SqlParameter("@TrialEval_BatterGravityVal", TrialEval_BatterGravityVal)
            sqlparams(28) = New SqlParameter("@TrialEval_BatterGravityCom", TrialEval_BatterGravityCom)
            sqlparams(29) = New SqlParameter("@userid", userid)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '====== Created by Altaf Modified by MUBYN used in ModifiedTrial.aspx
    Public Shared Function InserttrialMethod(ByVal TrialMethod_DoughTemperature As String, ByVal TrialMethod_OnBenchTime As String, ByVal TrialMethod_ScaleTime As String,
                                        ByVal TrialMethod_ScaleWeight As String, ByVal TrialMethod_InProoferTime As String, ByVal TrialMethod_InOvenTime As String,
                                        ByVal TrialMethod_OutOvenTime As String, ByVal TrialMethod_Steam As String, ByVal TrialMethod_Remarks As String, ByVal userid As Integer,
                                        ByVal TR_Id As Integer) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertTrialMethod")
            sqlparams(1) = New SqlParameter("@TrialMethod_DoughTemperature", TrialMethod_DoughTemperature)
            sqlparams(2) = New SqlParameter("@TrialMethod_OnBenchTime", TrialMethod_OnBenchTime)
            sqlparams(3) = New SqlParameter("@TrialMethod_ScaleTime", TrialMethod_ScaleTime)
            sqlparams(4) = New SqlParameter("@TrialMethod_ScaleWeight", TrialMethod_ScaleWeight)
            sqlparams(5) = New SqlParameter("@TrialMethod_InProoferTime", TrialMethod_InProoferTime)
            sqlparams(6) = New SqlParameter("@TrialMethod_InOvenTime", TrialMethod_InOvenTime)
            sqlparams(7) = New SqlParameter("@TrialMethod_OutOvenTime", TrialMethod_OutOvenTime)
            sqlparams(8) = New SqlParameter("@TrialMethod_Steam", TrialMethod_Steam)
            ' sqlparams(9) = New SqlParameter("@TrialMethod_OutOvenTime", TrialMethod_OutOvenTime)
            sqlparams(10) = New SqlParameter("@TrialMethod_Remarks", TrialMethod_Remarks)
            sqlparams(11) = New SqlParameter("@userid", userid)
            sqlparams(12) = New SqlParameter("@TR_Id", TR_Id)

            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdateApprove(ByVal Mode As String, ByVal id As Integer, ByVal Modifiedid As Integer, ByVal Formulation_StatusRemark As String) As DataSet   '---------Created By MUBYN used in ModifyRecipe.aspx, ModifyTrial.aspx
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@U_ModifiedID", Modifiedid)
            sqlparams(3) = New SqlParameter("@Formulation_StatusRemark", Formulation_StatusRemark)

            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'Modifyformulation.aspx add by altaf 14-may-18
        End Try
    End Function

#Region "LMSLogin"
    Public Shared Function ValidateLogin(ByVal _Username As String, ByVal _Password As String) As DataSet   '------Added by MUBYN used in LMSLogin.aspx
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateLMSLogin")
            sqlparams(1) = New SqlParameter("@U_UserName", _Username)
            sqlparams(2) = New SqlParameter("@U_Password", _Password)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ValidateOldPass(ByVal U_Id As String, ByVal U_Password As String) As DataSet       '------Added by MUBYN used in LMSChangePassword.aspx 17-05-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ValidateOldPass")
            sqlparams(1) = New SqlParameter("@U_Id", U_Id)
            sqlparams(2) = New SqlParameter("@U_Password", U_Password)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Changepass(ByVal _Password As String, ByVal ID As Integer) As Integer       '------Added by MUBYN used in LMSChangePassword.aspx 17-05-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "Changepass")
            sqlparams(1) = New SqlParameter("@U_Password", _Password)
            sqlparams(2) = New SqlParameter("@U_ID", ID)
            Return DBBridge.ExecuteNonQuery("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
    Public Shared Function Updatetrial(ByVal Id As Integer, ByVal userid As Integer, ByVal Trial_Remarks As String) As Integer
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateTrial")
            sqlparams(1) = New SqlParameter("@id", Id)
            sqlparams(2) = New SqlParameter("@userid", userid)
            sqlparams(3) = New SqlParameter("@Trial_Remarks", Trial_Remarks)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdatetrialEval(ByVal TrialEval_VolumeVal As String, ByVal TrialEval_VolumeCom As String, ByVal TrialEval_WeightVal As String,
                                        ByVal TrialEval_WeightCom As String, ByVal TrialEval_DimensionVal As String,
       ByVal TrialEval_DimensionCom As String, ByVal TrialEval_CrumbTextureVal As String, ByVal TrialEval_CrumbTextureCom As String,
       ByVal TrialEval_CrumbColorVal As String, ByVal TrialEval_CrumbColorCom As String, ByVal TrialEval_CrustTextureVal As String, ByVal TrialEval_CrustTextureCom As String,
       ByVal TrialEval_CrustColorVal As String, ByVal TrialEval_CrustColorCom As String, ByVal TrialEval_Taste As String, ByVal TrialEval_TRId As Integer,
       ByVal userid As Integer, ByVal TrialEval_CenterHeightVal As String, ByVal TrialEval_CenterHeightCom As String, ByVal TrialEval_LeftHeightVal As String, ByVal TrialEval_LeftHeightCom As String, ByVal TrialEval_RightHeightVal As String,
       ByVal TrialEval_RightHeightCom As String, ByVal TrialEval_SweetnessVal As String, ByVal TrialEval_SweetnessCom As String, ByVal TrialEval_FlavourVal As String, ByVal TrialEval_FlavourCom As String,
       ByVal TrialEval_BatterGravityVal As String, ByVal TrialEval_BatterGravityCom As String) As Integer
        Dim sqlparams(30) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdatetrialEvaluation")
            sqlparams(1) = New SqlParameter("@TrialEval_VolumeVal", TrialEval_VolumeVal)
            sqlparams(2) = New SqlParameter("@TrialEval_VolumeCom", TrialEval_VolumeCom)
            sqlparams(3) = New SqlParameter("@TrialEval_WeightVal", TrialEval_WeightVal)
            sqlparams(4) = New SqlParameter("@TrialEval_WeightCom", TrialEval_WeightCom)
            sqlparams(5) = New SqlParameter("@TrialEval_DimensionVal", TrialEval_DimensionVal)
            sqlparams(6) = New SqlParameter("@TrialEval_DimensionCom", TrialEval_DimensionCom)
            sqlparams(7) = New SqlParameter("@TrialEval_CrumbTextureVal", TrialEval_CrumbTextureVal)
            sqlparams(8) = New SqlParameter("@TrialEval_CrumbTextureCom", TrialEval_CrumbTextureCom)

            sqlparams(9) = New SqlParameter("@TrialEval_CrumbColorVal", TrialEval_CrumbColorVal)
            sqlparams(10) = New SqlParameter("@TrialEval_CrumbColorCom", TrialEval_CrumbColorCom)
            sqlparams(11) = New SqlParameter("@TrialEval_CrustTextureVal", TrialEval_CrustTextureVal)
            sqlparams(12) = New SqlParameter("@TrialEval_CrustTextureCom", TrialEval_CrustTextureCom)
            sqlparams(13) = New SqlParameter("@TrialEval_CrustColorVal", TrialEval_CrustColorVal)
            sqlparams(14) = New SqlParameter("@TrialEval_CrustColorCom", TrialEval_CrustColorCom)
            sqlparams(15) = New SqlParameter("@TrialEval_Taste", TrialEval_Taste)
            sqlparams(16) = New SqlParameter("@id", TrialEval_TRId)
            sqlparams(17) = New SqlParameter("@TrialEval_CenterHeightVal", TrialEval_CenterHeightVal)
            sqlparams(18) = New SqlParameter("@TrialEval_CenterHeightCom", TrialEval_CenterHeightCom)
            sqlparams(19) = New SqlParameter("@TrialEval_LeftHeightVal", TrialEval_LeftHeightVal)
            sqlparams(20) = New SqlParameter("@TrialEval_LeftHeightCom", TrialEval_LeftHeightCom)
            sqlparams(21) = New SqlParameter("@TrialEval_RightHeightVal", TrialEval_RightHeightVal)
            sqlparams(22) = New SqlParameter("@TrialEval_RightHeightCom", TrialEval_RightHeightCom)
            sqlparams(23) = New SqlParameter("@TrialEval_SweetnessVal", TrialEval_SweetnessVal)
            sqlparams(24) = New SqlParameter("@TrialEval_SweetnessCom", TrialEval_SweetnessCom)
            sqlparams(25) = New SqlParameter("@TrialEval_FlavourVal", TrialEval_FlavourVal)
            sqlparams(26) = New SqlParameter("@TrialEval_FlavourCom", TrialEval_FlavourCom)
            sqlparams(27) = New SqlParameter("@TrialEval_BatterGravityVal", TrialEval_BatterGravityVal)
            sqlparams(28) = New SqlParameter("@TrialEval_BatterGravityCom", TrialEval_BatterGravityCom)
            sqlparams(29) = New SqlParameter("@userid", userid)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UpdatetrialMethod(ByVal TrialMethod_DoughTemperature As String, ByVal TrialMethod_OnBenchTime As String, ByVal TrialMethod_ScaleTime As String,
                                        ByVal TrialMethod_ScaleWeight As String, ByVal TrialMethod_InProoferTime As String, ByVal TrialMethod_InOvenTime As String,
                                        ByVal TrialMethod_OutOvenTime As String, ByVal TrialMethod_Steam As String, ByVal TrialMethod_Remarks As String, ByVal userid As Integer,
                                        ByVal TrialMethod_TRId As Integer) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateTrialMethod")
            sqlparams(1) = New SqlParameter("@TrialMethod_DoughTemperature", TrialMethod_DoughTemperature)
            sqlparams(2) = New SqlParameter("@TrialMethod_OnBenchTime", TrialMethod_OnBenchTime)
            sqlparams(3) = New SqlParameter("@TrialMethod_ScaleTime", TrialMethod_ScaleTime)
            sqlparams(4) = New SqlParameter("@TrialMethod_ScaleWeight", TrialMethod_ScaleWeight)
            sqlparams(5) = New SqlParameter("@TrialMethod_InProoferTime", TrialMethod_InProoferTime)
            sqlparams(6) = New SqlParameter("@TrialMethod_InOvenTime", TrialMethod_InOvenTime)
            sqlparams(7) = New SqlParameter("@TrialMethod_OutOvenTime", TrialMethod_OutOvenTime)
            sqlparams(8) = New SqlParameter("@TrialMethod_Steam", TrialMethod_Steam)
            ' sqlparams(9) = New SqlParameter("@TrialMethod_OutOvenTime", TrialMethod_OutOvenTime)
            sqlparams(10) = New SqlParameter("@TrialMethod_Remarks", TrialMethod_Remarks)
            sqlparams(11) = New SqlParameter("@userid", userid)
            sqlparams(12) = New SqlParameter("@id", TrialMethod_TRId)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in ModifyRecipe.aspx 19-05-18
    Public Shared Function UpdateRecipe(ByVal id As Integer, Recipe_Mixer As String, ByVal Recipe_Blade As String, ByVal Recipe_Mould As String,
                                             ByVal Recipe_Oven As String, ByVal Recipe_Remarks As String, ByVal Recipe_CreatedId As Integer) As Integer
        Dim sqlparams(7) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateRecipe")
            sqlparams(1) = New SqlParameter("@Recipe_Mixer", Recipe_Mixer)
            sqlparams(2) = New SqlParameter("@Recipe_Blade", Recipe_Blade)
            sqlparams(3) = New SqlParameter("@Recipe_Mould", Recipe_Mould)
            sqlparams(4) = New SqlParameter("@Recipe_Oven", Recipe_Oven)
            sqlparams(5) = New SqlParameter("@Recipe_Remarks", Recipe_Remarks)
            sqlparams(6) = New SqlParameter("@Recipe_CreatedId", Recipe_CreatedId)
            sqlparams(7) = New SqlParameter("@id", id)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in ModifyRecipe.aspx 21-05-18
    Public Shared Function DeleteRecipeChild(ByVal id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteRecipeChild")
            sqlparams(1) = New SqlParameter("@id", id)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in ModifyTrials.aspx 27-09-18
    Public Shared Function DeleteFormChild(ByVal id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteFormChild")
            sqlparams(1) = New SqlParameter("@id", id)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillDropdownById(ByVal Mode As String, ByVal U_ID As Integer, ByVal LevelId As Integer, ByVal ProductName As String) As DataSet        '---------Created By MUBYN used in  ModifyRecipe.aspx
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", U_ID)
            sqlparams(2) = New SqlParameter("@LevelId", LevelId)
            sqlparams(3) = New SqlParameter("@ProductName", ProductName)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function DropdownByName(ByVal Mode As String, ByVal Name As String) As DataSet        '---------Created By MUBYN used in ModifyRecipe.aspx 23-05-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Formulation_ProdName", Name)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function DropdownByIDName(ByVal Mode As String, ByVal U_ID As Integer, ByVal Name As String) As DataSet        '---------Created By MUBYN used in ModifyRecipe.aspx 23-05-2018
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", U_ID)
            sqlparams(2) = New SqlParameter("@Formulation_ProdName", Name)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckProdExist(ByVal Name As String) As String        '---------Created By MUBYN used in ModifyFormulation.aspx 23-05-2018
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CheckProdExist")
            sqlparams(1) = New SqlParameter("@Formulation_ProdName", Name)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in ModifyFormulation.aspx 24-05-2018
    Public Shared Function InsertTrialRecipe(ByVal TR_TrialId As Integer, ByVal TR_RecipeId As Integer) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertTrialRecipe")
            sqlparams(2) = New SqlParameter("@TR_TrialId", TR_TrialId)
            sqlparams(3) = New SqlParameter("@TR_RecipeId", TR_RecipeId)
            'sqlparams(4) = New SqlParameter("@TR_Type", TR_Type)
            ' sqlparams(5) = New SqlParameter("@TR_TypeId", TR_TypeId)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in ModifyTrial.aspx 25-05-18
    Public Shared Function DeleteTrialChild(ByVal id As Integer) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "DeleteTrialChild")
            sqlparams(1) = New SqlParameter("@id", id)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillRecipeForPop(ByVal Mode As String, ByVal MixType As String, ByVal id As Integer) As DataSet        '---------Created By MUBYN used in ModifyTrial.aspx 25-05-2018
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Product_MixType", MixType)
            sqlparams(2) = New SqlParameter("@id", id)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By Faisal used in Modifytrial.aspx 28-05-2018
    Public Shared Function InsertTrialImage(ByVal TRImage_TRID As Integer, ByVal TRImagePath As String) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertTrialimage")
            sqlparams(2) = New SqlParameter("@TRImage_TRID", TRImage_TRID)
            sqlparams(3) = New SqlParameter("@TRImagePath", TRImagePath)

            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '---------Created By MUBYN used in ModifyTrial.aspx
    Public Shared Function SearchRecipeForPop(ByVal Mode As String, ByVal MixType As String, ByVal SearchValue As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Product_MixType", MixType)
            sqlparams(2) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Not in use
    Public Shared Function LMSAssignTable(ByVal MixType As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "LMSAssignTable")

            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By Altaf used in ProductWiseFormulation.aspx 
    ''Modified by MUBYN
    Public Shared Function formulationProdreport(ByVal Mode As String, ByVal id As Integer, ByVal Type As String, ByVal Formulation_ProdName As String,
                                                 ByVal Formulation_ProductID As Integer, ByVal Formulation_Type As String, ByVal Formulation_ProdCategory As String,
                                                 ByVal FromDate As String, ByVal ToDate As String) As DataSet
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@Assignto_Type", Type)
            If Formulation_ProductID = "-1" Then
                sqlparams(3) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(4) = New SqlParameter("@Formulation_ProdName", DBNull.Value)
            ElseIf Formulation_ProductID = "0" Then
                sqlparams(3) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(4) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)
            ElseIf Formulation_ProductID > "0" Then
                sqlparams(3) = New SqlParameter("@Formulation_ProductID", Formulation_ProductID)
                sqlparams(4) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)

            End If
            If Formulation_Type = "All" Then
                sqlparams(5) = New SqlParameter("@Formulation_Type", DBNull.Value)
            ElseIf Formulation_Type = "Exist" Then
                sqlparams(5) = New SqlParameter("@Formulation_Type", "Existing")
            ElseIf Formulation_Type = "New" Then
                sqlparams(5) = New SqlParameter("@Formulation_Type", "New")
            ElseIf Formulation_Type = "Competitor" Then
                sqlparams(5) = New SqlParameter("@Formulation_Type", "Competitor")
            End If
            If Formulation_ProdCategory = "All" Then
                sqlparams(7) = New SqlParameter("@Formulation_ProdCategory", DBNull.Value)
            Else
                sqlparams(7) = New SqlParameter("@Formulation_ProdCategory", Formulation_ProdCategory)
            End If
            sqlparams(8) = New SqlParameter("@FromDate", FromDate)
            sqlparams(9) = New SqlParameter("@ToDate", ToDate)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    '---------Created By Altaf used in ProductWiseFormulation.aspx 
    ''=========Modified by MUBYN
    Public Shared Function ddProduct(ByVal Mode As String, ByVal U_ID As Integer, ByVal LevelId As Integer,
                                     ByVal Formulation_Type As String, ByVal Formulation_ProdCategory As String) As DataSet
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@U_ID", U_ID)
            sqlparams(2) = New SqlParameter("@LevelId", LevelId)
            If Formulation_Type = "All" Then
                sqlparams(3) = New SqlParameter("@Formulation_Type", DBNull.Value)
                'sqlparams(4) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
            ElseIf Formulation_Type = "Exist" Then
                sqlparams(3) = New SqlParameter("@Formulation_Type", "Existing")
                'sqlparams(4) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
            ElseIf Formulation_Type = "New" Then
                sqlparams(3) = New SqlParameter("@Formulation_Type", "New")
                'sqlparams(4) = New SqlParameter("@Formulation_ProductID", "0")
            ElseIf Formulation_Type = "Competitor" Then
                sqlparams(3) = New SqlParameter("@Formulation_Type", "Competitor")
                'sqlparams(4) = New SqlParameter("@Formulation_ProductID", "0")
            End If
            If Formulation_ProdCategory = "All" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProdCategory", DBNull.Value)
            Else
                sqlparams(5) = New SqlParameter("@Formulation_ProdCategory", Formulation_ProdCategory)
            End If
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function UserDropdown(ByVal Mode As String) As DataSet    '=========Added by MUBYN used in ProductWiseFormulation.aspx 21-06-2018
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)

            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '---------Created By MUBYN used in RecipeReport.aspx 
    Public Shared Function RecipeReport(ByVal Mode As String, ByVal id As Integer, ByVal Type As String, ByVal Formulation_ProdCategory As String,
                                         ByVal Formulation_Type As String, ByVal Formulation_ProdName As String, ByVal Formulation_ProductID As Integer,
                                         ByVal FromDate As String, ByVal ToDate As String) As DataSet
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@Assignto_Type", Type)
            If Formulation_ProdCategory = "All" Then
                sqlparams(3) = New SqlParameter("@Formulation_ProdCategory", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Formulation_ProdCategory", Formulation_ProdCategory)
            End If
            If Formulation_Type = "All" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", DBNull.Value)
            ElseIf Formulation_Type = "Exist" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "Existing")
            ElseIf Formulation_Type = "New" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "New")
            ElseIf Formulation_Type = "Competitor" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "Competitor")
            End If
            If Formulation_ProductID = "-1" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", DBNull.Value)
            ElseIf Formulation_ProductID = "0" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)
            ElseIf Formulation_ProductID > "0" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", Formulation_ProductID)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)

            End If
            sqlparams(8) = New SqlParameter("@FromDate", FromDate)
            sqlparams(9) = New SqlParameter("@ToDate", ToDate)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    '---------Created By MUBYN used in TrialReport.aspx 21-06-2018
    Public Shared Function TrialReport(ByVal Mode As String, ByVal id As Integer, ByVal Type As String, ByVal Formulation_ProdCategory As String, ByVal Formulation_Type As String,
                                        ByVal Formulation_ProdName As String, ByVal Formulation_ProductID As Integer,
                                        ByVal FromDate As String, ByVal ToDate As String) As DataSet
        Dim sqlparams(11) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@id", id)
            sqlparams(2) = New SqlParameter("@Assignto_Type", Type)
            If Formulation_ProdCategory = "All" Then
                sqlparams(3) = New SqlParameter("@Formulation_ProdCategory", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Formulation_ProdCategory", Formulation_ProdCategory)
            End If
            If Formulation_Type = "All" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", DBNull.Value)
            ElseIf Formulation_Type = "Exist" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "Existing")
            ElseIf Formulation_Type = "New" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "New")
            ElseIf Formulation_Type = "Competitor" Then
                sqlparams(4) = New SqlParameter("@Formulation_Type", "Competitor")
            End If
            If Formulation_ProductID = "-1" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", DBNull.Value)
            ElseIf Formulation_ProductID = "0" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", DBNull.Value)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)
            ElseIf Formulation_ProductID > "0" Then
                sqlparams(5) = New SqlParameter("@Formulation_ProductID", Formulation_ProductID)
                sqlparams(6) = New SqlParameter("@Formulation_ProdName", Formulation_ProdName)
            End If
            sqlparams(8) = New SqlParameter("@FromDate", FromDate)
            sqlparams(9) = New SqlParameter("@ToDate", ToDate)
            Return DBBridge.ExecuteDataset("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
            'polist.aspx search
        End Try
    End Function

    Public Shared Function CheckExist(ByVal Mode As String, ByVal Value As String) As String          '---------Created By MUBYN 
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Value", Value)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function IdById(ByVal Mode As String, ByVal ID As Integer) As Integer        '---------Created By MUBYN 
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@ID", ID)
            Return DBBridge.ExecuteScalar("_spLMS", sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

