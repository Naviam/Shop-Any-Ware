var RatesViewModel = function (loadingText, errorText) {
    var self = this;

    self.loadingText = loadingText;
    self.errorText = errorText;
    self.loadingRates = ko.observable(false);
    self.weight = ko.observable();
    self.amount = ko.observable();
    self.countries = ko.observableArray();
    self.methods = ko.observableArray();
    self.methods.push({ name: "USPS Express mail", Id: 1 });
    self.methods.push({ name: "USPS Priority mail", Id: 2 });
    self.selectedMethod = ko.observable(0);
    self.selectedCountry = ko.observable(0);
    self.rate = ko.observable(0);
    self.calculatedRate = ko.computed(function() {
        if (self.loadingRates()) return self.loadingText;
        return self.rate();
    });
    $.post("/home/getCountries", function (data) {
        var resp = ko.toJS(data);
        $.each(resp, function (index, value) {
            self.countries.push({ TranslatedName: value.TranslatedName, DefaultName: value.DefaultName });
        });
    });

    self.calculateRate = function () {
        if (isNaN(self.amount()) || isNaN(self.weight())) return;
        self.loadingRates(true);
        $.post("/home/CalculateRate", {
            "Weight": self.weight(),
            "Amount": self.amount(),
            "CountryName": self.selectedCountry().DefaultName,
            "DeliveryMethodId": self.selectedMethod().Id},
            function (data) {
                var resp = ko.toJS(data);
                self.loadingRates(false);
                if (resp.Error != '') {
                    self.rate(self.errorText);
                }
                else {
                    self.rate('$'+resp.Rate);
                }
            });
    };
}