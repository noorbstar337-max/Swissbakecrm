<%@ Page Language="VB" AutoEventWireup="false" CodeFile="testing.aspx.vb" Inherits="testing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>


<script src="jquery-1.3.2.js" type="text/javascript"></script>

<script type="text/javascript">

        //with bind function
        $(document).ready(function(){
                $("#<%= btnNormal.ClientID %>").bind("mouseover",         function()
        {
                $("#result").append("I Will be there untill postback occurs");
                });
        alert("bind")
        }); 
</script>

<script type="text/javascript">

        // with live function
        $(document).ready(function()
{
$("#<%= btnLive.ClientID %>").live("mouseover", function()
{
$("#resultLive").append("I will always be functional");
});
alert("live")
}); 
</script>

<script type="text/javascript">
function pageLoad(sender, args)
{
        $(document).ready(function()
{
$("#<%= btnLoad.ClientID %>").bind("mouseover", function()
{
$("#resultPageLoad").append("I wiil be binded in each page load");
});


});


if (args.get_isPartialLoad())
{
        alert("Partial Postback occur");
}
else
{
        alert("Full page post back."); 
}
}
</script>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="uppnl" runat="server">
<ContentTemplate>
        <table>
        <thead>
        <tr>
                <th>
                        jQuery bind()
                </th>
                <th>
                        jQuery live()
                </th>
                <th>
                        PageLoad(sender,args)
                </th>
        </tr>
        </thead>
<tbody>
        <tr valign="top">
                <td style="width: 150px">
                        <asp:Button ID="btnNormal" runat="server" Text="Hover Before postback" />
                </td>
                <td>
                        <asp:Button ID="btnLive" runat="server" Text="Hover Anytime" />
                </td>
                <td>
                        <asp:Button ID="btnLoad" runat="server" Text="I will always be there" />
                </td>
        </tr>
        </tbody>
</table>
        <asp:Button ID="btn" runat="server" Text="Postback" />
</ContentTemplate>
</asp:UpdatePanel>
<table>
<tr valign="top">
        <td style="width: 150px">
                <div id="result"></div>
        </td>
        <td>
                <div id="resultLive"></div>
        </td>
        <td>
                <div id="resultPageLoad"></div>
        </td>
</tr>
</table>
</div>
</form>
</body>
</html>
