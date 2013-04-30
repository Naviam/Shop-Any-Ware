var RatesViewModel = function (loadingText, errorText, deliveryUnavailableText) {
    var self = this;

    self.loadingText = loadingText;
    self.errorText = errorText;
    self.deliveryUnavailableText = deliveryUnavailableText;
    self.loadingRates = ko.observable(false);
    self.weight = ko.observable();
    self.countries = ko.observableArray();
    self.methods = ko.observableArray();
    self.methods.push({ name: "USPS Express mail", Id: 1 });
    self.methods.push({ name: "USPS Priority mail", Id: 2 });
    self.selectedMethod = ko.observable(0);
    self.selectedCountry = ko.observable(0);
    self.rate = ko.observable(0);
    self.calculatedRate = ko.computed(function () {
        if (self.loadingRates()) return self.loadingText;
        return self.rate();
    });
    $.post("/home/getCountries", function (data) {
        self.countries(data);
    });

    self.calculateRate = function () {
        if (isNaN(self.weight())) return;
        self.loadingRates(true);
        $.post("/home/CalculateRate", {
            "Weight": self.weight(),
            "CountryName": self.selectedCountry().DefaultName,
            "DeliveryMethodId": self.selectedMethod().Id
        },
            function (data) {
                var resp = ko.toJS(data);
                self.loadingRates(false);
                if (resp.Error != null) {
                    self.rate(self.errorText);
                    return
                }
                if (resp.Rate == null) {
                    self.rate(self.deliveryUnavailableText);
                    return;
                }
                self.rate("$" + resp.Rate);
            });
    };
}