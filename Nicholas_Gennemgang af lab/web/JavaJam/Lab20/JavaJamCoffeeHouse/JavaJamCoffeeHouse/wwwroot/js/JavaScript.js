var obj = document.getElementsByClassName("menu");
for (i = 0; i < obj.length; i++) {
    obj[i].addEventListener("mouseover", function (event) {
        var target = event.target || event.srcElement;
        target.className = "menuEnhanced";

    });
    obj[i].addEventListener("mouseout", function (event) {
        var target = event.target || event.srcElement;
        target.className = "menu";
    });
}
;