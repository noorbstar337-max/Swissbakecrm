<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Demo1.aspx.vb" Inherits="Demo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/html">
    window.onafterprint = function(){
  window.location.assign("http://localhost:55611/ViewQuotation.aspx?Id=yfwXks99d3XI%2bRbzzr3ZHw%3d%3d")
}

        if (navigator.userAgent.toLowerCase().indexOf('chrome') > -1) {
    var showPopup = false;
    window.onbeforeunload = function () {
        if (showPopup) {
            return 'You must use the Cancel button to close the Print Preview window.\n';
        } else {
            showPopup = true;
        }
    }
    window.print();
    window.close();
} else {
    window.print();
    window.close();
}
    </script>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
     <div id="abc" runat="server">
        
    </div>

    </form>
</body>
</html>
