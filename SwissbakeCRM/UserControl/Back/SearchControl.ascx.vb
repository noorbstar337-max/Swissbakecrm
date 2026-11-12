
Partial Class UserControl_Back_WebUserControl
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
    Public Property Ubtnshowall() As Button
        Get
            Return Me.btnshowall
        End Get
        Set(value As Button)
            Me.btnshowall = value
        End Set
    End Property
    Public Property UbtnExportWord() As ImageButton
        Get
            Return Me.btnExportWord
        End Get
        Set(value As ImageButton)
            Me.btnExportWord = value
        End Set
    End Property
    Public Property UbtnExportExcel() As ImageButton
        Get
            Return Me.btnExportExcel
        End Get
        Set(value As ImageButton)
            Me.btnExportExcel = value
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
            'ddpagesize.Visible = False
            'btnshowall.Visible = False
            'btnExportWord.Visible = False
            'btnExportExcel.Visible = False
            ''what the hell is this 
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
                        fillGridview(10)
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
            ExecptionBLL.Insert("SearchControl", "Page_Load", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub
    
    Public Sub FillSearch()
        Try
            GridView1.DataSource = MainBLL.SearchGridView(txtsearch.Text.Trim, hfsearchmode.Value)
            GridView1.DataBind()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControl", "FillSearch", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub fillGridview(ByVal ddpagesize As Integer)
        Try
            GridView1.VirtualItemCount = MainBLL.TotalRowInGridview(hftotalcount.Value)
            GridView1.DataSource = MainBLL.FillGridView("0", ddpagesize, hfgridviewmode.Value)
            GridView1.DataBind()
            Dim temp As Integer = GridView1.Rows.Count
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControl", "fillGridview", error1, Session("UserId"))
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
            ExecptionBLL.Insert("SearchControl", "btnshowall_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub btnExportWord_Click(sender As Object, e As EventArgs) Handles btnExportWord.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + hfExcelName.Value + ".doc")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-word "
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)
            Dim GRD As New GridView
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
            GRD.RenderControl(hw)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.[End]()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControl", "btnExportWord_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        Try
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" + hfExcelName.Value + ".xls")
            Response.Charset = ""
            Response.ContentType = "application/vnd.ms-excel"
            Dim sw As New StringWriter()
            Dim hw As New HtmlTextWriter(sw)

            Dim GRD As New GridView
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

            'Change the Header Row back to white color 
            'GRD.HeaderRow.Style.Add("background-color", "#FFFFFF")

            ''Apply style to Individual Cells 
            'GRD.HeaderRow.Cells(0).Style.Add("background-color", "#f9f9f9")
            'GRD.HeaderRow.Cells(1).Style.Add("background-color", "#f9f9f9")
            'GRD.HeaderRow.Cells(2).Style.Add("background-color", "#f9f9f9")
            'GRD.HeaderRow.Cells(3).Style.Add("background-color", "#f9f9f9")

            'For i As Integer = 0 To GRD.Rows.Count - 1
            '    Dim row As GridViewRow = GRD.Rows(i)

            '    'Change Color back to white 
            '    row.BackColor = System.Drawing.Color.White

            '    'Apply text style to each Row 
            '    row.Attributes.Add("class", "textmode")

            '    'Apply style to Individual Cells of Alternating Row 
            '    If i Mod 2 <> 0 Then
            '        row.Cells(0).Style.Add("background-color", "#f9f9f9")
            '        row.Cells(1).Style.Add("background-color", "#f9f9f9")
            '        row.Cells(2).Style.Add("background-color", "#f9f9f9")
            '        row.Cells(3).Style.Add("background-color", "#f9f9f9")
            '    End If
            'Next
            GRD.RenderControl(hw)

            'style to format numbers to string 
            Dim style As String = "<style> .textmode { mso-number-format:\@; } </style>"
            Response.Write(style)
            Response.Output.Write(sw.ToString())
            Response.Flush()
            Response.End()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("SearchControl", "btnExportExcel_Click", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

   
End Class
