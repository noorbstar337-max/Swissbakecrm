<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SideBlogpost.ascx.vb" Inherits="UserControl_Front_BlogSideBlogCategory" %>
<li class="widget blog-cat-w fx" data-animate="fadeInRight">
    <h3 class="widget-head">Blog Categories</h3>
    <div class="widget-content">
        <ul class="list list-ok alt">
            <asp:Repeater ID="rprecentblog" runat="server">
                <ItemTemplate>
                    <li><a href="blog-single.html">
                        <asp:Literal ID="lblcategory" runat="server" Text='<%#Eval("Cat_Name")%>' EnableViewState="false"></asp:Literal>
                    </a><span>[<asp:Literal ID="Literal1" runat="server" Text='<%#Eval("TotalBlog")%>' EnableViewState="false"></asp:Literal>]</span></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</li>
