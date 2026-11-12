<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyVendor.aspx.vb" Inherits="ModifyVendor" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
<%--    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
    </script>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server"></asp:Label><br>
                        <asp:Label ID="lblconvertdate" runat="server" Visible="false"></asp:Label>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Vendor.aspx">Vendor</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
                <asp:HiddenField ID="strrowcount" runat="server" />
            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <div class="" style="">
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                        <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Vendor.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Vendor</strong> Information
                            <small>
                                <span class="pull-right" id="modifyspan" runat="server">By&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration: none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
                                </span>
                            </small>
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">Company Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVendorname" runat="server" placeholder="Enter Company Name" data-toggle="tooltip" title="Enter Company Name" 
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reVendorname" runat="server" ControlToValidate="txtVendorname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter company name" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="col-md-4" id="divcode" runat="server">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Vendor Code</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcode" runat="server" placeholder="Enter Vendor Code" data-toggle="tooltip" title="Enter Vendor Code" TabIndex="2"
                                            CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtVendorname" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter code" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <%-- <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Industry</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlindustry" runat="server" name="example-chosen" class="select-chosen" TabIndex="3"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="ddlindustry" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select industry" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Type<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddltype" runat="server" name="example-chosen" class="select-chosen" >                                           
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator InitialValue="Select Vendor Type"  ID="recompnytype" runat="server" ControlToValidate="ddltype" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Vendor Type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div style="clear: both;"></div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">CST No</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtCstNo" runat="server" placeholder="Enter CST No" data-toggle="tooltip" title="Enter CST No" 
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>

                           <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">VAT TIN No</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtVatTinNo" runat="server" placeholder="Enter VAT TIN No" data-toggle="tooltip" title="Enter VAT TIN No" 
                                            CssClass="form-control"></asp:TextBox>
                                       
                                    </div>
                                </div>
                            </div>
                                  <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">GST No</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtgstno" runat="server" placeholder="Enter GST No" data-toggle="tooltip" title="Enter GST No" 
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator InitialValue="Select Vendor Type"  ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgstno" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter GST No" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Source</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlsource" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true" TabIndex="5"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlsource" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select source" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-4" runat="server" id="divcampaign">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">Campaign</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlcamp" runat="server" name="example-chosen" class="form-control" TabIndex="6"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlsource" ValidationGroup="DemofffMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select source" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                                                                           
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlsource" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Turn Over</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtturnover" runat="server" placeholder="Enter Turn Over" data-toggle="tooltip" title="Enter Turn Over" TabIndex="7"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="returnover" runat="server" ControlToValidate="txtturnover" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter turn over" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Website</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtwebsite" runat="server" placeholder="Enter Website" data-toggle="tooltip" title="Enter Website" TabIndex="8"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rewebsite" runat="server" ControlToValidate="txtwebsite" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter Website" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Opening Balance </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtopenbal" runat="server" placeholder="Enter Opening Balance" data-toggle="tooltip" title="Enter Opening Balance" TabIndex="8"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtopenbal" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter opening balance" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
                            <%--<div class="col-md-4" id="divdiscription" runat="server">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Discription</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdiscription" runat="server" placeholder="Enter Discription" data-toggle="tooltip" title="Enter Discription" TabIndex="10"
                                            CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rediscription" runat="server" ControlToValidate="txtdiscription" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select discription" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <%--<div class="col-md-12">
                                <User:AssignControl ID="assigncontrol" runat="server" />
                            </div>--%>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="Hfdropdown" runat="server" />
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light">
                            <strong>Contact</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                          <div class="block">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
                                        <ContentTemplate>
                                            <div class="table-responsive">
                                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                    CssClass="table table-striped table-vcenter table" ShowFooter="true">
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" Visible="false" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <div class="col-md-6" runat="server" visible="false">
                                                                    <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField>
                                                            <ItemTemplate>
                                                                <div class="col-md-6">
                                                               <asp:RadioButton ID="chkoneday" runat="server" class="checkbox-inline" for="example-inline-checkbox" GroupName="holiday" Style="margin-bottom: 11px;" ></asp:RadioButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField HeaderText="Principle Name" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="" Visible="false" >
                                                            <ItemTemplate>
                                                                <div class="input-group  col-md-12">
                                                                    <span class="input-group-addon"><i class="gi gi-tags"></i></span>                                                                   
                                                                    <asp:TextBox ID="txtserialno5" runat="server" CssClass="form-control decimal"  ></asp:TextBox>
                                                                                                                        </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField  HeaderText ="Primary" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" Visible="true" >
                                                            <ItemTemplate>
                                                                <asp:Literal  ID="ltcontactID" runat="server" Text='<%#Eval("Contact_Id")%>' Visible="false" ></asp:Literal>
                                                                <%--<asp:RadioButton  ID="MyRadioButton1" runat ="server" Checked='<%#Eval("Contact_Primary").ToString().Equals("True")%>'  GroupName ="select" AutoPostBack ="true"  OnCheckedChanged ="MyRadioButton1_CheckedChanged"  CssClass = "form-control " />--%>
                                                                     <%--<asp:CheckBox ID="ckselect"   runat="server" Checked='<%#Eval("Contact_IsSecondary").ToString().Equals("True")%>'    OnCheckedChanged="ckselect_CheckedChanged"/>--%>
                                                                
                                                                  <asp:CheckBox ID="ckselect" runat="server" Checked='<%# Eval("Contact_IsSecondary").ToString().Equals("True")%>'   />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtserialno4" runat="server" CssClass="form-control "   Text='<%#Eval("Contact_ContactPerson")%>'></asp:TextBox>
                                                              <asp:RequiredFieldValidator ID="rfvcntctprsn" runat="server" Display ="Dynamic"  ControlToValidate ="txtserialno4" ErrorMessage ="Enter Contact Person" ForeColor="Red"  ValidationGroup ="MasterGroup"></asp:RequiredFieldValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                       

                                                        <asp:TemplateField HeaderText="EmailID" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtserialno2" runat="server" CssClass="form-control"  Text='<%#Eval("Contact_Email")%>'></asp:TextBox>
                                                           <asp:RegularExpressionValidator runat="server" Display ="Dynamic"  ValidationExpression ="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup ="Save" ControlToValidate ="txtserialno2" errormessage="Enter valid Email" ForeColor ="Red"  ></asp:RegularExpressionValidator>
                                                                 </ItemTemplate>
                                                        </asp:TemplateField>

                                                         <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtserialno3" runat="server" CssClass="form-control decimal"  Text='<%#Eval("Contact_Mobile")%>'></asp:TextBox>
                                                          
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Phone" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtserialno1" runat="server" CssClass="form-control decimal" Text='<%#Eval("Contact_Landline")%>'></asp:TextBox>
                                                                
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" Visible="false" >
                                                            <ItemTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();" 
                                                                        CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info"  runat="server" 
                                                                        CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="gi gi-plus"></i></asp:LinkButton>
                                                                </div>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                    <PagerSettings PageButtonCount="4" />
                                                    <EmptyDataTemplate>
                                                        <h3>Add Receipt Detail</h3>
                                                        <div class="btn-group btn-group-xs" style="align-content: center;">
                                                            <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="100px"
                                                                CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"> Add Receipt</asp:LinkButton>
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
                                <div style="clear: both;"></div>
                                <br />

                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Address</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <%--<h5><strong>Billing Address :</strong></h5>--%>
                                <br />
                            </div>

                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter name" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtaddemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtaddemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <%--<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Telephone No<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddphone" runat="server" placeholder="Enter Telephone Number" data-toggle="tooltip" title="Enter Telephone Number"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtaddphone"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"  ValidationGroup ="MasterGroup"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaddphone" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter phone no" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator><br />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-md-8">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Address<span class="text-danger"> *</span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtaddressbill" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="readdressbill" runat="server" ControlToValidate="txtaddressbill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter address" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Pincode<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpincodebill" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtpincodebill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter pincode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">City<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcitybill" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter City"
                                            CssClass="form-control"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Country</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlcountrybill" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recountrybill" runat="server" ControlToValidate="ddlcountrybill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">State<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlstatebill" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="restatebill" runat="server" ControlToValidate="ddlstatebill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select State" InitialValue="0" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>


                            
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>

                

                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Principle</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="block">
                                <div class="col-md-12">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="table-responsive">
                                                <asp:HiddenField ID="hfgrandtotal" runat="server" />
                                                <asp:HiddenField ID="hfbarcodechk" runat="server" />
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                    CssClass="table table-striped table-vcenter table" ShowFooter="true">
                                                    <Columns>
                                                        <asp:BoundField DataField="RowNumber" Visible="false" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <div class="col-md-6" runat="server" visible="false">
                                                                    <asp:Label runat="server" ID="RowNumber" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Principle Name" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                            <ItemTemplate>
                                                                <div class="input-group  col-md-12">
                                                                    <span class="input-group-addon"><i class="gi gi-tags"></i></span>
                                                                    <asp:DropDownList ID="ddprinciple" runat="server" CssClass="select-chosen" OnSelectedIndexChanged="ddprinciple_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator InitialValue="Select Principle" ID="rfvddprinciple" runat="server" Display ="Dynamic"  ControlToValidate ="ddprinciple" ErrorMessage ="Select Principle" ForeColor="Red"  ValidationGroup ="MasterGroup"></asp:RequiredFieldValidator>
                                                                    <asp:Literal ID="ltattid" runat="server" Text='<%#Eval("Principle_ID")%>' Visible="false"></asp:Literal>
                                                                </div>

                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Contact Person" HeaderStyle-CssClass="MasterGridviewHeader"  HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcontact" runat="server" Text='<%#Eval("Principle_ContactPerson")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mobile" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmobile" runat="server" Text='<%#Eval("Principle_MobileNo")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="EmailID" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" runat="server" Text='<%#Eval("Principle_EmailID")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="City" HeaderStyle-CssClass="MasterGridviewHeader" HeaderStyle-ForeColor="#1bbae1" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcity" runat="server" Text='<%#Eval("Principle_City")%>'></asp:Label>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
                                                            <ItemTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();" 
                                                                        CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <div class="btn-group btn-group-xs">
                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info"  runat="server" 
                                                                        CommandName="AddNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="gi gi-plus"></i></asp:LinkButton>
                                                                </div>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                    <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                    <PagerSettings PageButtonCount="4" />
                                                    <EmptyDataTemplate>
                                                        <h3>Add Principle Detail</h3>
                                                        <div class="btn-group btn-group-xs" style="align-content: center;">
                                                            <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" Font-Size="20px" Width="100px"
                                                                CommandName="Add" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"> Add Principle</asp:LinkButton>
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
                                <div style="clear: both;"></div>
                                <br />

                            </div>


                        </div>
                    </div>
                </div>

                 <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <div class="pull-right">
                        </div>
                        <h4 class="widget-content-light">
                            <strong>Additional</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                              
                                <br />
                            </div> 
                            <div class="col-md-12"> 
                          <div class="col-md-6">                               
                                    <label class="control-label" for="example-hf-email">Payment Terms<%--<span class="text-danger"> *</span>--%></label>
                                   
                                        <asp:TextBox ID="txtPaymentTerms" runat="server" placeholder="Enter Payment Terms" data-toggle="tooltip" title="Enter Payment Terms" TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaymentTerms" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Payment Terms" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                   
                               
                            </div>
                            <div class="col-md-6">                               
                                    <label class="control-label" for="example-hf-email">Payment Terms In Days<span class="text-danger"> *</span></label>
                                   
                                        <asp:TextBox ID="txtTermDays" runat="server" placeholder="Enter Payment Terms In Days" onkeyup="this.value=this.value.replace(/\D/g,'');" data-toggle="tooltip" title="Enter Payment Terms In Days"  maxlength="4"
                                            CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ForeColor="Red" runat="server" ControlToValidate="txtTermDays" SetFocusOnError="true" ErrorMessage="This is required field"></asp:RequiredFieldValidator>
                                 <%--<asp:RegularExpressionValidator runat="server" ErrorMessage="Integer Only" ValidationGroup="MasterGroup" ControlToValidate="txtTermDays"
      ValidationExpression="^[0-9]}$" SetFocusOnError="true" Display="Dynamic"></asp:RegularExpressionValidator> --%>
                                       
                               
                            </div>
                                </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Vendor.aspx" class="btn btn-alt btn-danger" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

