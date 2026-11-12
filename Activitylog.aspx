<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Activitylog.aspx.vb" Inherits="Activitylog" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>CRM Activity Log</title>
    <style>
    /* Grid header only */
    .activity-grid th {
        background-color: #3f4a56;   /* same as top menu */
        color: #ffffff !important;   /* white text */
        font-weight: 600;
        padding: 10px;
        border: 1px solid #3f4a56;
        text-align: left;
        white-space: nowrap;
    }

    /* Grid body (rows) – normal look */
    .activity-grid td {
        background-color: #ffffff;
        color: #333333;
        padding: 8px;
        border: 1px solid #ddd;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">

        <h2>CRM Activity Log</h2>

        <asp:GridView ID="gvActivityLog"  runat="server" AutoGenerateColumns="False" CssClass="activity-grid" BorderWidth="1" CellPadding="5">

            <Columns>
                <asp:BoundField DataField="CreatedOn" HeaderText="Date" />
                <asp:BoundField DataField="UserName" HeaderText="User" />
                <asp:BoundField DataField="Action" HeaderText="Action" />
                <asp:BoundField DataField="Module" HeaderText="Module" />
               <%-- <asp:BoundField DataField="OrderNo" HeaderText="Order No" />--%>
                <asp:BoundField DataField="Description" HeaderText="Description" />
                <asp:BoundField DataField="IPAddress" HeaderText="IP" />
                <asp:BoundField DataField="Browser" HeaderText="Browser" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
