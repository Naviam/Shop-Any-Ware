/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />

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
    self.orderNumber = ko.observable(serverModel.OrderNumber);
    self.trackingNumber = ko.observable(serverModel.TrackingNumber);
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

    self.getItemDetails = function(itemId) {
        /// <summary>Get item details.</summary>
    };

    self.addItem = function(item) {
        /// <summary>Add new item to order.</summary>
    };

    self.removeItem = function(item) {
        /// <summary>Remove item from order.</summary>
    };
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

    self.loadRetailers = function() {
        /// <summary>Load shops from db to autosuggest them for user.</summary>
    };

    self.getRecentOrders = function() {
        /// <summary>Load recent orders from server.</summary>
        $.post("/tdservice/order/getrecent", function (data) {
            var orders = ko.toJS(data);
            self.orders = ko.observable(orders);
        });
    };
    self.getRecentOrders();

    self.getRecentPackages = function() {
        /// <summary>Load recent packages from server.</summary>
    };

    self.getPackages = function(recordsToShow) {
        /// <summary>Load history of packages.</summary>
    };

    self.createOrder = function() {
        /// <summary>Add new order.</summary>
        if (self.newOrderField() != "") {
            $.post("/tdservice/order/addorder", { "retailerUrl": ko.toJSON(self.newOrderField()) }, function (data) {
                alert(data);
                self.newOrderField("");
            });
        }
        // show error message
    };

    self.removeOrder = function(orderId) {
        /// <summary>Remove order.</summary>
    };

    self.createPackage = function(packageName) {
        /// <summary>Create package.</summary>
    };

    self.removePackage = function(packageId) {
        /// <summary>Remove package.</summary>
    };
}