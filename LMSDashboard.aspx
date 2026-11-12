<%@ Page Title="" Language="VB" MasterPageFile="~/LMSMasterPage.master" AutoEventWireup="false" CodeFile="LMSDashboard.aspx.vb" Inherits="LMSDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Page content -->
    <div class="content-header content-header-media" style="height: 125px;">
        <div class="header-section">
            <div class="row">
                <!-- Main Title (hidden on small devices for the statistics to fit hidden-xs hidden-sm) -->
                <div class="col-md-4 col-lg-6">
                    <h1>Welcome to LMS <strong>
                        <asp:Label ID="lblusername" runat="server" Font-Bold="true"></asp:Label></strong><br>
                        <small></small></h1>
                </div>
            </div>
        </div>
        <!-- For best results use an image with a resolution of 2560x248 pixels (You can also use a blurred image with ratio 10:1 - eg: 1000x100 pixels - it will adjust and look great!) -->
        <img src="img/placeholders/headers/dashboard_header.jpg" alt="header image" class="animation-pulseSlow">
    </div>
    <!-- Mini Top Stats Row -->
    <div class="row" style="margin-left: -5px; margin-right: -5px;" id="divall" runat="server">
        <div class="row">
            
            <div class="col-sm-6 col-lg-4" runat="server" id="divTodPendCount">
                <!-- Widget -->
                <div class="widget">
                    <div class="widget-extra themed-background-spring text-center">
                        <h2 class="widget-content-light">
                            <small>Today Trials</small><br>
                            <small>
                                <asp:Label ID="ltTodPendTr" Text="0" runat="server"></asp:Label></small>
                        </h2>
                    </div>
                </div>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-4" runat="server" id="divPendcount">
                <!-- Widget -->
                <div class="widget">
                    <div class="widget-extra themed-background-default text-center">
                        <h2 class="widget-content-light">
                            <small>Pending Trials</small><br>
                            <small>
                                <asp:Label ID="ltPendTr" Text="0" runat="server"></asp:Label></small>
                        </h2>
                    </div>
                </div>
                <!-- END Widget -->
            </div>
            <div class="col-sm-6 col-lg-4" runat="server" id="divFeedBack">
                <!-- Widget -->
                <div class="widget">
                    <div class="widget-extra themed-background-autumn text-center">
                        <h2 class="widget-content-light">
                            <small>Pending Feedback</small><br>
                            <small>
                                <asp:Label ID="ltFBCount" Text="0" runat="server"></asp:Label></small>
                        </h2>
                    </div>
                </div>
                <!-- END Widget -->
            </div>
        </div>
        <div class="row">
            
            <div class="col-md-12" runat="server" id="divTodayTrial">
                <div class="block">
                    <div class="block-title">
                        <h2>Today Trials
                           <%-- ( <i class="fa fa-rupee"></i> <asp:Label ID="lblpendingpay" runat="server"></asp:Label>)--%></h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                            <asp:GridView ID="grdTodayTrial" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Trial Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_No">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblformno" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Replace(Eval("Formulation_No"), "FR", "TR")))%>' />
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recipe Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_No" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblreipeno" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No")))%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Formulation Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_No" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink3" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblformno1" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_No")))%>' />
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Product_Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProdName" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trial Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Approved">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRstatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Recipe_Approved"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_Approved")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_CreatedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldate" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_CreatedDate")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Execution Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_ExecutionDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrExecution" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_ExecutionDate")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrPriority" runat="server" CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complete Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_CompleteStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrCompleteStatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Formulation_CompleteStatus"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_CompleteStatus")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assign To" ItemStyle-CssClass="col-md-2" HeaderStyle-CssClass="" SortExpression="Assignto">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrAssignTo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Assignto")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="Edit" class="btn-xs btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            <%--<asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "Modifyrecipe.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString()))%>'
                                                data-toggle="tooltip" title="Edit" class="btn-xs btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approve" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblapprover" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_Id")))%>' />
                                            <asp:Literal ID="ltFormApprove" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_FormulationId")))%>' />
                                            <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approve" class="btn-xs btn-success" runat="server"
                                                CommandName="Approvedink" CommandArgument='<%#Eval("Recipe_Id").ToString() + "," + Eval("Recipe_FormulationId").ToString()%>'>Approve</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <%--<asp:Literal ID="lblFeedStat" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("FeedStat")))%>' />--%>
                                            <asp:LinkButton ID="lnkAddFeed" data-toggle="tooltip" title="Add Feedback" class="btn-xs btn-info" runat="server"
                                                visible='<%# IIf(Eval("FeedStat") = "Already Exist", "false", "true")%>'
                                                CommandName="AddFeed" CommandArgument='<%#Eval("Recipe_Id").ToString()%>'><i class="fa fa-plus"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkViewFeed" data-toggle="tooltip" title="View Feedback" class="btn-xs btn-success" runat="server"
                                                 visible='<%# IIf(Eval("FeedStat") = "Already Exist", "true", "false")%>'
                                                    CommandName="ViewFeed" CommandArgument='<%#Eval("Recipe_Id").ToString()%>'><i class="fa fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblnorecord" runat="server" Text="No Records Found" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12" runat="server" id="divRecipegrd">
                <div class="block">
                    <div class="block-title">
                        <h2>Pending Trials
                           <%-- ( <i class="fa fa-rupee"></i> <asp:Label ID="lblpendingpay" runat="server"></asp:Label>)--%></h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                            <asp:GridView ID="GrdPendTrial" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Trial Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_No">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblformno" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Replace(Eval("Formulation_No"), "FR", "TR")))%>' />
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recipe Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_No" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblreipeno" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_No")))%>' />
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Formulation Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_No" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink3" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lblformno1" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_No")))%>' />
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Product_Name" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProdName" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Product_Name")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trial Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Approved">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRstatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Recipe_Approved"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_Approved")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_CreatedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbldate" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_CreatedDate")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Execution Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_ExecutionDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrExecution" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_ExecutionDate")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Priority Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_Priority">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrPriority" runat="server" CssClass='<%#Security.checkpriorityLMS(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_Priority")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Complete Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_CompleteStatus">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrCompleteStatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Formulation_CompleteStatus"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_CompleteStatus")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assign To" ItemStyle-CssClass="col-md-2" HeaderStyle-CssClass="" SortExpression="Assignto">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblrAssignTo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Assignto")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyTrials.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_FormulationId").ToString()))%>'
                                                data-toggle="tooltip" title="Edit" class="btn-xs btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
                                            <%--<asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "Modifyrecipe.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Recipe_Id").ToString()))%>'
                                                data-toggle="tooltip" title="Edit" class="btn-xs btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approve" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Recipe_Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblapprover" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_Id")))%>' />
                                            <asp:Literal ID="ltFormApprove" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Recipe_FormulationId")))%>' />
                                            <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approve" class="btn-xs btn-success" runat="server"
                                                CommandName="Approvedink" CommandArgument='<%#Eval("Recipe_Id").ToString() + "," + Eval("Recipe_FormulationId").ToString()%>'>Approve</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" >
                                        <ItemTemplate>
                                            <%--<asp:Literal ID="lblFeedStat" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("FeedStat")))%>' />--%>
                                            <asp:LinkButton ID="lnkAddFeed" data-toggle="tooltip" title="Add Feedback" class="btn-xs btn-info" runat="server"
                                                visible='<%# IIf(Eval("FeedStat") = "Already Exist", "false", "true")%>'
                                                CommandName="AddFeed" CommandArgument='<%#Eval("Recipe_Id").ToString()%>'><i class="fa fa-plus"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkViewFeed" data-toggle="tooltip" title="View Feedback" class="btn-xs btn-success" runat="server"
                                                 visible='<%# IIf(Eval("FeedStat") = "Already Exist", "true", "false")%>'
                                                    CommandName="ViewFeed" CommandArgument='<%#Eval("Recipe_Id").ToString()%>'><i class="fa fa-eye"></i></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblnorecord" runat="server" Text="No Records Found" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12" runat="server" id="divtrialgrd">
                <div class="block">
                    <div class="block-title">
                        <h2>Pending Feedback
                           <%-- ( <i class="fa fa-rupee"></i> <asp:Label ID="lblpendingorders" runat="server"></asp:Label>)--%></h2>
                    </div>
                    <div style="min-height: 200px; max-height: 200px; overflow: auto;">
                        <div class="table-responsive">
                            <asp:GridView ID="Grdtrial" AutoGenerateColumns="false" HeaderStyle-Font-Size="Smaller" HeaderStyle-Width="100" HeaderStyle-Font-Bold="true" AllowPaging="false" CssClass="table table-striped table-vcenter" GridLines="None" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Feedback Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_No">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifyFeedback.aspx?chk=v&ID=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Trial_Id").ToString()))%>'
                                                data-toggle="tooltip" title="View" runat="server">
                                                <asp:Literal ID="lbltrialno" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Replace(Eval("Trial_No"), "TR", "FR")))%>' />
                                            </asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Trial Code" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_No">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblTrialCode" runat="server" Text='<%#(Replace(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_No")), "FR", "TR"))%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Feedback Type" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_Type">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbltrialType" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Trial_Type")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Type" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Formulation_ProdCategory">
                                        <ItemTemplate>
                                            <asp:Literal ID="lblProdType" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Formulation_ProdCategory")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_Approved">
                                        <ItemTemplate>
                                            <asp:Label ID="lblstatus" runat="server" CssClass='<%#Security.checkpriorityLMS(Eval("Trial_Approved"))%>' Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Trial_Approved")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_CreatedDate">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbltdate" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Trial_CreatedDate")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assign To" ItemStyle-CssClass="col-md-2" HeaderStyle-CssClass="" SortExpression="Assignto">
                                        <ItemTemplate>
                                            <asp:Literal ID="lbltAssignTo" runat="server" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Assignto")))%>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_Id">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hledit" EnableViewState="false" NavigateUrl='<%# "ModifyFeedback.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("Trial_Id").ToString()))%>'
                                                data-toggle="tooltip" title="Edit" class="btn-xs btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approve" ItemStyle-CssClass="" HeaderStyle-CssClass="" SortExpression="Trial_Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltapprove" runat="server" Visible="false" Text='<%#(DynamicparcelDataManipulation.FixNullFromDB(Eval("Trial_Id")))%>' />
                                            <asp:LinkButton ID="lnkApproved" data-toggle="tooltip" title="Approved" class="btn-success btn-xs" runat="server"
                                                CommandName="ApproveTrialLink" CommandArgument='<%#Eval("Trial_Id").ToString()%>'>Approve</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="col-sm-12">
                                        <asp:Label ID="lblnorecord" runat="server" Text="No Records Found" CssClass="label label-danger"></asp:Label>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

