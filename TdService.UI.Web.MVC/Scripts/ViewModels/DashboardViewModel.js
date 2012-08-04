/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />
/// <reference path="../knockout.validation.debug.js" />
/// <reference path="../knockout-sortable.js" />

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

ko.bindingHandlers.executeOnEnter = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var allBindings = allBindingsAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                allBindings.executeOnEnter.call(viewModel);
                return false;
            }
            return true;
        });
    }
};

function Item(serverModel) {
    /// <summary>Item view model.</summary>
    var self = this;

    // item view model properties
    self.price = ko.observable(0);
}

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
    self.deliveryAddressName = ko.observable(serverModel.deliveryAddressName).extend({ defaultIfNull: "not set" });
    self.dispatchMethod = ko.observable(serverModel.DispatchMethod).extend({ defaultIfNull: "not set" });
    self.createdDate = ko.observable(serverModel.CreatedDate);
    self.dispatchedDate = ko.observable(serverModel.DispatchedDate);
    self.deliveredDate = ko.observable(serverModel.DeliveredDate);
    self.status = ko.observable(serverModel.Status);

    // package view model collections
    self.items = ko.observableArray();

    // package state properties
    self.canBeRemoved = serverModel.CanBeRemoved;
    self.canBeModified = serverModel.CanBeModified;
    self.canItemsBeModified = serverModel.CanItemsBeModified;
    self.canBeSent = serverModel.CanBeSent;
    self.canBeDisposed = serverModel.CanBeDisposed;

    // order view model computed properties
    self.totalItemsAmount = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items[i].price;
        }
        return total;
    });
    self.packageItemsId = ko.computed(function () {
        /// <summary>This id is used for collapse / expand feature.</summary>
        return 'package_items_' + self.id().toString();
    });
    self.packageItemsIdWithNumberSign = ko.computed(function () {
        /// <summary>This id is used for collapse / expand feature.</summary>
        return '#' + self.packageItemsId();
    });

    self.sendPackage = function(pack) {
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

    // order view model collections
    self.items = ko.observableArray();

    // order state properties
    self.canBeRemoved = serverModel.CanBeRemoved;
    self.canBeModified = serverModel.CanBeModified;
    self.canItemsBeModified = serverModel.CanItemsBeModified;
    self.canBeRequestedForReturn = serverModel.CanBeRequestedForReturn;

    // order view model computed properties
    self.totalItemsAmount = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items[i].price;
        }
        return total;
    });

    self.orderDate = ko.computed(function() {
        return self.receivedDate() == null ? self.createdDate() : self.receivedDate();
    });
    
    self.orderItemsId = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        return 'order_items_' + self.id().toString();
    });
    
    self.orderItemsIdWithNumberSign = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        return '#' + self.orderItemsId();
    });

    self.loadItems = function() {
        /// <summary>Get collection of items for the order.</summary>
        for (var i = 0; i < 5; i++) {
            this.items().unshift(new Item({}));
        }
    };
    self.loadItems();

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

    self.init = true;

    // default model properties
    // self.message = ko.observable(serverModel.Message);
    // self.messageType = ko.observable(serverModel.MessageType);
    // self.errorCode = ko.observable(serverModel.ErrorCode);

    // dashboard view model properties
    self.newOrderField = ko.observable().extend({ required: true });
    self.newPackageField = ko.observable().extend({ required: { message: ' ', params: true } });

    // dashboard view model collections
    self.orders = ko.observableArray();
    self.addresses = ko.observableArray();
    self.packages = ko.observableArray();
    self.retailers = ko.observableArray();

    // computed properties
    self.shouldShowOrdersEmptyMessage = ko.computed(function () {
        /// <summary>Determines whether no orders message should be displayed.</summary>
        return self.orders().length == 0;
    });

    self.disableAddOrderButton = ko.computed(function () {
        /// <summary>Determines whether add order button should be disabled.</summary>
        return self.newOrderField() === undefined || self.newOrderField() == '';
    });

    self.disableCreatePackageButton = ko.computed(function () {
        /// <summary>Determines whether create package button should be disabled.</summary>
        return self.newPackageField() === undefined || self.newPackageField() == '';
    });

    self.suggestRetailers = function() {
        /// <summary>Load shops from db to autosuggest them for user.</summary>
        if (!self.newOrderField.isValid()) {
            return;
        }
        $.post("/tdservice/retailers/suggest", { "searchText": self.newOrderField() }, function (data) {
            var retailers = ko.toJS(data);
            self.retailers.removeAll();
            $.each(retailers, function (index, value) {
                var retailer = new Retailer(value);
                self.retailers.unshift(retailer);
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
        $("#addNewOrderButton").button('toggle').button('loading');
        if (self.newOrderField.isValid()) {
            $.post("/tdservice/orders/add", { "retailerUrl": self.newOrderField() }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var order = new Order(model);
                    self.orders.unshift(order);
                    window.showNotice(data.Message, data.MessageType);
                    $('#' + order.id()).show("blind", {}, "normal", function () {
                        self.newOrderField("");

                    });
                }
                $("#addNewOrderButton").button('toggle').button('reset');
            });
            return;
        }
        $(event.target).tooltip({ trigger: 'manual'});
        $(event.target).tooltip('show');
    };

    self.removeOrder = function(order) {
        /// <summary>Remove order.</summary>
        $.post("/tdservice/orders/remove", { "orderId": order.id }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                window.showNotice(data.Message, data.MessageType);
                $('#' + order.id()).hide("explode", {}, "normal", function () {
                    self.orders.remove(order);
                });
            }
        });
    };

    self.getRecentPackages = function () {
        /// <summary>Load recent packages from server.</summary>
        $.post("/tdservice/packages/recent", function (data) {
            var packages = ko.toJS(data);
            self.packages.removeAll();
            $.each(packages, function (index, value) {
                var pack = new Package(value);
                self.packages.unshift(pack);
            });
        });
    };
    self.getRecentPackages();

    self.getPackageHistory = function (recordsToShow) {
        /// <summary>Load history of packages.</summary>
    };

    self.createPackage = function(packageName) {
        /// <summary>Create package.</summary>
    };

    self.removePackage = function(packageId) {
        /// <summary>Remove package.</summary>
    };

    self.init = false;
}