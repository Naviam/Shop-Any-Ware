var SignUpViewModel = function (model) {
    /// <summary>
    ///     View model that describes sign up form behavior.
    /// </summary>
    /// <param name="model" type="Object">
    ///     Optional model with initial data.
    /// </param>
    // var signUp = JSON.parse(model);
    var self = this;
    self.email = ko.observable(model.Email).extend({ required: true }); // signUp.Email
    self.password = ko.observable().extend({ required: true }); // signUp.Password
    self.passwordConfirm = ko.observable().extend({ required: true }); // signUp.passwordConfirm
    self.firstName = ko.observable(model.FirstName).extend({ required: true }); // signUp.FirstName
    self.lastName = ko.observable(model.LastName).extend({ required: true }); // signUp.LastName

    self.verifyEmailExists = function () {
        /// <summary>
        ///    Verify Email Exists
        /// </summary>
        if ($("form").validate().element(self.email)) {
            alert("send request");
        }
    };
};