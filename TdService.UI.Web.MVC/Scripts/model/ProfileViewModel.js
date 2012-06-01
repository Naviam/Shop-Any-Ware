var ProfileViewModel = function (model) {
    /// <summary>
    ///     View model that describes profile form behavior.
    /// </summary>
    /// <param name="model" type="Object">
    ///     Optional model with initial data.
    /// </param>
    var profile = JSON.parse(model);
    var self = this;
    self.email = ko.observable(profile.Email);
    self.currentPassword = ko.observable(profile.CurrentPassword);
    //    self.newPassword = ko.observable("");
    self.firstName = ko.observable(profile.FirstName);
    self.lastName = ko.observable(profile.LastName);
//    self.notifyOnOrderStatusChange = ko.observable(profile.NotifyOnOrderStatusChange);
//    self.notifyOnPackageStatusChange = ko.observable(profile.NotifyOnPackageStatusChange);

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

    self.updateProfile = function () {
        /// <summary>Update first and last name.</summary>
        if ($("form").valid()) {
            $.post("Profile/Save", $("form").serialize(),
                function(data, textStatus, jqXhr) {
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