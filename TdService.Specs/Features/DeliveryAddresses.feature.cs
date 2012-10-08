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
    [NUnit.Framework.DescriptionAttribute("Delivery Addresses")]
    [NUnit.Framework.CategoryAttribute("deliveryaddresses")]
    public partial class DeliveryAddressesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeliveryAddresses.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delivery Addresses", "In order to choose delivery address for my packages\r\nAs a shopper\r\nI want to be a" +
                    "ble to view, add, edit and remove my delivery addresses", ProgrammingLanguage.CSharp, new string[] {
                        "deliveryaddresses"});
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
        [NUnit.Framework.DescriptionAttribute("View own delivery addresses")]
        [NUnit.Framework.CategoryAttribute("viewdeliveryaddresses")]
        public virtual void ViewOwnDeliveryAddresses()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View own delivery addresses", new string[] {
                        "viewdeliveryaddresses"});
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
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table1.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "Minsk - Novovilenskaya",
                        "Novovilenskaya street",
                        "10, 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630"});
            table1.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "Minsk - Nekrasova",
                        "Nekrasova street",
                        "8, 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "+375295067630"});
            table1.AddRow(new string[] {
                        "3",
                        "Patric",
                        "Gutie",
                        "France - Paris",
                        "Elisei",
                        "14/3, 45",
                        "Paris",
                        "France",
                        "",
                        "",
                        "12040",
                        "+455295067630"});
#line 11
 testRunner.And("I have the following delivery addresses", ((string)(null)), table1, "And ");
#line 16
 testRunner.When("I get my own delivery addresses", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table2.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "Minsk - Novovilenskaya",
                        "Novovilenskaya street",
                        "10, 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630"});
            table2.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "Minsk - Nekrasova",
                        "Nekrasova street",
                        "8, 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "+375295067630"});
            table2.AddRow(new string[] {
                        "3",
                        "Patric",
                        "Gutie",
                        "France - Paris",
                        "Elisei",
                        "14/3, 45",
                        "Paris",
                        "France",
                        "",
                        "",
                        "12040",
                        "+455295067630"});
#line 17
 testRunner.Then("I should have the following delivery addresses as a result", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add delivery address")]
        [NUnit.Framework.CategoryAttribute("adddeliveryaddress")]
        public virtual void AddDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add delivery address", new string[] {
                        "adddeliveryaddress"});
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table3.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "Initial",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
#line 27
 testRunner.And("I have the following delivery addresses", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table4.AddRow(new string[] {
                        "",
                        "Vitali",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
            table4.AddRow(new string[] {
                        "",
                        "Vitali",
                        "Hatalski",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "Minsk",
                        "Minsk",
                        "220053",
                        "+375295067630",
                        ""});
            table4.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630",
                        ""});
#line 30
 testRunner.When("I add the following delivery addresses", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table5.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        "Success"});
            table5.AddRow(new string[] {
                        "3",
                        "Vitali",
                        "Hatalski",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "Minsk",
                        "Minsk",
                        "220053",
                        "+375295067630",
                        "Success"});
            table5.AddRow(new string[] {
                        "0",
                        "",
                        "",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630",
                        "Warning"});
#line 35
 testRunner.Then("I should have the following delivery addresses as a result", ((string)(null)), table5, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate required fields when adding delivery address")]
        [NUnit.Framework.CategoryAttribute("adddeliveryaddress")]
        public virtual void ValidateRequiredFieldsWhenAddingDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate required fields when adding delivery address", new string[] {
                        "adddeliveryaddress"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table6.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "Initial",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        ""});
#line 45
 testRunner.And("I have the following delivery addresses", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table7.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""});
#line 48
 testRunner.When("I add the following delivery address", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table8.AddRow(new string[] {
                        "0",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Warning"});
#line 51
 testRunner.Then("I should have the following delivery address as a result", ((string)(null)), table8, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code",
                        "Rule"});
            table9.AddRow(new string[] {
                        "FirstName",
                        "DeliveryAddressFirstNameRequired",
                        ""});
            table9.AddRow(new string[] {
                        "LastName",
                        "DeliveryAddressLastNameRequired",
                        ""});
            table9.AddRow(new string[] {
                        "AddressName",
                        "DeliveryAddressAddressNameRequired",
                        ""});
            table9.AddRow(new string[] {
                        "AddressLine1",
                        "AddressAddressLine1Required",
                        ""});
            table9.AddRow(new string[] {
                        "City",
                        "AddressCityRequired",
                        ""});
            table9.AddRow(new string[] {
                        "Country",
                        "AddressCountryRequired",
                        ""});
            table9.AddRow(new string[] {
                        "ZipCode",
                        "AddressZipCodeRequired",
                        ""});
#line 54
 testRunner.And("the delivery address view model should have following errors", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Validate max char length of fields when adding delivery address")]
        [NUnit.Framework.CategoryAttribute("adddeliveryaddress")]
        public virtual void ValidateMaxCharLengthOfFieldsWhenAddingDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate max char length of fields when adding delivery address", new string[] {
                        "adddeliveryaddress"});
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table10.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "Initial",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        ""});
#line 68
 testRunner.And("I have the following delivery addresses", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone"});
            table11.AddRow(new string[] {
                        "",
                        "first name that is longer 21 chars",
                        "last name that is longer 21 chars",
                        "The maximum allowed length of address name is 40 chars.",
                        @"This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website.",
                        @"This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website.",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "123456789012",
                        "+375295067630506763050676305067630"});
#line 71
 testRunner.When("I add the following delivery address", ((string)(null)), table11, "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table12.AddRow(new string[] {
                        "0",
                        "first name that is longer 21 chars",
                        "last name that is longer 21 chars",
                        "The maximum allowed length of address name is 40 chars.",
                        @"This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website.",
                        @"This is an optional credential that allows you to increase the level of your account security. To add this security option to your account, you will need to purchase a compatible authentication device from Gemalto, a third-party provider. Click the button below to purchase a device from the Gemalto website.",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "Taumatawhakatangihangakoauauotamateapokaiwhenuakitanatahuwhenuakitanatahu",
                        "123456789012",
                        "+375295067630506763050676305067630",
                        "Warning"});
#line 74
 testRunner.Then("I should have the following delivery address as a result", ((string)(null)), table12, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code",
                        "Rule"});
            table13.AddRow(new string[] {
                        "FirstName",
                        "DeliveryAddressFirstNameMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "LastName",
                        "DeliveryAddressLastNameMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "AddressName",
                        "DeliveryAddressAddressNameMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "AddressLine1",
                        "AddressAddressLine1MaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "AddressLine2",
                        "AddressAddressLine2MaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "City",
                        "AddressCityMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "Country",
                        "AddressCountryMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "State",
                        "AddressStateMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "Region",
                        "AddressRegionMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "ZipCode",
                        "AddressZipCodeMaxLength",
                        ""});
            table13.AddRow(new string[] {
                        "Phone",
                        "AddressPhoneMaxLength",
                        ""});
#line 77
 testRunner.And("the delivery address view model should have following errors", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit delivery address")]
        [NUnit.Framework.CategoryAttribute("editdeliveryaddress")]
        public virtual void EditDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit delivery address", new string[] {
                        "editdeliveryaddress"});
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 94
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table14.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
            table14.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630",
                        ""});
#line 95
 testRunner.And("I have the following delivery addresses", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table15.AddRow(new string[] {
                        "1",
                        "",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
            table15.AddRow(new string[] {
                        "2",
                        "Alex",
                        "Hatalski",
                        "Main address",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
#line 99
 testRunner.When("I edit the following delivery addresses", ((string)(null)), table15, "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table16.AddRow(new string[] {
                        "1",
                        "",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        "Warning"});
            table16.AddRow(new string[] {
                        "2",
                        "Alex",
                        "Hatalski",
                        "Main address",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        "Success"});
#line 103
 testRunner.Then("I should have the following delivery addresses as a result", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove delivery address")]
        [NUnit.Framework.CategoryAttribute("removedeliveryaddress")]
        public virtual void RemoveDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove delivery address", new string[] {
                        "removedeliveryaddress"});
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table17.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "My first",
                        "Nekrasova 8",
                        "flat 14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "",
                        ""});
            table17.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "My second",
                        "Novovilenskaya 10",
                        "flat 41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630",
                        ""});
#line 112
 testRunner.And("I have the following delivery addresses", ((string)(null)), table17, "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id"});
            table18.AddRow(new string[] {
                        "1"});
            table18.AddRow(new string[] {
                        "5"});
#line 116
 testRunner.When("I remove the following delivery addresses", ((string)(null)), table18, "When ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "FirstName",
                        "LastName",
                        "AddressName",
                        "AddressLine1",
                        "AddressLine2",
                        "City",
                        "Country",
                        "State",
                        "Region",
                        "ZipCode",
                        "Phone",
                        "MessageType"});
            table19.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Success"});
            table19.AddRow(new string[] {
                        "0",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "Error"});
#line 120
 testRunner.Then("I should have the following delivery addresses as a result", ((string)(null)), table19, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
