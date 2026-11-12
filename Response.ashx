<%@ WebHandler Language="VB" Class="Response" %>
Imports System
Imports System.Web
Imports System.Collections
Imports System.Collections.Generic
Imports System.Web.SessionState
Imports System.InvalidCastException

Public Class Response
    Implements IHttpHandler
    Implements IRequiresSessionState
   
    
    Public Property Activity_Owner() As Integer
        
        
        Get
            Return m_Activity_Owner
        End Get
        Set(value As Integer)
            m_Activity_Owner = value
        End Set
    End Property
    Private m_Activity_Owner As Integer
    Public Sub ProcessRequest(context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "application/json"

        Dim start As New DateTime(1970, 1, 1)
        Dim [end] As New DateTime(1970, 1, 1)
        Dim Activity_Owner As Integer = System.Web.HttpContext.Current.Session("UserId")
        'Dim name As String = context.Session("UserId").ToString()
        'System.Web.HttpContext.Current.Session("UserId")

        start = start.AddSeconds(Double.Parse(context.Request.QueryString("start")))
        [end] = [end].AddSeconds(Double.Parse(context.Request.QueryString("end")))
        'start = Convert.ToDateTime(context.Request.QueryString("start"))
        '[end] = Convert.ToDateTime(context.Request.QueryString("end"))
        ' Activity_Owner = 4
        
        
        'testing
        '  Dim listCalender As List(Of CalendarEvent) = EventDAO.getEvents(start, [end], Activity_Owner)
        '        Dim js As New System.Web.Script.Serialization.JavaScriptSerializer()
        '        'context.Response.Write(js.Serialize(listCalender))

        '        Dim result As [String] = [String].Empty

        '        result += "["

        '        Dim idList As New List(Of Integer)()
        
        '        For Each cevent As CalendarEvent In EventDAO.getEvents(start, [end], Activity_Owner)
        '            result += convertCalendarEventIntoString(cevent)
        '            idList.Add(cevent.Activity_Id)
        '        Next

        '        If result.EndsWith(",") Then
        '            result = result.Substring(0, result.Length - 1)
        '        End If

        '        result += "]"
        '        'store list of event ids in Session, so that it can be accessed in web methods
        '        'context.Session("idList") = idList
        
        '        context.Response.Write(js.Serialize(result))
        '        '  context.Response.Write(result)
        '    End Sub

        '    Private Function convertCalendarEventIntoString(cevent As CalendarEvent) As [String]
        '        Dim allDay As [String] = "true"
        '        If (cevent.start).ToString().Equals((cevent.[end]).ToString()) Then

        '            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 Then
        '                allDay = "true"
        '            Else
        '                allDay = "false"
        '            End If
        '        Else
        '            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 AndAlso cevent.[end].Hour = 0 AndAlso cevent.[end].Minute = 0 AndAlso cevent.[end].Second = 0 Then
        '                allDay = "true"
        '            Else
        '                allDay = "false"
        '            End If
        '        End If
        '        'Return "{" + "id: '" + cevent.id + "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.title) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.description) + "'" + "},"
        '        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'" + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "},"
        '        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'" + "},"
        '        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "},"
        '        'working code'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'},"
        '        Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlDecode(cevent.Activity_Subject) + "'," + "start:  " + cevent.start.ToString() + "," + "end: " + cevent.[end].ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'," + "Aname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Assign_To) + "'," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'},"
        '    End Function


        '    Public ReadOnly Property IsReusable() As Boolean
        '        Get
        '            Return False
        '        End Get
        '    End Property
    
        '    Public ReadOnly Property IsReusable1 As Boolean Implements IHttpHandler.IsReusable
        '        Get
        '            Return False
        '        End Get
        '    End Property

        '    Private Function ConvertToTimestamp(value As DateTime) As Long
        '        Dim epoch As Long = (value.ToUniversalTime().Ticks - 621355968000000000L) / 10000000
        '        Return epoch
        '    End Function
  
        'End Class

        'testing
        
        
        Dim result As [String] = [String].Empty

        result += "["

        Dim idList As New List(Of Integer)()
        For Each cevent As CalendarEvent In EventDAO.getEvents(start, [end], Activity_Owner)
            result += convertCalendarEventIntoString(cevent)
            idList.Add(cevent.Activity_Id)
        Next

        If result.EndsWith(",") Then
            result = result.Substring(0, result.Length - 1)
        End If

        result += "]"
        'store list of event ids in Session, so that it can be accessed in web methods
        context.Session("idList") = idList

        context.Response.Write(result)
    End Sub

    Private Function convertCalendarEventIntoString(cevent As CalendarEvent) As [String]
        Dim allDay As [String] = "true"
        If ConvertToTimestamp(cevent.start).ToString().Equals(ConvertToTimestamp(cevent.[end]).ToString()) Then

            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 Then
                allDay = "true"
            Else
                allDay = "false"
            End If
        Else
            If cevent.start.Hour = 0 AndAlso cevent.start.Minute = 0 AndAlso cevent.start.Second = 0 AndAlso cevent.[end].Hour = 0 AndAlso cevent.[end].Minute = 0 AndAlso cevent.[end].Second = 0 Then
                allDay = "true"
            Else
                allDay = "false"
            End If
        End If
        'Return "{" + "id: '" + cevent.id + "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.title) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.description) + "'" + "},"
        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'" + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "},"
        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'" + "},"
        'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'" + "},"
        'working code'Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'},"
        Return "{" & "id: '" & cevent.Activity_Id & "'," + "title: '" + HttpContext.Current.Server.HtmlDecode(cevent.Activity_Subject) + "'," + "start:  " + ConvertToTimestamp(cevent.start).ToString() + "," + "end: " + ConvertToTimestamp(cevent.[end]).ToString() + "," + "allDay:" + allDay + "," + "Rname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_RelatedTypeID) + "'," + "Aname: '" + HttpContext.Current.Server.HtmlEncode(cevent.Assign_To) + "'," + "description: '" + HttpContext.Current.Server.HtmlEncode(cevent.Activity_Description) + "'," + "Status: '" + HttpContext.Current.Server.HtmlDecode(cevent.Status) + "'},"
    End Function


    Public ReadOnly Property IsReusable() As Boolean
        Get
            Return False
        End Get
    End Property
    
    Public ReadOnly Property IsReusable1 As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Function ConvertToTimestamp(value As DateTime) As Long
        Dim epoch As Long = (value.ToUniversalTime().Ticks - 621355968000000000L) / 10000000
        Return epoch
    End Function
  
End Class


