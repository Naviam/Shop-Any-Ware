function Transaction(serverModel) {
    var self = this;

    // default model properties
    self.message = serverModel.Message;
    self.messageType = serverModel.MessageType;
    self.errorCode = serverModel.ErrorCode;
    self.brokenRules = serverModel.BrokenRules;

    //server model properties
    self.operationAmount = serverModel.OperationAmount;
    self.transactionDate = serverModel.DateString;
    self.currency = serverModel.Currency;
    self.transactionStatus = serverModel.StatusTranslated;
    self.operationType = serverModel.OperationType;
    self.operationTypeTranslated = serverModel.OperationTypeTranslated;

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