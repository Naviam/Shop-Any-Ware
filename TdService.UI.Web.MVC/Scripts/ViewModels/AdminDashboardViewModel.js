ko.bindingHandlers.executeOnEnter = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var allBindings = allBindingsAccessor();
        $(element).keypress(function (event) {
            var keyCode = (event.which ? event.which : event.keyCode);
            if (keyCode === 13) {
                allBindings.executeOnEnter.call(viewModel);
                return false;
            }
            return true;
        });
    }
};

function Role(serverModel) {
    var self = this;

    //server model properties
    self.roleName = serverModel.NameTranslated;
    self.id = serverModel.Id;
}

function GridRole(id, roleName, userIsInRole) {
    var self = this;
    
    self.id = id;
    self.roleName = roleName;
    self.userIsInRole = userIsInRole;
}

function UserInRole(serverModel, translatedRolesArray, memberDashboardUrl) {
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
    self.memberDashboardUrl = memberDashboardUrl;
    self.Roles = ko.observableArray();
    $.each(translatedRolesArray, function (index, value) {
        if (value.id == -1) return;//all users, not actually a role
        var pos = $.inArray(value.id, serverModel.Roles);
        var gridRole = new GridRole(value.id, value.roleName, pos != -1);
        self.Roles.push(gridRole);
    });

    self.viewShopperDashboard = function () {
        if (!self.UserIsInRole(2)) return; //2 is shopper
        
        window.open(self.memberDashboardUrl+'?userEmail='+self.Email, '_blank');
    };

    self.UserIsInRole = function (roleId) {
        var result = false;
        $.each(self.Roles(), function (index, value) {
            if (value.id == roleId && value.userIsInRole)
                result = true;
        });
        return result;
    };
}

function AdminDashboardViewModel(serverModel) {
    var self = this;
    var addressModel = JSON.parse(serverModel);
    self.roles = ko.observableArray();
    self.users = ko.observableArray();
    self.userId = ko.observable();
    self.userFilterValiidationMessage = addressModel.UserFilterValiidationMessage;
    self.userListPageSizes = ko.observableArray(['10', '50', '200']);
    self.selectedPageSize = ko.observable(10);
    self.totalCount = ko.observable(addressModel.TotalCount);
    self.goToPageIndex = ko.observable('').extend({ number: true });
    self.currentRole = -1;//all
    self.currentPage = ko.observable(1);
    self.initializing = true;
    self.pageCount = ko.observable(0);
    self.canMoveNext = ko.observable(false);
    self.canMovePrev = ko.observable(false);
    self.memberDashboardUrl = addressModel.MemberDashBoardUrl;
    
    $.each(addressModel.Roles, function (index, value) {
        var role = new Role(value);
        self.roles.push(role);
    });
    self.roles.unshift({ roleName: addressModel.AllRolesTranslated, id: -1 });
    
    self.changeSelectedRole = function () {
        self.currentPage(1);
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
                var user = new UserInRole(resp, self.roles());
                self.users.push(user);
            }
        });
    };

    self.changePageSize = function() {
        if (self.initializing) {
            self.initializing = false;
            return;
        }
        self.currentPage(1);
        self.loadUsers();
    };
    
    self.moveNextPage = function () {
        self.currentPage(self.currentPage() + 1);
        self.loadUsers();
    };
    
    self.movePrevPage = function() {
        self.currentPage(self.currentPage() - 1);
        self.loadUsers();
    };

    self.goToPage = function() {
        if (!self.goToPageIndex.isValid() || self.goToPageIndex()>self.pageCount() || self.goToPageIndex()<1) {
            window.showNotice(addressModel.GoToPageIndexValidationMessage, 'Warning');
            return;
        }
        var k = self.goToPageIndex();
        self.currentPage(k);
        
        self.loadUsers();
    };

    self.loadUsers = function(){
        $.post("/admin/GetUsersInRole", { "roleId": self.currentRole, "pageSize": self.selectedPageSize, "pageNumber": self.currentPage }, function (data) {
            var response = ko.toJS(data);
            self.users.removeAll();
            $.each(response.Users, function (index, value) {
                var user = new UserInRole(value, self.roles(), self.memberDashboardUrl);
                self.users.push(user);
            });
            if (response.TotalCount == 0) return;

            self.totalCount(response.TotalCount);
            
            if (response.TotalCount <= self.selectedPageSize()) {
                self.pageCount(1);
            }
            else {
                var mod = response.TotalCount % self.selectedPageSize();
                self.pageCount(Math.floor(response.TotalCount / self.selectedPageSize() + (mod != 0 ? 1 : 0)));
            }
            self.canMoveNext(self.currentPage() < self.pageCount());
            self.canMovePrev(self.currentPage() > 1);
        });
    };
    self.loadUsers();
}