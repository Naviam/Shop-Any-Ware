Date.prototype.addDays = function(n) {
    this.setDate(this.getDate() + n);
    return this;
};

function Item(itemUrl) {
    /// <summary>
    ///     A particular item in the order or package.
    /// </summary>
    /// <param name="itemUrl" type="String">
    ///     The url that points to an item in a shop website.
    /// </param>
    var self = this;
    self.url = ko.observable(itemUrl);
    self.name = ko.observable("");
    self.size = ko.observable("");
    self.color = ko.observable("");
    self.quantity = ko.observable(1);
    self.price = ko.observable(0);
}

var OrderStatus = { Created: 0, Processed: 1, Received: 2 };

function Order(shopName, items) {
    /// <summary>
    ///     An order from online shop.
    /// </summary>
    /// <param name="shopName" type="String">
    ///     Name of online shop where the order is from.
    /// </param>
    /// <param name="items" type="Array">
    ///     Optional collection of initial items in the order.
    /// </param>
    var self = this;
    self.id = ko.observable();
    self.shop = ko.observable(shopName);
    self.orderNumber = ko.observable("");
    self.trackingNumber = ko.observable("");
    self.status = ko.observable(OrderStatus.Created);
    self.createdDate = new Date();
    self.receivedDate = new Date();
    self.items = ko.observableArray(items);

    self.update = function (shop, orderNumber, trackingNumber, status, createdDate, receivedDate) {
        /// <summary>Update order parameters.</summary>
        self.shop(shop);
        self.orderNumber(orderNumber);
        self.trackingNumber(trackingNumber);
        self.status(status);
        self.createdDate = createdDate;
        self.receivedDate = receivedDate;
    };

    self.process = function () {
        /// <summary>Process order on arrival. This will possibly be not a UI function.</summary>
        self.status("received");
        self.receivedDate = new Date();
    };
}

function OrderViewModel(orders) {
    /// <summary>
    ///     View model that describes orders behavior.
    /// </summary>
    /// <param name="orders" type="Array">
    ///     Optional collection of initial orders.
    /// </param>
    var self = this;
    self.newOrder = ko.observable("");
    self.recentDaysToShow = ko.observable(30);
    self.orders = ko.observableArray((orders == undefined) ? [] : orders);

    self.addOrder = function () {
        /// <summary>Add new order.</summary>
        if (/^([a-z]([a-z]|\d|\+|-|\.)*):(\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?((\[(|(v[\da-f]{1,}\.(([a-z]|\d|-|\.|_|~)|[!\$&'\(\)\*\+,;=]|:)+))\])|((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=])*)(:\d*)?)(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*|(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)|((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)|((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)){0})(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i.test(self.newOrder())) {
            var order = new Order("", [new Item(self.newOrder())]);
            //order.addItemUrl(self.newOrder());
            self.orders.unshift(order);
        } else if (self.newOrder() != null && self.newOrder() != undefined && self.newOrder() != "") {
            self.orders.unshift(new Order(self.newOrder()));
        }
        self.newOrder("");
        //$("#orders").getNiceScroll().resize();
    };

    self.removeOrder = function (order) {
        /// <summary>Remove the order.</summary>
        /// <param name="order">Order to remove.</param>
        if (order.status() == OrderStatus.Created) {
            self.orders.remove(order);
            return true;
        } else {
            return false;
        }
    };
}

ko.applyBindings(new OrderViewModel());