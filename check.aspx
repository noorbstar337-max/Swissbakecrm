<%@ Page Language="VB" AutoEventWireup="false" CodeFile="check.aspx.vb" Inherits="check" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="pnlactivity" runat="server">
                <div>
                    <hr id="ecxstopSpelling">
                    Subject:
                <asp:Literal ID="ltsubject" runat="server"></asp:Literal><br>
                    <br>
                    <title>Today Activity Email Notification</title>
                    <table bgcolor="#FFFFFF" cellpadding="2" cellspacing="0" style="border-collapse: collapse;" bordercolor="#1274C0" width="1000" height="100">
                        <tbody>
                            <tr height="20" bgcolor="">
                                <td width="1000" height="102">
                                    <table border="1" cellpadding="2" cellspacing="0" style="border-collapse: collapse;" bordercolor="#1274C0" width="1000" height="1">
                                        <tbody>
                                            <tr height="20" bgcolor="C4DAFF">
                                                <th width="1000" colspan="10" height="19" style="font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: center;"><b>Swiss Bake Ingredients Pvt Ltd  : 
                                                <asp:Literal ID="ltusername" runat="server"></asp:Literal>
                                                </b></th>
                                            </tr>

                                            <tr height="20" bgcolor="#C4DAFF">
                                                <th width="1000" colspan="10" height="19" style="font-family: Arial; font-size: 15px; font-weight: bold; color: #1274C0; text-align: left;"><b>&nbsp;Today Activity</b></th>
                                            </tr>
                                            <asp:Repeater ID="rpactivity" runat="server">
                                                <HeaderTemplate>
                                                    <tr height="20">
                                                        <td width="20" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;S.No</b></td>
                                                        <td width="150" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;" nowrap=""><b>&nbsp;Related To</b></td>
                                                        <td width="50" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;" nowrap=""><b>&nbsp;Name</b></td>
                                                        <td width="80" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;" nowrap=""><b>&nbsp;Subject</b></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;" nowrap=""><b>&nbsp;Activity Type</b></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;From</b></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;To</b></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;Priority</b></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;Status</b></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px;"><b>&nbsp;AssingTo</b></td>
                                                    </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td width="20" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;"><%# Container.ItemIndex + 1 %></td>
                                                        <td width="150" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;" nowrap=""><%# Eval("Related Type") %></td>
                                                        <td width="50" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;" nowrap=""><%# Eval("Name") %></td>
                                                        <td width="80" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;" nowrap=""><%# Eval("Subject")%></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;" nowrap=""><%# Eval("Activity Type")%></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="font-size: 12px; font-family: verdana;" nowrap=""><%# Eval("From")%></td>
                                                        <td width="100" bgcolor="#FFFFFF" height="1" valign="top" style="word-wrap: break-word; font-size: 12px; font-family: verdana;"><%# Eval("To")%></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="word-wrap: break-word; font-size: 12px; font-family: verdana;"><%# Eval("Priority")%></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="word-wrap: break-word; font-size: 12px; font-family: verdana;"><%# Eval("Status")%></td>
                                                        <td width="330" bgcolor="#FFFFFF" height="1" valign="top" style="word-wrap: break-word; font-size: 12px; font-family: verdana;"><%# Eval("AssignTo")%></td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <tr>
                                                <td colspan="10" height="15"><font face="Verdana" size="1"><u>CONFIDENTIALITY INFORMATION AND DISCLAIMER</u> </font></td>
                                            </tr>
                                            <tr>
                                                <td width="100%" colspan="10" style="word-wrap: break-word;"><font face="Verdana" size="1"></font>
                                                    <br>
                                                    <div align="justify"><font face="Verdana" size="1">&nbsp;Unless indicated otherwise, the information contained in this message is privileged and confidential, and is intended only for the use of the addressee(s) named above and others who have been specifically authorized to receive it. If you are not the intended recipient, you are hereby notified that any dissemination, distribution or copying of this message and/or attachments is strictly prohibited. The company accepts no liability for any damage caused by any virus transmitted by this email. Furthermore, the company does not warrant a proper and complete transmission of this information, nor does it accept liability for any delays. If you have received this message in error, please contact support@salesbabu.com and delete the message. Thank you. </font></div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br>
                    <font size="1" color="#666666">Sent by SalesBabu CRM</font>
                    <br>
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
