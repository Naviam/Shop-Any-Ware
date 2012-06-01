var DeliveryAddressViewModel = function (modelParam) {
    /// <summary>
    ///     View model that describes delivery addresses page behavior.
    /// </summary>
    /// <param name="modelParam" type="Object">
    ///     Optional model with initial data.
    /// </param>
    var model = JSON.parse(modelParam);
    var self = this;
    self.addressBook = ko.observableArray(model.DeliveryAddressBook);

    //    $("form").validate({
    //        errorClass: 'error',
    //        validClass: 'success',
    //        errorElement: 'span',
    //        highlight: function (element, errorClass, validClass) {
    //            $(element).parents("div[class='control-group']").addClass(errorClass).removeClass(validClass);
    //        },
    //        unhighlight: function (element, errorClass, validClass) {
    //            $(element).parents(".error").removeClass(errorClass).addClass(validClass);
    //        }
    //    });

    self.addNewAddress = function () {
        /// <summary>Update first and last name.</summary>
        if ($("form").valid()) {
            $.post("Address/Create", $("form").serialize(),
                function (data, textStatus, jqXhr) {
                    noty({
                        "text": data.Message,
                        "layout": "topCenter",
                        "type": data.MessageType,
                        "theme": "noty_theme_twitter",
                        "animateOpen": { "height": "toggle" },
                        "animateClose": { "height": "toggle" },
                        "speed": 500,
                        "timeout": 5000,
                        "closeButton": false,
                        "closeOnSelfClick": true,
                        "closeOnSelfOver": false,
                        "modal": false
                    });
                });
        }
    };
};