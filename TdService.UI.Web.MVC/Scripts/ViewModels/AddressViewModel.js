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
    self.Id = ko.observable(address.Id);
    self.FirstName = ko.observable(address.FirstName);
    self.LastName = ko.observable(address.LastName);
    self.AddressName = ko.observable(address.AddressName);
    self.AddressLine1 = ko.observable(address.AddressLine1);
    self.AddressLine2 = ko.observable(address.AddressLine2);
    self.City = ko.observable(address.City);
    self.Country = ko.observable(address.Country);
    self.Region = ko.observable(address.Region);
    self.State = ko.observable(address.State);
    self.ZipCode = ko.observable(address.ZipCode);
    self.Phone = ko.observable(address.Phone);

    self.addressId = ko.computed(function() {
        return "address_" + self.Id();
    });
    
    self.addressIdWithNumberSign = ko.computed(function () {
        return "#" + self.addressId();
    });
};

var AddressViewModel = function () {
    var self = this;

    // own properties
    self.addressBook = ko.observableArray();
    self.addressesLoaded = ko.observable(false);

    self.addAddressModel = ko.observable(new DeliveryAddress({ Id: 0 }));

    self.loadAddresses = function() {
        $.post("/address/get", function (data) {
            var collection = ko.toJS(data);
            self.addressBook.removeAll();
            $.each(collection, function (index, value) {
                var deliveryAddress = new DeliveryAddress(value);
                self.addressBook.unshift(deliveryAddress);
            });
            self.addressesLoaded(true);
        });
    };
    self.loadAddresses();

    self.update = function (deliveryAddress) {
        $.post("/address/update", ko.toJS(deliveryAddress), function (data) {
            window.showNotice(data.Message, data.MessageType);
        });
    };

    self.add = function (deliveryAddress) {
        var param = deliveryAddress;
        $.post("/address/add", ko.toJS(deliveryAddress), function (data) {
            var result = ko.toJS(data);
            self.addAddressModel(new DeliveryAddress({ Id: 0 }));
            if (result.MessageType == "Success") {
                var address = new DeliveryAddress(result);
                self.addressBook.unshift(address);
                $("#addDeliveryAddressModel").modal('hide');
            }

            $.each(result.BrokenRules, function(index, value) {
                var rule = value;
                param[rule.Property].extend({ displayBrokenRule: rule });
                result.Message = result.Message + rule.ErrorCode + "<br/>";
            });
            
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