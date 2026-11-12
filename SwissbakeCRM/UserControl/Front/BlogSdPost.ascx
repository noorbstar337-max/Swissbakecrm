<%@ Control Language="VB" AutoEventWireup="false" ClassName="BlogSdPost" CodeFile="BlogSdPost.ascx.vb" Inherits="UserControl_Front_BlogSiderecenrPost" %>
<li class="widget r-posts-w fx" data-animate="fadeInRight">
    <h3 class="widget-head">Recent Posts</h3>
    <div class="widget-content">
        <ul>
            <asp:Repeater ID="rprecentblog" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="post-img">
                           <asp:Image ID="imgblog" runat="server" Height="70" Width="70" EnableViewState="false"  ImageUrl='<%#Page.ResolveUrl(DynamicparcelImages.NoImagUserControl(Eval("Blog_BlogImage")))%>'  alt="Our Blog post image goes here"/>
                        </div>
                        <div class="widget-post-info">
                            <h4>
                                <asp:HyperLink ID="hfseo" runat="server" NavigateUrl='<%#Page.ResolveUrl("BlogDetail/" + Eval("Blog_SeoUrl"))%>'><asp:Literal ID="lblblogtitle" runat="server" Text='<%# Eval("Blog_BlogTitle")%>' EnableViewState="false"></asp:Literal>
                                </asp:HyperLink>
                            </h4>
                            <div class="meta">
                                <span><i class="fa fa-clock-o"></i><asp:Literal ID="lblblogday" runat="server"  Text='<%#(DateFormat(Eval("Blog_CreatedDate")))%>' EnableViewState="false" />,</span><a href="blog-single.html"><i class="fa fa-eye"></i><asp:Literal ID="lblblogview" runat="server" Text='<%#Eval("blog_blogview")%>' EnableViewState="false"></asp:Literal></a>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</li>
