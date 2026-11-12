Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading

'Imports System.Runtime.Serialization


Partial Class PrintDocs
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim type As String
    Public dsReport As New DataSet
    Public dtReport, dt1, dt2 As New DataTable
    Public reportHead As String = ""
    Public doc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    'Dim mergeDt As New CrystalDecisions.Shared.MIReportDataSet
    Dim CrExportOptions As ExportOptions
    Dim cryRpt As New ReportDocument()
    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
    Dim TcsApplicable As Boolean = False

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        GenetrateReport()
    End Sub
    'Public Sub ExportTOPdf(pid As Integer)
    '    Dim crConnectionInfo As New ConnectionInfo()



    '    Dim CrExportOptions As New ExportOptions()
    '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
    '    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
    '    ' Dim dtRow, dtRow1 As New DataTable()



    '    Dim dsreport As New DataSet
    '    dsreport.Tables.Add("CryRt_CustBill")
    '    dsreport.Tables.Add("CryRt_CustShip")
    '    dsreport.Tables.Add("CryRt_QtnItems")
    '    Dim dt1 As New DataTable("CryRt_CustBill")
    '    Dim dt2 As New DataTable("CryRt_CustShip")
    '    Dim dt3 As New DataTable("CryRt_QtnItems")

    '    'dt1 = QuotationBLL.crystaldetails("crystalbilladdr", 601).Tables(0)
    '    'dt2 = QuotationBLL.crystaldetails("crystalshipaddr", 601).Tables(0)
    '    'dt3 = QuotationBLL.crystaldetails("crystalQtnExpItem", 42).Tables(0)


    '    dt1 = QuotationBLL.crystaldetails("crystalbilladdr", 659).Tables(0)
    '    dt2 = QuotationBLL.crystaldetails("crystalshipaddr", 659).Tables(0)
    '    dt3 = QuotationBLL.crystaldetails("crystalQtnExpItem", 24).Tables(0)

    '    '  dsreport.Merge(dt1)
    '    dsreport.Tables("CryRt_CustBill").Merge(dt1)
    '    dsreport.Tables("CryRt_CustShip").Merge(dt2)
    '    dsreport.Tables("CryRt_QtnItems").Merge(dt3)

    '    '  QuotationID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
    '    Dim CustId As Integer = QuotationBLL.GetCustId(pid)

    '    cryRpt.Load(Server.MapPath("") + "\CrystalReport\qtnExp.rpt")


    '    'string str = Server.MapPath("") + "\\App_Data\\TATAPGA.mdb";
    '    ' Dim str As String = Server.MapPath("") + "\App_Data"


    '    Dim host As String = HttpContext.Current.Request.Url.Host

    '    'If host = "localhost" Then
    '    '   cryRpt.SetDatabaseLogon("sa", "Acaira@123", "SERVER", "db_swissbake")
    '    ' Else
    '    cryRpt.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "dbswissbake")

    '    ' End If

    '    cryRpt.SetDataSource(dsreport)
    '    cryRpt.Subreports.Item("AccShipAddr").SetDataSource(dsreport.Tables("crystalshipaddr"))
    '    cryRpt.Subreports.Item("QtnItems").SetDataSource(dsreport.Tables("crystalQtnExpItem"))
    '    cryRpt.VerifyDatabase()

    '    CrExportOptions = cryRpt.ExportOptions
    '    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
    '    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions
    '    CrExportOptions.FormatOptions = CrFormatTypeOptions
    '    'string output = Server.MapPath("") + "\\" + dt3.Rows[0]["Quotation_No"].ToString() + ".pdf";
    '    Dim filename As String = dt3.Rows(0)("Quotation_No").ToString()
    '    filename = filename.Replace(",", " ")
    '    filename = filename.Replace("/", "")

    '    Dim output As String = (Convert.ToString(Server.MapPath("") + "\") & filename) + ".pdf"
    '    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, output)
    '    cryRpt.Close()
    '    cryRpt.Dispose()
    '    '  DownloadNDelete(output)

    'End Sub
    Public Sub GenetrateReport()
        If Request.QueryString("tpy") = "Quotation" Then
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
            Try

                Dim dsreport As New DataSet
                dsreport.Tables.Add("CryRt_CustBill")
                dsreport.Tables.Add("CryRt_CustShip")
                dsreport.Tables.Add("CryRt_QtnItems")
                Dim dt1 As New DataTable("CryRt_CustBill")
                Dim dt2 As New DataTable("CryRt_CustShip")
                Dim dt3 As New DataTable("CryRt_QtnItems")

                'dt1 = QuotationBLL.crystaldetails("crystalbilladdr", 601).Tables(0)
                'dt2 = QuotationBLL.crystaldetails("crystalshipaddr", 601).Tables(0)
                'dt3 = QuotationBLL.crystaldetails("crystalQtnExpItem", 42).Tables(0)


                Dim CustId As Integer = QuotationBLL.GetCustId(MainID)
                dt1 = QuotationBLL.crystaldetails("crystalbilladdr", CustId).Tables(0)
                dt2 = QuotationBLL.crystaldetails("crystalshipaddr", CustId).Tables(0)
                dt3 = QuotationBLL.crystaldetails("crystalQtnExpAllItem", MainID).Tables(0)

                If Not String.IsNullOrEmpty(dt3.Rows(0)("Tcs_Amount").ToString()) Then
                    If (Convert.ToInt32(dt3.Rows(0)("Tcs_Amount")) > 0) Then
                        TcsApplicable = True
                    End If
                End If



                '  dsreport.Merge(dt1)
                dsreport.Tables("CryRt_CustBill").Merge(dt1)
                dsreport.Tables("CryRt_CustShip").Merge(dt2)

                'dt3.Rows(0)("Quotation_FlightNo") = dt3.Rows(0)("BankId")
                'dt3.AcceptChanges()

                dsreport.Tables("CryRt_QtnItems").Merge(dt3)
                'If dsReport.Tables(0).Rows.Count > 0 Then



                If type = "USD" Then
                    doc.Load(Server.MapPath("\CrystalReport\QtnExp.rpt"))
                ElseIf type = "EURO" Then
                    doc.Load(Server.MapPath("\CrystalReport\QtnExp.rpt"))
                Else
                    If (TcsApplicable = True) Then
                        doc.Load(Server.MapPath("\CrystalReport\TCSQtnDom.rpt"))
                    Else
                        doc.Load(Server.MapPath("\CrystalReport\QtnDom.rpt"))
                    End If
                End If
                '  reportBLL.FixDatabase(doc)
                '  doc.SetDatabaseLogon(reportBLL.dbUser, reportBLL.dbPass, reportBLL.serverName, reportBLL.dbName)
                Dim host As String = HttpContext.Current.Request.Url.Host

                'doc.VerifyDatabase()
                'If host = "localhost" Then
                ' doc.SetDatabaseLogon("sa", "Acaira@123", "SERVER", "db_swissbake")
                ' Else
                doc.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "NewDBswissbake")

                ' End If



                doc.SetDataSource(dsreport)
                doc.Subreports.Item("AccShipAddr").SetDataSource(dsreport.Tables("crystalshipaddr"))
                doc.Subreports.Item("QtnItems").SetDataSource(dsreport.Tables("CryRt_QtnItems")) 'doc.Subreports.Item("QtnItems").SetDataSource(dsreport.Tables("crystalQtnExpItem"))
                'doc.Refresh()
                ''Bank detail


                ' ==============================
                ' COMPANY DETAILS - MAIN REPORT
                ' ==============================

                If dt3.Rows.Count > 0 Then

                    Dim CompanyName As String =
        Convert.ToString(dt3.Rows(0)("Company_Name"))

                    'Dim CompanyAddress As String =
                    'Convert.ToString(dt3.Rows(0)("Company_Address"))
                    Dim CompanyAddress As String =
    Convert.ToString(dt3.Rows(0)("Company_Address")) _
    .Replace("<br />", Environment.NewLine) _
    .Replace("<br/>", Environment.NewLine) _
    .Replace("<br>", Environment.NewLine)
                    'Company_EmailId
                    Dim CompanyEmailId As String =
                        Convert.ToString(dt3.Rows(0)("Company_EmailId"))
                    Dim CompanyGST As String =
                    Convert.ToString(dt3.Rows(0)("Company_GST"))
                    Dim CompanyPAN As String =
                        Convert.ToString(dt3.Rows(0)("Company_PAN"))
                    Dim CompanyState As String =
                        Convert.ToString(dt3.Rows(0)("Company_StateName"))

                    SetCrystalParameter(doc, "Company_Name", CompanyName)
                    SetCrystalParameter(doc, "Company_Address", CompanyAddress)
                    SetCrystalParameter(doc, "Company_EmailId", CompanyEmailId)
                    SetCrystalParameter(doc, "Company_GST", CompanyGST)
                    SetCrystalParameter(doc, "Company_PAN", CompanyPAN)
                    SetCrystalParameter(doc, "Company_StateID", CompanyState)


                End If

                Dim BankId As Integer = 0

                If dt3.Rows.Count > 0 Then

                    If dt3.Columns.Contains("BankId") AndAlso
       Not IsDBNull(dt3.Rows(0)("BankId")) Then

                        Integer.TryParse(
            dt3.Rows(0)("BankId").ToString(), BankId
                )

                    End If

                End If

                'Verify every subreport actually receives data
                '----------------------------------------
                'For Each sr As ReportDocument In doc.Subreports
                '	Response.Write(sr.Name & "<br>")
                '	Response.Write("Tables : " & sr.Database.Tables.Count & "<br>")
                'Next
                'Response.End()

                SetBankDetails(BankId)
                'end bank detail

                'Response.End()

                'DISPLAYS  CRYSTAL PARAMETERS COUNT
                ' For Each p As CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition In doc.DataDefinition.ParameterFields
                ' Response.Write(p.Name & " = " & p.CurrentValues.Count & "<br>")
                ' Next

                ' Response.Write("<hr>" & "For Each SubReport" & "<br>")


                ' For Each sr As ReportDocument In doc.Subreports

                ' Response.Write("<hr>" & sr.Name & "<br>")

                ' For Each p As CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition In sr.DataDefinition.ParameterFields
                ' Response.Write(p.Name & " = " & p.CurrentValues.Count & "<br>")
                ' Next

                ' Next

                ' Response.End()


                ' CHECKING CRYSTAL ACTUAL REPORT NAME
                ' -----------------------------------------------------------------
                ' For Each sr As ReportDocument In doc.Subreports
                ' Response.Write(sr.Name & "<br>")
                ' Next

                ' Response.End()


                'CHECK CRYSTAL PARAMETERS
                ' -----------------------------------------------------------------
                'For Each p As CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition In doc.DataDefinition.ParameterFields
                '	Response.Write("<br>" & p.Name)
                'Next
                'Response.End()


                'It immediately tells which parameters still have no values.
                '==========================================================
                ' For Each p As CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition In doc.DataDefinition.ParameterFields

                ' If p.CurrentValues.Count = 0 Then
                ' Response.Write("Missing : " & p.Name & "<br>")
                ' Else
                ' Response.Write("OK : " & p.Name & "<br>")
                ' End If

                ' Next

                ' Response.End()


                ' For Each sr As CrystalDecisions.CrystalReports.Engine.ReportDocument In doc.Subreports

                ' Response.Write("<hr><b>" & sr.Name & "</b><br>")

                ' For Each p As CrystalDecisions.CrystalReports.Engine.ParameterFieldDefinition In sr.DataDefinition.ParameterFields

                ' If p.CurrentValues.Count = 0 Then
                ' Response.Write("Missing : " & p.Name & "<br>")
                ' Else
                ' Response.Write("OK : " & p.Name & "<br>")
                ' End If

                ' Next

                ' Next

                ' Response.End()



                CrExportOptions = doc.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportDestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                    '.ExportFormatType = ExportFormatType.PortableDocFormat
                End With

                Dim pdfPath As String = Server.MapPath("PrintDocs/")

                'Try
                '    doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, Server.MapPath("").ToString() & "\GeneratePdfReport\Agreement.pdf")
                '    ' doc.ExportToDisk(ExportFormatType.PortableDocFormat, pdfPath.ToString & "\Agreement.pdf")
                'Catch ex As Exception
                '    Dim str As String = ex.ToString
                'End Try

                Dim filename As String = dt3.Rows(0)("Quotation_No").ToString()
                filename = filename.Replace(",", " ")
                filename = filename.Replace("/", "")

                Dim output As String = (Convert.ToString(Server.MapPath("") + "\PrintDocs\") & filename) + ".pdf"

                ' Try
                ' doc.Refresh()
                ' Catch ex As Exception
                ' Response.Write(ex.ToString())
                ' Response.End()
                ' End Try

                doc.ExportToDisk(ExportFormatType.PortableDocFormat, output)


                ' Response.Redirect("~\PrintDocs\" + filename + ".pdf", False)
                ' '  Response.Redirect(output, True)

                ' DownloadNDelete(output)
                doc.Dispose()
                DownloadNDelete1(output, "")
                'System.IO.File.Delete(output)
                'doc.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response,True, "Report")
            Catch ex As System.Exception
                Throw ex
            End Try
            '      ElseIf Request.QueryString("tpy") = "Proforma" Then
            '          MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '          type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
            '          Try

            '              If type = "USD" Then

            '                  'doc.Load(Server.MapPath("\CrystalReport\ProformaExp.rpt"))
            '              Else
            '                  doc.Load(Server.MapPath("\CrystalReport\ProformaDom.rpt"))
            '              End If

            '              Dim host As String = HttpContext.Current.Request.Url.Host

            '              'If host = "localhost" Then
            '              ' doc.SetDatabaseLogon("sa", "Acaira@123", "SERVER", "db_swissbake")
            '              ' Else
            '              doc.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "NewDBswissbake")

            '              ' End If


            '              Dim dsreport As New DataSet
            '              dsreport.Tables.Add("CryRt_CustBill")
            '              dsreport.Tables.Add("CryRt_CustShip")
            '              dsreport.Tables.Add("CryRt_QtnItems")
            '              dsreport.Tables.Add("CryRt_Proforma")
            '              Dim dt1 As New DataTable("CryRt_CustBill")
            '              Dim dt2 As New DataTable("CryRt_CustShip")
            '              Dim dt3 As New DataTable("CryRt_QtnItems")
            '              Dim dt4 As New DataTable("CryRt_Proforma")

            '              'dt1 = QuotationBLL.crystaldetails("crystalbilladdr", 601).Tables(0)
            '              'dt2 = QuotationBLL.crystaldetails("crystalshipaddr", 601).Tables(0)
            '              'dt3 = QuotationBLL.crystaldetails("crystalQtnExpItem", 42).Tables(0)


            '              Dim CustId As Integer = QuotationBLL.GetCustId(MainID)
            '              dt1 = QuotationBLL.crystaldetails("crystalbilladdr", CustId).Tables(0)
            '              dt2 = QuotationBLL.crystaldetails("crystalshipaddr", CustId).Tables(0)
            '              dt3 = QuotationBLL.crystaldetails("crystalQtnExpAllItem", MainID).Tables(0)
            '              dt4 = ProformaBLL.crystalProforma("crystalProforma", MainID).Tables(0)

            '              '  dsreport.Merge(dt1)
            '              dsreport.Tables("CryRt_CustBill").Merge(dt1)
            '              dsreport.Tables("CryRt_CustShip").Merge(dt2)
            '              dsreport.Tables("CryRt_QtnItems").Merge(dt3)
            '              dsreport.Tables("CryRt_Proforma").Merge(dt4)

            '              'If dsReport.Tables(0).Rows.Count > 0 Then

            '              doc.SetDataSource(dsreport)
            '              doc.Subreports.Item("AccShipAddr").SetDataSource(dsreport.Tables("crystalshipaddr"))
            '              doc.Subreports.Item("QtnItems").SetDataSource(dsreport.Tables("crystalQtnExpItem"))
            '              'doc.Refresh()

            '              ''Bank detail


            '' ' BELOW CODE IS FOR CHECK dsreport TABLE DETAILS
            '' '===========================================
            '	' If dsreport Is Nothing Then

            '			' Response.Write("dsreport is Nothing")

            '		' Else

            '			' Response.Write("Tables Count : " & dsreport.Tables.Count & "<br><br>")

            '			' For Each tbl As DataTable In dsreport.Tables

            '				' Response.Write("<b>Table : " & tbl.TableName & "</b><br>")
            '				' Response.Write("Rows : " & tbl.Rows.Count & "<br>")

            '				' If tbl.Rows.Count > 0 Then

            '					' For Each col As DataColumn In tbl.Columns
            '						' Response.Write(col.ColumnName & " : " &
            '									   ' tbl.Rows(0)(col.ColumnName).ToString() & "<br>")
            '					' Next

            '				' End If

            '				' Response.Write("<hr>")

            '			' Next

            '		' End If

            '		'Response.End()


            '              Dim BankId As Integer = 0

            '						If dt4.Rows.Count > 0 AndAlso
            '		   dt4.Columns.Contains("BankId") AndAlso
            '		   Not IsDBNull(dt4.Rows(0)("BankId")) Then

            '							Integer.TryParse(
            '				dt4.Rows(0)("BankId").ToString(),
            '				BankId
            '			)

            '              End If



            '              'If BankId not available in Proforma then take from Quotation
            '              If BankId = 0 AndAlso dt3.Rows.Count > 0 Then

            '                  If dt3.Columns.Contains("BankId") AndAlso
            '     Not IsDBNull(dt3.Rows(0)("BankId")) Then

            '                      Integer.TryParse(
            '          dt3.Rows(0)("BankId").ToString(),
            '          BankId
            '      )

            '                  End If

            '              End If

            '              SetBankDetails(BankId)

            '		'Response.Write("After Bank Details")
            '		'Response.End
            '              ''end bank detail
            '              doc.VerifyDatabase()
            '              CrExportOptions = doc.ExportOptions
            '              With CrExportOptions
            '                  .ExportDestinationType = ExportDestinationType.DiskFile
            '                  .ExportDestinationOptions = CrDiskFileDestinationOptions
            '                  .FormatOptions = CrFormatTypeOptions

            '                  '.ExportFormatType = ExportFormatType.PortableDocFormat
            '              End With



            '		' For Each p As ParameterFieldDefinition In doc.DataDefinition.ParameterFields
            '			' Response.Write("MAIN : " & p.Name & "<br>")
            '		' Next

            '		' For Each sr As ReportDocument In doc.Subreports

            '			' Response.Write("<hr>" & sr.Name & "<br>")

            '			' For Each p As ParameterFieldDefinition In sr.DataDefinition.ParameterFields
            '				' Response.Write("SUB : " & p.Name & "<br>")
            '			' Next

            '		' Next

            '		' Response.End()






            '              Dim pdfPath As String = Server.MapPath("PrintDocs/")

            '              'Try
            '              '    doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, Server.MapPath("").ToString() & "\GeneratePdfReport\Agreement.pdf")
            '              '    ' doc.ExportToDisk(ExportFormatType.PortableDocFormat, pdfPath.ToString & "\Agreement.pdf")
            '              'Catch ex As Exception
            '              '    Dim str As String = ex.ToString
            '              'End Try

            '              Dim filename As String = dt4.Rows(0)("Proforma_No").ToString()
            '              filename = filename.Replace(",", " ")
            '              filename = filename.Replace("/", "")

            '              Dim output As String = (Convert.ToString(Server.MapPath("") + "\PrintDocs\") & filename) + ".pdf"

            '              doc.ExportToDisk(ExportFormatType.PortableDocFormat, output)


            '              ' Response.Redirect("~\Emaildocs\" + filename + ".pdf", False)
            '              ' '  Response.Redirect(output, True)

            '              ' DownloadNDelete(output)

            '              doc.Dispose()
            '              DownloadNDelete1(output, "")
            '          Catch ex As  System.Exception
            '              'Throw ex

            '			Response.Write(ex.Message)

            '			If ex.InnerException IsNot Nothing Then
            '				Response.Write("<br>" & ex.InnerException.Message)
            '			End If

            '			Response.End()

            '          End Try


            '     ElseIf Request.QueryString("tpy") = "Proforma" Then


            '         MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '         type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
            '         Dim path1 As String = "", path2 As String = ""
            '         Dim tblBank As New DataTable("tblBank")
            '         Try

            '             If type = "USD" Then
            '                 doc.Load(Server.MapPath("\CrystalReport\ProformaExp.rpt"))
            '             Else
            '                 doc.Load(Server.MapPath("\CrystalReport\ProformaDom.rpt"))
            '             End If

            '             Dim host As String = HttpContext.Current.Request.Url.Host

            '             doc.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "NewDBswissbake")

            '             Dim dsreport As New DataSet
            '             dsreport.Tables.Add("CryRt_CustBill")
            '             dsreport.Tables.Add("CryRt_CustShip")
            '             dsreport.Tables.Add("CryRt_QtnItems")
            '             dsreport.Tables.Add("CryRt_Proforma")

            '             Dim dt1 As New DataTable("CryRt_CustBill")
            '             Dim dt2 As New DataTable("CryRt_CustShip")
            '             Dim dt3 As New DataTable("CryRt_QtnItems")
            '             Dim dt4 As New DataTable("CryRt_Proforma")

            '             Dim CustId As Integer = QuotationBLL.GetCustId(MainID)

            '             dt1 = QuotationBLL.crystaldetails("crystalbilladdr", CustId).Tables(0)
            '             dt2 = QuotationBLL.crystaldetails("crystalshipaddr", CustId).Tables(0)

            '             dt3 = QuotationBLL.crystaldetails("crystalQtnExpAllItem", MainID).Tables(0)
            '             dt4 = ProformaBLL.crystalProforma("crystalProforma", MainID).Tables(0)

            '             dsreport.Tables("CryRt_CustBill").Merge(dt1)
            '             dsreport.Tables("CryRt_CustShip").Merge(dt2)
            '             dsreport.Tables("CryRt_QtnItems").Merge(dt3)
            '             dsreport.Tables("CryRt_Proforma").Merge(dt4)

            '             doc.SetDataSource(dsreport)

            '             ' ==============================
            '             ' SET DATASOURCE
            '             ' ==============================

            '             'doc.SetDataSource(dsreport)

            '             doc.Subreports.Item("AccShipAddr").SetDataSource(dsreport.Tables("CryRt_CustShip"))

            '             Dim qtnSubReport As ReportDocument = doc.Subreports.Item("QtnItems")

            '             qtnSubReport.SetDataSource(dsreport.Tables("CryRt_QtnItems"))


            '             ' ==============================
            '             ' BANK DETAIL
            '             ' ==============================

            '             Dim BankId As Integer = 0

            '             ' First get BankId from Proforma
            '             If dt4.Rows.Count > 0 AndAlso
            '                 dt4.Columns.Contains("BankId") AndAlso
            'Not IsDBNull(dt4.Rows(0)("BankId")) Then

            '                 Integer.TryParse(
            '     dt4.Rows(0)("BankId").ToString(),
            '     BankId
            ' )

            '             End If


            '             ' If BankId not available in Proforma then get from Quotation
            '             If BankId = 0 AndAlso
            'dt3.Rows.Count > 0 AndAlso
            'dt3.Columns.Contains("BankId") AndAlso
            'Not IsDBNull(dt3.Rows(0)("BankId")) Then

            '                 Integer.TryParse(
            '     dt3.Rows(0)("BankId").ToString(),
            '     BankId
            ' )

            '             End If


            '             Response.Write("Final BankId = " & BankId.ToString() & "<br/>")


            '             ' ==============================
            '             ' DECLARE BANK VARIABLES
            '             ' ==============================

            '             Dim AccountName As String = ""
            '             Dim BankName As String = ""
            '             Dim AccountNumber As String = ""
            '             Dim BankBranch As String = ""
            '             Dim IFSCCode As String = ""
            '             Dim AccountType As String = "Current"
            '             Dim BankQRCodePath As String = ""


            '             ' ==============================
            '             ' GET BANK DETAILS
            '             ' ==============================

            '             tblBank = MainBLL.GetBankById(BankId).Tables(0)


            '             If tblBank.Rows.Count > 0 Then

            '                 AccountName = Convert.ToString(tblBank.Rows(0)("Description"))

            '                 BankName = Convert.ToString(tblBank.Rows(0)("Name"))

            '                 AccountNumber = Convert.ToString(tblBank.Rows(0)("AccountNum"))

            '                 BankBranch = Convert.ToString(tblBank.Rows(0)("Branch"))

            '                 IFSCCode = Convert.ToString(tblBank.Rows(0)("IFSCCode"))


            '                 AccountType = "Current"

            '                 BankQRCodePath =
            '     Server.MapPath("~/images/BankQRCode/" & Convert.ToString(tblBank.Rows(0)("QRCode")) & ".png")

            '             Else

            '                 AccountName = "Swiss Bake Ingredients Pvt. Ltd."

            '                 BankName = "Kotak Bank"

            '                 AccountNumber = "7411221116"

            '                 BankBranch = "Mumbai Central"

            '                 IFSCCode = "KKBK0001348"

            '                 AccountType = "Current"

            '                 BankQRCodePath =
            '     Server.MapPath("~/images/BankQRCode/KOTAK_Bank.png")

            '             End If


            '             ' ==============================
            '             ' MAIN REPORT PARAMETERS
            '             ' ==============================

            '             SetCrystalParameter(doc, "BankName", BankName)

            '             SetCrystalParameter(doc, "AccountNumber", AccountNumber)

            '             SetCrystalParameter(doc, "BankBranch", BankBranch)

            '             SetCrystalParameter(doc, "IFSCCode", IFSCCode)

            '             SetCrystalParameter(doc, "AccountType", AccountType)

            '             SetCrystalParameter(doc, "BankQRCodePath", BankQRCodePath)

            '             SetCrystalParameter(doc, "AccountName", AccountName)

            '             SetCrystalParameter(doc, "BankId", CLng(BankId))


            '             ' ==============================
            '             ' QTNITEMS SUBREPORT PARAMETERS
            '             ' ==============================

            '             SetCrystalParameter(qtnSubReport, "BankName", BankName)

            '             SetCrystalParameter(qtnSubReport, "AccountNumber", AccountNumber)

            '             SetCrystalParameter(qtnSubReport, "BankBranch", BankBranch)

            '             SetCrystalParameter(qtnSubReport, "IFSCCode", IFSCCode)

            '             SetCrystalParameter(qtnSubReport, "AccountType", AccountType)

            '             SetCrystalParameter(qtnSubReport, "BankQRCodePath", BankQRCodePath)

            '             SetCrystalParameter(qtnSubReport, "AccountName", AccountName)

            '             SetCrystalParameter(qtnSubReport, "BankId", CLng(BankId))
            '             '' ==============================
            '             '' End Bank Detail
            '             '' ==============================

            '             ' doc.VerifyDatabase()

            '             CrExportOptions = doc.ExportOptions

            '             With CrExportOptions
            '                 .ExportDestinationType = ExportDestinationType.DiskFile
            '                 .ExportDestinationOptions = CrDiskFileDestinationOptions
            '                 .FormatOptions = CrFormatTypeOptions
            '             End With

            '             Dim pdfPath As String = Server.MapPath("PrintDocs/")

            '             Dim filename As String = dt4.Rows(0)("Proforma_No").ToString()

            '             filename = filename.Replace(",", " ")
            '             filename = filename.Replace("/", "")

            '             Dim output As String =
            '                 (Convert.ToString(Server.MapPath("") + "\PrintDocs\") & filename) + ".pdf"


            '             Response.Write("<h2>MAIN REPORT PARAMETERS</h2>")

            '             For Each pf As ParameterFieldDefinition In doc.DataDefinition.ParameterFields

            '                 Response.Write("Parameter: " & pf.Name & "<br/>")

            '                 If pf.CurrentValues.Count = 0 Then
            '                     Response.Write("<b style='color:red'>MISSING VALUE</b><br/>")
            '                 Else

            '                     For Each val As ParameterValue In pf.CurrentValues

            '                         If TypeOf val Is ParameterDiscreteValue Then

            '                             Dim dv As ParameterDiscreteValue =
            '         DirectCast(val, ParameterDiscreteValue)

            '                             Response.Write(
            '         "Value: " &
            '         Server.HtmlEncode(Convert.ToString(dv.Value)) &
            '         "<br/>"
            '     )

            '                         End If

            '                     Next

            '                 End If

            '                 Response.Write("<hr/>")

            '             Next




            '             doc.ExportToDisk(ExportFormatType.PortableDocFormat, output)

            '             doc.Dispose()

            '             DownloadNDelete1(output, "")

            '         Catch ex As System.Exception

            '             Throw ex

            '         End Try

        ElseIf Request.QueryString("tpy") = "Proforma" Then


            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
            Dim path1 As String = "", path2 As String = ""
            Dim tblBank As New DataTable("tblBank")
            Try

                If type = "USD" Then
                    doc.Load(Server.MapPath("\CrystalReport\ProformaExp.rpt"))
                Else
                    doc.Load(Server.MapPath("\CrystalReport\ProformaDom.rpt"))
                End If

                Dim host As String = HttpContext.Current.Request.Url.Host

                doc.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "NewDBswissbake")

                Dim dsreport As New DataSet
                dsreport.Tables.Add("CryRt_CustBill")
                dsreport.Tables.Add("CryRt_CustShip")
                dsreport.Tables.Add("CryRt_QtnItems")
                dsreport.Tables.Add("CryRt_Proforma")

                Dim dt1 As New DataTable("CryRt_CustBill")
                Dim dt2 As New DataTable("CryRt_CustShip")
                Dim dt3 As New DataTable("CryRt_QtnItems")
                Dim dt4 As New DataTable("CryRt_Proforma")

                Dim CustId As Integer = QuotationBLL.GetCustId(MainID)

                dt1 = QuotationBLL.crystaldetails("crystalbilladdr", CustId).Tables(0)
                dt2 = QuotationBLL.crystaldetails("crystalshipaddr", CustId).Tables(0)

                dt3 = QuotationBLL.crystaldetails("crystalQtnExpAllItem", MainID).Tables(0)
                dt4 = ProformaBLL.crystalProforma("crystalProforma", MainID).Tables(0)

                dsreport.Tables("CryRt_CustBill").Merge(dt1)
                dsreport.Tables("CryRt_CustShip").Merge(dt2)
                dsreport.Tables("CryRt_QtnItems").Merge(dt3)
                dsreport.Tables("CryRt_Proforma").Merge(dt4)

                doc.SetDataSource(dsreport)

                ' ==============================
                ' SET DATASOURCE
                ' ==============================

                doc.SetDataSource(dsreport)

                doc.Subreports.Item("AccShipAddr").SetDataSource(
                    dsreport.Tables("CryRt_CustShip")
                )

                Dim qtnSubReport As ReportDocument =
                    doc.Subreports.Item("QtnItems")

                qtnSubReport.SetDataSource(
                    dsreport.Tables("CryRt_QtnItems")
                )


                ' ==============================
                ' BANK DETAIL
                ' ==============================

                Dim BankId As Integer = 0

                ' First get BankId from Proforma
                If dt4.Rows.Count > 0 AndAlso
                   dt4.Columns.Contains("BankId") AndAlso
                   Not IsDBNull(dt4.Rows(0)("BankId")) Then

                    Integer.TryParse(
                        dt4.Rows(0)("BankId").ToString(),
                        BankId
                    )

                End If


                ' If BankId not available in Proforma then get from Quotation
                If BankId = 0 AndAlso
                   dt3.Rows.Count > 0 AndAlso
                   dt3.Columns.Contains("BankId") AndAlso
                   Not IsDBNull(dt3.Rows(0)("BankId")) Then

                    Integer.TryParse(
                        dt3.Rows(0)("BankId").ToString(),
                        BankId
                    )

                End If


                Response.Write(
                    "Final BankId = " &
                    BankId.ToString() &
                    "<br/>"
                )


                ' ==============================
                ' DECLARE BANK VARIABLES
                ' ==============================

                Dim AccountName As String = ""
                Dim BankName As String = ""
                Dim AccountNumber As String = ""
                Dim BankBranch As String = ""
                Dim IFSCCode As String = ""
                Dim AccountType As String = "Current"
                Dim BankQRCodePath As String = ""


                ' ==============================
                ' GET BANK DETAILS
                ' ==============================

                tblBank = MainBLL.GetBankById(BankId).Tables(0)


                If tblBank.Rows.Count > 0 Then

                    AccountName =
                        Convert.ToString(
                            tblBank.Rows(0)("Description")
                        )

                    BankName =
                        Convert.ToString(
                            tblBank.Rows(0)("Name")
                        )

                    AccountNumber =
                        Convert.ToString(
                            tblBank.Rows(0)("AccountNum")
                        )

                    BankBranch =
                        Convert.ToString(
                            tblBank.Rows(0)("Branch")
                        )

                    IFSCCode =
                        Convert.ToString(
                            tblBank.Rows(0)("IFSCCode")
                        )

                    AccountType = "Current"

                    BankQRCodePath =
                        Server.MapPath(
                            "~/images/BankQRCode/" &
                            Convert.ToString(
                                tblBank.Rows(0)("QRCode")
                            ) &
                            ".png"
                        )

                Else

                    AccountName =
                        "Swiss Bake Ingredients Pvt. Ltd."

                    BankName = "Kotak Bank"

                    AccountNumber = "7411221116"

                    BankBranch = "Mumbai Central"

                    IFSCCode = "KKBK0001348"

                    AccountType = "Current"

                    BankQRCodePath =
                        Server.MapPath(
                            "~/images/BankQRCode/KOTAK_Bank.png"
                        )

                End If


                ' ==============================
                ' MAIN REPORT PARAMETERS
                ' ==============================

                SetCrystalParameter(
                    doc,
                    "BankName",
                    BankName
                )

                SetCrystalParameter(
                    doc,
                    "AccountNumber",
                    AccountNumber
                )

                SetCrystalParameter(
                    doc,
                    "BankBranch",
                    BankBranch
                )

                SetCrystalParameter(
                    doc,
                    "IFSCCode",
                    IFSCCode
                )

                SetCrystalParameter(
                    doc,
                    "AccountType",
                    AccountType
                )

                SetCrystalParameter(
                    doc,
                    "BankQRCodePath",
                    BankQRCodePath
                )

                SetCrystalParameter(
                    doc,
                    "AccountName",
                    AccountName
                )

                SetCrystalParameter(
                    doc,
                    "BankId",
                    CLng(BankId)
                )


                ' ==============================
                ' QTNITEMS SUBREPORT PARAMETERS
                ' ==============================

                SetCrystalParameter(
                    qtnSubReport,
                    "BankName",
                    BankName
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "AccountNumber",
                    AccountNumber
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "BankBranch",
                    BankBranch
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "IFSCCode",
                    IFSCCode
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "AccountType",
                    AccountType
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "BankQRCodePath",
                    BankQRCodePath
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "AccountName",
                    AccountName
                )

                SetCrystalParameter(
                    qtnSubReport,
                    "BankId",
                    CLng(BankId)
                )
                '' ==============================
                '' End Bank Detail
                '' ==============================


                ' ==============================
                ' COMPANY DETAILS - MAIN REPORT
                ' ==============================

                If dt3.Rows.Count > 0 Then

                    Dim CompanyName As String =
        Convert.ToString(dt3.Rows(0)("Company_Name"))

                    'Dim CompanyAddress As String =
                    'Convert.ToString(dt3.Rows(0)("Company_Address"))
                    Dim CompanyAddress As String =
    Convert.ToString(dt3.Rows(0)("Company_Address")) _
    .Replace("<br />", Environment.NewLine) _
    .Replace("<br/>", Environment.NewLine) _
    .Replace("<br>", Environment.NewLine)
                    'Company_EmailId
                    Dim CompanyEmailId As String =
                        Convert.ToString(dt3.Rows(0)("Company_EmailId"))
                    Dim CompanyGST As String =
                    Convert.ToString(dt3.Rows(0)("Company_GST"))
                    Dim CompanyPAN As String =
                        Convert.ToString(dt3.Rows(0)("Company_PAN"))
                    Dim CompanyState As String =
                        Convert.ToString(dt3.Rows(0)("Company_StateName"))

                    SetCrystalParameter(doc, "Company_Name", CompanyName)
                    SetCrystalParameter(doc, "Company_Address", CompanyAddress)
                    SetCrystalParameter(doc, "Company_EmailId", CompanyEmailId)
                    SetCrystalParameter(doc, "Company_GST", CompanyGST)
                    SetCrystalParameter(doc, "Company_PAN", CompanyPAN)
                    SetCrystalParameter(doc, "Company_StateID", CompanyState)


                End If
                'END COMAPNY DETAIL
                'doc.VerifyDatabase()

                CrExportOptions = doc.ExportOptions

                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportDestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With

                Dim pdfPath As String = Server.MapPath("PrintDocs/")

                Dim filename As String = dt4.Rows(0)("Proforma_No").ToString()

                filename = filename.Replace(",", " ")
                filename = filename.Replace("/", "")

                Dim output As String =
                    (Convert.ToString(Server.MapPath("") + "\PrintDocs\") & filename) + ".pdf"


                '        Response.Write("<h2>MAIN REPORT PARAMETERS</h2>")

                '        For Each pf As ParameterFieldDefinition In doc.DataDefinition.ParameterFields

                '            Response.Write("Parameter: " & pf.Name & "<br/>")

                '            If pf.CurrentValues.Count = 0 Then
                '                Response.Write("<b style='color:red'>MISSING VALUE</b><br/>")
                '            Else

                '                For Each val As ParameterValue In pf.CurrentValues

                '                    If TypeOf val Is ParameterDiscreteValue Then

                '                        Dim dv As ParameterDiscreteValue =
                '    DirectCast(val, ParameterDiscreteValue)

                '                        Response.Write(
                '    "Value: " &
                '    Server.HtmlEncode(Convert.ToString(dv.Value)) &
                '    "<br/>"
                ')

                '                    End If

                '                Next

                '            End If

                '            Response.Write("<hr/>")

                '        Next




                doc.ExportToDisk(ExportFormatType.PortableDocFormat, output)

                doc.Dispose()

                DownloadNDelete1(output, "")

            Catch ex As System.Exception

                Throw ex

            End Try
        ElseIf Request.QueryString("tpy") = "Price" Then
            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            type = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("type")))
            ' MainID = ((Request.QueryString("Id")))
            ' type = (Request.QueryString("type"))
            Try

                'If type = "USD" Then

                '    doc.Load(Server.MapPath("\CrystalReport\ProformaExp.rpt"))
                'Else
                '    doc.Load(Server.MapPath("\CrystalReport\ProformaDom.rpt"))
                'End If
                doc.Load(Server.MapPath("\CrystalReport\PriceList.rpt"))
                Dim host As String = HttpContext.Current.Request.Url.Host

                'If host = "localhost" Then
                ' doc.SetDatabaseLogon("sa", "Acaira@123", "SERVER", "db_swissbake")
                ' Else
                doc.SetDatabaseLogon("swissbake", "qwertyuiop", "103.231.209.42", "NewDBswissbake")

                ' End If


                Dim dsreport As New DataSet
                dsreport.Tables.Add("dtPricelist")

                Dim dt1 As New DataTable("dtPricelist")


                'dt1 = QuotationBLL.crystaldetails("crystalbilladdr", 601).Tables(0)
                'dt2 = QuotationBLL.crystaldetails("crystalshipaddr", 601).Tables(0)
                'dt3 = QuotationBLL.crystaldetails("crystalQtnExpItem", 42).Tables(0)


                '   Dim CustId As Integer = QuotationBLL.GetCustId(MainID)
                dt1 = ProductBLL.ViewPricelist(MainID).Tables(0)

                '  dsreport.Merge(dt1)
                dsreport.Tables("dtPricelist").Merge(dt1)
                '   dsreport.Tables("CryRt_CustShip").Merge(dt2)


                'If dsReport.Tables(0).Rows.Count > 0 Then

                doc.SetDataSource(dsreport)
                'doc.Subreports.Item("AccShipAddr").SetDataSource(dsreport.Tables("crystalshipaddr"))
                doc.Subreports.Item("QtnItems").SetDataSource(dsreport.Tables("dtPricelist"))
                'doc.Refresh()
                doc.VerifyDatabase()
                CrExportOptions = doc.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportDestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions

                    '.ExportFormatType = ExportFormatType.PortableDocFormat
                End With

                Dim pdfPath As String = Server.MapPath("PrintDocs/")

                'Try
                '    doc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, False, Server.MapPath("").ToString() & "\GeneratePdfReport\Agreement.pdf")
                '    ' doc.ExportToDisk(ExportFormatType.PortableDocFormat, pdfPath.ToString & "\Agreement.pdf")
                'Catch ex As Exception
                '    Dim str As String = ex.ToString
                'End Try

                Dim filename As String = type 'dt4.Rows(0)("Proforma_No").ToString()
                filename = filename.Replace(",", " ")
                filename = filename.Replace("/", "")

                Dim output As String = (Convert.ToString(Server.MapPath("") + "\PrintDocs\") & filename) + ".pdf"

                doc.ExportToDisk(ExportFormatType.PortableDocFormat, output)


                ' Response.Redirect("~\PrintDocs\" + filename + ".pdf", False)
                ' '  Response.Redirect(output, True)

                ' DownloadNDelete(output)
                doc.Dispose()
                DownloadNDelete1(output, "")
            Catch ex As System.Exception
                Throw ex
            End Try
            ''===========Purchse Order section=========================
            'ElseIf Request.QueryString("tpy") = "Purchase" Then

            '    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '    Dim VendorID As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VendorID")))

            '    Dim ds As DataSet = MainBLL.QResponseViewByID(MainID, VendorID, "PurchaseOrderProductViewByID")

            '    'Check data
            '    Response.Write("<b>Table Count : </b>" & ds.Tables.Count & "<br/><br/>")

            '    For i As Integer = 0 To ds.Tables.Count - 1

            '        Response.Write("<h3>Table " & i & "</h3>")

            '        If ds.Tables(i).Rows.Count > 0 Then

            '            For Each col As DataColumn In ds.Tables(i).Columns
            '                Response.Write("<b>" & col.ColumnName & "</b> : " &
            '                               ds.Tables(i).Rows(0)(col.ColumnName).ToString() &
            '                               "<br/>")
            '            Next

            '        Else
            '            Response.Write("No Records<br/>")
            '        End If

            '        Response.Write("<hr/>")

            '    Next

            '    Response.End()

            'End If
            ''Noor 
            'ElseIf Request.QueryString("tpy") = "Purchase" Then

            '    MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            '    Dim VendorID As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VendorID")))

            '    'Purchase Order Data
            '    Dim ds As DataSet = MainBLL.QResponseViewByID(MainID, VendorID, "PurchaseOrderProductViewByID")

            '    'Company Data
            '    Dim dsCompany As DataSet = QuotationRequestBLL.FillGridViewByID("emailvendor", MainID)

            '    Response.Write("<h2>Purchase Order Debug Data</h2>")
            '    Response.Write("<hr/>")

            '    '================ Company Details ==================
            '    Response.Write("<h2>Company Details (Fillcompany)</h2>")

            '    If dsCompany.Tables.Count > 0 AndAlso dsCompany.Tables(0).Rows.Count > 0 Then

            '        For Each col As DataColumn In dsCompany.Tables(0).Columns
            '            Response.Write("<b>" & col.ColumnName & "</b> : " &
            '                   dsCompany.Tables(0).Rows(0)(col.ColumnName).ToString() &
            '                   "<br/>")
            '        Next

            '    Else
            '        Response.Write("No Company Data Found.<br/>")
            '    End If

            '    Response.Write("<hr/>")

            '    '================ Purchase Order Dataset ==================
            '    Response.Write("<h2>PurchaseOrderProductViewByID</h2>")
            '    Response.Write("<b>Total Tables : </b>" & ds.Tables.Count & "<br/><br/>")

            '    For i As Integer = 0 To ds.Tables.Count - 1

            '        Response.Write("<h3>Table " & i &
            '               " (Rows : " & ds.Tables(i).Rows.Count & ")</h3>")

            '        If ds.Tables(i).Rows.Count > 0 Then

            '            For r As Integer = 0 To ds.Tables(i).Rows.Count - 1

            '                Response.Write("<div style='background:#efefef;padding:5px;margin-top:10px;'>")
            '                Response.Write("<b>Row " & (r + 1) & "</b>")
            '                Response.Write("</div>")

            '                For Each col As DataColumn In ds.Tables(i).Columns

            '                    Response.Write("<b>" & col.ColumnName & "</b> : " &
            '                           ds.Tables(i).Rows(r)(col.ColumnName).ToString() &
            '                           "<br/>")

            '                Next

            '                Response.Write("<br/>")

            '            Next

            '        Else

            '            Response.Write("No Records<br/>")

            '        End If

            '        Response.Write("<hr/>")

            '    Next

            '    Response.End()


            '    ''===========END Purchase Order section=========================
            'End If
            ''End Noor 
        ElseIf Request.QueryString("tpy") = "Purchase" Then

            MainID = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("Id")))
            Dim VendorID As Integer = Security.Decrypt(HttpUtility.UrlDecode(Request.QueryString("VendorID")))

            '================ Purchase Order Data ==================
            Dim ds As DataSet = MainBLL.QResponseViewByID(
        MainID, VendorID, "PurchaseOrderProductViewByID")

            '================ Company Data =========================
            Dim dsCompany As DataSet = QuotationRequestBLL.FillGridViewByID(
        "emailvendor", MainID)

            '================ Validate Data ========================
            If ds Is Nothing OrElse ds.Tables.Count = 0 Then
                Response.Write("Purchase order data not found.")
                HttpContext.Current.ApplicationInstance.CompleteRequest()
                Return
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                Response.Write("No purchase order records found.")
                HttpContext.Current.ApplicationInstance.CompleteRequest()
                Return
            End If

            '================ Load Crystal Report ==================
            Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument()

            Try
                Dim reportPath As String = Server.MapPath("\CrystalReport\PurchaseOrder.rpt")

                If Not System.IO.File.Exists(reportPath) Then
                    Throw New System.IO.FileNotFoundException(
                "PurchaseOrder.rpt was not found.", reportPath)
                End If

                rpt.Load(reportPath)

                'Bind purchase order dataset
                rpt.SetDataSource(ds)

                'Bind company data if the report contains the Company table
                If dsCompany IsNot Nothing AndAlso
           dsCompany.Tables.Count > 0 AndAlso
           dsCompany.Tables(0).Rows.Count > 0 Then

                    Dim companyTableName As String = dsCompany.Tables(0).TableName

                    If rpt.Database.Tables.
                Cast(Of CrystalDecisions.CrystalReports.Engine.Table)().
                Any(Function(t) String.Equals(
                    t.Name, companyTableName,
                    StringComparison.OrdinalIgnoreCase)) Then

                        rpt.Database.Tables(companyTableName).SetDataSource(
                    dsCompany.Tables(0))
                    End If
                End If

                '================ Export PDF =========================
                Using pdfStream As System.IO.Stream =
            rpt.ExportToStream(
                CrystalDecisions.Shared.ExportFormatType.PortableDocFormat)

                    Response.Clear()
                    Response.Buffer = True
                    Response.ContentType = "application/pdf"
                    Response.AddHeader(
                "Content-Disposition",
                "attachment; filename=PurchaseOrder.pdf")

                    pdfStream.CopyTo(Response.OutputStream)
                    Response.Flush()
                End Using

            Finally
                rpt.Close()
                rpt.Dispose()
            End Try

            HttpContext.Current.ApplicationInstance.CompleteRequest()
            Response.End()
        End If
        '=========== END Purchase Order section ================
    End Sub
    ''============ Bank detail section===============
    Private Sub SetBankDetails(ByVal BankId As Integer)

        'Response.Write("BankId : " & BankId)
        'Response.End()
        'Temparory comment
        ' BankId = 1

        Dim tblBank As DataTable
        Dim bankQRCodePath As String = ""

        tblBank = MainBLL.GetBankById(BankId).Tables(0)


        ' BELOW CODE IS FOR CHECK TBLBANK TABLE DETAILS
        '===========================================
        ' If tblBank Is Nothing Then
        ' Response.Write("tblBank is Nothing")
        ' Else
        ' Response.Write("Rows Count: " & tblBank.Rows.Count)

        ' If tblBank.Rows.Count > 0 Then
        ' Response.Write("<br>Data Found")

        ' 'Display all columns of first row
        ' For Each col As DataColumn In tblBank.Columns
        ' Response.Write("<br>" & col.ColumnName & " : " & tblBank.Rows(0)(col.ColumnName).ToString())
        ' Next
        ' Else
        ' Response.Write("<br>No Records Found")
        ' End If
        ' End If

        ' 'Response.Write(tblBank.Rows(0)("Name") & "<br>")
        ' '	Response.Write("Tables : " & sr.Database.Tables.Count & "<br>")
        ' 'Next
        ' Response.End()



        If tblBank IsNot Nothing AndAlso tblBank.Rows.Count > 0 Then

            bankQRCodePath = Server.MapPath(
            "~/images/BankQRCode/" &
            Convert.ToString(tblBank.Rows(0)("QRCode")) &
            ".png"
        )

            Dim sr As ReportDocument = doc.Subreports("QtnItems")

            'Try
            '    doc.SetParameterValue("AccountName", "Sl Ayyubi")
            'Catch ex As System.Exception
            '    Throw New System.Exception("AccountName : " & ex.Message)
            'End Try


            'Try
            '    doc.SetParameterValue("BankName", "Federal Bank")
            'Catch ex As System.Exception
            '    Throw New System.Exception("BankName : " & ex.Message)
            'End Try


            'Try
            '    doc.SetParameterValue("AccountNumber", "2332423424")
            'Catch ex As System.Exception
            '    Throw New System.Exception("AccountNumber : " & ex.Message)
            'End Try


            'Try
            '    doc.SetParameterValue("BankBranch", "Bandra")
            'Catch ex As System.Exception
            '    Throw New System.Exception("BankBranch : " & ex.Message)
            'End Try


            'Try
            '    doc.SetParameterValue("IFSCCode", "456456456")
            'Catch ex As System.Exception
            '    Throw New System.Exception("IFSCCode : " & ex.Message)
            'End Try



            'Try
            '    doc.SetParameterValue("AccountType", "Current")
            'Catch ex As System.Exception
            '    Throw New System.Exception("AccountType : " & ex.Message)
            'End Try



            'Try
            '    doc.SetParameterValue("BankId", "1")
            'Catch ex As System.Exception
            '    Throw New System.Exception("BankId : " & ex.Message)
            'End Try



            'Try
            '    doc.SetParameterValue("BankQRCodePath", "WRWWRWERWERWER")
            'Catch ex As System.Exception
            '    Throw New System.Exception("BankQRCodePath : " & ex.Message)
            'End Try

            Try
                doc.SetParameterValue("AccountName", Convert.ToString(tblBank.Rows(0)("Description")), "QtnItems")

            Catch ex As System.Exception
                Throw New System.Exception("AccountName : " & ex.Message)
            End Try

            Try
                doc.SetParameterValue("BankName", Convert.ToString(tblBank.Rows(0)("Name")), "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("BankName : " & ex.Message)
            End Try



            Try
                doc.SetParameterValue("AccountNumber", Convert.ToString(tblBank.Rows(0)("AccountNum")), "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("AccountNumber : " & ex.Message)
            End Try


            Try
                doc.SetParameterValue("BankBranch", Convert.ToString(tblBank.Rows(0)("Branch")), "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("BankBranch : " & ex.Message)
            End Try



            Try
                doc.SetParameterValue("IFSCCode", Convert.ToString(tblBank.Rows(0)("IFSCCode")), "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("IFSCCode : " & ex.Message)
            End Try



            Try
                doc.SetParameterValue("AccountType", "Current", "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("AccountType : " & ex.Message)
            End Try



            Try
                doc.SetParameterValue("BankId", BankId, "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("BankId : " & ex.Message)
            End Try



            Try
                doc.SetParameterValue("BankQRCodePath", bankQRCodePath, "QtnItems")
            Catch ex As System.Exception
                Throw New System.Exception("BankQRCodePath : " & ex.Message)
            End Try


            'doc.SetParameterValue("BankName", "Federal Bank")

            'doc.SetParameterValue("AccountNumber","12112211335664")

            'doc.SetParameterValue("BankBranch","Bandra")

            'doc.SetParameterValue("IFSCCode","67845664564")

            'doc.SetParameterValue("AccountType", "Current")
            'doc.SetParameterValue("BankId", "44")
            'doc.SetParameterValue("BankQRCodePath", "erwrwrrwrw")

            ' doc.SetParameterValue("AccountName",
            ' Convert.ToString(tblBank.Rows(0)("Description")))

            ' doc.SetParameterValue("BankName",
            ' Convert.ToString(tblBank.Rows(0)("Name")))

            ' doc.SetParameterValue("AccountNumber",
            ' Convert.ToString(tblBank.Rows(0)("AccountNum")))

            ' doc.SetParameterValue("BankBranch",
            ' Convert.ToString(tblBank.Rows(0)("Branch")))

            ' doc.SetParameterValue("IFSCCode",
            ' Convert.ToString(tblBank.Rows(0)("IFSCCode")))

            ' doc.SetParameterValue("AccountType", "Current")
            ' doc.SetParameterValue("BankId", BankId)
            ' doc.SetParameterValue("BankQRCodePath", bankQRCodePath)

        Else


            ' Try
            ' doc.SetParameterValue("AccountName", "Sl Ayyubi","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("AccountName : " & ex.Message)
            ' End Try

            ' Try
            ' doc.SetParameterValue("BankName", "Federal Bank","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("BankName : " & ex.Message)
            ' End Try



            ' Try
            ' doc.SetParameterValue("AccountNumber", "123123132342424","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("AccountNumber : " & ex.Message)
            ' End Try


            ' Try
            ' doc.SetParameterValue("BankBranch", "Worli","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("BankBranch : " & ex.Message)
            ' End Try



            ' Try
            ' doc.SetParameterValue("IFSCCode", "67845664564","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("IFSCCode : " & ex.Message)
            ' End Try



            ' Try
            ' doc.SetParameterValue("AccountType", "Current","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("AccountType : " & ex.Message)
            ' End Try



            ' Try
            ' doc.SetParameterValue("BankId", "44","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("BankId : " & ex.Message)
            ' End Try



            ' Try
            ' doc.SetParameterValue("BankQRCodePath", "erwrwrrwrw","QtnItems")
            ' Catch ex As Exception
            ' Throw New Exception("BankQRCodePath : " & ex.Message)
            ' End Try


            doc.SetParameterValue("AccountName",
                              "Swiss Bake Ingredients Pvt. Ltd.")

            doc.SetParameterValue("BankName", "Kotak Bank")

            doc.SetParameterValue("AccountNumber", "7411221116")

            doc.SetParameterValue("BankBranch", "Mumbai Central")

            doc.SetParameterValue("IFSCCode", "KKBK0001348")

            doc.SetParameterValue("AccountType", "Current")

            doc.SetParameterValue("BankId", BankId)

            doc.SetParameterValue(
            "BankQRCodePath",
            Server.MapPath("~/images/BankQRCode/KOTAK_Bank.png")
      )

        End If

    End Sub

    ''=============End back detail section ===========
    Public Sub DownloadNDelete(sFilePath As String)
        Try
            Response.Clear()
            Response.AddHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(sFilePath))
            Response.ContentType = Path.GetExtension(sFilePath)
            Response.WriteFile(sFilePath)
            Response.Flush()
            Thread.Sleep(2000)
            System.IO.File.Delete(sFilePath)
            'Response.Close();


            Response.[End]()

        Catch ex As System.Exception
        End Try
    End Sub

    Public Sub DownloadNDelete1(sFilePath As String, ByVal barcodePath As String)
        Try
            ' Dim client As New WebClient()
            ' Dim buffer As [Byte]() = client.DownloadData(sFilePath)

            ' If buffer IsNot Nothing Then
            ' Response.ContentType = "application/pdf"
            ' Response.AddHeader("content-length", buffer.Length.ToString())
            ' Response.BinaryWrite(buffer)
            ' End If
            ' System.IO.File.Delete(sFilePath)
            ' System.IO.File.Delete(barcodePath)
            Response.Redirect("/PrintDoc/" + Path.GetFileName(sFilePath).ToString.Replace(".pdf", ""))
        Catch ex As System.Exception
        End Try
    End Sub

    Private Sub SetCrystalParameter(
    ByVal report As ReportDocument,
    ByVal parameterName As String,
    ByVal parameterValue As Object
)

        Dim pf As ParameterFieldDefinition =
        report.DataDefinition.ParameterFields(parameterName)

        pf.CurrentValues.Clear()

        Dim dv As New ParameterDiscreteValue()
        dv.Value = parameterValue

        pf.CurrentValues.Add(dv)

        pf.ApplyCurrentValues(pf.CurrentValues)

    End Sub
End Class
