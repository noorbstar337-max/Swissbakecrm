<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="LMSPrivilege.aspx.vb" Inherits="LMSPrivilege" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
   
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="fa fa-unlock-alt" ></i>Privilege<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="LMSdashboard.aspx">Home</a></li>
                <li>Privilege</li>
            </ul>

            <div class="block">
                <div class="block-title">
                    <h2><strong>Privilege</strong> Detail</h2>
                </div>
                <%--Search User Control Start--%>
                <div class="form-group col-md-6">
                        <label class="col-md-3 " style="margin-top: 7px" for="example-nf-email"><span class="text-danger">*</span> Select Level</label>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlevel" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen">
                                 <asp:ListItem Value="0">Select Level</asp:ListItem>
                                 <%--<asp:ListItem Value="1" >Admin</asp:ListItem>--%>
                                 <asp:ListItem Value="2">R & D</asp:ListItem>
                                 <asp:ListItem Value="3">Lab Technician</asp:ListItem>
                                 <asp:ListItem Value="4">Factory Lab Technician</asp:ListItem>
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="rfLevel" runat="server" ControlToValidate="ddlevel" InitialValue="0" SetFocusOnError="true" ValidationGroup="PrivilegeGroup" CssClass="MasterValidationCSS"
                                ErrorMessage="select a level"></asp:RequiredFieldValidator>
                            <br />
                            <br />
                        </div>

                    </div>
                <div style="clear:both"></div>
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Menu_Id" AllowCustomPaging="true"
                                CssClass="table table-striped table-vcenter "  AlternatingRowStyle-CssClass="Alternate_grid">
                                <Columns>

                                 <asp:TemplateField HeaderText="Menu Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Menu_MenuName">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblMenuID" runat="server" Text='<%#(Eval("Menu_Id"))%>' Visible="false" />
                                            <asp:Literal ID="lblscId" runat="server" Text='<%#(Eval("Menu_MenuName"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select All" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbselectall" runat="server" OnCheckedChanged="Selectall" AutoPostBack="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField Visible="false" HeaderText="Select" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                        <ItemTemplate>
                                             <asp:CheckBox ID="cbselect" runat="server" autopostback="true"  checked='<%#Eval("Prvg_SelectActive").ToString().Equals("True")%>'/>
                                             <%--<asp:CheckBox ID="cbselect" runat="server" autopostback="true" OnCheckedChanged="checkview"  checked='<%#Eval("Prvg_SelectActive").ToString().Equals("True")%>'/>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="View" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                        <ItemTemplate>
                                             <asp:CheckBox ID="cbview"  runat="server" checked='<%#Eval("Prvg_Rview").ToString().Equals("True")%>' Enabled="true"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Add" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbadd" runat="server" checked='<%#Eval("Prvg_RAdd").ToString().Equals("True")%>' Enabled="true"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Edit" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                        <ItemTemplate>
                                              <asp:CheckBox ID="cbedit"  runat="server" OnCheckedChanged="SelectViewOnEdit" checked='<%#Eval("Prvg_RUpdate").ToString().Equals("True")%>' Enabled="true" AutoPostBack="true"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem display-none" HeaderStyle-CssClass="MasterGridviewHeader display-none" SortExpression="" >
                                        <ItemTemplate>
                                              <asp:CheckBox ID="cbdelete" runat="server"  checked='<%#Eval("Prvg_RDelete").ToString().Equals("True")%>' Enabled="true"/>
                                        </ItemTemplate>
                                    </asp:TemplateField></Columns>
                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />

                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />

                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                           <%-- <div class="form-group">
                        <br />
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('PrivilegeGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" ValidationGroup="PrivilegeGroup"  class="btn btn-xs btn-success  pull-right" />
                    </div>--%>
                        </div>

                    </ContentTemplate>

                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
                        <asp:AsyncPostBackTrigger ControlID="ddlevel" />
                    </Triggers>
                </asp:UpdatePanel>
                   <%--<br />--%>
                   <div class="form-group">
                     
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('PrivilegeGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" ValidationGroup="PrivilegeGroup"  class="btn btn-xs btn-success " />
                       

                    </div>

            </div>
     
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

