/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />
/// <reference path="../knockout.validation.debug.js" />
/// <reference path="../knockout-sortable.js" />
/// <reference path="../bootstrap/bootstrap-collapse.js" />

function SignInViewModel() {
    var self = this;

    self.email = ko.observable('').extend({ required: true }).extend({ email: true });
    self.password = ko.observable('').extend({ required: true });
    self.rememberMe = ko.observable(false);

    self.submit = function () {
        if (self.isValid()) {
            $("#signInForm").submit();
        }
    };
}