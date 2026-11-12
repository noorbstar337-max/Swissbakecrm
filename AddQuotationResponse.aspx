<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="AddQuotationResponse.aspx.vb" Inherits="AddQuotationResponse" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > . {
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        function checkdelete() {
            if (confirm('Are you Sure want to Delete?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
                return true
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>
    <script>
        //document.getElementById("txttest").onkeyup = function() {myFunction()};
        function onlyNos(e, t) {
            debugger;
            try {
                var cnt = 0;
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    if (charCode == 46) {
                        return true;
                    }
                    else if (charCode == 45) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:HiddenField ID="deletestatus" runat="server" />

    <asp:HiddenField ID="hfamount" runat="server" />
    <asp:HiddenField ID="hftax" runat="server" />
    <asp:HiddenField ID="hffreight" runat="server" />
    <asp:HiddenField ID="hfpaymentterms" runat="server" />
    <asp:HiddenField ID="hfDeliveryTerms" runat="server" />
    <%--  <asp:UpdatePanel runat="server" UpdateMode="Always" ID="UpdatePanel2">
        <ContentTemplate>--%>
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%-- <i class="fa fa-cubes" style="margin: -8px"></i>Modify Quotation<br>--%>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="QuotationRequest.aspx">Quotation</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <%--<li>Modify Quotation</li>--%>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="block-options pull-right">
                    <asp:Button Text="Save" Visible="false" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <%-- <asp:Button Text="Save" runat="server" ID="Button1" />--%>
                    <%--<asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Quotation.aspx" class="btn btn-alt btn-sm btn-danger" OnClick="hfcancel_Click" />--%>
                    <asp:LinkButton ID="HyperLink1" Visible=" false" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-sm btn-danger" />
                    <asp:Button runat="server" ID="btnApprove" class="btn  btn-success" Text="Approve"></asp:Button>
                    <asp:Button runat="server" ID="btnReject" class="btn  btn-warning" Text="Reject"></asp:Button>
                    <asp:Button runat="server" ID="btnRejectAll" class="btn  btn-danger" Text="Reject ALL"></asp:Button>
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Quotation</strong> Request (<asp:Label ID="lblQReqCode" runat="server" Font-Bold="true"></asp:Label>)
                         <small>
                             <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                             </span>
                         </small>
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Quotation No.</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVQNo" runat="server" data-toggle="tooltip" title="Vendor quotation no."
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvdVQNo" runat="server" ControlToValidate="txtVQNo" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Vendor quotation no." Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Vendor<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddVendor" AutoPostBack="true" runat="server" data-toggle="tooltip" title="Vendor" CssClass="form-control">
                                            <%--<asp:ListItem Value="None">None</asp:ListItem>--%>
                                            <%-- <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                                            <asp:ListItem Value="Account">Account</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddVendor" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Vendor" InitialValue="Select Vendor" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Quotation Date</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" data-toggle="tooltip" title=" Date"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <%--               <div class="col-md-4">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">HS Code</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtHSCode" runat="server" data-toggle="tooltip" title=" HS Code" TabIndex="4"
                                                    CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">Pack Size</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtPackSize" runat="server" data-toggle="tooltip" title=" Pack Size" TabIndex="5"
                                                    CssClass="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>--%>

                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-1 control-label" for="example-hf-password">Remarks</label>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtRemark" runat="server" data-toggle="tooltip" title="Remarks" TextMode="MultiLine" Rows="4"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <%-- <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Raw Material</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtRawMaterial" runat="server"  data-toggle="tooltip" title=" Raw Material" TabIndex="4"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>--%>
                            <br />

                            <%-- <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Quantity</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtQuantity" runat="server"  data-toggle="tooltip" title=" Quantity" TabIndex="5"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Unit<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddUnit" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Unit" CssClass="form-control" TabIndex="6">
                                            <asp:ListItem Value="Kg">Kg</asp:ListItem>
                                            <asp:ListItem Value="Each">Each</asp:ListItem>
                                        </asp:DropDownList>
                                   </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Amount</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAmount" runat="server"  data-toggle="tooltip" title=" Amount" TabIndex="7"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Tax</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTax" runat="server"  data-toggle="tooltip" title=" Tax" TabIndex="8"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Freight</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtFreight" runat="server"  data-toggle="tooltip" title=" Freight" TabIndex="9"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Payment Terms</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtPaymentTerms" runat="server"  data-toggle="tooltip" title=" Payment Terms" TabIndex="10"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Remark</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtRemark" runat="server"  data-toggle="tooltip" title=" Remark" TabIndex="11"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>--%>
                            <%--  <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Amount</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtamount" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" TabIndex="12" placeholder="Enter Exp Closing" data-toggle="tooltip" title="Enter Exp Closing"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtQuotationdate" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter amount" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
                            <%--  <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Status<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddStatus" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Status" CssClass="form-control" TabIndex="13">
                                            <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                            <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                            <asp:ListItem Value="Approved">Approved</asp:ListItem>
                                            <asp:ListItem Value="PO Create">PO Create</asp:ListItem>
                                        </asp:DropDownList>
                                   </div>
                                </div>
                            </div>--%>


                            <div style="clear: both"></div>


                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Raw Material</strong> Details
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="">
                                <div class="col-md-12">
                                    <%-- <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always" >
                                                <ContentTemplate>--%>
                                    <div class="table-responsive">
                                        <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                        <asp:HiddenField ID="hfbarcodechk" runat="server" />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                            CssClass="table table-striped table-vcenter table" ShowFooter="true">
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" Visible="false" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="col-md-6" runat="server" visible="false">
                                                            <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="raw Material" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                    <ItemTemplate>
                                                        <div class="input-group  col-md-12">
                                                            <span class="input-group-addon"><i class="gi gi-tags"></i></span>
                                                            <asp:DropDownList ID="ddrawmaterial" runat="server" CssClass="select-chosen"></asp:DropDownList>
                                                            <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("QRRawMaterial_RawID")%>' Visible="false"></asp:Literal>
                                                            <asp:Literal ID="ltqrid" runat="server" Text='<%#Eval("QRRawMaterial_QRDID")%>' Visible="false"></asp:Literal>
                                                            <asp:RequiredFieldValidator ID="rfvddmaterial" runat="server" ControlToValidate="ddrawmaterial" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                                ErrorMessage="Select raw material" InitialValue="Select Raw Material" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                        </div>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                                        <asp:TextBox ID="txtquantity" runat="server" Text='<%#Eval("QRRawMaterial_Quantity")%>' data-toggle="tooltip" CssClass="form-control" OnTextChanged="txtquantity_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvdqty" runat="server" ControlToValidate="txtquantity" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter quantity" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblunite" runat="server" Text='<%#Eval("QRRawMaterial_Unit")%>' Visible="false"></asp:Label>
                                                        <asp:DropDownList ID="ddunuit" runat="server" CssClass="select-chosen">
                                                            <%--<asp:ListItem Value="0" Text="Select Material"></asp:ListItem>--%>
                                                            <asp:ListItem Value="KG" Text="KG"></asp:ListItem>
                                                            <%--<asp:ListItem Value="Numbers" Text="Numbers"></asp:ListItem>--%>
                                                            <asp:ListItem Value="Nos." Text="Nos."></asp:ListItem>
                                                            <asp:ListItem Value="Each" Text="Each"></asp:ListItem>
                                                            <asp:ListItem Value="SqMt" Text="SqMt"></asp:ListItem>
                                                            <asp:ListItem Value="RnMt" Text="RnMt"></asp:ListItem>
                                                            <asp:ListItem Value="Ltr" Text="Ltr"></asp:ListItem>
                                                            <asp:ListItem Value="Unit" Text="Unit"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvddunit" runat="server" ControlToValidate="ddunuit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Select unit" InitialValue="0" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="HS Code" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                                        <asp:TextBox ID="txtHSCode" runat="server" Text='<%#Eval("QuotationResponse_HSCode")%>' data-toggle="tooltip" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvdqty1" runat="server" ControlToValidate="txtHSCode" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter HS Code" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pack Size" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>--%>
                                                        <asp:TextBox ID="txtPackSize" runat="server" Text='<%#Eval("QuotationResponse_PackSize")%>' data-toggle="tooltip" CssClass="form-control"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvdqty2" runat="server" ControlToValidate="txtPackSize" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                            ErrorMessage="Please enter Pack Size" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <%--  <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                            <ItemTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                        CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server"
                                                                        CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="gi gi-plus"></i></asp:LinkButton>
                                                                </div>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>--%>
                                            </Columns>
                                            <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                            <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                            <PagerSettings PageButtonCount="4" />
                                            <%--  <EmptyDataTemplate>
                                                        <h3>Add Receipt Detail</h3>
                                                        <div class="btn-group btn-group-xs" style="align-content: center;">
                                                            <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="100px"
                                                                CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"> Add Receipt</asp:LinkButton>
                                                        </div>
                                                    </EmptyDataTemplate>--%>
                                            <EmptyDataRowStyle HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                    <%--   </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="GridView1" />
                                                </Triggers>
                                            </asp:UpdatePanel>--%>
                                </div>
                                <div style="clear: both;"></div>
                                <br />

                            </div>


                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Other</strong> Details
                        </h4>
                    </div>

                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>

                            <div style="clear: both"></div>
                            <%-- <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Quantity</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtQuantity" runat="server"  data-toggle="tooltip" title=" Quantity" TabIndex="5"
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Unit<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddUnit" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Unit" CssClass="form-control" TabIndex="6">
                                            <asp:ListItem Value="Kg">Kg</asp:ListItem>
                                            <asp:ListItem Value="Each">Each</asp:ListItem>
                                        </asp:DropDownList>
                                   </div>
                                </div>
                            </div>--%>

                            <div class="col-md-4">
                                <div class="">

                                    <label class="col-md-5 control-label" for="example-hf-password">Amount Per Unit<span> <i class="fa fa-inr "></i></span></label>
                                    <div class="col-md-7">
                                        <%-- <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>--%>
                                        <asp:TextBox ID="txtAmountPerUnit" OnKeypress="return onlyNos(event,this);" runat="server" CauseValidation="false" data-toggle="tooltip" title=" Amount Per Unit"
                                            CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAmountPerUnit" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Enter Amount" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <%--</ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="txtAmountPerUnit" EventName="TextChanged" />
                                                    </Triggers>
                                                </asp:UpdatePanel>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Tax (%) </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTaxPercent" OnKeypress="return onlyNos(event,this);" runat="server" data-toggle="tooltip" title=" Tax (%)" AutoPostBack="true"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Freight<span> <i class="fa fa-inr "></i></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtFreight" OnKeypress="return onlyNos(event,this);" runat="server" data-toggle="tooltip" title=" Freight" AutoPostBack="true"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">

                                    <label class="col-md-4 control-label" for="example-hf-password">Amount<span> <i class="fa fa-inr "></i></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAmount" runat="server" data-toggle="tooltip" title=" Amount" Enabled="false"
                                            CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAmount" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                        ErrorMessage="Please Enter Amount" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>




                            <div class="col-md-4">
                                <div class="">

                                    <label class="col-md-4 control-label" for="example-hf-password">Tax<span> <i class="fa fa-inr "></i></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTax" runat="server" data-toggle="tooltip" title=" Tax" Enabled="false"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">

                                    <label class="col-md-4 control-label" for="example-hf-password">Total Amount<span> <i class="fa fa-inr "></i></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtTotalAmt" runat="server" data-toggle="tooltip" title=" Total Amount" Enabled="false"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="">
                                    <br />
                                    <label class="col-md-1 control-label" for="example-hf-password">Payment Terms</label>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtPaymentTerms" runat="server" data-toggle="tooltip" title=" Payment Terms" TextMode="MultiLine" Rows="4"
                                            CssClass="form-control"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="">
                                    <label class="col-md-1 control-label" for="example-hf-password">Delivery Terms</label>
                                    <div class="col-md-11">
                                        <asp:TextBox ID="txtDeliveryTerms" runat="server" data-toggle="tooltip" title="Terms Of Delivery" TextMode="MultiLine" Rows="4"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <%--<User:DocumentControl runat="server" ID="DocumentControl" />--%>
                            <div style="clear: both"></div>
                        </div>
                    </div>

                </div>
            </div>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-sm btn-danger" />
                    <%--<asp:LinkButton ID="LinkButton1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-sm btn-danger" />--%>
                </div>
            </div>

        </div>
    </div>

    <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtAmountPerUnit" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtTaxPercent" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtFreight" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>--%>

    <%--   <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel2" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>

