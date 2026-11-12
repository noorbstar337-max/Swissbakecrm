Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Threading
Imports System.Drawing
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.Net

Partial Class Document
    Inherits _PageBaseClass
    Dim MainID As Integer
    Dim AccID As Integer
    Dim type As String
    Dim InvId As Integer
    Public dsReport As New DataSet
    Public dtReport, dt1, dt2 As New DataTable
    Public reportHead As String = ""
    Public doc As New CrystalDecisions.CrystalReports.Engine.ReportDocument()
    'Dim mergeDt As New CrystalDecisions.Shared.MIReportDataSet
    Dim CrExportOptions As ExportOptions
    Dim cryRpt As New ReportDocument()
    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
    Private bc As New BarcodeLib.Barcode()
    Dim BitBarcode As New Bitmap(120, 80)
    Dim imagepath As String
    Dim invoiceNumber As String
    Public strPrint, strType As String
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ' If Me.Page.RouteData.Values("type") Is Nothing Then
            ' Response.Redirect("https://swissbake.in")
        ' End If
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            Dim sFilePath As String = ((Convert.ToString(Server.MapPath("") + "\PrintDocs\") & Me.Page.RouteData.Values("type")) + ".pdf").Replace("\PrintDoc\", "\")
            Dim barcodePath As String = Server.MapPath("~/images/Barcode/" + Me.Page.RouteData.Values("type") + ".png")
            Dim client As New WebClient()
            Dim buffer As [Byte]() = client.DownloadData(sFilePath)

            If buffer IsNot Nothing Then
				client.Dispose()
                Response.ContentType = "application/pdf"
                Response.AddHeader("content-length", buffer.Length.ToString())
                Response.BinaryWrite(buffer)
            End If
			client.Dispose()
            System.IO.File.Delete(sFilePath)
            System.IO.File.Delete(barcodePath)

        Catch ex As Exception
          '  Response.Redirect("https://swissbake.in")

        End Try
    End Sub

   

    
End Class
