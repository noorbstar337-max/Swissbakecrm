Imports DynamicparcelEnumerations

Partial Class Profile
    Inherits System.Web.UI.Page
    Dim path3 As String
    
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
        End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                FillDetail()
            Catch ex As Exception
                Response.Redirect("index.aspx")
            End Try
        End If

        Me.Title = "Profile"
    End Sub

    Private Sub SaveProduct(ByVal enumOperation As DML_OPERATION)
        Try
            UserImageUpload()
            UserBLL.UpdateProfile(txtfirstname.Text, txtlastname.Text, txtemail.Text, txtmobile.Text, txtdob.Text, path3, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert(''); window.location('Profile.aspx');", True)
            Response.Redirect(Request.RawUrl)
            FillDetail()
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub FillDetail()
        Try
            Dim dt As DataSet = MainBLL.ViewByID(Session("UserId"), "UserProfileViewByID")
            Dim dtUser As New DataTable
            dtUser = dt.Tables(0)
            Dim drUserRow As DataRow = dtUser.Rows(0)
            txtfirstname.Text = DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_FirstName").ToString())
            txtlastname.Text = DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_LastName").ToString())
            txtemail.Text = DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_Email").ToString())
            txtmobile.Text = DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_Mobile").ToString())
            txtdob.Text = DynamicparcelDataManipulation.DateFormatDateMode(drUserRow("U_DOB").ToString())
            hfimgpath.Value = DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_Theme").ToString())
            Image1.ImageUrl = "../" + DynamicparcelDataManipulation.FixNullFromDB(drUserRow("U_Theme").ToString())

        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub UserImageUpload()
        If FileUploadControl.PostedFile.FileName = "" Then
            path3 = hfimgpath.Value
        Else
            Try
                Dim MyDate As DateTime = DateTime.Now
                Dim filename As String = Path.GetFileName(MyDate.ToString("ddMMyyhhmmss") + "-" + FileUploadControl.PostedFile.FileName)
                path3 = "ProfileImage/" + filename
                Dim path2 As String = Server.MapPath("~/ProfileImage/" + filename)
                FileUploadControl.PostedFile.SaveAs(path2)
                DynamicparcelImages.CompressImage(path2, 25)
            Catch ex As Exception
                Dim error1 As String = ex.Message.Replace(Chr(34), "")
                error1 = error1.Replace(Chr(39), "")
                ScriptManager.RegisterClientScriptBlock(Page, Me.GetType(), "call", "alert('Error " + error1.ToString + "');", True)
            End Try
        End If
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        SaveProduct(DML_OPERATION.UPDATE)
    End Sub

End Class
