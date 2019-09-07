var FeedContorller = function (attendenceService) {
    var button;
    var init = function (container) {
        //$(".js-toggle-attendence").click(toggleAttendence);
        $(container).on("click", ".js-toggle-attendence", toggleAttendence)
    };

    var toggleAttendence = function (e) {
        button = $(e.target);
        var tourId = button.attr("data-tour-id")
        if (button.hasClass("btn-default")) {
            attendenceService.createAttendence(tourId, done, fail);
        }
        else {
            attendenceService.deleteAttendence(tourId, done, fail);
        }
    };

    var done = function () {
        var text = (button.text() == "Going") ? "Going?" : "Going";
        button.toggleClass("btn-info").toggleClass("btn-default").text();
    };
    var fail = function () {
        alert("Something failed");
    };

    return {
        init: init
    }

}(AttendenceService);