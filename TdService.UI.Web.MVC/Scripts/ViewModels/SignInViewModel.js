/// <reference path="../jquery-1.8.1.intellisense.js" />
/// <reference path="../jquery.noty.js" />
/// <reference path="../json2.js" />
/// <reference path="../knockout-2.1.0.debug.js" />
/// <reference path="../knockout.mapping-latest.debug.js" />
/// <reference path="../knockout.validation.debug.js" />
/// <reference path="../knockout-sortable.js" />

function SignInViewModel(model) {
    var m = JSON.parse(unescape(model));
    var self = this;

    self.Email = ko.observable(m.Email).extend({ required: true, email: true });
    self.Password = ko.observable(m.Password).extend({ required: true });
    self.RememberMe = ko.observable(m.RememberMe);
    ////self.__RequestVerificationToken = encodeURIComponent($('#signInForm [name=__RequestVerificationToken]').val());

    self.signIn = function (signInModel) {
        ko.mapping.defaultOptions().ignore = ["errorElementClass", "errorMessageClass"];
        var request = $.ajax({
            url: "/account/signin",
            type: 'POST',
            data: ko.mapping.toJSON(signInModel),
            dataType: 'json',
            contentType: 'application/json'
        });

        request.done(function (data) {
            if (data.redirect) {
                // data.redirect contains the string URL to redirect to
                window.location = data.redirect;
            }
            else {
                window.showNotice(data.Message, data.MessageType);
            }
        });

        request.fail(function (jqXHR, textStatus, errorThrown) {
            if (console && console.log) {
                console.log("Status: " + textStatus + " Error:", errorThrown);
            }
        });
        ////$.ajax("/account/signin", ko.mapping.toJSON(signInModel), function (data) {
        ////    window.showNotice(data.Message, data.MessageType);
        ////});
    };
}