<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Principle.aspx.vb" Inherits="Principle" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="gi gi-user" style="margin: -8px"></i>Principle<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Principle</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Principle</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Principle_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Principle_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#(Eval("Principle_ID"))%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Company Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Principle_CompanyName">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ViewPrinciple.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Principle_ID").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                            <asp:Literal ID="lblscname" runat="server" Text='<%#(Eval("Principle_CompanyName"))%>' />
                                         </asp:HyperLink>
                                                </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Contact Person" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Principle_ContactPerson">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblconperson" runat="server" Text='<%#(Eval("Principle_ContactPerson"))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Principle_EmailID">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblEmail" runat="server" Text='<%#(Eval("Principle_EmailID"))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mobile no." ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Principle_MobileNo">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblmobile" runat="server" Text='<%#(Eval("Principle_MobileNo"))%>' />

                                            <asp:HiddenField ID="hfphone" Value='<%#Eval("Principle_Phone")%>' runat="server" />

                                            <asp:HiddenField ID="hfaddress" Value='<%#Eval("Principle_Address")%>' runat="server" />
                                            <asp:HiddenField ID="hfcity" Value='<%#Eval("Principle_City")%>' runat="server" />
                                            <asp:HiddenField ID="hfpincode" Value='<%#Eval("Principle_Pincode")%>' runat="server" />
                                            <asp:HiddenField ID="hfcountry" Value='<%#Eval("Principle_Country")%>' runat="server" />
                                            <asp:HiddenField ID="hfstate" Value='<%#Eval("Principle_State")%>' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField Visible="false"  HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Principle_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Principle_Status"))%>' runat="server" Text='<%#Eval("Principle_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>



                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Edit">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkedit" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="HyperLink2" CommandName="editlink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLinkdelete" runat="server">Delete</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
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
                        </div>

                        <asp:LinkButton ID="btnShow" runat="server" />
                        <asp:ModalPopupExtender ID="mpe" runat="server" BehaviorID="mpe" PopupControlID="pnlPopup" TargetControlID="btnShow"
                            CancelControlID="btnNo">
                        </asp:ModalPopupExtender>


                        <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton="btnsave">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                        <h3 class="modal-title">
                                            <asp:Label ID="lblheading" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="modal-body">

                                        <div class="col-md-12">
                                            <label for="example-nf-email">Company name<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtcompanyname" runat="server" placeholder="Enter company name " data-toggle="tooltip" title="Enter company name "
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtcompanyname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter company name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>

                                        <div class="col-md-6">
                                            <label for="example-nf-email">Contact Person <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtconperson" runat="server" placeholder="Enter contact-person " data-toggle="tooltip" title="enter contact person"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="godreq2" runat="server" ControlToValidate="txtconperson" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter contact person" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            
                                        </div>

                                        <div class="col-md-6">
                                            <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email " data-toggle="tooltip" title="Enter email"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtemail" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter email" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" Display="Dynamic" ControlToValidate="txtemail" ValidationGroup="MasterGroup" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                                            

                                        </div>
                                        <div style="clear:both;"></div>
                                        <div class="col-md-6">
                                            <label for="example-nf-email">Mobile no. <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtmob" runat="server" placeholder="Enter  mobile-no" data-toggle="tooltip" title="Enter mobile no."
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtmob" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter mobile no." SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" ValidationGroup="MasterGroup" Display="Dynamic"></asp:RegularExpressionValidator>
                                           
                                        </div>

                                        <div class="col-md-6">
                                            <label for="example-nf-email">Phone no. <span class="text-danger"></span></label>
                                            <asp:TextBox ID="txtofficeno" runat="server" placeholder="Enter Phone Number" data-toggle="tooltip" title="Enter Phone Number"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno"
                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" ValidationGroup="MasterGroup1"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="DemoMasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Enter phone Number" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-12">
                                            <label for="example-hf-email">Address<span class="text-danger"> </span></label>
                                            <asp:TextBox ID="txtaddressbill" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address" TextMode="MultiLine" Rows="2"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="readdressbill" runat="server" ControlToValidate="txtaddressbill" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter address" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>

                                        </div>

                                        <div class="col-md-6">
                                            <label for="example-hf-email">City<span class="text-danger"> </span></label>
                                            <asp:TextBox ID="txtcitybill" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter city"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpincodebill" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter city" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>

                                       
                                        <div class="col-md-6">
                                            <label for="example-hf-password">Pincode<span class="text-danger"> </span></label>
                                            <asp:TextBox ID="txtpincodebill" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtpincodebill" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter pincode" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>                                        

                                    <div style="clear:both ;"></div>
                                      
                                       <div class="col-md-6">
                                            <label for="example-hf-password">Country<span class="text-danger"> </span></label>
                                            <asp:DropDownList ID="ddlcountrybill" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="recountrybill" runat="server" ControlToValidate="ddlcountrybill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-6">                                         
                                            <label class="col-md-3" for="example-hf-password">State<span class="text-danger"> </span></label>                                         
                                            <asp:DropDownList ID="ddlstatebill" runat="server" CssClass="form-control" class="col-md-9"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="restatebill" runat="server" ControlToValidate="ddlstatebill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select state" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>                                     
                                        </div>
                                         <div style="clear:both ;"></div>
                                    </div>                                        
                                    <div class="modal-footer">
                                        <%--   <asp:Button ID="btnNo" runat="server" Text="Close" class="btn btn-sm btn-default"></asp:Button>--%>
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save"></asp:Button>
                                
                                      </div> 
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

