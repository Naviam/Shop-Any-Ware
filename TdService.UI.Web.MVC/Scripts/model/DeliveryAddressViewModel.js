function DeliveryAddress() {
    var self = this;
    self.id = ko.observable(0);
    self.firstName = ko.observable("");
    self.lastName = ko.observable("");
    self.addressName = ko.observable("");
    self.country = ko.observable("");
    self.region = ko.observable("");
    self.city = ko.observable("");
    self.addressLine1 = ko.observable("");
    self.addressLine2 = ko.observable("");
    // self.address3 = ko.observable("");
    self.zipCode = ko.observable("");
    self.phone = ko.observable("");

    self.addDeliveryAddress = function () {
        /// <summary>Add new delivery address.</summary>
        if ($("form").valid()) {
            $.post("Address/Add", $("form").serialize(),
                function (data, textStatus, jqXhr) {
                    self.notify(data.Message, data.MessageType);
                    if (data.MessageType != "error") {
                        window.deliveryAddressViewModel.addressBook.unshift(self);
                    }
                }
            );
        }
    };

    self.notify = function (message, type) {
        /// <summary>Notify with the message of a particular type (error, success, warning).</summary>
        noty({
            "text": message,
            "layout": "topCenter",
            "type": type,
            "theme": "noty_theme_twitter",
            "animateOpen": { "height": "toggle" },
            "animateClose": { "height": "toggle" },
            "speed": 500,
            "timeout": 5000,
            "closeButton": false,
            "closeOnSelfClick": true,
            "closeOnSelfOver": false,
            "modal": false
        });
    };
};

var DeliveryAddressViewModel = function (modelParam) {
    /// <summary>
    ///     View model that describes delivery addresses page behavior.
    /// </summary>
    /// <param name="modelParam" type="Object">
    ///     Optional model with initial data.
    /// </param>
    var model = JSON.parse(modelParam);
    var self = this;

    self.ar = new Array();
    for (var i = 0; i < model.length; i++) {
        var currentNode = model[i];
        var address = new DeliveryAddress();
        address.addressName = currentNode.AddressName;
        address.firstName = currentNode.FirstName;
        address.lastName = currentNode.LastName;
        address.zipCode = currentNode.ZipCode;
        address.phone = currentNode.Phone;
        address.state = currentNode.State;
        address.city = currentNode.City;
        address.country = currentNode.Country;
        address.addressLine1 = currentNode.AddressLine1;
        address.addressLine2 = currentNode.AddressLine2;
        address.region = currentNode.Region;
        self.ar.push(address);
    }
    self.addressBook = ko.observableArray(self.ar);

    self.showEditAddressModalWindow = function () {
        /// <summary>Show edit delivery address modal window.</summary>
        self.notify("show edit form", "success");
    };

    self.editDeliveryAddress = function () {
        /// <summary>Edit delivery address.</summary>
        self.notify("edit delivery address", "success");
    };

    self.removeDeliveryAddress = function (address) {
        /// <summary>Remove delivery address.</summary>
        var a = address;
        self.notify("remove delivery address", "success");
    };

    self.notify = function (message, type) {
        /// <summary>Notify with the message of a particular type (error, success, warning).</summary>
        noty({
            "text": message,
            "layout": "topCenter",
            "type": type,
            "theme": "noty_theme_twitter",
            "animateOpen": { "height": "toggle" },
            "animateClose": { "height": "toggle" },
            "speed": 500,
            "timeout": 5000,
            "closeButton": false,
            "closeOnSelfClick": true,
            "closeOnSelfOver": false,
            "modal": false
        });
    };
};