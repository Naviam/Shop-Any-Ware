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
    [NUnit.Framework.DescriptionAttribute("Sign In")]
    [NUnit.Framework.CategoryAttribute("signin")]
    public partial class SignInFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SignIn.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sign In", "In order to start using service\r\nAs a shopper\r\nI want to be able to sign in with " +
                    "my credentials", ProgrammingLanguage.CSharp, new string[] {
                        "signin"});
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
        [NUnit.Framework.DescriptionAttribute("Shopper sign in")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void ShopperSignIn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopper sign in", new string[] {
                        "shopper"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table1.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "ruinruin",
                        "false"});
#line 11
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table1, "When ");
#line 14
 testRunner.Then("I should be redirected to shopper dashbord page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Shopper invalid credentials")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void ShopperInvalidCredentials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopper invalid credentials", new string[] {
                        "shopper"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table2.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "ruinruin3",
                        "false"});
#line 20
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table2, "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me",
                        "Message Type",
                        "Error Code"});
            table3.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "",
                        "false",
                        "Error",
                        "UserNotValid"});
#line 23
 testRunner.Then("the signin result should be as follows", ((string)(null)), table3, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Shopper validate required fields")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void ShopperValidateRequiredFields()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopper validate required fields", new string[] {
                        "shopper"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table4.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "",
                        "false"});
#line 31
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me",
                        "Message Type"});
            table5.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "",
                        "false",
                        "Warning"});
#line 34
 testRunner.Then("the signin result should be as follows", ((string)(null)), table5, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table6.AddRow(new string[] {
                        "Password",
                        "UserPasswordRequired"});
#line 37
 testRunner.And("the signin view model should have following errors", ((string)(null)), table6, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Operator sign in")]
        [NUnit.Framework.CategoryAttribute("operator")]
        public virtual void OperatorSignIn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Operator sign in", new string[] {
                        "operator"});
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table7.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "ruinruin",
                        "false"});
#line 45
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table7, "When ");
#line 48
 testRunner.Then("I should be redirected to operator dashbord page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
