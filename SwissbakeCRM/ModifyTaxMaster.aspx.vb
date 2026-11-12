Imports DynamicparcelEnumerations
Partial Class ModifyTaxMaster
    Inherits System.Web.UI.Page
   
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                ' checktaxradio()
              
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Public Sub checktaxradio()
    '    Try
    '        If rdtax.Checked = True Then
    '            tax_block.Visible = True
    '            addition_block.Visible = False
    '        ElseIf rdaddCharge.Checked = True Then
    '            tax_block.Visible = False
    '            addition_block.Visible = True

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

  
    Protected Sub rdtax_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try

            If rdtax.SelectedValue = "Tax" Then
                tax_block.Visible = True
                addition_block.Visible = False
            ElseIf rdtax.SelectedValue = "Additional Charges" Then
                tax_block.Visible = False
                addition_block.Visible = True
                txtmrpabatement.ReadOnly = True
            Else
                txtmrpabatement.ReadOnly = False
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub checkbox_tax_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
       
            If checkbox_tax.SelectedValue = 3 Then
                taxpercent.Visible = False
                taxamount.Visible = True
            ElseIf checkbox_tax.SelectedValue = Nothing Then
                taxpercent.Visible = True
                taxamount.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
