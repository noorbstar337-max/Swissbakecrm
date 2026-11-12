<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Profile.aspx.vb" Inherits="Profile" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfimgpath" runat="server" />
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-table" style="margin: -8px"></i>Profile<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li>Profile</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Profile Details</strong> </h2>
                </div>
                <div class="form-horizontal form-bordered">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">First Name :</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtfirstname" runat="server" placeholder="Enter First Name" data-toggle="tooltip" title="First Name" CssClass="form-control" TabIndex ="1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rqpagename" Display="Dynamic" runat="server" ControlToValidate="txtfirstname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter first name"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">Last Name :</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtlastname" runat="server" placeholder="Enter Last Name" data-toggle="tooltip" title="Last Name" CssClass="form-control" TabIndex ="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" runat="server" ControlToValidate="txtlastname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter last name"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">Email :</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email" data-toggle="tooltip" title="Email" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" runat="server" ControlToValidate="txtemail" ValidationGroup="profilegroup" CssClass="MasterValidationCSS" TabIndex ="3"
                                    ErrorMessage="Please enter a emailid"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Dynamic" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter a valid emailid" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">Mobile No :</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtmobile" runat="server" MaxLength="10" placeholder="Enter Mobile No" data-toggle="tooltip" title="Mobile No" CssClass="form-control" TabIndex ="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" runat="server" ControlToValidate="txtmobile" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter a mobile number"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Display="Dynamic" ValidationGroup="MasterGroup" runat="server" CssClass="MasterValidationCSS" ErrorMessage="Please enter valid mobile number" ValidationExpression="^[()0-9 +-]{8,15}$" SetFocusOnError="true" ControlToValidate="txtmobile"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">Date of Birthday :</label>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtdob" runat="server" TextMode ="Date"  placeholder="Enter DOB" data-toggle="tooltip" title="DOB" CssClass="form-control" TabIndex ="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Please enter DOB " Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12" id="compfileupload" runat="server">
                        <div class="form-group">
                            <label class="col-md-2" for="example-hf-password">Upload Image :</label>
                            <div class="col-md-4">
                                <input id="FileUploadControl" type="file" name="file" onchange="previewFile()" runat="server" tabindex ="6" /><br />
                                <asp:Image ID="Image1" runat="server" Height="116px" Width="206px" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorfileup" runat="server" ValidationGroup="MasterGroup" SetFocusOnError="true" ControlToValidate="FileUploadControl"
                                    ErrorMessage="Invalid Image File" ForeColor="Red"
                                    ValidationExpression="^([0-9a-zA-Z_\-~ :\\])+(.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.gif|.GIF|.png|.PNG)$"> 
                                </asp:RegularExpressionValidator><br />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" TabIndex="7" />
                        <asp:HyperLink ID="hfcancel" EnableViewState="False" Text="Cancel" runat="server" NavigateUrl="index.aspx" class="btn btn-alt btn-danger" TabIndex="8" />
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

