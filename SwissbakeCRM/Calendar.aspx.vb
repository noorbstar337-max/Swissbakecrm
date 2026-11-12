Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Globalization
Imports System.Text.RegularExpressions
Partial Class Calendar
    Inherits System.Web.UI.Page

    'this method only updates title and description
    'this is called when a event is clicked on the calendar
    <System.Web.Services.WebMethod(True)> _
    Public Shared Function UpdateEvent(cevent As CalendarEvent) As String

        Dim idList As List(Of Integer) = DirectCast(System.Web.HttpContext.Current.Session("idList"), List(Of Integer))
        If idList IsNot Nothing AndAlso idList.Contains(cevent.Activity_Id) Then
            If CheckAlphaNumeric(cevent.Activity_Description) Then
                EventDAO.updateEvent(cevent.Activity_Id, cevent.Activity_Subject, cevent.Activity_Description, cevent.Activity_RelatedTypeID, cevent.Assign_To)

                Return "updated event with id:" & cevent.Activity_Id & " update title to: " + cevent.Activity_Subject + " update description to: " + cevent.Activity_Description + " update Rname to: " + cevent.Activity_RelatedTypeID + " update Aname to: " + cevent.Assign_To


            End If
        End If

        Return "unable to update event with id:" & cevent.Activity_Id & " title : " + cevent.Activity_Subject + " description : " + cevent.Activity_Description
    End Function

    'this method only updates start and end time
    'this is called when a event is dragged or resized in the calendar
    <System.Web.Services.WebMethod(True)> _
    Public Shared Function UpdateEventTime(improperEvent As ImproperCalendarEvent) As String
        Dim idList As List(Of Integer) = DirectCast(System.Web.HttpContext.Current.Session("idList"), List(Of Integer))
        If idList IsNot Nothing AndAlso idList.Contains(improperEvent.Activity_Id) Then
            EventDAO.updateEventTime(improperEvent.Activity_Id, DateTime.ParseExact(improperEvent.start, "dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture), DateTime.ParseExact(improperEvent.[end], "dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture))

            Return "updated event with id:" & improperEvent.Activity_Id & "update start to: " + improperEvent.start + " update end to: " + improperEvent.[end]
        End If

        Return "unable to update event with id: " + improperEvent.Activity_Id.ToString
    End Function

    'called when delete button is pressed
    <System.Web.Services.WebMethod(True)> _
    Public Shared Function deleteEvent(id As Integer) As [String]
        'idList is stored in Session by JsonResponse.ashx for security reasons
        'whenever any event is update or deleted, the event id is checked
        'whether it is present in the idList, if it is not present in the idList
        'then it may be a malicious user trying to delete someone elses events
        'thus this checking prevents misuse
        Dim idList As List(Of Integer) = DirectCast(System.Web.HttpContext.Current.Session("idList"), List(Of Integer))
        If idList IsNot Nothing AndAlso idList.Contains(id) Then
            EventDAO.deleteEvent(id)
            Return "deleted event with id:" & id
        End If

        Return "unable to delete event with id: " & id

    End Function

    'called when Add button is clicked
    'this is called when a mouse is clicked on open space of any day or dragged 
    'over mutliple days
    <System.Web.Services.WebMethod> _
    Public Shared Function addEvent(improperEvent As ImproperCalendarEvent) As Integer


        Dim cevent As New CalendarEvent() With { _
            .Activity_Subject = improperEvent.Activity_Subject, _
            .Activity_Description = improperEvent.Activity_Description, _
            .start = DateTime.ParseExact(improperEvent.start, "dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture), _
            .[end] = DateTime.ParseExact(improperEvent.[end], "dd-MM-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture) _
        }

        If CheckAlphaNumeric(cevent.Activity_Subject) AndAlso CheckAlphaNumeric(cevent.Activity_Description) Then
            Dim key As Integer = EventDAO.addEvent(cevent)

            Dim idList As List(Of Integer) = DirectCast(System.Web.HttpContext.Current.Session("idList"), List(Of Integer))

            If idList IsNot Nothing Then
                idList.Add(key)
            End If

            'return the primary key of the added cevent object
            Return key
        End If

        Return -1
        'return a negative number just to signify nothing has been added
    End Function

    Private Shared Function CheckAlphaNumeric(str As String) As Boolean

        Return Regex.IsMatch(str, "^[a-zA-Z0-9 ]*$")
    End Function

End Class
