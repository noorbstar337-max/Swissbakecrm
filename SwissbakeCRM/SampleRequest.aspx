<%@ Page Title="" Language="VB" MasterPageFile="~/MainPage.master" AutoEventWireup="false" CodeFile="SampleRequest.aspx.vb" Inherits="Sample" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<script type="text/javascript">
		function checkdelete() {
			if (confirm('Are you Sure want to Delete?')) {
				document.getElementById('<%=deletestatus.ClientID %>').value = "yes";
            	return true
            }
            else {
            	document.getElementById('<%=deletestatus.ClientID %>').value = "no";
            	return true
            }
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:HiddenField ID="deletestatus" runat="server" />
	<asp:HiddenField ID="Hfgridview" runat="server" />
	<asp:HiddenField ID="hftotalrecord" runat="server" />
	<asp:HiddenField ID="hfsearch" runat="server" />
	<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
		<ContentTemplate>

			<div class="content-header">
				<div class="header-section">
					<h1>
						<i class="gi gi-parents" style="margin: -8px"></i>Sample Requests<br>
					</h1>
				</div>
			</div>
			<ul class="breadcrumb breadcrumb-top">
				<li><a href="index.aspx">Home</a></li>
				<li>Sample Requests</li>
			</ul>
			<div class="block">
				<div class="block-title">
					<h2><strong>Sample Request</strong> Details</h2>
				</div>
				<%--Search User Control Start--%>
				<User:SearchBarByID ID="SearchControl" runat="server" />
				<%--Search User Control End--%>
				<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
					<ContentTemplate>
						<asp:HiddenField ID="Hfsearchcheck" runat="server" />
						<div class="table-responsive">
							<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="SampleRequest_Id" AllowCustomPaging="true"
								CssClass="table table-striped table-vcenter table-hover" OnSorting="GridView1_Sorting"
								AllowPaging="True" PageSize="10" AllowSorting="True">
								<Columns>
									<asp:TemplateField HeaderText="Edit" ItemStyle-Width="10px" HeaderStyle-ForeColor="#1bbae1" HeaderStyle-CssClass="" ItemStyle-CssClass="">
										<HeaderTemplate>
											<asp:HyperLink ID="HyperLink4" runat="server">Edit</asp:HyperLink>
										</HeaderTemplate>
										<ItemTemplate>
											<div class="btn-group btn-group-xs">
												<asp:HyperLink ID="HyperLink2" EnableViewState="false" NavigateUrl='<%# "ModifySampleRequest.aspx?chk=e&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("SampleRequest_Id").ToString()))%>'
													data-toggle="tooltip" title="Edit" class="btn btn-default" runat="server"><i class="fa fa-pencil"></i></asp:HyperLink>
											</div>
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Sample Request No" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="SampleRequest_No">
										<ItemTemplate>
											<asp:HyperLink ID="HyperLink1" EnableViewState="false" NavigateUrl='<%# "ModifySampleRequest.aspx?chk=v&Id=" + HttpUtility.UrlEncode(Security.Encrypt(Eval("SampleRequest_Id").ToString()))%>'
												data-toggle="tooltip" title="View" runat="server">
												<asp:Literal ID="lblSamReqNo" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("SampleRequest_No"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
											</asp:HyperLink>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Request Date" ItemStyle-CssClass="MasterGridviewItem" HeaderStyle-CssClass="MasterGridviewHeader" SortExpression="SampleRequest_Date">
										<ItemTemplate>
											<asp:Literal ID="lblReqDate" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToDateTime(Eval("SampleRequest_Date")), SearchControl.UtxtSearch)%>' EnableViewState="false" />
											<%--<asp:Literal ID="Literal1" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Convert.ToString(Eval("SampleRequest_Date")), SearchControl.UtxtSearch)%>' EnableViewState="false" />--%>
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Request Type" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="SampleRequest_Type" Visible="false">
										<ItemTemplate>
											<asp:Literal ID="lblReqType" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("SampleRequest_Type"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Company Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="CompanyName" >
										<ItemTemplate>
											<asp:Literal ID="lblCompanyName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("CompanyName") + " (" + Eval("SampleRequest_Type") + ")", SearchControl.UtxtSearch)%>' EnableViewState="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Contact Name" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="ContactName">
										<ItemTemplate>
											<asp:Literal ID="lblContactName" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("ContactName"), SearchControl.UtxtSearch)%>' EnableViewState="false" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Qty (KG)" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="qty"  >
										<ItemTemplate>
											<asp:Label ID="lblqtyyyyyy" runat="server" Text='<%#DynamicparcelGridview.HighlightText(DynamicparcelDataManipulation.FixNullFromDB(Eval("qty")), SearchControl.UtxtSearch)%>' />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="AssignTo" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="AssignTo">
										<ItemTemplate>
											<asp:Label ID="lblassignto" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("AssignTo"), SearchControl.UtxtSearch)%>' />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Request Status" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem" SortExpression="SampleRequest_SampleStatus">
										<ItemTemplate>
											<asp:Label ID="lblReqStatus" runat="server" Text='<%#DynamicparcelGridview.HighlightText(Eval("SampleRequest_SampleStatus"), SearchControl.UtxtSearch)%>'
												CssClass='<%#Security.checkSRStatus(Eval("SampleRequest_SampleStatus"))%>' EnableViewState="false" />
											<asp:Literal ID="ltreqstatus" runat="server" Text='<%#Eval("SampleRequest_SampleStatus")%>' Visible="false" EnableViewState="false" />
										</ItemTemplate>
									</asp:TemplateField>

									<asp:TemplateField HeaderText="Delete" ItemStyle-Width="10px" HeaderStyle-CssClass="MasterGridviewHeader" ItemStyle-CssClass="MasterGridviewItem">
										<ItemTemplate>
											<div class="btn-group btn-group-xs">
												<asp:LinkButton ID="lnkdelete" data-toggle="tooltip" title="Delete" class="btn btn-danger" runat="server" OnClientClick="checkdelete();"
													CommandName="deletelink" CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"><i class="fa fa-times"></i></asp:LinkButton><%--      <asp:Literal ID="ltdel" runat="server"  Text='<%#DynamicparcelDataManipulation.FixNullFromDB(Eval("invCount"))%>' Visible="false" ></asp:Literal>--%>
											</div>
										</ItemTemplate>
									</asp:TemplateField>
								</Columns>
								<PagerStyle CssClass="MasterGridviewPaging" HorizontalAlign="Right" BackColor="White" />

								<FooterStyle HorizontalAlign="Center" BackColor="White" />
								<PagerSettings PageButtonCount="4" />

								<EmptyDataTemplate>
									<asp:Label ID="s" runat="server" Text="No Record Found"></asp:Label><br />
									<br />
								</EmptyDataTemplate>
								<EmptyDataRowStyle HorizontalAlign="Center" />
							</asp:GridView>
						</div>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="GridView1" />
					</Triggers>
				</asp:UpdatePanel>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="" runat="server" DisplayAfter="0">
		<ProgressTemplate>
			<br />
			<div class="divWaiting">
				<i class="fa fa-sun-o fa-spin" id="LoadingUpadatePanel"></i>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>



