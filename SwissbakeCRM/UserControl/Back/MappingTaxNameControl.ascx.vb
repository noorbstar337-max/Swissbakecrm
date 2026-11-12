
Partial Class UserControl_Back_MappingTaxNameControl
    Inherits System.Web.UI.UserControl
    Dim HashAssignTo As Hashtable = New Hashtable
    Dim Count As Integer
    Dim DID As Integer
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
        If Not IsPostBack Then
            Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
            fillUser()
            FillAssignTo()
        Else
            Dim target As String = Me.Request.Form("__EVENTTARGET")
            If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                    GridView1.AllowCustomPaging = False
                    FillSearch()
                Else
                    GridView1.AllowCustomPaging = True
                    fillUser()
                End If
            End If
        End If
    End Sub

    Public Sub fillUser()
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("MTaxNameTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView("0", "5", "MTaxNameGridview")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MappingTaxNameControl", "fillUser", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, "MTaxNameSearch")
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MappingTaxNameControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            If txtsearch.Text = "" Then
                GridView1.PageIndex = e.NewPageIndex
                GridView1.DataSource = MainBLL.FillGridView(e.NewPageIndex, "5", "MTaxNameGridview")
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
            ExecptionBLL.Insert("MappingTaxNameControl", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            GridView1.AllowCustomPaging = True
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview("MTaxNameTotalNumberOfRecord")
            GridView1.DataSource = MainBLL.FillGridView("0", "5", "MTaxNameGridview")
            GridView1.DataBind()
            txtsearch.Text = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MappingTaxNameControl", "btnshowall_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("MappingTaxNameControl", "btnsave Add", error1, Session("UserId"))
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
                    HashAssignTo.Remove(ltid.Text)
                    Session("dassigntohash") = HashAssignTo
                Else
                    HashAssignTo.Remove(ltid.Text)
                    Session("dassigntohash") = HashAssignTo
                End If
                rpassignto.DataSource = HashAssignTo
                rpassignto.DataBind()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("MappingTaxNameControl", "rpassignto_ItemCommand Add", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            End Try
        End If
    End Sub

   
    Public Sub FillAssignTo()
        Try
            If hftypeid.Value = "" Then
            ElseIf hftypeid.Value > 0 Then
                Dim dttemp As DataSet = MappingTaxNameBLL.FillAssignTo(hftypeid.Value)
                For j As Integer = 0 To dttemp.Tables(0).Rows.Count - 1
                    HashAssignTo.Add(dttemp.Tables(0).Rows(j)("TaxMapping_Id").ToString(), dttemp.Tables(0).Rows(j)("Tax_Name").ToString())
                Next
                Session("dassigntohash") = HashAssignTo
                rpassignto.DataSource = HashAssignTo
                rpassignto.DataBind()
            Else
                rpassignto.DataSource = ""
                rpassignto.DataBind()
                Session("dassigntohash") = Nothing
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MappingTaxNameControl", "FillAssignTo", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub AddAssignTo(ByVal DID As Integer, ByVal taxmainID As Integer)
        Try
            If DID > 0 Then
                MappingTaxNameBLL.DeleteAssignTo(DID, Session("Audlog_Id"))
            End If
            Dim HCatid As Hashtable = If(Session("dassigntohash") IsNot Nothing, DirectCast(Session("dassigntohash"), Hashtable), Nothing)
            If HCatid IsNot Nothing Then
                HashAssignTo = Session("dassigntohash")
            Else
            End If
            Count = MappingTaxNameBLL.MaxAssignTo
            Dim sb As New StringBuilder
            sb.Append("<root>")
            For i As Integer = 0 To HashAssignTo.Count - 1
                sb.Append("<row TaxMapping_ID='" & Count.ToString & "' TaxMapping_TaxID='" & HashAssignTo.Keys(i) &
                         "' TaxMapping_CreatedDate='" & DateAndTime.DateString & "' TaxMapping_MainTaxID='" & taxmainID & "' />")
                Count = Count + 1
            Next
            sb.Append("</root>")
            MappingTaxNameBLL.XMLInsert(sb.ToString, Session("Audlog_Id"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("MappingTaxNameControl", "AddAssignTo", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub


End Class
