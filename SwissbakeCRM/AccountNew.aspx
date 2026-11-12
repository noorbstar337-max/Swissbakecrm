<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="AccountNew.aspx.vb" Inherits="AccountNew" %>


<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
    <script type="text/javascript">
        function lkdeleteclick() {
            if (confirm('Are you sure want to delete ?')) {
                document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
            }
            else {
                document.getElementById('<%=deletestatus.ClientID %>').value = "no";
                return true
            }
        }
    </script>

    <script>
      
        jQuery(function ($) {
            var focusedElementId = "";
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(function (source, args) {
                var fe = document.activeElement;
                if (fe != null) {
                    focusedElementId = fe.id;
                } else {
                    focusedElementId = "";
                }
            });

            prm.add_endRequest(function (source, args) {
                if (focusedElementId != "") {
                  
                    $("#" + focusedElementId).focus();
                    var tmpStr =$("#" + focusedElementId).val();
                    $("#" + focusedElementId).val('');
                    $("#" + focusedElementId).val(tmpStr);
                    document.getElementById('<%=hfBackcount.ClientID %>').value = "1";
                    
                }
            });
        });
    </script>
    <script>
        $(document).ready(function(){
            var text = <%=tabss%>;
            if (text == "0"){
            }
            else{
                $('a:contains("' + text + '")').parent().addClass('active disabled');
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_pageLoaded(panelLoaded);
            
                function panelLoaded(sender, args){
                  
                    var text = <%=tabss%>;
                    var value = $("#<%=tab.ClientID%>").val();
                
                    // re-bind your jQuery events here
                    $('a:contains("' + value + '")').parent().addClass('active disabled');

                }
            }

        });
    </script>
    <%--<script>
        $(document).ready(function(){
           
            $(function () {
           
           ;debugger
                var text = <%=tabss%>;
                if (text == "0"){
                }
                else{
                    ;debugger
                    $('a:contains("' + text + '")').parent().addClass('active disabled');
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_pageLoaded(panelLoaded);
            
                    function panelLoaded(sender, args){
                  
                        var text = <%=tabss%>;
                        var value = $("#<%=tab.ClientID%>").val();
                
                        // re-bind your jQuery events here
                        $('a:contains("' + value + '")').parent().addClass('active disabled');

                    }
                }

            });
        });
    </script>--%>
    <script type="text/javascript">
        function lkviewclick(id){       
           
            var a="";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                },
                async: false
            });
         
            //if (ProdName == "Internet Leased Line Service")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "PRI Services")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "Leased Line Service")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "MPLS")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyMPLS.aspx";
            //}
            //else if (ProdName == "FT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
                  
            //else if (ProdName == "SBT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
            //else if (ProdName == "WFT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
            //else
            //{
            //    //link.Value = "ModifyNewproposal.aspx";
            //    p1 = "ModifyNewproposal.aspx";
            //}
            window.location.href="ViewAccount.aspx?Id="+a;
        }
        function lkEditclick(id, ProdName){
           
            var a="";
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(response){
                    a=response.d;
                },
                async: false
            });
            //if (ProdName == "Internet Leased Line Service")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "PRI Services")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "Leased Line Service")
            //{
            //    // link.Value = "Modifyproposal.aspx";
            //    p1 = "Modifyproposal.aspx";
            //}
            //else if (ProdName == "MPLS")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyMPLS.aspx";
            //}
            //else if (ProdName == "FT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
                  
            //else if (ProdName == "SBT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
            //else if (ProdName == "WFT")
            //{
            //    // link.Value = "ModifyMPLS.aspx";
            //    p1 = "ModifyLBS.aspx";
            //}
            //else
            //{
            //    //link.Value = "ModifyNewproposal.aspx";
            //    p1 = "ModifyNewproposal.aspx";
            //}
            window.location.href="ModifyAccount.aspx?chk=e&Id="+a;
        }        
    </script>
    <script type="text/javascript">
        function AtLeastOneField_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtCompanyName.ClientID%>");
            var txt2 = document.getElementById("<%= txtContactPerson.ClientID%>");
            var txt3 = document.getElementById("<%= txtPhone.ClientID%>");
            var txt4 = document.getElementById("<%= txtEmailColumn.ClientID%>");
            var txt5 = document.getElementById("<%= txtMobile.ClientID%>");
            var txt6 = document.getElementById("<%= txtCity.ClientID%>");
            //var txt7 = document.getElementById("<%= txtAccountOwner.ClientID%>");
            var txt7 = document.getElementById("<%= ddlCustOwner.ClientID%>");
            //var txt8 = document.getElementById("<%= txtCreatedBy.ClientID%>");
            var txt8 = document.getElementById("<%= ddlCreatedBy.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            //var txt10 = document.getElementById("<%= txtFrom.ClientID%>");
            var txt10 = document.getElementById("<%= ddlFrom.ClientID%>");
            args.IsValid = (txt1.value != "" && txt1.value.length >= 3) || (txt2.value != "" && txt2.value.length >= 3) || (txt3.value != "" && txt3.value.length >= 3) || (txt4.value != "" && txt4.value.length >= 3) || (txt5.value != "" && txt5.value.length >= 3) || (txt6.value != "" && txt6.value.length >= 3) || (txt7.value != "0") || (txt8.value != "0") || (txt9.value != "" && txt9.value.length >= 3) || (txt10.value != "Select");
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= txtCompanyName.ClientID%>");
            var txt2 = document.getElementById("<%= txtContactPerson.ClientID%>");
            var txt3 = document.getElementById("<%= txtPhone.ClientID%>");
            var txt4 = document.getElementById("<%= txtEmailColumn.ClientID%>");
            var txt5 = document.getElementById("<%= txtMobile.ClientID%>");
            var txt6 = document.getElementById("<%= txtCity.ClientID%>");
            var txt7 = document.getElementById("<%= ddlCustOwner.ClientID%>");
            var txt8 = document.getElementById("<%= ddlCreatedBy.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            var txt10 = document.getElementById("<%= ddlFrom.ClientID%>");
            txt1.value = "";
            txt2.value = "";
            txt3.value = "";
            txt4.value = "";
            txt5.value = "";
            txt6.value = "";
            txt7.value = "0";
            txt8.value = "0";
            txt9.value = "";
            txt10.value = "Select";
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfExcel" runat="server" />
    <asp:HiddenField ID="PrintStatus" runat="server" />
    <asp:HiddenField ID="hfgridview" runat="server" />
    <asp:HiddenField ID="deletestatus" runat="server" />
    <div class="content-header">
        <div class="header-section">
            <h2>Account</h2>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a> </li>
        <li>Account</li>
    </ul>
    <div class="block full">
        <div class="block-title">
            <h2><strong>Account</strong> List</h2>
        </div>
        <div class="row">
            <asp:Panel runat="server" DefaultButton="btnsubmit">
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Company</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Company Name" data-toggle="tooltip" title="Company Name"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Contact Person</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtContactPerson" runat="server" placeholder="Contact Person" data-toggle="tooltip" title="Contact Person"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Phone</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" data-toggle="tooltip" title="Phone"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Email</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtEmailColumn" runat="server" placeholder="Email" data-toggle="tooltip" title="Email"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Mobile</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtMobile" runat="server" placeholder="Mobile" data-toggle="tooltip" title="Mobile" onkeyup="this.value=this.value.replace(/[^\d]/g,'');"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">City</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtCity" runat="server" placeholder="City" data-toggle="tooltip" title="City"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div style="clear: both"></div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Account Owner</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="ddlCustOwner" CssClass="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txtAccountOwner" runat="server" placeholder="Account Owner" data-toggle="tooltip" title="Account Owner" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Assign To</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAssignTo" runat="server" placeholder="Assign To" data-toggle="tooltip" title="Assign To"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Created By</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="ddlCreatedBy" CssClass="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txtCreatedBy" runat="server" placeholder="Created By" data-toggle="tooltip" title="Created By" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleast one field and minimum 3 characters required." ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                </div>
                <%--<div style="clear: both"></div>--%>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">From</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="ddlFrom" CssClass="form-control">
                            <asp:ListItem Text="Select from" Value="Select"></asp:ListItem>
                            <asp:ListItem Text="CRM" Value="CRM"></asp:ListItem>
                            <asp:ListItem Text="B2B" Value="B2B"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtFrom" runat="server" placeholder="From" data-toggle="tooltip" title="From" Visible="false"
                            CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="col-sm-12 text-right">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary" Style="margin-right: 10px;"></asp:HyperLink>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" Style="margin-right: 10px;" />
                        <button id="btnClearAll1" type="button" class="btn btn-sm btn-warning" style="margin-right: 10px;" onclick="ClearAllFunction()">Clear All</button>
                        <%--<asp:Button ID="btnClearAll" runat="server" Text="Clear All" class="btn btn-sm btn-warning" Style="margin-right: 10px;" />--%>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-sm btn-info pull-right" UseSubmitBehavior="false"
                            OnClientClick="if (!Page_ClientValidate('MasterGroupSearch')){ return false; } this.disabled = true; this.value = 'Searching...';"></asp:Button>
                    </div>
                </div>
            </asp:Panel>
        </div>
        <div class="row">

            <div class="col-sm-12 text-right">
                <%--<asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />--%>
            </div>
        </div>
        <div class="table-responsive" runat="server" id="divMain" visible="false">

            <div class="table-options clearfix" style="background-color: #f9fafc; padding: 8px 0 5px; width: auto; border: 1px solid #eaedf1;">

                <div class="col-md-2">
                    <div>
                        <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-sm-8">
                </div>
                <div class="col-sm-3 pull-right input-group" style="padding-left: 15px; padding-right: 15px;">
                    <asp:TextBox runat="server" ID="txtSearch" class="form-control" placeholder="Search" OnTextChanged="Text_TextChanged"></asp:TextBox>
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                </div>

            </div>

            <asp:UpdatePanel runat="server" ID="rpg">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server">
                        <%--  <asp:UpdatePanel runat="server" ID="rpg">
                    <ContentTemplate>--%>
                        <table id="printtable" class="table table-vcenter table-condensed table-bordered" style="margin-bottom: 0px;">
                            <thead>
                                <tr>
                                    <th id="thEdit" runat="server" class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">Edit</th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Acc_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Company Name</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Contact_ContactPerson" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Contact Person</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Contact_Landline" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Phone</asp:LinkButton>
                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Contact_Email" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Email</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Contact_Mobile" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Mobile</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="city" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>City</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="U_FirstName" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Account Owner</asp:LinkButton>

                                    </th>

                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="AssignTo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Assign To</asp:LinkButton>

                                    </th>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="CreatedBy" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Created By</asp:LinkButton>

                                    </th>
                                    <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">For</th>--%>
                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                        <asp:LinkButton ID="Acc_OpenFrom" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>From</asp:LinkButton>

                                    </th>

                                    <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server" visible="false">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rpgridview" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td id="tdEdit" runat="server" class="text-center">
                                                <%-- <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# "ModifyAccount.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>

                                                <a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("Acc_Id").ToString()%>)'><i class="fa fa-pencil"></i></a>
                                            </td>
                                            <td class="text-center">
                                                <%--<asp:HyperLink ID="HyperLink1" NavigateUrl='<%# "ViewAccount.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Acc_Id").ToString()))%>'
                                                    data-toggle="tooltip" title="View" runat="server">
                                                    <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name")))%>' />
                                                </asp:HyperLink>--%>
                                                <a id="lkView" data-toggle="tooltip" title="View" style='cursor: pointer;' onclick='lkviewclick(<%#Eval("Acc_Id").ToString()%>)'>
                                                    <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_Name")))%>' />
                                                </a>
                                                <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("Acc_Id"))%>' Visible="false" />
                                            </td>

                                            <td class="text-center">
                                                <asp:Literal ID="lblname" runat="server" Text='<%#Eval("Contact_ContactPerson")%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblphone" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Landline"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Email"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblmobile" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Contact_Mobile"))%>' /></td>
                                            <td class="text-center">
                                                <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("city"))%>' />
                                            </td>
                                            <%--<td class="text-center">
                                                <asp:Label ID="lblType" runat="server"  Text='<%#Eval("Acc_Type").ToString%>' EnableViewState="false" />
                                            <asp:Literal ID="lblowner" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
                                            </td>--%>
                                            <td class="text-center">
                                                <asp:Literal ID="lblowner" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("U_FirstName")))%>' />
                                            </td>
                                            <td class="text-center">
                                                <asp:Label ID="lblassignto" runat="server" Text='<%#Eval("AssignTo")%>' /></td>
                                            <td class="text-center">
                                                <asp:Label ID="lblCreatedBy" runat="server" Text='<%#Eval("CreatedBy")%>' /></td>
                                            <%--<td class="text-center">
                                                <asp:Label ID="lblFor" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Reseller_Name"))%>' EnableViewState="false" />
                                            </td>--%>
                                            <td class="text-center">
                                                <asp:Label ID="lblfrom" runat="server" CssClass='<%#(Eval("Class"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Acc_OpenFrom")))%>' />
                                                <%--<asp:Label ID="lblfrom" runat="server" CssClass='<%#Security.OrderFrom(Eval("Acc_OpenFrom"))%>' Text='<%#(If(Eval("Acc_OpenFrom") = "CRM", "CRM", "B2B"))%>' />--%>
                                            </td>

                                            <%--<td class="text-center" id="tdEdit" runat="server" visible="false">
                                                <a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" href='<%#"ModifyAccount.aspx?chk=e&ID=" + HttpUtility.UrlEncode(Security.Encrypt( Eval("Acc_Id").ToString()))%>'><i class="fa fa-pencil"></i></a>&nbsp;
                                                <asp:LinkButton ID="btndelete" CommandName="Delete" Visible="false" CommandArgument='<%#Eval("Acc_Id")%>' OnClientClick="lkdeleteclick()" data-toggle="tooltip" title="Delete" class="btn btn-alt btn-xs btn-danger" runat="server"><i class="fa fa-times"></i></asp:LinkButton>
                                            </td>--%>
                                        </tr>

                                    </ItemTemplate>


                                    <FooterTemplate>
                                        <tr id="trEmpty" runat="server" visible="false">
                                            <td class="dataTables_empty" style="width: 240px;">No matching records found.
                                            </td>
                                        </tr>

                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:Label ID="Label1" runat="server" Text="No matching records found" Visible="false"></asp:Label>
                                <tfoot style="display: none;">
                                    <tr>
                                        <th class="text-center"></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox1" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Company Name" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox2" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Contact Person" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox3" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Phone" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox4" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Email" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox5" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Mobile" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox6" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="City" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox9" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Type" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox7" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="Assign To" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center" style="display: none;"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox10" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="For" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>
                                        <th class="text-center"><span class="filter_column filter_text">
                                            <asp:TextBox ID="TextBox8" runat="server" Style="text-align: center; font-weight: 500; margin: 0 auto;" class="text-center form-control text_filter" onkeyup="searchfoot(this)" placeholder="From" OnTextChanged="Text_TextChanged"></asp:TextBox></span></th>

                                        <th class="text-center"><span class="filter_column filter_text"></span></th>
                                        <%--  <th class="text-center"><span class="filter_column filter_text">
                                           </span></th>
                                      <th class="text-center"><span class="filter_column filter_text">
                                           </span></th>--%>
                                    </tr>
                                </tfoot>


                            </tbody>

                        </table>
                        <%--   </ContentTemplate>
                    </asp:UpdatePanel> --%>
                        <asp:HiddenField ID="hfBackcount" runat="server" />
                        <asp:HiddenField ID="tab" runat="server" />
                        <div class="row" style="margin: 0px;">
                            <div class="col-md-12" style="background-color: #f9fafc; padding: 10px 0; border: 1px solid #eaedf1; border-top-width: 0;">
                                <div class="col-sm-5 hidden-xs">
                                    <div class="dataTables_info" role="status" aria-live="polite">
                                        <%--  <strong>1</strong>-<strong>10</strong> of <strong>10</strong>--%>

                                        <strong>
                                            <asp:Label ID="lblTcount" runat="server"></asp:Label></strong>

                                    </div>
                                </div>
                                <div class="col-sm-7 col-xs-12 clearfix">
                                    <div class="dataTables_paginate paging_bootstrap" id="example-datatable_paginate">
                                        <%--  <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>--%>
                                        <ul id="menu" class="pagination pagination-sm remove-margin" style="height: 12px;">

                                            <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand" OnItemDataBound="rptPaging_ItemDataBound">

                                                <ItemTemplate>

                                                    <li data-category="TestValue" id="li1">

                                                        <asp:LinkButton ID="btnPage" CssClass="" class="dataTables_paginate paging_bootstrap" data-category="TestValue"
                                                            CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                                            runat="server" Font-Bold="True"><%# Container.DataItem %>
                                                        </asp:LinkButton>
                                                    </li>
                                                </ItemTemplate>

                                            </asp:Repeater>


                                        </ul>
                                        <%--   </ContentTemplate>
                                     
                    </asp:UpdatePanel> --%>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="rpgridview" />
                      <asp:AsyncPostBackTrigger ControlID="rptPaging" />--%>
                    <%-- <asp:AsyncPostBackTrigger ControlID="rptPaging"  EventName="rptPaging_ItemCommand"/>--%>
                </Triggers>

            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>

