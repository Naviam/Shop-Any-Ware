function Shop(id, name, category) {
    var self = this;
    self.id = ko.observable(id);
    self.name = ko.observable(name);
    self.category = ko.observable(category);
}

function Photo(id, itemId, url, description) {
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
    self.currency = ko.observable("USD");
    self.quantity = ko.observable(quantity);

    self.hideItem = function (element) {
        if (elem.nodeType === 1) $(elem).slideUp(function() { $(elem).remove(); });
    };
}

function Order(id, shop, orderNumber, trackingNumber) {
    var self = this;
    self.id = ko.observable(id);
    self.shop = ko.observable(shop);
    self.orderNumber = ko.observable(orderNumber);
    self.trackingNumber = ko.observable(trackingNumber);
    self.status = ko.observable("open");
    self.receivedDate = new Date().toDateString();
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
    self.totalAmount = ko.computed({
        read: function () {
            var total = 0;
            for (var n = 0; n < self.items.length; n++)
                total += self.items[n].price;
            return total;
        } 
    });

    self.myDropCallback = function(arg) {
        if (console) {
            console.log("Moved '" + arg.item.name() + "' from " + arg.sourceParent.id + " (index: " + arg.sourceIndex + ") to " + arg.targetParent.id + " (index " + arg.targetIndex + ")");
        }
    };

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

    self.addOrder = function () {
        self.orders.unshift(new Order(1, "Amazon.com Inc", "78793773", "1Z32863V0307459091"));
    };

    self.removeOrder = function () {
        self.orders.remove(this);
    };

    self.packages = ko.observableArray([
        new Package(1, "my package 1", "my address 1", "EMS Express"),
        new Package(2, "my package 2", "my address 2", "EMS Priority")
    ]);

    self.shops = ko.observableArray([
        new Shop(1, "Amazon.com Inc", "Mass Merchant"),
        new Shop(2, "Staples Inc", "Office Supplies"),
        new Shop(3, "Apple Inc", "Computers / Electronics"),
        new Shop(4, "Dell Inc", "Computers / Electronics"),
        new Shop(5, "Office Depot Inc", "Office Supplies"),
        new Shop(6, "Walmart.com", "Mass Merchant"),
        new Shop(7, "Sears Holdings Corp", "Mass Merchant"),
        new Shop(8, "Liberty Media Corp (QVC, Liberty E-Commerce)", "Mass Merchant"),
        new Shop(9, "OfficeMax Inc", "Office Supplies"),
        new Shop(10, "CDW Corp", "Computers / Electronics"),
        new Shop(11, "Best Buy Co", "Computers / Electronics"),
        new Shop(12, "Newegg Inc", "Computers / Electronics"),
        new Shop(13, "Netflix Inc", "Books / Music / Videos"),
        new Shop(14, "SonyStyle.com", "Computers / Electronics"),
        new Shop(15, "W.W. Grainger Inc", "Hardware / Home Improvement"),
        new Shop(16, "Costco Wholesale Corp", "Mass Merchant"),
        new Shop(17, "Macy’s Inc", "Mass Merchant"),
        new Shop(18, "Victoria’s Secret Direct & Bath and Body Works", "Apparel / Accessories"),
        new Shop(19, "HP Home & Home Office Store", "Computers / Electronics"),
        new Shop(20, "J.C. Penney Co. Inc", "Mass Merchant"),
        new Shop(21, "L.L. Bean Inc", "Apparel / Accessories"),
        new Shop(22, "Target Corp", "Mass Merchant")
    ]);

    ko.bindingHandlers.autosuggest = {
        init: function (element, valueAccessor, allBindingAccessors, model) {
            var shopNames = $.map(model.shops(), function (n) {
                return n.name();
            });
            $(element).typeahead({ source: shopNames });
        }
    };

    // Here's a custom Knockout binding that makes elements shown/hidden via jQuery's fadeIn()/fadeOut() methods
    // Could be stored in a separate utility library
    ko.bindingHandlers.fadeVisible = {
        init: function (element, valueAccessor) {
            // Initially set the element to be instantly visible/hidden depending on the value
            var value = valueAccessor();
            $(element).toggle(ko.utils.unwrapObservable(value)); // Use "unwrapObservable" so we can handle values that may or may not be observable
        },
        update: function (element, valueAccessor) {
            // Whenever the value subsequently changes, slowly fade the element in or out
            var value = valueAccessor();
            ko.utils.unwrapObservable(value) ? $(element).fadeIn() : $(element).fadeOut();
        }
    };
}
ko.applyBindings(new DashboardViewModel());