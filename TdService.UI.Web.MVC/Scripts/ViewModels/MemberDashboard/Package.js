function Package(serverModel) {
    /// <summary>Package view model.</summary>
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);

    // package view model properties
    self.id = ko.observable(serverModel.Id);
    self.name = ko.observable(serverModel.Name);
    self.deliveryAddressId = ko.observable(serverModel.DeliveryAddressId);
    self.deliveryAddressName = ko.observable(serverModel.DeliveryAddressName).extend({ defaultIfNull: "not set" });
    self.dispatchMethod = ko.observable(serverModel.DispatchMethod).extend({ defaultIfNull: "not set" });
    self.createdDate = ko.observable(formatDate(serverModel.CreatedDate));
    self.dispatchedDate = ko.observable(formatDate(serverModel.DispatchedDate));
    self.deliveredDate = ko.observable(formatDate(serverModel.DeliveredDate));
    self.status = ko.observable(serverModel.Status);
    self.statusTranslated = ko.observable(serverModel.StatusTranslated);
    self.isCollapsed = ko.observable(false);

    // package view model collections
    self.items = ko.observableArray();
    self.selectedAddress = ko.observable();
    self.selectedMethod = ko.observable();

    // package state properties
    self.canBeRemoved = serverModel.CanBeRemoved;
    self.canBeModified = serverModel.CanBeModified;
    self.canItemsBeModified = serverModel.CanItemsBeModified;
    self.canBeSent = serverModel.CanBeSent;
    self.canBeDisposed = serverModel.CanBeDisposed;

    // package view model computed properties
    self.domPackageId = ko.computed(function () {
        return "package" + self.id();
    });

    self.totalItemsAmount = ko.computed(function () {
        /// <summary>Determines the total amount of items in te the package.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].price();
        }
        return total;
    });

    self.totalItemsQuantity = ko.computed(function () {
        /// <summary>Determines the total number of items in the package.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].quantity();
        }
        return total;
    });

    self.totalItemsWeight = ko.computed(function () {
        /// <summary>Determines the total weight of items in the package.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].weight();
        }
        return total;
    });

    self.packageDate = ko.computed(function () {
        switch (self.status()) {
            case 'Delivered':
                return self.deliveredDate();
            case 'Dispatched':
                return self.dispatchedDate();
            default:
                return self.createdDate();
        }
    });

    self.loadItems = ko.computed(function () {
        $.post("/items/getpackageitems", { "packageId": self.id() }, function (data) {
            var response = ko.toJS(data);
            self.items.removeAll();
            $.each(response.Items, function (index, value) {
                var item = new Item(value);
                self.items.unshift(item);
            });
        });
    });
    self.loadItems();

    self.isExpanded = ko.computed(function () {
        return !self.isCollapsed();
    });

    self.toggleCollapse = function () {
        var currentValue = self.isCollapsed();
        self.isCollapsed(!currentValue);
    };

    self.sendPackage = function (pack) {
        /// <summary>Send package.</summary>
    };

    self.getItemDetails = function (item) {
        /// <summary>Get item details.</summary>
    };

    self.addItem = function (item) {
        /// <summary>Add new item to order.</summary>
    };

    self.removeItem = function (item) {
        /// <summary>Remove item from order.</summary>
    };
}