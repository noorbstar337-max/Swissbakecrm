'========================================================================
'Kartris - www.kartris.com
'Copyright 2014 CACTUSOFT INTERNATIONAL FZ LLC

'GNU GENERAL PUBLIC LICENSE v2
'This program is free software distributed under the GPL without any
'warranty.
'www.gnu.org/licenses/gpl-2.0.html

'KARTRIS COMMERCIAL LICENSE
'If a valid license.config issued by Cactusoft is present, the KCL
'overrides the GPL v2.
'www.kartris.com/t-Kartris-Commercial-License.aspx
'========================================================================

Imports System.Web.UI

Public MustInherit Class _PageBaseClass

    Inherits System.Web.UI.Page
    Public _sortDirection As String
    Public _FIllMode As String
    Public _SearchMode As String
    Public sortImage As New Image()
    Public Property SortDireaction() As String
        Get
            If ViewState("SortDireaction") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("SortDireaction").ToString()
            End If
        End Get
        Set(value As String)
            ViewState("SortDireaction") = value
        End Set
    End Property
    'Public Property FillMode() As String
    '    Get
    '        Return Me._FIllMode
    '    End Get
    '    Set(value As String)
    '        Me._FIllMode = value
    '    End Set
    'End Property
    'Public Property SearchMode() As String
    '    Get
    '        Return Me._SearchMode
    '    End Get
    '    Set(value As String)
    '        Me._SearchMode = value
    '    End Set
    'End Property
    Protected Sub SetSortDirection(sortDirection As String)
        If sortDirection = "ASC" Then
            _sortDirection = "DESC"
            sortImage.ImageUrl = "img/view_sort_ascending.png"
        Else
            _sortDirection = "ASC"
            sortImage.ImageUrl = "img/view_sort_descending.png"
        End If
    End Sub

    Public Overloads Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        ' Verifies that the control is rendered 
    End Sub

    'Public Property txtsearch() As TextBox
    '    Get
    '        Return Me._txtsearch
    '    End Get
    '    Set(value As TextBox)
    '        Me._txtsearch = value
    '    End Set
    'End Property
    'Public Property UpdatePanel1() As UpdatePanel
    '    Get
    '        Return Me._UpdatePanel1
    '    End Get
    '    Set(value As UpdatePanel)
    '        Me._UpdatePanel1 = value
    '    End Set
    'End Property

    'Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
    '    End If
    'End Sub

 
End Class
