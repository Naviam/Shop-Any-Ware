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
    self.notifyOnOrderStatusChanged = ko.observable(profile.NotifyOnOrderStatusChanged);
    self.notifyOnPackageStatusChanged = ko.observable(profile.NotifyOnPackageStatusChanged);

    self.updateProfile = function () {
        /// <summary>Update first and last name.</summary>
        if ($("form").valid()) {
            $.post("Profile/Save", $("form").serialize(),
                function (data) {
                    if (data.BrokenRules !== undefined && data.BrokenRules != null) {
                        var container = $("form").find("[data-valmsg-summary=true]");
                        var list = container.find("ul");

                        if (list && list.length && data.BrokenRules.length) {
                            list.empty();
                            container.addClass("validation-summary-errors").removeClass("validation-summary-valid");

                            $.each(data.BrokenRules, function () {
                                $("<li />").html(this.Rule).appendTo(list);
                            });
                        }
                    }
                    window.showNotice(data.Message, data.MessageType);
                });
        }
    };
};