var ProfileViewModel = function (model) {
    /// <summary>
    ///     View model that describes profile form behavior.
    /// </summary>
    /// <param name="orders" type="Array">
    ///     Optional collection of initial orders.
    /// </param>
    var profile = JSON.parse(model);
    var self = this;
    self.email = ko.observable(profile.Email);
    self.currentPassword = ko.observable(profile.CurrentPassword);
    //    self.newPassword = ko.observable("");
    self.firstName = ko.observable(profile.FirstName);
    self.lastName = ko.observable(profile.LastName);

    self.updateFullName = function () {
        /// <summary>Update first and last name.</summary>
        /// <param name="order">Order to remove.</param>

    };
};

