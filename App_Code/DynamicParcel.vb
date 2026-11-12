Imports Microsoft.VisualBasic

Public NotInheritable Class DynamicparcelEnumerations
    Public Enum DML_OPERATION
        INSERT = 1
        UPDATE = 2
        DELETE = 3
    End Enum
End Class

Public NotInheritable Class DynamicparcelDisplayFunctions
    ''' <summary>
    ''' Clean up file names to ascii
    ''' </summary>
    Public Shared Function SanitizeProductName(ByVal strInput As String) As String
        strInput = Replace(strInput, " ", "e")
        Dim objRegex As RegularExpressions.Regex = New RegularExpressions.Regex("[^A-Za-z 0-9 \.,\?'""!@#\$%\^&\*\(\)-_=\+;:<>\/\\\|\}\{\[\]`~]*°")
        SanitizeProductName = objRegex.Replace(strInput, "")
    End Function

    ''' <summary>
    ''' Clean URL
    ''' </summary>
    Public Shared Function CleanURL(ByVal strInput As String) As String
        'will need to be replaced by a regex
        'strInput = strInput.Replace("""", "")
        'strInput = strInput.Replace("*", "")
        'strInput = strInput.Replace("#", "")
        strInput = strInput.Replace("//", "/")
        strInput = strInput.Replace("°", "o")
        strInput = strInput.Replace("./", "_/")
        'Return strInput.Replace("&", "-And-")
        Dim strArrayChars() As String = Split(""",',\,:,*,?,|,(,),%,#,&,>,<", ",")
        For numCount = 0 To UBound(strArrayChars)
            strInput = Replace(strInput, strArrayChars(numCount), IIf(strArrayChars(numCount) = "%", "pc", ""))
        Next
        Return strInput
    End Function

    ''' <summary>
    ''' This truncates descriptions to specified length if too long, and appends "..."
    ''' </summary>
    Public Shared Function TruncateDescription(ByVal strDescription As Object, ByVal numCharacters As Integer) As String
        strDescription = StripHTML(strDescription) 'uses another Kartris function

        If Len(strDescription) > numCharacters Then
            Return Left(strDescription, numCharacters) & "..."
        End If

        Return strDescription
    End Function

    Public Shared Function StripHTML(ByVal strInput As Object) As String
        Dim strOutput As String = ""
        Try
            strOutput = RegularExpressions.Regex.Replace(strInput.ToString, "<(.|\n)*?>", String.Empty)

            'This bit trims extra chars, probably because this function
            'was used incorrectly in some places to sanitize URLs - use CleanURL for that.
            'Dim strArrayChars() As String = Split("',/,\,:,*,?,|,(,),%", ",")
            'For numCount = 0 To UBound(strArrayChars)
            'strOutput = Replace(strOutput, strArrayChars(numCount), IIf(strArrayChars(numCount) = "%", "pc", ""))
            'Next

            'This removes half-formed tags with an opening < but no close tag
            If strOutput.Contains("<") Then
                strOutput = Left(strOutput, InStr(strOutput, "<") - 1)
            End If
        Catch
            strOutput = ""
        End Try

        Return strOutput
    End Function

    Public Shared Function RemoveXSS(ByVal objText As Object) As Object
        If objText IsNot Nothing AndAlso objText.GetType() Is Type.GetType("System.String") Then
            objText = objText.Replace("<", "&lt;") '<
            objText = objText.Replace(">", "&gt;") '>
            objText = objText.Replace("'", "&apos;") 'apostophe
            objText = objText.Replace("""", "&#x22;") ' "
            objText = objText.Replace(")", "&#x29") ' )
            objText = objText.Replace("(", "&#x28") ' (
        End If
        Return objText
    End Function
    ''' <summary>
    ''' This truncates descriptions to Html Tags "..."
    ''' </summary>
    Public Shared Function RemoveHTMLTag(ByVal strInput As Object) As String
        If strInput = "" Then
        Else
            strInput = Regex.Replace(strInput, "<[^>]*>", [String].Empty)
            strInput = strInput.Replace("&nbsp;", " ")
            strInput = Regex.Replace(strInput, "\s+", " ")
            strInput = Regex.Replace(strInput, "\r\n", vbLf)
            strInput = Regex.Replace(strInput, "\n+", vbLf)
        End If
        Return strInput
    End Function
    ''' <summary>
    ''' Filter SeoUrl "..."
    ''' </summary>
    Public Shared Function GenerateURL(Title As Object) As String
        Dim strTitle As String = Title.ToString()

        '#Region "Generate SEO Friendly URL based on Title"
        strTitle = strTitle.Trim()

        'Trim "-" Hyphen
        strTitle = strTitle.Trim("-"c)

        'strTitle = strTitle.ToLower()
        Dim chars As Char() = "$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray()
        'strTitle = strTitle.Replace("c#", "C-Sharp")
        'strTitle = strTitle.Replace("vb.net", "VB-Net")
        'strTitle = strTitle.Replace("asp.net", "Asp-Net")

        'Replace . with - hyphen
        strTitle = strTitle.Replace(".", "-")

        'Replace Special-Characters
        For i As Integer = 0 To chars.Length - 1
            Dim strChar As String = chars.GetValue(i).ToString()
            If strTitle.Contains(strChar) Then
                strTitle = strTitle.Replace(strChar, String.Empty)
            End If
        Next

        'Replace all spaces with one "-" hyphen
        strTitle = strTitle.Replace(" ", "-")

        'Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("-----", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("&", "and")
        'Run the code again...
        'Trim Start and End Spaces.
        strTitle = strTitle.Trim()

        'Trim "-" Hyphen
        strTitle = strTitle.Trim("-"c)
        '#End Region

        'Append ID at the end of SEO Friendly URL
        'strTitle = "~/Article/" & strTitle & "-" & Convert.ToString(strId) & ".aspx"

        Return strTitle
    End Function

    Public Shared Function CleanAddress(address As Object) As String
        Dim strTitle As String = address.ToString()

        '#Region "Generate SEO Friendly URL based on Title"
        strTitle = strTitle.Trim()

        'Trim "-" Hyphen
        strTitle = strTitle.Trim("-"c)

        'strTitle = strTitle.ToLower()
        Dim chars As Char() = "$%#@!*?;~`+=()[]{}|'<>^&""".ToCharArray()
        'strTitle = strTitle.Replace("c#", "C-Sharp")
        'strTitle = strTitle.Replace("vb.net", "VB-Net")
        'strTitle = strTitle.Replace("asp.net", "Asp-Net")

        'Replace . with - hyphen
        'strTitle = strTitle.Replace(".", "-")

        'Replace Special-Characters
        For i As Integer = 0 To chars.Length - 1
            Dim strChar As String = chars.GetValue(i).ToString()
            If strTitle.Contains(strChar) Then
                strTitle = strTitle.Replace(strChar, String.Empty)
            End If
        Next

        'Replace all spaces with one "-" hyphen

        strTitle = strTitle.Replace("'", " ")
        'Replace multiple "-" hyphen with single "-" hyphen.
        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("-----", "-")
        strTitle = strTitle.Replace("----", "-")
        strTitle = strTitle.Replace("---", "-")
        strTitle = strTitle.Replace("--", "-")
        strTitle = strTitle.Replace("&", "and")
        strTitle = strTitle.Replace(vbCrLf, " ")
        strTitle = strTitle.Replace(vbCr, " ")
        strTitle = strTitle.Replace(vbLf, " ")
        strTitle = strTitle.Replace(Chr(10), " ")
        strTitle = strTitle.Replace(Chr(13), " ")
        strTitle = strTitle.Replace(vbNewLine, " ")
        strTitle = strTitle.Replace(Environment.NewLine, " ")
        'Run the code again...
        'Trim Start and End Spaces.
        strTitle = strTitle.Trim()

        'Trim "-" Hyphen
        strTitle = strTitle.Trim("-"c)
        '#End Region

        'Append ID at the end of SEO Friendly URL
        'strTitle = "~/Article/" & strTitle & "-" & Convert.ToString(strId) & ".aspx"

        Return strTitle
    End Function

    Public Shared Function GenerateDynamicPage(Title As Object, ByVal _ReplaceItem As Object) As String
        Dim strTitle As String = Title.ToString()
        '#Region "Generate SEO Friendly URL based on Title"
        strTitle = strTitle.Trim()
        'Replace all $$$$$ with one _ReplaceItem
        strTitle = strTitle.Replace("$$$$$", _ReplaceItem)
        Return strTitle
    End Function
   
End Class

Public NotInheritable Class DynamicparcelDataManipulation
    Public Shared Function FixNullFromDB(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        End If
        Return objInput
    End Function
    Public Shared Function DateFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput.ToString() = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("yyyy-MM-dd")
                Return objInput
            End If
        End If
    End Function

    Public Shared Function DateFormatfirstdate(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("dd-MM-yyyy")
                Return objInput
            End If
        End If
    End Function

    Public Shared Function DateFormatWithTime(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("dd/MM/yyyy - HH:mm:ss tt")
                Return objInput
            End If
        End If
    End Function
    Public Shared Function AlphaDateFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("MMM dd yyyy")
        End If
        Return objInput
    End Function
    Public Shared Function YearFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("yyyy")
        End If
        Return objInput
    End Function
    Public Shared Function MonthFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("MMM")
        End If
        Return objInput
    End Function
    Public Shared Function DaysFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            Dim dt As Date = Convert.ToDateTime(objInput)
            objInput = dt.ToString("dd")
        End If
        Return objInput
    End Function

    Public Shared Function DateFormatDateMode(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("yyyy-MM-dd")
                Return objInput
            End If
        End If
    End Function

    Public Shared Function DateFormatDateTimeLocal(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Try
                    Dim dt As Date = Convert.ToDateTime(objInput)
                    objInput = dt.ToString("yyyy-MM-ddTHH:mm")
                    Return objInput
                Catch ex As Exception
                    Return Nothing
                End Try
            End If
        End If
    End Function

    Public Shared Function TimeFormat(ByVal objInput As Object) As Object
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("h:mm")
                Return objInput
            End If
        End If
    End Function
    Public Shared Function TimeFormatSec(ByVal objInput As Object) As Object '============Created By MUBYN
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("h:mm:ss")
                Return objInput
            End If
        End If
    End Function
    Public Shared Function TimeFormatAmPm(ByVal objInput As Object) As Object  '============Created By MUBYN
        If objInput Is DBNull.Value Then
            Return Nothing
        Else
            If objInput = "" Then
                Return Nothing
            Else
                Dim dt As Date = Convert.ToDateTime(objInput)
                objInput = dt.ToString("hh:mm tt")
                Return objInput
            End If
        End If
    End Function

End Class

Public NotInheritable Class DynamicparcelImages

    Public Const strImagesPath As String = "~/Images/"
    Public Const strCategoryImagesPath As String = "~/Images/Categories"
    Public Const strProductImagesPath As String = "~/Images/Products"
    Public Const strPromotionImagesPath As String = "~/Images/Promotions"
    Public Const strThemesPath As String = "~/Skins"

    Public Enum IMAGE_TYPE
        enum_CategoryImage = 1
        enum_ProductImage = 2
        enum_VersionImage = 3
        enum_PromotionImage = 4
        enum_OtherImage = 5
    End Enum

    Public Enum IMAGE_SIZE
        enum_Thumb = 1
        enum_Normal = 2
        enum_Large = 3
        enum_Auto = 4
        enum_MiniThumb = 5
    End Enum


    ''' <summary>
    ''' compress images
    ''' </summary>
    Public Shared Sub CompressImage(ByVal strImagePath As String, ByVal numQuality As Long)
        Dim numMaxWidth As Integer = 1500, numMaxHeight As Integer = 1500
        Try
            Dim numImageNewWidth, numImageNewHeight As Integer

            Dim objImgOriginal As System.Drawing.Image
            objImgOriginal = System.Drawing.Image.FromFile(strImagePath)
            objImgOriginal.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)
            objImgOriginal.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone)

            If objImgOriginal.Height / numMaxHeight < objImgOriginal.Width / numMaxWidth Then
                'Resize by width
                numImageNewWidth = numMaxWidth
                numImageNewHeight = objImgOriginal.Height / (objImgOriginal.Width / numMaxWidth)
            Else
                'Resize by height
                numImageNewHeight = numMaxHeight
                numImageNewWidth = objImgOriginal.Width / (objImgOriginal.Height / numMaxHeight)
            End If

            'If new height/width bigger than old ones, cancel
            If numImageNewHeight > objImgOriginal.Height Or numImageNewWidth > objImgOriginal.Width Then
                numImageNewHeight = objImgOriginal.Height
                numImageNewWidth = objImgOriginal.Width
            End If

            Dim objImgCompressed As System.Drawing.Image = objImgOriginal.GetThumbnailImage(numImageNewWidth, numImageNewHeight, Nothing, Nothing)
            objImgOriginal.Dispose()

            Dim Info = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
            Dim Params = New System.Drawing.Imaging.EncoderParameters(1)
            Params.Param(0) = New System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, numQuality)

            objImgCompressed.Save(strImagePath, Info(1), Params)
            objImgCompressed.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Function NoImage(ByVal objInput As Object) As String
        If objInput = "" Then
            objInput = "images/noimage.png"

        Else
            Return objInput
        End If
        Return objInput
    End Function
    Public Shared Function NoImagUserControl(ByVal objInput As Object) As String
        If objInput = "" Then
            objInput = "~/images/noimage.png"
        Else
            objInput = "~/" + objInput
            Return objInput
        End If
        Return objInput
    End Function
End Class

Public NotInheritable Class DynamicparcelGridview
    Public Shared Function CheckPrivilage(ByVal delcol As Integer, ByVal Edit As Integer, ByVal status As Integer, ByVal view As Integer,
    GridView1 As GridView, ByVal ID As Integer, hfadd As HyperLink, _Page As String) As GridView
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                hfadd.Visible = False
                GridView1.Columns(Edit).Visible = False
                GridView1.Columns(status).Visible = False
                GridView1.Columns(delcol).Visible = False
                GridView1.Columns(view).Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hfadd.Visible = True
                Else
                    hfadd.Visible = False
                End If
                If (drprivilage("Prvg_RView").ToString()) = True Then
                    GridView1.Columns(view).Visible = True
                Else
                    GridView1.Columns(view).Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(Edit).Visible = True
                    GridView1.Columns(status).Visible = True
                Else
                    GridView1.Columns(Edit).Visible = False
                    GridView1.Columns(status).Visible = False
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    GridView1.Columns(delcol).Visible = True
                Else
                    GridView1.Columns(delcol).Visible = False
                End If
            End If
            Return GridView1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub CheckPrivilageForModify(ByVal ID As Integer, upsave As Button, save As Button, _Page As String)
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                save.Visible = False
                upsave.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    save.Visible = True
                    upsave.Visible = True
                Else
                    save.Visible = False
                    upsave.Visible = False
                    Throw New Exception("You don't have permission \n please contact admin")
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    save.Visible = True
                    upsave.Visible = True
                Else
                    save.Visible = False
                    upsave.Visible = False
                    Throw New Exception("You don't have permission \n please contact admin")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function CheckPrivilagewithNoView(ByVal delcol As Integer, ByVal Edit As Integer, ByVal status As Integer,
    GridView1 As GridView, ByVal ID As Integer, hfadd As HyperLink, _Page As String) As GridView
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                hfadd.Visible = False
                GridView1.Columns(Edit).Visible = False
                GridView1.Columns(status).Visible = False
                GridView1.Columns(delcol).Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hfadd.Visible = True
                Else
                    hfadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(Edit).Visible = True
                    GridView1.Columns(status).Visible = True
                Else
                    GridView1.Columns(Edit).Visible = False
                    GridView1.Columns(status).Visible = False
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    GridView1.Columns(delcol).Visible = True
                Else
                    GridView1.Columns(delcol).Visible = False
                End If
            End If
            Return GridView1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function CheckPrivilageWithSamePageModified(add As LinkButton, ByVal Edit As Integer, ByVal delcol As Integer,
    ByVal status As Integer, GridView1 As GridView, ByVal ID As Integer, _Page As String) As GridView
        Try
            Dim dt As DataSet = PrivilageBLL.CheckPrivilige(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then

                GridView1.Columns(Edit).Visible = False
                GridView1.Columns(status).Visible = False
                GridView1.Columns(delcol).Visible = False
                GridView1.ShowFooter = False
                add.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_Rview").ToString()) = True Then
                Else
                    Throw New Exception("You don't have right to view this page\n Please contact admin!")
                End If
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    add.Visible = True
                Else
                    add.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(Edit).Visible = True
                    GridView1.Columns(status).Visible = True
                Else
                    GridView1.Columns(Edit).Visible = False
                    GridView1.Columns(status).Visible = False
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    GridView1.Columns(delcol).Visible = True
                Else
                    GridView1.Columns(delcol).Visible = False
                End If
            End If
            Return GridView1
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Shared Function HighlightText(ByVal InputTxt As String, txtSearch As TextBox) As String
        Try
            Dim Search_Str As String = txtSearch.Text
            ' Setup the regular expression and add the Or operator.
            Dim RegExp As Regex = New Regex(Search_Str.Replace(" ", "|").Trim, RegexOptions.IgnoreCase)
            ' Highlight keywords by calling the
            'delegate each time a keyword is found.
            Return RegExp.Replace(InputTxt, New MatchEvaluator(AddressOf ReplaceKeyWords))
        Catch ex As Exception

        End Try

    End Function

    Public Shared Function ReplaceKeyWords(ByVal m As Match) As String
        Return ("<span class=MasterGridviewhighlight>" + m.Value + "</span>")
    End Function

    '------------Added by MUBYN Used in CheckPrivilege function for LMS
    Public Shared Function CheckLMSPrivilegewithNoView(ByVal delcol As Integer, ByVal Edit As Integer, ByVal status As Integer,
   GridView1 As GridView, ByVal ID As Integer, hfadd As HyperLink, _Page As String) As GridView
        Try
            Dim dt As DataSet = PrivilageBLL.CheckLMSPrivilege(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                hfadd.Visible = False
                GridView1.Columns(Edit).Visible = False
                GridView1.Columns(status).Visible = False
                GridView1.Columns(delcol).Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    hfadd.Visible = True
                Else
                    hfadd.Visible = False
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    GridView1.Columns(Edit).Visible = True
                    GridView1.Columns(status).Visible = True
                Else
                    GridView1.Columns(Edit).Visible = False
                    GridView1.Columns(status).Visible = False
                End If
                If (drprivilage("Prvg_RDelete").ToString()) = True Then
                    GridView1.Columns(delcol).Visible = True
                Else
                    GridView1.Columns(delcol).Visible = False
                End If
            End If
            Return GridView1
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '------------Added by MUBYN Used in CheckPrivilege function for LMS
    Public Shared Sub CheckLMSPrivilageForModify(ByVal ID As Integer, upsave As Button, save As Button, _Page As String)
        Try
            Dim dt As DataSet = PrivilageBLL.CheckLMSPrivilege(ID, _Page)
            Dim dtprivilage As New DataTable
            dtprivilage = dt.Tables(0)
            Dim drprivilage As DataRow
            If dtprivilage.Rows.Count = 0 Then
                save.Visible = False
                upsave.Visible = False
            Else
                drprivilage = dtprivilage.Rows(0)
                If (drprivilage("Prvg_RAdd").ToString()) = True Then
                    save.Visible = True
                    upsave.Visible = True
                Else
                    save.Visible = False
                    upsave.Visible = False
                    Throw New Exception("You don't have permission \n please contact admin")
                End If
                If (drprivilage("Prvg_RUpdate").ToString()) = True Then
                    save.Visible = True
                    upsave.Visible = True
                Else
                    save.Visible = False
                    upsave.Visible = False
                    Throw New Exception("You don't have permission \n please contact admin")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class



