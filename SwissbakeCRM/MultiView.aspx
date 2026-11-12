<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="MultiView.aspx.vb" Inherits="MultiView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script src="js/vendor/modernizr-2.7.1-respond-1.4.2.min.js"></script>
    <script src="js/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            ;debugger
           
            var MainId = getUrlVars()["Levl"];
                  //  $('#' + MainId).click();
                    var newMainId = MainId;
                    var newMainId = newMainId.match(/[a-zA-Z]+|[0-9]+/g);
             var id = newMainId[0] + newMainId[1];
             var type = newMainId[0];
            if (type == 'P') {
                $('#' + id).click();
            }
            if (type == 'PR') {
                $('#' + id).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().children(':first-child').children().children().click();
                $('#' + id).click();
            }
            if (type == 'PT') {
                $('#' + id).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().children(':first-child').children().children().click();
                $('#' + id).parent().parent().parent().parent().parent().parent().parent().parent().parent().parent().children(':first-child').children().children().click();
                $('#' + id).click();
                setTimeout(function () {
                    $('html, body').animate({
                        scrollTop: $('#' + id).offset().top
                    }, 1000);
                }, 1);
            }
            //setTimeout(function () {
            //    $('html, body').animate({
            //        scrollTop: $('.hidden1').offset().top
            //    }, 1000);
            //}, 1);
        });
        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <%--starts--%>
    <%-- <asp:Label ID="lblitemdt" Text="open" runat="server"></asp:Label>--%>
    <div class="row">
            <div class="col-md-12">
        <div id="faq188f" class="panel-group">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="panel-title"><a class="accordion-toggle" data-toggle="collapse" data-parent="#faq188f" href="#faq188f_q188">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblitemdt" Text="open" runat="server"></asp:Label></ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnsave" />
                    </Triggers>
                </asp:UpdatePanel>
            </a></h4>
        </div>
        <div id="faq188f_q188" class="panel-collapse collapse in" style=" overflow: auto;">
                <div class="col-md-12">
                    <br />
                            <div id="faq1881" class="panel-group" runat="server">
                                <asp:Repeater ID="rptmaidq" runat="server">
                                    <ItemTemplate>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881"   id='<%# "P"+Eval("Formulation_Id").ToString%>' href='<%#"#F" + Eval("Formulation_Id").ToString%>'>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                               <asp:label id="hfpFormulation" CssClass="hidden1" Value='<%# "F" + Eval("Formulation_Id").ToString%>' runat="server" style="display:none;"/>
                                                            <asp:Label ID="lblDescptn" runat="server" Text='<%#Eval("Formulation_No")%>'></asp:Label>
                                                            <asp:Label ID="lblqtn" runat="server" Text='<%#Eval("Formulation_Id")%>' Visible="false"></asp:Label>&nbsp;&nbsp;|
                                                           Version:<asp:Label ID="lblversion" runat="server"></asp:Label>&nbsp;&nbsp;|
                                                            Amount:<asp:Label ID="lblamt" runat="server" ></asp:Label>
                                                                  
                                                           <%-- <div class="pull-right">
                                                                <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyExpense.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Ex_Id").ToString()))%>'
                                                                    class="btn btn-alt btn-xs btn-primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>--%>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id='<%#"F"+Eval("Formulation_Id").ToString%>' class="panel-collapse" style="height: 0px;   overflow: auto;">
                                                <div class="panel-body">
                                                    <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                                    <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                                    <br />

                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="grditemproduct" ShowFooter="true"    GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"  HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Raw Material"  HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                         <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink11" runat="server">Raw Material </asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("Rm_Name")%>'></asp:Literal>
                                            <asp:Literal ID="ltitemid" runat="server" Text='<%#Eval("FRawM_FormulationId")%>' Visible="false"></asp:Literal>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink12" runat="server"> Code</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductcode" runat="server" Text='<%#Eval("Rm_Code")%>'></asp:Literal> 
                                            <asp:Label ID="ltitemtypeid" runat="server" Text='<%#Eval("FRawM_FormulationId")%>' Visible="false" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink13" runat="server">SKU</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("FRawM_Cost")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("FRawM_Cost")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Rate/kg</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                           <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("FRawM_Cost")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Percentage" ItemStyle-Width="100px" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                        <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink14" runat="server">Percentage</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="col-md-12">
                                                <asp:label ID="txtquantity" runat="server"  Visible="false" Text='<%#Eval("FRawM_Percentage")%>' Height="25" data-toggle="tooltip" title="Enter Qunatity"
                                                    CssClass="form-control"></asp:label>
                                                <asp:Literal ID="ltquantity" runat="server" Text='<%#Eval("FRawM_Percentage")%>'></asp:Literal>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                               
                                    <asp:TemplateField HeaderText="GST" HeaderStyle-CssClass="" ItemStyle-CssClass="" Visible="false" >
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">GST</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            
                                            
                                            <i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lblvatinrs" runat="server" Text='<%#Eval("FRawM_Percentage")%>' />(<asp:Literal ID="lblvat" runat="server" Text='<%#Eval("FRawM_Percentage")%>' />%)
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                         <asp:TemplateField HeaderText="KG" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink17" runat="server">KG</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltkg" Text='<%#Eval("FRawM_QtyKg")%>' runat="server"></asp:Literal> kg
                                            <%-- <asp:Literal ID="lblvat" runat="server" Text='<%#Eval("Product_Vat")%>' Visible="false" />--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            
                                            Total KG:<br /><hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;"" />
                                            <%-- Total Freight:<br />
                                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />--%>
                                            Total Amount:
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                            <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink18" runat="server">Amount</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <i class="fa fa-rupee"></i>&nbsp;<asp:Literal ID="ltamount" Text='<%#Eval("FRawM_Cost")%>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
<%--Total Amount:<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                            
                                            <b>&nbsp;<asp:Literal ID="lttotalKG" Text='78500' runat="server"></asp:Literal> KG</b><br />
                                                                  <%--          
                                            <hr style="border: 0; border-top: 1px solid #eee; margin-top: 4px; margin-bottom: 4px;" />
                                                                            <b><i class="fa fa-rupee"></i>&nbsp;
                                                                <asp:Label ID="lblfreight"  runat="server"></asp:Label>

                                                            </b>
                                                            <br />--%>
                                            <hr style="border:0;border-top: 1px solid #eee;margin-top:4px;margin-bottom:4px;" /><b><i class="fa fa-rupee"></i>&nbsp; <asp:Literal ID="lttotalamount" Text='78500' runat="server"></asp:Literal></b></FooterTemplate>
                                    </asp:TemplateField>
                                 
                                </Columns>
                             <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                       
                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                    </Triggers>
                </asp:UpdatePanel>
                                                    <%--recepie starts--%>
                                                    <ul>
   <div id="faq188f_q188" class="panel-collapse collapse in" style=" overflow: auto;">
                <div class="col-md-12">
                    <br />
                            <div id="faq1881" class="panel-group" runat="server">
                                <asp:Repeater ID="rptmainRcp" runat="server" OnItemDataBound="rptmainRcp_ItemDataBound"  >
                                    <ItemTemplate>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881"   id='<%# "PR" + Eval("Recipe_Id").ToString%>' href='<%#"#R" + Eval("Recipe_Id").ToString%>'>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblRcpNo" runat="server" Text='<%#Eval("Recipe_No")%>'></asp:Label>
                                                                  <asp:HiddenField id="hfPrecipe" Value='<%# "R" + Eval("Recipe_Id").ToString%>' runat="server" />
                                                            <asp:Label ID="lblrcpid" runat="server" Text='<%#Eval("Recipe_Id")%>' Visible="false"></asp:Label>&nbsp;&nbsp;|
                                                           Status:<asp:Label ID="lblversion1" Text='<%#Eval("Recipe_Approved")%>'  runat="server"></asp:Label>&nbsp;&nbsp;
                                                         
                                                                  
                                                           <%-- <div class="pull-right">
                                                                <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyExpense.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Ex_Id").ToString()))%>'
                                                                    class="btn btn-alt btn-xs btn-primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>--%>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id='<%#"R" + Eval("Recipe_Id").ToString%>' class="panel-collapse" style="height: 0px;   overflow: auto;">
                                                <div class="panel-body">
                                                    <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                                    <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                                    <br />

                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">
                            <asp:GridView ID="grditemrcp" ShowFooter="true"    GridLines="None" CssClass="table table-striped table-vcenter" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true"  HeaderStyle-Font-Size="Smaller" CellPadding="0" CellSpacing="0" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Product Name"  HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                         <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink11" runat="server">Ingredients</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductname" runat="server" Text='<%#Eval("RecipeIngredient_Name")%>'></asp:Literal>
                                            <asp:Literal ID="ltitemid1" runat="server" Text='<%#Eval("Recipe_Id")%>' Visible="false"></asp:Literal>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="SKU" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink13" runat="server">Value</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="ltproductWeight" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>' Visible="false"></asp:Literal>
                                            <asp:Literal ID="ltpackingpacking" runat="server" Text='<%#Eval("RecipeIngredient_Value")%>'></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rate" HeaderStyle-CssClass="" ItemStyle-CssClass="">
                                          <HeaderTemplate>
                                        <asp:HyperLink ID="HyperLink15" runat="server">Percent</asp:HyperLink>
                                       </HeaderTemplate>
                                        <ItemTemplate>
                                          &nbsp; <asp:Literal ID="ltrate" runat="server" Text='<%#Eval("RecipeIngredient_Percent")%>'></asp:Literal>%
                                        </ItemTemplate>
                                    </asp:TemplateField>
                             
                               
                                    
                                          
                                    
                                 
                                </Columns>
                             <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="left" BackColor="White" />
                                <FooterStyle HorizontalAlign="left" BackColor="White" />
                                <PagerSettings PageButtonCount="4" />
                                <EmptyDataTemplate>
                                    <asp:Label ID="s" runat="server" Text="No Item Found"></asp:Label><br />
                                    <br />
                                </EmptyDataTemplate>
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                       
                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                    </Triggers>
                </asp:UpdatePanel>


                                                    <%--trial starts--%>
  <ul>
   <div id="faq188f_q188" class="panel-collapse collapse in" style=" overflow: auto;">
                <div class="col-md-12">
                    <br />
                            <div id="faq1881" class="panel-group" runat="server">
                                <asp:Repeater ID="rptmaintrial" runat="server" OnItemDataBound="rptmaintrial_ItemDataBound"   >
                                    <ItemTemplate>

                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <h4 class="panel-title"><a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#faq1881"   id='<%# "PT" + Eval("Trial_Id").ToString%>' href='<%#"#T" + Eval("Trial_Id").ToString%>'>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblTrialNo" runat="server" Text='<%#Eval("Trial_No")%>'></asp:Label>
                                                                  <asp:HiddenField id="hfpTrial" Value='<%# "T" + Eval("Trial_Id").ToString%>' runat="server" />
                                                            <asp:Label ID="lblTrialid" runat="server" Text='<%#Eval("Trial_Id")%>' Visible="false"></asp:Label>&nbsp;&nbsp;|
                                                           Status:<asp:Label ID="lblversion11" Text='<%#Eval("Trial_Approved")%>'  runat="server"></asp:Label>&nbsp;&nbsp;
                                                         
                                                                  
                                                           <%-- <div class="pull-right">
                                                                <asp:Label ID="lblAmt" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyExpense.aspx?Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Ex_Id").ToString()))%>'
                                                                    class="btn btn-alt btn-xs btn-primary" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                                            </div>--%>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                </a></h4>
                                            </div>
                                            <div id='<%#"T" + Eval("Trial_Id").ToString%>' class="panel-collapse" style="height: 0px;   overflow: auto;">
                                                <div class="panel-body">
                                                    <asp:LinkButton ID="LinkButton1" Text="" runat="server" />
                                                    <asp:LinkButton ID="LinkButton2" Text="Add Item" runat="server" class="btn btn-alt btn-xs btn-primary" Visible="false" />
                                                    <br />

                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive">

                            <%--Trial method starts--%>
                            <div id="DivEvalMethod" runat="server">
                                    <h5><strong>
                                        <asp:Label runat="server" ID="lbltype"></asp:Label>
                                        Evaluation Method</strong></h5>
                                         <asp:HiddenField ID="strrowcount" runat="server" />
                                    <div class="table-responsive">
                                        <div class="widget-extra-full">
                                            <div class="form-horizontal">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvEvalMethod" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                <Columns>
                                                                    <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                    <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                        <ItemTemplate>
                                                                            <div class="input-group  col-md-12">
                                                                                <div class="text-center">
                                                                                    <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                </div>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Recipe No.</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass="form-control MasterGridviewItem " Visible="false"></asp:Label>
                                                                                <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                <%--<asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("Dough_Temperature")%>' Visible="false"></asp:Literal>--%>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvtxtProcStep" runat="server"  ControlToValidate="txtProcStep" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS" 
                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Dough &#8451;</HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="txtDoughTemp" ToolTip="Dough Temperature" onkeypress="return onlyNos(event,this);" runat="server" Text='<%#Bind("TrialMethod_DoughTemperature")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                <%--<asp:Literal ID="ltRMat" runat="server" Text='<%#Eval("Dough_Temperature")%>' Visible="false"></asp:Literal>--%>
                                                                                <%--<asp:RequiredFieldValidator ID="rfvtxtProcStep" runat="server"  ControlToValidate="txtProcStep" Display="Dynamic" ValidationGroup="MasterGroupProc" CssClass="MasterValidationCSS" 
                                                                    ErrorMessage="This is required" SetFocusOnError="true"></asp:RequiredFieldValidator>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Bench <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <%--<asp:Label ID="txtBenchTime" runat="server" ></asp:Label>--%>
                                                                                <asp:Label ID="txtBenchTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_OnBenchTime")%>' CssClass="form-control MasterGridviewItem"
                                                                                    onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtBenchTime');" onblur="Coloncheck(this,'txtBenchTime');checktime(this,'txtBenchTime');"
                                                                                    MaxLength="5" ToolTip="On Bench Time"></asp:Label>
                                                                                <%--<asp:Label ID="txtBenchTime" runat="server" Text='<%#Bind("Bench_Time")%>' CssClass="form-control MasterGridviewItem test-input"  placeholder="hh:mm:ss" ></asp:Label>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Scale <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <%--<ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtScaleTime" Mask="99:99:99" />--%>
                                                                                <asp:Label ID="txtScaleTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_ScaleTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                    onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtScaleTime');" onblur="Coloncheck(this,'txtScaleTime');checktime(this,'txtScaleTime');"
                                                                                    MaxLength="5" ToolTip="Scale Time"></asp:Label>

                                                                                <%--<asp:Label ID="txtScaleTime" runat="server" Text='<%#Bind("Scale_Time")%>' CssClass="form-control MasterGridviewItem test-input "  placeholder="hh:mm:ss"></asp:Label>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Scale Weight </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="txtScaleWeight" runat="server" Text='<%#Bind("TrialMethod_ScaleWeight")%>' CssClass="form-control MasterGridviewItem " ToolTip="ScaleWeight"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>In Proofer <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MeX2" runat="server" TargetControlID="txtInProoferTime" Mask="99:99:99" />--%>
                                                                                <asp:Label ID="txtInProoferTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_InProoferTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                    onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtInProoferTime');" onblur="Coloncheck(this,'txtInProoferTime');checktime(this,'txtInProoferTime');"
                                                                                    MaxLength="5" ToolTip=" In Proofer Time"></asp:Label>
                                                                                <%--<asp:Label ID="txtInProoferTime"  runat="server" Text='<%#Bind("InProofer_Time")%>'  CssClass="form-control MasterGridviewItem test-input" placeholder="hh:mm:ss"  maxlength="8" ></asp:Label>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Oven in <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <%--<ajaxToolkit:MaskedEditExtender ID="MeX2" runat="server" TargetControlID="txtInOvenTime" Mask="99:99:99" />--%>
                                                                                <asp:Label ID="txtInOvenTime" runat="server" placeholder="HH:MM" Text='<%#Bind("TrialMethod_InOvenTime")%>' CssClass="form-control MasterGridviewItem test-inpu1t"
                                                                                    onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtInOvenTime');" onblur="Coloncheck(this,'txtInOvenTime');checktime(this,'txtInOvenTime');"
                                                                                    MaxLength="5" ToolTip="In Oven Time"></asp:Label>

                                                                                <%-- <asp:Label ID="txtInOvenTime" runat="server" Text='<%#Bind("InOven_Time")%>' CssClass="form-control MasterGridviewItem test-inpu1t" 
                                                                  placeholder="hh:mm:ss" value="" maxlength="6" ></asp:Label>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Oven out <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="txtOutOvenTime" placeholder="HH:MM" runat="server" Text='<%#Bind("TrialMethod_OutOvenTime")%>' CssClass="form-control MasterGridviewItem test-input"
                                                                                    onkeypress="return onlyNos(event,this);" onkeyup="insertColon(this,'txtOutOvenTime');" onblur="Coloncheck(this,'txtOutOvenTime');checktime(this,'txtOutOvenTime');"
                                                                                    MaxLength="5" ToolTip="Out Oven Time"></asp:Label>

                                                                                <%--<asp:Label ID="txtOutOvenTime" runat="server" Text='<%#Bind("OutOven_Time")%>' CssClass="form-control MasterGridviewItem test-input " placeholder="hh:mm:ss"></asp:Label>--%>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Steam </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <%--<asp:CheckBox ID="chkSteam" runat="server" CssClass="form-control select-chosen " />--%>
                                                                                <asp:DropDownList ID="ddlSteam" runat="server" CssClass="form-control select-chosen " AutoPostBack="false" ToolTip="Steam">
                                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:Literal ID="ltSteam" runat="server" Text='<%#Eval("TrialMethod_Steam")%>' Visible="false"></asp:Literal>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Bulk fermentation" HeaderStyle-ForeColor="#666666" HeaderStyle-Width="11%" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Bulk Fermentation <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblBulkferment" runat="server" Text='<%#Eval("Bulk_fermentation")%>' CssClass="MasterGridviewItem " ToolTip="Bulk Fermentation"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-Width="9%" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Proofing <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblProofing" runat="server" Text='<%#Bind("Proofing")%>' CssClass="MasterGridviewItem " ToolTip="Proofing"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-Width="9%" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                        <HeaderTemplate>Baking <i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <div class="col-md-12">
                                                                                <asp:Label ID="lblBakingTime" runat="server" Text='<%#Bind("Baking_Time")%>' CssClass="MasterGridviewItem " ToolTip="Baking Time"></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>


                                                                    <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem">
                                                                        <ItemTemplate>
                                                                            <div class="btn-group btn-group-xs" style="display: none;">
                                                                                <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                    CommandName="deleteEvalMLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <div id="divLknAdd" class="btn-group btn-group-xs" style="display: none;">
                                                                                <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupEvalM')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                    CommandName="AddEvalMNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
                                                                            </div>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>

                                                                <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                                <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                <PagerSettings PageButtonCount="4" />
                                                                <EmptyDataTemplate>
                                                                </EmptyDataTemplate>
                                                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                                            </asp:GridView>
                                                            <asp:Literal runat="server" ID="Literal3"></asp:Literal>
                                                        </div>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="gvEvalMethod" />

                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="clear: both"></div>
                                </div>
                            <%--Trial method starts--%>
                            <br />
                            
                         <h5><strong>Evaluation</strong></h5>
                                 <%--Trial Evaluation starts--%>
                                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="gvMultiEval" runat="server" AutoGenerateColumns="False" DataKeyNames="" AllowCustomPaging="true"
                                                                    CssClass="table table-striped table-vcenter table-condensed" ShowFooter="true" GridLines="None">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="RowNumber" Visible="false" />

                                                                        <asp:TemplateField HeaderText="Sr No." Visible="False" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="">
                                                                            <ItemTemplate>
                                                                                <div class="input-group  col-md-12">
                                                                                    <div class="text-center">
                                                                                        <asp:Literal ID="ltFrom" runat="server" Text='<%#Eval("RowNumber")%>' Visible="False"></asp:Literal>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="lblValue" runat="server" Text="Value" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="lblComment" runat="server" Text="Comment" CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="false" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Recipe No.</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="lblRecipeID" runat="server" Text='<%#Bind("Recipe_Id")%>' CssClass="form-control MasterGridviewItem " Visible="false"></asp:Label>
                                                                                    <asp:Label ID="lblRecipeNo" runat="server" Text='<%#Bind("Recipe_No")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" HeaderStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Center Height</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtcentreHtVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtcentreHtcom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CenterHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Left Side Height<i class="fa fa-clock-o"></i></HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtLeftHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtLeftHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_LeftHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Right Side Height</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtrightHeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtrightHeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_RightHeightCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Sweetness</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtsweetVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtsweetCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_SweetnessCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Flavour</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtflavorVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtflavorCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_FlavourCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" Visible="False" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Specific Gravity of Batter (g/liter)</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtBatterVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtBatterCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_BatterGravityCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Volume</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtVolumeVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtVolumeCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_VolumeCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Weight</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtWeightVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightVal")%>' CssClass="form-control "></asp:Label>
                                                                                    <asp:Label ID="txtWeightCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_WeightCom")%>' CssClass="form-control "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Dimension</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtDimensionVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtDimensionCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_DimensionCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Crumb Texture</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtCrumbTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtCrumbTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Crumb Color</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtCrumbColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtCrumbColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrumbColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Crust Texture</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtCrustTextVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtCrustTextCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustTextureCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Crust Color</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtCrustColVal" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorVal")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                    <asp:Label ID="txtCrustColCom" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_CrustColorCom")%>' CssClass="form-control MasterGridviewItem "></asp:Label>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Taste</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>
                                                                                    <asp:Label ID="txtTasteVal" TextMode="MultiLine" Rows="4" ToolTip="Dough Temperature" runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="   MasterGridviewItem "></asp:Label>
                                                                                    <%--<asp:Label ID="txtTasteCom" ToolTip="Dough Temperature"  runat="server" Text='<%#Bind("TrialEval_Taste")%>' CssClass="form-control MasterGridviewItem "></asp:Label>--%>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                       <%-- <asp:TemplateField HeaderStyle-ForeColor="#666666" ItemStyle-Width="8%" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle">
                                                                            <HeaderTemplate>Upload Image</HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <div>

                                                                                    <label class="btn btn-alt btn-xs btn-info ">
                                                                                        Choose Files
                                                                                    <asp:FileUpload ID="MuImage" Style="display: none;" CssClass="fileuploadM" multiple="multiple" runat="server" />

                                                                                    </label>

                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>

                                                                        <asp:TemplateField ItemStyle-Width="10px" HeaderStyle-ForeColor="#666666" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="MasterGridviewItem" Visible="false">
                                                                            <ItemTemplate>
                                                                                <div class="btn-group btn-group-xs" style="display: none;">
                                                                                    <asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
                                                                                        CommandName="deleteEvalMLink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <div id="divLknAdd" class="btn-group btn-group-xs" style="display: none;">
                                                                                    <asp:LinkButton ID="lnkadd" data-toggle="tooltip" title="Add" class="btn btn-info" runat="server" OnClientClick="if (!Page_ClientValidate('MasterGroupEvalM')){ return false; } this.disabled = true; this.value = 'Adding...';"
                                                                                        CommandName="AddEvalMNewRow" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-plus"></i></asp:LinkButton>
                                                                                </div>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>

                                                                    <PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />
                                                                    <FooterStyle HorizontalAlign="Center" BackColor="White" />
                                                                    <PagerSettings PageButtonCount="4" />
                                                                    <EmptyDataTemplate>
                                                                    </EmptyDataTemplate>
                                                                    <EmptyDataRowStyle HorizontalAlign="Center" />
                                                                </asp:GridView>
                                                                <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                                                            </div>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <%--<asp:AsyncPostBackTrigger ControlID="gvMultiEval" />--%>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                               <%--Trial Evaluation ends--%>
                        </div>

                    </ContentTemplate>
                    <Triggers>
                       
                        <asp:AsyncPostBackTrigger ControlID="grditemproduct" />
                    </Triggers>
                </asp:UpdatePanel>

                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>
                                                     
                                                </div> 
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>
                                                     
                                                </div> 
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>


                        </div>
                                                     
                                                </div> 

    </div>  </div> 
            </div>
        </div>
            <%--ends--%>
</asp:Content>

