<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsSideBlock.ascx.vb" Inherits="UserControl_Front_NewsSideBlock" %>
				<ul class="sidebar_widgets">
							
									
									<li class="widget r-posts-w fx" data-animate="fadeInRight">
										<h3 class="widget-head">Recent News</h3>
										<div class="widget-content">
											<ul>
                                                 <asp:Repeater ID="rprecentnews" runat="server">
                <ItemTemplate>
												<li>
												
													<div class="widget-post-info">
														<h4>
															<a href='<%#Page.ResolveUrl("NewsDetail/" + Eval("N_SeoUrl"))%>' style="color:rgb(196, 22, 28);">
																 <asp:Literal ID="lbltitle" runat="server" Text='<%#Eval("N_Title")%>' EnableViewState="false" />
															</a>
														</h4>
														<div class="meta">
															<span><i class="fa fa-clock-o"></i> <asp:Literal ID="lbldate" runat="server" Text='<%#DateFormat(Eval("N_CreatedDate"))%>' EnableViewState="false" /></span>
														</div>
                                                        <p style="color:rgb(102, 102, 102);"><asp:Literal ID="lbldesc" runat="server" Text='<%#DynamicparcelDisplayFunctions.TruncateDescription(Eval("N_ShrtDescription"),90)%>' EnableViewState="false" /><br/> <a class="read-more" href='<%#Page.ResolveUrl("NewsDetail/" + Eval("N_SeoUrl"))%>' style="color:rgb(196, 22, 28);float: right;">Read more</a> </p>
											
													</div>
												</li>
											 </ItemTemplate>
            </asp:Repeater>
											
											</ul>
										</div>
									</li>
								</ul>	
