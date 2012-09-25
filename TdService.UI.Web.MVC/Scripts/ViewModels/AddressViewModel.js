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

    self.add = function(deliveryAddress) {
        window.deliveryAddressViewModel.add(deliveryAddress);
    };

    self.update = function (deliveryAddress) {
        $.post("/address/update", ko.toJSON(deliveryAddress), function (data) {
            window.showNotice(data.Message, data.MessageType);
        });
    };
};

var AddressViewModel = function () {
    var self = this;

    // own properties
    self.addressBook = ko.observableArray();

    self.loadAddresses = function() {
        $.post("/address/get", function (data) {
            var collection = ko.toJS(data);
            self.addressBook.removeAll();
            $.each(collection, function (index, value) {
                var deliveryAddress = new DeliveryAddress(value);
                self.addressBook.unshift(deliveryAddress);
            });
        });
    };
    self.loadAddresses();

    self.add = function (deliveryAddress) {
        $.jsonWithMapping("/address/add", deliveryAddress, function (data) {
            var result = ko.toJS(data);
            if (result.MessageType == "Success") {
                var address = new DeliveryAddressViewModel(result);
                self.addressBook.unshift(address);
            }
            window.showNotice(data.Message, data.MessageType);
        });
    };

    self.remove = function (deliveryAddress) {
        $.jsonWithMapping("/address/remove", deliveryAddress.id, function (data) {
            var result = ko.toJS(data);
            if (result.MessageType == "Success") {
                var address = new DeliveryAddressViewModel(result);
                self.addressBook.remove(address);
            }
            window.showNotice(data.Message, data.MessageType);
        });
    };
};