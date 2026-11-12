<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyCompany.aspx.vb" Inherits="ModifyCompany" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=Image1 .ClientID %>');
            var file = document.querySelector('#<%=FileUploadControl .ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }
            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }

        function previewFile1() {
            var preview = document.querySelector('#<%=Image2.ClientID%>');
            var file1 = document.querySelector('#<%=FileUploadControl1.ClientID%>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }
            if (file1) {
                reader.readAsDataURL(file1);
            } else {
                preview.src = "";
            }
        }

        function previewFile2() {
            var preview = document.querySelector('#<%=Image3.ClientID%>');
            var file2 = document.querySelector('#<%=FileUploadControl2.ClientID%>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }
            if (file2) {
                reader.readAsDataURL(file2);
            } else {
                preview.src = "";
            }
        }
    </script>

    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
        <asp:HiddenField ID="hfimgpath" runat="server" />
        <asp:HiddenField ID="hfimgpathheader" runat="server" />
        <asp:HiddenField ID="hfimgpathfooter" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-user" style="margin: -8px"></i>Company<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Company</li>
            </ul>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                    <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/index.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Company</strong> Information
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
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Company Name :</label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblname" CssClass="form-control text-primary" Font-Bold="true" runat="server"  Style="border-color: white;"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6" runat="server" id="divpass">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date Of Registration : </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblregestration" CssClass="form-control text-primary" Font-Bold="true" runat="server"  Style="border-color: white;"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date Of Expiry :</label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblexpiry" CssClass="form-control text-primary" Font-Bold="true" runat="server"  Style="border-color: white;"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Contact Person : </label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblcontactperson" CssClass="form-control text-primary" Font-Bold="true" runat="server"  Style="border-color: white;"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">No Of User :</label>
                                    <div class="col-md-8">
                                        <asp:Label ID="lbluser" CssClass="form-control text-primary" runat="server" Font-Bold="true" Text="6" Style="border-color: white;"></asp:Label>

                                    </div>
                                </div>
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
                            <strong>Contact</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Phone No :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtphone" runat="server" placeholder="Phone No" data-toggle="tooltip" title="Phone No" TextMode="Number" min="0" TabIndex="1"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorphone" runat="server" ControlToValidate="txtphone" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter phone number" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid phone number" ControlToValidate="txtphone"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-password">Email :</label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" TabIndex="2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reemail" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regemail" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:Label ID="lblemail" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Fax No :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtfax" runat="server" placeholder="Fax No" data-toggle="tooltip" title="Fax No " TabIndex="3"
                                            CssClass="form-control"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatorfaxno" runat="server" ControlToValidate="txtfax" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Fax No " Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <br />
                                    </div>
                                </div>
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
                                <br />
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Address1 :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtadd1" runat="server" placeholder="Enter Address1" data-toggle="tooltip" title="Address1" TabIndex="4" TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtadd1" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter address" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Address2 :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtadd2" runat="server" placeholder="Enter Address2" data-toggle="tooltip" title="Address2" TabIndex="5" TextMode="MultiLine" Rows="2"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtadd2" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter address" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">State : </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddstate" runat="server" name="example-chosen" class="select-chosen" TabIndex="6"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorstate" runat="server" ControlToValidate="ddstate" InitialValue="Select State" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select State" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Country :</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddcountry" runat="server" name="example-chosen" class="select-chosen" TabIndex="7"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorcountry" runat="server" ControlToValidate="ddcountry" InitialValue="Select Country" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select country" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                </div>
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
                            <strong>Tax</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">PAN :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpan" runat="server" placeholder="PAN" data-toggle="tooltip" title="PAN " TabIndex="8"
                                            CssClass="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorpan" runat="server" ControlToValidate="txtpan" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter PAN" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">CIN :</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcin" runat="server" placeholder="CIN" data-toggle="tooltip" title="CIN" TabIndex="9"
                                            CssClass="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorcin" runat="server" ControlToValidate="txtcin" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter CIN" Display="Dynamic"></asp:RequiredFieldValidator> --%>
                                        <br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">CST No : </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcst" runat="server" placeholder="CST No " data-toggle="tooltip" title="CST No " TabIndex="10"
                                            CssClass="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorcst" runat="server" ControlToValidate="txtcst" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter CST No" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">VAT/TIN No : </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtvat" runat="server" placeholder="VAT/TIN No " data-toggle="tooltip" title="VAT/TIN No " TabIndex="11"
                                            CssClass="form-control"></asp:TextBox>
                                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidatorvat" runat="server" ControlToValidate="txtvat" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter VAT/TIN No" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                        <br />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Service Tax Reg No : </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtsertaxregno" runat="server" placeholder="Service Tax Reg No" data-toggle="tooltip" title="Service Tax Reg No" TabIndex="12"
                                            CssClass="form-control"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorsregno" runat="server" ControlToValidate="txtsertaxregno" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter Service Tax Reg No" Display="Dynamic"></asp:RequiredFieldValidator>--%><br />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Sales Target : </label>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddsalestargettime" runat="server" name="example-chosen" class="select-chosen" TabIndex="13">
                                            <asp:ListItem>Monthly</asp:ListItem>
                                            <asp:ListItem>Quarterly</asp:ListItem>
                                            <asp:ListItem>Annually</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddsalestargettype" runat="server" name="example-chosen" class="select-chosen" TabIndex="14">
                                            <asp:ListItem>Total Sales Value</asp:ListItem>
                                            <asp:ListItem>Sales Value without tax</asp:ListItem>
                                            <asp:ListItem>Quantity</asp:ListItem>
                                        </asp:DropDownList>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorsalestar" runat="server" ControlToValidate="ddsalestargettime" InitialValue="Select Sales Target" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Sales Target" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
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
                            <strong>Images</strong>
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <label for="example-hf-password">Icon : </label>
                                <input id="FileUploadControl" type="file" name="file" onchange="previewFile()" runat="server" tabindex="15" /><br />
                                    <asp:Image ID="Image1" runat="server" Height="80px" Width="170px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfileup" runat="server" ValidationGroup="MasterGroup" SetFocusOnError="true" ControlToValidate="FileUploadControl"
                                    ErrorMessage="Invalid image file" ForeColor="Red"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
                                </asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-4">
                                <label for="example-hf-password">Header Image : </label>
                                <input id="FileUploadControl1" type="file" name="file1" onchange="previewFile1()" runat="server" tabindex="15" /><br />
                                <asp:Image ID="Image2" runat="server" Height="80px" Width="170px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="MasterGroup" SetFocusOnError="true" ControlToValidate="FileUploadControl"
                                    ErrorMessage="Invalid image file" ForeColor="Red"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
                                </asp:RegularExpressionValidator>
                            </div>

                            <div class="col-md-4">
                                <label for="example-hf-password">Footer Image : </label>
                                <input id="FileUploadControl2" type="file" name="file2" onchange="previewFile2()" runat="server" tabindex="15" /><br />
                                <asp:Image ID="Image3" runat="server" Height="80px" Width="170px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="MasterGroup" SetFocusOnError="true" ControlToValidate="FileUploadControl"
                                    ErrorMessage="Invalid image file" ForeColor="Red"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div style="clear: both"></div>
                    </div>
                </div>
            </div>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="16" />
                    <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/index.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="17" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

