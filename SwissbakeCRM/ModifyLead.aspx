<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyLead.aspx.vb" Inherits="ModifyLead" MaintainScrollPositionOnPostback="true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 {
            padding-bottom: 0px;
        }
    </style>
    <script type="text/javascript">
        function AtLeastOneContact_ClientValidate(sender, args) {
            var txt1 = document.getElementById("<%= txtemail.ClientID%>");
            var txt2 = document.getElementById("<%= txtmob.ClientID%>");
            var txt3 = document.getElementById("<%= txtofficeno.ClientID%>");
            args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
        }
		
		function validateSource() {
            var ddlind = document.getElementById("<%= ddlindustry.ClientID%>");
            var ddlsrc = document.getElementById("<%= ddlsource.ClientID%>");
			
			if(ddlind.selectedIndex > 0 && ddlsrc.selectedIndex > 0)
					return true;
			else
			{
			alert('Industry or Source cannot be empty!');
					return false;
					}
			/*		
			var strUser = e.options[e.selectedIndex].value;

                var strUser1 = e.options[e.selectedIndex].text;
                if(strUser==0)
                {
                    alert("Please select a user");
                }
				
            //args.IsValid = (txt1.value != "") || (txt2.value != "") || (txt3.value != "");
			*/
		}
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField runat="server" ID="hfLeadName" />
    <asp:HiddenField runat="server" ID="hfLeadEmail" />
    <div class="row">
        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-parents" style="margin: -8px"></i>
                        <asp:Label ID="lbltitle1" runat="server" ></asp:Label><br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Lead.aspx">Lead</a></li>
                <li><asp:Label ID="lbltitle2" runat="server" ></asp:Label></li>

            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">

                <div class="pull-right">
                    <%-- btn-group removed by mandar --%>
                    <div class="" style="">
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                        <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Lead.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />
                        <%--<button class="btn btn-sm btn-primary"><i class="fa fa-floppy-o"></i>&nbsp;Save</button>

                        <button class="btn btn-sm btn-primary"><i class="fa fa-times"></i>&nbsp;Cancel</button>--%>
                    </div>
                </div>

            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light abc">
                            <strong>Lead</strong> Information
                             <small>
                                <span class="pull-right" id="modifyspan" runat="server" >
                            By&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifiedname" runat="server" Font-Bold="true"></asp:Label></a>&nbsp;on&nbsp;<a style="text-decoration:none;"><asp:Label ID="lblmodifieddate" Font-Bold="true" runat="server" Font-Italic="true"></asp:Label></a>
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
                                    <label class="col-md-4 control-label" for="example-hf-email">Lead Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtleadname" runat="server" placeholder="Enter Lead Name" data-toggle="tooltip" title="Enter Lead Name"
                                            CssClass="form-control"></asp:TextBox>
										<asp:Label ID="lblname" runat="server" style="color:red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="releadname" runat="server" ControlToValidate="txtleadname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter lead name" Display="Dynamic" SetFocusOnError="true" ></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Date<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtleaddate" runat="server" data-toggle="tooltip" title="Enter Lead Date"
                                            CssClass="form-control" TextMode="Date" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="releaddate" runat="server" ControlToValidate="txtleaddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter date" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Lead Type</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlleadtype" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reindus" runat="server" ControlToValidate="ddlleadtype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select Type" SetFocusOnError="true"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Lead Category</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddCategory" runat="server" name="example-chosen" class="select-chosen" >                                           
                                          
                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                            <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                                            <%-- <asp:ListItem Text="Retail" Value="Retail"></asp:ListItem>--%>

                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11"  runat="server" ControlToValidate="ddCategory" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Category" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Source</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlsource" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlsource" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select source" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>

                                    
                                </div>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-4" runat="server" id="divcampaign">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">Campaign</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlcamp" runat="server" name="example-chosen" class="form-control"></asp:DropDownList>

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
                                    <label class="col-md-4 control-label" for="example-hf-password">Industry</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlindustry" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="ddlindustry" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select industry" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Company Type</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlcompnytype" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recompnytype" runat="server" ControlToValidate="ddlcompnytype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select company type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Turn Over</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtturnover" runat="server" placeholder="Enter Turn Over" data-toggle="tooltip" title="Enter Turn Over"
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
                                        <asp:TextBox ID="txtwebsite" runat="server" placeholder="Enter Website" data-toggle="tooltip" title="Enter Website"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rewebsite" runat="server" ControlToValidate="txtwebsite" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter Website" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Other Reference</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtotherref" runat="server" placeholder="Enter Other Reference" data-toggle="tooltip" title="Enter Other Reference"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="reotherref" runat="server" ControlToValidate="txtotherref" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter other reference" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" id="divstage" runat="server" >
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Stage</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlstage" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="restage" runat="server" ControlToValidate="ddlstage" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select stage" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" id="divdiscription" runat="server" >
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Description</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdiscription" runat="server" placeholder="Enter Discription" data-toggle="tooltip" title="Enter Discription"
                                            CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rediscription" runat="server" ControlToValidate="txtdiscription" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select discription" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             <div class="col-md-12">
                             <User:AssignControl ID="assigncontrol" runat="server" />
                             </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
                <div class="widget">
                    <div class="widget-extra themed-background-dark">

                        <h4 class="widget-content-light">
                            <strong>Primary Contact</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Title<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:HiddenField ID ="hfcontactid" runat="server" />
                                        <asp:DropDownList ID="ddltitle" runat="server" name="Title" class="form-control">
                                            <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                                            <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                                            <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
                                            <asp:ListItem Text="Chef." Value="Chef."></asp:ListItem>
                                            <asp:ListItem Text="Dr." Value="Dr."></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control"></asp:TextBox>										
                                        <asp:RequiredFieldValidator ID="refirstname" runat="server" ControlToValidate="txtname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter name" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Designation</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddldesignation" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="redesig" runat="server" ControlToValidate="ddldesignation" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select designation" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                        <br />
                                    </div>
                                </div>
                            </div>       
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-4">
                                        <div class="">
                                            <label class="col-md-4 control-label" for="example-hf-password">Email Id</label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                                    CssClass="form-control" AutoPostBack="true" onkeyup="this.value=this.value.replace(/ /g, '');"></asp:TextBox>
                                                <asp:Label ID="lblemail" runat="server" Style="color: red;" Visible="false"></asp:Label>
                                                <asp:RegularExpressionValidator ID="rgemailship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="reemailship" runat="server" ControlToValidate="txtemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="Please enter email id" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Mobile Number</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtmob" runat="server" placeholder="Enter Mobile Number" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Enter valid mobile number" ControlToValidate="txtmob"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="remobship" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter mobile number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Office Number</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtofficeno" runat="server" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="11" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno" ValidationGroup ="MasterGroup"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter Phone number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:TextBox ID="txtextention" runat="server" placeholder="Extention" data-toggle="tooltip" title="Enter Extention" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" 
                                            CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
							          <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Notify by<span class="text-danger"> </span></label>
                                    <div class="col-md-8">                              
                                        <asp:DropDownList ID="ddlnotifyby" runat="server" name="Title" CssClass="form-control">                                           
                                            <asp:ListItem Text="Email" Value="Email"></asp:ListItem>   
                                            <asp:ListItem Text="Alert" Value="Alert"></asp:ListItem>
                                            <asp:ListItem Text="None" Value="None"></asp:ListItem>
                                        </asp:DropDownList>
                                           <asp:RequiredFieldValidator ID="renotifyby" runat="server" ControlToValidate="ddlnotifyby" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please Select Notify by" SetFocusOnError="true" InitialValue ="---Please Select---" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                     
                                    </div>
                                </div>
                            </div> 
                                 <div class="col-md-4">
                                      <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                            ClientValidationFunction="AtLeastOneContact_ClientValidate" ></asp:CustomValidator>   
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
                            <div class="col-md-8">
                                <div class="">
                                    <label class="col-md-2 control-label" for="example-hf-email">Address<span class="text-danger"> </span></label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtaddressbill" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="readdressbill" runat="server" ControlToValidate="txtaddressbill" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter address" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Pincode</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpincodebill" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode" onkeyup="this.value=this.value.replace(/[^\d]/g,'');"
                                            CssClass="form-control" MaxLength="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtpincodebill" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter pincode" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Country</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlcountrybill" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recountrybill" runat="server" ControlToValidate="ddlcountrybill" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select country" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">State<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlstatebill" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="restatebill" runat="server" ControlToValidate="ddlstatebill" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select state" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-email">City<span class="text-danger"> </span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcitybill" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter City"
                                            CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                    </div>
                    
                </div>
            </div>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    
                    <asp:Button Text="Save" runat="server" ID="btnadd"  OnClientClick="validateSource(); if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton  ID="hfcancel" CausesValidation="false"  Text="Cancel" runat="server" NavigateUrl="~/Lead.aspx" class="btn btn-alt btn-danger" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

