Imports DynamicparcelEnumerations

Partial Class ModifyCompany
    Inherits System.Web.UI.Page
    Dim CompanyID As Integer = 1
    Dim path3 As String
    Dim hpath3 As String
    Dim fpath3 As String

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
            Try
                CheckPrivilage()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='AdminMenu.aspx';", True)
            End Try
        Else
            Try
                CheckPrivilage()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='AdminMenu.aspx';", True)
            End Try
        End If
  End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                FillCountry()
                FillState()
                FillDetail()
                'CheckPrivilage()
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCompany", "Page_Load", error1, Session("UserId"))
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "');window.location='index.aspx';", True)
            End Try
        End If
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Try
            CompanyImageUpload()
            HeaderImageUpload()
            FooterImageUpload()
            CompanyBLL.Update(txtphone.Text, txtfax.Text, txtemail.Text, txtcst.Text, ddcountry.SelectedValue, ddstate.SelectedValue, path3, txtpan.Text, txtcin.Text, txtvat.Text, txtsertaxregno.Text, ddsalestargettime.SelectedValue, ddsalestargettype.SelectedValue, Session("UserId"), CompanyID, txtadd1.Text, txtadd2.Text, hpath3, fpath3)
            FillDetail()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "SaveProduct", error1, Session("UserId"))
            Throw ex
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(CompanyID, "CrmCompanyViewByID")
            Dim dtFaq As New DataTable
            dtFaq = dt.Tables(0)
            Dim drFaqRow As DataRow
            drFaqRow = dtFaq.Rows(0)
            lblname.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Name").ToString())
            txtadd1.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Address1").ToString())
            txtadd2.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Address2").ToString())
            txtphone.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Phone").ToString())
            txtfax.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_FaxNo").ToString())
            txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_InfoEmail").ToString())
            lblregestration.Text = DynamicparcelDataManipulation.AlphaDateFormat(drFaqRow("CM_DORegistration").ToString())
            txtpan.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_PAN").ToString())
            lblexpiry.Text = DynamicparcelDataManipulation.AlphaDateFormat(drFaqRow("CM_DOExpiry").ToString())
            txtcin.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Cin").ToString())
            lbluser.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_NoOfUser").ToString())
            txtcst.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_CTS").ToString())
            lblcontactperson.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_ContactPerson").ToString())
            txtvat.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_VatTin").ToString())
            ddcountry.SelectedValue = Convert.ToInt32(drFaqRow("CM_Country").ToString())
            ddstate.SelectedValue = Convert.ToInt32(drFaqRow("CM_State").ToString())
            txtsertaxregno.Text = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_STaxRegNo").ToString())
            ddsalestargettime.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_STTime").ToString())
            ddsalestargettype.SelectedValue = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_STType").ToString())
            hfimgpath.Value = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Image").ToString())
            Image1.ImageUrl = "../" + DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_Image").ToString())
            hfimgpathheader.Value = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_HImage").ToString())
            Image2.ImageUrl = "../" + DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_HImage").ToString())
            hfimgpathfooter.Value = DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_FImage").ToString())
            Image3.ImageUrl = "../" + DynamicparcelDataManipulation.FixNullFromDB(drFaqRow("CM_FImage").ToString())
            'txtcreatedate.Text = DynamicparcelDataManipulation.DateFormat(drFaqRow("CM_CreatedDate").ToString())
            'txtcreateid.Text = DynamicparcelDataManipulation.FixNullFromDB(MainBLL.GetUserName(Convert.ToInt32(drFaqRow("CM_CreatedID").ToString())))
            lblmodifieddate.Text = DynamicparcelDataManipulation.AlphaDateFormat(drFaqRow("CM_ModifiedDate").ToString())
            lblmodifiedname.Text = DynamicparcelDataManipulation.FixNullFromDB(MainBLL.GetUserName(Convert.ToInt32(drFaqRow("CM_ModifiedID").ToString())))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "FillDetail", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try

    End Sub


    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            SaveProduct(DML_OPERATION.UPDATE)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "btnadd_Click", error1, Session("UserId"))
            ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
        End Try

    End Sub

    Public Sub CheckPrivilage()
        Try
            Dim ID As Integer = Convert.ToInt32(Session("UserRoleID"))
            If ID = "1" Then
                btnadd.Visible = True
                Button1.Visible = True
                'ElseIf ID = "2" Then
                '    btnadd.Visible = False
                '    Button1.Visible = False
                '    FileUploadControl.Visible = False
                'ElseIf ID = "3" Then
                '    btnadd.Visible = False
                '    Button1.Visible = False
                '    FileUploadControl.Visible = False
            Else
                btnadd.Visible = False
                Button1.Visible = False
                FileUploadControl.Visible = False
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "CheckPrivilage", error1, Session("UserId"))
            'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            Throw ex
        End Try
    End Sub

    Public Sub CompanyImageUpload()
        If FileUploadControl.PostedFile.FileName = "" Then
            path3 = hfimgpath.Value
        Else
            Try
                Dim MyDate As DateTime = DateTime.Now
                Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl.PostedFile.FileName)
                path3 = "img/CompanyImage/" + filename
                Dim path2 As String = Server.MapPath("~/img/CompanyImage/" + filename)
                FileUploadControl.PostedFile.SaveAs(path2)
                'DynamicparcelImages.CompressImage(path2, 25)
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCompany", "CompanyImageUpload", error1, Session("UserId"))
                'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
                Throw ex
            End Try
        End If
    End Sub

    Public Sub HeaderImageUpload()
        If FileUploadControl1.PostedFile.FileName = "" Then
            hpath3 = hfimgpathheader.Value
        Else
            Try
                Dim MyDate As DateTime = DateTime.Now
                Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl1.PostedFile.FileName)
                hpath3 = "img/CompanyImage/" + filename
                Dim path2 As String = Server.MapPath("~/img/CompanyImage/" + filename)
                FileUploadControl1.PostedFile.SaveAs(path2)
                'DynamicparcelImages.CompressImage(path2, 25)
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCompany", "HeaderImageUpload", error1, Session("UserId"))
                'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
                Throw ex
            End Try
        End If
    End Sub

    Public Sub FooterImageUpload()
        If FileUploadControl2.PostedFile.FileName = "" Then
            fpath3 = hfimgpathfooter.Value
        Else
            Try
                Dim MyDate As DateTime = DateTime.Now
                Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl2.PostedFile.FileName)
                fpath3 = "img/CompanyImage/" + filename
                Dim path2 As String = Server.MapPath("~/img/CompanyImage/" + filename)
                FileUploadControl2.PostedFile.SaveAs(path2)
                'DynamicparcelImages.CompressImage(path2, 25)
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ExecptionBLL.Insert("ModifyCompany", "FooterImageUpload", error1, Session("UserId"))
                'ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
                Throw ex
            End Try
        End If
    End Sub

    Public Sub FillCountry()
        Try
            ddcountry.DataSource = MainBLL.Dropdown("CountryDropDown")
            ddcountry.DataTextField = "CountryName"
            ddcountry.DataValueField = "Id"
            ddcountry.DataBind()
            ddcountry.Items.Insert(0, New ListItem("Select Country", "0"))
            ddcountry.SelectedValue = 105
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "FillCountry", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub

    Public Sub FillState()
        Try
            ddstate.DataSource = MainBLL.DropdownWithID("StateDropDown", ddcountry.SelectedValue)
            ddstate.DataTextField = "StateName"
            ddstate.DataValueField = "ID"
            ddstate.DataBind()
            ddstate.Items.Insert(0, New ListItem("Select State", "0"))
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ModifyCompany", "FillState", error1, Session("UserId"))
            'ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
            Throw ex
        End Try
    End Sub
End Class
