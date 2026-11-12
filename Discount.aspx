<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Discount.aspx.vb" Inherits="Crm_Discount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script type="text/javascript">
        function DiscountRate(txtdiscount) {
            debugger;
          
            var txtDiscountedRate = document.getElementById(txtdiscount.id.replace('txtdiscount', 'txtDiscountedRate'));
            var txtdiscount = document.getElementById(txtdiscount.id.replace('txtdiscount', 'txtdiscount'));
            var lblRate = document.getElementById(txtdiscount.id.replace('txtdiscount', 'lblRate'));
         
            txtDiscountedRate.value = (lblRate.innerText - (lblRate.innerText * txtdiscount.value) / 100).toFixed(2);
           
        };</script>
    <script type="text/javascript">
         function DiscountPercent(txtDiscountedRate) {
             debugger;

             var txtDiscountedRate = document.getElementById(txtDiscountedRate.id.replace('txtDiscountedRate', 'txtDiscountedRate'));
             var txtdiscount = document.getElementById(txtDiscountedRate.id.replace('txtDiscountedRate', 'txtdiscount'));
             var lblRate = document.getElementById(txtDiscountedRate.id.replace('txtDiscountedRate', 'lblRate'));

             txtdiscount.value = ((lblRate.innerText - txtDiscountedRate.value) / lblRate.innerText * 100).toFixed(4);

         };</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="fa fa-inr"></i>Discount<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="_Home.aspx">Home</a></li>
                <li>Discount</li>
            </ul>

            <div class="block" style ="display:table;width:100%;">
                <div class="block-title">
                    <h2><strong>Discount</strong> Detail</h2>
                </div>
                    <div class="col-md-4">
                        <label for="example-nf-email">Type</label>
                        <asp:DropDownList ID="ddtype" runat="server" data-toggle="tooltip" title="Customer Code"  class="select-chosen"  TabIndex ="1" AutoPostBack="true" >
                            <asp:ListItem Text="Prospect" Value="Prospect"></asp:ListItem>
                            <asp:ListItem Text="Account" Value="Account"></asp:ListItem>
                         </asp:DropDownList>
                        <br />
                        <br />
                    </div>
                    <div class="col-md-4">
                        <label for="example-nf-email">Category</label>
                        <asp:DropDownList ID="ddCategory" runat="server" data-toggle="tooltip" title="Customer Code"  class="select-chosen"  TabIndex ="1" AutoPostBack="true" >
                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                            <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                         </asp:DropDownList>
                        <br />
                        <br />
                    </div>
                          <div class="col-md-4">
                        <label for="example-nf-email">Customer Name</label>
                        <asp:DropDownList ID="ddlcustname" runat="server" data-toggle="tooltip" title="Customer Name" class="select-chosen"  TabIndex ="2" AutoPostBack="true" >
                         </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcustname"  ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select customer name" InitialValue ="0" Display ="Dynamic" ></asp:RequiredFieldValidator>
                              
                        <br />
                        <br />
                    </div>
                <div class="col-md-4">
                        <label for="example-nf-email">Customer Code</label>
                        <asp:DropDownList ID="ddlcustid" runat="server" data-toggle="tooltip" title="Customer Code"  class="select-chosen"  TabIndex ="1" AutoPostBack="true" >
                         </asp:DropDownList>
                        <br />
                        <br />
                    </div>      
                <div class="col-md-4" style="display:none;">
                        <label for="example-nf-email">Email Id</label>
                        <asp:DropDownList ID="ddlemail" runat="server" data-toggle="tooltip" title="Email Id" class="select-chosen"  TabIndex ="3" AutoPostBack="true" >
                         </asp:DropDownList>
                        <br />
                        <br />
                    </div>
                   <div class="col-md-4" id="divprod" runat="server">
                        <label for="example-nf-email">Product</label>
                        <asp:DropDownList ID="ddProduct" runat="server" data-toggle="tooltip" title="Email Id" class="select-chosen"  TabIndex ="3" AutoPostBack="true" >
                         </asp:DropDownList>
                        <br />
                        <br />
                    </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div runat="server" id="divflat" class="row">
                            <div class="col-md-4">
                                <label for="example-nf-email">Flat discount over all products</label>
                      <asp:TextBox ID="txtflatdis" runat="server" placeholder="Enter discount(%)" data-toggle="tooltip" title="Flat discount over all products"
                            CssClass="form-control" TabIndex="4"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="rqdis" runat="server" ControlToValidate="txtflatdis" ValidationGroup="flatdis" CssClass="MasterValidationCSS" Display="Dynamic" 
                            ErrorMessage="Please enter discount"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtflatdis" ErrorMessage="Discount should be between 0 to 99" ValidationExpression="^(?:99|\d{1,2})(?:\.\d{1,4})?$" ValidationGroup="flatdis" CssClass="MasterValidationCSS"></asp:RegularExpressionValidator>
                                </div>
                             <div class="col-md-12">
                                 <br />
                                 <asp:Button Text="Apply"  runat="server" ID="btnflatdiscount" OnClientClick="if (!Page_ClientValidate('flatdis')){ return false; } this.disabled = true; this.value = 'Applying...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" style="float: right;" ValidationGroup="flatdis" TabIndex="5"  />
                             <br />    
                             </div>
                        </div>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" DataKeyNames="Product_id"
                                CssClass="table table-striped table-vcenter table-hover" OnSorting="GridView1_Sorting"
                                AllowPaging="False"  AllowSorting="True">
                                <Columns>

                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Product_id" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProductid" runat="server" Text='<%#Eval("Product_id")%>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Product Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Product_Code">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcode" runat="server" Text='<%#Eval("Product_Code")%>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
									  
                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblname" runat="server" Text='<%#Eval("Product_Name") + " - (" + Eval("Product_Code") + ")"%>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SKU" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblpacking" runat="server" Text='<%#Eval("Packing_Packing")%>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Rate" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                            ₹  <asp:Label ID="lblRate" runat="server" Text='<%# (Eval("Product_Rate"))%>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Discounted Rate (₹)" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" >
                                        <ItemTemplate>
                                           <asp:TextBox ID="txtDiscountedRate" runat="server" Text='<%#Convert.ToDouble(Eval("Product_Rate") - (Eval("Product_Rate") * Eval("discount_discount") / 100)).ToString("0.00")%>'  onChange="DiscountPercent(this)" CssClass="decimal " style="text-align:right;"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Discount(%)" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdiscount" runat="server" Text='<%#Eval("discount_discount")%>' onChange="DiscountRate(this)" CssClass="decimal " style="text-align:center;"></asp:TextBox>
                                            <asp:Literal ID="ltCost" runat="server" Text='<%#Eval("Product_Cost")%>' visible="false" />
                                            <asp:Literal ID="ltMargin" runat="server" Text='<%#Eval("Product_Margin")%>' visible="false" /> 
                                            <asp:Literal ID="ltRate" runat="server" Text='<%#Eval("Product_Rate")%>' visible="false" /> 
                                            <br />
                                             <asp:Literal ID="lblERR" runat="server"  />
                                            <asp:CustomValidator ID="CustomValidator1" runat="server" OnServerValidate="valueCheck"  ControlToValidate="txtdiscount" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:CustomValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtdiscount" ErrorMessage="Discount should be between 0 to 99" ValidationExpression="^(?:99|\d{1,2})(?:\.\d{1,4})?$" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" ></asp:RegularExpressionValidator>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />

                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />

                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                            
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="col-md-1 pull-right">
                        <asp:Button Text="Update" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" TabIndex="6" />
                    <br />
                    <br />
                    </div>
                
            </div>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

