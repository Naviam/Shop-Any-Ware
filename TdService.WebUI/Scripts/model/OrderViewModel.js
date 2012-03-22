﻿function Photo(id, itemId, url, description) {
    var self = this;
    self.id = ko.observable(id);
    self.itemId = ko.observable(itemId);
    self.url = ko.observable(url);
    self.description = ko.observable(description);
}

function Item(id, url, name, quantity, size, color, price) {
    var self = this;
    self.id = ko.observable(id);
    self.url = ko.observable(url);
    self.name = ko.observable(name);
    self.size = ko.observable(size);
    self.color = ko.observable(color);
    self.price = ko.observable(price);
    self.quantity = ko.observable(quantity);
}

function Order(id, shop, orderNumber, trackingNumber) {
    var self = this;
    self.id = ko.observable(id);
    self.shop = ko.observable(shop);
    self.orderNumber = ko.observable(orderNumber);
    self.trackingNumber = ko.observable(trackingNumber);
    self.status = ko.observable("open");
    self.receivedDate = new Date();
    self.createdDate = new Date();

    self.items = ko.observableArray([
        new Item(1, null, "Kindle", 1, "7\"", "Gray", 79.43),
        new Item(2, null, "Sony Vaio", 1, "14\"", "Black", 990.00),
        new Item(3, null, "Dell Vostro", 2, "17\"", "White", 1500.00)
    ]);

    self.photos = ko.observableArray([
        new Photo(323, 1, "https://s3.amazonaws.com/prod.tracker2/resource/5405179/Gap_PM_Upload_Error_3-21-12.jpg?AWSAccessKeyId=AKIAIKWOAN6H4H3QMJ6Q&Expires=1332344768&Signature=vPQMREJDEepkyM0H4TE7MmC5u3o%3D", "Photo of the kindle")
    ]);

    // Computed data
    self.totalAmount = ko.computed(function () {
        var total = 0;
        for (var n = 0; n < self.items.length; n++)
            total += self.items[n].price;
        return total;
    });

    self.addItem = function () {
        var item = new Item(4, null, "IPAD 3", 1, "11\"", "White", 809.05);
        self.items.unshift(item);
    };

    self.removeItem = function (item) {
        self.items.remove(item);
    };
}

function Package(id, description, deliveryAddress, dispatchMethod) {
    var self = this;
    self.id = ko.observable(id);
    self.description = ko.observable(description);
    self.deliveryAddress = ko.observable(deliveryAddress);
    self.dispatchMethod = ko.observable(dispatchMethod);
    self.status = ko.observable("Created");
    self.dispatchedDate = ko.observable(new Date());
    self.deliveredDate = ko.observable(new Date());

    self.items = ko.observableArray([
        new Item(1, null, "Kindle", 1, "7\"", "Gray", 79.43),
        new Item(2, null, "Sony Vaio", 1, "14\"", "Black", 990.00),
        new Item(3, null, "Dell Vostro", 2, "17\"", "White", 1500.00)
    ]);

    self.dropItem = function (item) {
        self.items.unshift(item);
    };

    self.removeItem = function (item) {
        self.items.remove(item);
    };
};

function DashboardViewModel() {
    var self = this;

    // Non-editable catalog data - would come from the server
    self.orders = ko.observableArray([
        new Order(1, "Amazon", "7732267633", "1Z32863V0307459092"),
        new Order(2, "Victoria Secrets", "7732267634", "1Z32863V0307459091"),
        new Order(3, "Ebay.com", "7732267635", "1Z32863V0307459095")
    ]);

    self.packages = ko.observableArray([
        new Package(1, "my package 1", "my address 1", "EMS Express"),
        new Package(2, "my package 2", "my address 2", "EMS Priority")
    ]);
}
ko.applyBindings(new DashboardViewModel());