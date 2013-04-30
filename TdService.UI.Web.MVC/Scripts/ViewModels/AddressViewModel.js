ko.extenders.displayBrokenRule = function (target, brokenRule) {
    //add some sub-observables to our observable
    target.hasError = ko.observable();
    target.validationMessage = ko.observable();

    //define a function to do validation
    function validate(newValue) {
        target.hasError(newValue ? false : true);
        target.validationMessage(newValue ? "" : brokenRule.ErrorCode);
    }

    //initial validation
    validate(target());

    //validate whenever the value changes
    target.subscribe(validate);

    //return the original observable
    return target;
};


var DeliveryAddress = function (address) {
    /// <summary>
    ///     View model that describes delivery address behavior.
    /// </summary>
    /// <param name="model" type="Object">
    ///     Optional model with initial data.
    /// </param>
    //var address = JSON.parse(unescape(model));
    var self = this;
    if (address.Id != 0) {
        self.Id = ko.observable(address.Id);
        self.FirstName = ko.observable(address.FirstName);
        self.LastName = ko.observable(address.LastName);
        self.AddressName = ko.observable(address.AddressName);
        self.AddressLine1 = ko.observable(address.AddressLine1);
        self.AddressLine2 = ko.observable(address.AddressLine2);
        self.City = ko.observable(address.City);
        self.CountryNameTranslated = ko.observable(address.CountryNameTranslated);
        self.CountryId = ko.observable(address.CountryId);
        self.Region = ko.observable(address.Region);
        self.State = ko.observable(address.State);
        self.ZipCode = ko.observable(address.ZipCode);
        self.Phone = ko.observable(address.Phone);
    }
    else {
        self.Id = ko.observable(address.Id);
        self.FirstName = ko.observable('');
        self.LastName = ko.observable('');
        self.AddressName = ko.observable('');
        self.AddressLine1 = ko.observable('');
        self.AddressLine2 = ko.observable('');
        self.City = ko.observable('');
        self.CountryId = ko.observable('');
        self.CountryId = ko.observable('');
        self.Region = ko.observable('');
        self.State = ko.observable('');
        self.ZipCode = ko.observable('');
        self.Phone = ko.observable('');
    }

    self.SelectedCountry = ko.observable();
    
    self.addressId = ko.computed(function() {
        return "address_" + self.Id();
    });
    self.addressFormId = ko.computed(function () {
        return "form_" + self.addressId();
    });
    self.addressIdWithNumberSign = ko.computed(function () {
        return "#" + self.addressId();
    });

    self.getPlainObject = function() {
        var result =  {
            Id: self.Id(),
            FirstName: self.FirstName(),
            LastName: self.LastName(),
            AddressName: self.AddressName(),
            AddressLine1: self.AddressLine1(),
            AddressLine2: self.AddressLine2(),
            City: self.City(),
            CountryId: self.CountryId(),
            Region: self.Region(),
            State: self.State(),
            ZipCode: self.ZipCode(),
            Phone: self.Phone()
        };
        return result;
    };
};

var AddressViewModel = function () {
    var self = this;

    // own properties
    self.addressBook = ko.observableArray();
    self.countries = ko.observableArray();
    $.post("/home/getCountries", function (data) {
        self.countries(data);
    });

    self.addressesLoaded = ko.observable(false);

    self.addAddressModel = ko.observable(new DeliveryAddress({ Id: 0 }));

    $("#addDeliveryAddressModel").on("hidden", function() {
        // clean up form
        self.addAddressModel(new DeliveryAddress({ Id: 0 }));
    });

    self.loadAddresses = function() {
        $.post("/address/get", function (data) {
            var collection = ko.toJS(data);
            self.addressBook.removeAll();
            $.each(collection, function (index, value) {
                var deliveryAddress = new DeliveryAddress(value);
                self.addressBook.unshift(deliveryAddress);
                $(deliveryAddress.addressIdWithNumberSign()).on("hidden", function () {
                    // reload the list of addresses
                    self.loadAddresses();
                });
            });
            self.addressesLoaded(true);
        });
    };
    self.loadAddresses();

    self.update = function (deliveryAddress) {
        var form = $("#" + deliveryAddress.addressFormId());
        $.post("/address/update", deliveryAddress.getPlainObject(), function (data) {
            var result = ko.toJS(data);
            var address = new DeliveryAddress(result);
            if (result.MessageType == "Success") {
                $(deliveryAddress.addressIdWithNumberSign()).modal('hide');
            }

            if (data.BrokenRules !== undefined && data.BrokenRules != null) {
                var container = form.find("[data-valmsg-summary=true]");
                var list = container.find("ul");

                if (list && list.length && data.BrokenRules.length) {
                    list.empty();
                    container.addClass("validation-summary-errors").removeClass("validation-summary-valid");

                    $.each(data.BrokenRules, function () {
                        $("<li />").html(this.Rule).appendTo(list);
                    });
                }
            }
            window.showNotice(data.Message, data.MessageType);
        });
    };

    self.add = function (deliveryAddress) {
        //sorry for that
        deliveryAddress.CountryId(deliveryAddress.SelectedCountry().Id);
        $.post("/address/add", deliveryAddress.getPlainObject(), function (data) {
            var result = ko.toJS(data);
            if (result.MessageType == "Success") {
                var address = new DeliveryAddress(result);
                self.addressBook.unshift(address);
                $("#addDeliveryAddressModel").modal('hide');
            }

            if (data.BrokenRules !== undefined && data.BrokenRules != null) {
                var container = $("#addAddressForm").find("[data-valmsg-summary=true]");
                var list = container.find("ul");

                if (list && list.length && data.BrokenRules.length) {
                    list.empty();
                    container.addClass("validation-summary-errors").removeClass("validation-summary-valid");

                    $.each(data.BrokenRules, function () {
                        $("<li />").html(this.Rule).appendTo(list);
                    });
                }
            }
            window.showNotice(result.Message, data.MessageType);
        });
    };

    self.remove = function (deliveryAddress) {
        $.post("/address/remove", { 'addressId': deliveryAddress.Id() }, function (data) {
            var result = ko.toJS(data);
            if (result.MessageType == "Success") {
                self.addressBook.remove(deliveryAddress);
            }
            window.showNotice(data.Message, data.MessageType);
        });
    };
};