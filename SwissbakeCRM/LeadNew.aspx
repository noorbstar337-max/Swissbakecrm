<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="LeadNew.aspx.vb" Inherits="LeadNew" %>

<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jquery.min.js"></script>
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
    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
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
    <script type="text/javascript">
        function lkviewclick(id) {

            var a = "";
            // var id= "321";
            // var c = +Prodname;
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;
                },
                async: false
            });

            window.location.href = "ViewLead.aspx?Id=" + a;
        }
        function lkEditclick(id, ProdName) {

            var a = "";
            $.ajax({
                type: "POST",
                url: "ItemcontrolService.asmx/Encrypt",
                data: '{id: ' + id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    a = response.d;
                },
                async: false
            });
            
            window.location.href = "ModifyLead.aspx?chk=e&Id=" + a;
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
            //var txt7 = document.getElementById("<%= txtSalesStage.ClientID%>");
            var txt7 = document.getElementById("<%= ddlstage.ClientID%>");
            //var txt8 = document.getElementById("<%= txtSource.ClientID%>");
            var txt8 = document.getElementById("<%= ddlsource.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            args.IsValid = (txt1.value != "" && txt1.value.length >= 3) || (txt2.value != "" && txt2.value.length >= 3) || (txt3.value != "" && txt3.value.length >= 3) || (txt4.value != "" && txt4.value.length >= 3) || (txt5.value != "" && txt5.value.length >= 3) || (txt6.value != "" && txt6.value.length >= 3) || (txt7.value != "-1") || (txt8.value != "-1") || (txt9.value != "" && txt9.value.length >= 3);
        }

        function ClearAllFunction() {
            var txt1 = document.getElementById("<%= txtCompanyName.ClientID%>");
            var txt2 = document.getElementById("<%= txtContactPerson.ClientID%>");
            var txt3 = document.getElementById("<%= txtPhone.ClientID%>");
            var txt4 = document.getElementById("<%= txtEmailColumn.ClientID%>");
            var txt5 = document.getElementById("<%= txtMobile.ClientID%>");
            var txt6 = document.getElementById("<%= txtCity.ClientID%>");
            var txt7 = document.getElementById("<%= ddlstage.ClientID%>");
            var txt8 = document.getElementById("<%= ddlsource.ClientID%>");
            var txt9 = document.getElementById("<%= txtAssignTo.ClientID%>");
            txt1.value = "";
            txt2.value = "";
            txt3.value = "";
            txt4.value = "";
            txt5.value = "";
            txt6.value = "";
            txt7.value = "-1";
            txt8.value = "-1";
            txt9.value = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="deletestatus" runat="server" />
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfExcel" runat="server" />
    <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="gi gi-parents" style="margin: -8px"></i>Lead<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Lead</li>
    </ul>
    <div class="block">
        <div class="block-title">
            <h2><strong>Lead</strong> Detail</h2>
        </div>
        <%--Search User Control Start--%>
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
                    <label class="col-md-4 control-label" for="example-hf-email">Sales Stage</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlstage" runat="server" name="example-chosen" class="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txtSalesStage" runat="server" placeholder="Sales Stage" data-toggle="tooltip" title="Sales Stage" Visible="false"
                            CssClass="form-control"></asp:TextBox>

                    </div>
                </div>
                <div class="col-md-4">
                    <label class="col-md-4 control-label" for="example-hf-email">Source</label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="ddlsource" runat="server" name="example-chosen" class="form-control"></asp:DropDownList>
                        <asp:TextBox ID="txtSource" runat="server" placeholder="Source" data-toggle="tooltip" title="Source" Visible="false"
                            CssClass="form-control"></asp:TextBox>
                        <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Atleast one field and minimum 3 characters required." ValidationGroup="MasterGroupSearch"
                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneField_ServerValidate"
                            ClientValidationFunction="AtLeastOneField_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                    </div>
                </div>
                <div class="col-md-4" style="display: none;">
                    <label class="col-md-4 control-label" for="example-hf-email">Assign To</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtAssignTo" runat="server" placeholder="Assign To" data-toggle="tooltip" title="Assign To"
                            CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <%--<div style="clear: both"></div>--%>
                <div class="col-sm-12 text-right">
                    <div class="col-md-12">
                        <asp:HyperLink ID="hlnkAdd" EnableViewState="false" runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
                        <asp:Button ID="lkadd" EnableViewState="false" runat="server" Text="Quick Add" CssClass="btn btn-alt btn-sm btn-primary"></asp:Button>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-alt btn-sm btn-success " CausesValidation="false" Text="Export to Excel" Visible="false" />
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
                <asp:Button ID="lkadd" EnableViewState="false" runat="server" Text="Quick Add" CssClass="btn btn-alt btn-sm btn-primary"></asp:Button>
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
            <%--Search User Control End--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="hfcheck" runat="server" />
                    <asp:HiddenField ID="hfchanged" runat="server" />
                    <asp:HiddenField ID="hfsearch" runat="server" />
                    <asp:HiddenField ID="hfquery" runat="server" />
                    <asp:HiddenField ID="hfmodule" runat="server" />
                    <asp:HiddenField ID="hftopquery" runat="server" />
                    <asp:HiddenField ID="hftopquerycheck" runat="server" />
                    <asp:HiddenField ID="hfReport_Type" runat="server" />
                    <asp:HiddenField ID="Hfsearchcheck" runat="server" />
                    <asp:HiddenField ID="hfsearchquery" runat="server" />
                    <div class="table-responsive">
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
                                                    <asp:LinkButton ID="Lead_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Company Name</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="LeadContact_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Contact Person</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="LeadContact_OfficeNo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Phone</asp:LinkButton>
                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="LeadContact_Email" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Email</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="LeadContact_MobileNo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Mobile</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="City" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>City</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Stage_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Sales Stage</asp:LinkButton>

                                                </th>

                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="Source_Name" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Source</asp:LinkButton>

                                                </th>
                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">
                                                    <asp:LinkButton ID="AssignTo" OnClick="Sorting" runat="server" class="text-center" Style="font-size: 14px; font-weight: 600; color: #1bbae1;"><i class="hi hi-sort fa-1x"></i>Assign To</asp:LinkButton>

                                                </th>
                                                <%--<th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;">For</th>--%>

                                                <th class="text-center" style="font-size: 14px; font-weight: 600; color: #1bbae1;" id="thEdit1" runat="server" visible="false">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="rpgridview" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td id="tdEdit" runat="server" class="text-center">
                                                            <a id="lkedit" data-toggle="tooltip" title="Edit" class="btn btn-alt btn-xs btn-primary" onclick='lkEditclick(<%#Eval("Lead_Id").ToString()%>)'><i class="fa fa-pencil"></i></a>
                                                        </td>
                                                        <td class="text-center">
                                                            <a id="lkView" data-toggle="tooltip" title="View" style='cursor: pointer;' onclick='lkviewclick(<%#Eval("Lead_Id").ToString()%>)'>
                                                                <asp:Literal ID="lblcontact" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Lead_Name")))%>' />
                                                            </a>
                                                            <asp:Literal ID="lbluId" runat="server" Text='<%#(Eval("Lead_Id"))%>' Visible="false" />
                                                        </td>

                                                        <td class="text-center">
                                                            <asp:Literal ID="lblname" runat="server" Text='<%#Eval("LeadContact_Name")%>' /></td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblphone" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LeadContact_OfficeNo"))%>' /></td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblemail" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LeadContact_Email"))%>' /></td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblmobile" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("LeadContact_MobileNo"))%>' /></td>
                                                        <td class="text-center">
                                                            <asp:Literal ID="lblCity" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("City"))%>' />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblstage" runat="server" Style="color: white; padding: 0 10px; border-radius: 3px;" BackColor='<%#(System.Drawing.Color.FromName(Eval("Stage_ColorBand").ToString))%>' Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Stage_Name"))%>' />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblSource" runat="server" Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("Source_Name"))%>' />
                                                        </td>
                                                        <td class="text-center">
                                                            <asp:Label ID="lblassignto" runat="server" Text='<%#Eval("AssignTo")%>' /></td>
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
                                        <label for="example-nf-email">Lead Name <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtleadname" runat="server" placeholder="Enter Lead Name" data-toggle="tooltip" title="Enter Lead Name"
                                            CssClass="form-control" TabIndex="1"></asp:TextBox>
                                        <asp:Label ID="lblname" runat="server" Style="color: red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtleadname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter lead name" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="example-nf-email">Lead Date <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtleaddate" runat="server" placeholder="dd/mm/yy" data-toggle="tooltip" title="Enter Lead Date"
                                            CssClass="form-control input-datepicker" data-date-format="dd/mm/yy" TextMode="Date" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="releaddate" runat="server" ControlToValidate="txtleaddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter date" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="form-group">
                                        <label for="example-nf-email">Contact Person <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control" TabIndex="3"></asp:TextBox><asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter name" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <label for="example-nf-email">Email <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" TabIndex="4" onkeyup="this.value=this.value.replace(/ /g, '');"></asp:TextBox>
                                        <asp:Label ID="lblemail" runat="server" Style="color: red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Email" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                    </div>
                                    <div class="form-group">
                                        <label for="example-nf-email">Mobile Number <span class="text-danger">*</span></label>
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control" TabIndex="5" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Mobile Number" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" SetFocusOnError="true"></asp:RegularExpressionValidator>

                                    </div>
                                    <div class="form-group">
                                        <label for="example-nf-email">Office Number <span class="text-danger"></span></label>
                                        <asp:TextBox ID="txtofficeno" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control" TabIndex="6"></asp:TextBox><br />
                                        <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention"
                                            CssClass="form-control" TabIndex="7"></asp:TextBox>
                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Atleast one contact required" ValidationGroup="MasterGroup"
                                            CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                            ClientValidationFunction="AtLeastOneContact_ClientValidate" SetFocusOnError="true"></asp:CustomValidator>
                                    </div>
                                    <div class="form-group" style="display: none;">
                                        <label for="example-nf-email">Notify by <span class="text-danger"></span></label>
                                        <asp:DropDownList ID="ddlnotifyby" runat="server" name="Title" CssClass="form-control" TabIndex="8">
                                            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>
                                            <asp:ListItem Text="Alert" Value="Alert"></asp:ListItem>
                                            <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="renotifyby" runat="server" ControlToValidate="ddlnotifyby" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Select Notify by" Display="Dynamic" SetFocusOnError="true" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnsave" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                        UseSubmitBehavior="false" class="btn btn-sm btn-primary" ValidationGroup="MasterGroup" Text="Save" TabIndex="8"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <%--<asp:AsyncPostBackTrigger ControlID="GridView1" />--%>
                    <asp:PostBackTrigger ControlID="btnsave" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnadd" />--%>
                    <%--<asp:AsyncPostBackTrigger ControlID ="btnshowall" />--%>
                    <%--<asp:PostBackTrigger ControlID ="btnExportExcel" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

