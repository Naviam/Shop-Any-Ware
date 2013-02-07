function Transaction(serverModel) {
    var self = this;

    // default model properties
    self.message = ko.observable(serverModel.Message);
    self.messageType = ko.observable(serverModel.MessageType);
    self.errorCode = ko.observable(serverModel.ErrorCode);
    self.brokenRules = ko.observableArray(serverModel.BrokenRules);

    //server model properties
    self.operationAmount = ko.observable(serverModel.OperationAmount);
    self.transactionDate = ko.observable(formatDate(serverModel.Date));
    self.currency = ko.observable(serverModel.Currency);
    self.transactionStatus = ko.observable(serverModel.StatusTranslated);
    self.transactionStatusCssClass = ko.computed(function () {
        switch (serverModel.TransactionStatus) {
            case 'Approved':
                return 'label-success';
            case 'InProgress':
            case 'Pending':
                return 'label-warning';
            case 'Failed':
                return 'label-important';
            default:
                return '';
        }
    }, self);
}