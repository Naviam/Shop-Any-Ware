var SignUpViewModel = function (model) {
    /// <summary>
    ///     View model that describes sign up form behavior.
    /// </summary>
    /// <param name="model" type="Object">
    ///     Optional model with initial data.
    /// </param>
    var signUp = JSON.parse(unescape(model));
    var self = this;
    self.email = ko.observable(signUp.Email).extend({ required: true }); // signUp.Email
    self.password = ko.observable().extend({ required: true }); // signUp.Password
    self.passwordConfirm = ko.observable().extend({ required: true }); // signUp.passwordConfirm
    self.firstName = ko.observable(signUp.FirstName).extend({ required: true }); // signUp.FirstName
    self.lastName = ko.observable(signUp.LastName).extend({ required: true }); // signUp.LastName

    self.verifyEmailExists = function () {
        /// <summary>
        ///    Verify Email Exists
        /// </summary>
        if ($("form").validate().element(self.email)) {
            alert("send request");
        }
    };
};