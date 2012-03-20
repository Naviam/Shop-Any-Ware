function Order(shop, orderNumber, trackingNumber) {
    var self = this;
    self.Shop = ko.observable(shop);
    self.OrderNumber = ko.observable(orderNumber);
    self.TrackingNumber = ko.observable(trackingNumber);

    self.Items = ko.observableArray([
        new Item(null, "Kindle", 1, null, null, 79.43),
        new Item(null, "Sony Vaio", 1, null, null, 990.99)
    ]);

    self.addItem = function(item) {
        self.Items.unshift(item);
    };

    self.removeItem = function (item) {
        for (var i = 0; i < self.Items.length; i++) {
            if (item == self.Items[i]) {
                self.Items.splice(i, 1);
                i--;
            }
        }
    };
}

function Item(url, name, quantity, size, color, price) {
    var self = this;
    self.Url = ko.observable(url);
    self.Name = ko.observable(name);
    self.Size = ko.observable(size);
    self.Color = ko.observable(color);
    self.Price = ko.observable(price);
    self.Quantity = ko.observable(quantity);
    self.PhotoRequired = ko.observable(false);
    self.PhotoUrl = null;

    // Computed data
    self.TotalAmount = ko.computed(function () {
        var total = 0;
        for (var n = 0; n < self.Items()[n].length; n++)
            total += self.Items()[n].Price;
        return total;
    });

    self.addPhoto = function (photoUrl) {
        if (self.PhotoRequired) {
            self.PhotoUrl = photoUrl;
        }
    };
}

function OrderViewModel() {
    var self = this;

    // Non-editable catalog data - would come from the server
    self.Orders = ko.observableArray([
        new Order("Amazon", "7732267633", "1Z32863V0307459092"),
        new Order("Victoria Secrets", "7732267633", "1Z32863V0307459092"),
        new Order("Ebay.com", "7732267633", "1Z32863V0307459092")
    ]);
}
ko.applyBindings(new OrderViewModel());