<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VendorSide.ascx.vb" Inherits="UserControl_Front_VendorSide" %>
<asp:Repeater ID="rpvendorside" runat="server">
    <ItemTemplate>
        <li>
            <a class="flickr" title="">
             <asp:Image ID="imgblog" runat="server" Height="78" Width="78" EnableViewState="false" 
              ImageUrl='<%#Page.ResolveUrl(DynamicparcelImages.NoImagUserControl(Eval("Ven_Logo")))%>' alt="Our Blog post image goes here"/><span class="img-overlay"></span>
            </a>
        </li>
    </ItemTemplate>
</asp:Repeater>

