<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="TrialReport.aspx.vb" Inherits="TrialReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="row">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="content-header">
                        <div class="header-section">
                            <h1>Feedbacks<br>
                            </h1>
                        </div>
                    </div>
                    <ul class="breadcrumb breadcrumb-top">
                        <li><a href="LMSDashboard.aspx">Home</a></li>
                        <li>Trails</li>
                    </ul>
                    <div class="col-md-12">
                        <div class="widget">
                            <div class="widget-extra themed-background-dark">
                                <h5 class="widget-content-light abc">
                                    <strong>Feedback</strong> Details
                                </h5>
                            </div>
                            <div class="block" style="display: table; width: 100%;">
                                <div class="col-md-11">
                                        <div class="col-md-3">
                                            <label class="col-md-3 control-label">From</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtfrom" runat="server" TabIndex="2" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-md-3">
                                            <label class="col-md-3 control-label">To</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txtto" runat="server" TabIndex="3" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                    <br />
                                <div class="col-md-11">
                                    <div class="col-md-3" id="div1" runat="server">
                                        <label for="example-nf-email" class="col-md-6">Mix Type</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlMixTypeForm" runat="server" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen" AutoPostBack="true">
                                                <asp:ListItem Value="All">All</asp:ListItem>
                                                <asp:ListItem Value="Bread">Bread</asp:ListItem>
                                                <asp:ListItem Value="Cake">Cake</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlProduct" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is Required" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label for="example-nf-email" class="col-md-6">Formulation Type</label>
                                        <div class="col-md-6">
                                            <asp:DropDownList ID="ddlFormulationType" runat="server" data-toggle="tooltip" title="Select Product Type" CssClass="form-control select-chosen" AutoPostBack="true">
                                                <asp:ListItem Value="All">All</asp:ListItem>
                                                <asp:ListItem Value="Exist">Existing Product</asp:ListItem>
                                                <asp:ListItem Value="New">New Product</asp:ListItem>
                                                <asp:ListItem Value="Competitor">Competitor Product</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfddlFormulationType" runat="server" ControlToValidate="ddlFormulationType" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="This is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <br />
                                        </div>
                                    </div>
                                    <div class="col-md-3" id="divDDLProduct" runat="server">
                                        <label for="example-nf-email" class="col-md-3">Product </label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="true" data-toggle="tooltip" title="Select Product" CssClass="form-control select-chosen">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3" runat="server" visible="false">
                                        <label class="col-md-3 control-label">User</label>
                                        <div class="col-md-9">
                                            <asp:DropDownList ID="ddlUser" runat="server" class="select-chosen">
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-1">
                                    <asp:Button ID="btsubmit" runat="server" Text="Submit" class="btn btn-xs btn-success " />
                                </div>
                                <div id="divmain" runat="server">
                                    <%--<div class="row">--%>
                                    <div class="table-responsive">
                                        <asp:UpdatePanel runat="server" ID="rpg" UpdateMode="Always">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnldemo" runat="server">
                                                    <table id="printtable" class="MultiDatatable table table-vcenter table-condensed table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th class="text-center" style="display: none"></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="Formulation_No" runat="server">Code</asp:Label></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="Product_Name" runat="server">Product Name</asp:Label></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="Label3" runat="server">Mix Type</asp:Label></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="Label4" runat="server">Product Type</asp:Label></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="AssignTo" runat="server">Assign to</asp:Label></th>
                                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                                    <asp:Label Style="color: #1bbae1;" ID="Formulation_CreatedDate" runat="server">Date</asp:Label></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <asp:Repeater ID="rpFormulation" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td style="display: none" class="text-center">
                                                                            <asp:Literal ID="lblFormulationId" runat="server" Text='<%#Eval("Trial_Id")%>' EnableViewState="false" />
                                                                        </td>

                                                                        <td class="text-center ">

                                                                            <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "Multiview.aspx?id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Trial_Id").ToString())) + "&&Levl=PT" + Eval("Trial_Id").ToString()%>'
                                                                                runat="server" Target="_blank">
                                                                                <asp:Literal ID="lblFormulationno" runat="server" Text='<%#Eval("Trial_No")%>' EnableViewState="false" />
                                                                            </asp:HyperLink><br />
                                                                        </td>
                                                                        <td class="text-center ">
                                                                            <asp:Literal ID="lblFormulationName" runat="server" Text='<%#Eval("Product_Name")%>' EnableViewState="false" />
                                                                        </td>
                                                                        <td class="text-center ">
                                                                            <asp:Literal ID="Literal2" runat="server" Text='<%#Eval("Formulation_ProdCategory")%>' EnableViewState="false" />
                                                                        </td>
                                                                        <td class="text-center ">
                                                                            <asp:Literal ID="Literal3" runat="server" Text='<%#Eval("Formulation_Type")%>' EnableViewState="false" />
                                                                        </td>
                                                                        <td class="text-center ">
                                                                            <asp:Literal ID="lblFormulationOID" runat="server" Text='<%#Eval("AssignTo")%>' EnableViewState="false" />
                                                                        </td>
                                                                        <td class="text-center ">
                                                                            <asp:Literal ID="lblFormulationDate" runat="server" Text='<%#Eval("Formulation_CreatedDate")%>' EnableViewState="false" />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <tr id="trEmpty" runat="server" visible="false">
                                                                        <td class="dataTables_empty" style="width: 240px;">No matching records found. </td>

                                                                    </tr>

                                                                </FooterTemplate>

                                                            </asp:Repeater>
                                                            <asp:Label ID="Label1" runat="server" Text="No matching records found" Visible="false"></asp:Label>
                                                        </tbody>
                                                        <tfoot>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <label for="example-nf-email" class="control-label " id="lblNoData" runat="server" visible="false">No matching records found.</label>
                                                                </td>
                                                            </tr>
                                                        </tfoot>
                                                    </table>
                                                    <asp:HiddenField ID="hfBackcount" runat="server" />
                                                    <asp:HiddenField ID="tab" runat="server" />

                                                </asp:Panel>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btsubmit" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                    <%--</div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>


