$(document).ready(function () {
    $([]).add("input[type=text][readonly!=readonly]").add("[type=email][readonly!=readonly]").first().focus();
});