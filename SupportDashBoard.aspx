<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SupportDashBoard.aspx.vb" Inherits="SupportDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtCode.ClientID%>");
            var txt2 = document.getElementById("<%= txtName.ClientID%>");
            var txt3 = document.getElementById("<%= txtCompany.ClientID%>");
            var txt4 = document.getElementById("<%= txtEmail.ClientID%>");
            var txt5 = document.getElementById("<%= txtMobile.ClientID%>");
            var txt6 = document.getElementById("<%= txtOrderCode.ClientID%>");
            var txt7 = document.getElementById("<%= txtInvNo.ClientID%>");
            var txt8 = document.getElementById("<%= txtTracking.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "") || (txt4.value != "") || (txt5.value != "") || (txt6.value != "") || (txt7.value != "") || (txt8.value != "");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="Hfsearchcheck" runat="server" />

    <div class="content-header content-header-media" style="height: 125px;">
        <div class="header-section">

            
            <div class="row">

                <!-- Main Title (hidden on small devices for the statistics to fit hidden-xs hidden-sm) -->
                <div class="col-md-4 col-lg-6">
                    <h1>Welcome  <strong>
                        <asp:Label ID="lblusername" runat="server" Font-Bold="true"></asp:Label></strong><br>
                        <%--<small>You Look Awesome!</small>--%></h1>
                </div>
                <%-- <div class="col-md-8 col-lg-6">
                    <div class="col-xs-4 col-sm-3 pull-right">
                        <asp:DropDownList ID="ddluser" runat="server" AutoPostBack="true"  name="example-chosen" class="form-control"></asp:DropDownList>
                    </div>
                </div>--%>
            </div>
        </div>
        <!-- For best results use an image with a resolution of 2560x248 pixels (You can also use a blurred image with ratio 10:1 - eg: 1000x100 pixels - it will adjust and look great!) -->
        <img src="img/placeholders/headers/dashboard_header.jpg" alt="header image" class="animation-pulseSlow">
    </div>
        <div class="row">

    <div class="col-md-12">
       
        <div class="col-sm-4" id="divnewComplaint" runat="server">
            <!-- Widget -->
            <a href="SupportComplaint.aspx?type=NFUHfhdSFeW" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="fa fa-life-ring"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown">
                        <strong><asp:Label ID="lblSwissComplaint" runat="server"></asp:Label> Pending Complaints</strong><br />
                        <small>From B2B</small>                                
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
            </div>
            </div>
    <div class="block full">
        
        <div class="row">
            <div class="form-horizontal form-bordered">
                <div class="col-md-12">
                     <asp:Panel ID="Panel1" runat="server" DefaultButton = "btndashboard">
                    <%--<div class="col-md-5">
                        <label class="col-md-1 control-label">From</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtfrom" runat="server" class="form-control" placeholder="Enter From Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfrom" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter From date" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <label class="col-md-1 control-label">To</label>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtto" runat="server" class="form-control" placeholder="Enter To Date" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtto" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="Enter To date" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Enter Valid date" CssClass="MasterValidationCSS" ControlToCompare="txtfrom" ControlToValidate="txtto" Operator="GreaterThanEqual" ValidationGroup="MasterGroup"></asp:CompareValidator>
                        </div>
                    </div>--%>
                         <br />
                    <div class="col-md-4" >
                        <label class="col-md-4 control-label">Code</label>
                        <div class="col-md-8">
                             <asp:TextBox ID="txtCode" runat="server" class="form-control" placeholder="Enter Code" />
                        </div>
                    </div>
                   <%-- <div class="col-md-4" style="display:none;">
                        <label class="col-md-4 control-label">Type</label>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlType" runat="server" data-toggle="tooltip" title="Type" CssClass="form-control">
                                <asp:ListItem Value="Account" Text="Account"></asp:ListItem>
                                <asp:ListItem Value="Prospect" Text="Prospect"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div class="col-md-4">
                        <label class="col-md-4 control-label">Contact Name</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Enter Name" />

                        </div>
                    </div>
                    <div class="col-md-4">
                        <label class="col-md-4 control-label">Company</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtCompany" runat="server" class="form-control" placeholder="Enter Company" />

                        </div>
                    </div>
                   <%-- <div class="col-md-4">
                        <label class="col-md-4 control-label">Phone Contact</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Enter Phone Contact" />

                        </div>
                    </div>--%>
                    <div class="col-md-4">
                        <label class="col-md-4 control-label">Email</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email" />

                        </div>
                    </div>
                         <div class="col-md-4">
                        <label class="col-md-4 control-label">Mobile</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtMobile" runat="server" class="form-control" placeholder="Enter Mobile" />

                        </div>
                    </div>
                         <div class="col-md-4">
                        <label class="col-md-4 control-label">Order Code</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtOrderCode" runat="server" class="form-control" placeholder="Enter Order Code" />

                        </div>
                    </div>
                         <div class="col-md-4">
                        <label class="col-md-4 control-label">Invoice Number</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtInvNo" runat="server" class="form-control" placeholder="Enter Invoice Number" />

                        </div>
                    </div>
                    <div class="col-md-4">
                        <label class="col-md-4 control-label">Tracking Number</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtTracking" runat="server" class="form-control" placeholder="Enter Order Code" />

                        </div>
                        <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="At least one field required" ValidationGroup="MasterGroup"
                                                CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                                ClientValidationFunction="AtLeastOneContact_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                    <%-- <div class="col-md-4">
                        <label class="col-md-4 control-label">Name</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="Enter Name" />

                        </div>
                    </div>--%>
                    <%--<div style="clear: both"></div>--%>

                    <div class="col-md-2 pull-right">

                       <%-- <div class="col-md-6">
                            <asp:DropDownList ID="ddlPaging" runat="server" data-toggle="tooltip" title="Paging" CssClass="form-control">
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="30" Text="30"></asp:ListItem>
                                <asp:ListItem Value="50" Text="50"></asp:ListItem>
                            </asp:DropDownList>
                             
                        </div>--%>

                        <asp:Button ID="btndashboard"  ValidationGroup="MasterGroup" runat="server" Text="Submit" CssClass="btn btn-xs btn-success pull-right" 
                            UseSubmitBehavior="false"  OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Loading...';"/>
                        <%--<asp:ImageButton ID="btnExportExcel"  OnClientClick="tableToExcel('example-datatable', 'W3C Example Table')" data-toggle="tooltip" title="Export Excel" Style="margin-right: 10px" Width="33px" ImageAlign="Right" runat="server" ImageUrl="~/img/excel.gif" />--%>
                        <%--<input type="button" onclick="tableToExcel('example-datatable', 'W3C Example Table')" class="btn btn-sm btn-success" value="Export to Excel" />--%>
                    </div>
                         </asp:Panel>
                </div>
            </div>
        </div>
         <div style="clear: both"></div>
        <br />
        <%--  </div>
    <div class="block full">--%>
        <%--<User:SearchBarByID ID="SearchControl" runat="server" />--%>

        <div class="table-responsive">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Acc_Id" OnSorting="GridView1_Sorting" AllowCustomPaging="false"
                CssClass="table table-striped table-vcenter" GridLines="None" AllowPaging="false" AllowSorting="True">
                <%-- <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Lead_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter" OnSorting="GridView1_Sorting" GridLines="None"
                                AllowPaging="True" AllowSorting="True">--%>
                <Columns>
                    <%--<asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                    <HeaderTemplate>
                        <asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="btn-group btn-group-xs">
                            <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyLead.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Lead_Id").ToString()))%>'
                                data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="" Visible="false" ItemStyle-CssClass="" SortExpression="Acc_Id">
                        <ItemTemplate>
                            <asp:Literal ID="lbluId" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Id"))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sr." ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
                        <ItemTemplate>
                            <asp:Literal ID="lblSrNo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("RowNumber")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Code" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Acc_Code">
                        <ItemTemplate>
                            <asp:Literal ID="lblCode" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Code")) + " (" + DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Type")) + ")")%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Acc_Name">
                        <ItemTemplate>
                            <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Name" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Contact_ContactPerson">
                        <ItemTemplate>
                            <asp:HyperLink ID="HypLnkType"   NavigateUrl='<%# Eval("href").ToString() + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                data-toggle="tooltip" title="View" runat="server">
                           <%-- <asp:HyperLink ID="HypLnkType"   
                                data-toggle="tooltip" title="View" runat="server">--%>
                                <asp:Literal ID="lblname" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_ContactPerson"))%>'   />
                            </asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" SortExpression="Contact_Mobile">
                        <ItemTemplate>
                            <asp:Literal ID="lblmobile" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Mobile")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="Email" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Contact_WorkEmail">
                        <ItemTemplate>
                            <asp:Literal ID="lblemail" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_WorkEmail")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Email" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Contact_Email">
                        <ItemTemplate>
                            <asp:Literal ID="lblemail" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Email")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="State" ItemStyle-Width="120" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" SortExpression="StateName">
                        <ItemTemplate>
                            <asp:Literal ID="lblState" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("StateName"))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City" ItemStyle-Width="120" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" SortExpression="City">
                        <ItemTemplate>
                            <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("City"))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Owner" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Owner">
                        <ItemTemplate>
                            <asp:Literal ID="lblOwner" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Owner")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assign To" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="AssignTo">
                        <ItemTemplate>
                            <asp:Literal ID="lblAssignTo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Contact_Landline" Visible="false">
                        <ItemTemplate>
                            <asp:Literal ID="lblphone" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Landline")))%>'   />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    
                    <%--<asp:TemplateField HeaderText="Sales Stage" ItemStyle-Width="150" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Stage_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblstage" runat="server" Style="color: white; padding: 0 10px; border-radius: 3px;" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Stage_Name"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Source" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="Source_Name" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblassignto" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Source_Name"))%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="AssignTo" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" SortExpression="AssignTo">
                    <ItemTemplate>
                        <asp:Label ID="lblassignto" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("AssignTo"))%>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                </Columns>
                <%--<PagerStyle HorizontalAlign="left" BackColor="White" />--%>
                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                <FooterStyle HorizontalAlign="left" BackColor="White" />
                <PagerSettings PageButtonCount="4" />
                <EmptyDataTemplate>
                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br /><br /></EmptyDataTemplate><EmptyDataRowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

