<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charts Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript" src="https://www.google.com/jsapi"></script>
        <asp:GridView ID="gvData" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
        <div id="chart_div" style="width: 660px; height: 400px;">
        </div>
    </div>
    </form>
</body>
</html>
