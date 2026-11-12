<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="OpportunityStage.aspx.vb" Inherits="OpportunityStage" %>
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
                        <i class="fa fa-signal" style="margin: -8px"></i>Opportunity Stage<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Opportunity Stage</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Opportunity Stage</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <User:SearchBar ID="SearchControl" runat="server" />

                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:HiddenField ID="hfcheck" runat="server" />
                        <asp:HiddenField ID="hfchanged" runat="server" />
                        <asp:HiddenField ID="hfseq" runat="server" />
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="OppStage_ID" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter " OnSorting="GridView1_Sorting" AlternatingRowStyle-CssClass="Alternate_grid"
                                AllowPaging="True" PageSize="10" AllowSorting="True" >
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="OppStage_ID" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("OppStage_ID"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sequence No." HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="OppStage_Sequence">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblSequence" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("OppStage_Sequence"), SearchControl.UtxtSearch)%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stage Name" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="OppStage_Name">
                                        <ItemTemplate>
                                          <asp:Label  ID="ltnamesss" runat="server" style="color:white;padding: 0 10px;border-radius: 3px;" BackColor='<%#(System.Drawing.Color.FromName(Eval("OppStage_ColorBand").ToString))%>'   Text='<%#DynamicparcelGridview.HighlightText(Eval("OppStage_Name"), SearchControl.UtxtSearch)%>'></asp:Label>
                                             <asp:Literal ID="ltname" runat="server" Text='<%#Eval("OppStage_Name")%>' Visible="false"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Probability" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="OppStage_Probability">
                                        <ItemTemplate>
                                            <asp:Literal ID="ltprodddb" runat="server"  Text='<%#DynamicparcelGridview.HighlightText(Eval("OppStage_Probability"), SearchControl.UtxtSearch)%>'></asp:Literal>%
                                             <asp:Literal ID="ltprob" runat="server" Text='<%#Eval("OppStage_Probability")%>' Visible="false"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Open/Close" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="OppStage_OpenClose">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblopenclose" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("OppStage_OpenClose"), SearchControl.UtxtSearch)%>' />
                                            <asp:Literal ID="ltopenclose" runat="server" Visible="false" Text='<%#(Eval("OppStage_OpenClose"))%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="OppStage_Status" ItemStyle-Width="25">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk" CssClass='<%#Security.checkStatus(Eval("OppStage_Status"))%>' runat="server" Text='<%#Eval("OppStage_Status")%>'
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
                                        <asp:LinkButton ID="btnNo" class="close" runat="server" OnClick="btnNo_Click1">&times;</asp:LinkButton>
                                        <h3 class="modal-title"><asp:Label ID="lblheading" runat="server"></asp:Label> </h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="example-nf-email">Stage Name <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtStagename" runat="server" placeholder="Enter Stage Name" data-toggle="tooltip" title="Enter Stage Name" TabIndex ="1"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtStagename" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter stage name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblname" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Probability <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtprob" runat="server" placeholder="Probability" data-toggle="tooltip" title="Probability" TabIndex ="2"
                                                CssClass="form-control" TextMode="Number"  ></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reprob" runat="server" ControlToValidate="txtprob" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter probability" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtprob" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter valid probability" SetFocusOnError="true" MinimumValue="0" MaximumValue="100" Type="Integer" ></asp:RangeValidator>
                                         </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Color Band <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtcolor" runat="server" placeholder="" data-toggle="tooltip" title="" TabIndex ="2"
                                                CssClass="form-control" TextMode="Color"  ></asp:TextBox>
                                         </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Sequence Number <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtsequence" runat="server" placeholder="Enter Sequence Number" data-toggle="tooltip" title="Enter Sequence Number" TabIndex ="1"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="reseq" runat="server" ControlToValidate="txtsequence" Display="Dynamic" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter sequence number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                            <asp:Label ID="lblseq" CssClass="MasterValidationCSS" runat="server"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label for="example-nf-email">Stage Status <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddlopen" runat="server" name="Stage Status" class="form-control" TabIndex="3">
                                            <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                            <asp:ListItem Text="Close" Value="Close"></asp:ListItem>                                            
                                        </asp:DropDownList>
                                         </div>
                                    </div>
                                    <div class="modal-footer">
                                        <%--   <asp:Button ID="btnNo" runat="server" Text="Close" class="btn btn-sm btn-default"></asp:Button>--%>
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                            UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save" TabIndex="4"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <asp:PostBackTrigger ControlID="btnsave" />
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

