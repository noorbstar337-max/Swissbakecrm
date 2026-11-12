<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="trialdatecheck.aspx.vb" Inherits="trialdatecheck" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <asp:TextBox ID="ddlDate" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date"  AutoPostBack="true"
                                                            CssClass="form-control"></asp:TextBox>
                    <asp:TextBox ID="txtDate" runat="server" placeholder="Enter Execution Date" data-toggle="tooltip" title="Enter Execution Date" TextMode="Date" AutoPostBack="true"
                                                            CssClass="form-control"></asp:TextBox>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
  
    <asp:Label ID="lbltest" runat="server" ></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btnsave"   runat="server" Text="save" />
        <asp:Button ID="Button1"   runat="server" Text="save" />
</asp:Content>

