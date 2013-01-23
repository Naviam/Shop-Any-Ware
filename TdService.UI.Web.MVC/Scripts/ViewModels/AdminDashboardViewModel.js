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

function PageSettings(roleManagementPermissionsError, canModifyRoles, userFilterValiidationMessage, memberDashboardUrl, shopperRoleCannotBeAssigned, userId, cantModifyOwnRole) {
    this.RoleManagementPermissionsError = roleManagementPermissionsError;
    this.canModifyRoles = canModifyRoles;
    this.userFilterValiidationMessage = userFilterValiidationMessage;
    this.memberDashboardUrl = memberDashboardUrl;
    this.shopperRoleCannotBeAssigned = shopperRoleCannotBeAssigned;
    this.userId = userId;
    this.CantModifyOwnRole = cantModifyOwnRole;
}

function ModalWindowValidationMessages(emailIsRequired, emailIsIncorrect, firstNameIsRequired, lastNameIsRequired, passwordIsRequired, passwordShouldMatch) {
    this.emailIsRequired = emailIsRequired;
    this.emailIsIncorrect = emailIsIncorrect;
    this.firstNameIsRequired = firstNameIsRequired;
    this.lastNameIsRequired = lastNameIsRequired;
    this.passwordIsRequired = passwordIsRequired;
    this.passwordShouldMatch = passwordShouldMatch;
}

//global stuff
var modalWindowValidationMessages;
var pageSettings;

function NewUserViewModel() {
    var self = this;

    self.isAdmin = ko.observable(false);
    self.isOperator = ko.observable(true);
    self.email = ko.observable().extend({ required: { message: modalWindowValidationMessages.emailIsRequired }, email: { message: modalWindowValidationMessages.emailIsIncorrect } });
    self.firstName = ko.observable().extend({ required: { message: modalWindowValidationMessages.firstNameIsRequired } });
    self.lastName = ko.observable().extend({ required: { message: modalWindowValidationMessages.lastNameIsRequired } });
    self.password = ko.observable().extend({ required: { message: modalWindowValidationMessages.passwordIsRequired } });
    self.repeatPassword = ko.observable().extend({ equal: { params: self.password, message: modalWindowValidationMessages.passwordShouldMatch } });
    self.brokenRules = ko.observableArray();
    self.userAdded = false;
    self.errorsVisible = ko.observable(false);

    self.validationModel = ko.validatedObservable({
        email: self.email,
        firstName: self.firstName,
        lastName: self.lastName,
        password: self.password,
        repeatPassword: self.repeatPassword
    });

    self.showPopup = function () {
        self.errorsVisible(false);
        self.brokenRules.removeAll();
        self.email('');
        self.firstName('');
        self.lastName('');
        self.password('');
        self.repeatPassword('');
        self.isAdmin(false);
        self.isOperator(true);
        self.userAdded = false;
        $('#newUserFormModal').modal('show');
    };


    self.saveUser = function () {
        if (!self.validationModel.isValid()) {
            self.errorsVisible(true);
            return;
        }
        $.post("/admin/CreateNewUser", { "Email": self.email, "FirstName": self.firstName, "LastName": self.lastName, "Password": self.password, "IsAdmin": self.isAdmin(), "IsOperator": self.isOperator() }, function (data) {
            var resp = ko.toJS(data);
            if (resp.MessageType != 'Success') {
                self.brokenRules.removeAll();
                self.errorsVisible(true);
                $.each(resp.BrokenRules, function (index, value) {
                    self.brokenRules.push(value.Rule);
                });                
            } else {
                self.userAdded = true;
                $('#newUserFormModal').modal('hide');
            }
        });
    }
}

function Role(serverModel) {
    var self = this;

    //server model properties
    self.roleName = serverModel.NameTranslated;
    self.id = serverModel.Id;
    self.selected = ko.observable(false);
}

function GridRole(id, roleName, userIsInRole) {
    var self = this;

    self.id = id;
    self.roleName = roleName;
    self.userIsInRole = ko.observable(userIsInRole);
}

function UserInRole(serverModel, translatedRolesArray) {
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
    self.Roles = ko.observableArray();


    $.each(translatedRolesArray, function (index, value) {
        if (value.id == -1) return;//all users, not actually a role
        var pos = $.inArray(value.id, serverModel.Roles);
        var gridRole = new GridRole(value.id, value.roleName, pos != -1);
        self.Roles.push(gridRole);
    });

    self.viewShopperDashboard = function () {
        if (!self.UserIsInRole(2)) return; //2 is shopper

        window.open(pageSettings.memberDashboardUrl + '?userEmail=' + self.Email, '_self');
    };

    self.UserIsInRole = function (roleId) {
        var result = false;
        $.each(self.Roles(), function (index, value) {
            if (value.id == roleId && value.userIsInRole())
                result = true;
        });
        return result;
    };

    self.toggleRole = function (gridRole, event) {
        event.originalEvent.stopImmediatePropagation();

        if (!pageSettings.canModifyRoles) {
            window.showNotice(pageSettings.RoleManagementPermissionsError, 'Warning');
            return false;
        }
        if (gridRole.id == 2) {
            window.showNotice(pageSettings.shopperRoleCannotBeAssigned, 'Warning');
            return false;
        }
        if (self.Id == pageSettings.userId) {
            window.showNotice(pageSettings.CantModifyOwnRole, 'Warning');
            return false;
        }
        self.sendRoleChangeRequest(gridRole);
    };

    self.sendRoleChangeRequest = function (gridRole) {
        $.post(gridRole.userIsInRole() ? "/admin/RemoveUserFromRole" : "/admin/AddUserToRole", { "userId": self.Id, "roleId": gridRole.id }, function (data) {
            var resp = ko.toJS(data);
            if (resp.MessageType == 'Error') {
                window.showNotice(resp.Message, resp.MessageType);
                return;
            }
            //update observable array
            $.each(self.Roles(), function (index, value) {
                if (value.id == gridRole.id)
                    value.userIsInRole(!gridRole.userIsInRole());
            });
            window.showNotice(resp.Message, 'Information');
        });
    }
}

function AdminDashboardViewModel(serverModel) {
    var self = this;
    var addressModel = JSON.parse(serverModel);
    self.roles = ko.observableArray();
    self.users = ko.observableArray();
    self.userId = ko.observable();
    self.userEmail = ko.observable().extend({ email: true });;
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
    self.canModifyUserRoles = ko.observable(addressModel.CanModifyUserRoles);

    $.each(addressModel.Roles, function (index, value) {
        var role = new Role(value);
        self.roles.push(role);
    });
    self.roles.unshift({ roleName: addressModel.AllRolesTranslated, id: -1, selected: ko.observable(true) });

    //global class
    pageSettings = new PageSettings(addressModel.RoleManagementPermissionsError, addressModel.CanModifyUserRoles, addressModel.UserFilterValiidationMessage, addressModel.MemberDashBoardUrl,
    addressModel.ShopperRoleCannotBeAssigned, addressModel.UserId, addressModel.CantModifyOwnRole);

    modalWindowValidationMessages = new ModalWindowValidationMessages(addressModel.EmailIsRequired, addressModel.EmailIsIncorrect, addressModel.FirstNameIsRequired,
        addressModel.LastNameIsRequired, addressModel.PasswordIsRequired, addressModel.PasswordShouldMatch);

    self.newUserViewModel = new NewUserViewModel();
    $('#newUserFormModal').bind('hidden', function () {
        if (self.newUserViewModel.userAdded) {
            self.loadUsers();
        }
    });


    self.changeSelectedRole = function () {
        self.currentPage(1);
        //load users in role
        self.currentRole = this.id;
        self.loadUsers();
    };

    self.FilterById = function () {
        if (self.userId == '' || !Number(self.userId())) {
            window.showNotice(pageSettings.userFilterValiidationMessage, 'Warning');
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

    self.FilterByEmail = function () {
        if (self.userEmail() == '' || !self.userEmail.isValid()) {
            window.showNotice(pageSettings.userFilterValiidationMessage, 'Warning');
            return;
        };

        $.post("/admin/GetUserByEmail", { "email": self.userEmail() }, function (data) {
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

    self.changePageSize = function () {
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

    self.movePrevPage = function () {
        self.currentPage(self.currentPage() - 1);
        self.loadUsers();
    };

    self.goToPage = function () {
        if (!self.goToPageIndex.isValid() || self.goToPageIndex() > self.pageCount() || self.goToPageIndex() < 1) {
            window.showNotice(addressModel.GoToPageIndexValidationMessage, 'Warning');
            return;
        }
        var k = self.goToPageIndex();
        self.currentPage(k);

        self.loadUsers();
    };


    self.loadUsers = function () {
        $.post("/admin/GetUsersInRole", { "roleId": self.currentRole, "pageSize": self.selectedPageSize, "pageNumber": self.currentPage }, function (data) {
            var response = ko.toJS(data);
            self.users.removeAll();
            $.each(response.Users, function (index, value) {
                var user = new UserInRole(value, self.roles());
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