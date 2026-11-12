<%@ Control Language="VB" AutoEventWireup="false" ClassName="SearchControl" CodeFile="SearchControl.ascx.vb" Inherits="UserControl_Back_WebUserControl" %>
<div class="row">
    <div class="form-group" style="margin:0px 57px">
                            <%-- <asp:Button ID="btnExportPDF" Text="ExportToPdf" runat="server" CssClass="btn btn-alt btn-sm btn-info" />--%>
                        </div>
</div>
 

<div class="table-options clearfix">
    <div class="col-sm-5 col-xs-4">
        <div class="dataTables_length" id="example-datatable_length">
            <asp:DropDownList ID="ddpagesize" AutoPostBack="true" runat="server" CssClass="form-control">
                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                <asp:ListItem Text="20" Value="20"></asp:ListItem>
                <asp:ListItem Text="30" Value="30"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="col-sm-4 col-xs-12">
        <div id="example-datatable_filter" class="dataTables_filter">
            <label>
                <div class="input-group">
                    <asp:TextBox ID="txtsearch" runat="server" class="form-control" placeholder="Search" /><span class="input-group-addon">
                        <i class="fa fa-search"></i></span>
                </div>
            </label>
        </div>
    </div>
    <div class="col-sm-3 col-xs-12">
        <asp:Button ID="btnshowall" EnableViewState="false" runat="server" Text="Show All" CssClass="btn btn-alt btn-sm btn-primary" />
        <asp:HyperLink ID="hfadd"  runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:HyperLink>
        <asp:linkbutton ID="lkadd"  runat="server" Text="ADD" CssClass="btn btn-alt btn-sm btn-primary"></asp:linkbutton>
        <asp:ImageButton ID="btnExportWord" Width="33px" ImageAlign ="Right"  data-toggle="tooltip" title="Export Word"  ImageUrl="~/images/word.gif"
       runat="server" 
                             />
                            <asp:ImageButton ID="btnExportExcel" data-toggle="tooltip" title="Export Excel" style="margin-right:10px" Width="33px" ImageAlign ="Right" runat="server" ImageUrl="~/images/excel.gif" />
                          
    </div>
</div>
<asp:HiddenField ID ="hfsearchmode" runat ="server" />
<asp:HiddenField ID ="hfExcelmode" runat ="server" />
<asp:HiddenField ID="hfgridviewmode" runat="server" />
<asp:HiddenField ID="hftotalcount" runat="server" />
  <asp:HiddenField ID="hfExcelName" runat="server" />
