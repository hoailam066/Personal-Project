jQuery(function ($) {
    //$(".tbl tr:has(td)").css({ background: "ffffff" }).hover(
    //    function () { $(this).css({ background: "#C1DAD7" }); },
    //    function () { $(this).css({ background: "#ffffff" }); }
    //    );
    $(".tbl td").bind("click", function () {
        var row = $(this).parent();
        $(".tbl tr").each(function () {
            if ($(this)[0] != row[0]) {
                $("td", this).removeClass("selected_row");
            }
        });
        $("td", row).each(function () {
            if (!$(this).hasClass("selected_row")) {
                $(this).addClass("selected_row");
            } else {
                $(this).removeClass("selected_row");
            }
        });
    });
});