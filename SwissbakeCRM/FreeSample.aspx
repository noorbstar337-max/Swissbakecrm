<%--<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="FreeSample.aspx.vb" Inherits="FreeSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>Free Sample</title>
    <script type="text/javascript">
        function hideMessage() {
            setTimeout(function () {
                var msg = document.getElementById('<%= lblMessage.ClientID %>');
            if (msg) {
                msg.innerHTML = "";
            }
        }, 3000);
        }
    </script>
    <style>
        .free-sample-container {
            padding: 20px;
        }

        .free-sample-title {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .sample-add-section {
            display: flex;
            gap: 10px;
            align-items: center;
            margin-bottom: 20px;
        }

        .sample-grid {
            width: 100%;
            border-collapse: collapse;
        }

        .sample-grid th {
            background: #f5f5f5;
            padding: 10px;
            text-align: left;
        }

        .sample-grid td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .delete-btn {
            color: red;
            cursor: pointer;
        }
    </style>

</asp:Content>


<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    Runat="Server">

    <div class="free-sample-container">

        <div class="free-sample-title">
            Free Sample
        </div>

        <!-- Add Product -->
        <div class="sample-add-section">

            <asp:DropDownList
                ID="ddlProduct"
                runat="server"
                CssClass="form-control"
                Width="350px">
            </asp:DropDownList>

            <asp:Button
                ID="btnAddSample"
                runat="server"
                Text="Add Free Sample"
                CssClass="btn btn-primary"
                OnClick="btnAddSample_Click" />

        </div>

        <br />

        <!-- Free Sample Grid -->

        <asp:GridView
            ID="gvFreeSample"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="sample-grid"
            DataKeyNames="FreeSample_Id"
            OnRowCommand="gvFreeSample_RowCommand">

            <Columns>

                <asp:BoundField
                    DataField="Product_Name"
                    HeaderText="Product" />

                <asp:BoundField
                    DataField="Product_Code"
                    HeaderText="Product Code" />


                <asp:TemplateField HeaderText="Amount">
    <ItemTemplate>
        <asp:TextBox
            ID="txtAmount"
            runat="server"
            CssClass="form-control"
            Text='<%# Eval("FreeSample_Amount", "{0:0.00}") %>'
            Width="100px">
        </asp:TextBox>
    </ItemTemplate>
</asp:TemplateField>
                <asp:TemplateField HeaderText="Action">

                    <ItemTemplate>
                         <asp:LinkButton
            ID="lnkUpdate"
            runat="server"
            Text="Update"
            CssClass="btn btn-success"
            CommandName="UpdateAmount"
            CommandArgument='<%# Eval("FreeSample_Id") %>'>
        </asp:LinkButton>
                        <asp:LinkButton
                            ID="lnkDelete"
                            runat="server"
                            Text="Delete"
                            CssClass="btn btn-danger"
                            CommandName="DeleteSample"
                            CommandArgument='<%# Eval("FreeSample_Id") %>'
                            OnClientClick="return confirm('Are you sure you want to delete this free sample?');">
                        </asp:LinkButton>

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <br />

        <asp:Label
            ID="lblMessage"
            runat="server">
        </asp:Label>

    </div>

</asp:Content>
--%>

<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="FreeSample.aspx.vb" Inherits="FreeSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <title>Free Sample</title>

    <script type="text/javascript">
        function hideMessage() {
            setTimeout(function () {
                var msg = document.getElementById('<%= lblMessage.ClientID %>');
                if (msg) {
                    msg.innerHTML = "";
                }
            }, 3000);
        }
    </script>

    <style>
        .free-sample-container {
            padding: 20px;
        }

        .free-sample-title {
            font-size: 20px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .sample-add-section {
            display: flex;
            gap: 10px;
            align-items: center;
            margin-bottom: 20px;
        }

        .sample-grid {
            width: 100%;
            border-collapse: collapse;
        }

        .sample-grid th {
            background: #f5f5f5;
            padding: 10px;
            text-align: left;
        }

        .sample-grid td {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

        .sample-grid input {
            max-width: 120px;
        }

        .delete-btn {
            color: red;
            cursor: pointer;
        }

        .total-amount {
            display: block;
            margin-top: 15px;
            font-size: 18px;
            font-weight: bold;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1"
    Runat="Server">

    <div class="free-sample-container">

        <div class="free-sample-title">
            Free Sample
        </div>

        <!-- ADD PRODUCT -->
        <div class="sample-add-section">

            <asp:DropDownList
                ID="ddlProduct"
                runat="server"
                CssClass="form-control"
                Width="350px">
            </asp:DropDownList>

            <asp:Button
                ID="btnAddSample"
                runat="server"
                Text="Add Free Sample"
                CssClass="btn btn-primary"
                OnClick="btnAddSample_Click" />

        </div>

        <br />

        <!-- FREE SAMPLE GRID -->
        <asp:GridView
            ID="gvFreeSample"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="sample-grid"
            DataKeyNames="FreeSample_Id"
            OnRowCommand="gvFreeSample_RowCommand">

            <Columns>

                <asp:BoundField
                    DataField="Product_Name"
                    HeaderText="Product" />

                <asp:BoundField
                    DataField="Product_Code"
                    HeaderText="Product Code" />

                <%-- AMOUNT --%>
                <asp:TemplateField HeaderText="Amount">

                    <ItemTemplate>

                        <asp:TextBox
                            ID="txtAmount"
                            runat="server"
                            CssClass="form-control"
                            Text='<%# Eval("FreeSample_Amount", "{0:0.00}") %>'
                            Width="100px">
                        </asp:TextBox>

                    </ItemTemplate>

                </asp:TemplateField>

                <%--ACTION--%>
                <asp:TemplateField HeaderText="Action">

                    <ItemTemplate>

                        <asp:LinkButton
                            ID="lnkUpdate"
                            runat="server"
                            Text="Update"
                            CssClass="btn btn-success"
                            CommandName="UpdateAmount"
                            CommandArgument='<%# Eval("FreeSample_Id") %>'>
                        </asp:LinkButton>

                        &nbsp;

                        <asp:LinkButton
                            ID="lnkDelete"
                            runat="server"
                            Text="Delete"
                            CssClass="btn btn-danger delete-btn"
                            CommandName="DeleteSample"
                            CommandArgument='<%# Eval("FreeSample_Id") %>'
                            OnClientClick="return confirm('Are you sure you want to delete this free sample?');">
                        </asp:LinkButton>

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <%--TOTAL AMOUNT --%>
        <asp:Label
            ID="lblTotalAmount"
            runat="server"
            CssClass="total-amount">
        </asp:Label>

        <br />

        <%--MESSAGE --%>
        <asp:Label
            ID="lblMessage"
            runat="server">
        </asp:Label>

    </div>

</asp:Content>
