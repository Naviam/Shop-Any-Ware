var SignUpViewModel = function (model) {
    /// <summary>
    ///     View model that describes sign up form behavior.
    /// </summary>
    /// <param name="model" type="Object">
    ///     Optional model with initial data.
    /// </param>
    // var signUp = JSON.parse(model);
    var self = this;
    self.email = ko.observable(); // signUp.Email
    self.password = ko.observable(); // signUp.Password
    self.passwordConfirm = ko.observable(); // signUp.passwordConfirm
    self.firstName = ko.observable(); // signUp.FirstName
    self.lastName = ko.observable(); // signUp.LastName

    self.verifyEmailExists = function () {
        /// <summary>
        ///    Verify Email Exists
        /// </summary>
        if ($("form").validate().element(self.email)) {
            alert("send request");
        }
    };
};

$(document).ready(function () {
    ko.applyBindings(new SignUpViewModel(null));
});