<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="privilage.aspx.vb" Inherits="privilage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript">

         function SelectAllCol(id, id2) {
             //get reference of GridView control
             var grid = document.getElementById("<%= GridView1.ClientID %>");
            //variable to contain the cell of the grid
            var cell;

            if (grid.rows.length > 0) {
                //loop starts from 1. rows[0] points to the header.
                for (i = 1; i < grid.rows.length; i++) {
                    //get the reference of first column
                    cell = grid.rows[i].cells[id2];

                    //loop according to the number of childNodes in the cell
                    for (j = 0; j < cell.childNodes.length; j++) {
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type == "checkbox") {
                            //assign the status of the Select All checkbox to the cell checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }


    </script>
    <script type="text/javascript" language="javascript">
        function SelectAllCollRow(chkbox) {
            var chk = chkbox;
            //var chk = document.getElementById(chkbox);
            //var chk = document.getElementById();
            var grid = document.getElementById("<%= GridView1.ClientID %>");
            var cell;
            debugger;
            if (chk.checked == true) {
                if (grid.rows.length > 0) {
                    for (i = 1; i < grid.rows.length; i++) {
                        for (var k = 0; k < grid.rows[i].cells.length; k++) {
                            cell = grid.rows[i].cells[k];
                            for (j = 0; j < cell.childNodes.length; j++) {
                                if (cell.childNodes[j].type == "checkbox") {
                                    //cell.childNodes[j].enabled = true;
                                    cell.childNodes[j].checked = true;
                                }
                            }
                        }
                    }
                }
            }
            else {
                if (grid.rows.length > 0) {
                    for (i = 1; i < grid.rows.length; i++) {
                        for (var k = 0; k < grid.rows[i].cells.length; k++) {
                            cell = grid.rows[i].cells[k];
                            for (j = 0; j < cell.childNodes.length; j++) {
                                if (cell.childNodes[j].type == "checkbox") {
                                    cell.childNodes[j].checked = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        function SelectAllRow(chkbox) {
            debugger;
            var row = chkbox.parentNode.parentNode;
            var rowIndex = row.rowIndex;
            var chk = chkbox;
            //var chk = document.getElementById(chkbox);
            //var chk = document.getElementById();
            var grid = document.getElementById("<%=GridView1.ClientID%>");
            var cell;
            if (chk.checked == true) {
                for (var k = 0; k < grid.rows[rowIndex].cells.length; k++) {
                    cell = grid.rows[rowIndex].cells[k];
                    for (j = 0; j < cell.childNodes.length; j++) {
                        if (cell.childNodes[j].type == "checkbox") {
                            cell.childNodes[j].checked = true;
                        }
                    }
                }
            }
            else {
                for (var k = 0; k < grid.rows[rowIndex].cells.length; k++) {
                    cell = grid.rows[rowIndex].cells[k];
                    for (j = 0; j < cell.childNodes.length; j++) {
                        if (cell.childNodes[j].type == "checkbox") {
                            cell.childNodes[j].checked = false;
                        }
                    }
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />

    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="fa fa-unlock-alt" style="margin: -8px"></i>Privilage<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li><a href="AdminMenu.aspx">Admin</a></li>
        <li>Privilage</li>
    </ul>

    <div class="block">
        <div class="block-title">
            <h2><strong>Privilage</strong> Detail</h2>
        </div>
        <%--Search User Control Start--%>
        <div class="form-group">
            <label class="col-md-2 control-label" style="margin-top: 7px" for="example-nf-email"><span class="text-danger">*</span> Select Level</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlevel" runat="server" AutoPostBack="true" name="example-chosen" class="select-chosen"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rqpagename" runat="server" ControlToValidate="ddlevel" InitialValue=" --- Select Level --- " SetFocusOnError="true" ValidationGroup="PrivilageGroup" CssClass="MasterValidationCSS"
                    ErrorMessage="select a level"></asp:RequiredFieldValidator>
                <br />
                <br />
            </div>

        </div>
        <div style="clear: both"></div>
        <%--Search User Control End--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <div id="divHeader" visible="false" runat="server">
                        <table class="table-responsive col-md-12">
                            <tr>
                                <td class="MasterGridviewHeader" style="width: 55%">Menu Name</td>
                                <td class="MasterGridviewHeader" style="width: 9%">
                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="&nbsp; All" onclick="SelectAllCollRow(this)" /></td>
                                    <%--<input type="checkbox" id="chkSelectAll" runat="server" text="&nbsp; Select All" onclick="SelectAllCollRow(this)" />--%></td>
                                <td class="MasterGridviewHeader" style="width: 9%" runat="server" visible="false" >
                                    <asp:CheckBox ID="cbSelectAllTop" runat="server" Text="&nbsp; Select" /></td>
                                <td class="MasterGridviewHeader" style="width: 9%">
                                    <asp:CheckBox ID="cbviewAll" runat="server" Text="&nbsp; View" /></td>
                                <td class="MasterGridviewHeader" style="width: 9%">
                                    <asp:CheckBox ID="cbAddAll" runat="server" Text="&nbsp;  Add" /></td>
                                <td class="MasterGridviewHeader" style="width: 9%">
                                    <asp:CheckBox ID="cbEditAll" runat="server" Text="&nbsp;  Edit" /></td>
                                <td class="MasterGridviewHeader" style="width: 9%">
                                    <asp:CheckBox ID="cbDeleteAll" runat="server" Text="&nbsp;  Delete" /></td>
                            </tr>
                        </table>
                    </div>
                    <div class="table-responsive col-md-12" style="overflow: scroll; height: 400px;">
                        <%--<div class="table-responsive">--%>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Menu_Id" AllowCustomPaging="true"
                            CssClass="table table-striped table-vcenter " AlternatingRowStyle-CssClass="Alternate_grid">
                            <Columns>

                                <asp:TemplateField HeaderText="" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Menu_MenuName">
                                <%--<asp:TemplateField HeaderText="Menu Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="Menu_MenuName">--%>
                                    <ItemTemplate>
                                        <asp:Literal ID="lblscId" runat="server" Text='<%#(Eval("Menu_MenuName"))%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="Select All" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbselectall" runat="server"  onclick="SelectAllRow(this)"  />
                                        <%-- OnCheckedChanged="Selectall" AutoPostBack="true" --%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" Visible="false" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="Select" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbselect" runat="server" AutoPostBack="true" OnCheckedChanged="checkview" Checked='<%#Eval("Prvg_SelectActive").ToString().Equals("True")%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="View" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbview" runat="server" Checked='<%#Eval("Prvg_Rview").ToString().Equals("True")%>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="Add" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbadd" runat="server" Checked='<%#Eval("Prvg_RAdd").ToString().Equals("True")%>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="Edit" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbedit" runat="server" Checked='<%#Eval("Prvg_RUpdate").ToString().Equals("True")%>'  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">
                                <%--<asp:TemplateField HeaderText="Delete" ItemStyle-Width="100" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="">--%>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbdelete" runat="server" Checked='<%#Eval("Prvg_RDelete").ToString().Equals("True")%>' />
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
                        <%--</div>--%>
                    </div>
                </div>

            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridView1" />
                <asp:AsyncPostBackTrigger ControlID="ddlevel" />
            </Triggers>
        </asp:UpdatePanel>

        <div class="form-group">
            <br />
            <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('PrivilageGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                UseSubmitBehavior="false" ValidationGroup="PrivilageGroup" class="btn btn-alt btn-primary" />


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

