var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function updateEvent(event, element) {
    //alert(event.description);

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $('#updatedialog').dialog('open');
    debugger;
    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#eventId").val(event.id);
    $("#eventStart").text("" + event.start.toLocaleString());
    $("#EventRName").text("" + event.Rname.toLocaleString());
    $("#EventAName").text("" + event.Aname.toLocaleString());
    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }

}

function updateSuccess(updateResult) {
    //alert(updateResult);
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
}

function addSuccess(addResult) {
// if addresult is -1, means event was not added
    //    alert("added key: " + addResult);
    debugger;

    if (addResult != -1) {
        $('#calendar').fullCalendar('renderEvent',
            
						{
                            
						    title: $("#addEventName").val(),
						    start: addStartDate,
						    end: addEndDate,
						    Activity_Id: addResult,
						    description: $("#addEventDesc").val(),
						    Rname: $("#addEventRName").val(),
						    //Aname: $("#addEventAName").val(),
						    allDay: globalAllDay
						},
						true // make the event "stick"
					);


        $('#calendar').fullCalendar('unselect');
    }

}

function UpdateTimeSuccess(updateResult) {
    //alert(updateResult);
}


function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');


    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());


    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);

}

function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        Activity_Id: event.id,
        start: event.start

    };

    if (allDay) {
        eventToUpdate.start.setHours(0, 0, 0);

    }

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;

    }
    else {
        eventToUpdate.end = event.end;
        if (allDay) {
            eventToUpdate.end.setHours(0, 0, 0);
        }
    }

    eventToUpdate.start = eventToUpdate.start.format("dd-MM-yyyy hh:mm:ss tt");
    eventToUpdate.end = eventToUpdate.end.format("dd-MM-yyyy hh:mm:ss tt");

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);

}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event, allDay);



}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);

}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck); 
}

$(document).ready(function() {
    debugger;
    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Update": function () {
                debugger;
                //alert(currentUpdateEvent.title);
                var eventToUpdate = {
               
                    Activity_Id: currentUpdateEvent.id,
                    Activity_Subject: $("#eventName").val(),
                    Activity_Description: $("#eventDesc").val(),
                    Activity_RelatedTypeID: $("#EventRName").val(),
                    Assign_To: $("#EventAName").val()
                };

                if ( checkForSpecialChars(eventToUpdate.description)) {
                    alert("Please enter characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                    $(this).dialog("close");
                    debugger;
                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    //currentUpdateEvent.Rname.toLocaleString() = $("#EventRName").val();
                    //currentUpdateEvent.Rname= $("#EventRName").text("" + event.Rname.toLocaleString());
                    //currentUpdateEvent.Rname = $("#EventRName").val();
                    //currentUpdateEvent.Aname = $("#EventAName").val();
                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "Delete": function() {

                if (confirm("Are you sure you want to delete this event?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }

            }

        }
    });

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Add": function () {
                debugger;

                //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    Activity_Subject: $("#addEventName").val(),
                    Activity_Description: $("#addEventDesc").val(),
                    //Activity_RelatedTypeID:$("#addEventRName").val(),
                    start: addStartDate.format("dd-MM-yyyy hh:mm:ss tt"),
                    end: addEndDate.format("dd-MM-yyyy hh:mm:ss tt")

                };

                if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                    alert("Please enter only characters: A to Z, a to z, 0 to 9, spaces");
                }
                else {
                    //alert("sending " + eventToAdd.title);

                    PageMethods.addEvent(eventToAdd, addSuccess);
                    $(this).dialog("close");
                }

            }

        }
    });


    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    debugger;
    var calendar = $('#calendar').fullCalendar({
        
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: true,
        eventLimit: true,
        views: {
            agenda: {
                eventLimit: 4 // adjust to 6 only for agendaWeek/agendaDay
            }
        },
        events: "Response.ashx",
        eventLimitText: "Something",
        eventDrop: eventDropped,
        eventResize: eventResized,

        eventRender: function (event, element, view) {

            //test
            //{
            //    if (event.title = 'Market Visit') {
            //        debugger;
            //        // countevents = countevents + allevents.length;
            //        //backgroundColor: '#red';
            //        //eventColor: '#378006';
            //        //eventColor: '#378006';
            //        //$("#calendar").addClass("fc-greenEvent");
            //        color: 'black'
            //    }
            //    else if (event.title = 'Market Visit') {
            //        element.css['event', 'fc-greenEvent'];

            //    }

            //    else if (event.title === 'Market Visit') {
            //        // event.color = "#77DD77"; //Concluído OK
            //        element.css('background-color', '#00FF00');
            //    }
            //    else if (event.title = 'Market Visit') {
            //        element.css('fc-greenEvent');

            //    }
            //    else if (event.title = 'Market Visit') {
            //        element.css('fc-greenEvent', '#00FF00');

            //    }
            //}
            //tesat
            //alert(event.title);
            element.qtip({
//                content: { content: 'event.Rname', content: 'event.Aname' },
                //content: {'event.Rname',tooltip:'event.Aname' },
                content: event.Rname,
                position: { corner: { tooltip: 'bottomLeft', target: 'topRight'} }, 
                style: {
                    border: {
                        width: 1,
                        radius: 3,
                        color: '#2779AA'

                    },
                    padding: 10,
                    textAlign: 'center',
                    tip: true, // Give it a speech bubble tip with automatic corner detection
                    name: 'blue' // Style it according to the preset 'cream' style
                }

            });
        }

        //test
        //eventAfterRender: function (event, element,view) {
        //    //{
        //        if (event.title = 'Market Visit') {
        //            debugger;
        //            // countevents = countevents + allevents.length;
        //            //backgroundColor: '#red';
        //            //eventColor: '#378006';
        //            //eventColor: '#378006';
        //            $("event").addClass("fc-greenEvent");
                   
        //          //  color: 'black'
        //        }
        //test
            //    else if (event.title = 'Market Visit') {
            //        element.css['event', 'fc-greenEvent'];

            //    }

            //    else if (event.title === 'Market Visit') {
            //        // event.color = "#77DD77"; //Concluído OK
            //        element.css('background-color', '#00FF00');
            //    }
            //    else if (event.title = 'Market Visit') {
            //        element.css('fc-greenEvent');

            //    }
            //    else if (event.title = 'Market Visit') {
            //        element.css('fc-greenEvent', '#00FF00');

            //    }
            //}
    //    eventAfterRender: function (event,element,view) {
    //        debugger;
    //        //var allevents = $('#calendar').fullCalendar();
        
       
    //        if (event.title = Market) {
              
    //       // countevents = countevents + allevents.length;
    //        backgroundColor: '#red';
    //        eventColor: '#378006';
    //    }
    //    else if (event.title === 'Market Visit') {
    //              event.color = "#77DD77"; //Concluído OK
    //            element.css('background-color', '#77DD77');
    //           }
        
    //}
    //    eventAfterRender: function (event, element, view) {
    //        debugger;
    //        var dataHoje = new Date();
      
    //        if (event.start < dataHoje && event.end > dataHoje) {
    //            //event.color = "#FFB347"; //Em andamento
    //            element.css('background-color', '#FFB347');
    //        } else if (event.start < dataHoje && event.end < dataHoje) {
    //            //event.color = "#77DD77"; //Concluído OK
    //            element.css('background-color', '#77DD77');
    //        }
    //        else if (event.title ="Market Visit" && ) {
    //            //event.color = "#77DD77"; //Concluído OK
    //            element.css('background-color', '#77DD77');
    //        } else if (event.start > dataHoje && event.end > dataHoje) {
    //            //event.color = "#AEC6CF"; //Não iniciado
    //            element.css('background-color', '#AEC6CF');
    //        }
    //    }

   });

});

