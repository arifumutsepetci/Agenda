$('#open-modal').click(function () {
    $('#addEventModal').modal('show');
});

$('#close-modal').click(function () {
    $('#addEventModal').modal('toggle');
});

document.getElementById('event-date').valueAsDate = new Date();