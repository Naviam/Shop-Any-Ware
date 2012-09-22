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
    [NUnit.Framework.DescriptionAttribute("Shopper Packages")]
    [NUnit.Framework.CategoryAttribute("packages")]
    public partial class ShopperPackagesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ShopperPackages.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Shopper Packages", "In order to send packages to my delivery address\r\nAs a shopper\r\nI want to be able" +
                    " to consolidate my items in packages and specify delivery address", ProgrammingLanguage.CSharp, new string[] {
                        "packages"});
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
        [NUnit.Framework.DescriptionAttribute("Add new package")]
        [NUnit.Framework.CategoryAttribute("addpackage")]
        public virtual void AddNewPackage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add new package", new string[] {
                        "addpackage"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I set package name as \'my first package\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Status"});
            table1.AddRow(new string[] {
                        "1",
                        "my first package",
                        "New"});
#line 12
 testRunner.Then("I should have the following packages as a result", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update package delivery address")]
        public virtual void UpdatePackageDeliveryAddress()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update package delivery address", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "my first address",
                        "Nekrasova 8",
                        "14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "+375295067630"});
            table2.AddRow(new string[] {
                        "2",
                        "Vitali",
                        "Hatalski",
                        "my second address",
                        "Novovilenskaya 10",
                        "41",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220053",
                        "+375295067630"});
#line 19
 testRunner.And("I have the following delivery addresses", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Delivery Address Id",
                        "Status"});
            table3.AddRow(new string[] {
                        "my first package",
                        "1",
                        "New"});
#line 23
 testRunner.And("I have the following packages", ((string)(null)), table3, "And ");
#line 26
 testRunner.When("I update delivery address to \'2\' of package \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Delivery Address Id",
                        "Status",
                        "Message Type"});
            table4.AddRow(new string[] {
                        "1",
                        "my first package",
                        "2",
                        "New",
                        "Success"});
#line 27
 testRunner.Then("I should have the following packages as a result", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Remove package in New status")]
        public virtual void RemovePackageInNewStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Remove package in New status", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "Phone"});
            table5.AddRow(new string[] {
                        "1",
                        "Vitali",
                        "Hatalski",
                        "my first address",
                        "Nekrasova 8",
                        "14",
                        "Minsk",
                        "Belarus",
                        "",
                        "",
                        "220040",
                        "+375295067630"});
#line 34
 testRunner.And("I have the following delivery addresses", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Delivery Address Id",
                        "Dispatch Method",
                        "Status"});
            table6.AddRow(new string[] {
                        "my first package",
                        "0",
                        "",
                        "New"});
            table6.AddRow(new string[] {
                        "my second package",
                        "1",
                        "",
                        "New"});
#line 37
 testRunner.And("I have the following packages", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id"});
            table7.AddRow(new string[] {
                        "1"});
            table7.AddRow(new string[] {
                        "2"});
            table7.AddRow(new string[] {
                        "3"});
#line 41
 testRunner.When("I remove packages with the ids as follows", ((string)(null)), table7, "When ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Delivery Address Id",
                        "Status",
                        "Message Type"});
            table8.AddRow(new string[] {
                        "1",
                        "",
                        "",
                        "",
                        ""});
            table8.AddRow(new string[] {
                        "2",
                        "",
                        "",
                        "",
                        ""});
            table8.AddRow(new string[] {
                        "3",
                        "",
                        "",
                        "",
                        ""});
#line 46
 testRunner.Then("I should have the following packages as a result", ((string)(null)), table8, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
