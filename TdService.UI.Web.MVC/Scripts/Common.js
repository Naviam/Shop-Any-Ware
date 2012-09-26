$(document).ready(function () {
    // auto focus
    //$([]).add("input[type=text][readonly!=readonly]").add("[type=email][readonly!=readonly]").first().focus();
    // support placeholder in old browsers
    //$('input[placeholder]').placeholder();
    $('textarea[placeholder]').simplePlaceholder();
    $('input:text[placeholder]').simplePlaceholder(); // classic input[type=text]
    $('input[type="email"][placeholder]').simplePlaceholder(); // email fields input[type=email]
});

function showNotice(message, type) {
    noty({
        "text": message,
        "layout": "topCenter",
        "type": type.toLowerCase(),
        "theme": "noty_theme_twitter",
        "animateOpen": { "height": "toggle" },
        "animateClose": { "height": "toggle" },
        "speed": 900,
        "timeout": 4000,
        "closeButton": true,
        "closeOnSelfClick": true,
        "closeOnSelfOver": false,
        "modal": false
    });
}

jQuery.extend({
    json: function (url, data, success) {
        var request = $.ajax({
            url: url,
            type: 'POST',
            data: data,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        });
        request.done(success);
        // ReSharper disable InconsistentNaming
        request.fail(function (jqXHR, textStatus, errorThrown) {
            // ReSharper restore InconsistentNaming
            if (console && console.log) {
                console.log("Status: " + textStatus + " Error:", errorThrown);
            }
            if (window.showNotice) {
                window.showNotice(errorThrown, "Error");
            }
        });
    },

    jsonWithMapping: function(url, data, success) {
        $.json(url, ko.mapping.toJSON(data), success);
    },

    postWithMapping: function(url, data, success) {
        var request = $.ajax({
            type: 'POST',
            url: url,
            data: ko.toJSON(data),
            success: success
        });
        request.done(success);
        // ReSharper disable InconsistentNaming
        request.fail(function (jqXHR, textStatus, errorThrown) {
            // ReSharper restore InconsistentNaming
            if (console && console.log) {
                console.log("Status: " + textStatus + " Error:", errorThrown);
            }
            if (window.showNotice) {
                window.showNotice(errorThrown, "Error");
            }
        });
    }
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