audiojs.events.ready(function () {
    var as = audiojs.createAll({
        autoplay: true,
        autoload: "none"
    });

});

function replaceAll(str, de, para) {
    var pos = str.indexOf(de);
    while (pos > -1) {
        str = str.replace(de, para);
        pos = str.indexOf(de);
    }
    return (str);
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) {
            var rep = replaceAll(sParameterName[1], "%2F", "/");
            rep = replaceAll(rep, "%20", " ");
            return rep;
        }
    }
}
var x = getUrlParameter('path');
$('#audioPlay').attr('src', x);