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
        [NUnit.Framework.DescriptionAttribute("Sign in shopper")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void SignInShopper()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign in shopper", new string[] {
                        "shopper"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table1.AddRow(new string[] {
                        "v.hatalski@gmail.com",
                        "ruinruin",
                        "false"});
#line 11
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table1, "When ");
#line 14
 testRunner.Then("I should be redirected to controller \'Member\' and action \'Dashboard\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Shopper invalid password")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void ShopperInvalidPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopper invalid password", new string[] {
                        "shopper"});
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table2.AddRow(new string[] {
                        "v.hatalski@gmail.com",
                        "ruin3",
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
                        "v.hatalski@gmail.com",
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
        [NUnit.Framework.DescriptionAttribute("Shopper invalid email")]
        [NUnit.Framework.CategoryAttribute("shopper")]
        public virtual void ShopperInvalidEmail()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shopper invalid email", new string[] {
                        "shopper"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table4.AddRow(new string[] {
                        "vhatalski@gmail.com",
                        "ruinruinruinruinruinruinruinruin",
                        "false"});
#line 31
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table4, "When ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me",
                        "Message Type",
                        "Error Code"});
            table5.AddRow(new string[] {
                        "vhatalski@gmail.com",
                        "",
                        "false",
                        "Error",
                        "UserNotValid"});
#line 34
 testRunner.Then("the signin result should be as follows", ((string)(null)), table5, "Then ");
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
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Shopper" +
                    "\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table6.AddRow(new string[] {
                        "",
                        "",
                        "false"});
#line 42
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table6, "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me",
                        "Message Type"});
            table7.AddRow(new string[] {
                        "",
                        "",
                        "false",
                        "Warning"});
#line 45
 testRunner.Then("the signin result should be as follows", ((string)(null)), table7, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code",
                        "Rule"});
            table8.AddRow(new string[] {
                        "Email",
                        "UserEmailRequired",
                        ""});
            table8.AddRow(new string[] {
                        "Password",
                        "UserPasswordRequired",
                        ""});
#line 48
 testRunner.And("the signin view model should have following errors", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign in operator")]
        [NUnit.Framework.CategoryAttribute("operator")]
        public virtual void SignInOperator()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign in operator", new string[] {
                        "operator"});
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Operato" +
                    "r\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table9.AddRow(new string[] {
                        "v.hatalski@gmail.com",
                        "ruinruin",
                        "false"});
#line 57
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table9, "When ");
#line 60
 testRunner.Then("I should be redirected to controller \'Operator\' and action \'Dashboard\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign in consultant")]
        [NUnit.Framework.CategoryAttribute("consultant")]
        public virtual void SignInConsultant()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign in consultant", new string[] {
                        "consultant"});
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Consult" +
                    "ant\' with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 65
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table10.AddRow(new string[] {
                        "v.hatalski@gmail.com",
                        "ruinruin",
                        "false"});
#line 66
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table10, "When ");
#line 69
 testRunner.Then("I should be redirected to controller \'Operator\' and action \'Dashboard\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Sign in admin")]
        [NUnit.Framework.CategoryAttribute("admin")]
        public virtual void SignInAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sign in admin", new string[] {
                        "admin"});
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("there is \'v.hatalski@gmail.com\' account with \'ruinruin\' password in role \'Admin\' " +
                    "with fullname \'Vitali\' and \'Hatalski\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Remember Me"});
            table11.AddRow(new string[] {
                        "v.hatalski@gmail.com",
                        "ruinruin",
                        "false"});
#line 75
 testRunner.When("I fill sign in form with the following data", ((string)(null)), table11, "When ");
#line 78
 testRunner.Then("I should be redirected to controller \'Admin\' and action \'Dashboard\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion