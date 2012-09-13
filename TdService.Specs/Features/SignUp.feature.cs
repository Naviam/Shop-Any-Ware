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
    [NUnit.Framework.DescriptionAttribute("Sign Up")]
    [NUnit.Framework.CategoryAttribute("signup")]
    public partial class SignUpFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SignUp.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sign Up", "In order to start using ShopAnyWare service\r\nAs an anonymous user\r\nI want to be a" +
                    "ble to register as a shopper and activate my personal account", ProgrammingLanguage.CSharp, new string[] {
                        "signup"});
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
        [NUnit.Framework.DescriptionAttribute("Shoppers sign up")]
        public virtual void ShoppersSignUp()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Shoppers sign up", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table1.AddRow(new string[] {
                        "hautama@tut.by",
                        "ruinruin",
                        "ruinruin",
                        "Vitali",
                        "Hatalski"});
#line 9
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table1, "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Activated",
                        "Message Type"});
            table2.AddRow(new string[] {
                        "hautama@tut.by",
                        "Vitali",
                        "Hatalski",
                        "false",
                        "Success"});
#line 12
 testRunner.Then("I should have the result as follows", ((string)(null)), table2, "Then ");
#line 15
 testRunner.And("activation code should be generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("email with activation code should be sent to registration email address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Account already exists")]
        public virtual void AccountAlreadyExists()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Account already exists", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table3.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "ruinruin",
                        "ruinruin",
                        "Vitali",
                        "Hatalski"});
#line 21
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table3, "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table4.AddRow(new string[] {
                        "vhatalski@naviam.com",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 24
 testRunner.Then("I should have the result as follows", ((string)(null)), table4, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table5.AddRow(new string[] {
                        "Email",
                        "UserEmailExists"});
#line 27
 testRunner.And("the signup view model should have following errors", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify email existence when it should exist")]
        public virtual void VerifyEmailExistenceWhenItShouldExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify email existence when it should exist", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
 testRunner.And("The \'vhatalski@naviam.com\' account already exists", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("I enter email \'vhatalski@naviam.com\' to verify existence", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "EmailExists",
                        "Message Type"});
            table6.AddRow(new string[] {
                        "True",
                        "Warning"});
#line 35
 testRunner.Then("the verify email view model should be as follows", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify email existence when it should not exist")]
        public virtual void VerifyEmailExistenceWhenItShouldNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify email existence when it should not exist", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.When("I enter email \'nosuchmail@naviam.com\' to verify existence", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "EmailExists",
                        "Message Type"});
            table7.AddRow(new string[] {
                        "False",
                        "Success"});
#line 42
 testRunner.Then("the verify email view model should be as follows", ((string)(null)), table7, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Email and password are required")]
        public virtual void EmailAndPasswordAreRequired()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email and password are required", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table8.AddRow(new string[] {
                        "",
                        "",
                        "",
                        "Vitali",
                        "Hatalski"});
#line 48
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table8, "When ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table9.AddRow(new string[] {
                        "",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 51
 testRunner.Then("I should have the result as follows", ((string)(null)), table9, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table10.AddRow(new string[] {
                        "Password",
                        "UserPasswordRequired"});
            table10.AddRow(new string[] {
                        "Email",
                        "UserEmailRequired"});
            table10.AddRow(new string[] {
                        "PasswordConfirm",
                        "UserPasswordConfirmRequired"});
#line 54
 testRunner.And("the signup view model should have following errors", ((string)(null)), table10, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("First and Last names are required")]
        public virtual void FirstAndLastNamesAreRequired()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("First and Last names are required", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table11.AddRow(new string[] {
                        "hautama@tut.by",
                        "ruinruin",
                        "ruinruin",
                        "",
                        ""});
#line 62
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table11, "When ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table12.AddRow(new string[] {
                        "hautama@tut.by",
                        "",
                        "",
                        "Warning"});
#line 65
 testRunner.Then("I should have the result as follows", ((string)(null)), table12, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table13.AddRow(new string[] {
                        "FirstName",
                        "ProfileFirstNameRequired"});
            table13.AddRow(new string[] {
                        "LastName",
                        "ProfileLastNameRequired"});
#line 68
 testRunner.And("the signup view model should have following errors", ((string)(null)), table13, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("First and Last names should be less than 21 chars")]
        public virtual void FirstAndLastNamesShouldBeLessThan21Chars()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("First and Last names should be less than 21 chars", ((string[])(null)));
#line 73
this.ScenarioSetup(scenarioInfo);
#line 74
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table14.AddRow(new string[] {
                        "hautama@tut.by",
                        "ruinruin",
                        "ruinruin",
                        "First name longer than 21 chars",
                        "Last name longer than 21 chars"});
#line 75
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table14, "When ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table15.AddRow(new string[] {
                        "hautama@tut.by",
                        "First name longer than 21 chars",
                        "Last name longer than 21 chars",
                        "Warning"});
#line 78
 testRunner.Then("I should have the result as follows", ((string)(null)), table15, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table16.AddRow(new string[] {
                        "FirstName",
                        "ProfileFirstNameMaxLength"});
            table16.AddRow(new string[] {
                        "LastName",
                        "ProfileLastNameMaxLength"});
#line 81
 testRunner.And("the signup view model should have following errors", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Email is invalid")]
        public virtual void EmailIsInvalid()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Email is invalid", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table17.AddRow(new string[] {
                        "hautamatut.by",
                        "ruinruin",
                        "ruinruin",
                        "Vitali",
                        "Hatalski"});
#line 88
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table17, "When ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table18.AddRow(new string[] {
                        "hautamatut.by",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 91
 testRunner.Then("I should have the result as follows", ((string)(null)), table18, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table19.AddRow(new string[] {
                        "Email",
                        "UserEmailInvalid"});
#line 94
 testRunner.And("the signup view model should have following errors", ((string)(null)), table19, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Password Confirm does not match")]
        public virtual void PasswordConfirmDoesNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password Confirm does not match", ((string[])(null)));
#line 98
this.ScenarioSetup(scenarioInfo);
#line 99
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table20.AddRow(new string[] {
                        "hautama@tut.by",
                        "ruinruin",
                        "ruinruin1",
                        "Vitali",
                        "Hatalski"});
#line 100
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table20, "When ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table21.AddRow(new string[] {
                        "hautama@tut.by",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 103
 testRunner.Then("I should have the result as follows", ((string)(null)), table21, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table22.AddRow(new string[] {
                        "PasswordConfirm",
                        "UserPasswordConfirmNotEqual"});
#line 106
 testRunner.And("the signup view model should have following errors", ((string)(null)), table22, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Password length cannot be less than 7 chars")]
        public virtual void PasswordLengthCannotBeLessThan7Chars()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password length cannot be less than 7 chars", ((string[])(null)));
#line 110
this.ScenarioSetup(scenarioInfo);
#line 111
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table23.AddRow(new string[] {
                        "hautama@tut.by",
                        "ruin",
                        "ruin",
                        "Vitali",
                        "Hatalski"});
#line 112
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table23, "When ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table24.AddRow(new string[] {
                        "hautama@tut.by",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 115
 testRunner.Then("I should have the result as follows", ((string)(null)), table24, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table25.AddRow(new string[] {
                        "Password",
                        "UserPasswordMinLength"});
#line 118
 testRunner.And("the signup view model should have following errors", ((string)(null)), table25, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Password length cannot be more than 21 chars")]
        public virtual void PasswordLengthCannotBeMoreThan21Chars()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password length cannot be more than 21 chars", ((string[])(null)));
#line 122
this.ScenarioSetup(scenarioInfo);
#line 123
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table26.AddRow(new string[] {
                        "hautama@tut.by",
                        "passwordwithmorethan21chars",
                        "passwordwithmorethan21chars",
                        "Vitali",
                        "Hatalski"});
#line 124
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table26, "When ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table27.AddRow(new string[] {
                        "hautama@tut.by",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 127
 testRunner.Then("I should have the result as follows", ((string)(null)), table27, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table28.AddRow(new string[] {
                        "Password",
                        "UserPasswordMaxLength"});
#line 130
 testRunner.And("the signup view model should have following errors", ((string)(null)), table28, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Password is required and Password Confirm does not match")]
        public virtual void PasswordIsRequiredAndPasswordConfirmDoesNotMatch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Password is required and Password Confirm does not match", ((string[])(null)));
#line 134
this.ScenarioSetup(scenarioInfo);
#line 135
 testRunner.Given("I have not been authenticated yet", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "Password",
                        "Password Confirm",
                        "First Name",
                        "Last Name"});
            table29.AddRow(new string[] {
                        "hautama@tut.by",
                        "",
                        "ruinruin",
                        "Vitali",
                        "Hatalski"});
#line 136
 testRunner.When("I fill sign up form with the following data", ((string)(null)), table29, "When ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "Email",
                        "First Name",
                        "Last Name",
                        "Message Type"});
            table30.AddRow(new string[] {
                        "hautama@tut.by",
                        "Vitali",
                        "Hatalski",
                        "Warning"});
#line 139
 testRunner.Then("I should have the result as follows", ((string)(null)), table30, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        "Property",
                        "Error Code"});
            table31.AddRow(new string[] {
                        "Password",
                        "UserPasswordRequired"});
            table31.AddRow(new string[] {
                        "PasswordConfirm",
                        "UserPasswordConfirmNotEqual"});
#line 142
 testRunner.And("the signup view model should have following errors", ((string)(null)), table31, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
