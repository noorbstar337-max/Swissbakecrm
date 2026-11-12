
Partial Class UserControl_Back_AssignToControl
    Inherits System.Web.UI.UserControl
    Dim HashAssignTo As Hashtable = New Hashtable
    Dim Count As Integer
    Dim DID As Integer
    Dim MainID As Integer
#Region "User Control Property"
    Public Property Uhftype() As HiddenField
        Get
            Return Me.hftype
        End Get
        Set(value As HiddenField)
            Me.hftype = value
        End Set
    End Property
    Public Property Uhftypeid() As HiddenField
        Get
            Return Me.hftypeid
        End Get
        Set(value As HiddenField)
            Me.hftypeid = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                fillUser()
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                If MainID = 0 Then
                    Session("dassigntohash") = Nothing
                    Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
                    If Assnid IsNot Nothing Then
                        HashAssignTo = Session("dassigntohash")
                        For i As Integer = 0 To GridView1.Rows.Count - 1
                            Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                            Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                            Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                            If ckselect.Checked = True Then
                                If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                Else
                                    HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                End If
                            End If
                        Next
                        Session("dassigntohash") = HashAssignTo
                    Else
                        For i As Integer = 0 To GridView1.Rows.Count - 1
                            Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                            Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                            Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                            If ckselect.Checked = True Then
                                If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                Else
                                    HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                End If
                            End If
                        Next
                        Session("dassigntohash") = HashAssignTo
                    End If
                    rpassignto.DataSource = HashAssignTo
                    rpassignto.DataBind()
                Else
                    FillAssignTo()
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        FillSearch()
                    Else
                        fillUser()
                    End If
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            GridView1.DataSource = UserBLL.FillAssignUser(Session("UserId"))
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = UserBLL.SearchUserByAssign(Session("UserId"), txtsearch.Text.Trim)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If txtsearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, "5", "UserGridview")
                GridView1.DataBind()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            Else
                GridView1.PageIndex = e.NewPageIndex
                FillSearch()
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            fillUser()
            txtsearch.Text = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "btnshowall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If Assnid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    If ckselect.Checked = True Then
                        If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                    End If
                Next
                Session("dassigntohash") = HashAssignTo
            Else
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    If ckselect.Checked = True Then
                        If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                    End If
                Next
                Session("dassigntohash") = HashAssignTo
            End If
            rpassignto.DataSource = HashAssignTo
            rpassignto.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "btnsave Add", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub

    Protected Sub rpassignto_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rpassignto.ItemCommand
        If e.CommandName = "deleteassign" Then
            Try
                Dim index As Integer = Convert.ToInt32(e.Item.ItemIndex)
                Dim ltid As Literal = DirectCast(e.Item.FindControl("ltid"), Literal)
                Dim ids As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
                If ids IsNot Nothing Then
                    HashAssignTo = Session("dassigntohash")
                    If ltid.Text = Session("UserId") Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("Cannot delete default assign").ToString + "')", True)
                    Else
                        HashAssignTo.Remove(ltid.Text)
                        Session("dassigntohash") = HashAssignTo
                    End If
                Else
                    If ltid.Text = Session("UserId") Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("Cannot delete default assign").ToString + "')", True)
                    Else
                        HashAssignTo.Remove(ltid.Text)
                        Session("dassigntohash") = HashAssignTo
                    End If
                End If
                rpassignto.DataSource = HashAssignTo
                rpassignto.DataBind()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("AssignToUserControl", "rpassignto_ItemCommand Add", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

    'Public Sub AddAssignTo(ByVal DID As Integer)
    '    Try
    '        If DID > 0 Then
    '            AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
    '        End If
    '        Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
    '        If HCatid IsNot Nothing Then
    '            HashAssignTo = Session("dassigntohash")
    '        Else
    '        End If
    '        Count = AssignToBLL.MaxAssignTo
    '        Dim sb As New StringBuilder
    '        sb.Append("<root>")
    '        For i As Integer = 0 To GridView1.Rows.Count - 1
    '            Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
    '            Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
    '            Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
    '            If ckselect.Checked = True Then
    '                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & lbluId.Text &
    '                      "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("UserId") &
    '                      "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
    '                       "' Assignto_Del='0' Assignto_Status='Active' />")
    '                Count = Count + 1
    '            End If
    '        Next

    '        'For i As Integer = 0 To HashAssignTo.Count - 1
    '        '    sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
    '        '             "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("UserId") &
    '        '             "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
    '        '              "' Assignto_Del='0' Assignto_Status='Active' />")
    '        '    Count = Count + 1
    '        'Next

    '        sb.Append("</root>")
    '        AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '        ExecptionBLL.Insert("AssignToUserControl", "AddAssignTo", error1, Session("UserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    Public Sub AddAssignTo(ByVal DID As Integer)
        Try
            If DID > 0 Then
                AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("UserId"), Session("UserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("UserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
            Session("dassigntohash") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddAssignTo", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillAssignTo()
        Try
            If Not String.IsNullOrEmpty(hftypeid.Value) Then
                If hftypeid.Value > 0 Then
                    Dim dttemp As DataSet = AssignToBLL.FillAssignTo(hftype.Value, hftypeid.Value)
                    For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                        If Not HashAssignTo.Contains(dttemp.Tables(0).Rows(j)("Assignto_UserID").ToString()) Then
                            HashAssignTo.Add(dttemp.Tables(0).Rows(j)("Assignto_UserID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
                        End If
                    Next
                    Session("dassigntohash") = HashAssignTo
                    rpassignto.DataSource = HashAssignTo
                    rpassignto.DataBind()
                Else
                    rpassignto.DataSource = ""
                    rpassignto.DataBind()
                    Session("dassigntohash") = Nothing
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "FillAssignTo", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim row As GridViewRow = e.Row
                Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                Dim ckselect As CheckBox = DirectCast(e.Row.FindControl("ckselect"), CheckBox)
                Dim UserID As Integer = GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString()
                If UserID = Session("UserId") Then
                    ckselect.Checked = True
                Else
                    ckselect.Checked = False
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "GridView1_RowDataBound", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Function Setdata() As Object
        Dim data As Object() = New Object(1) {}

        Return data

    End Function

End Class
