<%@ Control Language="VB" AutoEventWireup="false" ClassName="PageUrlControl" CodeFile="PageUrlControl.ascx.vb" Inherits="UserControl_Back_PageUrlControl" %>
<%--<div class="form-group">
    <label for="example-nf-email">Select Menu <span class="text-danger"></span></label>
    <asp:DropDownList ID="ddmenu" CssClass="form-control" runat="server"></asp:DropDownList>
</div>--%>

<div class="form-group">
    <label for="example-nf-email">Select Url Type <span class="text-danger">*</span></label>
    <asp:RadioButtonList ID="ckpagelist"  Width="50%" CellPadding="25" CellSpacing="25" runat="server" AutoPostBack="true">
        <asp:ListItem Text="Select From Page" Value="Page"></asp:ListItem>
        <asp:ListItem Text="Static Url" Value="Static"></asp:ListItem>
        <asp:ListItem Text="None" Value="None"></asp:ListItem>
    </asp:RadioButtonList>

    <asp:RequiredFieldValidator ID="rqcklist" Display ="Dynamic"  runat="server" ControlToValidate="ckpagelist" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select one of option from list"></asp:RequiredFieldValidator>
</div>

<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        
        <div class="form-group" id="div_rdpagetype" runat="server" visible="false">
    <label for="example-nf-email">Select Page Url  <span class="text-danger">*</span></label>
    <asp:RadioButtonList ID="rdpagetype"    Width="50%" CellPadding="25" CellSpacing="25" runat="server" AutoPostBack="true">
       <asp:ListItem Text="Page" Selected="True"  Value="Page"></asp:ListItem>
        <asp:ListItem Text="PageSeo" Value="PageSeo"></asp:ListItem>
       
    </asp:RadioButtonList>

   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display ="Dynamic"  runat="server" ControlToValidate="ckpagelist" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select one of option from list"></asp:RequiredFieldValidator>--%>
</div>
        <div class="form-group" id="div_dropdown" runat="server" visible="false">
            <label for="example-nf-email">Select Page Url <span class="text-danger">*</span></label>
            <asp:DropDownList ID="ddpageurl" name="example-chosen" class="select-chosen"  runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqddpage" Display ="Dynamic" Enabled ="false" runat="server" ControlToValidate="ddpageurl" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select page url" InitialValue="Select Page url"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group" id="div_PageSeo" runat="server" visible="false">
            <label for="example-nf-email">Select Page Url <span class="text-danger">*</span></label>
            <asp:DropDownList ID="ddpageseo" name="example-chosen" class="select-chosen" runat="server"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rqpageseo" Display ="Dynamic" Enabled ="false" runat="server" ControlToValidate="ddpageseo" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please select page url" InitialValue="Select Page Seo url"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group" id="div_static" runat="server" visible="false">
            <label for="example-nf-email">Static Url <span class="text-danger">*</span></label>
            <asp:TextBox ID="txtstaticurl" runat="server" placeholder="Static Url"  data-toggle="tooltip" title="Static Url"
                CssClass="form-control"></asp:TextBox>
               <asp:RequiredFieldValidator ID="rqstaticurl" Enabled ="false"  Display ="Dynamic"  runat="server" ControlToValidate="txtstaticurl" ValidationGroup="MasterGroup" CssClass="MasterValidationCSS"
                            ErrorMessage="Please enter a static url"></asp:RequiredFieldValidator>
        </div>
    </ContentTemplate>
    <Triggers >
        <asp:AsyncPostBackTrigger ControlID="ckpagelist" />
    </Triggers>
</asp:UpdatePanel>
<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <br />
        <div class="divWaiting">
            <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
        </div>
    </ProgressTemplate>
</asp:UpdateProgress>
