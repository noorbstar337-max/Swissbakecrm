Imports Microsoft.VisualBasic
Imports APPCODE.DAL
Imports System.Net
Imports System.Net.Mail
Imports System.IO

Public Class ActivityBLL
    Private Shared _spname As String = "_spActivity"

    Public Shared Function Insert(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal ActivityStatus As String, ByVal Activity_Duedate As Date, ByVal Activity_Type As String,
             ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal Activity_Priority As String, ByVal AudtTrail_LogId As Integer,
             ByVal CreatedID As Integer, ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(14) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertTask")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(3) = New SqlParameter("@Activity_Duedate", Activity_Duedate)
            sqlparams(4) = New SqlParameter("@Activity_Type", Activity_Type)
            sqlparams(5) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(6) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(9) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(10) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(11) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(12) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(13) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(14) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertFullTask(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal ActivityStatus As String, ByVal Activity_Duedate As Date, ByVal Activity_Type As String,
           ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal Activity_Priority As String, ByVal AudtTrail_LogId As Integer,
           ByVal Description As String, ByVal Result As String, ByVal CreatedID As Integer, ByVal Fromdate As DateTime,
           ByVal Todate As DateTime, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(18) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFullTask")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(3) = New SqlParameter("@Activity_Duedate", Activity_Duedate)
            sqlparams(4) = New SqlParameter("@Activity_Type", Activity_Type)
            sqlparams(5) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(6) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(9) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(10) = New SqlParameter("@Activity_Description", Description)
            sqlparams(11) = New SqlParameter("@Activity_Result", Result)
            sqlparams(12) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(13) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(14) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(15) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(16) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(17) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(18) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillActivity() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(1) = New SqlParameter("@Mode", "FillActivity")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillActivityByRelatedType(ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillActivityByRelatedType")
            sqlparams(1) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(2) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillCloseActivityByRelatedType(ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ID As Integer) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "FillCloseActivityByRelatedType")
            sqlparams(1) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(2) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillTaskType(ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(2) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillTaskTypeById(ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(2) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateTask(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal ActivityStatus As String, ByVal Activity_Duedate As Date, ByVal Activity_Type As String,
           ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal Activity_Priority As String, ByVal AudtTrail_LogId As Integer,
           ByVal Description As String, ByVal Result As String, ByVal CreatedID As Integer, ByVal ID As Integer,
           ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateTask")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(3) = New SqlParameter("@Activity_Duedate", Activity_Duedate)
            sqlparams(4) = New SqlParameter("@Activity_Type", Activity_Type)
            sqlparams(5) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(6) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(9) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(10) = New SqlParameter("@Activity_Description", Description)
            sqlparams(11) = New SqlParameter("@Activity_Result", Result)
            sqlparams(12) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(13) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(14) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(15) = New SqlParameter("@Activity_Id", ID)
            sqlparams(16) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(17) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(18) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(19) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ClosedActivity(ByVal ID As Integer, ByVal Result As String) As Integer
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ClosedActivity")
            sqlparams(1) = New SqlParameter("@Activity_Id", ID)
            sqlparams(2) = New SqlParameter("@Activity_Result", Result)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Shared Function ChangeToDSR(ByVal Activity_Id As Integer, ByVal UserId As Integer) As Integer '========== Activity.aspx =========   By MUBYN 
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ChangeToDSR")
            sqlparams(1) = New SqlParameter("@Activity_Id", Activity_Id)
            sqlparams(2) = New SqlParameter("@Activity_ModifiedID", UserId)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertFullEvent(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal Location As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
          ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal ActivityStatus As String, ByVal AudtTrail_LogId As Integer,
          ByVal Description As String, ByVal CreatedID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(16) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFullEvent")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_Location", Location)
            sqlparams(3) = New SqlParameter("@Activity_Fromdate", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_Todate", Todate)
            sqlparams(5) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Description", Description)
            sqlparams(10) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(11) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(12) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(13) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(14) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(15) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(16) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertEvent(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal Location As String,
     ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal AudtTrail_LogId As Integer,
     ByVal CreatedID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertEvent")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_Location", Location)
            sqlparams(3) = New SqlParameter("@Activity_Fromdate", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_Todate", Todate)
            sqlparams(5) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(10) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(11) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(12) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Shared Function UpdateEvent(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal Location As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
          ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal ActivityStatus As String, ByVal AudtTrail_LogId As Integer,
          ByVal Description As String, ByVal ModifiedID As Integer, ByVal ID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(17) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateEvent")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_Location", Location)
            sqlparams(3) = New SqlParameter("@Activity_Fromdate", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_Todate", Todate)
            sqlparams(5) = New SqlParameter("@Activity_ModifiedID", ModifiedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Description", Description)
            sqlparams(10) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(11) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(12) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(13) = New SqlParameter("@Activity_Id", ID)
            sqlparams(14) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(15) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(16) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(17) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertFullCall(ByVal Result As String, ByVal Activity_Subject As String, ByVal CallType As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
          ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal Activity_ActivityStatus As String, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal AudtTrail_LogId As Integer,
          ByVal Description As String, ByVal CallPurpose As String, ByVal Billable As Boolean, ByVal CreatedID As Integer,
          ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFullCall")
            sqlparams(1) = New SqlParameter("@Activity_Result", Result)
            sqlparams(2) = New SqlParameter("@Activity_CallType", CallType)
            sqlparams(3) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(5) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Description", Description)
            sqlparams(10) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(11) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(12) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(13) = New SqlParameter("@Activity_CallPurpose", CallPurpose)
            sqlparams(14) = New SqlParameter("@Activity_IsBillable", Billable)
            sqlparams(15) = New SqlParameter("@Activity_Owner", CreatedID)
            sqlparams(16) = New SqlParameter("@Activity_ActivityStatus", Activity_ActivityStatus)
            sqlparams(17) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(18) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(19) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateCall(ByVal Result As String, ByVal Activity_Subject As String, ByVal CallType As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
         ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal Activity_ActivityStatus As String, ByVal ContactType As String, ByVal ContactTypeID As Integer, ByVal AudtTrail_LogId As Integer,
         ByVal Description As String, ByVal CallPurpose As String, ByVal Billable As Boolean, ByVal ModifiedID As Integer,
         ByVal ID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(19) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateCall")
            sqlparams(1) = New SqlParameter("@Activity_Result", Result)
            sqlparams(2) = New SqlParameter("@Activity_CallType", CallType)
            sqlparams(3) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(5) = New SqlParameter("@Activity_ModifiedID", ModifiedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Description", Description)
            sqlparams(10) = New SqlParameter("@Activity_ContactType", ContactType)
            sqlparams(11) = New SqlParameter("@Activity_ContactTypeID", ContactTypeID)
            sqlparams(12) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(13) = New SqlParameter("@Activity_CallPurpose", CallPurpose)
            sqlparams(14) = New SqlParameter("@Activity_IsBillable", Billable)
            sqlparams(15) = New SqlParameter("@Activity_Id", ID)
            sqlparams(16) = New SqlParameter("@Activity_ActivityStatus", Activity_ActivityStatus)
            sqlparams(17) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(18) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(19) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertCall(ByVal Activity_Subject As String, ByVal CallType As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
          ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal AudtTrail_LogId As Integer,
          ByVal CallPurpose As String, ByVal CreatedID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertCall")
            sqlparams(1) = New SqlParameter("@Activity_CallType", CallType)
            sqlparams(2) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(3) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(4) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(6) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(7) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(8) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(9) = New SqlParameter("@Activity_CallPurpose", CallPurpose)
            sqlparams(10) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(11) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(12) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function FillAllActivity(ByVal PageIndex As Integer, ByVal PageSize As Integer, ByVal ID As Integer, ByVal Mode As String) As DataSet
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@PageIndex", PageIndex)
            sqlparams(2) = New SqlParameter("@PageSize", PageSize)
            sqlparams(3) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function SearchAllActivity(ByVal Mode As String, ByVal ID As Integer, ByVal SearchValue As String) As DataSet
        Dim sqlparams(2) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Activity_Id", ID)
            sqlparams(2) = New SqlParameter("@SearchValue", SearchValue)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertChildTask(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal ActivityStatus As String, ByVal Activity_Duedate As Date, ByVal Activity_Type As String,
             ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal Activity_Priority As String, ByVal AudtTrail_LogId As Integer, ByVal CreatedID As Integer,
             ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal _ChildID As Integer, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(15) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertChildTask")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_ActivityStatus", ActivityStatus)
            sqlparams(3) = New SqlParameter("@Activity_Duedate", Activity_Duedate)
            sqlparams(4) = New SqlParameter("@Activity_Type", Activity_Type)
            sqlparams(5) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(6) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(7) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(8) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(9) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(10) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(11) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(12) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(13) = New SqlParameter("@Activity_IsChildID", _ChildID)
            sqlparams(14) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(15) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateFollowActivity(ByVal ModifiedID As Integer, ByVal ID As Integer, ByVal Activity_Result As String) As Integer
        Dim sqlparams(3) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateFollowActivity")
            sqlparams(1) = New SqlParameter("@Activity_ModifiedID", ModifiedID)
            sqlparams(2) = New SqlParameter("@Activity_Id", ID)
            sqlparams(3) = New SqlParameter("@Activity_Result", Activity_Result)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertChildEvent(ByVal Owner As Integer, ByVal Activity_Subject As String, ByVal Location As String,
    ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal AudtTrail_LogId As Integer,
    ByVal CreatedID As Integer, ByVal _ChildID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertChildEvent")
            sqlparams(1) = New SqlParameter("@Activity_Owner", Owner)
            sqlparams(2) = New SqlParameter("@Activity_Location", Location)
            sqlparams(3) = New SqlParameter("@Activity_Fromdate", Fromdate)
            sqlparams(4) = New SqlParameter("@Activity_Todate", Todate)
            sqlparams(5) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(6) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(7) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(8) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(9) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(10) = New SqlParameter("@Activity_IsChildID", _ChildID)
            sqlparams(11) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(12) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(13) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertChildCall(ByVal Activity_Subject As String, ByVal CallType As String, ByVal Fromdate As DateTime, ByVal Todate As DateTime,
         ByVal RelatedType As String, ByVal RelatedTypeID As Integer, ByVal AudtTrail_LogId As Integer,
         ByVal CallPurpose As String, ByVal CreatedID As Integer, ByVal _ChildID As Integer, ByVal Activity_Priority As String, ByVal Reminder As Boolean, ByVal Reminderdatetime As DateTime) As Integer
        Dim sqlparams(13) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertChildCall")
            sqlparams(1) = New SqlParameter("@Activity_CallType", CallType)
            sqlparams(2) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(3) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(4) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(5) = New SqlParameter("@AudtTrail_LogId", AudtTrail_LogId)
            sqlparams(6) = New SqlParameter("@Activity_RelatedType", RelatedType)
            sqlparams(7) = New SqlParameter("@Activity_RelatedTypeID", RelatedTypeID)
            sqlparams(8) = New SqlParameter("@Activity_Subject", Activity_Subject)
            sqlparams(9) = New SqlParameter("@Activity_CallPurpose", CallPurpose)
            sqlparams(10) = New SqlParameter("@Activity_IsChildID", _ChildID)
            sqlparams(11) = New SqlParameter("@Activity_Priority", Activity_Priority)
            sqlparams(12) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(13) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CalenderActivity() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "CalenderActivity")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function InsertPostpone(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal CreatedID As Integer, ByVal Reminder As Boolean,
                                          ByVal Reminderdatetime As DateTime, ByVal Activity_Result As String) As Integer
        Dim sqlparams(6) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertPostpone")
            sqlparams(1) = New SqlParameter("@Activity_CallStartTime", Fromdate)
            sqlparams(2) = New SqlParameter("@Activity_CallEndTime", Todate)
            sqlparams(3) = New SqlParameter("@Activity_CreatedID", CreatedID)
            sqlparams(4) = New SqlParameter("@Activity_Reminder", Reminder)
            sqlparams(5) = New SqlParameter("@Activity_Reminderdatetime", Reminderdatetime)
            sqlparams(6) = New SqlParameter("@Activity_Result", Activity_Result)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ActivityReminder(ByVal _OwnerID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ActivityReminder")
            sqlparams(1) = New SqlParameter("@Activity_Owner", _OwnerID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function UpdateEmailSend(ByVal _Id As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "UpdateEmailSend")
            sqlparams(1) = New SqlParameter("@Activity_Id", _Id)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Sendmail() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ActivityEmailNotify")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)

        Catch ex As Exception
            Throw ex
        End Try
        'Using mm As New MailMessage("shahidacaira@gmail.com", Email)
        '    mm.Subject = "Enquiry From Website"
        '    mm.Body = "Hi"
        '    mm.IsBodyHtml = True
        '    Dim smtp As New SmtpClient()
        '    smtp.Host = "smtp.gmail.com"
        '    smtp.EnableSsl = True
        '    Dim NetworkCred As New NetworkCredential("shahidacaira@gmail.com", "gdfgdfgdfgdfgdfgdfg")
        '    smtp.UseDefaultCredentials = True
        '    smtp.Credentials = NetworkCred
        '    smtp.Port = 587
        '    smtp.EnableSsl = True
        '    smtp.Send(mm)
        'End Using
    End Function

    Public Shared Function SendActivityMail(ByVal email As String, ByVal Content As String, ByVal Subj As String) As String
        Try
            Dim SendFrom As MailAddress = New MailAddress("irfan.bstar@gmail.com")
            Dim smtp As New SmtpClient
            Dim MyMessage As MailMessage = New MailMessage()
            MyMessage.From = SendFrom
            Dim Multi As String() = email.Split(","c)
            'spiliting input Email id string with comma(,)
            For Each Multiemailid As String In Multi
                'adding multi reciver's Email Id
                MyMessage.[To].Add(New MailAddress(Multiemailid))
            Next
            MyMessage.To.Add(email)
            MyMessage.Subject = Subj
            MyMessage.Body = Content
            MyMessage.IsBodyHtml = True
            smtp.UseDefaultCredentials = True
            'smtp.Port = 587
            smtp.Port = 25
            smtp.Credentials = New NetworkCredential("irfan.bstar@gmail.com", "mh01ay1039")
            smtp.Host = "smtp.gmail.com"
            'smtp.Host = "smtp-mail.outlook.com"
            smtp.EnableSsl = True
            smtp.Send(MyMessage)
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Your Enquiry has been register Successfully....')", True)
        Catch ex As Exception
            'Dim err As String = "alert('Error While Getting data" + ex.Message + "')"
            '  ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", err, True)
            Throw ex
        End Try
    End Function

    Public Shared Sub SendScheduleMail()
        ' Write your send mail code here.
        Dim ds As DataSet
        Dim email As String
        ds = ActivityBLL.Sendmail()
        If ds.Tables(0).Rows.Count >= 1 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim body As String = String.Empty
                'Dim FILENAME As String = HttpContext.Current.Server.MapPath("~/Email/Remindermail.html")
                ''Get a StreamReader class that can be used to read the file
                'Dim objStreamReader As StreamReader
                'objStreamReader = File.OpenText(FILENAME)
                'Dim reader As StreamReader = New StreamReader(Server.MapPath("~/Email/Remindermail.html"))
                'Dim reader As New StreamReader(HttpContext.Current.Server.MapPath("~/Email/Remindermail.html"))
                'body = reader.ReadToEnd
                body = "<table border='3' bgcolor='#FFFFFF' cellpadding='2' cellspacing='0' style='border-collapse:collapse;  border: 3px solid #1274C0;background-color:#FFFFFF;padding:2px;!Important;' bordercolor='rgb(18, 116, 192)'  width='800' height='100'> <tbody> <tr height='20' bgcolor=''> <td width='800' height='102'> <table border='1' cellpadding='2' cellspacing='0' style='border-collapse:collapse;' bordercolor='#1274C0' width='800' height='1'> <tbody> <tr height='20' bgcolor='C4DAFF'> <th width='1000' colspan='10' height='19' style='font-family:Arial;font-size:15px;font-weight:bold;color:#1274C0;text-align:center;'><b>Swiss Bake Ingredients Pvt Ltd </b></th> </tr> <tr height='20' bgcolor='#C4DAFF'> <th width='1000' colspan='10' height='19' style='font-family:Arial;font-size:15px;font-weight:bold;color:#1274C0;text-align:left;'><b>&nbsp;Activity Reminder: " + DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("Remindertime").ToString) + "</b></th> </tr> <tr> <td style='width: 20%;'> <strong> <span>" + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Related Type").ToString) + "</span> </strong> </td> <td> " + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Name").ToString) + " </td> </tr> <tr> <td style='width: 20%;'> <strong> <span>Activity Assign</span> </strong> </td> <td> " + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("AssignTo").ToString) + " </td> </tr> <tr> <td style='width: 20%;'><strong>Activity Subject</strong></td> <td> " + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Subject").ToString) + " </td> </tr> <tr> <td><strong>Activity Date </strong></td> <td> <b>From </b> " + DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("From").ToString) + " <b>To</b> " + DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("To").ToString) + " </td> </tr> <tr> <td><strong>Status</strong></td> <td> <span class='label label-success'>" + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Status").ToString) + "</span> </td> </tr> <tr> <td><strong>Priority</strong></td> <td> <span class='label label-success'>" + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Priority").ToString) + "</span> </td> </tr> <tr> <td><strong>Desc</strong></td> <td>" + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Activity_Description").ToString) + "</td> </tr> <tr> <td><strong>Result</strong></td> <td>" + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Activity_Result").ToString) + "</td> </tr> <tr> <td colspan='10' height='15'> <font face='Verdana' size='1'><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u> </font> </td> </tr> <tr> <td width='100%' colspan='10' style='word-wrap:break-word;'> <font face='Verdana' size='1'></font> <br> <div align='justify'><font face='Verdana' size='1'>&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. </font></div> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table>"
                'body = body.Replace("#ReminderTime", DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("Remindertime").ToString))
                'body = body.Replace("#Name", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Related Type").ToString))
                'body = body.Replace("#NameValue", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Name").ToString))
                'body = body.Replace("#Assign", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("AssignTo").ToString))
                'body = body.Replace("#Subject", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Subject").ToString))
                'body = body.Replace("#DateFrom", DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("From").ToString))
                'body = body.Replace("#DateTo", DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("To").ToString))
                'body = body.Replace("#Status", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Status").ToString))
                'body = body.Replace("#Priority", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Priority").ToString))
                'body = body.Replace("#Desc", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Activity_Description").ToString))
                'body = body.Replace("#Email", DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Activity_Result").ToString))
                email = DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("Email").ToString)
                'Remindertime()
                ActivityBLL.SendActivityMail(email, body, "CRM - Activity Reminder Notification on " + DynamicparcelDataManipulation.DateFormatWithTime(ds.Tables(0).Rows(i)("Remindertime").ToString) + " For " + DynamicparcelDataManipulation.FixNullFromDB(ds.Tables(0).Rows(i)("AssignTo").ToString) + "")
                ActivityBLL.UpdateEmailSend(ds.Tables(0).Rows(i)("ID").ToString)
            Next
        End If
    End Sub

    Public Shared Sub Main()
        '
        ' It will free resources on its own.
        '
        Dim line As String
        Using reader As New StreamReader("~/Email/Remindermail.html")
            line = reader.ReadLine()
        End Using
        Console.WriteLine(line)
    End Sub
    Public Shared Function ClosedReminder(ByVal ID As Integer) As Integer
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ClosedReminder")
            sqlparams(1) = New SqlParameter("@Activity_Id", ID)
            Return DBBridge.ExecuteNonQuery(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function TodayActivityMailByOwner(ByVal ID As Integer) As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "TodayActivityMailByOwner")
            sqlparams(1) = New SqlParameter("@Activity_Owner", ID)
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ActivityOwnerList() As DataSet
        Dim sqlparams(1) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "ActivityOwnerList")
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub SendTodayMail()
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim sb As New StringBuilder
        ds = ActivityBLL.ActivityOwnerList()
        If ds.Tables(0).Rows.Count >= 1 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                sb.Append("<div><hr id='ecxstopSpelling'>Subject:SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "<br><br><title>Today Activity Email Notification</title>")
                sb.Append("<table bgcolor='#FFFFFF' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='100'><tbody><tr height='20' bgcolor=""><td width='1000' height='102'><table border='1' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='1'><tbody>")
                sb.Append("<tr height='20' bgcolor='C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: center;'><b>Swiss Bake Ingredients Pvt Ltd  : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</b></th> </tr><tr height='20' bgcolor='#C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: left;'><b>&nbsp;Today Activity</b></th></tr>")
                sb.Append("<tr height='20'>")
                sb.Append("<td width='20' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;S.No</b></td>")
                sb.Append("<td width='150' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;' nowrap=""><b>&nbsp;Related To</b></td>")
                sb.Append("<td width='50' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;' nowrap=""><b>&nbsp;Name</b></td>")
                sb.Append("<td width='80'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;' nowrap=""><b>&nbsp;Subject</b></td>")
                sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;' nowrap=""><b>&nbsp;Activity Type</b></td>")
                sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;From</b></td>")
                sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;To</b></td>")
                sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;Priority</b></td>")
                sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;Status</b></td>")
                sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px;'><b>&nbsp;AssingTo</b></td>")
                sb.Append("</tr>")

                ds1 = ActivityBLL.TodayActivityMailByOwner(ds.Tables(0).Rows(i)("U_Id").ToString)
                If ds1.Tables(0).Rows.Count >= 1 Then
                    For k As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        Dim temp As Integer = k + 1
                        sb.Append("<tr>")
                        sb.Append("<td width='20'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;'>" + temp.ToString + "</td>")
                        sb.Append("<td width='150' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Related Type").ToString + "</td>")
                        sb.Append("<td width='50'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Name").ToString + "</td>")
                        sb.Append("<td width='80'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Subject").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Activity Type").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("From").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("To").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Priority").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Status").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("AssignTo").ToString + "</td>")
                        sb.Append("</tr>")
                    Next
                End If
                sb.Append("<tr><td colspan='10' height='15'><font face='Verdana' size='1'><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u></font></td></tr><tr><td width='100%' colspan='10' style='word-wrap: break-word;'><font face='Verdana' size='1'></font><br><div align='justify'><font face='Verdana' size='1'>&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. If you have received this message in error, please contact support@salesbabu.com and delete the message. Thank you. </font></div></td></tr>")
                sb.Append("</tbody></table></td></tr></tbody></table><br><font size='1' color='#666666'>Sent by SalesBabu CRM</font><br></div>")
                If ds1.Tables(0).Rows.Count >= 1 Then
                    ActivityBLL.SendActivityMail("irfan.bstar@gmail.com", sb.ToString, "SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "")
                End If
            Next
        End If
    End Sub

    Public Shared Function SendTodayMail1() As StringBuilder
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim sb As New StringBuilder
        ds = ActivityBLL.ActivityOwnerList()
        If ds.Tables(0).Rows.Count >= 1 Then
            For i As Integer = 0 To 1
                'sb.Append("<div><hr id='ecxstopSpelling'/>Subject:SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "<br><br><title>Today Activity Email Notification</title>")
                'sb.Append("<table bgcolor='#FFFFFF' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='100'><tbody><tr height='20' bgcolor=""><td width='1000' height='102'><table border='1' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='1'><tbody>")

                sb.Append("<table id='tablee' border='1' cellspacing='0'>")
                ' sb.Append("<tr height='20' bgcolor='C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: center;'><b>Swiss Bake Ingredients Pvt Ltd  : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</b></th> </tr><tr height='20' bgcolor='#C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: left;'><b>&nbsp;Today Activity</b></th></tr>")
                sb.Append("<tr>")

                sb.Append("<th>S.No</th>")
                sb.Append("<th>Related To</th>")
                sb.Append("<th>Name</th>")
                sb.Append("<th>Subject</th>")
                sb.Append("<th>Activity Type</th>")
                sb.Append("<th>From</th>")
                sb.Append("<th>To</th>")
                sb.Append("<th>Priority</th>")
                sb.Append("<th>Status</th>")
                sb.Append("<th>AssingTo</th>")
                sb.Append("</tr>")

                ds1 = ActivityBLL.TodayActivityMailByOwner(ds.Tables(0).Rows(i)("U_Id").ToString)
                If ds1.Tables(0).Rows.Count >= 1 Then
                    For k As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        Dim temp As Integer = k + 1
                        sb.Append("<tr>")
                        sb.Append("<td width='20'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;'>" + temp.ToString + "</td>")
                        sb.Append("<td width='150' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Related Type").ToString + "</td>")
                        sb.Append("<td width='50'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Name").ToString + "</td>")
                        sb.Append("<td width='80'  bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Subject").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("Activity Type").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='font-size: 12px; font-family: verdana;' nowrap="">" + ds1.Tables(0).Rows(k)("From").ToString + "</td>")
                        sb.Append("<td width='100' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("To").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Priority").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Status").ToString + "</td>")
                        sb.Append("<td width='330' bgcolor='#FFFFFF' height='1' valign='top' style='word-wrap: break-word; font-size: 12px; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("AssignTo").ToString + "</td>")
                        sb.Append("</tr>")
                    Next
                End If
                sb.Append("<tr><td colspan='10' height='15'><font face='Verdana' size='1'><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u></font></td></tr><tr><td width='100%' colspan='10' style='word-wrap: break-word;'><font face='Verdana' size='1'></font><br><div align='justify'><font face='Verdana' size='1'>&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. If you have received this message in error, please contact support@salesbabu.com and delete the message. Thank you. </font></div></td></tr>")
                sb.Append("</tbody></table></td></tr></tbody></table><br><font size='1' color='#666666'>Sent by SalesBabu CRM</font><br></div>")
                If ds1.Tables(0).Rows.Count >= 1 Then
                    ActivityBLL.SendActivityMail("irfan.bstar@gmail.com", sb.ToString, "SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "")
                End If
            Next
            Return sb
        End If
    End Function

    Public Shared Sub SendActivityTodayMail()
        Dim ds As DataSet
        Dim ds1 As DataSet
        Dim sb As New StringBuilder
        ds = ActivityBLL.ActivityOwnerList()
        If ds.Tables(0).Rows.Count >= 1 Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'sb.Append("<div><hr id='ecxstopSpelling'/>Subject:SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "<br><br><title>Today Activity Email Notification</title>")
                'sb.Append("<table bgcolor='#FFFFFF' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='100'><tbody><tr height='20' bgcolor=""><td width='1000' height='102'><table border='1' cellpadding='2' cellspacing='0' style='border-collapse: collapse;' bordercolor='#1274C0' width='1000' height='1'><tbody>")
                sb.Append("<table id='tablee' border='1' style='border-color:gray;width:960px;' cellspacing='0'>")
                ' sb.Append("<tr height='20' bgcolor='C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: center;'><b>Swiss Bake Ingredients Pvt Ltd  : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</b></th> </tr><tr height='20' bgcolor='#C4DAFF'><th width='1000' colspan='10' height='19' style='font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: left;'><b>&nbsp;Today Activity</b></th></tr>")
                sb.Append("<tr style='background-color: rgb(196, 218, 255);'><td colspan='10' style='text-align:center; color: #1274c0;font-weight:bold;font-family: sans-serif;padding: 6px;'>Swiss Bake Ingredients Pvt Ltd : " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</td></tr>")
                sb.Append("<tr style='background-color: rgb(196, 218, 255);'><td colspan='10' style='  color: #1274c0;font-weight:bold;font-family: sans-serif;padding: 6px;'>Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "</td></tr>")
                sb.Append("<tr>")
                sb.Append("<th>S.No</th>")
                sb.Append("<th>Related To</th>")
                sb.Append("<th>Name</th>")
                sb.Append("<th style='width:150px;'>Subject</th>")
                sb.Append("<th>Activity Type</th>")
                sb.Append("<th>From</th>")
                sb.Append("<th>To</th>")
                sb.Append("<th>Priority</th>")
                sb.Append("<th>Status</th>")
                sb.Append("<th>AssingTo</th>")
                sb.Append("</tr>")
                ds1 = ActivityBLL.TodayActivityMailByOwner(ds.Tables(0).Rows(i)("U_Id").ToString)
                If ds1.Tables(0).Rows.Count >= 1 Then
                    For k As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                        Dim temp As Integer = k + 1
                        sb.Append("<tr>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + temp.ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Related Type").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Name").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Subject").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Activity Type").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center;font-family: verdana;'>" + ds1.Tables(0).Rows(k)("From").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("To").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Priority").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("Status").ToString + "</td>")
                        sb.Append("<td style='font-size:12px;text-align:center; font-family: verdana;'>" + ds1.Tables(0).Rows(k)("AssignTo").ToString + "</td>")
                        sb.Append("</tr>")
                    Next
                End If
                sb.Append("</table>")
                ' sb.Append("<tr><td colspan='10' height='15'><font face='Verdana' size='1'><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u></font></td></tr><tr><td width='100%' colspan='10' style='word-wrap: break-word;'><font face='Verdana' size='1'></font><br><div align='justify'><font face='Verdana' size='1'>&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. If you have received this message in error, please contact support@salesbabu.com and delete the message. Thank you. </font></div></td></tr>")
                ' sb.Append("</tbody></table></td></tr></tbody></table><br><font size='1' color='#666666'>Sent by SalesBabu CRM</font><br></div>")
                If ds1.Tables(0).Rows.Count >= 1 Then
                    ActivityBLL.SendActivityMail("" + ds.Tables(0).Rows(i)("U_Email").ToString + "", sb.ToString, "SwissBake CRM -Today Activity Notification " + DateTime.Now.ToString("dd-MM-yyyy") + " for " + ds.Tables(0).Rows(i)("U_FirstName").ToString + "")
                End If
                sb.Clear()
            Next
        End If
    End Sub
    Public Shared Function SearchActivitybyType(ByVal Mode As String, ByVal ID As Integer, ByVal SearchValue As String, ByVal Type As String) As DataSet
        Dim sqlparams(4) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", Mode)
            sqlparams(1) = New SqlParameter("@Activity_Id", ID)
            sqlparams(2) = New SqlParameter("@SearchValue", SearchValue)
            If Type = "" Then
                sqlparams(3) = New SqlParameter("@Type", DBNull.Value)
            Else
                sqlparams(3) = New SqlParameter("@Type", Type)
            End If
            Return DBBridge.ExecuteDataset(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Mubyn DSR 30-Jul-2020
    Public Shared Function InsertRating(ByVal Rating_AgentId As Integer, ByVal Rating_TypeId As String, ByVal Rating_Listening As Integer,
                                        ByVal Rating_Knowledge As Integer, ByVal Rating_Understandability As Integer, ByVal Rating_Remark As String,
                                        ByVal Rating_Status As String, ByVal Rating_CreatedBy As Integer, ByVal Rating_DeleteDate As String, ByVal Rating_BadStatus As String) As Integer
        Dim sqlparams(12) As SqlParameter
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertRating")
            sqlparams(2) = New SqlParameter("@Rating_AgentId", Rating_AgentId)
            sqlparams(3) = New SqlParameter("@Rating_TypeId", Rating_TypeId)
            sqlparams(4) = New SqlParameter("@Rating_Listening", Rating_Listening)
            sqlparams(5) = New SqlParameter("@Rating_Knowledge", Rating_Knowledge)
            sqlparams(6) = New SqlParameter("@Rating_Understandability", Rating_Understandability)
            sqlparams(7) = New SqlParameter("@Rating_Remark", Rating_Remark)
            sqlparams(8) = New SqlParameter("@Rating_Status", Rating_Status)
            sqlparams(9) = New SqlParameter("@Rating_CreatedBy", Rating_CreatedBy)
            sqlparams(10) = New SqlParameter("@Rating_DeleteDate", Rating_DeleteDate)
            sqlparams(11) = New SqlParameter("@Rating_BadStatus", Rating_BadStatus)
            Return DBBridge.ExecuteScalar(_spname, sqlparams)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
