﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TdService.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Shopper Orders")]
    [NUnit.Framework.CategoryAttribute("orders")]
    public partial class ShopperOrdersFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShopperOrders.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Shopper Orders", "In order to let operator know about incoming orders\r\nAs a shopper\r\nI want to be a" +
                    "ble to add new orders, remove them and update with tracking number and order num" +
                    "ber", ProgrammingLanguage.CSharp, new string[] {
                        "orders"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View my recent orders")]
        [NUnit.Framework.CategoryAttribute("viewrecentorders")]
        public virtual void ViewMyRecentOrders()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View my recent orders", new string[] {
                        "viewrecentorders"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table1.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "773456789012345",
                        "New"});
            table1.AddRow(new string[] {
                        "2",
                        "6pm.com",
                        "123453453455",
                        "673456789012345",
                        "Received"});
            table1.AddRow(new string[] {
                        "3",
                        "zazzle.com",
                        "125675575445",
                        "344567895675664",
                        "Returned"});
            table1.AddRow(new string[] {
                        "4",
                        "yoox.com",
                        "455367456655",
                        "34567893442345",
                        "Disposed"});
            table1.AddRow(new string[] {
                        "5",
                        "zappos.com",
                        "234345454433",
                        "123456789012345",
                        "Received"});
            table1.AddRow(new string[] {
                        "6",
                        "zappos.com",
                        "453656457544",
                        "245763453445463",
                        "ReturnRequested"});
#line 11
 testRunner.And("I have the following orders", ((string)(null)), table1, "And ");
#line 19
 testRunner.When("I go to my recent orders tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table2.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "773456789012345",
                        "New",
                        "True",
                        "True",
                        "False",
                        "True",
                        "Success"});
            table2.AddRow(new string[] {
                        "2",
                        "6pm.com",
                        "123453453455",
                        "673456789012345",
                        "Received",
                        "False",
                        "False",
                        "True",
                        "False",
                        "Success"});
            table2.AddRow(new string[] {
                        "5",
                        "zappos.com",
                        "234345454433",
                        "123456789012345",
                        "Received",
                        "False",
                        "False",
                        "True",
                        "False",
                        "Success"});
            table2.AddRow(new string[] {
                        "6",
                        "zappos.com",
                        "453656457544",
                        "245763453445463",
                        "ReturnRequested",
                        "False",
                        "False",
                        "False",
                        "False",
                        "Success"});
#line 20
 testRunner.Then("the order view models should be as follows", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("View my history orders")]
        [NUnit.Framework.CategoryAttribute("viewhistoryorders")]
        public virtual void ViewMyHistoryOrders()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View my history orders", new string[] {
                        "viewhistoryorders"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table3.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "773456789012345",
                        "New"});
            table3.AddRow(new string[] {
                        "2",
                        "6pm.com",
                        "123453453455",
                        "673456789012345",
                        "Received"});
            table3.AddRow(new string[] {
                        "3",
                        "zazzle.com",
                        "125675575445",
                        "344567895675664",
                        "Returned"});
            table3.AddRow(new string[] {
                        "4",
                        "yoox.com",
                        "455367456655",
                        "34567893442345",
                        "Disposed"});
            table3.AddRow(new string[] {
                        "5",
                        "zappos.com",
                        "234345454433",
                        "123456789012345",
                        "Received"});
            table3.AddRow(new string[] {
                        "6",
                        "zappos.com",
                        "453656457544",
                        "245763453445463",
                        "ReturnRequested"});
#line 31
 testRunner.And("I have the following orders", ((string)(null)), table3, "And ");
#line 39
 testRunner.When("I go to my history orders tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table4.AddRow(new string[] {
                        "3",
                        "zazzle.com",
                        "125675575445",
                        "344567895675664",
                        "Returned",
                        "False",
                        "False",
                        "False",
                        "False",
                        "Success"});
            table4.AddRow(new string[] {
                        "4",
                        "yoox.com",
                        "455367456655",
                        "34567893442345",
                        "Disposed",
                        "False",
                        "False",
                        "False",
                        "False",
                        "Success"});
#line 40
 testRunner.Then("the order view models should be as follows", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new order")]
        [NUnit.Framework.CategoryAttribute("addorder")]
        public virtual void AddNewOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new order", new string[] {
                        "addorder"});
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I set retailer url as \'amazon.com\' and press add order button on shopper dashboar" +
                    "d page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table5.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "",
                        "",
                        "New",
                        "True",
                        "True",
                        "False",
                        "True",
                        "Success"});
#line 50
 testRunner.Then("the order view model should be as follows", ((string)(null)), table5, "Then ");
#line 53
 testRunner.And("the order view model should have Created Date that is earlier than UTC Now", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new order reusing existent retailer instead of creating new one")]
        [NUnit.Framework.CategoryAttribute("addorder")]
        public virtual void AddNewOrderReusingExistentRetailerInsteadOfCreatingNewOne()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new order reusing existent retailer instead of creating new one", new string[] {
                        "addorder"});
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 58
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table6.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "773456789012345",
                        "New"});
#line 59
 testRunner.And("I have the following orders", ((string)(null)), table6, "And ");
#line 62
 testRunner.When("I set retailer url as \'amazon.com\' and press add order button on shopper dashboar" +
                    "d page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table7.AddRow(new string[] {
                        "2",
                        "amazon.com",
                        "",
                        "",
                        "",
                        "New",
                        "True",
                        "True",
                        "False",
                        "True",
                        "Success"});
#line 63
 testRunner.Then("the order view model should be as follows", ((string)(null)), table7, "Then ");
#line 66
 testRunner.And("there must be only one db record with \'amazon.com\' retailer url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new order validate retailer url is required")]
        [NUnit.Framework.CategoryAttribute("addorder")]
        public virtual void AddNewOrderValidateRetailerUrlIsRequired()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new order validate retailer url is required", new string[] {
                        "addorder"});
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.When("I set retailer url as \'\' and press add order button on shopper dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table8.AddRow(new string[] {
                        "0",
                        "",
                        "",
                        "",
                        "",
                        "New",
                        "False",
                        "False",
                        "False",
                        "False",
                        "Warning"});
#line 73
 testRunner.Then("the order view model should be as follows", ((string)(null)), table8, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table9.AddRow(new string[] {
                        "RetailerUrl",
                        "OrderRetailerRequired"});
#line 76
 testRunner.And("the order view model should have the following errors", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add new order validate retailer max length")]
        [NUnit.Framework.CategoryAttribute("addorder")]
        public virtual void AddNewOrderValidateRetailerMaxLength()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new order validate retailer max length", new string[] {
                        "addorder"});
#line 81
this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 83
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When(@"I set retailer url as 'this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses' and press add order button on shopper dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Can Be Modified",
                        "Can Be Removed",
                        "Can Be Requested For Return",
                        "Can Items Be Modified",
                        "Message Type"});
            table10.AddRow(new string[] {
                        "0",
                        @"this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses this is the very long an unusual retailer url that is not actually a url but a long text that exceeds the maximum allowed length for url addresses",
                        "",
                        "",
                        "",
                        "New",
                        "False",
                        "False",
                        "False",
                        "False",
                        "Warning"});
#line 85
 testRunner.Then("the order view model should be as follows", ((string)(null)), table10, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table11.AddRow(new string[] {
                        "RetailerUrl",
                        "RetailerUrlMaxLength"});
#line 88
 testRunner.And("the order view model should have the following errors", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update order in new status")]
        [NUnit.Framework.CategoryAttribute("updateorder")]
        public virtual void UpdateOrderInNewStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update order in new status", new string[] {
                        "updateorder"});
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table12.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "123456789012345",
                        "New"});
#line 96
 testRunner.And("I have the following orders", ((string)(null)), table12, "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table13.AddRow(new string[] {
                        "1",
                        "098765432109",
                        "1234",
                        "New"});
#line 99
 testRunner.When("I update order as follows", ((string)(null)), table13, "When ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Order Number",
                        "Tracking Number",
                        "Status",
                        "Message Type"});
            table14.AddRow(new string[] {
                        "1",
                        "098765432109",
                        "1234",
                        "New",
                        "Success"});
#line 102
 testRunner.Then("the order view model should be as follows", ((string)(null)), table14, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update order in new status validate fields max length")]
        [NUnit.Framework.CategoryAttribute("updateorder")]
        public virtual void UpdateOrderInNewStatusValidateFieldsMaxLength()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update order in new status validate fields max length", new string[] {
                        "updateorder"});
#line 107
this.ScenarioSetup(scenarioInfo);
#line 108
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 109
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table15.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "123456789012345",
                        "New"});
#line 110
 testRunner.And("I have the following orders", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table16.AddRow(new string[] {
                        "1",
                        "098765432109098765432109098765432109098765432109",
                        "123456789012345123456789012345123456789012345123456789012345",
                        "New"});
#line 113
 testRunner.When("I update order as follows", ((string)(null)), table16, "When ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Order Number",
                        "Tracking Number",
                        "Status",
                        "Message Type"});
            table17.AddRow(new string[] {
                        "1",
                        "098765432109098765432109098765432109098765432109",
                        "123456789012345123456789012345123456789012345123456789012345",
                        "New",
                        "Warning"});
#line 116
 testRunner.Then("the order view model should be as follows", ((string)(null)), table17, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table18.AddRow(new string[] {
                        "OrderNumber",
                        "OrderOrderNumberMaxLength"});
            table18.AddRow(new string[] {
                        "TrackingNumber",
                        "OrderTrackingNumberMaxLength"});
#line 119
 testRunner.And("the order view model should have the following errors", ((string)(null)), table18, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove order in new status")]
        [NUnit.Framework.CategoryAttribute("removeorder")]
        public virtual void RemoveOrderInNewStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove order in new status", new string[] {
                        "removeorder"});
#line 125
this.ScenarioSetup(scenarioInfo);
#line 126
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 127
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status"});
            table19.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "",
                        "",
                        "New"});
#line 128
 testRunner.And("I have the following orders", ((string)(null)), table19, "And ");
#line 131
 testRunner.When("I remove order with id \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Message Type"});
            table20.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Success"});
#line 132
 testRunner.Then("the order view model should be as follows", ((string)(null)), table20, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove order in other status than new should not be possible")]
        [NUnit.Framework.CategoryAttribute("removeorder")]
        public virtual void RemoveOrderInOtherStatusThanNewShouldNotBePossible()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove order in other status than new should not be possible", new string[] {
                        "removeorder"});
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 139
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status"});
            table21.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "",
                        "",
                        "Received"});
            table21.AddRow(new string[] {
                        "2",
                        "6pm.com",
                        "",
                        "",
                        "",
                        "Returned"});
            table21.AddRow(new string[] {
                        "3",
                        "apple.com",
                        "",
                        "",
                        "",
                        "ReturnRequested"});
            table21.AddRow(new string[] {
                        "4",
                        "zappos.com",
                        "",
                        "",
                        "",
                        "Disposed"});
#line 140
 testRunner.And("I have the following orders", ((string)(null)), table21, "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id"});
            table22.AddRow(new string[] {
                        "1"});
            table22.AddRow(new string[] {
                        "2"});
            table22.AddRow(new string[] {
                        "3"});
            table22.AddRow(new string[] {
                        "4"});
#line 146
 testRunner.When("I remove the following orders", ((string)(null)), table22, "When ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Message Type",
                        "Error Code"});
            table23.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error",
                        "OrderCannotBeRemoved"});
            table23.AddRow(new string[] {
                        "2",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error",
                        "OrderCannotBeRemoved"});
            table23.AddRow(new string[] {
                        "3",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error",
                        "OrderCannotBeRemoved"});
            table23.AddRow(new string[] {
                        "4",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error",
                        "OrderCannotBeRemoved"});
#line 152
 testRunner.Then("the order view models should be as follows", ((string)(null)), table23, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove order that does not exist")]
        [NUnit.Framework.CategoryAttribute("removeorder")]
        public virtual void RemoveOrderThatDoesNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove order that does not exist", new string[] {
                        "removeorder"});
#line 160
this.ScenarioSetup(scenarioInfo);
#line 161
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 162
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status"});
            table24.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "",
                        "",
                        "",
                        "New"});
#line 163
 testRunner.And("I have the following orders", ((string)(null)), table24, "And ");
#line 166
 testRunner.When("I remove order with id \'2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer Url",
                        "Order Number",
                        "Tracking Number",
                        "Received Date",
                        "Status",
                        "Message Type",
                        "Error Code"});
            table25.AddRow(new string[] {
                        "2",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error",
                        "OrderNotBelongToUser"});
#line 167
 testRunner.Then("the order view model should be as follows", ((string)(null)), table25, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
