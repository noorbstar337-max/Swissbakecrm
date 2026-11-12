<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="false" CodeFile="CreateMultiPO.aspx.vb" Inherits="CreateMultiPO" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    

    <script src="js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            
            calculateFinalPrice()

        });

        
        function calculateFinalPrice() {
            ; debugger
         <%--   var checkedBoxesCount = $("<%=GridSelInv.ClientID%>").find("input:checkbox:checked").length;
            if (checkedBoxesCount == 0)
            {
                $('.btnpay').hide();
            }
            else {
                $('.btnpay').show();
            }--%>

            //alert("NO CHECKBOX SELECTED");
            var Grid_Table = document.getElementById('<%= GridView1.ClientID%>');
            if (Grid_Table != null) {
                $('.btnpay').hide();
                var checkBoxes = Grid_Table.getElementsByTagName("input");
                var pay = 0.0;
                var freight = 0.0;
                var count = 0
                var grdcellcount = $('.mT>tbody>tr>th').length - 1;
                for (var row = 0; row < Grid_Table.rows.length - 1; row++) {
                    //if (Grid_Table.rows[row].cells[0].checked) {
                    if (checkBoxes[row].checked) {

                        freight = freight + parseFloat(Grid_Table.rows[row + 1].cells[8].textContent.split("(")[0].replace(/[^0-9.]/g, ""));
                        pay = pay + parseFloat(Grid_Table.rows[row + 1].cells[9].textContent.split("(")[0].replace(/[^0-9.]/g, ""));
                       
                        count = count + 1;
                        if (count >1) {
                            $('.btnpay').show();
                        }
                        else {

                            $('.btnpay').hide();
                        }
                        //if (checkBoxes[row].checked) {
                        //    $('.btnpay').show();
                        //}
                        //else {

                        //    $('.btnpay').hide();
                        //}
                    }
                    // Grid_Table.rows[Grid_Table.rows.length].cells[7].innerHTML = "<hr style='border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;'>" + "<b><i class='fa fa-rupee'></i> " + Math.round(pay).toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,') + "</b>";
                }

                $('.totalpay').text(Math.round(pay).toFixed(2));
                $('.totalfreight').text(Math.round(freight).toFixed(2));

            }
            else {
                $('.btnpay').hide();
            }
        }


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfsubtotal" runat="server" />
    <asp:HiddenField ID="hfquantity" runat="server" />
    <asp:HiddenField ID="hftotalq" runat="server" />
    <asp:HiddenField ID="hfvat" runat="server" />
    <asp:HiddenField ID="hfgrand" runat="server" />

    
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%-- <i class="hi hi-tasks" style="margin: -8px"></i>Modify Task<br>--%>
                    New Sale Order
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="polist.aspx">PO List</a></li>
                <li>
                   Create PO</li>
                <%-- <li>Modify Task</li>--%>
            </ul>
            <div class="col-md-12">
                <div class="widget" style="display:table; width:100%">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Create</strong> Purchase Order
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-12">
                              
                                    <div class="col-md-2">
                                        <label class="control-label" for="example-hf-password">Vendor Name:</label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddvendor" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen" data-toggle="tooltip" title="Select Vendo" TabIndex="1"></asp:DropDownList>
                                    <br />
                                       <br /> 
                                    </div>
                               
                                
                                
                                </div> 
                             <div class="col-md-12" runat="server" id="divgrid" visible="false" >
                           Quotation Details:  <span  class="text-danger">(NOTE In order to create PO there should be more than 1 Quotation Selected)</span>
                            
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" DataKeyNames="QuotationRequest_No" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter mT" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                     <asp:TemplateField HeaderText="Select QR" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                             <asp:CheckBox ID="CheckBox1" runat="server" onclick="calculateFinalPrice()" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="QR-No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hpsponsor" EnableViewState="false" NavigateUrl='<%# "ViewQuotationResponse.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString())) & "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                               <asp:Literal ID="lblQRNo1" runat="server" Text='<%#Eval("QuotationRequest_No")%>' />
                                            </asp:HyperLink>
                                             <asp:Literal ID="LblR" runat="server" Text='<%#Eval("QuotationRequest_ID")%>' Visible="false" />
                                                <asp:Literal ID="LblV" runat="server" Text='<%#Eval("Vendor_Id")%>' Visible="false" />
                                                <asp:Literal ID="lblid" runat="server" Text='<%#Eval("QuotationRequest_No")%>' Visible="false" />
                                                <asp:Literal ID="lblQRNo" runat="server" Text='<%#Eval("QuotationRequest_No")%>' Visible="false"  />
                                                  <asp:Literal ID="lblrespid" runat="server" Text='<%#Eval("QuotationResponse_ID")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vendor-Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblVendorName" runat="server" Text='<%#Eval("Vendor_Name")%>' />
                                            <asp:Literal ID="ltname" runat="server" Visible="false" Text='<%#(Eval("Vendor_Name"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Raw-Material" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblRMName" runat="server" Text='<%#Eval("Rm_Name")%>' />
                                            <asp:Literal ID="lblRMID" runat="server" Text='<%#Eval("Rm_ID")%>' Visible="false" />
                                            <asp:Literal ID="lblQResponse_Code" runat="server" Text='<%#Eval("QuotationResponse_Code")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblQty" runat="server" Text='<%#Eval("Quantity")%>' />
                                            <asp:Literal ID="lblQty1" runat="server" Text='<%#Eval("Quantity")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblAmount" runat="server" Text='<%#Convert.ToDouble(Eval("Amount")).ToString("#,##0.00")%>' />
                                            <asp:Literal ID="lblAmount1" runat="server" Text='<%#Eval("Amount")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Per-Unit" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblPerUnit" runat="server" Text='<%#Convert.ToDouble(Eval("Per_Unit")).ToString("#,##0.00")%>' />
                                            <asp:Literal ID="lblPerUnit1" runat="server" Text='<%#Eval("Per_Unit")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTax" runat="server" Text='<%#Convert.ToDouble(Eval("Tax")).ToString("#,##0.00")%>' />
                                            <asp:Literal ID="lblTax1" runat="server" Text='<%#Eval("Tax")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Freight" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblFreight" runat="server" Text='<%#Convert.ToDouble(Eval("Freight")).ToString("#,##0.00")%>' />
                                            <asp:Literal ID="lblFreight1" runat="server" Text='<%#Eval("Freight")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <i class="fa fa-inr "></i>&nbsp;
                                            <asp:Literal ID="lblTotal" runat="server" Text='<%#Convert.ToDouble(Eval("Total")).ToString("#,##0.00")%>' />
                                            <asp:Literal ID="lblTotal1" runat="server" Text='<%#Eval("Total")%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblStatus" runat="server" Text='<%#Eval("QuotationResponse_Status")%>' />
                                            <asp:Literal ID="lblstatus1" runat="server" Text='<%#(Eval("QuotationResponse_Status"))%>' Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="false">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkAction" runat="server">Action</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approved" class="btn btn-success" runat="server"
                                                    CommandName="Approvedink" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Approve</asp:LinkButton>
                                                <asp:LinkButton ID="lnkPO" data-toggle="tooltip" title="Create PO" class="btn btn-warning" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Creating PO...';"
                                                    CommandName="createPO" CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>Create PO</asp:LinkButton>
                                                <%--  <asp:LinkButton ID="LnkViewPO" data-toggle="tooltip" title="View PO" class="btn btn-info" runat="server"  OnClientClick="aspnetForm.target ='_blank';"
                                                    CommandName="ViewPo"  CommandArgument='<%#Eval("QuotationRequest_ID").ToString() + ","+Eval("Vendor_Id").ToString() %>'>View PO</asp:LinkButton>--%>

                                                <a id="LnkViewPO" runat="server" data-toggle="tooltip" title="View PO" class="btn btn-alt btn-xs btn-success" href='<%#"Purchaseorder.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("QuotationRequest_ID").ToString)) + "&VId=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Vendor_Id").ToString))%>' target="_blank"><i class="fa fa-print"></i>&nbsp;View PO</a>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                             <div style="color: black; float: right; margin: 4px 0 0 0;">
                Total Freight : ₹
                <asp:Label ID="Label1" CssClass="totalfreight" runat="server"></asp:Label>

            <br />
                               
                Total Amount : ₹
                <asp:Label ID="invpayamt1" CssClass="totalpay" runat="server"></asp:Label>

            </div>

                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <%--<asp:PostBackTrigger ControlID="btnsave" />--%>
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        
              </div>
              
                   
                  
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
                        <ProgressTemplate>
                            <br />
                            <div class="divWaiting">
                                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
             <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                     <asp:Button Text="Save" runat="server" ID="btnsave" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary  btnpay" ValidationGroup="MasterGroup" TabIndex="13" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/SalesOrders.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="14" />
                </div>
            </div>
    </div>
        </div>
</asp:Content>

