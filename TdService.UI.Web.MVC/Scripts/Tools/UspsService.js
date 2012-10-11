jQuery.extend({
    uspsTrackPackage: function (userId, trackingNumber, success) {
        var data = 'API=TrackV2&XML=<TrackRequest USERID="852TRADE0543"><TrackID ID="EJ958083578US"></TrackID></TrackRequest>';
        var request = $.ajax({
            url: "http://production.shippingapis.com/ShippingAPITest.dll",
            type: 'GET',
            crossDomain: true,
            data: data,
            dataType: 'xml'
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

    jsonWithMapping: function (url, data, success) {
        $.json(url, ko.mapping.toJSON(data), success);
    }
});