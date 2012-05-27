pavlov.specify("OrderViewModel", function () {
    describe("View My Orders", function () {
        var sampleOrders;
        var recentExpected;

        before(function () {
            var order1 = new Order("Amazon, inc.");
            order1.status("received");
            order1.createdDate = new Date().addDays(-39);
            order1.receivedDate = new Date().addDays(-31);
            var order2 = new Order("Apple, Inc.");
            order2.status("received");
            order1.createdDate = new Date().addDays(-36);
            order2.receivedDate = new Date().addDays(-30);
            var order3 = new Order("JCPenny");
            order3.status("received");
            order1.createdDate = new Date().addDays(-60);
            order3.receivedDate = new Date().addDays(-56);
            var order4 = new Order("JCPenny");
            order4.status("received");
            order1.createdDate = new Date().addDays(-40);
            order4.receivedDate = new Date().addDays(-26);
            var order5 = new Order("Apple, Inc.");
            order5.status("received");
            order1.createdDate = new Date().addDays(-29);
            order5.receivedDate = new Date().addDays(-10);
            var order6 = new Order("Apple, Inc.");
            order6.status("waiting");
            order1.createdDate = new Date().addDays(-9);
            order6.receivedDate = null;
            var order7 = new Order("Amazon, Inc.");
            order7.status("waiting");
            order1.createdDate = new Date().addDays(-3);
            order7.receivedDate = null;
            sampleOrders = [order1, order2, order3, order4, order5, order6, order7];

            recentExpected = [order2, order4, order5, order6, order7];
        });

        it("should see orders passed to view model constructor", function () {
            var model = new OrderViewModel(sampleOrders);
            assert(model.orders().length).equals(sampleOrders.length);
        });

        it("should be able not to pass orders to view model constructor", function () {
            var model = new OrderViewModel();
            assert(model.orders().length).equals(0);
        });

        //        given(["Amazon, Inc."], ["Apple, Inc."], ["JC Penny"]).
        //        it("Should be able to add new order by specifying shop name", function (shopName) {
        //            var model = new OrderViewModel(sampleOrders);
        //            model.newOrder(shopName);
        //            model.addOrder();
        //            var result = $.Enumerable.From(model.orders()).Where(function (x) {
        //                return x.shop() == shopName;
        //            }).ToArray();
        //            assert(result.length).equals(1);
        //            //assert(result()[0]).equals(order);
        //        });

        it("should be sorted by createdDate beginning the most recently created order", function () {
            var model = new OrderViewModel(sampleOrders);
            model.orders().sort(function (a, b) {
                return a.createdDate < b.createdDate;
            });
            var sorted = $.Enumerable.From(model.orders()).OrderByDescending("$.receivedDate").ToArray();
            assert(model.orders()).isSameAs(sorted(), "the sorting order of orders should be by receivedDate desc");
        });

        //        it("Should see my recent (waiting or received less than 30 days ago) orders", function () {
        //            var model = new OrderViewModel(sampleOrders);
        //            model.recentDaysToShow = 30;
        //            assert(model.recentOrders().length).equals(recentExpected.length);
        //            //deepEqual(model.recentOrders, recentExpected);
        //            //assert(recentExpected.length, model.recentOrders.length);
        //        });
    });

    describe("Add Order", function () {
        given(["Apple, Inc.", "Amazon, Inc."]).
        it("should be able to add order when shop name was submitted", function (shopName) {
            var model = new OrderViewModel();
            model.newOrder(shopName);
            var result = model.addOrder();
            assert(result).isTrue("addOrder returns true");
            assert(model.orders.pop().shop()).equals(shopName, "shop namebbZCZZASS should be same as in given");
        });

        given([""]).
        it("should not be able to add order when empty shop name was submitted", function (shopName) {
            var model = new OrderViewModel();
            model.newOrder(shopName);
            var result = model.addOrder();
            assert(result).isFalse("addOrder returns false");
            assert(model.orders.pop()).isUndefined("pop method on orders array should be undefined");
        });

        given("https://haha").
        it("should be advised to check url if text looks like url but was not validated", function (url) {
            var model = new OrderViewModel();
            model.newOrder(url);
            var result = model.addOrder();
            assert(result).isFalse("addOrder returns false");
            assert(model.orders.pop()).isUndefined("pop method on orders array should be undefined");
        });
    });

    describe("Remove Order", function () {
        it("should be able to remove order in created status", function () {
            var createdOrder = new Order("Apple, Inc.");
            createdOrder.status(OrderStatus.Created);
            var model = new OrderViewModel([createdOrder]);
            var result = model.removeOrder(createdOrder);
            assert(result).equals(true, "removeOrder returns true");
            assert(model.orders().length).equals(0, "should be no orders left in the collection");
        });

        it("should not be able to remove order in processed status", function () {
            var processedOrder = new Order("Apple, Inc.");
            processedOrder.status(OrderStatus.Processed);
            var model = new OrderViewModel([processedOrder]);
            var result = model.removeOrder(processedOrder);
            assert(result).equals(false, "removeOrder returns false");
            assert(model.orders().length).equals(1, "should be a single order left in the collection");
        });

        it("should not be able to remove order in received status", function () {
            var receivedOrder = new Order("Apple, Inc.");
            receivedOrder.status(OrderStatus.Received);
            var model = new OrderViewModel([receivedOrder]);
            var result = model.removeOrder(receivedOrder);
            assert(result).equals(false, "removeOrder returns false");
            assert(model.orders().length).equals(1, "should be a single order left in the collection");
        });
    });
});