Imports Excel
Imports System.Text.RegularExpressions

Partial Class ImportProspect
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Session("UserId") = Nothing Then
            TryCast(Me.Master, MainPage).MaintainSession()
        End If
    End Sub

    Protected Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Dim dt As DataTable = Session("dt")
            If dt.Rows.Count > 0 Then
                Dim validProspect As Integer = dt.Select("Validation = 'Valid'").Length
                If validProspect > 0 Then
                    Dim numberofacc As Integer = 0
                    Dim numberofcontact As Integer = 0
                    Dim numberofaddress As Integer = 0
                    Dim Count As Integer = ImportAccountBLL.countAccount
                    Dim ContactCount As Integer = ImportAccountBLL.MaxContactID
                    Dim AddressCount As Integer = ImportAccountBLL.AccountAddressCount
                    Dim AssignCount As Integer = AssignToBLL.MaxAssignTo
                    Dim code As String = ""
                    Dim maxcode As String = CInt(Regex.Match(ImportAccountBLL.ProspectCode.ToString, "\d+").Value) + 1
                    Dim sbProspect As New StringBuilder
                    Dim sbcontact As New StringBuilder
                    Dim sbaddress As New StringBuilder
                    Dim sbAssign As New StringBuilder
                    sbProspect.Append("<root>")
                    sbcontact.Append("<root>")
                    sbaddress.Append("<root>")
                    sbAssign.Append("<root>")
                    For Each row As DataRow In dt.Rows

                        code = String.Format("{0}{1}", "P", maxcode.ToString().PadLeft(9, "0"))

                        If row("Validation") = "Valid" Then
                            sbProspect.Append("<row Acc_Id='" & Count.ToString & "' Acc_Name='" & row.Item("Prospect Name").ToString.Trim & "' Acc_IndustryId='" & row.Item("Industry").ToString.Trim &
                                             "' Acc_SourceID='" & row.Item("Source").ToString.Trim & "' Acc_OwnerID='" & Session("UserId") & "' Acc_CompanyTypeID='" & row.Item("Company Type").ToString.Trim &
                                             "' Acc_Website='" & row.Item("Website").ToString.Trim & "' Acc_Type='Prospect' Acc_TurnOver='" & row.Item("TurnOver").ToString.Trim &
                                             "' Acc_CreatedID='" & Session("UserId") & "' Acc_CreatedDate='" & DateAndTime.DateString & "' Acc_Date='" & DateAndTime.DateString &
                                             "' Acc_Code='" & code & "' Cust_EmailId='" & row.Item("Email Id 1").ToString.Trim & "' Acc_CampaignID='" & row.Item("Campaign").ToString.Trim & "' Acc_Description='" & row.Item("Description").ToString.Trim.Replace("&", "and") & "' Acc_Del='0' Acc_Status='Active' />")
                            sbaddress.Append("<row AccAddr_ID='" & AddressCount.ToString.Trim & "' AccAddr_Type='Billing' AccAddr_AccID='" & Count.ToString & "' AccAddr_Name='" & row.Item("Billing Contact Person").ToString.Trim.Replace("&", "and") &
                                             "' AccAddr_Email='" & row.Item("Billing Email ID").ToString.Trim & "' AccAddr_Telephone='" & row.Item("Billing Phone").ToString.Trim & "' AccAddr_City='" & row.Item("Billing City").ToString.Trim &
                                             "' AccAddr_State='" & row.Item("Billing State").ToString.Trim & "' AccAddr_Country='" & row.Item("Billing Country").ToString & "' AccAddr_Pincode='" & row.Item("Billing PostalCode").ToString & "' AccAddr_Address='" & row.Item("Billing Address").ToString.Trim.Replace("&", "and") &
                                             "' AccAddr_CreatedId='" & Session("UserId") & "' AccAddr_CreatedDate='" & DateAndTime.DateString & "' AccAddr_Del='0' AccAddr_Status='Active' />")
                            AddressCount = AddressCount + 1
                            numberofaddress += 1
                            sbaddress.Append("<row AccAddr_ID='" & AddressCount.ToString.Trim & "' AccAddr_Type='Shipping' AccAddr_AccID='" & Count.ToString & "' AccAddr_Name='" & row.Item("Shipping Contact Person").ToString.Trim.Replace("&", "and") &
                                             "' AccAddr_Email='" & row.Item("Shipping Email ID").ToString.Trim & "' AccAddr_Telephone='" & row.Item("Shipping Phone").ToString.Trim & "' AccAddr_City='" & row.Item("Shipping City").ToString.Trim &
                                             "' AccAddr_State='" & row.Item("Shipping State").ToString.Trim & "' AccAddr_Country='" & row.Item("Shipping Country").ToString & "' AccAddr_Pincode='" & row.Item("Shipping PostalCode").ToString & "' AccAddr_Address='" & row.Item("Shipping Address").ToString.Trim.Replace("&", "and") &
                                             "' AccAddr_CreatedId='" & Session("UserId") & "' AccAddr_CreatedDate='" & DateAndTime.DateString & "' AccAddr_Del='0' AccAddr_Status='Active' />")
                            sbcontact.Append("<row Contact_Id='" & ContactCount.ToString & "' Contact_ContactTypeId='" & Count.ToString & "' Contact_Title='Mr.' Contact_Gender='Male' Contact_Type='0' Contact_Primary='1' Contact_ContactType='Prospect'  Contact_ContactPerson='" & row.Item("Contact Person 1").ToString.Trim &
                                             "' Contact_Designation='0' Contact_Email='" & row.Item("Email Id 1").ToString.Trim & "' Contact_Mobile='" & row.Item("Phone Number 1").ToString.Trim & "' Contact_CreatedID='" & Session("UserId") &
                                             "' Contact_CreatedDate='" & DateAndTime.DateString & "' Contact_LeadContact_Del='0' Contact_Status='Active' />")
                            If Not (String.IsNullOrEmpty(row.Item("Contact Person 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Email Id 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Phone Number 2").ToString.Trim)) Then
                                ContactCount = ContactCount + 1
                                numberofcontact += 1
                                sbcontact.Append("<row Contact_Id='" & ContactCount.ToString & "' Contact_ContactTypeId='" & Count.ToString & "' Contact_Title='Mr.' Contact_Gender='Male' Contact_Type='0' Contact_Primary='1' Contact_ContactType='Prospect'  Contact_ContactPerson='" & row.Item("Contact Person 2").ToString.Trim &
                                                 "' Contact_Designation='0' Contact_Email='" & row.Item("Email Id 2").ToString.Trim & "' Contact_Mobile='" & row.Item("Phone Number 2").ToString.Trim & "' Contact_CreatedID='" & Session("UserId") &
                                                 "' Contact_CreatedDate='" & DateAndTime.DateString & "' Contact_LeadContact_Del='0' Contact_Status='Active' />")
                            End If
                            If Not (String.IsNullOrEmpty(row.Item("Contact Person 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Email Id 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Phone Number 3").ToString.Trim)) Then
                                ContactCount = ContactCount + 1
                                numberofcontact += 1
                                sbcontact.Append("<row Contact_Id='" & ContactCount.ToString & "' Contact_ContactTypeId='" & Count.ToString & "' Contact_Title='Mr.' Contact_Gender='Male' Contact_Type='0' Contact_Primary='1' Contact_ContactType='Prospect'  Contact_ContactPerson='" & row.Item("Contact Person 3").ToString.Trim &
                                                 "' Contact_Designation='0' Contact_Email='" & row.Item("Email Id 3").ToString.Trim & "' Contact_Mobile='" & row.Item("Phone Number 3").ToString.Trim & "' Contact_CreatedID='" & Session("UserId") &
                                                 "' Contact_CreatedDate='" & DateAndTime.DateString & "' Contact_LeadContact_Del='0' Contact_Status='Active' />")
                            End If

                            sbAssign.Append("<row Assignto_ID='" & AssignCount.ToString & "' Assignto_UserID='" & Session("UserId") &
                        "' Assignto_Type='Prospect' Assignto_TypeID='" & Count.ToString & "' Assignto_CreatedID='" & Session("UserId") &
                        "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                         "' Assignto_Del='0' Assignto_Status='Active' />")

                            maxcode += 1
                            Count = Count + 1
                            ContactCount = ContactCount + 1
                            AddressCount = AddressCount + 1
                            AssignCount = AssignCount + 1
                            numberofacc += 1
                            numberofaddress += 1
                            numberofcontact += 1
                        End If
                    Next
                    sbProspect.Append("</root>")
                    sbaddress.Append("</root>")
                    sbcontact.Append("</root>")
                    sbAssign.Append("</root>")
                    Dim errmsg As String = ImportAccountBLL.XMLInsert(sbProspect.ToString, sbaddress.ToString, sbcontact.ToString, Session("Audlog_Id"), numberofacc, numberofaddress, numberofcontact)
                    If Not String.IsNullOrEmpty(errmsg) Then
                        If Not IsNumeric(errmsg) Then
                            Throw New Exception(errmsg)
                        Else
                            AssignToBLL.XMLInsert(sbAssign.ToString, Session("Audlog_Id"), "Prospect")
                            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + numberofacc.ToString + " Prospects inserted\n" + numberofaddress.ToString + " Address inserted \n" + numberofcontact.ToString + " Contacts inserted!');window.location='Prospect.aspx';", True)
                            Session("dt") = Nothing
                        End If
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Prospect to upload!')", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Prospect to upload!')", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ImportProspect", "btnadd_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportProspect", "ImportExcel", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub Check(dt As DataTable, ByVal Filename As String)
        Try
            Dim check As Boolean = False
            If dt.Rows.Count > 0 Then
                Dim Prospectcol As DataTable = ImportAccountBLL.AccountImporColumn().Tables(0)
                For i As Integer = 0 To dt.Columns.Count - 1
                    check = False
                    For Each col In Prospectcol.Rows
                        If col("Excel_Column").ToString.Equals(dt.Columns(i).ToString) Then
                            check = True
                            Exit For
                        End If
                    Next
                    If check = False Then
                        Throw New Exception("Invalid Coloum Name= " & dt.Columns(i).ToString)
                        Exit For
                    End If
                Next
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


                    Dim sourcedt As DataTable = MainBLL.Dropdown("SourceDropDown").Tables(0)
                    Dim industrydt As DataTable = MainBLL.Dropdown("IndustryDropDown").Tables(0)
                    Dim companytypedt As DataTable = MainBLL.Dropdown("CompanyTypeDropDown").Tables(0)
                    Dim countrydt As DataTable = MainBLL.Dropdown("CountryDropDown").Tables(0)
                    Dim statedt As DataTable = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
                    Dim Campaigndt As DataTable = MainBLL.Dropdown("CampaignNameDropDown").Tables(0)


                    For Each row As DataRow In dt.Rows

                        If String.IsNullOrEmpty(row.Item("Prospect Name").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Prospect Name is empty"
                        Else
                            row.BeginEdit()
                            row.Item("Prospect Name") = row.Item("Prospect Name").ToString.Replace("&", "and")
                            row.Item("Prospect Name") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Prospect Name"))
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Billing Address").ToString) Then
                            row.BeginEdit()
                            'row.Item("Billing Address") = Convert.ToString(row.Item("Billing Address")).Replace("\r", "").Replace("\n", "")
                            'Dim stradd As String = row.Item("Billing Address").ToString
                            'row.Item("Billing Address") = row.Item("Billing Address").ToString.Trim.Replace(System.Environment.NewLine, "").Replace("\r\n", "").Replace(vbLf, "").Replace(vbCr, "").Replace(Chr(10), "")
                            row.Item("Billing Address") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Billing Address"))
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Shipping Address").ToString) Then
                            row.BeginEdit()
                            'row.Item("Shipping Address") = row.Item("Shipping Address").ToString.Replace("\r", "").Replace("\n", "")
                            'row.Item("Shipping Address") = row.Item("Shipping Address").ToString.Trim.Replace(System.Environment.NewLine, "").Replace("\r\n", "").Replace(vbLf, "").Replace(vbCr, "").Replace(Chr(10), "")
                            row.Item("Shipping Address") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Shipping Address"))
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("TurnOver").ToString) Then
                            row.BeginEdit()
                            row.Item("TurnOver") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("TurnOver"))
                            row.EndEdit()
                        End If

                        If String.IsNullOrEmpty(row.Item("Contact Person 1").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Contact Person is empty"
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Email Id 1").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Email Id 1").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "Email Id is invalid"
                            End If
                        End If


                        If Not String.IsNullOrEmpty(row.Item("Billing Email ID").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Billing Email ID").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "Billing Email ID is invalid"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Shipping Email ID").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Shipping Email ID").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "Shipping Email ID is invalid"
                            End If
                        End If
                        ''mobile no 
                        'If Not String.IsNullOrEmpty(row.Item(4).ToString) Then
                        '    If Not IsNumeric(row.Item(4).ToString.Trim.Replace(" ", "")) Then
                        '        row("Validation") = "Invalid"
                        '        row("Error") = "Mobile No is invalid"
                        '    End If
                        '    '    If Not row.Item(4).ToString.Length = 10 Then
                        '    '        row("Validation") = "Invalid"
                        '    '        row("Error") = "Mobile No is invalid"
                        '    '    End If
                        'End If
                        If Not String.IsNullOrEmpty(row.Item("Website").ToString) Then
                            Dim regexurl As Regex = New Regex("(http(s)?://)?([\w-]+\.)+[\w-]+[.com]+(/[/?%&=]*)?")
                            Dim matchurl As Match = regexurl.Match(row.Item("Website").ToString)
                            If Not matchurl.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "Website is invalid"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Source").ToString) Then
                            Dim source As Array = sourcedt.Select("Source_Name = '" + row.Item("Source").ToString + "'")
                            If source.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Source") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Source") = source(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Source") = 0
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Industry").ToString) Then
                            Dim industry As Array = industrydt.Select("Industry_Name = '" + row.Item("Industry").ToString + "'")
                            If industry.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Industry") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Industry") = industry(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Industry") = 0
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Company Type").ToString) Then
                            Dim companytype As Array = companytypedt.Select("CompanyType = '" + row.Item("Company Type").ToString + "'")
                            If companytype.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Company Type") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Company Type") = companytype(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Company Type") = 0
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Billing Country").ToString) Then
                            Dim country As Array = countrydt.Select("CountryName = '" + row.Item("Billing Country").ToString + "'")
                            If country.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Billing Country") = 105
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Billing Country") = country(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Billing Country") = 105
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Shipping Country").ToString) Then
                            Dim country As Array = countrydt.Select("CountryName = '" + row.Item("Shipping Country").ToString + "'")
                            If country.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Shipping Country") = 105
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Shipping Country") = country(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Shipping Country") = 105
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Billing State").ToString) Then
                            Dim state As Array = statedt.Select("StateName = '" + row.Item("Billing State").ToString + "'")
                            If state.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Billing State") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Billing State") = state(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Billing State") = 0
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Shipping State").ToString) Then
                            Dim state As Array = statedt.Select("StateName = '" + row.Item("Shipping State").ToString + "'")
                            If state.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Shipping State") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Shipping State") = state(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Shipping State") = 0
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Campaign").ToString) Then
                            Dim Campaign As Array = Campaigndt.Select("Campaign_Name = '" + row.Item("Campaign").ToString + "'")
                            If Campaign.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Campaign") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Campaign") = Campaign(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Campaign") = 0
                            row.EndEdit()
                        End If
                        For Each item As DataColumn In dt.Columns
                            If Not (row(item).ToString = row.Item("Website").ToString Or row(item).ToString = row.Item("Billing Email ID").ToString Or row(item).ToString = row.Item("Shipping Email ID").ToString Or row(item).ToString = row.Item("Email Id 1").ToString Or row(item).ToString = row.Item("Email Id 2").ToString Or row(item).ToString = row.Item("Email Id 3").ToString) Then
                                row(item) = DynamicparcelDisplayFunctions.CleanAddress(row(item).ToString)
                            End If
                        Next
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
            ExecptionBLL.Insert("ImportProspect", "Check", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportProspect", "btnupload_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportProspect", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub countvalid(dt As DataTable)
        Try
            Dim validProspect As Integer = dt.Select("Validation = 'Valid'").Length
            Dim invalidProspect As Integer = dt.Select("Validation = 'Invalid'").Length
            lblinvalidAccount.Visible = True
            lblvalidAccount.Visible = True
            lblinvalidAccount.Text = "Total Invalid Prospects: " + invalidProspect.ToString
            lblvalidAccount.Text = "Total Valid Prospects: " + validProspect.ToString
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ImportProspect", "countvalid", error1, Session("UserId"))
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
