Imports Excel
Imports System.Text.RegularExpressions

Partial Class ImportLead
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
                Dim validlead As Integer = dt.Select("Validation = 'Valid'").Length
                If validlead > 0 Then
                    Dim Count As Integer = ImportLeadBLL.countlead
                    Dim ContactCount As Integer = ImportLeadBLL.LeadContactCount
                    Dim AddressCount As Integer = ImportLeadBLL.LeadAddressCount
                    Dim AssignCount As Integer = AssignToBLL.MaxAssignTo
                    Dim sblead As New StringBuilder
                    Dim sbcontact As New StringBuilder
                    Dim sbaddress As New StringBuilder
                    Dim sbAssign As New StringBuilder
                    sblead.Append("<root>")
                    sbcontact.Append("<root>")
                    sbaddress.Append("<root>")
                    sbAssign.Append("<root>")
                    For Each row As DataRow In dt.Rows
                        If row("Validation") = "Valid" Then
                            sblead.Append("<row Lead_Id='" & Count.ToString & "' Lead_Date='" & DateAndTime.Now.ToString("yyyy-MM-dd HH:mm:ss") &
                                  "' Lead_Name='" & row.Item("Lead Name").ToString.Trim & "' Lead_IndustryId='" & row.Item("Industry").ToString.Trim & "' Lead_SourceID='" & row.Item("Source").ToString.Trim & "' Lead_StageID='1' Lead_CompanyTypeID='" & row.Item("Company Type").ToString.Trim &
                                  "' Lead_LeadTypeID='" & row.Item("Lead Type").ToString.Trim & "' Lead_Reference='" & row.Item("Lead Reference").ToString.Trim & "' Lead_OwnerID='" & Session("UserId") & "' Lead_Website='" & row.Item("Lead Website").ToString.Trim & "' Lead_CampaignId='" & row.Item("Campaign").ToString.Trim &
                                  "' Lead_TurnOver='" & row.Item("Lead TurnOver").ToString.Trim & "' Lead_CreatedID='" & Session("UserId") & "' Lead_CreatedDate='" & DateAndTime.DateString &
                                   "' Lead_Del='0' Lead_Status='Active' />")
                            sbaddress.Append("<row LeadAddress_ID='" & AddressCount.ToString.Trim & "' LeadAddress_Type='Billing' LeadAddress_LeadID='" & Count.ToString & "' LeadAddress_Address='" & row.Item("Address").ToString.Trim.Replace("&", "and") & "' LeadAddress_City='" & row.Item("City").ToString.Trim &
                                             "' LeadAddress_State='" & row.Item("State").ToString.Trim & "' LeadAddress_Country='" & row.Item("Country").ToString &
                                  "' LeadAddress_Pincode='" & row.Item("Pincode").ToString & "' LeadAddress_CreatedId='" & Session("UserId") & "' LeadAddress_CreatedDate='" & DateAndTime.DateString & "' LeadAddress_Del='0' LeadAddress_Status='Active' />")
                            sbcontact.Append("<row LeadContact_Id='" & ContactCount.ToString & "' LeadContact_LeadId='" & Count.ToString &
                                  "' LeadContact_Title='Mr.' LeadContact_Name='" & row.Item("Contact Person 1").ToString.Trim & "' LeadContact_DesigId='0' LeadContact_Email='" & row.Item("Contact Email 1").ToString.Trim & "' LeadContact_MobileNo='" & row.Item("Contact MobileNo 1").ToString.Trim & "' LeadContact_OfficeNo='" & row.Item("Contact OfficeNo 1").ToString.Trim &
                                  "' LeadContact_Extention='" & row.Item("Extention 1").ToString.Trim & "' LeadContact_CreatedID='" & Session("UserId") & "' LeadContact_CreatedDate='" & DateAndTime.DateString &
                                   "' LeadContact_Primary='1' Lead_Del='0' Lead_Status='Active' />")
                            If (String.IsNullOrEmpty(row.Item("Contact Person 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact Email 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact MobileNo 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact OfficeNo 2").ToString.Trim) And String.IsNullOrEmpty(row.Item("Extention 2").ToString.Trim)) Then
                            Else
                                ContactCount = ContactCount + 1
                                sbcontact.Append("<row LeadContact_Id='" & ContactCount.ToString & "' LeadContact_LeadId='" & Count.ToString &
                                  "' LeadContact_Title='Mr.' LeadContact_Name='" & row.Item("Contact Person 2").ToString.Trim & "' LeadContact_DesigId='0' LeadContact_Email='" & row.Item("Contact Email 2").ToString.Trim & "' LeadContact_MobileNo='" & row.Item("Contact MobileNo 2").ToString.Trim & "' LeadContact_OfficeNo='" & row.Item("Contact OfficeNo 2").ToString.Trim &
                                  "' LeadContact_Extention='" & row.Item("Extention 2").ToString.Trim & "' LeadContact_CreatedID='" & Session("UserId") & "' LeadContact_CreatedDate='" & DateAndTime.DateString &
                                   "' LeadContact_Primary='0' Lead_Del='0' Lead_Status='Active' />")
                            End If

                            If (String.IsNullOrEmpty(row.Item("Contact Person 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact Email 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact MobileNo 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Contact OfficeNo 3").ToString.Trim) And String.IsNullOrEmpty(row.Item("Extention 3").ToString.Trim)) Then
                            Else
                                ContactCount = ContactCount + 1
                                sbcontact.Append("<row LeadContact_Id='" & ContactCount.ToString & "' LeadContact_LeadId='" & Count.ToString &
                                  "' LeadContact_Title='Mr.' LeadContact_Name='" & row.Item("Contact Person 3").ToString.Trim & "' LeadContact_DesigId='0' LeadContact_Email='" & row.Item("Contact Email 3").ToString.Trim & "' LeadContact_MobileNo='" & row.Item("Contact MobileNo 3").ToString.Trim & "' LeadContact_OfficeNo='" & row.Item("Contact OfficeNo 3").ToString.Trim &
                                  "' LeadContact_Extention='" & row.Item("Extention 3").ToString.Trim & "' LeadContact_CreatedID='" & Session("UserId") & "' LeadContact_CreatedDate='" & DateAndTime.DateString &
                                   "' LeadContact_Primary='0' Lead_Del='0' Lead_Status='Active' />")
                            End If


                            sbAssign.Append("<row Assignto_ID='" & AssignCount.ToString & "' Assignto_UserID='" & Session("UserId") &
                         "' Assignto_Type='Lead' Assignto_TypeID='" & Count.ToString & "' Assignto_CreatedID='" & Session("UserId") &
                         "' Assignto_CreatedDate='" & DateAndTime.DateString & "' Assignto_ModifiedID='" & Session("UserId") & "' Assignto_ModifiedDate='" & DateAndTime.DateString &
                          "' Assignto_Del='0' Assignto_Status='Active' />")
                            Count = Count + 1
                            ContactCount = ContactCount + 1
                            AddressCount = AddressCount + 1
                            AssignCount = AssignCount + 1
                        End If
                    Next
                    sblead.Append("</root>")
                    sbaddress.Append("</root>")
                    sbcontact.Append("</root>")
                    sbAssign.Append("</root>")
                    Dim errmsg As String = ImportLeadBLL.XMLInsert(sblead.ToString, sbaddress.ToString, sbcontact.ToString, Session("Audlog_Id"), validlead)
                    If Not String.IsNullOrEmpty(errmsg) Then
                        If Not IsNumeric(errmsg) Then
                            Throw New Exception(errmsg)
                        Else
                            AssignToBLL.XMLInsert(sbAssign.ToString, Session("Audlog_Id"), "Lead")
                            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + validlead.ToString + " Leads inserted');window.location='Lead.aspx';", True)
                            Session("dt") = Nothing
                        End If
                    End If
                Else
                    ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Lead to upload!')", True)
                End If
            Else
                ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('There is no Lead to upload!')", True)
            End If
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ImportLead", "btnadd_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportLead", "ImportExcel", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub Check(dt As DataTable, ByVal Filename As String)
        Try
            Dim check As Boolean = False
            If dt.Rows.Count > 0 Then
                Dim leadcol As DataTable = ImportLeadBLL.LeadImporColumn().Tables(0)
                For i As Integer = 0 To dt.Columns.Count - 1
                    check = False
                    For Each col In leadcol.Rows
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
                    Dim leadtypedt As DataTable = MainBLL.Dropdown("LeadTypeDropDown").Tables(0)
                    'Dim stagedt As DataTable = MainBLL.Dropdown("StageDropDown").Tables(0)
                    Dim industrydt As DataTable = MainBLL.Dropdown("IndustryDropDown").Tables(0)
                    Dim companytypedt As DataTable = MainBLL.Dropdown("CompanyTypeDropDown").Tables(0)
                    Dim countrydt As DataTable = MainBLL.Dropdown("CountryDropDown").Tables(0)
                    Dim statedt As DataTable = MainBLL.Dropdown("ALLStateDropDown").Tables(0)
                    Dim Campaigndt As DataTable = MainBLL.Dropdown("CampaignNameDropDown").Tables(0)


                    For Each row As DataRow In dt.Rows
                        If String.IsNullOrEmpty(row.Item("Lead Name").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Lead Name is empty"
                        Else
                            row.BeginEdit()
                            row.Item("Lead Name") = row.Item("Lead Name").ToString.Replace("&", "and")
                            row.Item("Lead Name") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Lead Name").ToString)
                            row.EndEdit()
                        End If
                        If String.IsNullOrEmpty(row.Item("Lead Date").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Lead Date is empty"
                        Else
                            Try
                                Date.Parse(row.Item("Lead Date").ToString)
                                'row.BeginEdit()
                                'Dim formateddate As String = CDate(row.Item("Lead Date").ToString).ToString("yyyy-MM-dd")
                                'row.Item("Lead Date") = formateddate
                                'row.EndEdit()
                            Catch ex As Exception
                                row("Validation") = "Invalid"
                                row("Error") = "Lead Date is invalid"
                            End Try
                        End If
                        If String.IsNullOrEmpty(row.Item("Contact Person 1").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Contact person is empty"
                        End If
                        If String.IsNullOrEmpty(row.Item("Contact Email 1").ToString) And String.IsNullOrEmpty(row.Item("Contact MobileNo 1").ToString) And String.IsNullOrEmpty(row.Item("Contact OfficeNo 1").ToString) Then
                            row("Validation") = "Invalid"
                            row("Error") = "Atleast on contact Info required"
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Contact Email 1").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Contact Email 1").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "EmailId is invalid"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Contact Email 2").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Contact Email 2").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "EmailId is invalid"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Contact Email 3").ToString) Then
                            Dim regex As Regex = New Regex("\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
                            Dim match As Match = regex.Match(row.Item("Contact Email 3").ToString)
                            If Not match.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "EmailId is invalid"
                            End If
                        End If

                        'mobile no 
                        If Not String.IsNullOrEmpty(row.Item("Contact MobileNo 1").ToString) Then
                            If Not IsNumeric(row.Item("Contact MobileNo 1").ToString.Trim.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("+", "")) Then
                                row("Validation") = "Invalid"
                                row("Error") = "Mobile No is invalid"
                            End If
                            '    If Not row.Item("Contact MobileNo").ToString.Length = 10 Then
                            '        row("Validation") = "Invalid"
                            '        row("Error") = "Mobile No is invalid"
                            '    End If
                        End If
                        If Not String.IsNullOrEmpty(row.Item("Lead Website").ToString) Then
                            Dim regexurl As Regex = New Regex("(http(s)?://)?([\w-]+\.)+[\w-]+[.com]+(/[/?%&=]*)?")
                            Dim matchurl As Match = regexurl.Match(row.Item("Lead Website").ToString)
                            If Not matchurl.Success Then
                                row("Validation") = "Invalid"
                                row("Error") = "Website is invalid"
                            End If
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Lead Type").ToString) Then
                            Dim leadtype As Array = leadtypedt.Select("LeadType = '" + row.Item("Lead Type").ToString + "'")
                            If leadtype.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Lead Type") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Lead Type") = leadtype(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Lead Type") = 0
                            row.EndEdit()
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

                        'If Not String.IsNullOrEmpty(row.Item("Stage").ToString) Then
                        '    Dim stage As Array = stagedt.Select("Stage_Name = '" + row.Item("Stage").ToString + "'")
                        '    If stage.Length = 0 Then
                        '        'row("Validation") = "Invalid"
                        '        row.BeginEdit()
                        '        row.Item("Stage") = 1
                        '        row.EndEdit()
                        '    Else
                        '        row.BeginEdit()
                        '        row.Item("Stage") = stage(0)(0).ToString
                        '        row.EndEdit()
                        '    End If
                        'Else
                        '    row.BeginEdit()
                        '    row.Item("Stage") = 0
                        '    row.EndEdit()
                        'End If

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

                        If Not String.IsNullOrEmpty(row.Item("Country").ToString) Then
                            Dim country As Array = countrydt.Select("CountryName = '" + row.Item("Country").ToString + "'")
                            If country.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("Country") = 105
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("Country") = country(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("Country") = 105
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("State").ToString) Then
                            Dim state As Array = statedt.Select("StateName = '" + row.Item("State").ToString + "'")
                            If state.Length = 0 Then
                                'row("Validation") = "Invalid"
                                row.BeginEdit()
                                row.Item("State") = 0
                                row.EndEdit()
                            Else
                                row.BeginEdit()
                                row.Item("State") = state(0)(0).ToString
                                row.EndEdit()
                            End If
                        Else
                            row.BeginEdit()
                            row.Item("State") = 0
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

                        If Not String.IsNullOrEmpty(row.Item("Address").ToString) Then
                            row.BeginEdit()
                            row.Item("Address") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Address"))
                            row.EndEdit()
                        End If

                        If Not String.IsNullOrEmpty(row.Item("Lead TurnOver").ToString) Then
                            row.BeginEdit()
                            row.Item("Lead TurnOver") = DynamicparcelDisplayFunctions.CleanAddress(row.Item("Lead TurnOver"))
                            row.EndEdit()
                        End If

                        For Each item As DataColumn In dt.Columns
                            If Not (row(item).ToString = row.Item("Lead Date").ToString Or row(item).ToString = row.Item("Contact Email 1").ToString Or row(item).ToString = row.Item("Contact Email 2").ToString Or row(item).ToString = row.Item("Contact Email 3").ToString Or row(item).ToString = row.Item("Lead Website").ToString) Then
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
            ExecptionBLL.Insert("ImportLead", "Check", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportLead", "btnupload_Click", error1, Session("UserId"))
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
            ExecptionBLL.Insert("ImportLead", "GridView1_PageIndexChanging", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Public Sub countvalid(dt As DataTable)
        Try
            Dim validlead As Integer = dt.Select("Validation = 'Valid'").Length
            Dim invalidlead As Integer = dt.Select("Validation = 'Invalid'").Length
            lblinvalidlead.Visible = True
            lblvalidlead.Visible = True
            lblinvalidlead.Text = "Total Invalid Leads: " + invalidlead.ToString
            lblvalidlead.Text = "Total Valid Leads: " + validlead.ToString
        Catch ex As Exception
            Dim error1 As String = ex.Message.Replace(Chr(34), "")
            error1 = error1.Replace(Chr(39), "")
            ExecptionBLL.Insert("ImportLead", "countvalid", error1, Session("UserId"))
            ScriptManager.RegisterStartupScript(Page, Me.[GetType](), "Call", "alert('" + (error1.ToString).ToString + "')", True)
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblinvalidlead.Visible = False
        lblvalidlead.Visible = False

    End Sub
End Class
