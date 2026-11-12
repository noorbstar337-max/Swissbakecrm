
Partial Class UserControl_Back_LMSAssignToControl
    Inherits System.Web.UI.UserControl

    Dim HashAssignTo As Hashtable = New Hashtable
    Dim HashAssignToForm As Hashtable = New Hashtable
    Dim HashAssignToNew As Hashtable = New Hashtable
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
    Public Property UhfTypeCode() As HiddenField
        Get
            Return Me.hfTypeCode
        End Get
        Set(value As HiddenField)
            Me.hfTypeCode = value
        End Set
    End Property
    Public Property UhfFormulationCode() As HiddenField
        Get
            Return Me.hfFormulationCode
        End Get
        Set(value As HiddenField)
            Me.hfFormulationCode = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
                'fillUser()
                'If hftype.Value = "Recipe" Then
                '    MainID = hftypeid.Value
                'Else
                MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
                'End If
                'MainID = Request.QueryString("Id")
                'Dim dtN1 As New DataTable
                'dtN1.Columns.Add("U_ID", GetType(String))
                'dtN1.Columns.Add("U_FirstName", GetType(String))
                'dtN1.Columns.Add("SMSStatus", GetType(String))
                If MainID = 0 Then
                    Session("dassigntohash") = Nothing
                    Session("CompareAssignto") = Nothing
                    Session("FirstAssignto") = Nothing
                    fillUser()
                    Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
                    Dim RName As String = ""
                    Dim FName As String = ""
                    Dim RVal As String = ""
                    Dim FVal As String = ""
                    If hftype.Value = "Both" Then
                        Dim dtN1 As New DataTable
                        dtN1.Columns.Add("U_ID", GetType(String))
                        dtN1.Columns.Add("U_FirstName", GetType(String))
                        dtN1.Columns.Add("F1", GetType(String))
                        dtN1.Columns.Add("SMSStatus", GetType(String))
                        dtN1.Columns.Add("SMSStatusForm", GetType(String))
                        If Assnid IsNot Nothing Then
                            HashAssignTo = Session("dassigntohash")
                            For i As Integer = 0 To GridView1.Rows.Count - 1
                                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                                Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                                Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                                If ckRecipe.Checked = True Then
                                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                    Else
                                        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                    End If
                                    'dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, "", True, "")
                                    RName = lblname1.Text.Trim
                                    RVal = True
                                Else
                                    HashAssignTo.Remove(lbluId.Text.Trim)
                                End If
                                If ckFormulation.Checked = True Then
                                    If HashAssignToForm.ContainsKey(lbluId.Text.Trim) Then
                                    Else
                                        HashAssignToForm.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                    End If
                                    'dtN1.Rows.Add(lbluId.Text.Trim, "", lblname1.Text.Trim, "", True)
                                    FName = lblname1.Text.Trim
                                    FVal = True
                                Else
                                    HashAssignToForm.Remove(lbluId.Text.Trim)
                                End If
                                If ckRecipe.Checked = True Or ckFormulation.Checked = True Then
                                    dtN1.Rows.Add(lbluId.Text.Trim, RName, FName, RVal, FVal)
                                Else
                                    'HashAssignTo.Remove(lbluId.Text.Trim)
                                    'HashAssignToForm.Remove(lbluId.Text.Trim)
                                End If
                            Next
                            Session("CompareAssignto") = dtN1
                            Session("dassigntohash") = HashAssignTo
                        Else
                            For i As Integer = 0 To GridView1.Rows.Count - 1
                                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                                Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                                Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                                If ckselect.Checked = True Then
                                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                    Else
                                        If Session("LMSUserId") <> "1" Then
                                            HashAssignTo.Add("1", "Admin")
                                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                        Else
                                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                        End If
                                        dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, lblname1.Text.Trim, True, True)

                                    End If
                                End If
                            Next
                            Session("CompareAssignto") = dtN1
                            Session("dassigntohash") = HashAssignTo
                        End If
                    Else
                        Dim dtN1 As New DataTable
                        dtN1.Columns.Add("U_ID", GetType(String))
                        dtN1.Columns.Add("U_FirstName", GetType(String))
                        dtN1.Columns.Add("SMSStatus", GetType(String))
                        If Assnid IsNot Nothing Then
                            HashAssignTo = Session("dassigntohash")
                            For i As Integer = 0 To GridView1.Rows.Count - 1
                                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                                If ckselect.Checked = True Then
                                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                    Else
                                        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                    End If
                                    dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                                End If
                            Next
                            Session("CompareAssignto") = dtN1
                            Session("dassigntohash") = HashAssignTo
                        Else
                            For i As Integer = 0 To GridView1.Rows.Count - 1
                                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                                If ckselect.Checked = True Then
                                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                                    Else
                                        If Session("LMSUserId") <> "1" Then
                                            HashAssignTo.Add("1", "Admin")
                                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                            dtN1.Rows.Add("1", "Admin", True)
                                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                                        Else
                                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                                        End If

                                    End If
                                End If
                            Next
                            Session("CompareAssignto") = dtN1
                            Session("dassigntohash") = HashAssignTo
                        End If
                    End If
                    rpassignto.DataSource = HashAssignTo
                    rpassignto.DataBind()
                Else
                    'Session("dassigntohash") = Nothing
                    'Session("CompareAssignto") = Nothing
                    FillAssignTo()
                    fillUser()
                End If
            Else
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                'fillUser()
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        FillSearch()
                    Else
                        fillUser()
                    End If
                End If
            End If
            Dim don As DataTable = Session("FirstAssignto")
            Dim a As Integer = 1
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "Page_Load", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillUser()
        Try
            'Dim ds As DataSet = UserBLL.FillLMSAssignUser(Session("LMSUserId"))

            'Dim dt As DataTable = ds.Tables(0)
            ' Session("CompareAssignto") = dt
            GridView1.DataSource = UserBLL.FillLMSAssignUser(Session("LMSUserId"))
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "fillUser", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = UserBLL.SearchLMSUserByAssign(Session("LMSUserId"), txtsearch.Text.Trim)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "FillSearch", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    '**********//////
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If txtsearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                ' GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, "5", "UserGridview")
                '/* here no new mode is created, this needs testing */
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, "5", "LMSUserGridview")
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
            ExecptionBLL.Insert("AssignToUserControl", "GridView1_PageIndexChanging", error1, Session("LMSUserId"))
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
            ExecptionBLL.Insert("AssignToUserControl", "btnshowall_Click", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            If hftype.Value = "Both" Then
                SaveBtnBoth()
            Else
                SaveBtnFormRecTrial()
                ' ''    SaveBtnFormulation()
                ' ''Else

                ' ''    Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
                ' ''    Dim dtN As DataTable

                ' ''    Dim dtN1 As New DataTable
                ' ''    dtN1.Columns.Add("U_ID", GetType(String))
                ' ''    dtN1.Columns.Add("U_FirstName", GetType(String))
                ' ''    dtN1.Columns.Add("SMSStatus", GetType(String))
                ' ''    If Assnid IsNot Nothing Then
                ' ''        HashAssignTo = Session("dassigntohash")
                ' ''        For i As Integer = 0 To GridView1.Rows.Count - 1
                ' ''            Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                ' ''            Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                ' ''            Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                ' ''            Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                ' ''            If ckselect.Checked = True Then
                ' ''                If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                ' ''                Else
                ' ''                    HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                ' ''                End If
                ' ''                dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                ' ''            End If
                ' ''        Next
                ' ''        dtN = dtN1
                ' ''        Session("CompareAssignto") = dtN
                ' ''        Session("dassigntohash") = HashAssignTo
                ' ''    Else
                ' ''        For i As Integer = 0 To GridView1.Rows.Count - 1
                ' ''            Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                ' ''            Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                ' ''            Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                ' ''            Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                ' ''            If ckselect.Checked = True Then
                ' ''                If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                ' ''                Else
                ' ''                    HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                ' ''                End If
                ' ''                dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                ' ''            End If
                ' ''        Next
                ' ''        dtN = dtN1
                ' ''        Session("CompareAssignto") = dtN
                ' ''        Session("dassigntohash") = HashAssignTo
                ' ''    End If
                ' ''    rpassignto.DataSource = HashAssignTo
                ' ''    rpassignto.DataBind()
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "btnsave Add", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try

    End Sub
    Public Sub SaveBtnBoth()
        Try
            Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            Dim dtN As DataTable

            Dim dtN1 As New DataTable
            dtN1.Columns.Add("U_ID", GetType(String))
            dtN1.Columns.Add("U_FirstName", GetType(String))
            dtN1.Columns.Add("F1", GetType(String))
            dtN1.Columns.Add("SMSStatus", GetType(String))
            dtN1.Columns.Add("SMSStatusForm", GetType(String))
            If Assnid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckTrial"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                    ''If ckselect.Checked = True Then
                    ''    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                    ''    Else
                    ''        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                    ''    End If
                    ''    dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                    ''End If
                    Dim RName As String = ""
                    Dim FName As String = ""
                    Dim RVal As String = ""
                    Dim FVal As String = ""
                    If ckRecipe.Checked = True Then
                        If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                        'dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, "", True, "")
                        RName = lblname1.Text.Trim
                        RVal = True
                    Else
                        HashAssignTo.Remove(lbluId.Text.Trim)
                    End If
                    If ckFormulation.Checked = True Then
                        If HashAssignToForm.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignToForm.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                        'dtN1.Rows.Add(lbluId.Text.Trim, "", lblname1.Text.Trim, "", True)
                        FName = lblname1.Text.Trim
                        FVal = True
                    Else
                        HashAssignToForm.Remove(lbluId.Text.Trim)
                    End If

                    '******************
                    If ckRecipe.Checked = True Then
                        If HashAssignToNew.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignToNew.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                       
                    Else
                        If ckFormulation.Checked = True Then
                            If HashAssignToNew.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignToNew.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                        Else
                            HashAssignToNew.Remove(lbluId.Text.Trim)
                        End If
                    End If
                    '******************

                    If ckRecipe.Checked = True Or ckFormulation.Checked = True Then
                        dtN1.Rows.Add(lbluId.Text.Trim, RName, FName, RVal, FVal)
                    Else
                        'HashAssignTo.Remove(lbluId.Text.Trim)
                        'HashAssignToForm.Remove(lbluId.Text.Trim)
                    End If
                Next
                dtN = dtN1
                Session("CompareAssignto") = dtN
                Session("dassigntohash") = HashAssignTo
                Session("dassigntohashForm") = HashAssignToForm
                Session("dassigntohashNew") = HashAssignToNew
            Else
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckTrial"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                    ''If ckselect.Checked = True Then
                    ''    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                    ''    Else
                    ''        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                    ''    End If
                    ''    dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                    ''End If
                    Dim RName As String = ""
                    Dim FName As String = ""
                    Dim RVal As String = ""
                    Dim FVal As String = ""
                    If ckRecipe.Checked = True Then
                        If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                        'dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, "", True, "")
                        RName = lblname1.Text.Trim
                        RVal = True
                    End If
                    If ckFormulation.Checked = True Then
                        If HashAssignToForm.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignToForm.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                        'dtN1.Rows.Add(lbluId.Text.Trim, "", lblname1.Text.Trim, "", True)
                        FName = lblname1.Text.Trim
                        FVal = True
                    End If

                    '******************
                    If ckRecipe.Checked = True Then
                        If HashAssignToNew.ContainsKey(lbluId.Text.Trim) Then
                        Else
                            HashAssignToNew.Add(lbluId.Text.Trim, lblname.Text.Trim)
                        End If
                    Else
                        If ckFormulation.Checked = False Then
                            If HashAssignToNew.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignToNew.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                        Else
                            HashAssignToNew.Remove(lbluId.Text.Trim)
                        End If
                    End If
                    '******************

                    If ckRecipe.Checked = True Or ckFormulation.Checked = True Then
                        dtN1.Rows.Add(lbluId.Text.Trim, RName, FName, RVal, FVal)
                    Else
                        HashAssignTo.Remove(lbluId.Text.Trim)
                    End If
                Next
                dtN = dtN1
                Session("CompareAssignto") = dtN
                Session("dassigntohash") = HashAssignTo
                Session("dassigntohashForm") = HashAssignToForm
                Session("dassigntohashNew") = HashAssignToNew
            End If
            rpassignto.DataSource = HashAssignToNew
            rpassignto.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SaveBtnFormRecTrial()
        Try
            Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            Dim dtN As DataTable

            Dim dtN1 As New DataTable
            dtN1.Columns.Add("U_ID", GetType(String))
            dtN1.Columns.Add("U_FirstName", GetType(String))
            dtN1.Columns.Add("SMSStatus", GetType(String))
            If Assnid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckTrial"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                    If hftype.Value = "Formulation" Then
                        If ckFormulation.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        Else
                            HashAssignTo.Remove(lbluId.Text.Trim)
                        End If
                    ElseIf hftype.Value = "Recipe" Then
                        If ckRecipe.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        Else
                            HashAssignTo.Remove(lbluId.Text.Trim)
                        End If
                    ElseIf hftype.Value = "Feedback" Then
                        If ckTrial.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        Else
                            HashAssignTo.Remove(lbluId.Text.Trim)
                        End If
                    End If
                Next
                dtN = dtN1
                Session("CompareAssignto") = dtN
                Session("dassigntohash") = HashAssignTo
            Else
                For i As Integer = 0 To GridView1.Rows.Count - 1
                    Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckTrial"), CheckBox)
                    Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
                    Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
                    Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
                    If hftype.Value = "Formulation" Then

                        If ckFormulation.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        End If
                    ElseIf hftype.Value = "Recipe" Then
                        If ckRecipe.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        End If
                    ElseIf hftype.Value = "Feedback" Then
                        If ckTrial.Checked = True Then
                            If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
                            Else
                                HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
                            End If
                            dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
                        End If
                    End If
                Next
                dtN = dtN1
                Session("CompareAssignto") = dtN
                Session("dassigntohash") = HashAssignTo
            End If
            rpassignto.DataSource = HashAssignTo
            rpassignto.DataBind()
        Catch ex As Exception

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
                    'Dim dtN1 As DataTable = Session("FirstAssignto")
                    Dim dtN1 As DataTable = Session("CompareAssignto")
                    'dtN1.Columns.Add("U_ID", GetType(String))
                    'dtN1.Columns.Add("U_FirstName", GetType(String))
                    'dtN1.Columns.Add("SMSStatus", GetType(String))
                    'If ltid.Text = Session("LMSUserId") Then
                    If ltid.Text = Session("LMSUserId") Or ltid.Text = 1 Then
                        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + ("Cannot delete default assign").ToString + "')", True)
                    Else
                        HashAssignTo.Remove(ltid.Text)
                        Session("dassigntohash") = HashAssignTo
                        Dim dr As DataRow = dtN1.Rows(index)
                        dtN1.Rows.Remove(dr)
                        Session("CompareAssignto") = dtN1
                    End If
                Else
                    If ltid.Text = Session("LMSUserId") Or ltid.Text = 1 Then
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
                ExecptionBLL.Insert("AssignToUserControl", "rpassignto_ItemCommand Add", error1, Session("LMSUserId"))
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
    '        HashAssignTo.Add(Session("LMSUserId"), Session("UserName"))
    '        End If
    '        Count = AssignToBLL.MaxAssignTo
    '        Dim sb As New StringBuilder
    '        sb.Append("<root>")
    '        For i As Integer = 0 To HashAssignTo.Count - 1
    '        sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
    '                 "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
    '                 "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
    '                  "' Assignto_Del='0' Assignto_Status='Active' />")
    '            Count = Count + 1
    '        Next
    '        sb.Append("</root>")
    '        AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)
    '        Session("dassigntohash") = Nothing
    '    Catch ex As Exception
    '        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    '        error1 = error1.Replace(Chr(39), "")
    '    ExecptionBLL.Insert("AssignToUserControl", "AddAssignTo", error1, Session("LMSUserId"))
    '        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    '    End Try
    'End Sub

    ' added by MUBYN used in LMS due to different Session Names

    Public Sub AddLMSAssignTo(ByVal DID As Integer)
        Try

            Dim tbl1 As New DataTable
            tbl1 = Session("FirstAssignto")
            Dim tbl2 As New DataTable
            tbl2 = Session("CompareAssignto")

            If tbl1 IsNot Nothing And tbl2 IsNot Nothing Then

                Dim RowCount As Integer
                If tbl1.Rows.Count < tbl2.Rows.Count Then
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl1.Rows(i)(1).ToString(), tbl2.Rows(j)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                Else
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl2.Rows(j)(0).ToString(), tbl1.Rows(i)(0).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                End If
            End If

            Session("CompareAssignto") = tbl2

            If DID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)

            If tbl2 IsNot Nothing Then
                Dim host As String = HttpContext.Current.Request.Url.Host
                Session("OrderEmailSubj") = "New " + hftype.Value + " has been assigned "
                For i = 0 To tbl2.Rows.Count - 1
                    If tbl2.Rows(i)(2) = True Then
                        ' '' ''SendUsingSMPP.SendSMS("New " + hftype.Value + " no. " + hfTypeCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        'SendUsingSMPP.SendSMS("New TRIAL! New trial no " + lblTrialNo.Text + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", "9773438089")
                        ' Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(0)) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                    End If
                Next
            End If

            Session("dassigntohash") = Nothing
            Session("CompareAssignto") = Nothing
            Session("FirstAssignto") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddLMSAssignTo", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub AddLMSAssignToWithoutSMS(ByVal DID As Integer)
        Try

            Dim tbl1 As New DataTable
            tbl1 = Session("FirstAssignto")
            Dim tbl2 As New DataTable
            tbl2 = Session("CompareAssignto")

            If tbl1 IsNot Nothing And tbl2 IsNot Nothing Then

                Dim RowCount As Integer
                If tbl1.Rows.Count < tbl2.Rows.Count Then
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl1.Rows(i)(1).ToString(), tbl2.Rows(j)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                Else
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl2.Rows(j)(0).ToString(), tbl1.Rows(i)(0).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                End If
            End If

            Session("CompareAssignto") = tbl2

            If DID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)

            If tbl2 IsNot Nothing Then
                Dim host As String = HttpContext.Current.Request.Url.Host
                Session("OrderEmailSubj") = "New " + hftype.Value + " has been assigned "
                For i = 0 To tbl2.Rows.Count - 1
                    If tbl2.Rows(i)(2) = True Then
                        ' '' ''SendUsingSMPP.SendSMS("New " + hftype.Value + " no. " + hfTypeCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        'SendUsingSMPP.SendSMS("New TRIAL! New trial no " + lblTrialNo.Text + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", "9773438089")
                        ' Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(0)) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
                    End If
                Next
            End If

            ''Session("dassigntohash") = Nothing
            ''Session("CompareAssignto") = Nothing
            ''Session("FirstAssignto") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddLMSAssignTo", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Public Sub AddLMSRecipeAssignToNoSMS(ByVal DID As Integer, ByVal FormID As Integer)
        Try
            hfFormulationID.Value = FormID
            'FillAssignTo()
            Dim tbl1 As New DataTable
            tbl1 = Session("FirstAssignto")
            Dim tbl2 As New DataTable
            tbl2 = Session("CompareAssignto")

            If tbl1 IsNot Nothing And tbl2 IsNot Nothing Then

                Dim RowCount As Integer
                If tbl1.Rows.Count < tbl2.Rows.Count Then
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl1.Rows(i)(1).ToString(), tbl2.Rows(j)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                Else
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl2.Rows(j)(0).ToString(), tbl1.Rows(i)(0).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                        Next
                    Next
                End If
            End If

            Session("CompareAssignto") = tbl2
            ''Recipe Assign Insert 
            If DID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)

            ''Formulation Assign Insert 
            FillAssignTo()
            If FormID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo("Formulation", FormID, Session("Audlog_Id"))
            End If
            Dim HCatidForm As Hashtable = If(Session("dassigntohashForm") IsNot Nothing, DirectCast(Session("dassigntohashForm"), Hashtable), Nothing)
            If HCatidForm IsNot Nothing Then
                HashAssignToForm = Session("dassigntohashForm")
            Else
                HashAssignToForm.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sbForm As New StringBuilder
            sbForm.Append("<root>")
            For i As Integer = 0 To HashAssignToForm.Count - 1
                sbForm.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignToForm.Keys(i) &
                         "' Assignto_Type='Formulation' Assignto_TypeID='" & FormID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sbForm.Append("</root>")
            AssignToBLL.XMLInsert(sbForm.ToString, Session("Audlog_Id"), hftype.Value)

            If tbl2 IsNot Nothing Then
                Dim host As String = HttpContext.Current.Request.Url.Host
                Session("OrderEmailSubj") = "New " + hftype.Value + " has been assigned "
                For i = 0 To tbl2.Rows.Count - 1
                    If tbl2.Rows(i)(3) <> "" Then
                        If tbl2.Rows(i)(3) = True Then
                            ' '' ''SendUsingSMPP.SendSMS("New " + hftype.Value + " no. " + hfTypeCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        End If
                    End If
                    If tbl2.Rows(i)(4) <> "" Then
                        If tbl2.Rows(i)(4) = True Then
                            SendUsingSMPP.SendSMS("New Formulation no. " + hfFormulationCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        End If
                    End If
                Next
            End If

            Session("dassigntohashForm") = Nothing
            Session("dassigntohash") = Nothing
            Session("CompareAssignto") = Nothing
            Session("FirstAssignto") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddLMSAssignTo", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub AddLMSBothAssignTo(ByVal DID As Integer, ByVal FormID As Integer)
        Try
            hfFormulationID.Value = FormID
            'FillAssignTo()
            Dim tbl1 As New DataTable
            tbl1 = Session("FirstAssignto")
            Dim tbl2 As New DataTable
            tbl2 = Session("CompareAssignto")

            If tbl1 IsNot Nothing And tbl2 IsNot Nothing Then

                Dim RowCount As Integer
                If tbl1.Rows.Count < tbl2.Rows.Count Then
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl1.Rows(i)(1).ToString(), tbl2.Rows(j)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                            If Equals(tbl1.Rows(i)(2).ToString(), tbl2.Rows(j)(2).ToString()) Then
                                tbl2.Rows(j)("SMSStatusForm") = False
                            End If
                        Next
                    Next
                ElseIf tbl1.Rows.Count > tbl2.Rows.Count Then
                    RowCount = tbl1.Rows.Count
                    For i As Integer = 0 To tbl2.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl1.Rows(j)(1).ToString(), tbl2.Rows(i)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                            If Equals(tbl1.Rows(j)(2).ToString(), tbl2.Rows(i)(2).ToString()) Then
                                tbl2.Rows(j)("SMSStatusForm") = False
                            End If
                        Next
                    Next
                Else
                    RowCount = tbl2.Rows.Count
                    For i As Integer = 0 To tbl1.Rows.Count - 1
                        For j As Integer = 0 To RowCount - 1
                            If Equals(tbl2.Rows(i)(1).ToString(), tbl1.Rows(j)(1).ToString()) Then
                                tbl2.Rows(j)("SMSStatus") = False
                            End If
                            If Equals(tbl2.Rows(i)(2).ToString(), tbl1.Rows(j)(2).ToString()) Then
                                tbl2.Rows(j)("SMSStatusForm") = False
                            End If
                        Next
                    Next
                End If
            End If

            Session("CompareAssignto") = tbl2
            ''Recipe Assign Insert 
            If DID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo("Recipe", DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
                HashAssignTo.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
                         "' Assignto_Type='Recipe' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)

            ''Formulation Assign Insert 
            'FillAssignTo()
            If FormID > 0 Then
                'No changes made here
                AssignToBLL.DeleteAssignTo("Formulation", FormID, Session("Audlog_Id"))
            End If
            Dim HCatidForm As Hashtable = If(Session("dassigntohashForm") IsNot Nothing, DirectCast(Session("dassigntohashForm"), Hashtable), Nothing)
            If HCatidForm IsNot Nothing Then
                HashAssignToForm = Session("dassigntohashForm")
            Else
                HashAssignToForm.Add(Session("LMSUserId"), Session("LMSUserName"))
            End If
            Count = AssignToBLL.MaxAssignTo
            Dim sbForm As New StringBuilder
            sbForm.Append("<root>")
            For i As Integer = 0 To HashAssignToForm.Count - 1
                sbForm.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignToForm.Keys(i) &
                         "' Assignto_Type='Formulation' Assignto_TypeID='" & FormID & "' Assignto_CreatedID='" & Session("LMSUserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                Count = Count + 1
            Next
            sbForm.Append("</root>")
            AssignToBLL.XMLInsert(sbForm.ToString, Session("Audlog_Id"), hftype.Value)

            If tbl2 IsNot Nothing Then
                Dim host As String = HttpContext.Current.Request.Url.Host
                Session("OrderEmailSubj") = "New " + hftype.Value + " has been assigned "
                For i = 0 To tbl2.Rows.Count - 1
                    If tbl2.Rows(i)(3) <> "" Then
                        If tbl2.Rows(i)(3) = True Then
                            ' '' ''SendUsingSMPP.SendSMS("New Recipe no. " + hfTypeCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        End If
                    End If
                    If tbl2.Rows(i)(4) <> "" Then
                        If tbl2.Rows(i)(4) = True Then
                            ' '' ''SendUsingSMPP.SendSMS("New Formulation no. " + hfFormulationCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
                        End If
                    End If
                Next
            End If

            Session("dassigntohashForm") = Nothing
            Session("dassigntohash") = Nothing
            Session("CompareAssignto") = Nothing
            Session("FirstAssignto") = Nothing
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "AddLMSAssignTo", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillAssignTo()
        Try
            If hftype.Value = "Both" Then

                If Not String.IsNullOrEmpty(hftypeid.Value) Then
                    If hftypeid.Value > 0 Then
                        Dim dttemp As DataSet = AssignToBLL.FillLMSAssignTo(hftype.Value, hftypeid.Value)
                        If dttemp.Tables(0).Rows.Count = 0 Then
                            dttemp = AssignToBLL.FillLMSRecFormAssignTo("Formulation", hfFormulationID.Value)
                        End If
                        Dim dttemp1 As DataSet = dttemp
                        dttemp1.Tables(0).Columns.Add("SMSStatus")
                        dttemp1.Tables(0).Columns.Add("SMSStatusForm")
                        For i = 0 To dttemp1.Tables(0).Rows.Count - 1
                            If dttemp1.Tables(0).Rows(i)("U_FirstName") <> "X" Then
                                dttemp1.Tables(0).Rows(i)("SMSStatus") = True
                            Else
                                'dttemp1.Tables(0).Rows(0)("SMSStatus") = True
                            End If
                            If dttemp1.Tables(0).Rows(i)("F1") <> "X" Then
                                dttemp1.Tables(0).Rows(i)("SMSStatusForm") = True
                            End If
                        Next

                        Session("FirstAssignto") = dttemp1.Tables(0)
                        Session("CompareAssignto") = dttemp1.Tables(0)
                        For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                            If dttemp1.Tables(0).Rows(j)("U_FirstName") <> "X" Then
                                HashAssignTo.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
                            End If
                            If dttemp1.Tables(0).Rows(j)("F1") <> "X" Then
                                HashAssignToForm.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("F1").ToString())
                            End If
                            'HashAssignTo.Add(dttemp.Tables(0).Rows(j)("Assignto_UserID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
                            If dttemp1.Tables(0).Rows(j)("U_FirstName") <> "X" Then
                                HashAssignToNew.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
                            Else
                                If dttemp1.Tables(0).Rows(j)("F1") <> "X" Then
                                    HashAssignToNew.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("F1").ToString())
                                End If
                            End If
                        Next

                        Session("dassigntohashForm") = HashAssignToForm
                        Session("dassigntohash") = HashAssignTo
                        Session("dassigntohashNew") = HashAssignToNew
                        '''''''''Session("dassigntohash") = HashAssignToNew
                        '''''''''rpassignto.DataSource = HashAssignTo
                        rpassignto.DataSource = HashAssignToNew
                        rpassignto.DataBind()
                    Else
                        rpassignto.DataSource = ""
                        rpassignto.DataBind()
                        Session("dassigntohash") = Nothing
                    End If
                End If
            Else
                If Not String.IsNullOrEmpty(hftypeid.Value) Then
                    If hftypeid.Value > 0 Then
                        Dim dttemp As DataSet = AssignToBLL.FillLMSAssignTo(hftype.Value, hftypeid.Value)
                        Dim dttemp1 As DataSet = dttemp
                        dttemp1.Tables(0).Columns.Add("SMSStatus")
                        For i = 0 To dttemp1.Tables(0).Rows.Count - 1
                            dttemp1.Tables(0).Rows(i)("SMSStatus") = True
                        Next
                        Session("FirstAssignto") = dttemp1.Tables(0)
                        Session("CompareAssignto") = dttemp1.Tables(0)
                        For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                            HashAssignTo.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
                            'HashAssignTo.Add(dttemp.Tables(0).Rows(j)("Assignto_UserID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
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
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "FillAssignTo", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
        Try
            'Dim flag As Boolean = 0
            Dim chk As Integer
            Dim chkForm As Integer
            If hftype.Value = "Both" Then
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim dt As DataTable = Session("CompareAssignto")

                    Dim row As GridViewRow = e.Row
                    Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                    Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                    Dim ckselect As CheckBox = DirectCast(e.Row.FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(e.Row.FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(e.Row.FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(e.Row.FindControl("ckTrial"), CheckBox)
                    Dim UserID As Integer = GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString()
                    If dt IsNot Nothing Then
                        For i = 0 To dt.Rows.Count - 1
                            If dt.Rows(i)("U_FirstName") <> "X" Then
                                chk = dt.Rows(i)("U_ID")
                            End If
                            If dt.Rows(i)("F1") <> "X" Then
                                chkForm = dt.Rows(i)("U_ID")
                            End If
                            'chk = dt.Rows(i)("Assignto_UserID")
                            If UserID = Session("LMSUserId") Or UserID = chk Then
                                ckselect.Checked = True
                                If hftype.Value = "Formulation" Then
                                    GridView1.Columns(7).Visible = True
                                    ckFormulation.Checked = True
                                ElseIf hftype.Value = "Recipe" Then
                                    GridView1.Columns(8).Visible = True
                                    ckRecipe.Checked = True
                                ElseIf hftype.Value = "Both" Then
                                    GridView1.Columns(7).Visible = True
                                    GridView1.Columns(8).Visible = True
                                    'ckFormulation.Checked = True
                                    ckRecipe.Checked = True
                                ElseIf hftype.Value = "Feedback" Then
                                    GridView1.Columns(9).Visible = True
                                    ckTrial.Checked = True
                                End If
                                If UserID = 1 Then
                                    ckselect.Enabled = False
                                    ckFormulation.Enabled = False
                                    ckRecipe.Enabled = False
                                    ckTrial.Enabled = False
                                End If
                            Else
                                'ckselect.Checked = False
                            End If
                            If UserID = Session("LMSUserId") Or UserID = chkForm Then
                                'ckselect.Checked = True
                                If hftype.Value = "Formulation" Then
                                    'GridView1.Columns(7).Visible = True
                                    ckFormulation.Checked = True
                                ElseIf hftype.Value = "Recipe" Then
                                    'GridView1.Columns(7).Visible = True
                                    'GridView1.Columns(8).Visible = True

                                    'ckFormulation.Checked = True
                                    ckRecipe.Checked = True
                                ElseIf hftype.Value = "Both" Then
                                    ckFormulation.Checked = True
                                ElseIf hftype.Value = "Feedback" Then
                                    'GridView1.Columns(9).Visible = True
                                    ckTrial.Checked = True
                                End If
                            Else
                                'ckselect.Checked = False
                            End If
                        Next
                    Else
                        If UserID = Session("LMSUserId") Then
                            ckselect.Checked = True
                            If UserID = 1 Then
                                ckselect.Enabled = False
                            End If
                            'If hftype.Value = "Formulation" Then
                            '    GridView1.Columns(7).Visible = True
                            '    ckFormulation.Checked = True
                            'ElseIf hftype.Value = "Recipe" Then
                            '    GridView1.Columns(8).Visible = True
                            '    ckRecipe.Checked = True
                            'ElseIf hftype.Value = "Both" Then
                            If hftype.Value = "Both" Then
                                GridView1.Columns(7).Visible = True
                                GridView1.Columns(8).Visible = True
                                ckFormulation.Checked = True
                                ckRecipe.Checked = True
                                If UserID = 1 Then
                                    ckFormulation.Enabled = False
                                    ckRecipe.Enabled = False
                                End If
                                'ElseIf hftype.Value = "Trial" Then
                                '    GridView1.Columns(9).Visible = True
                                '    ckTrial.Checked = True
                            End If
                        Else
                            'ckselect.Checked = False
                        End If

                    End If
                    'flag = 1
                End If
            Else
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim dt As DataTable = Session("CompareAssignto")
                    'If flag = 0 Then
                    '    chk = 0
                    'End If
                    Dim row As GridViewRow = e.Row
                    Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
                    Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
                    Dim ckselect As CheckBox = DirectCast(e.Row.FindControl("ckselect"), CheckBox)
                    Dim ckFormulation As CheckBox = DirectCast(e.Row.FindControl("ckFormulation"), CheckBox)
                    Dim ckRecipe As CheckBox = DirectCast(e.Row.FindControl("ckRecipe"), CheckBox)
                    Dim ckTrial As CheckBox = DirectCast(e.Row.FindControl("ckTrial"), CheckBox)
                    Dim UserID As Integer = GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString()
                    If dt IsNot Nothing Then
                        For i = 0 To dt.Rows.Count - 1
                            chk = dt.Rows(i)("U_ID")
                            'chk = dt.Rows(i)("Assignto_UserID")
                            If UserID = Session("LMSUserId") Or UserID = chk Then
                                ckselect.Checked = True
                                If hftype.Value = "Formulation" Then
                                    GridView1.Columns(7).Visible = True
                                    ckFormulation.Checked = True
                                ElseIf hftype.Value = "Recipe" Then
                                    'GridView1.Columns(7).Visible = True
                                    GridView1.Columns(8).Visible = True
                                    ckRecipe.Checked = True
                                ElseIf hftype.Value = "Feedback" Then
                                    GridView1.Columns(9).Visible = True
                                    ckTrial.Checked = True
                                End If
                                If UserID = 1 Then
                                    ckFormulation.Enabled = False
                                    ckRecipe.Enabled = False
                                    ckTrial.Enabled = False
                                End If
                            Else
                                'ckselect.Checked = False
                            End If
                        Next
                    Else
                        If UserID = Session("LMSUserId") Then
                            ckselect.Checked = True
                            If hftype.Value = "Formulation" Then
                                GridView1.Columns(7).Visible = True
                                ckFormulation.Checked = True
                            ElseIf hftype.Value = "Recipe" Then
                                'GridView1.Columns(7).Visible = True
                                GridView1.Columns(8).Visible = True
                                ckRecipe.Checked = True
                            ElseIf hftype.Value = "Feedback" Then
                                GridView1.Columns(9).Visible = True
                                ckTrial.Checked = True
                            End If
                            If UserID = 1 Then
                                ckFormulation.Enabled = False
                                ckRecipe.Enabled = False
                                ckTrial.Enabled = False
                            End If
                        Else
                            'ckselect.Checked = False
                        End If

                    End If

                    'flag = 1
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("AssignToUserControl", "GridView1_RowDataBound", error1, Session("LMSUserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Function Setdata() As Object
        Dim data As Object() = New Object(1) {}

        Return data

    End Function

    ' If tbl1.Rows.Count < tbl2.Rows.Count Then
    '                RowCount = tbl2.Rows.Count
    '                For i As Integer = 0 To tbl1.Rows.Count - 1
    '                    For j As Integer = 0 To RowCount - 1
    '                        If Equals(tbl1.Rows(i)(0).ToString(), tbl2.Rows(j)(0).ToString()) Then
    '                            tbl2.Rows(j).Delete()
    ''RowCount = RowCount - 1
    '                        End If
    '                    Next
    '                Next
    '            Else
    '                RowCount = tbl1.Rows.Count
    '                For i As Integer = 0 To tbl1.Rows.Count - 1
    '                    For j As Integer = 0 To RowCount - 1
    '                        If Equals(tbl2.Rows(i)(0).ToString(), tbl1.Rows(j)(0).ToString()) Then
    '                            tbl2.Rows(j).Delete()
    ''RowCount = RowCount - 1
    '                        End If
    '                    Next
    '                Next
    '            End If

    ''Public Sub FillAssignTo()
    ''    Try
    ''        If Not String.IsNullOrEmpty(hftypeid.Value) Then
    ''            If hftypeid.Value > 0 Then
    ''                Dim dttemp As DataSet = AssignToBLL.FillLMSAssignTo(hftype.Value, hftypeid.Value)
    ''                Dim dttemp1 As DataSet = dttemp
    ''                dttemp1.Tables(0).Columns.Add("SMSStatus")
    ''                For i = 0 To dttemp1.Tables(0).Rows.Count - 1
    ''                    dttemp1.Tables(0).Rows(i)("SMSStatus") = True
    ''                Next
    ''                Session("FirstAssignto") = dttemp1.Tables(0)
    ''                Session("CompareAssignto") = dttemp1.Tables(0)
    ''                For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
    ''                    HashAssignTo.Add(dttemp.Tables(0).Rows(j)("U_ID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
    ''                    'HashAssignTo.Add(dttemp.Tables(0).Rows(j)("Assignto_UserID").ToString(), dttemp.Tables(0).Rows(j)("U_FirstName").ToString())
    ''                Next
    ''                Session("dassigntohash") = HashAssignTo
    ''                rpassignto.DataSource = HashAssignTo
    ''                rpassignto.DataBind()
    ''            Else
    ''                rpassignto.DataSource = ""
    ''                rpassignto.DataBind()
    ''                Session("dassigntohash") = Nothing
    ''            End If
    ''        End If
    ''    Catch ex As Exception
    ''        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ''        error1 = error1.Replace(Chr(39), "")
    ''        ExecptionBLL.Insert("AssignToUserControl", "FillAssignTo", error1, Session("LMSUserId"))
    ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ''    End Try
    ''End Sub

    ''Protected Sub GridView1_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles GridView1.RowDataBound
    ''    Try
    ''        'Dim flag As Boolean = 0
    ''        Dim chk As Integer
    ''        If e.Row.RowType = DataControlRowType.DataRow Then
    ''            Dim dt As DataTable = Session("CompareAssignto")
    ''            'If flag = 0 Then
    ''            '    chk = 0
    ''            'End If


    ''            Dim row As GridViewRow = e.Row
    ''            Dim data As DataRow = DirectCast(row.DataItem, DataRowView).Row
    ''            Dim HyperLink1 As HyperLink = DirectCast(e.Row.FindControl("HyperLink1"), HyperLink)
    ''            Dim ckselect As CheckBox = DirectCast(e.Row.FindControl("ckselect"), CheckBox)
    ''            Dim ckFormulation As CheckBox = DirectCast(e.Row.FindControl("ckFormulation"), CheckBox)
    ''            Dim ckRecipe As CheckBox = DirectCast(e.Row.FindControl("ckRecipe"), CheckBox)
    ''            Dim ckTrial As CheckBox = DirectCast(e.Row.FindControl("ckTrial"), CheckBox)
    ''            Dim UserID As Integer = GridView1.DataKeys(e.Row.RowIndex).Values(0).ToString()
    ''            If dt IsNot Nothing Then
    ''                For i = 0 To dt.Rows.Count - 1
    ''                    chk = dt.Rows(i)("U_ID")
    ''                    'chk = dt.Rows(i)("Assignto_UserID")
    ''                    If UserID = Session("LMSUserId") Or UserID = chk Then
    ''                        ckselect.Checked = True
    ''                        If hftype.Value = "Formulation" Then
    ''                            GridView1.Columns(7).Visible = True
    ''                            ckFormulation.Checked = True
    ''                        ElseIf hftype.Value = "Recipe" Then
    ''                            GridView1.Columns(7).Visible = True
    ''                            GridView1.Columns(8).Visible = True
    ''                            ckRecipe.Checked = True
    ''                        ElseIf hftype.Value = "Trial" Then
    ''                            GridView1.Columns(9).Visible = True
    ''                            ckTrial.Checked = True
    ''                        End If
    ''                    Else
    ''                        'ckselect.Checked = False
    ''                    End If
    ''                Next
    ''            Else
    ''                If UserID = Session("LMSUserId") Then
    ''                    ckselect.Checked = True
    ''                    If hftype.Value = "Formulation" Then
    ''                        GridView1.Columns(7).Visible = True
    ''                        ckFormulation.Checked = True
    ''                    ElseIf hftype.Value = "Recipe" Then
    ''                        GridView1.Columns(7).Visible = True
    ''                        GridView1.Columns(8).Visible = True
    ''                        ckRecipe.Checked = True
    ''                    ElseIf hftype.Value = "Trial" Then
    ''                        GridView1.Columns(9).Visible = True
    ''                        ckTrial.Checked = True
    ''                    End If
    ''                Else
    ''                    'ckselect.Checked = False
    ''                End If

    ''            End If

    ''            'flag = 1
    ''        End If
    ''    Catch ex As Exception
    ''        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ''        error1 = error1.Replace(Chr(39), "")
    ''        ExecptionBLL.Insert("AssignToUserControl", "GridView1_RowDataBound", error1, Session("LMSUserId"))
    ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ''    End Try
    ''End Sub

    ''Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
    ''    Try
    ''        Dim Assnid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
    ''        Dim dtN As DataTable

    ''        Dim dtN1 As New DataTable
    ''        dtN1.Columns.Add("U_ID", GetType(String))
    ''        dtN1.Columns.Add("U_FirstName", GetType(String))
    ''        dtN1.Columns.Add("SMSStatus", GetType(String))
    ''        If Assnid IsNot Nothing Then
    ''            HashAssignTo = Session("dassigntohash")
    ''            For i As Integer = 0 To GridView1.Rows.Count - 1
    ''                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
    ''                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
    ''                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
    ''                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
    ''                If ckselect.Checked = True Then
    ''                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
    ''                    Else
    ''                        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
    ''                    End If
    ''                    dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
    ''                End If
    ''            Next
    ''            dtN = dtN1
    ''            Session("CompareAssignto") = dtN
    ''            Session("dassigntohash") = HashAssignTo
    ''        Else
    ''            For i As Integer = 0 To GridView1.Rows.Count - 1
    ''                Dim ckselect As CheckBox = DirectCast(GridView1.Rows(i).FindControl("ckselect"), CheckBox)
    ''                Dim lbluId As Literal = DirectCast(GridView1.Rows(i).FindControl("lbluId"), Literal)
    ''                Dim lblname As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname"), Literal)
    ''                Dim lblname1 As Literal = DirectCast(GridView1.Rows(i).FindControl("lblname1"), Literal)
    ''                If ckselect.Checked = True Then
    ''                    If HashAssignTo.ContainsKey(lbluId.Text.Trim) Then
    ''                    Else
    ''                        HashAssignTo.Add(lbluId.Text.Trim, lblname.Text.Trim)
    ''                    End If
    ''                    dtN1.Rows.Add(lbluId.Text.Trim, lblname1.Text.Trim, True)
    ''                End If
    ''            Next
    ''            dtN = dtN1
    ''            Session("CompareAssignto") = dtN
    ''            Session("dassigntohash") = HashAssignTo
    ''        End If
    ''        rpassignto.DataSource = HashAssignTo
    ''        rpassignto.DataBind()
    ''    Catch ex As Exception
    ''        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ''        error1 = error1.Replace(Chr(39), "")
    ''        ExecptionBLL.Insert("AssignToUserControl", "btnsave Add", error1, Session("LMSUserId"))
    ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ''    End Try

    ''End Sub

    ''Public Sub AddLMSAssignTo(ByVal DID As Integer)
    ''    Try

    ''        Dim tbl1 As New DataTable
    ''        tbl1 = Session("FirstAssignto")
    ''        Dim tbl2 As New DataTable
    ''        tbl2 = Session("CompareAssignto")

    ''        If tbl1 IsNot Nothing And tbl2 IsNot Nothing Then

    ''            Dim RowCount As Integer
    ''            If tbl1.Rows.Count < tbl2.Rows.Count Then
    ''                RowCount = tbl2.Rows.Count
    ''                For i As Integer = 0 To tbl1.Rows.Count - 1
    ''                    For j As Integer = 0 To RowCount - 1
    ''                        If Equals(tbl1.Rows(i)(1).ToString(), tbl2.Rows(j)(1).ToString()) Then
    ''                            tbl2.Rows(j)("SMSStatus") = False
    ''                        End If
    ''                    Next
    ''                Next
    ''            Else
    ''                RowCount = tbl2.Rows.Count
    ''                For i As Integer = 0 To tbl1.Rows.Count - 1
    ''                    For j As Integer = 0 To RowCount - 1
    ''                        If Equals(tbl2.Rows(j)(0).ToString(), tbl1.Rows(i)(0).ToString()) Then
    ''                            tbl2.Rows(j)("SMSStatus") = False
    ''                        End If
    ''                    Next
    ''                Next
    ''            End If
    ''        End If

    ''        Session("CompareAssignto") = tbl2

    ''        If DID > 0 Then
    ''            'No changes made here
    ''            AssignToBLL.DeleteAssignTo(hftype.Value, DID, Session("Audlog_Id"))
    ''        End If
    ''        Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
    ''        If HCatid IsNot Nothing Then
    ''            HashAssignTo = Session("dassigntohash")
    ''        Else
    ''            HashAssignTo.Add(Session("LMSUserId"), Session("LMSUserName"))
    ''        End If
    ''        Count = AssignToBLL.MaxAssignTo
    ''        Dim sb As New StringBuilder
    ''        sb.Append("<root>")
    ''        For i As Integer = 0 To HashAssignTo.Count - 1
    ''            sb.Append("<row Assignto_ID='" & Count.ToString & "' Assignto_UserID='" & HashAssignTo.Keys(i) &
    ''                     "' Assignto_Type='" & hftype.Value & "' Assignto_TypeID='" & DID & "' Assignto_CreatedID='" & Session("LMSUserId") &
    ''                     "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("LMSUserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
    ''                      "' Assignto_Del='0' Assignto_Status='Active' />")
    ''            Count = Count + 1
    ''        Next
    ''        sb.Append("</root>")
    ''        AssignToBLL.XMLInsert(sb.ToString, Session("Audlog_Id"), hftype.Value)

    ''        If tbl2 IsNot Nothing Then
    ''            Dim host As String = HttpContext.Current.Request.Url.Host
    ''            Session("OrderEmailSubj") = "New " + hftype.Value + " has been assigned "
    ''            For i = 0 To tbl2.Rows.Count - 1
    ''                If tbl2.Rows(i)(2) = True Then
    ''                    SendUsingSMPP.SendSMS("New " + hftype.Value + " no. " + hfTypeCode.Value + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", SmsBLL.LMSUserContactByID(tbl2.Rows(i)(0)))
    ''                    'SendUsingSMPP.SendSMS("New TRIAL! New trial no " + lblTrialNo.Text + " has been assigned to you by " + SmsBLL.LMSUserNameByID(Session("LMSUserId")).Replace(" ", "_") + " on " + FormatDateTime(Now, DateFormat.ShortDate) + ".", "9773438089")
    ''                    ' Response.Redirect("http://localhost:56361/PrintSalesOrdergst1.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(0)) & "&tp=" + HttpUtility.UrlEncode(Security.Encrypt(0)))
    ''                End If
    ''            Next
    ''        End If

    ''        Session("dassigntohash") = Nothing
    ''        Session("CompareAssignto") = Nothing
    ''        Session("FirstAssignto") = Nothing
    ''    Catch ex As Exception
    ''        Dim error1 As String = ex.Message.Replace(Chr(34), "")
    ''        error1 = error1.Replace(Chr(39), "")
    ''        ExecptionBLL.Insert("AssignToUserControl", "AddLMSAssignTo", error1, Session("LMSUserId"))
    ''        ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
    ''    End Try
    ''End Sub
End Class
