function DeliveryRatesViewModel() {
    var self = this;

    self.country = ko.observable();
    self.deliveryMethod = ko.observable();
    self.weight = ko.observable();
    self.amount = ko.observable();

    self.getRates = function(form) {
        var params = ko.toJS(form);
        jQuery.post("", params, function(data) {
            var m = ko.toString(data);
            self.amount(m);
        });
    };
}