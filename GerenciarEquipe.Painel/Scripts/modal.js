$(function () {
    $(".remove").click(function () {
        event.stopImmediatePropagation();
        event.preventDefault();
        var md = $(this).attr('href');
        var options = { "backdrop": "static" };
        $("#modal").load(md, function () {
            $("#modal").modal(options);
            $("#modal").show();
        });
    });
})
