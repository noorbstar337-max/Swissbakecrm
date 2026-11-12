<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calendar.aspx.vb" Inherits="Calendar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="X-UA-Compatible" content="IE=8" />
    <script type="text/javascript">
        var Activity_Owner = '<%=Session("UserId")%>';
    </script>

    <link href="Calendar%20files/css/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" type="text/css" />
    <link href="Calendar%20files/css/cupertino/jquery-ui.min.css" rel="stylesheet" type="text/css" />
      <link href="Calendar%20files/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
     <%--<link href="Calendar%20files/fullcalendar/formbubble.css" media="screen" rel="stylesheet" type="text/css"  />
    <link href="Calendar%20files/fullcalendar/viewmore.css"media="screen" rel="stylesheet" type="text/css"  />--%>
    <link href="Calendar%20files/fullcalendar.print.css" rel="stylesheet" />
    <%--<link href="Calendar%20files/fullcalendar/uibox.css" rel="stylesheet" />--%>


    <script src="Calendar%20files/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/scripts/calendarscript.js" type="text/javascript"></script>
  
    <script src="Calendar%20files/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
        <%--<script src="Calendar%20files/fullcalendar.js"></script>--%>
    <script src="Calendar%20files/jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>
     <script src="Calendar%20files/fullcalendar.js"></script>
    <script src="Calendar%20files/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
 
    <%--<script src="Calendar%20files/fullcalendar/jquery.formbubble.js" type="text/javascript"></script>
    <script src="Calendar%20files/fullcalendar/fullcalendar.viewmore.js" type="text/javascript"></script>--%>
    <%--<link href="Calendar%20files/css/cupertino/jquery-ui-1.7.3.custom.css" rel="stylesheet" type="text/css"/>
    <link href="Calendar%20files/css/cupertino/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="Calendar%20files/fullcalendar.print.css" rel="stylesheet" />
    <script src="Calendar%20files/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/scripts/calendarscript.js" type="text/javascript"></script>
    <link href="Calendar%20files/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <script src="Calendar%20files/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/jquery/jquery-ui-1.7.3.custom.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/jquery/jquery.qtip-1.0.0-rc3.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="Calendar%20files/jquery/jquery-ui-timepicker-addon-0.6.2.min.js" type="text/javascript"></script>
 --%>
   <%-- <script type="text/javascript">
            $(document).ready(function () {
             

                $('#calendar').fullCalendar ({
                    editable: true,
                    header: {
                        left: "prev,next today",
                        center: "title",
                        right: "month,agendaWeek,agendaDay"
                    },
                    events: "Response.ashx",

                });

                //$('#calendar').limitEvents(4);

                //$('#calendar').limitEvents({
                //  maxEvents: 3,
                //  viewMoreClick: function(){
                //    alert('custom click handler fired');
                //  }
                //});

            });
    </script>--%>
    <style type='text/css'>
        body {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        }

        #calendar {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
        .form-control {}
        #addEventRName {
            width: 228px;
        }
        .auto-style1 {
            text-align: left;
            padding-bottom: 10px;
            width: 238px;
        }
        .auto-style2 {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
            width: 51px;
        }
       
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:HiddenField ID="hfUserId" runat="server" />
        <div>
        <%--<div style="margin-right:500px;" >--%>
         <%--   <div  style="margin-left: 1004px;"class="fc-header-right" >--%>
            <asp:HyperLink id="hyperlink1" ImageHeight="40" ImageWidth="40" align="left"
                  ImageUrl="Calendar%20files/home.png" 
                  NavigateUrl="index.aspx"
                Title="Go back to CRM"
                  Target="_new"
                  runat="server"/> 
           <%--     </div>--%>
        </div>
        <div>
        </div >
         <div>
            <table class="table-responsive" style="width: 65%;height:25px; margin:auto;">
                <tr >
                    <td style="background-color: #E47467!Important; width:20%;" class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable;"  ><span class="fc-task">Task</span></td>
                    <td style="background-color: rgb(138, 156, 38)!Important;width:20%;"class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable;"><span class="fc-sampling" >Event</span></td>
                    <td style="background-color: #3A87AD!Important;width:20%;"class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable;"><span class="fc-event-skin">Call</span></td>
                    <td style="background-color: #DC3636!Important;width:20%;"class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable;"><span class="fc-missed">Missed</span></td>
                    <td style="background-color: rgb(73, 204, 31)!Important;width:20%;" class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable"><span class="fc-close">Close</span></td>
                </tr>
               
            </table>
        </div>
        <br />
     <%--    <div>
              <div class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable" style="position:relative ; z-index: 8; left: 918px; height: 18px; width: 200px; top: 82px;" unselectable="on">
                <div class="fc-event-inner fc-event-skin fc-task">

                    <span class="fc-event-title">Task</span>
                </div>
            </div>
              <div class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable" style="position: absolute; z-index: 8; left: 918px; height: 18px; width: 200px; top: 82px;" unselectable="on">
                <div class="fc-event-inner fc-event-skin fc-sampling">

                    <span class="fc-event-title">Event</span>
                </div>
            </div>
              <div class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable" style="position: absolute; z-index: 8; left: 918px; height: 18px; width: 200px; top: 82px;" unselectable="on">
                <div class="fc-event-inner fc-event-skin">

                    <span class="fc-event-title">Call</span>
                </div>
            </div>
            <div class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable" style="position: absolute; z-index: 8; left: 500px; height: 18px; width: 121px; top: 55px;" unselectable="on">
                <div class="fc-event-inner fc-event-skin fc-missed">

                    <span class="fc-event-title ui-draggable">Missed</span>
                </div>
            </div>
            <div class="fc-event fc-event-skin fc-event-hori fc-event-draggable fc-corner-left fc-corner-right  ui-draggable" style="position: relative; z-index: 8; left: 918px; height: 18px; width: 200px; top: 82px;" >
                <div class="fc-event-inner fc-event-skin fc-close">

                    <span class="fc-event-title">Close</span>
                </div>
            </div>

         </div>   --%>  
        <div class="block block-alt-noborder full" id="calendar">
        </div>
        <div id="updatedialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;"
            title="Update or Delete Event">
            <table cellpadding="0" class="style1">
                <tr>
                    <td class="alignRight">Subject:</td>
                    <td class="alignLeft">
                        <%--<input id="eventName" type="text" /><br />--%>
                        <asp:DropDownList ID="eventName" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="1" Height="18px" Width="141px">
                            <asp:ListItem Value="Meeting">Meeting</asp:ListItem>
                            <asp:ListItem Value="Market Visit">Market Visit</asp:ListItem>
                            <asp:ListItem Value="Study & Research">Study & Research</asp:ListItem>
                            <asp:ListItem Value="Internal Office Work">Internal Office Work</asp:ListItem>
                            <asp:ListItem Value="Order Follow Up">Order Follow Up</asp:ListItem>
                            <asp:ListItem Value="Payment Follow Up">Payment Follow Up</asp:ListItem>
                            <asp:ListItem Value="Sampling">Sampling</asp:ListItem>
                            <asp:ListItem Value="Demonstration">Demonstration</asp:ListItem>
                            <asp:ListItem Value="Exhibition">Exhibition</asp:ListItem>
                            <asp:ListItem Value="Phone Call Inbound">Phone Call Inbound</asp:ListItem>
                            <asp:ListItem Value="Phone Call Outbound">Phone Call Outbound</asp:ListItem>
                            <asp:ListItem Value="Email">Email</asp:ListItem>
                            <asp:ListItem Value="Others">Others</asp:ListItem>

                        </asp:DropDownList>

                    </td>
                </tr>
                 <tr>
                    <td class="alignRight">Name:</td>
                    <td class="alignLeft">
                        <span id="EventRName" ></span></td>
                     <%-- <textarea id="EventRName"cols="30" rows="1"></textarea></td>--%>
                </tr>
                   <tr style="display:none;">
                    <td class="alignRight">Assign to:</td>
                    <td class="alignLeft">
                        <span id="EventAName" ></span></td>
                     <%-- <textarea id="EventRName"cols="30" rows="1"></textarea></td>--%>
                </tr>
                <tr>
                    <td class="alignRight">Description:</td>
                    <td class="alignLeft">
                        <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
                </tr>
                <tr>
                    <td class="alignRight">Start:</td>
                    <td class="alignLeft">
                        <span id="eventStart"></span></td>
                </tr>
                <tr>
                    <td class="alignRight">End: </td>
                    <td class="alignLeft">
                        <span id="eventEnd"></span>
                        <input type="hidden" id="eventId" /></td>
                </tr>
            </table>
        </div>
     <%--  <div id="addDialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;" title="Add Event">--%>
            <%--<table cellpadding="0" class="style1">
                <tr>
                    <td class="alignRight">Subject:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="addEventName" runat="server" name="example-chosen" data-toggle="tooltip" title="Task" CssClass="form-control" TabIndex="1" Height="18px" Width="141px">
                                            <asp:ListItem Value="Select Subject">Select Subject</asp:ListItem>
                                            <asp:ListItem Value="Meeting">Meeting</asp:ListItem>
                                            <asp:ListItem Value="Market Visit">Market Visit</asp:ListItem>
                                            <asp:ListItem Value="Study and Research">Study & Research</asp:ListItem>
                                            <asp:ListItem Value="Internal Office Work">Internal Office Work</asp:ListItem>
                                            <asp:ListItem Value="Order Follow Up">Order Follow Up</asp:ListItem>
                                            <asp:ListItem Value="Payment Follow Up">Payment Follow Up</asp:ListItem>
                                        </asp:DropDownList>--%>
                        <%--<input id="addEventName" type="text" size="50" /><br />--%>
                  <%--  </td>
                </tr>
                   <tr>
                    <td class="alignRight">Description:</td>
                    <td class="auto-style1">
                        <textarea id="addEventDesc" cols="30" rows="3"></textarea></td>
                </tr>
                <tr>
                 <td class="auto-style2">Related to:</td>
                    <td class="alignLeft">--%>
                        <%--<textarea id="addEventRName" cols="30" rows="1"></textarea>--%>
                       <%-- <asp:DropDownList ID="addRtype" CssClass="form-control select-chosen" runat="server" Height="18px" Width="141px">
                            <asp:ListItem Value="None">None</asp:ListItem>
                            <asp:ListItem Value="Lead">Lead</asp:ListItem>
                            <asp:ListItem Value="Prospect">Prospect</asp:ListItem>
                            <asp:ListItem Value="Account">Account</asp:ListItem>
                            <asp:ListItem Value="Opportunity">Opportunity</asp:ListItem>
                            <asp:ListItem Value="Quotation">Quotation</asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
                    <tr>
                    <td class="alignRight">Name:</td>
                    <td class="auto-style1">
                        <textarea id="addEventRName" rows="1"></textarea>
                        </td>
                </tr>
                <tr>
                    <td class="alignRight">Start:</td>
                    <td class="auto-style1">
                        <span id="addEventStartDate"></span></td>
                </tr>
                <tr>
                    <td class="alignRight">End:</td>
                    <td class="auto-style1">
                        <span id="addEventEndDate"></span></td>
                </tr>
            </table>

        </div>
        <div runat="server" id="jsonDiv" />
        <input type="hidden" id="hdClient" runat="server" />--%>

    </form>
</body>
</html>
