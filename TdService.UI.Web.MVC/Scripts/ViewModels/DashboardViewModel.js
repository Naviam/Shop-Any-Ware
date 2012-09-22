﻿/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />
/// <reference path="../knockout.validation.debug.js" />
/// <reference path="../knockout-sortable.js" />
/// <reference path="../bootstrap/bootstrap-collapse.js" />

function getUrl(methodUrl) {
    return window.location.host + methodUrl;
}

function formatDate(dateUtcString) {
    if (dateUtcString == null || dateUtcString === undefined)
        return null;

    var date = new Date(dateUtcString);
    var currDate = date.getDate();
    var currMonth = date.getMonth() + 1; //Months are zero based
    var currYear = date.getFullYear();
    return currDate + "-" + currMonth + "-" + currYear;
}

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

ko.bindingHandlers.collapsed = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).collapse();
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        if (value) {
            $(element).collapse('hide');
        }
        else {
            $(element).collapse('show');
        }
    }
};

function Item(serverModel) {
    /// <summary>Item view model.</summary>
    var self = this;

    self.id = ko.observable(serverModel.Id);
    self.name = ko.observable(serverModel.Name);
    self.price = ko.observable(serverModel.Price);
    self.quantity = ko.observable(serverModel.Quantity);
    self.size = ko.observable(serverModel.Size);
    self.weight = ko.observable(serverModel.Weight);
    self.color = ko.observable(serverModel.Color);

    self.showDetails = function(item) {
        /// <summary>Show item details.</summary>
    };
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

    self.totalItemsQuantity = ko.computed(function() {
        /// <summary>Determines the total number of items in the package.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].quantity();
        }
        return total;
    });

    self.totalItemsWeight = ko.computed(function() {
        /// <summary>Determines the total weight of items in the package.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].weight();
        }
        return total;
    });

    self.loadItems = ko.computed(function () {
        $.post("/items/getpackageitems", { "packageId": self.id() }, function (data) {
            var items = ko.toJS(data);
            self.items.removeAll();
            $.each(items, function (index, value) {
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

function ItemViewModel() {
    /// <summary>Add item view model.</summary>
    var self = this;

    self.OrderId = 0;
    self.Name = ko.observable("").extend({ required: true });
    self.Quantity = ko.observable(1).extend({ required: true });
    self.Price = ko.observable().extend({ required: true });
    self.Weight = ko.observable();
    self.Size = ko.observable("");
    self.Color = ko.observable("");
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
    self.orderNumber = ko.observable(serverModel.OrderNumber);
    self.trackingNumber = ko.observable(serverModel.TrackingNumber);
    self.createdDate = ko.observable(formatDate(serverModel.CreatedDate));
    self.receivedDate = ko.observable(formatDate(serverModel.ReceivedDate));
    self.status = ko.observable(serverModel.Status);
    self.statusTranslated = ko.observable(serverModel.StatusTranslated);
    self.isCollapsed = ko.observable(false);

    // order view model collections
    self.items = ko.observableArray();

    self.itemViewModel = new ItemViewModel();

    // order state properties
    self.canBeReceived = serverModel.CanBeReceived;
    self.canBeRemoved = serverModel.CanBeRemoved;
    self.canBeModified = serverModel.CanBeModified;
    self.canItemsBeModified = serverModel.CanItemsBeModified;
    self.canBeRequestedForReturn = serverModel.CanBeRequestedForReturn;

    // order view model computed properties
    self.domOrderId = ko.computed(function () {
        return "order" + self.id();
    });

    self.totalItemsAmount = ko.computed(function () {
        /// <summary>Determines the total amount of the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].price();
        }
        return total;
    });

    self.totalItemsQuantity = ko.computed(function () {
        /// <summary>Determines the total number of items in the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].quantity();
        }
        return total;
    });

    self.totalItemsWeight = ko.computed(function () {
        /// <summary>Determines the total weight of items in the order.</summary>
        var total = 0;
        for (var i = 0; i < self.items().length; i++) {
            total = total + self.items()[i].weight();
        }
        return total;
    });
    
    self.hasItems = ko.computed(function() {
        /// <summary>Determines whether order has items.</summary>
        return self.items().length > 0;
    });

    self.orderDate = ko.computed(function() {
        return self.receivedDate() == null ? self.createdDate() : self.receivedDate();
    });

    self.isExpanded = ko.computed(function () {
        return !self.isCollapsed();
    });

    self.toggleCollapse = function () {
        var currentValue = self.isCollapsed();
        self.isCollapsed(!currentValue);
    };

    self.loadItems = function() {
        /// <summary>Get collection of items for the order.</summary>
        $.post("/items/getorderitems", { "orderId": self.id() }, function (data) {
            var items = ko.toJS(data);
            self.items.removeAll();
            $.each(items, function (index, value) {
                var item = new Item(value);
                self.items.unshift(item);
            });
        });
    };
    self.loadItems();

    self.getItemDetails = function(item) {
        /// <summary>Get item details.</summary>
    };

    self.addItem = function() {
        /// <summary>Add new item to order.</summary>
        self.itemViewModel.OrderId = self.id();
        var params =
            {
                "OrderId": self.id(),
                "Name": self.itemViewModel.Name(),
                "Quantity": self.itemViewModel.Quantity(),
                "Price": self.itemViewModel.Price(),
                "Size": self.itemViewModel.Size(),
                "Weight": self.itemViewModel.Weight(),
                "Color": self.itemViewModel.Color()
            };
        $.post("/items/additemtoorder", params, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                var item = new Item(model);
                self.items.unshift(item);
                window.showNotice(data.Message, data.MessageType);
                $('#' + item.id()).show("blind", {}, "normal", function () {
                    self.itemViewModel = new ItemViewModel();
                });
            }
        });
    };

    self.removeItem = function(item) {
        /// <summary>Remove item from order.</summary>
        $.post("/items/removeitemfromorder", ko.toJSON(item.id), function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                self.items.remove(item);
                window.showNotice(model.Message, model.MessageType);
                $('#' + item.id()).show("blind", {}, "normal", function () {
                });
            }
        });
    };
}

function Retailer(serverModel) {
    /// <summary>Retailer view model.</summary>
    var self = this;

    self.url = ko.observable(serverModel.Url);
    self.description = ko.observable(serverModel.Description);
}

function DashboardViewModel(serverModel) {
    /// <summary>Dashboard view model. The parent model for others.</summary>
    var self = this;

    self.recentPackagesNotLoaded = ko.observable(true);
    self.recentOrdersNotLoaded = ko.observable(true);

    // dashboard view model properties
    self.newOrderField = ko.observable().extend({ required: true });
    self.newPackageField = ko.observable().extend({ required: true });

    // dashboard view model collections
    self.orders = ko.observableArray();
    self.ordersHistory = ko.observableArray();
    self.addresses = ko.observableArray();
    self.packages = ko.observableArray();
    self.packagesHistory = ko.observableArray();
    self.retailers = ko.observableArray();

    // computed properties
    self.shouldShowOrdersEmptyMessage = ko.computed(function () {
        /// <summary>Determines whether no orders message should be displayed.</summary>
        return self.orders().length == 0 && self.recentOrdersNotLoaded() == false;
    });

    self.shouldShowLoadingRecentOrdersMessage = ko.computed(function () {
        /// <summary>Determines whether loading recent packages message should be displayed.</summary>
        return self.orders().length == 0 && self.recentOrdersNotLoaded();
    });

    self.shouldShowPackagesEmptyMessage = ko.computed(function () {
        /// <summary>Determines whether no orders message should be displayed.</summary>
        return self.packages().length == 0 && self.recentPackagesNotLoaded() == false;
    });

    self.shouldShowLoadingRecentPackagesMessage = ko.computed(function () {
        /// <summary>Determines whether loading recent packages message should be displayed.</summary>
        return self.packages().length == 0 && self.recentPackagesNotLoaded();
    });

    self.disableAddOrderButton = ko.computed(function () {
        /// <summary>Determines whether add order button should be disabled.</summary>
        return self.newOrderField() === undefined || self.newOrderField() == '';
    });

    self.disableCreatePackageButton = ko.computed(function () {
        /// <summary>Determines whether create package button should be disabled.</summary>
        return self.newPackageField() === undefined || self.newPackageField() == '';
    });

    self.collapseAllOrders = function () {
        $.each(self.orders(), function (index, order) {
            order.isCollapsed(true);
        });
    };

    self.collapseAllPackages = function () {
        $.each(self.packages(), function (index, pack) {
            pack.isCollapsed(true);
        });
    };

    self.addOrderExample = function (link) {
        self.newOrderField(link);
    };

    self.addPackageExample = function (link) {
        self.newPackageField(link);
    };

    self.suggestRetailers = function () {
        /// <summary>Load shops from db to autosuggest them for user.</summary>
        //if (!self.newOrderField.isValid()) {
        //    return;
        //}
        $.post("/retailers/get", { "searchText": self.newOrderField() }, function (data) {
            var retailers = ko.toJS(data);
            self.retailers.removeAll();
            $.each(retailers, function (index, value) {
                var retailer = new Retailer(value);
                self.retailers.unshift(retailer.url);
            });
        });
    };
    self.suggestRetailers();

    self.getRecentOrders = function() {
        /// <summary>Load recent orders from server.</summary>
        $.post("/orders/recent", function (data) {
            var orders = ko.toJS(data);
            self.orders.removeAll();
            $.each(orders, function(index, value) {
                var order = new Order(value);
                self.orders.unshift(order);
            });
            self.recentOrdersNotLoaded(false);
        });
    };
    self.getRecentOrders();
    
    self.getHistoryOrders = function () {
        /// <summary>Load recent orders from server.</summary>
        $.post("/orders/history", function (data) {
            var orders = ko.toJS(data);
            self.ordersHistory.removeAll();
            $.each(orders, function (index, value) {
                var order = new Order(value);
                self.ordersHistory.unshift(order);
            });
        });
    };
    self.getHistoryOrders();

    self.createOrder = function() {
        /// <summary>Add new order.</summary>
        if (self.newOrderField.isValid()) {
            $("#addNewOrderButton").button('toggle').button('loading');
            $.post("/orders/add", { "retailerUrl": self.newOrderField() }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var order = new Order(model);
                    self.orders.unshift(order);
                    window.showNotice(data.Message, data.MessageType);
                    $('#' + order.domOrderId()).show("blind", {}, "normal", function () {
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
        $.post("/orders/remove", { "orderId": order.id }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                window.showNotice(data.Message, data.MessageType);
                $('#' + order.domOrderId()).hide("explode", {}, "normal", function () {
                    self.orders.remove(order);
                });
            }
        });
    };

    self.getRecentPackages = function () {
        /// <summary>Load recent packages from server.</summary>
        $.post("/packages/recent", function (data) {
            var packages = ko.toJS(data);
            self.packages.removeAll();
            $.each(packages, function (index, value) {
                var pack = new Package(value);
                self.packages.unshift(pack);
            });
            self.recentPackagesNotLoaded(false);
        });
    };
    self.getRecentPackages();

    self.getPackageHistory = function (recordsToShow) {
        /// <summary>Load history of packages.</summary>
    };

    self.createPackage = function() {
        /// <summary>Create package.</summary>
        if (self.newPackageField.isValid()) {
            $("#addNewPackageButton").button('toggle').button('loading');
            $.post("/packages/add", { "packageName": self.newPackageField() }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var newPackage = new Package(model);
                    self.packages.unshift(newPackage);
                    window.showNotice(data.Message, data.MessageType);
                    $('#' + newPackage.domPackageId()).show("blind", {}, "normal", function () {
                        self.newPackageField("");
                    });
                }
                $("#addNewPackageButton").button('toggle').button('reset');
            });
            return;
        }
        $(event.target).tooltip({ trigger: 'manual' });
        $(event.target).tooltip('show');
    };

    self.removePackage = function(currentPackage) {
        /// <summary>Remove package.</summary>
        $.post("/packages/remove", { "packageId": currentPackage.id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                window.showNotice(data.Message, data.MessageType);
                $('#' + currentPackage.domPackageId()).hide("explode", {}, "normal", function () {
                    self.packages.remove(currentPackage);
                });
            }
        });
    };

    ko.bindingHandlers.autosuggest = {
        init: function (element, valueAccessor, allBindingAccessors, model) {
            $.post("/retailers/get", { "searchText": self.newOrderField() }, function (data) {
                var retailers = ko.toJS(data);
                self.retailers.removeAll();
                $.each(retailers, function (index, value) {
                    var retailer = new Retailer(value);
                    self.retailers.unshift(retailer.url);
                });
                var retailerUrls = $.map(retailers, function (n) {
                    return n.Url;
                });
                $(element).typeahead({ source: retailerUrls });
            });
            
        }
    };
}