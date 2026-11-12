Imports Excel
Imports System.Text.RegularExpressions

Partial Class ImportProduct
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Dim dt As DataTable = Session("dt")
            If dt.Rows.Count > 0 Then
                Dim validAccount As Integer = dt.Select("Validation = 'Valid'").Length
                If validAccount > 0 Then
                    Dim numberofacc As Integer = 0
                    Dim numberofcontact As Integer = 0


                    Dim Count As Integer = 1
                    Dim priceCount As Integer = 1


                    Dim sbAccount As New StringBuilder
                    Dim sbcontact As New StringBuilder

                    sbAccount.Append("<root>")
                    sbcontact.Append("<root>")

                    For Each row As DataRow In dt.Rows



                        If row("Validation") = "Valid" Then
                            sbAccount.Append("<row Product_Id='" & Count.ToString & "' Product_Name='" & row.Item("Product Name").ToString.Trim & "' Product_Code='" & row.Item("Product Code").ToString.Trim &
                                             "' Product_CategoryId='" & row.Item("Category").ToString.Trim & "' Product_ProductStatus='" & row.Item("Product Status").ToString.Trim &
                                             "' Product_PacketSize='" & row.Item("Standard Pack").ToString.Trim &
                                             "' Product_CreatedID='1' Product_CreatedDate='" & DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' />")

                            sbcontact.Append("<row ProductPrice_Id='" & priceCount.ToString & "' ProductPrice_ProductID='" & Count.ToString & "' ProductPrice_DealerPrice='" & row.Item("Dealer Price").ToString.Trim &
                                             "' ProductPrice_MrpPrice='" & row.Item("MRP").ToString.Trim &
                                             "' ProductPrice_CreatedDate='" & DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "' ProductPrice_Del='0' ProductPrice_Status='Active' />")


                            Count = Count + 1
                            priceCount = priceCount + 1

                            numberofacc += 1

                            numberofcontact += 1

                        End If
                    Next
                    sbAccount.Append("</root>")

                    sbcontact.Append("</root>")

                    Dim errmsg As String = ImportBLL.XMLInsert(sbAccount.ToString, sbcontact.ToString)


                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Product to upload!')", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Product to upload!')", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub ImportExcel(ByVal filePath As String, ByVal Extension As String)
        Try
            Dim stream As FileStream = File.Open(filePath, FileMode.Open, FileAccess.Read)
            Dim excelReader As IExcelDataReader
            Select Case Extension
                Case ".xls"
                    'Excel 97-03 
                    '1. Reading from a binary Excel file ('97-2003 format; *.xls)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream)
                    Exit Select
                Case ".xlsx"
                    'Excel 07 
                    '2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream)
                    Exit Select
            End Select
            '...
            '3. DataSet - The result of each spreadsheet will be created in the result.Tables
            '  Dim result As DataSet = excelReader.AsDataSet()
            '...
            '4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = True
            Dim result As DataSet = excelReader.AsDataSet()

            '5. Data Reader methods
            While excelReader.Read()
                'excelReader.GetInt32(0);
            End While

            '6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close()
            If result.Tables.Count > 0 Then
                Check(result.Tables(0), filePath)
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('No record found to Import')", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub Check(dt As DataTable, ByVal Filename As String)
        Try
            Dim check As Boolean = False
            If dt.Rows.Count > 0 Then
                check = True
                'Dim Accountcol As DataTable = ImportAccountBLL.AccountImporColumn().Tables(0)
                'For i As Integer = 0 To dt.Columns.Count - 1
                '    check = False
                '    For Each col In Accountcol.Rows
                '        If col("Excel_Column").ToString.Equals(dt.Columns(i).ToString) Then
                '            check = True
                '            Exit For
                '        End If
                '    Next
                '    If check = False Then
                '        Throw New Exception("Invalid Coloum Name= " & dt.Columns(i).ToString)
                '        Exit For
                '    End If
                'Next
                If check = True Then
                    Dim column As DataColumn
                    column = New DataColumn
                    With column
                        .ColumnName = "Validation"
                        .DataType = System.Type.GetType("System.String")
                        .DefaultValue = "Valid"
                        .Unique = False
                    End With
                    dt.Columns.Add(column)
                    Dim errorcol As DataColumn
                    errorcol = New DataColumn
                    With errorcol
                        .ColumnName = "Error"
                        .DataType = System.Type.GetType("System.String")
                        .Unique = False
                    End With
                    dt.Columns.Add(errorcol)


                    Dim Category As DataTable = MainBLL.Dropdown("ProductCategoryDropDown").Tables(0)

                    For Each row As DataRow In dt.Rows

                        If String.IsNullOrEmpty(row.Item("Product Name").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Product Name  is empty"
                        Else
                            row.BeginEdit()
                            row.Item("Product Name") = row.Item("Product Name").ToString.Replace("&", "and")
                            row.EndEdit()
                        End If


                        If Not String.IsNullOrEmpty(row.Item("Category").ToString) Then
                            Dim CategoryArry As Array = Category.Select("PC_Name = '" + row.Item("Category").ToString + "'")
                            If CategoryArry.Length = 0 Then
                                row.BeginEdit()
                                row.Item("Category") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Category") = CategoryArry(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Category") = 0
                            row.EndEdit()
                        End If


                        'For Each item As DataColumn In dt.Columns
                        '    If Not (row(item).ToString = row.Item("Website").ToString Or row(item).ToString = row.Item("Billing Email ID").ToString Or row(item).ToString = row.Item("Shipping Email ID").ToString Or row(item).ToString = row.Item("Email Id 1").ToString Or row(item).ToString = row.Item("Email Id 2").ToString Or row(item).ToString = row.Item("Email Id 3").ToString) Then
                        '        row(item) = DynamicparcelDisplayFunctions.CleanAddress(row(item).ToString)
                        '    End If
                        'Next
                    Next

                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    Session("dt") = dt
                    countvalid(dt)
                End If
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")

            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub btnupload_Click(sender As Object, e As EventArgs) Handles btnupload.Click
        Try
            If FileUpload1.HasFile Then
                Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
                Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)

                Dim FilePath As String = Server.MapPath("~/UploadExcel/" + FileName)
                FileUpload1.SaveAs(FilePath)

                ' Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
                ImportExcel(FilePath, Extension)
                System.IO.File.Delete(FilePath)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try

            GridView1.PageIndex = e.NewPageIndex
            GridView1.DataSource = Session("dt")
            GridView1.DataBind()
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "ScrollPage", "ResetScrollPosition();", True)
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub countvalid(dt As DataTable)
        Try
            Dim validAccount As Integer = dt.Select("Validation = 'Valid'").Length
            Dim invalidAccount As Integer = dt.Select("Validation = 'Invalid'").Length
            lblinvalidAccount.Visible = True
            lblvalidAccount.Visible = True
            lblinvalidAccount.Text = "Total Invalid Product: " + invalidAccount.ToString
            lblvalidAccount.Text = "Total Valid Product: " + validAccount.ToString
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            lblinvalidAccount.Visible = False
            lblvalidAccount.Visible = False
        End If
    End Sub


End Class
