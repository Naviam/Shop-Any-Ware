function Item(serverModel) {
    /// <summary>Item view model.</summary>
    var self = this;

    self.id = ko.observable(serverModel.Id);
    self.name = ko.observable(serverModel.Name);
    self.price = ko.observable(serverModel.Price);
    self.weight = ko.observable(serverModel.WeightPounds);
    self.quantity = ko.observable(serverModel.Quantity);
    self.dimHeight = ko.observable(serverModel.DimensionsHeight);
    self.dimLength = ko.observable(serverModel.DimensionsLength);
    self.dimWidth = ko.observable(serverModel.DimensionsWidth);
    self.dimGirth = ko.observable(serverModel.DimensionsGirth);
    self.images = ko.observableArray(serverModel.Images);

    self.selectedPackage = ko.observable();

    self.imagesPopupDivId = ko.computed(function () {
        return 'popup' + self.id();
    });
    
    self.slider = null;
    
    self.openImagesPopup = function () {
        if (self.images().length == 0) return;
        $('#' + self.imagesPopupDivId()).modal('show');
        self.slider = $('#' + self.imagesPopupDivId() +' .bxslider').bxSlider({
            mode: 'fade',
            captions: true
        });
    };
    
    self.closeImagesPopup = function () {
        self.slider.destroySlider();
        $('#' + self.imagesPopupDivId()).modal('hide');
    };
    
    self.updateFromModel = function (serverModel) {
        self.name(serverModel.Name);
        self.price(serverModel.Price);
        self.weight(serverModel.WeightPounds);
        self.quantity(serverModel.Quantity);
        self.dimHeight(serverModel.DimensionsHeight);
        self.dimLength(serverModel.DimensionsLength);
        self.dimWidth(serverModel.DimensionsWidth);
        self.dimGirth(serverModel.DimensionsGirth);
        self.images(serverModel.Images);
    }
}



function PopupItemViewModel() {
    /// <summary>Add item view model (for popup).</summary>
    var self = this;
    self.OrderId = 0;
    self.id = -1;//new
    self.name = ko.observable("").extend({ required: { message: modalWindowValidationMessages.nameIsRequired } });
    self.quantity = ko.observable(1).extend({ required: { message: modalWindowValidationMessages.quantityIsRequired }, number: { message: modalWindowValidationMessages.invalidQuantity }  });
    self.price = ko.observable().extend({ required: { message: modalWindowValidationMessages.priceIsRequired }, number: { message: modalWindowValidationMessages.invalidPrice } });
    self.weight = ko.observable("").extend({ number: { message: modalWindowValidationMessages.invalidWeight } });
    self.dimHeight = ko.observable("").extend({ number: { message: modalWindowValidationMessages.invalidHeight } });
    self.dimLength = ko.observable("").extend({ number: { message: modalWindowValidationMessages.invalidLength } });
    self.dimWidth = ko.observable("").extend({ number: { message: modalWindowValidationMessages.invalidWidth } });
    self.dimGirth = ko.observable("").extend({ number: { message: modalWindowValidationMessages.invalidGirth } });
    
    self.uploaderVisible = ko.observable(false);
    self.errorsVisible = ko.observable(false);
    self.brokenRules = ko.observableArray();
    self.validationModel = ko.validatedObservable({
        name: self.name,
        quantity: self.quantity,
        price: self.price,
        weight: self.weight,
        dimHeight: self.dimHeight,
        dimLength: self.dimLength,
        dimWidth: self.dimWidth,
        dimGirth: self.dimGirth
    });

    self.updateFieldsFromModel = function (model) {
        self.id = model.id();
        self.name(model.name());
        self.quantity(model.quantity());
        self.price(model.price());
        self.weight(model.weight());
        self.dimHeight(model.dimHeight());
        self.dimLength(model.dimLength());
        self.dimWidth(model.dimWidth());
        self.dimGirth(model.dimGirth());
    };
    self.clear = function () {
        self.id = -1;
        self.name("");
        self.quantity("");
        self.price("");
        self.weight("");
        self.dimHeight("");
        self.dimLength("");
        self.dimWidth("");
        self.dimGirth("");
    };
}