<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyComplaint.aspx.vb" Inherits="ModifyComplaint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .control-label {
            padding: 6px;
        }

        .col-md-4 > .form-group {
            padding-bottom: 0px;
        }
    </style>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <asp:HiddenField ID="hfemail" runat="server" />
         <asp:HiddenField ID="deletestatus" runat="server" />
        <asp:HiddenField ID="hfcreateddate" runat="server" />
        <asp:HiddenField ID="hfcustname" runat="server" />

        <div class="col-md-12">
            <div class="content-header">
                <div class="header-section">
                    <h1 style="font-weight: 400;">
                        <i class="gi gi-shop" style="margin: -8px"></i>Complaint Detail<br>
                    </h1>
                </div>
            </div>

            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="Support.aspx">Complaints</a></li>
                <li>Complaint Detail</li>
            </ul>

            <%--<div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click"/>
                        <asp:HyperLink ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Campaign.aspx" class="btn btn-alt btn-sm btn-danger" />
                </div>
            </div>--%>
            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light">
                            <strong>Complaint</strong> Information <strong>(<asp:Label ID="lblcomplaintno" ToolTip="Complaint No." runat="server" ></asp:Label>)</strong>                        
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>
                            <!-- Ticket View -->
                            <div class="tab-pane" id="tickets-single">
                                <ul class="media-list media-feed push">
                                    <!-- Ticket -->
                                    <li class="media">
                                        <div class="media-body">
                                            <p class="push-bit">
                                                <span class="text-muted pull-right">
                                                    <small>
                                                        <asp:Label ID="lblCreatedDate" CssClass="text-primary" runat="server"></asp:Label></small>
                                                </span>
                                                <strong>
                                                    <asp:Label ID="lblCustomerName" CssClass="text-primary" runat="server"></asp:Label>
                                                    for
                                                    <asp:Label ID="lbldep" CssClass="text-primary" runat="server"></asp:Label>
                                                    Department</strong>
                                            </p>
                                            <h4><strong>
                                                <asp:Label ID="lblsubject" runat="server"></asp:Label></strong></h4>
                                            <p>
                                                <asp:Label ID="lblcomplaint" runat="server"></asp:Label>
                                            </p>
                                            <asp:HyperLink ID="Hypercompattach" runat="server" NavigateUrl='<%# "../" + Eval("Reply_Attachment")%>' Style="text-decoration: none; color: #c4161c;"><label class="fscf-label" for="fscf_field3_4">
                                                                    Attachment <span class="fscf-required-indicator"><img src="img/Attachment.png"  height="20"></span> </label></asp:HyperLink>
                                            <div class="alert alert-success animation-fadeInQuick">Current Status: <strong>
                                                <asp:Label ID="lblstatus" runat="server"></asp:Label></strong></div>                                           
                                        </div>
                                    </li>
                                    <!-- END Ticket -->

                                    <!-- Replies -->
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <ItemTemplate>
                                            <li class="media">
                                                <div class="media-body">
                                                    <p class="push-bit">
                                                        <span class="text-muted pull-right">
                                                            <small>
                                                                <asp:Label ID="lblreplytime" CssClass="text-primary" Text='<%# Eval("Reply_Emp_CreatedDate")%>' runat="server"></asp:Label></small>
                                                             <asp:LinkButton ID="lb_delete" runat="server" class="btn btn-danger" data-original-title="Delete" style="padding: 0px 5px;margin-left: 8px;" data-toggle="tooltip" onclientclick="checkdelete();" OnClick = "Button_Delete" CommandArgument = '<%# Eval("Reply_ID")%>' CommandName="Button_Delete"><i class="fa fa-times"></i></asp:LinkButton> 
                                                        </span>
                                                        <strong>
                                                            <asp:Label ID="lbltype" CssClass="text-primary" Text='<%# Eval("rname")%>' runat="server"></asp:Label>                                                            
                                                        </strong>
                                                       
                                                           <p><asp:Label ID="lbldescription" runat="server" Text='<%# Eval("Reply_Discription")%>' Style=""></asp:Label></p>
                                                        
                                                        <asp:HyperLink ID="rpatachment" runat="server" NavigateUrl='<%# "../" + Eval("Reply_Attachment")%>' Style="text-decoration: none; color: #c4161c;"><label class="fscf-label" for="fscf_field3_4">
                                                                    Attachment <span class="fscf-required-indicator"><img src="img/Attachment.png"  height="20"></span> </label></asp:HyperLink>
                                                    </p>
                                                </div>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    <li class="media">
                                        <div class="media-body">
                                            <asp:TextBox ID="txtreply" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" placeholder="Enter your reply" TabIndex="2"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter description " ForeColor="Red" ControlToValidate="txtreply" CssClass="validation" ValidationGroup="complaint"></asp:RequiredFieldValidator>
                                             <p>
                                                <label for="example-nf-email">Complaint Status </label>
                                                <asp:DropDownList ID="ddcompStatus" runat="server" data-toggle="tooltip" TabIndex="1" title="Complaint Status" CssClass="form-control"></asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddcompStatus" ValidationGroup="MasterGroup"
                                                    CssClass="MasterValidationCSS"
                                                    ErrorMessage="Select complaint status" InitialValue="Select complaint status"></asp:RequiredFieldValidator>
                                            </p>
                                            <asp:FileUpload ID="FileUpload1" runat="server" TabIndex="3" Style="border: 0px solid;" /><br />
                                              <%--<a ID="lkback" href="Support.aspx" class="btn btn-sm btn-primary"><i class="fa fa-arrow-left"></i> Back</a>--%>
                                              <asp:LinkButton ID="lkback" runat="server" class="btn btn-sm btn-primary"><i class="fa fa-arrow-left"></i> Back</asp:LinkButton>
                                            <asp:LinkButton ID="btnsubmit" TabIndex="4" runat="server" class="btn btn-sm btn-primary" ValidationGroup="complaint"><i class="fa fa-send-o"></i> Post Reply</asp:LinkButton>
                                           
                                        </div>
                                    </li>
                                    <!-- END Replies -->
                                </ul>
                            </div>
                            <!-- END Ticket View -->

                            <%-- <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-email">Department<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                  <asp:TextBox ID="txtdeptname" runat="server" placeholder="Enter Department Name" data-toggle="tooltip" title="Enter Department Name"
                            CssClass="form-control" TabIndex="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqdeptname" runat="server" ControlToValidate="txtdeptname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter a department name"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-email">Campaign Type<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                 <asp:DropDownList ID="ddcampaign_type" runat="server" name="example-chosen" class="select-chosen" TabIndex="2"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddcampaign_type" InitialValue="select campaign type" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Select campaign type" SetFocusOnError ="true" ></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                       <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">Start Date<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtstartdate" runat="server" placeholder="dd/mm/yy" data-toggle="tooltip" title="Enter Start Date"
                                    CssClass="form-control input-datepicker" data-date-format="dd/mm/yy" TabIndex="3"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtstartdate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter start date" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                           <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">End Date<span class="text-danger"> *</span></label>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtenddate" runat="server" data-toggle="tooltip" placeholder="dd/mm/yy" title="Enter End Date"
                                    CssClass="form-control input-datepicker" data-date-format="dd/mm/yy" TabIndex="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtenddate" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter end date" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">Campaign Budget<span class="text-danger">*</span></label>
                            <div class="col-md-8">
                                 <asp:TextBox ID="txtbudget" runat="server" placeholder="Enter Campaign Budget" data-toggle="tooltip" title="Enter Campaign Budget"
                                    CssClass="form-control" TextMode="Number"  TabIndex="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbudget" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter campaign budget" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="form-group">
                            <label class="col-md-4 control-label" for="example-hf-password">No. of Lead</label>
                            <div class="col-md-8">
                                 <asp:TextBox ID="txtlead" runat="server" placeholder="Enter No. of Lead" data-toggle="tooltip" title="Enter No. of Lead"
                                    CssClass="form-control" TextMode="Number"  TabIndex="6"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlead" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter no. of lead" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                          <div class="form-group">
                            <label class="col-md-1 control-label" for="example-hf-password">Remark</label>
                            <div class="col-md-11">
                                 <asp:TextBox ID="txtremark" runat="server" placeholder="Enter Remark" data-toggle="tooltip" title="Enter Remark"
                                    CssClass="form-control" TabIndex="7"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtremark" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                    ErrorMessage="Enter remark" SetFocusOnError ="true"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>--%>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary" ValidationGroup="MasterGroup" TabIndex="8" />
                        <asp:HyperLink ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Campaign.aspx" class="btn btn-alt btn-sm btn-danger" TabIndex="9" />
                    <br />
                    <br />
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>

