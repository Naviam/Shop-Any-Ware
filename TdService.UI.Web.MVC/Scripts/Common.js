$(document).ready(function () {
    $([]).add("input[type=text][readonly!=readonly]").add("[type=email][readonly!=readonly]").first().focus();
});

function createCookie(name, value, days) {
    var expires;
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toGMTString();
    }
    else {
        expires = "";
    }
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEq = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEq) == 0) return c.substring(nameEq.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function changeCulture(culture) {
    /// <summary>Change web site language.</summary>
    var cultureCookie = readCookie("culture");
    if (cultureCookie != null) {
        eraseCookie("culture");
    }
    createCookie("culture", culture, 240);
    window.location.reload();
};

function showNotice(message, type) {
    noty({
        "text": message,
        "layout": "topCenter",
        "type": type.toLowerCase(),
        "theme": "noty_theme_twitter",
        "animateOpen": { "height": "toggle" },
        "animateClose": { "height": "toggle" },
        "speed": 500,
        "timeout": 4000,
        "closeButton": true,
        "closeOnSelfClick": true,
        "closeOnSelfOver": false,
        "modal": false
    });
}