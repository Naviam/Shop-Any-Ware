$(document).ready(function () {
    $([]).add("input[type=text][readonly!=readonly]").add("[type=email][readonly!=readonly]").first().focus();
});

function showNotice(message, type) {
    noty({
        "text": message,
        "layout": "topCenter",
        "type": type.toLowerCase(),
        "theme": "noty_theme_twitter",
        "animateOpen": { "height": "toggle" },
        "animateClose": { "height": "toggle" },
        "speed": 500,
        "timeout": 8000,
        "closeButton": true,
        "closeOnSelfClick": true,
        "closeOnSelfOver": false,
        "modal": false
    });
}