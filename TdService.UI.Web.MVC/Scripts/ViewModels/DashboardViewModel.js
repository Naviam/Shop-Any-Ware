/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />

ko.extenders.defaultIfNull = function (target, defaultValue) {
    var result = ko.computed({
        read: target,
        write: function (newValue) {
            if (!newValue) {
                target(defaultValue);
            } else {
                target(newValue);
            }
        }
    });
    result(target());
    return result;
};

function Item(serverModel) {
    /// <summary>Item view model.</summary>
    var self = this;

    // item view model properties
    self.price = ko.observable(serverModel.Price);
}

function Order(serverModel) {
    /// <summary>Order view model.</summary>
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);

    // order view model properties
    self.id = ko.observable(serverModel.Id);
    self.retailerUrl = ko.observable(serverModel.RetailerUrl);
    self.orderNumber = ko.observable(serverModel.OrderNumber).extend({ defaultIfNull: "not set" });
    self.trackingNumber = ko.observable(serverModel.TrackingNumber).extend({ defaultIfNull: "not set" });
    self.createdDate = ko.observable(serverModel.CreatedDate);
    self.receivedDate = ko.observable(serverModel.ReceivedDate);
    self.status = ko.observable(serverModel.Status);

    // order view model computed properties
    self.totalAmount = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items[i].price;
        }
        return total;
    });

    // order view model collections
    self.items = ko.observableArray();

    // order state properties
    self.canBeRemoved = serverModel.CanBeRemoved;
    self.canBeModified = serverModel.CanBeModified;
    self.canItemsBeModified = serverModel.CanItemsBeModified;
    self.canBeRequestedForReturn = serverModel.CanBeRequestedForReturn;

    self.getItemDetails = function(item) {
        /// <summary>Get item details.</summary>
    };

    self.addItem = function(item) {
        /// <summary>Add new item to order.</summary>
    };

    self.removeItem = function(item) {
        /// <summary>Remove item from order.</summary>
    };
}

function Retailer(serverModel) {
    var self = this;
    

}

function DashboardViewModel(serverModel) {
    /// <summary>Dashboard view model. The parent model for others.</summary>
    var self = this;

    // default model properties
    // self.message = ko.observable(serverModel.Message);
    // self.messageType = ko.observable(serverModel.MessageType);
    // self.errorCode = ko.observable(serverModel.ErrorCode);

    // dashboard view model properties
    self.newOrderField = ko.observable();
    self.newPackageField = ko.observable();

    // dashboard view model collections
    self.orders = ko.observableArray();
    self.packages = ko.observableArray();
    self.retailers = ko.observableArray();

    self.shouldShowOrdersEmptyMessage = ko.computed(function () {
        /// <summary>Determines whether no orders message should be displayed.</summary>
        return self.orders().length == 0;
    });

    self.suggestRetailers = function() {
        /// <summary>Load shops from db to autosuggest them for user.</summary>
        $.post("/tdservice/retailers/suggest", { "searchText": self.newOrderField() }, function (data) {
            var retailers = ko.toJS(data);
            self.retailers.removeAll();
            $.each(retailers, function (index, value) {
                var retailer = new Retailer(value);
                self.retailers.unshift(order);
            });
        });
    };

    self.getRecentOrders = function() {
        /// <summary>Load recent orders from server.</summary>
        $.post("/tdservice/orders/recent", function (data) {
            var orders = ko.toJS(data);
            self.orders.removeAll();
            $.each(orders, function(index, value) {
                var order = new Order(value);
                self.orders.unshift(order);
            });
        });
    };
    self.getRecentOrders();

    self.createOrder = function() {
        /// <summary>Add new order.</summary>
        if (self.newOrderField() != "") {
            $.post("/tdservice/orders/add", { "retailerUrl": self.newOrderField() }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var order = new Order(model);
                    self.newOrderField("");
                    self.orders.unshift(order);
                    window.showNotice(data.Message, data.MessageType);
                }
            });
        }
        // show error message
    };

    self.removeOrder = function(order) {
        /// <summary>Remove order.</summary>
        $.post("/tdservice/orders/remove", { "orderId": order.id }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                self.orders.remove(order);
                window.showNotice(data.Message, data.MessageType);
            }
        });
    };

    self.getRecentPackages = function () {
        /// <summary>Load recent packages from server.</summary>
    };

    self.getPackageHistory = function (recordsToShow) {
        /// <summary>Load history of packages.</summary>
    };

    self.createPackage = function(packageName) {
        /// <summary>Create package.</summary>
    };

    self.removePackage = function(packageId) {
        /// <summary>Remove package.</summary>
    };
}