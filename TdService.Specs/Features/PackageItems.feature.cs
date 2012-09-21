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
    [NUnit.Framework.DescriptionAttribute("Package Items")]
    [NUnit.Framework.CategoryAttribute("packages")]
    public partial class PackageItemsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PackageItems.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Package Items", "In order to consolidate package and calculate total package cost\r\nAs a shopper\r\nI" +
                    " want to be able to put and remove items from package", ProgrammingLanguage.CSharp, new string[] {
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
        [NUnit.Framework.DescriptionAttribute("Add item to the package")]
        public virtual void AddItemToThePackage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add item to the package", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I am authenticated as \'v.hatalski@gmail.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Quantity",
                        "Color",
                        "Size",
                        "Weight",
                        "Price"});
            table1.AddRow(new string[] {
                        "IPAD3",
                        "1",
                        "Black",
                        "",
                        "",
                        "800"});
            table1.AddRow(new string[] {
                        "Kindle Fire",
                        "2",
                        "White",
                        "",
                        "",
                        "350"});
#line 10
 testRunner.When("I add item to package with the following data", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Name",
                        "Quantity",
                        "Color",
                        "Size",
                        "Weight",
                        "Price"});
            table2.AddRow(new string[] {
                        "1",
                        "IPAD3",
                        "1",
                        "Black",
                        "",
                        "",
                        "800"});
            table2.AddRow(new string[] {
                        "2",
                        "Kindle Fire",
                        "2",
                        "White",
                        "",
                        "",
                        "350"});
#line 14
 testRunner.Then("I should have the following package items", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion