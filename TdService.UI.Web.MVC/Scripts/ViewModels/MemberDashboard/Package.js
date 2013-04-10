function PopupPackageSizeViewModel(packageObj) {
    /// <summary>Add item view model (for popup).</summary>
    var self = this;
    self.package = packageObj;
    self.weight = ko.observable(packageObj.weight()).extend({ number: { message: modalWindowValidationMessages.invalidWeight } });
    self.dimHeight = ko.observable(packageObj.dimHeight()).extend({ number: { message: modalWindowValidationMessages.invalidHeight } });
    self.dimLength = ko.observable(packageObj.dimLength()).extend({ number: { message: modalWindowValidationMessages.invalidLength } });
    self.dimWidth = ko.observable(packageObj.dimWidth()).extend({ number: { message: modalWindowValidationMessages.invalidWidth } });
    self.dimGirth = ko.observable(packageObj.dimGirth()).extend({ number: { message: modalWindowValidationMessages.invalidGirth } });

    //size popup dom id
    self.popupDomId = ko.computed(function () {
        return "sizePopup" + self.package.id();
    });

    self.errorsVisible = ko.observable(false);
    self.brokenRules = ko.observableArray();
    self.validationModel = ko.validatedObservable({
        weight: self.weight,
        dimHeight: self.dimHeight,
        dimLength: self.dimLength,
        dimWidth: self.dimWidth,
        dimGirth: self.dimGirth
    });
    self.savePackageSize = function () {
        if (!self.validationModel.isValid()) {
            self.errorsVisible(true);
            return;
        }

        $.post("/packages/updateTotalSize", {
            "PackageId": self.package.id(),
            "WeightPounds": self.weight(),
            "DimensionsLength": self.dimLength(),
            "DimensionsHeight": self.dimHeight(),
            "DimensionsWidth": self.dimWidth(),
            "DimensionsGirth": self.dimGirth()
        },
            function (data) {
                var model = ko.toJS(data);
                if (model.MessageType == "Success") {
                    self.package.weight(self.weight());
                    self.package.dimHeight(self.dimHeight());
                    self.package.dimLength(self.dimLength());
                    self.package.dimWidth(self.dimWidth());
                    self.package.dimGirth(self.dimGirth());
                    $('#' + self.popupDomId()).modal('hide');
                    window.showNotice(data.Message, data.MessageType);
                    self.package.updateEstimatedDeliveryPrice();
                }
            });
    };
}

function Package(serverModel) {
    /// <summary>Package view model.</summary>
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);

    //mesages from resources
    self.loadingText = serverModel.LoadingText;
    // package view model properties
    self.id = ko.observable(serverModel.Id);
    self.name = ko.observable(serverModel.Name);
    self.deliveryAddressId = ko.observable(serverModel.DeliveryAddressId);
    self.country = ko.observable(serverModel.Country);
    self.selectedAddress = ko.observable(serverModel.DeliveryAddressId);
    self.deliveryAddressName = ko.observable(serverModel.DeliveryAddressName).extend({ defaultIfNull: "not set" });

    self.dispatchMethod = ko.observable(serverModel.DispatchMethod);
    self.selectedMethod = ko.observable(serverModel.DispatchMethod);

    self.createdDate = ko.observable(serverModel.CreatedDateString);
    self.dispatchedDate = ko.observable(serverModel.DispatchedDateString);
    self.deliveredDate = ko.observable(serverModel.DeliveredDateString);
    self.status = ko.observable(serverModel.Status);
    self.statusTranslated = ko.observable(serverModel.StatusTranslated);
    self.isCollapsed = ko.observable(false);

    // package view model collections
    self.items = ko.observableArray();

    //size&weight
    self.dimHeight = ko.observable(serverModel.DimensionsHeight);
    self.dimLength = ko.observable(serverModel.DimensionsLength);
    self.dimWidth = ko.observable(serverModel.DimensionsWidth);
    self.dimGirth = ko.observable(serverModel.DimensionsGirth);
    self.weight = ko.observable(serverModel.TotalWeight);

    //size&weight edit popup
    self.popupPackageSizeViewModel = new PopupPackageSizeViewModel(self);

    // package state properties
    self.canBeRemoved = ko.observable(serverModel.CanBeRemoved);
    self.canBeModified = ko.observable(serverModel.CanBeModified);
    self.canItemsBeModified = ko.observable(serverModel.CanItemsBeModified);
    self.canBeSent = ko.observable(serverModel.CanBeSent);
    self.canBeDisposed = serverModel.CanBeDisposed;
    self.canBeAssembled = ko.observable(serverModel.CanBeAssembled);
    self.canBePaidFor = ko.observable(serverModel.CanBePaidFor);
    self.popupItemViewModel = new PopupItemViewModel();

    self.loadingDeliveryRates = ko.observable(false);
    self.canCalculateDeliveryRates = ko.computed(function() {
        return self.dimWidth() != '0' && self.dimHeight() != '0' && self.dimLength() != '0' && self.weight() != '0' && self.country()!=null;
    });
    this.expressMailPostagePrice = ko.observable();
    this.priorityMailPostagePrice = ko.observable();
    self.estimatedDeliveryRate = ko.computed(function () {
        if (self.loadingDeliveryRates()) return self.loadingText;
        switch (self.dispatchMethod()) {
        case 0:
            return '$' + self.expressMailPostagePrice();
        case 1:
            return '$' + self.priorityMailPostagePrice();
        }
    });
    

    self.assembleButtonVisible = ko.computed(function () {
        return self.items().length > 0 && self.canBeAssembled() && !viewSettings.operatorMode;
    });
    
    self.setPackageTotalSizeButtonVisible = ko.computed(function () {
        return self.status() == 'Assembling' && viewSettings.operatorMode;
    });

    self.packageAssembledButtonVisible = ko.computed(function () {
        return self.status() == 'Assembling' && viewSettings.operatorMode;
    });

    self.sendPackageButtonVisible = ko.computed(function () {
        return self.canBeSent() && !viewSettings.operatorMode;
    });

    self.payForPackageButtonVisible = ko.computed(function () {
        return self.canBePaidFor() && !viewSettings.operatorMode;
    });

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

    self.changeDeliveryAddress = function (packageObj) {
        if (self.selectedAddress() == null || self.selectedAddress() == self.deliveryAddressId()) return;
        $.post("/packages/ChangePackageDeliveryAddress", { "packageId": self.id(), "deliveryAddressId": self.selectedAddress() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                self.country(model.Country);
                self.deliveryAddressId(self.selectedAddress());
                self.updateEstimatedDeliveryPrice();
            }
            window.showNotice(model.Message, model.MessageType);

        });
    };

    self.changeDispatchMethod = function (packageObj) {
        if (self.selectedMethod() == null || self.selectedMethod() == self.dispatchMethod()) return;
        $.post("/packages/ChangePackageDispatchMethod", { "packageId": self.id(), "dispatchMethodId": self.selectedMethod() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == "Success") {
                self.dispatchMethod(self.selectedMethod());
            }
            window.showNotice(model.Message, model.MessageType);
            
        });
    };

    self.assemblePackage = function () {
        $.post("/packages/AssemblePackage", { "packageId": self.id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == 'Success') {
                self.updateStatusFieldsFromModel(model);
            }
            window.showNotice(model.Message, model.MessageType);
        });
    };

    self.updateStatusFieldsFromModel = function (serverModel) {
        self.status(serverModel.Status);
        self.statusTranslated(serverModel.StatusTranslated);
        self.canBeAssembled(serverModel.CanBeAssembled);
        self.canBeRemoved(serverModel.CanBeRemoved);
        self.canBeModified(serverModel.CanBeModified);
        self.canItemsBeModified(serverModel.CanItemsBeModified);
        self.canBeSent(serverModel.CanBeSent);
        self.canBePaidFor(serverModel.CanBePaidFor);
    };

    self.packageAssembled = function () {
        $.post("/packages/PackageAssembled", { "packageId": self.id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == 'Success') {
                self.updateStatusFieldsFromModel(model);
            }
            window.showNotice(model.Message, model.MessageType);
        });
    };

    self.sendPackage = function () {
        $.post("/packages/SendPackage", { "packageId": self.id() }, function (data) {
            var model = ko.toJS(data);
            if (model.MessageType == 'Success') {
                self.updateStatusFieldsFromModel(model);
            }
            window.showNotice(model.Message, model.MessageType);
        });
    };

    self.openSetPackageTotalSizePopup = function () {
        $('#' + self.popupPackageSizeViewModel.popupDomId()).modal('show');
    };

    self.updateEstimatedDeliveryPrice = function() {
        if (!self.canCalculateDeliveryRates()) return;
        self.loadingDeliveryRates(true);
        $.post("/packages/GetShippingRatesForPackage", { "height": self.dimHeight(), "length": self.dimLength(), "width": self.dimWidth(), "weight": self.weight(), "girth": self.dimGirth(), "country": self.country() }, function (data) {
            var model = ko.toJS(data);
            self.expressMailPostagePrice(model.ExpressMailPostagePrice);
            self.priorityMailPostagePrice(model.PriorityMailPostagePrice);
            self.loadingDeliveryRates(false);
        });
    };
    self.updateEstimatedDeliveryPrice();
    
    
}