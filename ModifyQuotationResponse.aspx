<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyQuotationResponse.aspx.vb" Inherits="ModifyQuotationResponse" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
          
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="QuotationRequest.aspx">Quotation Response</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
 
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Quotation.aspx" class="btn btn-alt btn-sm btn-danger"/>
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">

        <div class="widget-extra themed-background-dark">
       <h4 class="widget-content-light">
        <strong>Quotation Response</strong> Information
              </h4>
           </div>
        
        <br />
        <div class="form-horizontal form-bordered">

                    <div class="form-group">
                        <div class="col-md-12">
                            <div class="col-md-6">
                               <asp:Label runat="server" class="col-md-3" Text="Company Name"></asp:Label>
                               <div class="col-md-9">
                                    <asp:TextBox runat="server"  ID="txt1"  ValidationGroup ="test1" CssClass="form-control" placeholder=" Enter Company Name"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ControlToValidate ="txt1" ValidationGroup ="MasterGroup" ErrorMessage ="Enter Company Name" ForeColor ="Red" ></asp:RequiredFieldValidator>
                                </div>
                                <br />
                                <br />
                                <asp:Label runat="server" class="col-md-3" Text="Date"></asp:Label>
                               <div class="col-md-9">
                                    <asp:TextBox runat="server"  id="txt2" CssClass="form-control "  TextMode ="Date"  placeholder="Date"></asp:TextBox>
                                   <asp:RequiredFieldValidator runat="server" ControlToValidate ="txt2" ErrorMessage ="Enter Date" ValidationGroup ="MasterGroup" ForeColor ="Red" ></asp:RequiredFieldValidator>
                                </div>
                               </div>
                            <div class="col-md-6">
                                 <asp:Label runat="server" class="col-md-3" Text="Amount"></asp:Label>
                               <div class="col-md-9">
                                    <asp:TextBox runat="server" id="txt8"  CssClass="form-control " placeholder="Entrer Amount"></asp:TextBox>
                                      <asp:RequiredFieldValidator runat="server" ControlToValidate ="txt8" ValidationGroup ="MasterGroup" ErrorMessage ="Enter Amount" ForeColor ="Red" ></asp:RequiredFieldValidator>
                                  
                                </div>
                               
                                   <asp:Label runat="server" class="col-md-3" Text="Status"></asp:Label>
                               <div class="col-md-9">
                                    <asp:TextBox runat="server" id="TextBox1"  CssClass="form-control " placeholder="Entrer Status"></asp:TextBox>
                                      <asp:RequiredFieldValidator runat="server" ControlToValidate ="TextBox1" ValidationGroup ="MasterGroup" ErrorMessage ="Enter Status" ForeColor ="Red" ></asp:RequiredFieldValidator>
                                  
                                </div>

                             
                      


                          
                        </div>
                             <br />
                            <br />

                                <div class="col-md-12">
                                <User:AssignControl ID="assigncontrol1" runat="server" />
                            </div>
                          
                            <br />
                            <br />
                            </div> 
                    
                        </div>
                    
                </div>
       
        
        </div>
            </div>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="14" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/QuotationRequest.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="15" />
                </div>
            </div>

        </div>
    </div>
</asp:Content>
