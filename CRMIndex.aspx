<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="CRMIndex.aspx.vb" Inherits="CRMIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-header content-header-media" style="height: 125px;">
        <div class="header-section">
            <div class="row">
                <!-- Main Title (hidden on small devices for the statistics to fit hidden-xs hidden-sm) -->
                <div class="col-md-4 col-lg-6">
                    <h1>Welcome  <strong>
                        <asp:Label ID="lblusername" runat="server" Font-Bold="true"></asp:Label></strong><br>
                        </h1>                     
                </div>
             
            </div>
        </div>
        <!-- For best results use an image with a resolution of 2560x248 pixels (You can also use a blurred image with ratio 10:1 - eg: 1000x100 pixels - it will adjust and look great!) -->
        <img src="img/placeholders/headers/dashboard_header.jpg" alt="header image" class="animation-pulseSlow">
    </div>
    <div class="col-md-12 " id="divPurchase" style="float:none" runat="server" >
            <div class="">
                <div class="row media-filter-items">
                  
                  
                     <div id="divAddLead" runat="server" class="col-sm-6 col-lg-4">
                        <div  class="media-items animation-fadeInQuickInv" >
                            <a href="ModifyLead.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d&returnurl=y"   class="themed-color-autumn">
                                <div class="media-items-content">
                                    <i class="gi gi-group fa-4x themed-color-autumn pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Lead</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                     <div id="divAddProspect" runat="server" class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="ModifyProspect.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d&returnurl=y"   class="themed-color-spring">
                                <div class="media-items-content">
                                    <i class="gi gi-group fa-4x themed-color-spring pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Prospect</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div id="divAddAccount" runat="server" class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="ModifyAccount.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d&returnurl=y"   class="themed-color-fire">
                                <div class="media-items-content">
                                    <i class="gi gi-group fa-4x themed-color-fire pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Account</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div id="divAddQuotation" runat="server" class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="ModifyQuotation.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d&returnurl=TzV%2b1tS9W13zQX0NBLpQWS3gzszG5g59814C2PCXb0THxQhDenUYEcOoJbwuM3p%2feRv10czT4DczRMG1ol2glVmNe13zBDBM2wVRycy1v4k%3d" class="themed-color-fire">
                                <div class="media-items-content">
                                    <i class="fa fa-calculator fa-4x themed-color-fire pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Quotation</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div id="divAddOrder" runat="server" class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" >
                            <a href="ModifySalesOrder.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-cubes fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Order</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div id="divAddComplaint" runat="server" class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv">
                            <a href="ModifyCustomerComplaint.aspx?ID=jJOtHsRVwYECOhoiBc69dA%3d%3d&returnurl=y" class="themed-color-dark">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x themed-color-dark pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Add Complaint</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div> 
                         <!---Adding DSR-->
                     <div id="divAddDSR" runat="server" class="col-sm-6 col-lg-4">
     <div class="media-items animation-fadeInQuickInv">
         <a href="dsr.aspx?returnurl=wgvX%2bZAUHRCRa2hKbZzVErPWcDhzHX0t%2fSS3cWYlhkCH9pO1yRaBvbPs3cvM%2bFOohWa9juNh3scnsYZVE%2btKu3VdZHc08VizrVGcXvAff1Ynew4givdV%2fGUtU5hkh20D&ID=jJOtHsRVwYECOhoiBc69dA%3d%3d" class="themed-color-dark">
             <div class="media-items-content">
                 <%--<i class="gi gi-notes_2 fa-4x themed-color-dark pull-left"></i>--%>
                 <i class="gi gi-stats fa-4x themed-color-dark pull-left"></i>
             </div>
             <h4 style="margin-top: -4px; font-size: 16px;">
                 <strong>Add DSR</strong><br>
             </h4>
         </a>
     </div>
 </div> 
                    <!---->
          
                </div>

            </div>
        </div>
</asp:Content>

