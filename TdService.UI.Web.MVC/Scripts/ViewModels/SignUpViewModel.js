/// <reference path="../jquery-1.7.2-vsdoc.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />
/// <reference path="../knockout.validation.debug.js" />
/// <reference path="../knockout-sortable.js" />
/// <reference path="../bootstrap/bootstrap-collapse.js" />

ko.validation.configure({
    registerExtenders: true,
    messagesOnModified: true,
    insertMessages: true,
    parseInputAttributes: true,
    messageTemplate: null,
    decorateElement: true,
    errorClass: 'error'
});

var SignUpViewModel = function () {
    var self = this;

    self.email = ko.observable('').extend({ required: true }).extend({ email: true });
    self.password = ko.observable('').extend({ required: true, minLength: 7, maxLength: 21 });
    self.passwordConfirm = ko.observable('').extend({ required: true });
    self.firstName = ko.observable('').extend({ required: true });
    self.lastName = ko.observable('').extend({ required: true });

    self.submit = function () {
        if (self.errors().length == 0) {
            $("#signUpForm").submit();
        } else {
            alert('Please check your submission.');
            self.errors.showAllMessages();
        }
    };
};

var model = new SignUpViewModel();
model.errors = ko.validation.group(model);
ko.applyBindings(model, document.getElementById('signup'));