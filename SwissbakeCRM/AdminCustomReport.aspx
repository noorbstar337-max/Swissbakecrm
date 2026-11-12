<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" EnableEventValidation="false" CodeFile="AdminCustomReport.aspx.vb" Inherits="AdminCustomReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > . {
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#left").bind("click", function () {
                var options = $("[id*=lstRight] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstLeft]").append(opt);
                }
            });
            $("#right").bind("click", function () {
                var options = $("[id*=lstLeft] option:selected");
                for (var i = 0; i < options.length; i++) {
                    var opt = $(options[i]).clone();
                    $(options[i]).remove();
                    $("[id*=lstRight]").append(opt);
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=btnadd]").bind("click", function () {
                $("[id*=lstLeft] option").attr("selected", "selected");
                $("[id*=lstRight] option").attr("selected", "selected");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <%-- <i class="fa fa-cubes" style="margin: -8px"></i>Modify Quotation<br>--%>
                        <asp:Label ID="lbltitle1" Text="Custom Report" runat="server"></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="MainCustomReport.aspx">Admin Custom Report</a></li>
                <li>
                    <asp:Label ID="lbltitle2" Text="Custom Report" runat="server"></asp:Label></li>
                <%--<li>Modify Quotation</li>--%>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Quotation.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Admin Custom Report</strong> Information
                         <small>
                             <span class="pull-right" id="modifyspan" runat="server">&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                             </span>
                         </small>
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-8">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Report Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtreportname" runat="server" placeholder="Enter Report Name" data-toggle="tooltip" title="Enter Report Name" TabIndex="1"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="remembername" runat="server" ControlToValidate="txtreportname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Report Name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Select Module<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddmodule" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Related Type" CssClass="form-control" TabIndex="2">
                                            <asp:ListItem Value="None">None</asp:ListItem>
                                            <asp:ListItem Value="View_Lead">Lead</asp:ListItem>
                                            <asp:ListItem Value="View_LeadContact">Lead Contact</asp:ListItem>
                                            <asp:ListItem Value="MasterLead_View">Full Lead</asp:ListItem>
                                            <asp:ListItem Value="View_Account">Account</asp:ListItem>
                                            <asp:ListItem Value="View_AccountContact">Account Contact</asp:ListItem>
                                            <asp:ListItem Value="MasterAccount_View">Full Account</asp:ListItem>
                                            <asp:ListItem Value="View_User">User</asp:ListItem>
                                            <asp:ListItem Value="View_UserLogin">User Login</asp:ListItem>
                                            <asp:ListItem Value="View_Product">Product</asp:ListItem>
                                            <asp:ListItem Value="View_ProductDiscount">Product Discount</asp:ListItem>
                                            <asp:ListItem Value="View_Complaint">Complaint</asp:ListItem>
                                            <asp:ListItem Value="View_Opportunity">Opportunity</asp:ListItem>
                                            <asp:ListItem Value="View_OrderReport">Order Report</asp:ListItem>
                                            <asp:ListItem Value="View_Quotation">Quotation Report</asp:ListItem>
                                            <asp:ListItem Value="View_Error">Error Report</asp:ListItem>

                                            </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddmodule" InitialValue="None" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select module" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Description<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtdesc" runat="server" placeholder="Enter Description" data-toggle="tooltip" title="Enter Description" TabIndex="3"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdesc" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select type id" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Report Type<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="ddreporttype" runat="server"  data-toggle="tooltip" title="Related Type" CssClass="form-control" TabIndex="4">
                                            <asp:ListItem Value="Admin Report">Admin Report</asp:ListItem>
                                            <asp:ListItem Value="Summary Report">Summary Report</asp:ListItem>
                                            <asp:ListItem Value="Accounts Report">Accounts Report</asp:ListItem>
                                            <asp:ListItem Value="Product List Report"> Product List Report</asp:ListItem>
                                            <asp:ListItem Value="Lead Report">Lead Report</asp:ListItem>
                                            <asp:ListItem Value="Activity Report">Activity Report</asp:ListItem>
                                            <asp:ListItem Value="Opportunity Report">Opportunity Report</asp:ListItem>
                                            <asp:ListItem Value="Sales Order Report">Sales Order Report</asp:ListItem>
                                            <asp:ListItem Value="Quotation Report">Quotation Report</asp:ListItem>
                                            <asp:ListItem Value="Complaints Report">Complaints Report</asp:ListItem>
                                            <asp:ListItem Value="Custom Report">Custom Report</asp:ListItem>
                                            <asp:ListItem Value="Error Report">Error Report</asp:ListItem>
                                            </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdesc" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please select type id" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-md-1">
                            </div>
                            <asp:UpdatePanel ID="up1stleft" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-md-4">
                                        <b>Available Fields</b><br />
                                        <asp:ListBox ID="lstLeft" runat="server" CssClass="form-control" SelectionMode="Multiple" Height="100" Width="400"></asp:ListBox>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddmodule" />
                                </Triggers>
                            </asp:UpdatePanel>


                            <div class="col-md-1">
                                <br />
                                <br />


                                <input type="button"   class="btn btn-sm btn-primary" id="left" value="<<" />
                                <input type="button"  class="btn btn-sm btn-primary" id="right" value=">>" />



                            </div>

                            <div class="col-md-5">
                                <b>Selected Fields</b><br />
                                <asp:ListBox ID="lstRight" runat="server" CssClass="form-control" SelectionMode="Multiple" Height="100" Width="400"></asp:ListBox>
                            </div>


                            <div style="clear: both"></div>
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-1">
                            </div>
                            <div class="col-md-9">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                CssClass="table table-striped table-vcenter table" ShowFooter="true">
                                                <Columns>
                                                    <asp:BoundField DataField="RowNumber" Visible="false" />

                                                    <asp:TemplateField HeaderText="Log Operator" ItemStyle-Width="100px" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader">
                                                        <ItemTemplate>
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="gi gi-cogwheel"></i></span>
                                                                <asp:DropDownList ID="ddlogoperator" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Text="AND" Value="AND"></asp:ListItem>
                                                                    <asp:ListItem Text="OR" Value="OR"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Field Name" ItemStyle-Width="100px" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader">
                                                        <ItemTemplate>
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="gi gi-cogwheel"></i></span>
                                                                <asp:DropDownList ID="ddfieldname" runat="server" CssClass="form-control">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Operator" ItemStyle-Width="100px" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader">
                                                        <ItemTemplate>
                                                            <div class="input-group">
                                                                <span class="input-group-addon"><i class="gi gi-cogwheel"></i></span>
                                                                <asp:DropDownList ID="ddoperator" runat="server" CssClass="form-control">
                                                                    <asp:ListItem Text="like" Value="like"></asp:ListItem>
                                                                    <asp:ListItem Text="=" Value="="></asp:ListItem>
                                                                    <asp:ListItem Text=">" Value=">"></asp:ListItem>
                                                                    <asp:ListItem Text="<" Value="<"></asp:ListItem>
                                                                    <asp:ListItem Text="<>" Value="<>"></asp:ListItem>
                                                                    <asp:ListItem Text="BETWEEN" Value="BETWEEN"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                        <ItemTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                    CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                            </div>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            <div class="btn-group btn-group-xs">
                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" Font-Size="20px" Width="40px" runat="server"
                                                                    CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                                            </div>
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                <PagerSettings PageButtonCount="4" />
                                                <EmptyDataTemplate>
                                                    <div>
                                                        <div class="col-md-10">
                                                            <div class="alert alert-info alert-dismissable">
                                                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true"></button>
                                                                Click add button at right to add  Filter Pattern
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="btn-group btn-group-xs" style="float: right">
                                                        <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="40px"
                                                            CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-pencil-square-o"></i></asp:LinkButton>
                                                    </div>
                                                </EmptyDataTemplate>
                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                            </asp:GridView>
                                        </div>

                                    </ContentTemplate>

                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="GridView1" />

                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div id="divdate" runat="server" visible="false">
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Created Date</label>
                                        <asp:TextBox ID="txtcreatedate" runat="server" ReadOnly="true" placeholder="Created Date" data-toggle="tooltip" title="Created Date"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Created Name</label>
                                        <asp:TextBox ID="txtcreatedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Modified Date</label>
                                        <asp:TextBox ID="txtmodifieddate" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="">
                                        <label for="example-nf-email">Modified Name</label>
                                        <asp:TextBox ID="txtmodifiedname" runat="server" placeholder="Modified Date" ReadOnly="true" data-toggle="tooltip" title="Modified Date"
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>



                            </div>

                            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                                <div class="pull-right">
                                    <asp:Button Text="Save" runat="server" ID="btnadd" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="13" />
                                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Quotation.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="14" />
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
