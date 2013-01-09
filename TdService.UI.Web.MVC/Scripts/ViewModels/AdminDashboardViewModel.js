function Role(serverModel) {
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
    self.userId = ko.observable();
    self.userFilterValiidationMessage = addressModel.UserFilterValiidationMessage;
    self.userListPageSizes = ko.observableArray(['2', '50', '100']);
    self.selectedPageSize = ko.observable(2);
    self.currentPage = ko.observable(1);
    
    self.pages = ko.observableArray();
    self.totalCount = ko.observable(addressModel.TotalCount);
    self.currentRole = -1;//all
    self.initializing = true;

    $.each(addressModel.Roles, function (index, value) {
        var role = new Role(value);
        self.roles.push(role);
    });
    self.roles.unshift({ roleName: addressModel.AllRolesTranslated, id: -1 });
    
    
    self.changeSelectedRole = function () {
        //load users in role
        self.currentRole = this.id;
        self.loadUsers();
    };

    self.FilterById = function () {
        if (self.userId == '' || !Number(self.userId())) {
            window.showNotice(self.userFilterValiidationMessage, 'Warning');
            return;
        }

        $.post("/admin/GetUserById", { "userId": self.userId }, function (data) {
            var resp = ko.toJS(data);
            if (resp.MessageType == 'Warning') {
                window.showNotice(resp.Message, resp.MessageType);
            } else {
                self.users.removeAll();
                var user = new UserInRole(resp);
                self.users.push(user);
            }
        });
    };

    self.changePageSize = function() {
        if (self.initializing) {
            self.initializing = false;
            return;
        }
        
        self.loadUsers();
    };

    self.loadUsers = function(){
        $.post("/admin/GetUsersInRole", { "roleId": self.currentRole, "pageSize": self.selectedPageSize, "pageNumber": self.currentPage }, function (data) {
            var response = ko.toJS(data);
            self.users.removeAll();
            $.each(response.Users, function (index, value) {
                var user = new UserInRole(value);
                self.users.push(user);
            });
            self.totalCount(response.TotalCount);
        });
    };
    self.loadUsers();
}