function Order(shop, orderNumber, trackingNumber) {
    var self = this;
    self.shop = ko.observable(shop);
    self.orderNumber = ko.observable(orderNumber);
    self.trackingNumber = ko.observable(trackingNumber);
    self.status = ko.observable("open");

    self.items = ko.observableArray([
        new Item(null, "Kindle", 1, null, null, 79.43),
        new Item(null, "Sony Vaio", 1, null, null, 990.99)
    ]);

    // Computed data
    self.totalAmount = ko.computed(function () {
        var total = 0;
        for (var n = 0; n < self.items.length; n++)
            total += self.items[n].price;
        return total;
    });

    self.addItem = function(item) {
        self.Items.unshift(item);
    };

    self.removeItem = function (item) {
        for (var i = 0; i < self.items.length; i++) {
            if (item == self.items[i]) {
                self.items.splice(i, 1);
                i--;
            }
        }
    };
}

function Package(description, deliveryAddress, dispatchMethod) {
    var self = this;
    self.description = description;
    self.deliveryAddress = deliveryAddress;
    self.dispatchMethod = dispatchMethod;
};

function Item(url, name, quantity, size, color, price) {
    var self = this;
    self.url = ko.observable(url);
    self.name = ko.observable(name);
    self.size = ko.observable(size);
    self.color = ko.observable(color);
    self.price = ko.observable(price);
    self.quantity = ko.observable(quantity);
    self.photoRequired = ko.observable(false);
    self.photoUrl = null;

    self.addPhoto = function (photoUrl) {
        if (self.photoRequired) {
            self.photoUrl = photoUrl;
        }
    };
}

function DashboardViewModel() {
    var self = this;

    // Non-editable catalog data - would come from the server
    self.orders = ko.observableArray([
        new Order("Amazon", "7732267633", "1Z32863V0307459092"),
        new Order("Victoria Secrets", "7732267634", "1Z32863V0307459091"),
        new Order("Ebay.com", "7732267635", "1Z32863V0307459095")
    ]);

    self.packages = ko.observableArray([
        new Package("my package 1", "my address 1", "EMS Express"),
        new Package("my package 2", "my address 2", "EMS Priority")
    ]);
}
ko.applyBindings(new DashboardViewModel());