<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="CategoryWiseAchiveTarget.aspx.vb" Inherits="CategoryWiseAchiveTarget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <div class="row">
    <div class="col-sm-6">
                <!-- Widget -->
                <a href="SalesAchievedIndividual.aspx" class="widget widget-hover-effect1">
                 <div class="widget">
                    <div class="widget-extra-full text-center">
                        <%--<div class="widget-options-left">
                            <a class="btn btn-xs btn-alt btn-danger"  href="CategoryWiseAchiveTarget.aspx" data-toggle="tooltip" title="Category wise Sales Target" data-original-title="Category wise Sales Target"><i class="fa fa-sitemap"></i></a>
                        </div>
                        <div class="widget-options">
                            <a class="btn btn-xs btn-alt btn-danger" href="SalesOrders.aspx?Type=zhtqu" data-toggle="tooltip" title="Sales Achieved This Month" data-placement="left" data-original-title="Sales Achieved This Month"><i class="fa fa-eye"></i></a>
                        </div>--%>
                        <div class="pie-chart easyPieChart" id="divsaleschart" runat="server" data-percent="0" data-size="90" data-bar-color="#e11b1b" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltsalespercentageIndividual" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                    <div class="widget-extra themed-background-fancy text-center">
                        <h3 class="widget-content-light">
                            <small>Sales Achieved Individual</small><br>
                            <small>
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalesachivedIndividual" Text="0" runat="server"></asp:Literal>
                                out of&nbsp;
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalestargetIndividual" Text="0" runat="server"></asp:Literal></small>
                        </h3>
                    </div>
                </div>
                    </a>
                <!-- END Widget -->
            </div>
    <div class="col-sm-6 ">
                <!-- Widget -->
                <a href="SalesAchievedTeam.aspx" class="widget widget-hover-effect1">
                 <div class="widget">
                    <div class="widget-extra-full text-center">
                        <%--<div class="widget-options-left">
                            <a class="btn btn-xs btn-alt btn-danger"  href="CategoryWiseAchiveTarget.aspx" data-toggle="tooltip" title="Category wise Sales Target" data-original-title="Category wise Sales Target"><i class="fa fa-sitemap"></i></a>
                        </div>
                        <div class="widget-options">
                            <a class="btn btn-xs btn-alt btn-danger" href="SalesOrders.aspx?Type=zhtqu" data-toggle="tooltip" title="Sales Achieved This Month" data-placement="left" data-original-title="Sales Achieved This Month"><i class="fa fa-eye"></i></a>
                        </div>--%>
                        <div class="pie-chart easyPieChart" id="divsaleschartTeam" runat="server" data-percent="0" data-size="90" data-bar-color="#e11b1b" style="width: 90px; height: 90px; line-height: 90px;">
                            <span>
                                <asp:Literal ID="ltsalespercentageTeam" Text="0%" runat="server"></asp:Literal></span>
                            <canvas width="90" height="90"></canvas>
                        </div>
                    </div>
                    <div class="widget-extra themed-background-autumn text-center">
                        <h3 class="widget-content-light">
                            <small>Sales Achieved Team</small><br>
                            <small>
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalesachivedTeam" Text="0" runat="server"></asp:Literal>
                                out of&nbsp;
                                <i class="fa fa-rupee"></i> <asp:Literal ID="ltsalestargetTeam" Text="0" runat="server"></asp:Literal></small>
                        </h3>
                    </div>
                </div>
                    </a>
                <!-- END Widget -->
            </div>
    </div>
     <div class="row">
         <div class="col-lg-12">
     <h4><strong> Category Wise Sales Achivement Of This Month</strong> (Individual)</h4>
             </div><hr />
         </div> 
     <div class="row">
    <asp:Repeater ID="rptIndividual" runat="server">
        <ItemTemplate>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget">
                        <div class="widget-extra-full text-center">
                            <div class="pie-chart easyPieChart" id="divsaleschart" runat="server" data-size="90" data-bar-color="#e11b1b" style="width: 90px; height: 90px; line-height: 90px;" data-percent='<%#Eval("achivepercent")%>'>
                                <span>
                                    <asp:Literal ID="ltsalespercentagetargetIndividual" Text='<%#Eval("achivepercent").ToString + "%"%>' runat="server"></asp:Literal></span>
                                <canvas width="90" height="90"></canvas>
                            </div>
                        </div>
                        <div class="widget-extra themed-background-flatie text-center">
                            <h3 class="widget-content-light">
                                <strong><asp:Literal ID="lblcategoryNo" Text='<%#Eval("TC_Name")%>' runat="server" ></asp:Literal>
                                    
                                </strong>
                                <br>
                              <%--  <asp:Literal ID="Literal1" Text='<%#Eval("TargetFreightAchived")%>' runat="server" ></asp:Literal><br />--%>
                                <small>
                                    <i class="fa fa-rupee"></i>
                                    <%--<asp:Literal ID="ltsalesachived" Text='<%# If(Eval("STCD_SalesAmt").ToString = "All", (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"), (Convert.ToDouble(Eval("TargetSalesAchived")) + Convert.ToDouble(Eval("TargetFreightAchived"))).ToString("N2"))%>' runat="server"></asp:Literal>--%>
                                    <asp:Literal ID="ltsalesachived" Text='<%# If(Eval("STCD_SalesAmt").ToString = "All", (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"), (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"))%>' runat="server"></asp:Literal>
                                    out of&nbsp;
                                <i class="fa fa-rupee"></i>
                                    <asp:Literal ID="ltsalestarget" Text='<%#Convert.ToDouble(Eval("STCD_SalesAmt")).ToString("N2")%>' runat="server"></asp:Literal></small>
                            </h3>
                        </div>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
        </ItemTemplate>
    </asp:Repeater>
         </div> 
 <div class="row">
     <div class="col-lg-12">
    <h4><strong> Category Wise Sales Achivement Of This Month</strong> (Team)</h4>
         </div><hr />
     </div> 
     <div class="row">
    <asp:Repeater ID="rptTeam" runat="server">
        <ItemTemplate>
            <div class="col-sm-6 col-lg-3">
                <!-- Widget -->
                <a href="#" class="widget widget-hover-effect1">
                    <div class="widget">
                        <div class="widget-extra-full text-center">
                            <div class="pie-chart easyPieChart" id="divsaleschart" runat="server" data-size="90" data-bar-color="#e11b1b" style="width: 90px; height: 90px; line-height: 90px;" data-percent='<%#Eval("achivepercent")%>'>
                                <span>
                                    <asp:Literal ID="ltsalespercentageTargetTeam" Text='<%#Eval("achivepercent").ToString + "%"%>' runat="server"></asp:Literal></span>
                                <canvas width="90" height="90"></canvas>
                            </div>
                        </div>
                        <div class="widget-extra themed-background-night text-center">
                            <h3 class="widget-content-light">
                                <strong><asp:Literal ID="lblcategoryNo" Text='<%#Eval("TC_Name")%>' runat="server" ></asp:Literal>
                                    
                                </strong>
                                <br>
                              <%--  <asp:Literal ID="Literal1" Text='<%#Eval("TargetFreightAchived")%>' runat="server" ></asp:Literal><br />--%>
                                <small>
                                    <i class="fa fa-rupee"></i>
                                    <%--<asp:Literal ID="ltsalesachived" Text='<%# If(Eval("STCD_SalesAmt").ToString = "All", (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"), (Convert.ToDouble(Eval("TargetSalesAchived")) + Convert.ToDouble(Eval("TargetFreightAchived"))).ToString("N2"))%>' runat="server"></asp:Literal>--%>
                                    
                                    <asp:Literal ID="ltsalesachived" Text='<%# If(Eval("STCD_SalesAmt").ToString = "All", (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"), (Convert.ToDouble(Eval("TargetSalesAchived"))).ToString("N2"))%>' runat="server"></asp:Literal>
                                    out of&nbsp;
                                <i class="fa fa-rupee"></i>
                                    <asp:Literal ID="ltsalestarget" Text='<%#Convert.ToDouble(Eval("STCD_SalesAmt")).ToString("N2")%>' runat="server"></asp:Literal></small>
                            </h3>
                        </div>
                    </div>
                </a>
                <!-- END Widget -->
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div> 
</asp:Content>

