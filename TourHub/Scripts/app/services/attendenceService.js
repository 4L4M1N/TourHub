var AttendenceService = function () {
    var createAttendence = function (tourId, done, fail) {
        $.post("/api/attendences", { tourId: tourId })
            .done(done)
            .fail(fail);
    };
    var deleteAttendence = function (tourId, done, fail) {
        $.ajax({
            url: "/api/attendences" + tourId,
            method: "DELETE"
        })
            .done(done)
            .fail(fail);
    };
    return {
        createAttendence: createAttendence,
        deleteAttendence: deleteAttendence
    }
}();