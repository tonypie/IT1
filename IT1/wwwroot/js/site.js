(function () {
    var sidemenu = $("#side-menu,#wrapper");
    var btn = $("#btnToggleMenu");
    var icon = $("#header i.fa");

    icon.on("click", function () {
        sidemenu.toggleClass("hideMenu");
        if (sidemenu.hasClass("hideMenu")) {
            icon.removeClass("fa-chevron-circle-left");
            icon.addClass("fa-chevron-circle-right");
        }
        else {
            icon.removeClass("fa-chevron-circle-right");
            icon.addClass("fa-chevron-circle-left");
        }
    });
    

    //var btn = $("#btnToggleMenu");

    //btn.on("click", function () {
    //    sidemenu.toggleClass("hideMenu");
    //});

    //sidemenu.on("mouseenter", function () {
    //    sidemenu.css("background-color", "#888");
    //});

    //sidemenu.on("mouseleave", function () {
    //    sidemenu.css("background-color", "");
    //});

    
})();