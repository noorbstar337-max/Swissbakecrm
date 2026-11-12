<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="LMSRawMaterial.aspx.vb" Inherits="LMSRawMaterial" %>

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
                        <i class="gi gi-globe" style="margin: -8px"></i>LMS Raw Material<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="LMSDashboard.aspx">Home</a></li>
                <li>LMS Raw Material</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Raw Material</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Rm_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True" >
                                <Columns>

                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rm_Id" Visible ="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Id"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Code" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_code">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrawcode" runat="server" Text='<%#DynamicparcelGridview.HighlightText((DynamicparcelDataManipulation.FixNullFromDB(Eval("Rm_Code"))), SearchControl.UtxtSearch)%>' />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Name">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrawname" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Name"), SearchControl.UtxtSearch)%>' />
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rm_Type">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrawtype" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Type"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>

                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Specification" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Desc">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldesc" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Desc"), SearchControl.UtxtSearch)%>' />
                                                                                   </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Brand" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_Brand" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblbrand" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_Brand"), SearchControl.UtxtSearch)%>' />
                                                                                   </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Generic Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="Rm_GenericName" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblGenericName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Rm_GenericName"), SearchControl.UtxtSearch)%>' />
                                                                                   </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status"  Visible="false" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Rm_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("Rm_Status"))%>' runat="server" Text='<%#Eval("Rm_Status")%>'
                                                CommandName="statuslink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit"  Visible="false" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Edit">
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
                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader1" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Delete" Visible="false">
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
                        
                        <asp:Panel ID="pnlPopup" runat="server" Style="display: none" DefaultButton ="btnsave">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <asp:LinkButton ID="btnNo" class="close" runat="server">&times;</asp:LinkButton>
                                        <h3 class="modal-title"><asp:Label ID="lblheading" runat="server"></asp:Label> </h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="example-nf-email">Item Type<span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddItemType" runat="server" data-toggle="tooltip" title="Select Item Type" Enabled="false" CssClass="form-control">
                                                <%--<asp:ListItem CssClass="form-control" Text="Select Item Type" Value="Select Item Type"></asp:ListItem>--%>
                                                <asp:ListItem CssClass="form-control" Text="Raw Material" Value="Raw Material"></asp:ListItem>
                                                <%--<asp:ListItem CssClass="form-control" Text="Consumable Expense" Value="Consumable Expense"></asp:ListItem>--%>
                                                <%--<asp:ListItem CssClass="form-control" Text="Fixed Asset" Value="Fixed Asset"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RValidItemType" runat="server" ControlToValidate="ddItemType" Display="Dynamic" 
                                                ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please Select Item Type" SetFocusOnError="true" InitialValue="Select Item Type"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblItemType" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                    <div class="form-group">
                                            <label for="example-nf-email">Item Code<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtRawmaterialCode" runat="server" placeholder="Enter Item Code" data-toggle="tooltip" title="Enter Item Code" 
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRawmaterialCode" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter Item Code" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="Label1" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>

                                        <div class="form-group">
                                            <label for="example-nf-email">Name<span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtRawmaterialname" runat="server" placeholder="Enter  Name" data-toggle="tooltip" title="Enter  Name" 
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtRawmaterialname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter Name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Remark/Check<span class="text-danger"></span></label>
                                            <asp:TextBox ID="txtbrand" runat="server" placeholder="Enter Remark/Check" data-toggle="tooltip" title="Enter Remark/Check" 
                                                CssClass="form-control"></asp:TextBox>                                                                                
                                        </div>
										<div class="form-group">
											<label for="example-nf-email">Generic Name<span class="text-danger">*</span></label>
											<asp:TextBox ID="txtgenericname" runat="server" placeholder="Enter Generic Name" data-toggle="tooltip" title="Enter Generic Name"
												CssClass="form-control"></asp:TextBox>
											<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtgenericname" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
												ErrorMessage="Please enter Generic Name" SetFocusOnError="true"></asp:RequiredFieldValidator>
										</div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Details/Specification</label>
                                            <asp:TextBox ID="txtdesc" runat="server" placeholder="Enter Details/Specification" data-toggle="tooltip" title="Enter Details/Specification" 
                                                CssClass="form-control"></asp:TextBox>
										</div>
										<div class="form-group">
											<label for="example-nf-email">In Stock</label>
											<asp:TextBox ID="txtinstock" runat="server" placeholder="Enter Stock" data-toggle="tooltip" title="Enter Stock"
												CssClass="form-control"></asp:TextBox>
										</div>
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

