﻿function Role(serverModel) {
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);
    self.brokenRules = ko.observableArray(serverModel.BrokenRules);

    //server model properties
    self.roleName = serverModel.NameTranslated;
    self.id = serverModel.Id;
}

function UserInRole(serverModel) {
    var self = this;
    
    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);
    self.brokenRules = ko.observableArray(serverModel.BrokenRules);

    //server model properties
    self.Id = serverModel.Id;
    self.FullName = serverModel.FullName;
    self.OrdersCount = serverModel.OrdersCount;
    self.PackagesCount = serverModel.PackagesCount;
    self.Email = serverModel.Email;
    self.LastAccessDate = serverModel.LastAccessDate;
}

function AdminDashboardViewModel(serverModel) {
    var self = this;
    var addressModel = JSON.parse(serverModel);
    self.roles = ko.observableArray();
    self.users = ko.observableArray();
    
    $.each(addressModel.Roles, function (index, value) {
        var role = new Role(value);
        self.roles.push(role);
    });
    var initialId = addressModel.Roles[0].Id;
    
    self.changeSelectedRole = function () {
        //load users in role
        self.loadUsersInRole(this.id);
    };
    
    self.loadUsersInRole = function(id){
        $.post("/admin/GetUsersInRole", { "roleId": id }, function (data) {
            var users = ko.toJS(data);
            self.users.removeAll();
            $.each(users, function (index, value) {
                var user = new UserInRole(value);
                self.users.push(user);
            });
        });
    };
    self.loadUsersInRole(initialId);
}