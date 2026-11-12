<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DashBoard.aspx.vb" Inherits="Reports_DashBoard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <br />
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
        <div id="chart_div" style="width: 660px; height: 400px;">
        </div>
    </div>
    </form>
</body>
</html>
