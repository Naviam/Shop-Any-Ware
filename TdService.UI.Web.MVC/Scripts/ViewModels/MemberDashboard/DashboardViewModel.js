var modalWindowValidationMessages;
var viewSettings;

function viewSettings(operatorMode) {
    this.operatorMode = operatorMode;
}

function ModalWindowValidationMessages(nameIsRequired, quantityIsRequired, priceIsRequired, invalidPrice, invalidWeight, invalidHeight, invalidLength, invalidWidth, invalidGirth, invalidQuantity) {
    this.nameIsRequired = nameIsRequired;
    this.quantityIsRequired = quantityIsRequired;
    this.priceIsRequired = priceIsRequired;
    this.invalidPrice = invalidPrice;
    this.invalidWeight = invalidWeight;
    this.invalidHeight = invalidHeight;
    this.invalidLength = invalidLength;
    this.invalidWidth = invalidWidth;
    this.invalidGirth = invalidGirth;
    this.invalidQuantity = invalidQuantity;
}

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
    //init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
    //    var value = ko.utils.unwrapObservable(valueAccessor());
    //    $(element).collapse();
    //},
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
    
    viewSettings = new viewSettings(addressModel.OperatorMode);
    
    self.UserEmail = addressModel.UserEmail;
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
    self.addingFunds = ko.observable(false);
    self.addFundsAmount = ko.observable('').extend({ required: true, number: true });

    

    if (addressModel.PayPalTransactionResultMessage && addressModel.PayPalTransactionResultMessageType &&
        addressModel.PayPalTransactionResultMessage != '' && addressModel.PayPalTransactionResultMessageType != '') {
        window.showNotice(addressModel.PayPalTransactionResultMessage, addressModel.PayPalTransactionResultMessageType);
    }

    modalWindowValidationMessages = new ModalWindowValidationMessages(addressModel.NameIsRequired, addressModel.QuantityIsRequired, addressModel.PriceIsRequired,
        addressModel.InvalidPrice, addressModel.InvalidWeight, addressModel.InvalidHeight, addressModel.InvalidLength, addressModel.InvalidWidth, addressModel.InvalidGirth, addressModel.InvalidQuantity);

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

    self.trackPackage = function (trackingNumber) {
        $.uspsTrackPackage("", trackingNumber, function () {
            alert('success');
        });
    };

    self.getRecentOrders = function () {
        /// <summary>Load recent orders from server.</summary>
        $.post("/orders/recent", { "UserEmail": self.UserEmail }, function (data) {
            var orders = ko.toJS(data);
            self.orders.removeAll();
            $.each(orders, function (index, value) {
                var order = new Order(value);
                self.orders.unshift(order);
            });
            self.recentOrdersNotLoaded(false);
        });
    };
    self.getRecentOrders();

    self.getHistoryOrders = function () {
        /// <summary>Load recent orders from server.</summary>
        $.post("/orders/history", { "UserEmail": self.UserEmail }, function (data) {
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

    self.getTransactionHistory = function () {
        $.post("/ballance/TransactionHistory", function (data) {
            var transactions = ko.toJS(data);
            self.transactions.removeAll();
            $.each(transactions, function (index, value) {
                var transaction = new Transaction(value);
                self.transactions.unshift(transaction);
            });
            
            self.transactionHistoryNotLoaded(false);
            self.balanceBindingValue({ trigger: 'click', title: '', placement: 'bottom', content: 'balancePopupContent', update: '1' });
        });
    };
    self.getTransactionHistory();

    self.createOrder = function () {
        /// <summary>Add new order.</summary>
        if (self.newOrderField.isValid()) {
            $("#addNewOrderButton").button('toggle').button('loading');
            $.post("/orders/add", { "retailerUrl": self.newOrderField(), "UserEmail": self.UserEmail }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var order = new Order(model);
                    self.orders.unshift(order);
                    window.showNotice(data.Message, data.MessageType);
                    self.newOrderField("");
                    //$('#' + order.domOrderId()).show("blind", {}, "normal", function () {
                    //    self.newOrderField("");
                    //});
                }
                $("#addNewOrderButton").button('toggle').button('reset');
            });
            return;
        }
        $(event.target).tooltip({ trigger: 'manual' });
        $(event.target).tooltip('show');
    };

    self.removeOrder = function (order) {
        /// <summary>Remove order.</summary>
        $.post("/orders/remove", { "orderId": order.id, "UserEmail": self.UserEmail }, function (data) {
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
        $.post("/packages/recent",{ "UserEmail": self.UserEmail }, function (data) {
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
        $.post("/packages/history",{ "UserEmail": self.UserEmail }, function (data) {
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

    self.createPackage = function () {
        /// <summary>Create package.</summary>
        if (self.newPackageField.isValid()) {
            $("#addNewPackageButton").button('toggle').button('loading');
            $.post("/packages/add", { "packageName": self.newPackageField(), "UserEmail": self.UserEmail  }, function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    var newPackage = new Package(model);
                    self.packages.unshift(newPackage);
                    window.showNotice(data.Message, data.MessageType);
                    self.newPackageField("");
                    //$('#' + newPackage.domPackageId()).show("blind", {}, "normal", function () {
                    //    self.newPackageField("");
                    //});
                }
                $("#addNewPackageButton").button('toggle').button('reset');
            });
            return;
        }
        $(event.target).tooltip({ trigger: 'manual' });
        $(event.target).tooltip('show');
    };

    self.removePackage = function (currentPackage) {
        /// <summary>Remove package.</summary>
        $.post("/packages/remove", { "packageId": currentPackage.id(), "UserEmail": self.UserEmail }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                window.showNotice(data.Message, data.MessageType);
                $('#' + currentPackage.domPackageId()).hide("explode", {}, "normal", function () {
                    self.packages.remove(currentPackage);
                });
            }
        });
    };

    self.AddFunds = function () {
        if (!self.addFundsAmount.isValid()) {
            window.showNotice(addressModel.AmountValidationMessage, 'Warning');
            return;
        }
        self.addingFunds(true);
        $.post("/ballance/AddTransaction", { "amount": self.addFundsAmount() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                window.location = model.RedirectUrl;
            }
            else {
                self.addingFunds(false);
                window.showNotice(model.Message, model.MessageType);
            }
        });
    };

    self.moveSingleItemToPackage = function(item) {
        if (!item.selectedPackage()) return;
        
        $.post("/items/MoveOrderItemToNewPackage", { "itemId": item.id(), "packageId": item.selectedPackage().id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                $.each(self.orders(), function (index, value) {
                    if (value.id() == model.OrderId) {
                        value.removeItemClient(model.Item.Id);
                    }
                });

                $.each(self.packages(), function (index, value) {
                    if (value.id() == model.PackageId) {
                        value.addItems([model.Item]);
                    }
                });

                window.showNotice(model.Message, model.MessageType);
            }
        });
    };
    
    self.moveEntireOrderToPackage = function (order) {
        if (!order.selectedPackage()) return;
        
        $.post("/items/MoveOrderItemsToExistingPackage", { "orderId": order.id(), "packageId": order.selectedPackage().id()}, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                $.each(self.orders(), function (index, value) {
                    if (value.id()==model.OrderId) {
                        value.items.removeAll();
                        value.selectedPackage(null);
                    }
                });
                
                $.each(self.packages(), function (index, value) {
                    if (value.id() == model.PackageId) {
                        value.addItems(model.Items);
                    }
                });
                
                window.showNotice(model.Message, model.MessageType);
            }
        });
    };
    
    self.moveItemBackToOriginalOrder = function(item) {
        $.post("/items/MoveOrderItemToOriginalOrder", { "itemId": item.id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                $.each(self.packages(), function (index, value) {
                    if (value.id() == model.PackageId) {
                        value.removeItem(model.Item.Id);//remove item client-side
                    }
                });

                $.each(self.orders(), function (index, value) {
                    if (value.id() == model.OrderId) {
                        value.addItems([model.Item]);
                    }
                });

                window.showNotice(model.Message, model.MessageType);
            }
        });
    }

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


