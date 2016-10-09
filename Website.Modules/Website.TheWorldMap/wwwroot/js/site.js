// site.js file

(function () {
    var ele = $("#username");
    ele.text("KELVIN NGUYEN");

    var main = $("#main");

    main.on("mouseenter", function () {
        main.css("background-color", "#888");
    });

    main.on("mouseleave", function () {
        main.css("background-color","");
    });

    var menuItem = $("ul.menu li a");
    menuItem.on("click", function () {
        var me = $(this);
    });
})();