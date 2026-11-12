<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="AdminMenu.aspx.vb" Inherits="AdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-md-4 col-lg-3">
            <div class="block full">
                <div class="block-title">
                    <div class="block-options pull-right">
                        <%--<a href="javascript:void(0)" class="btn btn-alt btn-sm btn-default" data-toggle="tooltip" title="Settings"><i class="fa fa-cog"></i></a>--%>
                    </div>
                    <h2><i class="fa fa-gears"></i>&nbsp;<strong>Configuration</strong></h2>
                </div>
                <ul class="nav nav-pills nav-stacked nav-icons media-filter">
                    <li class="active">
                        <a href="javascript:void(0)" data-category="all">
                            <i class="fa fa-fw fa-folder-open themed-color-dark icon-push"></i><strong>All</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="lead">
                            <i class="fa fa-fw gi gi-parents text-danger icon-push"></i><strong>Lead</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="product">
                            <i class="fa fa-fw fa fa-cubes text-info icon-push"></i><strong>Product</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="Campaign">
                            <i class="fa fa-fw gi gi-shop text-danger icon-push"></i><strong>Campaign</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="company">
                            <i class="fa fa-fw gi gi-factory text-success icon-push"></i><strong>Company</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="vendor">
                            <i class="gi gi-group themed-color-amethyst icon-push"></i><strong>Vendor</strong>
                        </a>
                    </li>
                    <li>
                        <a href="javascript:void(0)" data-category="other">
                            <i class="fa fa-fw fa-book text-warning icon-push"></i><strong>Other</strong>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        <div class="col-md-8 col-lg-9">
            <div class="block">
                <div class="row media-filter-items">
                   <%-- <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="Lead.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-parents fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Lead</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="user.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="gi gi-user fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>User</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="product">
                            <a href="product.aspx" class="text-info">
                                <div class="media-items-content">
                                    <i class="fa fa-cubes fa-4x text-info pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Product</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="Industry.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="fa fa-institution fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Industries</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="LeadType.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-old_man fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Lead Type</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="Level.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="fa fa-sort-amount-desc fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Level</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="SalesTarget.aspx"  class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-flag-checkered fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Sales Target</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="privilage.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="fa fa-unlock-alt fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Privilage</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="ModifyCompany.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-adjust fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Company Details</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="Source.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-sort fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Source</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="department.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-building fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Department</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="product">
                            <a href="Category.aspx" class="text-info">
                                <div class="media-items-content">
                                    <i class="fa fa-sitemap fa-4x text-info pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Category</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                     <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="B2bdesignation.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-suitcase fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>B2B Designation</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                     <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="CrmDesignation.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-suitcase fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>CRM Designation</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="CompanyType.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-kiosk fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Company Type</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div> 
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="Addressbook.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="gi gi-book fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Address Book</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="OpportunityStage.aspx"  class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-charts fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Opportunity Stage</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>      
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="Region.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="gi gi-globe fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Region</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="Campaign">
                            <a href="Campaign.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-shop fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Campaign</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>                        
                     <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="UserType.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-user fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>User Group</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>                
                   <%-- <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="Currency.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="fa fa-inr fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Currency</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%> 
                    <%-- <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="product">
                            <a href="SubCategory.aspx" class="text-info">
                                <div class="media-items-content">
                                    <i class="fa fa-indent fa-4x text-info pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Sub Category</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%>
                    <%-- <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="product">
                            <a href="UOM.aspx" class="text-info">
                                <div class="media-items-content">
                                    <i class="fa fa-flask fa-4x text-info pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>UOM</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%> 
                    <%--<div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="Stage.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="fa fa-signal fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Stage</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%>
                    <%--<div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="Year.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="fa fa-calendar fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Year</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%>
                                 <%-- <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="Tax.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="fa fa-calculator fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Tax</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>--%>  
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="Campaign">
                            <a href="CampaignType.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="gi gi-kiosk_light fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Campaign Type</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    
                     
                    
                    
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="other">
                            <a href="ContactType.aspx" class="text-warning">
                                <div class="media-items-content">
                                    <i class="gi gi-phone_alt fa-4x text-warning pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Contact Type</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="Rawmaterial.aspx"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-cube fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Raw Material</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="godown.aspx"  class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-bank fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Godown</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="Vendor.aspx"   class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-group fa-4x themed-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Vendor</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="Principle.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-user fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Principle</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="VendorType.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="fa fa-random fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>VendorType</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                     <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="vendor">
                            <a href="quotationrequest.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-notes_2 fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Quotation Request</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="">
                            <a href="POListNew.aspx" class="themed-color-amethyst">
                                <div class="media-items-content">
                                    <i class="gi gi-sort fa-4x text-color-amethyst pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Purchase Order</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>

                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="lead">
                            <a href="AccountOwnerlist.aspx" class="text-danger">
                                <div class="media-items-content">
                                    <i class="fa fa-users fa-4x text-danger pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Account Owner</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>
                    <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="TargetCategory.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-user fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Target Category</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div>  
                    
                       <div class="col-sm-6 col-lg-4">
                        <div class="media-items animation-fadeInQuickInv" data-category="company">
                            <a href="productlist.aspx" class="text-success">
                                <div class="media-items-content">
                                    <i class="fa fa-sitemap  fa-4x text-success pull-left"></i>
                                </div>
                                <h4 style="margin-top: -4px; font-size: 16px;">
                                    <strong>Product List</strong><br>
                                </h4>
                            </a>
                        </div>
                    </div> 
                       
                                         
                </div>
            </div>
        </div>
    </div>
    <%--    <div class="row">
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Category.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                        <i class="fa fa-file-text"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Category</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="SubCategory.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                        <i class="gi gi-usd"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>SubCategory</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Campaign.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="gi gi-envelope"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Campaign</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="CampaignType.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                        <i class="gi gi-picture"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Campaign Type</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>

    </div>

    <div class="row">
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Currency.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                        <i class="fa fa-inr"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Currency</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Department.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                        <i class="gi gi-usd"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Department</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Designation.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="gi gi-envelope"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Designation</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Industry.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                        <i class="gi gi-picture"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Industry</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>

    </div>

    <div class="row">
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Region.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                        <i class="fa fa-file-text"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Region</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Source.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                        <i class="gi gi-usd"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Source</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Stage.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="gi gi-envelope"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Stage</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Status.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                        <i class="gi gi-picture"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Status</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>

    </div>

    <div class="row">
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="UOM.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                        <i class="fa fa-file-text"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>UOM </strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="User.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                        <i class="fa fa-user"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>User</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="UserType.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="fa fa-user"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>User Type</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Product.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                        <i class="gi gi-picture"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Product</strong>
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
    </div>

     <div class="row">
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="LeadType.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-autumn animation-fadeIn">
                        <i class="fa fa-file-text"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"> <strong> Lead Type </strong>                     
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="ContactType.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-spring animation-fadeIn">
                        <i class="fa fa-user"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"> <strong>Contact Type</strong>                
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>

        <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="ReasonForLost.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-fire animation-fadeIn">
                        <i class="fa fa-user"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"><strong>Reason For Lost</strong>                        
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>

       <%-- <div class="col-sm-6 col-lg-3">
            <!-- Widget -->
            <a href="Product.aspx" class="widget widget-hover-effect1">
                <div class="widget-simple">
                    <div class="widget-icon pull-left themed-background-amethyst animation-fadeIn">
                        <i class="gi gi-picture"></i>
                    </div>
                    <h3 class="widget-content text-right animation-pullDown"> <strong>Product</strong>                       
                    </h3>
                </div>
            </a>
            <!-- END Widget -->
        </div>
    </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

