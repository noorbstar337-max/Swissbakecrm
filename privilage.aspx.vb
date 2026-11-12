
Partial Class privilage
    Inherits System.Web.UI.Page
    Dim chselectall As New CheckBox
    Dim chselect As New CheckBox
    Dim chadd As New CheckBox
    Dim chupdate As New CheckBox
    Dim chview As New CheckBox
    Dim chdelete As New CheckBox
    Dim SelectActive As Boolean
    Dim Count As Integer = 0
    Dim add As Boolean
    Dim update As Boolean
    Dim view As Boolean
    Dim delete As Boolean
    Dim MenuID As Integer

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            If Not Session("UserId") = "1" Then
                Response.Redirect("index.aspx")
            End If
        Else
            If Not Session("UserId") = "1" Then
                Response.Redirect("index.aspx")
            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            fillLevel()
            cbviewAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbviewAll.ClientID + "',2)")
            cbAddAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbAddAll.ClientID + "',3)")
            cbEditAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbEditAll.ClientID + "',4)")
            cbDeleteAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbDeleteAll.ClientID + "',5)")
        End If
        'cbSelectAllTop.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbSelectAllTop.ClientID + "',2)")
        'cbviewAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbviewAll.ClientID + "',3)")
        'cbAddAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbAddAll.ClientID + "',4)")
        'cbEditAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbEditAll.ClientID + "',5)")
        'cbDeleteAll.Attributes.Add("onclick", "javascript:SelectAllCol('" + cbDeleteAll.ClientID + "',6)")
    End Sub

    Public Sub fillLevel()
        Try
            ddlevel.DataSource = MainBLL.Dropdown("LevelDropDown")
            ddlevel.DataTextField = "Level_LevelName"
            ddlevel.DataValueField = "Level_Id"
            ddlevel.DataBind()
            ddlevel.Items.Insert(0, " --- Select Level --- ")
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub ddlevel_TextChanged(sender As Object, e As EventArgs) Handles ddlevel.TextChanged
        Try
            If (ddlevel.SelectedIndex <> 0) Then
                divHeader.Visible = True
                GridView1.DataSource = PrivilageBLL.FillPrivilage(ddlevel.SelectedValue)
                GridView1.DataBind()
            Else
                divHeader.Visible = False
                GridView1.DataSource = ""
                GridView1.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub Selectall(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = DirectCast(DirectCast(sender, CheckBox).NamingContainer, GridViewRow)
            Dim dataKey = GridView1.DataKeys(row.RowIndex)
            chselectall = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbselectall"), CheckBox)
            chselect = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbselect"), CheckBox)
            chadd = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbadd"), CheckBox)
            chupdate = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbedit"), CheckBox)
            chview = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbview"), CheckBox)
            chdelete = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbdelete"), CheckBox)
            If chselectall.Checked = True Then
                chadd.Checked = True
                chdelete.Checked = True
                chupdate.Checked = True
                chview.Checked = True
                'chselect.Checked = True
                chadd.Enabled = True
                chdelete.Enabled = True
                chupdate.Enabled = True
                chview.Enabled = True
                chselect.Enabled = True
            ElseIf chselectall.Checked = False Then
                chadd.Checked = False
                chdelete.Checked = False
                chupdate.Checked = False
                chview.Checked = False
                'chselect.Checked = False
                'chadd.Enabled = False
                'chdelete.Enabled = False
                'chupdate.Enabled = False
                'chview.Enabled = False
                chselect.Enabled = True
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub checkview(sender As Object, e As EventArgs)
        Try
            Dim row As GridViewRow = DirectCast(DirectCast(sender, CheckBox).NamingContainer, GridViewRow)
            chselectall = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbselectall"), CheckBox)
            chselect = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbselect"), CheckBox)
            chadd = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbadd"), CheckBox)
            chupdate = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbedit"), CheckBox)
            chview = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbview"), CheckBox)
            chdelete = DirectCast(GridView1.Rows(row.RowIndex).FindControl("cbdelete"), CheckBox)
            If chselect.Checked = True Then
                'chadd.Enabled = True
                'chdelete.Enabled = True
                'chupdate.Enabled = True
                'chview.Enabled = True
            Else
                'chadd.Enabled = False
                'chdelete.Enabled = False
                'chupdate.Enabled = False
                'chview.Enabled = False
                'chadd.Checked = False
                'chdelete.Checked = False
                'chupdate.Checked = False
                'chview.Checked = False
                'chselectall.Checked = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub AddPrivilage()
        Try
            PrivilageBLL.DeletePrivilige(ddlevel.SelectedValue)
            Count = MainBLL.TotalRowInGridview("PrivilageMaxRow")
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To GridView1.Rows.Count - 1
                chselect = DirectCast(GridView1.Rows(i).FindControl("cbselect"), CheckBox)
                'If chselect.Checked = True Then
                chadd = DirectCast(GridView1.Rows(i).FindControl("cbadd"), CheckBox)
                chupdate = DirectCast(GridView1.Rows(i).FindControl("cbedit"), CheckBox)
                chview = DirectCast(GridView1.Rows(i).FindControl("cbview"), CheckBox)
                chdelete = DirectCast(GridView1.Rows(i).FindControl("cbdelete"), CheckBox)
                Dim index As Integer = Convert.ToInt32(GridView1.Rows(i).RowIndex)
                MenuID = GridView1.DataKeys(index).Value
                If (chdelete.Checked = True) Then
                    delete = True
                Else
                    delete = False
                End If
                If (chview.Checked = True) Then
                    view = True
                Else
                    view = False
                End If
                If (chadd.Checked = True) Then
                    add = True
                Else
                    add = False
                End If
                If (chupdate.Checked = True) Then
                    update = True
                Else
                    update = False
                End If
                SelectActive = True
                sb.Append("<row Prvg_Id='" & Count.ToString & "' Prvg_MenuId='" & MenuID & "' Prvg_LevelId='" & ddlevel.SelectedValue &
                    "' Prvg_RAdd='" & add & "' Prvg_RUpdate='" & update & "' Prvg_RDelete='" & delete & "' Prvg_Rview='" & view &
                     "' Prvg_CreatedDate='" & DateAndTime.DateString & "' Prvg_CreatedId='" & Session("UserId") & "' Prvg_SelectActive='" & SelectActive &
                     "' Prvg_ModifiedDate='" & DateAndTime.DateString & "' Prvg_ModifiedId='" & Session("UserId") &
                     "' Prvg_Del='0' Prvg_Status='Active' />")
                Count = Count + 1
                'End If
            Next
            sb.Append("</root>")
            PrivilageBLL.InsertPrivilage(sb.ToString)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        AddPrivilage()
        ddlevel_TextChanged(Nothing, Nothing)
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbl As Label = DirectCast(e.Row.FindControl("lblcatname"), Label)
            chselectall = DirectCast(e.Row.FindControl("cbselectall"), CheckBox)
            chselect = DirectCast(e.Row.FindControl("cbselect"), CheckBox)
            chadd = DirectCast(e.Row.FindControl("cbadd"), CheckBox)
            chupdate = DirectCast(e.Row.FindControl("cbedit"), CheckBox)
            chview = DirectCast(e.Row.FindControl("cbview"), CheckBox)
            chdelete = DirectCast(e.Row.FindControl("cbdelete"), CheckBox)
            If chselect.Checked = True Then
                chadd.Enabled = True
                chdelete.Enabled = True
                chupdate.Enabled = True
                chview.Enabled = True
            End If
        End If
    End Sub
End Class
