
Partial Class UserControl_Back_SearchControlWithID
    Inherits System.Web.UI.UserControl
    Public Event BubbleClick As EventHandler
    Dim _UpdatePanel1 As UpdatePanel
    Dim GridView1 As GridView

#Region "User Control Property"
    Public Property UpdatePanel1() As UpdatePanel
        Get
            Return Me._UpdatePanel1
        End Get
        Set(value As UpdatePanel)
            Me._UpdatePanel1 = value
        End Set
    End Property
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
    Public Property ULkadd() As LinkButton
        Get
            Return Me.lkadd
        End Get
        Set(value As LinkButton)
            Me.lkadd = value
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
    Public Property Uhfgridviewmode() As HiddenField
        Get
            Return Me.hfgridviewmode
        End Get
        Set(value As HiddenField)
            Me.hfgridviewmode = value
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
    Public Property Uhfid() As HiddenField
        Get
            Return Me.hfid
        End Get
        Set(value As HiddenField)
            Me.hfid = value
        End Set
    End Property
    Public Property UhfExcelName() As HiddenField
        Get
            Return Me.hfExcelName
        End Get
        Set(value As HiddenField)
            Me.hfExcelName = value
        End Set
    End Property
    Public Property UhfExcelmode() As HiddenField
        Get
            Return Me.hfExcelmode
        End Get
        Set(value As HiddenField)
            Me.hfExcelmode = value
        End Set
    End Property
#End Region

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                UpdatePanel1 = Me.Parent.FindControl("UpdatePanel1")
                GridView1 = Me.Parent.FindControl("GridView1")
                Me.txtsearch.Attributes.Add("onkeyup", String.Format("javascript:__doPostBack('{0}','')", Me.UpdatePanel1.ClientID))
            Else
                UpdatePanel1 = Me.Parent.FindControl("UpdatePanel1")
                GridView1 = Me.Parent.FindControl("GridView1")
                Dim target As String = Me.Request.Form("__EVENTTARGET")
                If Not String.IsNullOrEmpty(target) AndAlso target.Equals(Me.UpdatePanel1.ClientID) Then
                    If Not String.IsNullOrEmpty(Me.txtsearch.Text) Then
                        GridView1.AllowCustomPaging = False
                        FillSearch()
                    Else
                        GridView1.AllowCustomPaging = True
                        fillGridview(ddpagesize.SelectedValue)
                    End If
                End If
            End If
            Dim scriptManager__1 As ScriptManager = ScriptManager.GetCurrent(Me.Page)
            scriptManager__1.RegisterPostBackControl(Me.btnExportWord)
            scriptManager__1.RegisterPostBackControl(Me.btnExportExcel)
            If Session("UserRoleID") = 1 Then
                btnExportExcel.Visible = True
                btnExportWord.Visible = True
            Else
                btnExportExcel.Visible = False
                btnExportWord.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillSearch()
        Try
            If hfsearchmode.Value = "SearchQuotationRespByAssignByID" Or hfsearchmode.Value = "SearchQuotationRespAll" Or hfsearchmode.Value = "SearchPOList" Or hfExcelmode.Value = "ExcelQuotationRespByAssign" Then
                GridView1.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfsearchmode.Value)
                GridView1.DataBind()
            ElseIf hfsearchmode.Value = "SearchQRbystatus" Or hfExcelmode.Value = "ExcelQRDetails" Then
                GridView1.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfsearchmode.Value, Session("Type"))
                GridView1.DataBind()
            Else
                GridView1.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfsearchmode.Value)
                GridView1.DataBind()
            End If

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillGridview(ByVal ddpagesize As Integer)
        Try
            If hfsearchmode.Value = "SearchQuotationRespByAssignByID" Or hfsearchmode.Value = "SearchQuotationRespAll" Or hfsearchmode.Value = "SearchPOList" Or hfExcelmode.Value = "ExcelQuotationRespByAssign" Then
                If hfid.Value = 0 Then
                    GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalcount.Value)
                    GridView1.DataSource = MainBLL.FillGridView("0", ddpagesize, hfgridviewmode.Value)
                    GridView1.DataBind()
                    Dim temp As Integer = GridView1.Rows.Count
                Else
                    GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalcount.Value, Session("UserId"))
                    GridView1.DataSource = MainBLL.FillGridViewById("0", ddpagesize, hfid.Value, hfgridviewmode.Value)
                    GridView1.DataBind()
                    Dim temp As Integer = GridView1.Rows.Count
                End If
            ElseIf hfsearchmode.Value = "SearchQRbystatus" Or hfExcelmode.Value = "ExcelQRDetails" Then
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalcount.Value, Session("UserId"), Session("Type"))
                GridView1.DataSource = MainBLL.FillGridViewById("0", ddpagesize, Session("UserId"), hfgridviewmode.Value, Session("Type"))
                GridView1.DataBind()
                Dim temp As Integer = GridView1.Rows.Count
            Else
                GridView1.VirtualItemCount = MainBLL.TotalRowInGridviewBYID(hftotalcount.Value, Session("UserId"))
                GridView1.DataSource = MainBLL.FillGridViewById("0", ddpagesize, Session("UserId"), hfgridviewmode.Value)
                GridView1.DataBind()
                Dim temp As Integer = GridView1.Rows.Count
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "fillGridview", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event LKClick(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub ddpagesize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddpagesize.SelectedIndexChanged
        'Bubble the event
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub lkadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkadd.Click

        RaiseEvent LKClick(sender, e)
    End Sub
    Protected Sub btnshowall_Click(sender As Object, e As EventArgs) Handles btnshowall.Click
        Try
            GridView1.AllowCustomPaging = True
            fillGridview(ddpagesize.SelectedValue)
            txtsearch.Text = ""
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "btnshowall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    Protected Sub btnExportWord_Click(sender As Object, e As EventArgs) Handles btnExportWord.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + hfExcelName.Value + ".doc")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-word "
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim GRD As New GridView
            If hfExcelmode.Value = "ExcelQuotationRespByAssign" Or hfExcelmode.Value = "ExcelPOList" Then
                If hfid.Value = 0 Then
                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                Else

                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                End If
            ElseIf hfExcelmode.Value = "ExcelQRDetails" Then
                If hfid.Value = 0 Then
                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                Else

                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value, Session("Type"))

                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                End If

            Else
                If txtsearch.Text = "" Then
                    GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfExcelmode.Value)
                    GRD.DataBind()
                    GRD.AllowPaging = False
                    GRD.DataBind()
                Else
                    GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfExcelmode.Value)
                    GRD.DataBind()
                    GRD.AllowPaging = False
                    GRD.DataBind()
                End If
            End If
            GRD.RenderControl(hw)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "btnExportWord_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + hfExcelName.Value + ".xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim GRD As New GridView
            If hfExcelmode.Value = "ExcelQuotationRespByAssign" Or hfExcelmode.Value = "ExcelPOList" Then
                If hfid.Value = 0 Then
                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If

                Else

                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value)
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                End If

            ElseIf hfExcelmode.Value = "ExcelQRDetails" Then
                If hfid.Value = 0 Then
                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                Else

                    If txtsearch.Text = "" Then
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value, Session("Type"))

                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    Else
                        GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, hfid.Value, hfExcelmode.Value, Session("Type"))
                        GRD.DataBind()
                        GRD.AllowPaging = False
                        GRD.DataBind()
                    End If
                End If
            Else
                If txtsearch.Text = "" Then
                    GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfExcelmode.Value)
                    GRD.DataBind()
                    GRD.AllowPaging = False
                    GRD.DataBind()
                Else
                    GRD.DataSource = MainBLL.SearchGridViewByID(txtsearch.Text.Trim, Session("UserId"), hfExcelmode.Value)
                    GRD.DataBind()
                    GRD.AllowPaging = False
                    GRD.DataBind()
                End If
            End If
                GRD.RenderControl(hw)
                Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
                Response.Write(style)
                Response.Output.Write(sw.ToString())
                Response.Flush()
                Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControlWithId", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

End Class
