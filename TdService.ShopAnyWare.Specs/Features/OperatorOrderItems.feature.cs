﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18010
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TdService.ShopAnyWare.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Operator Order Items")]
    [NUnit.Framework.CategoryAttribute("orders")]
    [NUnit.Framework.CategoryAttribute("items")]
    public partial class OperatorOrderItemsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "OperatorOrderItems.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Operator Order Items", "In order to let shopper know about received orders\r\nAs an operator\r\nI want to be " +
                    "able to add, update and remove items for shopper orders in new status", ProgrammingLanguage.CSharp, new string[] {
                        "orders",
                        "items"});
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
        [NUnit.Framework.DescriptionAttribute("Add item to an order")]
        [NUnit.Framework.CategoryAttribute("addorderitem")]
        public virtual void AddItemToAnOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add item to an order", new string[] {
                        "addorderitem"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Operato" +
                    "r\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "1234567890",
                        "1234567890",
                        "New"});
            table1.AddRow(new string[] {
                        "2",
                        "macys.com",
                        "1234567891",
                        "1234567891",
                        "Received"});
#line 11
 testRunner.And("there are following orders in database", ((string)(null)), table1, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight Pounds",
                        "Weight Ounces"});
            table2.AddRow(new string[] {
                        "IPAD3",
                        "1",
                        "780.40",
                        "600",
                        "20"});
            table2.AddRow(new string[] {
                        "Kindle",
                        "5",
                        "130.95",
                        "200",
                        "10"});
#line 15
 testRunner.When("I add the following items to order \'1\'", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Order Id",
                        "Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight Pounds",
                        "Weight Ounces",
                        "Message Type"});
            table3.AddRow(new string[] {
                        "1",
                        "1",
                        "IPAD3",
                        "1",
                        "780.40",
                        "600",
                        "20",
                        "Success"});
            table3.AddRow(new string[] {
                        "1",
                        "2",
                        "Kindle",
                        "5",
                        "130.95",
                        "200",
                        "10",
                        "Success"});
#line 19
 testRunner.Then("the order item view model should be as follows", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove item from an order")]
        [NUnit.Framework.CategoryAttribute("removeorderitem")]
        public virtual void RemoveItemFromAnOrder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove item from an order", new string[] {
                        "removeorderitem"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
    testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Operato" +
                    "r\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
    testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table4.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "1234567890",
                        "1234567890",
                        "New"});
            table4.AddRow(new string[] {
                        "2",
                        "macys.com",
                        "1234567891",
                        "1234567891",
                        "Received"});
#line 28
    testRunner.And("there are following orders in database", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight Pounds",
                        "Weight Ounces"});
            table5.AddRow(new string[] {
                        "1",
                        "IPAD3",
                        "1",
                        "780.40",
                        "600",
                        "10"});
            table5.AddRow(new string[] {
                        "2",
                        "Kindle",
                        "5",
                        "130.95",
                        "200",
                        "12"});
#line 32
    testRunner.And("there are following items for order \'1\' in database", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Order Id",
                        "Id"});
            table6.AddRow(new string[] {
                        "1",
                        "1"});
#line 36
    testRunner.When("I remove the following order items", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Order Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight Pounds",
                        "Weight Ounces",
                        "Message Type"});
            table7.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Success"});
#line 39
    testRunner.Then("the order item view model should be as follows", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update order item")]
        [NUnit.Framework.CategoryAttribute("updateorderitem")]
        public virtual void UpdateOrderItem()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update order item", new string[] {
                        "updateorderitem"});
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
    testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Operato" +
                    "r\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
    testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Retailer",
                        "Order Number",
                        "Tracking Number",
                        "Status"});
            table8.AddRow(new string[] {
                        "1",
                        "amazon.com",
                        "1234567890",
                        "1234567890",
                        "New"});
            table8.AddRow(new string[] {
                        "2",
                        "macys.com",
                        "1234567891",
                        "1234567891",
                        "Received"});
#line 47
    testRunner.And("there are following orders in database", ((string)(null)), table8, "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight"});
            table9.AddRow(new string[] {
                        "1",
                        "IPAD3",
                        "1",
                        "780.40",
                        "600"});
            table9.AddRow(new string[] {
                        "2",
                        "Kindle",
                        "5",
                        "130.95",
                        "200"});
#line 51
    testRunner.And("there are following items for order \'1\' in database", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight"});
            table10.AddRow(new string[] {
                        "1",
                        "IPAD2",
                        "2",
                        "780.00",
                        "670"});
            table10.AddRow(new string[] {
                        "2",
                        "Kindle3",
                        "1",
                        "100.00",
                        "320"});
#line 55
    testRunner.When("I update items of order \'1\' as follows", ((string)(null)), table10, "When ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Order Id",
                        "Id",
                        "Name",
                        "Quantity",
                        "Price",
                        "Weight",
                        "Message Type"});
            table11.AddRow(new string[] {
                        "1",
                        "1",
                        "IPAD2",
                        "2",
                        "780.00",
                        "670",
                        "Success"});
            table11.AddRow(new string[] {
                        "1",
                        "2",
                        "Kindle3",
                        "1",
                        "100.00",
                        "320",
                        "Success"});
#line 59
    testRunner.Then("the order item view model should be as follows", ((string)(null)), table11, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
