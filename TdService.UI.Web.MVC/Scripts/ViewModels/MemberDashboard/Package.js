﻿function Package(serverModel) {
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

    self.popupItemViewModel = new PopupItemViewModel();

    // package view model computed properties
    self.domPackageId = ko.computed(function () {
        return "package" + self.id();
    });

    self.popupDomId = ko.computed(function () {
        return "packageItemFormModal" + self.id();
    });

    self.plUploaderDivContainerId = ko.computed(function () {
        return "plUploaderPackageDiv" + self.id();
    });

    self.plUploaderstartButtonId = ko.computed(function () {
        return self.plUploaderDivContainerId() + '_start';
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

    self.loadItems = function () {
        $.post("/items/getpackageitems", { "packageId": self.id() }, function (data) {
            var response = ko.toJS(data);
            self.items.removeAll();
            self.addItems(response.Items);
        });
    };
    self.loadItems();

    self.addItems = function (itemsList) {
        $.each(itemsList, function (index, value) {
            var item = new Item(value);
            self.items.unshift(item);
        });
    };

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

    self.removeItem = function (id) {
        ///remove item client-side
        $.each(self.items(), function (index, value) {
            if (value.id() == id) {
                self.items.remove(value);
                return false;
            }
        });
    };

    self.showEditItemPopup = function (model) {
        self.popupItemViewModel.updateFieldsFromModel(model);
        self.popupItemViewModel.uploaderVisible(true);

        $('#' + self.popupDomId()).modal('show');
        self.initUploader();
    };

    self.saveItem = function () {
        /// <summary>Add new item to order.</summary>
        if (!self.popupItemViewModel.validationModel.isValid()) {
            self.popupItemViewModel.errorsVisible(true);
            return;
        }

        var url = '/items/EditPackageItem';
        var callback = self.editItemCallback;

        $.post(url, self.getPopupData(), callback);
    };

    self.getPopupData = function () {
        var data =
            {
                "Id": self.popupItemViewModel.id,
                "PackageId": self.id(),
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

    self.editItemCallback = function (data) {
        var model = ko.toJS(data);
        if (model.MessageType == "Success") {
            $.each(self.items(), function (index, value) {
                if (value.id() == model.Id) {
                    value.updateFromModel(model);
                    return false;
                }
            });
            $('#' + self.popupDomId()).modal('hide');
            window.showNotice(data.Message, data.MessageType);
        }
    };
    
    self.initUploader = function () {
        $('#' + self.plUploaderDivContainerId()).plupload({
            // General settings
            runtimes: 'html4',
            max_file_size: '2mb',
            max_file_count: 5,
            chunk_size: '1mb',
            filters: [
            { title: "Image files", extensions: "jpg,bmp,gif,jpeg" }
            ],
            url: '/Items/AddItemImage?itemId=' + self.popupItemViewModel.id,
            init: {
                FileUploaded: function (up, file, response) {
                    //TODO: handle responses
                    var model = JSON.parse(response.response);
                    if (model.MessageType != 'Success') return;
                    //add new image to carousel
                    $.each(self.items(), function (index, value) {
                        if (value.id() == model.ItemId) {
                            //found
                            value.images.push({ FileName: model.FileName, Url: model.Url });

                        }
                    });
                }
            }
        });
        //I'm sorry for that. 
        $('#' + self.plUploaderstartButtonId()).click(function () {
            var up = $('#' + self.plUploaderDivContainerId()).plupload('getUploader');
            up.start();
        });
        var up = $('#' + self.plUploaderDivContainerId()).plupload('getUploader');
        up.refresh();
    };
    
}