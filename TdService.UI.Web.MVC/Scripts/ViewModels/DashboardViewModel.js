/// <reference path="../jquery-1.7.2-vsdoc.js" />
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

ko.bindingHandlers.autosuggest = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) { // , valueAccessor, allBindingAccessors, model
        $.post("/retailers/get", { "searchText": viewModel.newOrderField() }, function (data) {
            var retailers = ko.toJS(data);
            viewModel.retailers.removeAll();
            $.each(retailers, function (index, value) {
                var retailer = new Retailer(value);
                viewModel.retailers.unshift(retailer.url);
            });
            var retailerUrls = $.map(retailers, function (n) {
                return n.Url;
            });
            $(element).typeahead({ source: retailerUrls });
        });
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
    self.brokenRules = ko.observableArray(serverModel.BrokenRules);

    // order view model properties
    self.id = ko.observable(serverModel.Id);
    self.retailerUrl = ko.observable(serverModel.RetailerUrl);
    self.orderNumber = ko.observable(serverModel.OrderNumber);
    self.trackingNumber = ko.observable(serverModel.TrackingNumber);
    self.createdDate = ko.observable(formatDate(serverModel.CreatedDate));
    self.receivedDate = ko.observable(formatDate(serverModel.ReceivedDate));
    self.returnedDate = ko.observable(formatDate(serverModel.ReturnedDate));
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
        switch (self.status()) {
            case 'Received':
                return self.receivedDate();
            case 'Returned':
                return self.returnedDate();
            default:
                return self.createdDate();
        }
    });

    self.isExpanded = ko.computed(function () {
        return !self.isCollapsed();
    });

    self.toggleCollapse = function () {
        var currentValue = self.isCollapsed();
        self.isCollapsed(!currentValue);
    };

    self.trackingNumber.subscribe(function() {
        var params = { id: self.id(), orderNumber: self.orderNumber(), trackingNumber: self.trackingNumber() };
        $.post("/orders/update", params, function(data) {
            window.showNotice(data.Message, data.MessageType);
        });
    }, self);
    
    self.orderNumber.subscribe(function () {
        var params = { id: self.id(), orderNumber: self.orderNumber(), trackingNumber: self.trackingNumber() };
        $.post("/orders/update", params, function (data) {
            window.showNotice(data.Message, data.MessageType);
        });
    }, self);

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

    self.getItemDetails = function() {
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

function Transaction(serverModel) {
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);
    self.brokenRules = ko.observableArray(serverModel.BrokenRules);
    
    //server model properties
    self.operationAmount = ko.observable(serverModel.OperationAmount);
    self.transactionDate = ko.observable(serverModel.Date);
    self.currency = ko.observable(serverModel.Currency);
    self.transactionStatus = ko.observable(serverModel.StatusTranslated);
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
    var addressModel = JSON.parse(serverModel);

    self.recentPackagesNotLoaded = ko.observable(true);
    self.recentOrdersNotLoaded = ko.observable(true);
    self.historyPackagesNotLoaded = ko.observable(true);
    self.historyOrdersNotLoaded = ko.observable(true);
    self.transactionHistoryNotLoaded = ko.observable(true);
    
    // dashboard view model properties
    self.newOrderField = ko.observable().extend({ required: true });
    self.newPackageField = ko.observable().extend({ required: true });
    self.deliveryAddresses = ko.observable(addressModel.DeliveryAddressViewModels);
    self.deliveryMethods = ko.observable(addressModel.DeliveryMethods);
    self.balanceBindingValue = ko.observable({ trigger: 'click', title: '', placement: 'bottom', content: 'balancePopupContent' });

    // dashboard view model collections
    self.orders = ko.observableArray();
    self.ordersHistory = ko.observableArray();
    self.transactions = ko.observableArray();
    self.addresses = ko.observableArray();
    self.packages = ko.observableArray();
    self.packagesHistory = ko.observableArray();
    self.retailers = ko.observableArray();

    self.balance = ko.observable(addressModel.WalletAmount);
    self.addFundsAmount = ko.observable('').extend({ required: { message: '*' }, number: true });
    
    // computed properties
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

    self.expandAllOrders = function () {
        $.each(self.orders(), function (index, order) {
            order.isCollapsed(false);
        });
    };

    self.collapseAllPackages = function () {
        $.each(self.packages(), function (index, pack) {
            pack.isCollapsed(true);
        });
    };

    self.expandAllPackages = function () {
        $.each(self.packages(), function (index, pack) {
            pack.isCollapsed(false);
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

    self.trackPackage = function(trackingNumber) {
        $.uspsTrackPackage("", trackingNumber, function() {
            alert('success');
        });
    };

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
            self.historyOrdersNotLoaded(false);
        });
    };
    self.getHistoryOrders();

    self.getTransactionHistory = function() {
        $.post("/ballance/TransactionHistory", function (data) {
            var transactions = ko.toJS(data);
            self.transactions.removeAll();
            $.each(transactions, function (index, value) {
                var transaction = new Transaction(value);
                self.transactions.unshift(transaction);
            });
            ////for (var i = 0; i < transactions.length;i++) {
            ////    var transaction = new Transaction(transactions[i]);
            ////    self.transactionHistory.unshift(transaction);
            ////}
            self.transactionHistoryNotLoaded(false);
            self.balanceBindingValue({ trigger: 'click', title: '', placement: 'bottom', content: 'balancePopupContent', update: '1' });
        });
    };
    self.getTransactionHistory();

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

    self.getPackageHistory = function () {
        /// <summary>Load history of packages.</summary>
        $.post("/packages/history", function (data) {
            var packages = ko.toJS(data);
            self.packagesHistory.removeAll();
            $.each(packages, function (index, value) {
                var pack = new Package(value);
                self.packagesHistory.unshift(pack);
            });
            self.historyPackagesNotLoaded(false);
        });
    };
    self.getPackageHistory();

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

    self.AddFunds = function() {
        var valid = self.addFundsAmount.isValid();
        ko.validation.group(self).showAllMessages();
    };

}



ko.bindingHandlers.popover = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var options = ko.utils.unwrapObservable(valueAccessor());
        if (options) {
            var templateContent = $('#' + options.content).html();
            $(element).attr('data-content', templateContent);
            $(element).attr('data-original-title', options.title || '');
            $(element).attr('data-placement', options.placement || 'right');
            $(element).attr('data-trigger', options.trigger || 'click');
        }
        $(element).popover({ html: true });
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        $(element).popover('destroy');
        var options = ko.utils.unwrapObservable(valueAccessor());

        if (options) {
            var templateContent = $('#' + options.content).html();
            $(element).attr('data-content', templateContent);
            $(element).attr('data-original-title', options.title || '');
            $(element).attr('data-placement', options.placement || 'right');
            $(element).attr('data-trigger', options.trigger || 'click');
        }
        $(element).popover({ html: true });
    }
};


