<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="CommingSoon.aspx.vb" Inherits="CommingSoon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div id="error-container">
            <div class="error-options">
                <h3><i class="fa fa-chevron-circle-left text-muted"></i> <a href="#" onclick="history.go(-1);return false;">Go Back</a></h3>
            </div>
            <div class="row">
                <div class="col-sm-8 col-sm-offset-2 text-center">
                    <h1 class="animation-tossing"><i class="fa fa-bullhorn text-success"></i> <a style="text-decoration:none;">Comming soon.</a></h1>
                    <h2 class="h3">Oops, we are sorry but our service is currently not available..</h2>
                </div>
            </div>
        </div>
</asp:Content>

