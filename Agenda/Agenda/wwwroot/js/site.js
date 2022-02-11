$('#open-modal').click(function () {
    $('#addEventModal').modal('show');
});

$('#close-modal').click(function () {
    $('#addEventModal').modal('toggle');
});

document.getElementById('event-date').valueAsDate = new Date();

$(document).ready(function () {
    let IsEventAddedSuccessfully = $('#IsEventAddedSuccessfully').val();
    if (IsEventAddedSuccessfully != '' && IsEventAddedSuccessfully != null) {
        toastr.options.fadeOut = 150;
        toastr.options.fadeIn = 150;
        toastr.options.positionClass = "toast-bottom-right"
        if (IsEventAddedSuccessfully == "True") {
            toastr.success("The event is added successfully!", "", { timeOut: 2000 })
        }
        else if (IsEventAddedSuccessfully == "False")
            toastr.error("An error has occurred.", "", { timeOut: 2000 })
    }
});

$('#done-event-button').click(function () {
    let selected = [];
    $('input:checked').each(function () {
        selected.push($(this).attr('id'));
    });

    $.post("Home/DoEvents", { 'eventIdArray[]': selected }, function (response) {
        if (response.result == 'Redirect') {
            toastr.options.fadeOut = 150;
            toastr.options.positionClass = "toast-bottom-right";
            toastr.success(
                "The selected events are marked as completed! You will be redirected.",
                "",
                {
                    timeOut: 100,
                    onHidden: function () {
                        window.location.replace(response.url);
                    }
                }
            )
        }
    })
});