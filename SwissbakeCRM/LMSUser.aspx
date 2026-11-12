<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="LMSUser.aspx.vb" Inherits="LMSUser" %>

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
                <%--<div class="header-section">--%>
                <h3>
                    <i class="gi gi-user" style="margin-left: 25px;"></i>User
                </h3>
                <%--</div>--%>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="LMSdashboard.aspx">Home</a></li>
                <li>User</li>
            </ul>
                        <div class="block">
                <div class="block-title">
                    <h2><strong>User</strong> Detail</h2>
                </div>
    <%--        <div class="col-md-12">
                <div class="widget">--%>
                  <%--  <div class="widget-extra themed-background-dark">
                        <h5 class="widget-content-light abc"><strong></strong> </h5>
                    </div>--%>
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
                                        <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="U_ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Literal ID="lbluId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_ID"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="U_FirstName">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLinkname" EnableViewState="false" NavigateUrl='<%# "ModifyLMSUser.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'
                                                    runat="server" Style="font-weight: normal;">
                                                    <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("U_FirstName"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="Designation" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Desig_Name">
                                            <ItemTemplate>
                                                <asp:Literal ID="lbldesig" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("Desig_Name")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false" HeaderText="Department" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Deprt_Name">
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
                                                    <%--<asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'--%>
                                                    <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyLMSUser.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("U_ID").ToString()))%>'
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
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton><h3 class="modal-title">
                                                <asp:Label ID="lblheading" runat="server"></asp:Label></h3>
                                        </div>
                                        <div class="modal-body">
                                            <div class="form-group">
                                                <label for="example-nf-email">Role <span class="text-danger">*</span></label>
                                                <asp:DropDownList ID="ddllevel" runat="server" data-toggle="tooltip" title="Role" CssClass="form-control" TabIndex="5">
                                                    <asp:ListItem Value="0">Select Role</asp:ListItem>
                                                    <asp:ListItem Value="1">Admin</asp:ListItem>
                                                    <asp:ListItem Value="2">R & D</asp:ListItem>
                                                    <asp:ListItem Value="3">Lab Technician</asp:ListItem>
                                                    <asp:ListItem Value="4">Factory Lab Technician</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="relevel" runat="server" ControlToValidate="ddllevel" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="This is required." InitialValue="0" SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Name <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtuname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter User Name" TabIndex="1"
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtuname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="This is required." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Name" data-toggle="tooltip" title="Enter Email Name" TabIndex="2"
                                                    CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="rgemail" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="reemail" runat="server" ControlToValidate="txtemail" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="This is required." SetFocusOnError="true"></asp:RequiredFieldValidator><asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Password <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtnewpass" runat="server" placeholder="Enter New Password" data-toggle="tooltip" title="Enter New Password"
                                                    CssClass="form-control" TabIndex="3" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="rqusername" runat="server" ControlToValidate="txtnewpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="This is required." Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Confirm Password <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtconfirm" runat="server" placeholder="Enter Confirm Password" data-toggle="tooltip" title="Enter Confirm Password"
                                                    CssClass="form-control" TabIndex="4" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtnewpass" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                        ErrorMessage="This is required." Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator><asp:CompareValidator ID="cvpass" runat="server" ErrorMessage="Password does not match" ControlToValidate="txtconfirm" ControlToCompare="txtnewpass" Operator="Equal"
                                                            ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic"></asp:CompareValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="example-nf-email">Mobile <span class="text-danger">*</span></label>
                                                <asp:TextBox ID="txtMobile" runat="server" placeholder="Enter Mobile" data-toggle="tooltip" title="Enter User Name" TabIndex="1"
                                                    CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfMobile" runat="server" ControlToValidate="txtMobile" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="This is required." SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="remob" runat="server" ValidationExpression="^[()0-9 +-]{10}$" CssClass="MasterValidationCSS" ValidationGroup="MasterGroup"
                                                    ErrorMessage="Please enter valid mobile number" ControlToValidate="txtMobile" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>
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
            <%--</div>--%>

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


