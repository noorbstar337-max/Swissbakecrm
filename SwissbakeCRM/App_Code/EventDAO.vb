Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports APPCODE.DAL

'/// <summary>
'/// EventDAO class is the main class which interacts with the database. 
'/// </summary>


Public Class EventDAO
    'change the connection string as per your database connection.

    Private Shared connectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("connectionString").ToString



    'this method retrieves all events within range start-end

    '    'side note: if you want to show events only related to particular users,
    '    'if user id of that user is stored in session as Session["userid"]
    '    'the event table also contains a extra field named 'user_id' to mark the event for that particular user
    '    'then you can modify the SQL as:
    '    'SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
    '    'then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    'End Function
    'Public Shared Function getSession() As String
    '    If HttpContext.Current.Session("UserId") IsNot Nothing Then
    '        Dim sessionID As String = HttpContext.Current.Session("UserId").ToString()
    '        Return sessionID
    '    Else
    '        Return "null"
    '    End If
    'End Function
    Public Shared Function getEvents(start As DateTime, [end] As DateTime, Activity_Owner As Integer) As List(Of CalendarEvent)

        Dim events As New List(Of CalendarEvent)()
        Dim con As New SqlConnection(connectionString)
        ' Dim Owner As Integer = HttpContext.Current.Session("userid")
        ' Dim cmd As New SqlCommand("SELECT Activity_Id, isnull(Activity_Description,'-') as Activity_Description, Activity_Subject, Activity_CallStartTime, Activity_CallEndTime, dbo.ActivityRealtedToNameToFunction([Activity_Id]) as 'Name' FROM tblActivity where Activity_CallStartTime>=@start AND Activity_CallEndTime<=@end", con)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "_spActivity"
        cmd.Connection = con
        'working  'Dim cmd As New SqlCommand("SELECT Activity_Id, isnull(Activity_Description,'-') as Activity_Description, Activity_Subject, Activity_CallStartTime, Activity_CallEndTime, dbo.ActivityRealtedToNameToFunction([Activity_Id]) as 'Name' FROM tblActivity where Activity_Owner=@Activity_Owner AND Activity_Del='False' AND  Activity_CallStartTime>=@start AND Activity_CallEndTime<=@end", con)
        ' Dim cmd As New SqlCommand("SELECT Activity_Id,  Activity_Subject, Activity_CallStartTime, Activity_CallEndTime, dbo.ActivityRealtedToNameToFunction([Activity_Id]) as 'Name' FROM tblActivity where Activity_CallStartTime>=@start AND Activity_CallEndTime<=@end", con)
        cmd.Parameters.AddWithValue("@Activity_CallStartTime", start)
        cmd.Parameters.AddWithValue("@Activity_CallEndTime", [end])
        cmd.Parameters.AddWithValue("@Activity_Id", HttpContext.Current.Session("UserId"))
        cmd.Parameters.AddWithValue("@Mode", "FillAllCalendarActivity")
        'System.Web.HttpContext.Current.Session("databasename")
        Using con
            con.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim cevent As New CalendarEvent()
                cevent.Activity_Id = CInt(reader("ID"))
                'cevent.Activity_Owner = CInt(reader("Activity_Owner"))
                cevent.Activity_Subject = DirectCast(reader("Subject"), String)
                cevent.Activity_Description = DirectCast(reader("Activity_Description"), String)
                cevent.Assign_To = DirectCast(reader("AssignTo"), String)
                cevent.Status = DirectCast(reader("Status"), String)
                cevent.Activity_RelatedTypeID = DirectCast(reader("Name"), String) + ", Assign To:" + DirectCast(reader("AssignTo"), String)
                cevent.start = DirectCast(reader("Activity_CallStartTime"), DateTime)
                cevent.[end] = DirectCast(reader("Activity_CallEndTime"), DateTime)
                events.Add(cevent)
            End While
        End Using
        Return events
        'side note: if you want to show events only related to particular users,
        'if user id of that user is stored in session as Session["userid"]
        'the event table also contains a extra field named 'user_id' to mark the event for that particular user
        'then you can modify the SQL as:
        'SELECT event_id, description, title, event_start, event_end FROM event where user_id=@user_id AND event_start>=@start AND event_end<=@end
        'then add paramter as:cmd.Parameters.AddWithValue("@user_id", HttpContext.Current.Session["userid"]);
    End Function
    'this method updates the event title and description
    Public Shared Sub updateEvent(Activity_Id As Integer, Activity_Subject As [String], Activity_Description As [String], Activity_RelatedTypeID As String, Assign_To As String)
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("UPDATE tblActivity SET Activity_Subject=@Activity_Subject, Activity_Description=@Activity_Description WHERE Activity_Id=@Activity_Id", con)

        cmd.Parameters.AddWithValue("@Activity_Subject", Activity_Subject)
        cmd.Parameters.AddWithValue("@Activity_Description", Activity_Description)
        cmd.Parameters.AddWithValue("@Activity_Id", Activity_Id)
        Using con
            con.Open()
            cmd.ExecuteNonQuery()
        End Using


    End Sub

    'this method updates the event start and end time
    Public Shared Sub updateEventTime(Activity_Id As Integer, start As DateTime, [end] As DateTime)
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("UPDATE tblActivity SET Activity_CallStartTime=@Activity_CallStartTime, Activity_CallEndTime=@Activity_CallEndTime WHERE Activity_Id=@Activity_Id", con)
        cmd.Parameters.AddWithValue("@Activity_CallStartTime", start)
        cmd.Parameters.AddWithValue("@Activity_CallEndTime", [end])
        cmd.Parameters.AddWithValue("@Activity_Id", Activity_Id)
        Using con
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    'this method deletes event with the id passed in.
    Public Shared Sub deleteEvent(Activity_Id As Integer)
        Dim con As New SqlConnection(connectionString)
        Dim cmd As New SqlCommand("UPDATE tblActivity SET Activity_Del=1 WHERE (Activity_Id = @Activity_Id)", con)
        cmd.Parameters.AddWithValue("@Activity_Id", Activity_Id)
        Using con
            con.Open()
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    'this method adds events to the database
    Public Shared Function addEvent(cevent As CalendarEvent) As Integer
        ' Dim Owner As Integer = HttpContext.Current.Session("userid")
        Dim sqlparams(5) As SqlParameter
        'Dim con As New SqlConnection(connectionString)
        'Dim cmd As SqlCommand
        Dim conn As String
        Try
            sqlparams(0) = New SqlParameter("@Mode", "InsertFullTask")
            sqlparams(1) = New SqlParameter("@Activity_Description", cevent.Activity_Description)

            sqlparams(2) = New SqlParameter("@Activity_Subject", cevent.Activity_Subject)
            sqlparams(3) = New SqlParameter("@Activity_CallStartTime", cevent.start)
            sqlparams(4) = New SqlParameter("@Activity_CallEndTime", cevent.[end])
            sqlparams(5) = New SqlParameter("@Activity_Owner", System.Web.HttpContext.Current.Session("UserId"))
            conn = DBBridge.ExecuteScalar("_spActivity", sqlparams)
        Catch ex As Exception

            conn = 0
        End Try
        Return conn
        'Dim key As Integer = 0

        'Using con

        '    con.Open()
        '    cmd.ExecuteNonQuery()
        '    cmd = New SqlCommand("SELECT max(Activity_Id) FROM tblActivity where Activity_Subject=@Activity_Subject AND Activity_Result=@Activity_Result AND Activity_CallStartTime=@Activity_CallStartTime AND Activity_CallEndTime=@Activity_CallEndTime", con)


        '    cmd.Parameters.AddWithValue("@Activity_Subject", cevent.Activity_Subject)
        '    cmd.Parameters.AddWithValue("@Activity_Description", cevent.Activity_Description)
        '    cmd.Parameters.AddWithValue("@Activity_CallStartTime", cevent.start)
        '    cmd.Parameters.AddWithValue("@Activity_CallEndTime", cevent.[end])

        '    key = CInt(cmd.ExecuteScalar())
        'End Using

        'Return key

    End Function
    '   Public Shared Function addEvent(cevent As CalendarEvent) As Integer
    '    'add event to the database and return the primary key of the added event row

    '    'insert
    '    Dim con As New SqlConnection(connectionString)
    '    Dim cmd As New SqlCommand("INSERT INTO tblActivity(Activity_Subject, Activity_Result, Activity_CallStartTime, Activity_CallEndTime) VALUES(@Activity_Subject, @Activity_Result, @Activity_CallStartTime, @Activity_CallEndTime)", con)


    '    cmd.Parameters.AddWithValue("@Activity_Subject", cevent.Activity_Subject)
    '    cmd.Parameters.AddWithValue("@Activity_Result", cevent.Activity_Result)
    '    cmd.Parameters.AddWithValue("@Activity_CallStartTime", cevent.start)
    '    cmd.Parameters.AddWithValue("@Activity_CallEndTime", cevent.[end])

    '    Dim key As Integer = 0
    '    Using con
    '        con.Open()
    '        cmd.ExecuteNonQuery()

    '        'get primary key of inserted row
    '        cmd = New SqlCommand("SELECT max(Activity_Id) FROM tblActivity where Activity_Subject=@Activity_Subject AND Activity_Result=@Activity_Result AND Activity_CallStartTime=@Activity_CallStartTime AND Activity_CallEndTime=@Activity_CallEndTime", con)


    '        cmd.Parameters.AddWithValue("@Activity_Subject", cevent.Activity_Subject)
    '        cmd.Parameters.AddWithValue("@Activity_Result", cevent.Activity_Result)
    '        cmd.Parameters.AddWithValue("@Activity_CallStartTime", cevent.start)
    '        cmd.Parameters.AddWithValue("@Activity_CallEndTime", cevent.[end])

    '        key = CInt(cmd.ExecuteScalar())
    '    End Using

    '    Return key

    'End Function



End Class



