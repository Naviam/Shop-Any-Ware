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
    self.firstName = ko.observable(profile.FirstName);
    self.lastName = ko.observable(profile.LastName);
    self.notifyOnOrderStatusChange = ko.observable(profile.NotifyOnOrderStatusChange);
    self.notifyOnPackageStatusChange = ko.observable(profile.NotifyOnPackageStatusChange);

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
                        "timeout": 8000,
                        "closeButton": true,
                        "closeOnSelfClick": true,
                        "closeOnSelfOver": false,
                        "modal": false
                    });
                });
        }
    };
};