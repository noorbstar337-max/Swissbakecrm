Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class ImproperCalendarEvent
    Public Property Activity_Id() As Integer
        Get
            Return m_Activity_Id
        End Get
        Set(value As Integer)
            m_Activity_Id = value
        End Set
    End Property
    Private m_Activity_Id As Integer
    Public Property Status() As String
        Get
            Return m_Status
        End Get
        Set(value As String)
            m_Status = value
        End Set
    End Property
    Private m_Status As String
    Public Property Activity_RelatedTypeID() As String
        Get
            Return m_Activity_RelatedTypeID
        End Get
        Set(value As String)
            m_Activity_RelatedTypeID = value
        End Set
    End Property
    Private m_Activity_RelatedTypeID As String
    Public Property Activity_Subject() As String
        Get
            Return m_Activity_Subject
        End Get
        Set(value As String)
            m_Activity_Subject = value
        End Set
    End Property
    Private m_Activity_Subject As String
    Public Property Activity_Owner() As Integer
        Get
            Return m_Activity_Owner
        End Get
        Set(value As Integer)
            m_Activity_Owner = value
        End Set
    End Property
    Private m_Activity_Owner As Integer
    Public Property Activity_Description() As String
        Get
            Return m_Activity_Description
        End Get
        Set(value As String)
            m_Activity_Description = value
        End Set
    End Property
    Private m_Activity_Description As String
    Public Property start() As String
        Get
            Return m_start
        End Get
        Set(value As String)
            m_start = Value
        End Set
    End Property
    Private m_start As String
    Public Property [end]() As String
        Get
            Return m_end
        End Get
        Set(value As String)
            m_end = Value
        End Set
    End Property
    Private m_end As String
End Class
