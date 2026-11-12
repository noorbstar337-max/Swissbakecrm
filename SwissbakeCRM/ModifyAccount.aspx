<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ModifyAccount.aspx.vb" Inherits="ModifyAccount" MaintainScrollPositionOnPostback="true" %>

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
    </script>
    <script type="text/javascript">
        function copytxtval() {
            ; debugger
            //var t1=document.getElementById("txtAccountname");
            //var t2 = document.getElementById("txtname");
            //t2.value = t1.value;

            var t1 = document.getElementById("<%=txtname.ClientID%>");
            //var t2 = document.getElementById("<%=txtname.ClientID%>");
            var t3 = document.getElementById("<%=txtaddname.ClientID%>");
            // t2.value = t1.value;
            //if (t3.value == '') {
            t3.value = t1.value;
            //}
        }

        function copyEmailval() {
            ; debugger

            var t1 = document.getElementById("<%=txtemail.ClientID%>");
            var t2 = document.getElementById("<%=txtaddemail.ClientID%>");
            t2.value = t1.value;
        }

        <%--function copyMobileVal() {
            ; debugger

            var t1 = document.getElementById("<%=txtmob.ClientID%>");
            var t2 = document.getElementById("<%=txtAddMobile.ClientID%>");
            t2.value = t1.value;
        }--%>
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hfOwnerID" runat="server" />
    <asp:HiddenField ID="hfAccAddrShipID" runat="server" />
    <asp:HiddenField runat="server" ID="hfAccName" />
    <asp:HiddenField runat="server" ID="hfAccEmail" />
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
                <li><a href="Account.aspx">Account</a></li>
                <li>
                    <asp:Label ID="lbltitle2" runat="server"></asp:Label></li>
            </ul>
            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <div class="" style="">
                        <asp:Button Text="Save" runat="server" ID="Button1" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                            UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" OnClick="btnadd_Click" />
                        <asp:LinkButton ID="HyperLink1" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Account.aspx" class="btn btn-alt btn-danger" OnClick="hfcancel_Click" />
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="widget">
                    <div class="widget-extra themed-background-dark">
                        <h4 class="widget-content-light abc">
                            <strong>Account</strong> Information
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
                                    <label class="col-md-4 control-label" for="example-hf-email">Account Name<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtAccountname" runat="server" placeholder="Enter Account Name" data-toggle="tooltip" title="Enter Account Name" TabIndex="1"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:Label runat="server" ID="lblname" Style="color: red;"></asp:Label>
                                        <asp:RequiredFieldValidator ID="reAccountname" runat="server" ControlToValidate="txtAccountname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter account name" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" id="divcode" runat="server">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Account Code</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtcode" runat="server" placeholder="Enter Account Code" data-toggle="tooltip" title="Enter Account Code" TabIndex="2"
                                            CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAccountname" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter code" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Industry</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlindustry" runat="server" name="example-chosen" class="select-chosen" TabIndex="3"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reIndustry" runat="server" ControlToValidate="ddlindustry" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select industry" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Company Type</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlcompnytype" runat="server" name="example-chosen" class="select-chosen" TabIndex="4"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="recompnytype" runat="server" ControlToValidate="ddlcompnytype" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select company type" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Prospect Category</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddCategory" runat="server" name="example-chosen" class="select-chosen">

                                            <asp:ListItem Text="Domestic" Value="Domestic"></asp:ListItem>
                                            <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                                            <%-- <asp:ListItem Text="Retail" Value="Retail"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddCategory" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Select Category" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
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
                            <div class="col-md-4" runat="server" id="divopbal">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Opening Balance </label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtopenbal" Enabled="false" runat="server" placeholder="Enter Opening Balance" data-toggle="tooltip" title="Enter Opening Balance" TabIndex="8"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtopenbal" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter opening balance" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Due Days </label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlDueDate" runat="server" data-toggle="tooltip" title="DueDate" class="select-chosen" TabIndex="30">
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem Selected="True">10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                            <asp:ListItem>24</asp:ListItem>
                                            <asp:ListItem>25</asp:ListItem>
                                            <asp:ListItem>26</asp:ListItem>
                                            <asp:ListItem>27</asp:ListItem>
                                            <asp:ListItem>28</asp:ListItem>
                                            <asp:ListItem>29</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                            <asp:ListItem>31</asp:ListItem>
                                            <asp:ListItem>32</asp:ListItem>
                                            <asp:ListItem>33</asp:ListItem>
                                            <asp:ListItem>34</asp:ListItem>
                                            <asp:ListItem>35</asp:ListItem>
                                            <asp:ListItem>36</asp:ListItem>
                                            <asp:ListItem>37</asp:ListItem>
                                            <asp:ListItem>38</asp:ListItem>
                                            <asp:ListItem>39</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>41</asp:ListItem>
                                            <asp:ListItem>42</asp:ListItem>
                                            <asp:ListItem>43</asp:ListItem>
                                            <asp:ListItem>44</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                            <asp:ListItem>46</asp:ListItem>
                                            <asp:ListItem>47</asp:ListItem>
                                            <asp:ListItem>48</asp:ListItem>
                                            <asp:ListItem>49</asp:ListItem>
                                            <asp:ListItem>50</asp:ListItem>
                                            <asp:ListItem>51</asp:ListItem>
                                            <asp:ListItem>52</asp:ListItem>
                                            <asp:ListItem>53</asp:ListItem>
                                            <asp:ListItem>54</asp:ListItem>
                                            <asp:ListItem>55</asp:ListItem>
                                            <asp:ListItem>56</asp:ListItem>
                                            <asp:ListItem>57</asp:ListItem>
                                            <asp:ListItem>58</asp:ListItem>
                                            <asp:ListItem>59</asp:ListItem>
                                            <asp:ListItem>60</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4" id="divdiscription" runat="server">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Discription</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtdiscription" runat="server" placeholder="Enter Discription" data-toggle="tooltip" title="Enter Discription" TabIndex="10"
                                            CssClass="form-control" TextMode="MultiLine" Rows="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlsource" ValidationGroup="DemofffMasterGroup" CssClass="MasterValidationCSS"
                                                    ErrorMessage="select source" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                             <%--<div class="col-md-4" id="divOwner" runat="server" visible="false">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Account Owner</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlAccOwner" runat="server" name="example-chosen" class="form-control select-chosen" data-toggle="tooltip" title="Select Owner"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlAccOwner" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="select discription" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>
							<div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Bank</label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlBank" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label for="example-checkbox1" title="Feature coming soon">
                                        <asp:CheckBox ID="chkTCS" runat="server" CssClass="example-checkbox1" />
                                        TCS Applicable
                                    </label>
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
                                    <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name" onkeyup="copytxtval();"
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
                                            <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id" onkeyup="this.value=this.value.replace(/ /g, ''); copyEmailval();"
                                                    CssClass="form-control" AutoPostBack="true"></asp:TextBox>
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
                                        <asp:TextBox ID="txtmob" runat="server" onkeyup="this.value=this.value.replace(/[^\d\.]/g,'');" placeholder="Enter Mobile Number" data-toggle="tooltip" title="Enter Mobile Number"
                                            CssClass="form-control" MaxLength="10"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgmobship" runat="server" ErrorMessage="Please enter valid mobile number" ControlToValidate="txtmob"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" ValidationGroup="MasterGroup"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="remobship" runat="server" ControlToValidate="txtmob" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter mobile number" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Office Number</label>
                                    <div class="col-md-5">
                                        <asp:TextBox ID="txtofficeno" runat="server" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" placeholder="Enter Office Number" data-toggle="tooltip" title="Enter Office Number"
                                            CssClass="form-control" MaxLength="11"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rgofficeno" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtofficeno"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" ValidationGroup="MasterGroup"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="reoffice" runat="server" ControlToValidate="txtofficeno" ValidationGroup="DemoMasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter phone Number" SetFocusOnError="true"></asp:RequiredFieldValidator>
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
                                            ErrorMessage="Please Select Notify by" SetFocusOnError="true" InitialValue="---Please Select---"></asp:RequiredFieldValidator>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At leat one contact required" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS" Display="Dynamic" OnServerValidate="AtLeastOneContact_ServerValidate"
                                    ClientValidationFunction="AtLeastOneContact_ClientValidate"></asp:CustomValidator>
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
                                <h5><strong>Billing Address :</strong></h5>
                                <br />
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddname" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtaddname" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter name" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddemail" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                            CssClass="form-control" onkeyup="this.value=this.value.replace(/ /g, '');"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtaddemail" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtaddemail" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter email id" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">Telephone No<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtaddphone" runat="server" placeholder="Enter Telephone Number" data-toggle="tooltip" title="Enter Telephone Number"
                                            CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="11"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid phone number" ControlToValidate="txtaddphone"
                                            ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" ValidationGroup="MasterGroup"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtaddphone" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Enter phone no" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator><br />
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
                                            ErrorMessage="select state" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                    <label class="col-md-4 control-label" for="example-hf-password">Pincode<span class="text-danger"> *</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpincodebill" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode"
                                            CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="repicodebill" runat="server" ControlToValidate="txtpincodebill" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter pincode" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

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
                                    <label class="col-md-4 control-label" for="example-hf-password">GST <span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtGST" runat="server" placeholder="Enter GST" data-toggle="tooltip" title="Enter GST"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtGST" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter GST" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" CssClass="MasterValidationCSS" runat="server" ValidationGroup="RegisterGroup" ErrorMessage="Enter valid GST No."
                                            ValidationExpression="\d{2}[A-Za-z]{5}\d{4}[A-Za-z]\d{1}[Zz]{1}[A-Za-z\d]{1}" ControlToValidate="txtGST"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <h5><strong>Shipping Address : </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:CheckBox ID="chksameadd" Text=" Same as above" runat="server" AutoPostBack="true" /></h5>
                                <br />
                            </div>
							 <div class="col-md-6 label label-danger">
                                Make sure you have entered proper GST No. as per the State else eInvoice will not get generate
                            </div>
                            <div id="shipdiv" runat="server">
                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Name <span class="text-danger">*</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtaddnameship" runat="server" placeholder="Enter Name" data-toggle="tooltip" title="Enter Name"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorship" runat="server" ControlToValidate="txtaddnameship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter name" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Email Id<span class="text-danger"> *</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtaddemailship" runat="server" placeholder="Enter Email Id" data-toggle="tooltip" title="Enter Email Id"
                                                CssClass="form-control" onkeyup="this.value=this.value.replace(/ /g, '');"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1ship" runat="server" ValidationGroup="MasterGroup" ErrorMessage="Please enter valid email id"
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtaddemailship" CssClass="MasterValidationCSS" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4ship" runat="server" ControlToValidate="txtaddemailship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter email id" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Telephone No<span class="text-danger"> *</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtaddphoneship" runat="server" placeholder="Enter Telephone Number" data-toggle="tooltip" title="Enter Telephone Number"
                                                CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="11"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2ship" runat="server" ErrorMessage="Please enter valid number" ControlToValidate="txtaddphoneship"
                                                ValidationExpression="^[()0-9 +-]{8,15}$" CssClass="MasterValidationCSS" Display="Dynamic" Enabled="false"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5ship" runat="server" ControlToValidate="txtaddphoneship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter telephone no" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator><br />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Country</label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlcountryship" runat="server" name="example-chosen" class="select-chosen" AutoPostBack="true"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="recountryship" runat="server" ControlToValidate="ddlcountryship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select country" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">State<span class="text-danger"> </span></label>
                                        <div class="col-md-8">
                                            <asp:DropDownList ID="ddlstateship" runat="server" name="example-chosen" class="select-chosen"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="restateship" runat="server" ControlToValidate="ddlstateship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="select state" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-email">City<span class="text-danger"> </span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtcityship" runat="server" placeholder="Enter City" data-toggle="tooltip" title="Enter City"
                                                CssClass="form-control"></asp:TextBox><br />
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">Pincode<span class="text-danger"> *</span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtpincodeship" runat="server" placeholder="Enter Pincode" data-toggle="tooltip" title="Enter Pincode"
                                                CssClass="form-control" onkeyup="this.value=this.value.replace(/[^\d]/g,'');" MaxLength="6"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="repicodeship" runat="server" ControlToValidate="txtpincodeship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter pincode" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-8">
                                    <div class="">
                                        <label class="col-md-2 control-label" for="example-hf-email">Address<span class="text-danger"> *</span></label>
                                        <div class="col-md-10">
                                            <asp:TextBox ID="txtaddship" runat="server" placeholder="Enter Address" data-toggle="tooltip" title="Enter Address"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="readdrship" runat="server" ControlToValidate="txtaddship" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter address" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="">
                                        <label class="col-md-4 control-label" for="example-hf-password">GST <span class="text-danger"></span></label>
                                        <div class="col-md-8">
                                            <asp:TextBox ID="txtGSTShip" runat="server" placeholder="Enter Shipping GST" data-toggle="tooltip" title="Enter GST"
                                                CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtGSTShip" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                                ErrorMessage="Please enter GST" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" CssClass="MasterValidationCSS" runat="server" ValidationGroup="RegisterGroup" ErrorMessage="Enter valid GST No."
                                                ValidationExpression="\d{2}[A-Za-z]{5}\d{4}[A-Za-z]\d{1}[Zz]{1}[A-Za-z\d]{1}" ControlToValidate="txtGSTShip"></asp:RegularExpressionValidator>
                                        </div>
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
                            <strong>Tax</strong> Information
                        </h4>
                    </div>
                    <div class="widget-extra-full">
                        <div class="form-horizontal form-bordered">
                            <div class="col-md-12">
                                <br />
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">CST <span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txttin" runat="server" placeholder="Enter CST" data-toggle="tooltip" title="Enter CST"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="refirstcst" runat="server" ControlToValidate="txttin" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter cst" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">PAN <span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtpan" runat="server" placeholder="Enter PAN" data-toggle="tooltip" title="Enter PAN"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtpan" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter pan" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">VAT <span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtvat" runat="server" placeholder="Enter VAT" data-toggle="tooltip" title="Enter VAT"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtvat" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter vat" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="col-md-3">
                                <div class="">
                                    <label class="col-md-4 control-label" for="example-hf-password">GST <span class="text-danger"></span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txtGST" runat="server" placeholder="Enter GST" data-toggle="tooltip" title="Enter VAT"
                                            CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtGST" ValidationGroup="MasterGroup1" CssClass="MasterValidationCSS"
                                            ErrorMessage="Please enter GST" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>--%>

                            <div style="clear: both"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12" style="margin-bottom: 11px; display: table; margin-top: -8px">
                <div class="pull-right">
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-primary" ValidationGroup="MasterGroup" />
                    <asp:LinkButton ID="hfcancel" CausesValidation="false" Text="Cancel" runat="server" NavigateUrl="~/Account.aspx" class="btn btn-alt btn-danger" />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

