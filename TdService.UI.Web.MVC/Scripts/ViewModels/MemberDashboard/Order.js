﻿function Order(serverModel) {
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

    self.popupItemViewModel = new PopupItemViewModel();

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

    self.hasItems = ko.computed(function () {
        /// <summary>Determines whether order has items.</summary>
        return self.items().length > 0;
    });

    self.orderDate = ko.computed(function () {
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

    self.trackingNumber.subscribe(function () {
        var params = { id: self.id(), orderNumber: self.orderNumber(), trackingNumber: self.trackingNumber() };
        $.post("/orders/update", params, function (data) {
            window.showNotice(data.Message, data.MessageType);
        });
    }, self);

    self.orderNumber.subscribe(function () {
        var params = { id: self.id(), orderNumber: self.orderNumber(), trackingNumber: self.trackingNumber() };
        $.post("/orders/update", params, function (data) {
            window.showNotice(data.Message, data.MessageType);
        });
    }, self);

    self.loadItems = function () {
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

    self.getItemDetails = function () {
        /// <summary>Get item details.</summary>
    };

    self.saveItem = function () {
        /// <summary>Add new item to order.</summary>
        if (!self.popupItemViewModel.validationModel.isValid()) {
            self.popupItemViewModel.errorsVisible(true);
            return;
        }

        self.popupItemViewModel.OrderId = self.id();

        var url;
        var callback;

        if (self.popupItemViewModel.id == -1) {
            url = "/items/additemtoorder";
            callback = self.addItemCallback;
        } else {
            url = "/items/EditOrderItem";
            callback = self.editItemCallback;
        }

        $.post(url, self.getPopupData(), callback);
    };

    self.editItemCallback = function (data) {
        var model = ko.toJS(data);
        if (model.MessageType == "Success") {
            self.loadItems();
            self.destroyUploader();
            $('#itemFormModal').modal('hide');
            window.showNotice(data.Message, data.MessageType);
        }
    };

    self.addItemCallback = function (data) {
        var model = ko.toJS(data);
        if (model.MessageType == "Success") {
            self.loadItems();
            $('#itemFormModal').modal('hide');
            window.showNotice(data.Message, data.MessageType);
        }
    };
    self.getPopupData = function () {
        var data =
            {
                "Id": self.popupItemViewModel.id,
                "OrderId": self.id(),
                "Name": self.popupItemViewModel.name(),
                "Quantity": self.popupItemViewModel.quantity(),
                "Price": self.popupItemViewModel.price(),
                "WeightPounds": self.popupItemViewModel.weight(),
                "DimensionsGirth": self.popupItemViewModel.dimGirth(),
                "DimensionsHeight": self.popupItemViewModel.dimHeight(),
                "DimensionsWidth": self.popupItemViewModel.dimWidth(),
                "DimensionsLength": self.popupItemViewModel.dimLength(),
                "OperatorMode": viewSettings.operatorMode
            };
        return data;
    };

    self.initUploader = function () {
        $('#uploadImages').plupload({
            // General settings
            runtimes: 'html4',
            max_file_size: '2mb',
            max_file_count: 5,
            chunk_size: '1mb',
            unique_names: true,
            url: '/Items/AddItemImage?itemId=' + self.popupItemViewModel.id
        });
        //I'm sorry for that. 
        $("#uploadImages_start").click(function () {
            var up = $('#uploadImages').plupload('getUploader');
            up.start();
        });
    };

    self.destroyUploader = function () {
        $('#uploadImages').plupload('destroy');
    }

    self.showAddItemPopup = function () {
        self.popupItemViewModel.clear();
        self.popupItemViewModel.uploaderVisible(false);

        $('#itemFormModal').modal('show');
    };

    self.showEditItemPopup = function (model) {
        self.popupItemViewModel.updateFieldsFromModel(model);
        self.popupItemViewModel.uploaderVisible(true);
        self.initUploader();

        $('#itemFormModal').modal('show');
    };

    self.removeItem = function (item) {
        /// <summary>Remove item from order.</summary>
        $.post("/items/removeItem", { "ItemId": item.id }, function (data) {
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