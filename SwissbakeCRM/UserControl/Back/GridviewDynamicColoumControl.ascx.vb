
Partial Class UserControl_Back_GridviewDynamicColoumControl
    Inherits System.Web.UI.UserControl
    Dim GridID As Integer
    Public _sortDirection As String
    Public sortImage As New Image()
    Dim strColoumNames As New List(Of String)
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

    Protected Sub SetSortDirection(sortDirection As String)
        If sortDirection = "ASC" Then
            _sortDirection = "DESC"
            sortImage.ImageUrl = Page.ResolveUrl("img/view_sort_ascending.png")
        Else
            _sortDirection = "ASC"
            sortImage.ImageUrl = Page.ResolveUrl("img/view_sort_descending.png")
        End If
    End Sub

#Region "Property"

    Public Property UtxtSearch() As TextBox
        Get
            Return Me.txtsearch
        End Get
        Set(value As TextBox)
            Me.txtsearch = value
        End Set
    End Property

    Public Property Uhfadd() As HyperLink
        Get
            Return Me.hfadd
        End Get
        Set(value As HyperLink)
            Me.hfadd = value
        End Set
    End Property

    Public Property Uddpagesize() As DropDownList
        Get
            Return Me.ddpagesize
        End Get
        Set(value As DropDownList)
            Me.ddpagesize = value
        End Set
    End Property

    Public Property Uhfsearchmode() As HiddenField
        Get
            Return Me.hfsearchmode
        End Get
        Set(value As HiddenField)
            Me.hfsearchmode = value
        End Set
    End Property

    Public Property Uhfdefaultcoloum() As HiddenField
        Get
            Return Me.hfdefaultcoloum
        End Get
        Set(value As HiddenField)
            Me.hfdefaultcoloum = value
        End Set
    End Property

    Public Property Uhfgridviewmode() As HiddenField
        Get
            Return Me.hfgridviewmode
        End Get
        Set(value As HiddenField)
            Me.hfgridviewmode = value
        End Set
    End Property

    Public Property Uhficon() As HiddenField
        Get
            Return Me.hficon
        End Get
        Set(value As HiddenField)
            Me.hficon = value
        End Set
    End Property

    Public Property Uhfcoloumname() As HiddenField
        Get
            Return Me.hfcoloumname
        End Get
        Set(value As HiddenField)
            Me.hfcoloumname = value
        End Set
    End Property

    Public Property Uhfdelcoloum() As HiddenField
        Get
            Return Me.hfdelcoloum
        End Get
        Set(value As HiddenField)
            Me.hfdelcoloum = value
        End Set
    End Property

    Public Property Uhftotalcount() As HiddenField
        Get
            Return Me.hftotalcount
        End Get
        Set(value As HiddenField)
            Me.hftotalcount = value
        End Set
    End Property

    Public Property Uhfdeletsi() As HiddenField
        Get
            Return Me.hfdeletsi
        End Get
        Set(value As HiddenField)
            Me.hfdeletsi = value
        End Set
    End Property

    Public Property UhfStatus() As HiddenField
        Get
            Return Me.hfstatus
        End Get
        Set(value As HiddenField)
            Me.hfstatus = value
        End Set
    End Property

    Public Property Uhpagename() As HiddenField
        Get
            Return Me.hfpagename
        End Get
        Set(value As HiddenField)
            Me.hfpagename = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                FillGridview()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillGridview()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalcount.Value)
            GridView1.DataSource = MainBLL.DynamicColoumPaging(hfdefaultcoloum.Value, 0, 10, hfcoloumname.Value, hfdelcoloum.Value, hfpagename.Value, 1)
            GridView1.DataBind()
            GridView1.Columns(1).Visible = False
            dtcoloumname.DataSource = MainBLL.ColoumName(hfpagename.Value)
            dtcoloumname.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "FillGridview", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


    Protected Sub dtcoloumname_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles dtcoloumname.ItemDataBound
        Try
            If e.Item.ItemType = DataControlRowType.DataRow Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim ckselect As CheckBox = DirectCast(e.Item.FindControl("ckselect"), CheckBox)
                If (ckselect.Text.Contains("CreatedDate") Or ckselect.Text.Contains("CreatedId") Or ckselect.Text.Contains("ModifiedDate") Or
                    ckselect.Text.Contains("ModifiedId") Or ckselect.Text.Contains("DelDate") Or ckselect.Text.Contains("Del")) Then
                    e.Item.Enabled = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "dtcoloumname_ItemDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsavecoloum_Click(sender As Object, e As EventArgs) Handles btnsavecoloum.Click
        Try
            For i As Integer = 0 To dtcoloumname.Items.Count - 1
                Dim ckselect As CheckBox = CType(dtcoloumname.Items(i).FindControl("ckselect"), CheckBox)
                If ckselect.Checked = True Then
                    Dim temp As String = ckselect.Text
                    Dim str As String() = temp.Split("_")
                    Dim temp1 As String = ckselect.Text + " As " + str(1).ToString
                    strColoumNames.Add(temp1)
                End If
            Next
            Dim sb As String = String.Join(",", strColoumNames)
            Dim exist As String = ColoumSettingBLL.CheckSettingExist(2, hfpagename.Value)
            If exist = "exist" Then
                ColoumSettingBLL.Update(1, hfpagename.Value, sb.ToString, hfdelcoloum.Value, hfcoloumname.Value, 1, 1, "")
            Else
                ColoumSettingBLL.Insert(1, hfpagename.Value, sb.ToString, hfdelcoloum.Value, hfcoloumname.Value, 1, 1, "")
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "btnsavecoloum_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowCreated(sender As Object, e As GridViewRowEventArgs)
        Try
            Dim row As GridViewRow = e.Row
            Dim columns As New List(Of TableCell)()
            For Each column As DataControlField In GridView1.Columns
                Dim cell As TableCell = row.Cells(0)
                row.Cells.Remove(cell)
                columns.Add(cell)
            Next
            row.Cells.AddRange(columns.ToArray())
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "GridView1_RowCreated", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
    '    If e.CommandName = "deletelink" Then
    '        If deletestatus.Value = "yes" Then
    '            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '            GridID = GridView1.DataKeys(index).Value
    '            Try
    '                MainBLL.DeleteSI(GridID, Session("UserId"), hfdeletsi.Value, Session("Audlog_Id"))
    '                IndexfillUser(ddpagesize.SelectedValue)
    '            Catch ex As Exception
    '                Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '                error1 = error1.Replace(Chr(39), "")
    '                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '            End Try
    '        Else
    '            If txtsearch.Text.Trim = "" Then
    '                IndexfillUser(ddpagesize.SelectedValue)
    '            Else
    '                'FillSearch()
    '            End If
    '        End If

    '    ElseIf e.CommandName = "statuslink" Then
    '        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
    '        GridID = GridView1.DataKeys(index).Value
    '        Try
    '            MainBLL.UpdateStatus(GridID, Session("UserId"), hfstatus.Value, Session("Audlog_Id"))
    '            If txtsearch.Text.Trim = "" Then
    '                IndexfillUser(ddpagesize.SelectedValue)
    '            Else
    '                'FillSearch()
    '            End If
    '        Catch ex As Exception
    '            Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '            error1 = error1.Replace(Chr(39), "")
    '            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '        End Try
    '    End If
    'End Sub

    Public Sub IndexfillUser(ByVal ddpagesize As Integer)
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalcount.Value)
            GridView1.DataSource = MainBLL.DynamicColoumPaging(hfdefaultcoloum.Value, 0, 10, hfcoloumname.Value, hfdelcoloum.Value, hfpagename.Value, 1)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("GridViewDynamicControl", "IndexfillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

  
End Class
