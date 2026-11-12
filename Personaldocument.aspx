<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="Personaldocument.aspx.vb" Inherits="Personaldocument" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-header">
        <div class="header-section">
            <h1>
                <i class="hi hi-tasks" style="margin: -8px"></i>Personal Document<br>
            </h1>
        </div>
    </div>
    <ul class="breadcrumb breadcrumb-top">
        <li><a href="index.aspx">Home</a></li>
        <li>Personal Document</li>
    </ul>
    <User:NewDocumentControl ID="documentcontrol" runat="server" />

</asp:Content>

