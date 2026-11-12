<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="User.aspx.vb" Inherits="User" %>

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
                        <i class="gi gi-user" style="margin: -8px"></i>User<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>User</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>User</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="U_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" AllowSorting="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_ID" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lbluId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_ID"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_FirstName">
                                        <ItemTemplate>
                                           <asp:HyperLink ID="HyperLinkname" EnableViewState="false" NavigateUrl='<%# "ModifyUser.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'
                                                     runat="server" style="font-weight: normal;"> <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_FirstName"), SearchControl.UtxtSearch)%>' EnableViewState="false" /></asp:HyperLink> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Desig_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldesig" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Desig_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Deprt_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldept" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Deprt_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="city" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_City">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcity" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_City")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_Mobile">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblcontact" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_Mobile")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmailId" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_Email">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_Email"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Region" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Region_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblregion" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Region_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Reported To" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="ReportedTo">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblreport" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("ReportedTo"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("U_Status"))%>' runat="server" Text='<%#Eval("U_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="View" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink3" runat="server">View</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyUser.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="View" class="btn btn-default" runat="server"><i class="fa fa-eye"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="btn-group btn-group-xs">
                                                <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink5" runat="server">Delete</asp:HyperLink>
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
                            <div class="modal-dialog modal-sm" style="overflow-y: scroll; position: fixed; top: 0; bottom: 0; left: 0; right: 0; overflow: auto; width: 720px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                        <h3 class="modal-title">
                                            <asp:Label ID="lblheading" runat="server"></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="modal-body col-md-12">
                                        <div class="form-group col-md-6">
                                            <label for="example-nf-email">User Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtuname" runat="server" placeholder="Enter User Name" data-toggle="tooltip" title="Enter User Name" TabIndex="1"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtuname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter user name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                         <div class="form-group col-md-6">
                                            <label for="example-nf-email">User Designation <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddludesignation" runat="server" data-toggle="tooltip" title="Designation" CssClass="form-control" TabIndex="2"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvudesignation" runat="server" ControlToValidate="ddludesignation" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please select designation" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                         <div class="form-group col-md-6">
                                            <label for="example-nf-email">User Department <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddludepartment" runat="server" data-toggle="tooltip" title="Department" CssClass="form-control" TabIndex="3"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvudepartment" runat="server" ControlToValidate="ddludepartment" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please select Department" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Name" data-toggle="tooltip" title="Enter Email Name" TabIndex="4"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="rgemail" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="reemail" runat="server" ControlToValidate="txtemail" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter email" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label for="example-nf-email">Password <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtnewpass" runat="server" placeholder="Enter New Password" data-toggle="tooltip" title="Enter New Password"
                                                CssClass="form-control" TabIndex="5" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtnewpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter password" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label for="example-nf-email">Confirm Password <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtconfirm" runat="server" placeholder="Enter Confirm Password" data-toggle="tooltip" title="Enter Confirm Password"
                                                CssClass="form-control" TabIndex="6" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please confirm password" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cvpass" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtconfirm" ControlToCompare="txtnewpass" Operator="Equal"
                                                ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic"></asp:CompareValidator>
                                        </div>
                                        <div class="form-group col-md-6">
                                            <label for="example-nf-email">Role <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddllevel" runat="server" data-toggle="tooltip" title="Role" CssClass="form-control" TabIndex="7"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="relevel" runat="server" ControlToValidate="ddllevel" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select role" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>
                                         <div class="form-group col-md-6">
                                            <label for="example-nf-email">Region <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddlregion" runat="server" data-toggle="tooltip" title="Region" CssClass="form-control" TabIndex="8"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvregion" runat="server" ControlToValidate="ddlregion" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select Region" InitialValue="0" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save" TabIndex="6"></asp:Button>
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

