<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="ProductList.aspx.vb" Inherits="ProductList" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">   
    <style>
        table tbody tr:first-child th:last-child{
            width:170px;
        }
        table tbody tr:first-child th:nth-child(4){
            width:145px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="Hfgridview" runat="server" />
    <asp:HiddenField ID="hftotalrecord" runat="server" />
    <asp:HiddenField ID="hfsearch" runat="server" />
<%--    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>--%>
            <div class="content-header">
                <div class="header-section">
                    <h1>
                        <i class="fa fa-sitemap" style="margin: -8px"></i>Product<br>
                    </h1>
                </div>
            </div>
            <ul class="breadcrumb breadcrumb-top">
                <li><a href="index.aspx">Home</a></li>
                <li><a href="AdminMenu.aspx">Admin</a></li>
                <li>Product List</li>
            </ul>
            <div class="block">
                <div class="block-title">
                    <h2><strong>Product</strong> Detail List</h2>
                </div>
                <%--Search User Control Start--%>
                <div class="widget">
                    <div class="widget-extra-full">
                        <div class="col-md-12">
							<div class="col-md-2">
								<asp:DropDownList runat="server" ID="ddtype" class="form-control" AutoPostBack="true">
									<asp:ListItem>Domestic</asp:ListItem>
									<asp:ListItem Text="Export" Value="Export"></asp:ListItem>
								</asp:DropDownList>
							</div>
							<div class="col-md-9">
								<div id="example-datatable_filter" class="dataTables_filter">
									<label>
										<div class="input-group">
											<asp:UpdatePanel runat="server">
												<ContentTemplate>
													<asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" AutoPostBack="true"/>
												</ContentTemplate>
												<Triggers>
													<asp:AsyncPostBackTrigger ControlID="ddtype" />
												</Triggers>
											</asp:UpdatePanel>
											<span class="input-group-addon">
												<i class="fa fa-search"></i></span>
											<User:SearchBar ID="SearchControl" runat="server" Visible="false" />
										</div>
									</label>
								</div>
							</div>                            
                            <div class="col-md-1">
                                <asp:Button Text="Save" OnClick="btnadd_Click" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                                    UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary pull-right" ValidationGroup="MasterGroup" />
                           
                                 
                            </div>
                        </div>
                    </div>
                </div>
                <%--Search User Control End--%>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" ShowFooter="True" GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" 
                                HeaderStyle-Font-Size="Smaller" CellPadding="0" runat="server" AutoGenerateColumns="False" 
                                DataKeyNames="Product_Id" AllowCustomPaging="true" PageSize="10"  >
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Name" HeaderStyle-CssClass="" ItemStyle-CssClass=""  >
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server">Product Name</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblProductName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("Product_Name"), SearchControl.UtxtSearch)%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="" >
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" >SKU</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hfPacking_Weight" runat="server" Value='<%#Eval("Packing_Weight")%>' />
                                            <asp:Label ID="lblproductWeight" runat="server" Text='<%#Eval("Packing_Weight")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblpackingSize" runat="server" Text='<%#Eval("Package_Size")%>'></asp:Label>
                                            <asp:Label ID="lblproductid" runat="server" Text='<%#Eval("Product_Id")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PrdRate" HeaderStyle-CssClass="" ItemStyle-CssClass="" >
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink3" runat="server" >Rate/kg</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate> 
                                            <lable class="fa fa-rupee">   </lable>&nbsp;     
                                            <asp:Label ID="txtPrdrate" runat="server" Text='<%#Eval("Rate")%>'></asp:Label> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cost/KG" HeaderStyle-CssClass="" ItemStyle-CssClass="" >
                                        <HeaderTemplate>
                                            <asp:HyperLink ID="HyperLink4" runat="server" >Cost/KG</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div>
                                                <asp:TextBox ID="txtCostPerKG" width="100px"  onkeyup="this.value=this.value.replace(/\D/g,'');" OnTextChanged="txtCostPerKG_TextChanged" AutoPostBack="True" runat="server" Height="25" data-toggle="tooltip" title="Enter Cost Per KG" Text='<%#Eval("Cost")%>'
                                                    CssClass="form-control" ></asp:TextBox>  
                                               </div>
                                        </ItemTemplate>                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Min Margin(%)" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                            
                                            <asp:HyperLink ID="HyperLink5" runat="server">Min Selling Price(%)/KG</asp:HyperLink>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div style="display: flex;width: 170px;/* margin-right: 0; */">
                                            
                                             <asp:TextBox ID="txtMarginPercent"    runat="server"  onkeyup="this.value=this.value.replace(/\D/g,'');" AutoPostBack="true"
                                            width="65px" data-toggle="tooltip" title="Enter Percentange to set the minimum selling price/KG for this product" OnTextChanged="txtMarginPercent_TextChanged" Text='<%#Eval("Product_Margin")%>' CssClass="form-control"  ></asp:TextBox>
                                             <i style="margin-top: 4px;margin-left:5px;"> % /</i>&nbsp;
                                                <i class="fa fa-inr" style="margin-top: 8px;margin-left: 10px;"></i>&nbsp;   <asp:Label ID="lblMargin" runat="server" style="margin-top: 5px;"></asp:Label>
                                               
                                        </div>
                                                </ItemTemplate>
                                    </asp:TemplateField>                                    
                                </Columns>
                              <%--  <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />--%>
                                <HeaderStyle Font-Bold="True" Font-Size="Smaller" Width="100px" />
                               <%-- <PagerSettings PageButtonCount="4" />--%>
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="GridView1" />
						<asp:AsyncPostBackTrigger ControlID="ddtype" />
                    </Triggers>
                </asp:UpdatePanel> 
                <div class="widget">
                <div class="widget-extra-full" >                    
                    <asp:Button Text="Save" runat="server" ID="btnadd" OnClientClick="if (!Page_ClientValidate('MasterGroup')){ return false; } this.disabled = true; this.value = 'Saving...';"
                        UseSubmitBehavior="false" class="btn btn-alt btn-sm btn-primary pull-right" ValidationGroup="MasterGroup" />
                    </div> 
                    <br />                   
                </div>
           </div>

<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <br />
            <div class="divWaiting">
                <i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


