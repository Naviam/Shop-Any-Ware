using System;
using TechTalk.SpecFlow;

namespace TdService.ShopAnyWare.Specs.Steps
{
    [Binding]
    public class DepositSteps
    {
        [Then(@"the DoDirectPayment responce should be as follows")]
        public void ThenTheDoDirectPaymentResponceShouldBeAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the current wallet  amount of '(.*)' should be (.*)")]
        public void ThenTheCurrentWalletAmountOfShouldBe(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"there should be a transaction for user '(.*)' as follows")]
        public void ThenThereShouldBeATransactionForUserAsFollows(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I enter the following CC info on the deposit page")]
        public void GivenIEnterTheFollowingCCInfoOnTheDepositPage(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"there should be a transaction for me as follows")]
        public void ThenThereShouldBeATransactionForMeAsFollows(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"my current wallet  amount should be (.*)")]
        public void ThenMyCurrentWalletAmountShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"my current wallet  amount is (.*)")]
        public void GivenTheCurrentWalletAmountOfIs(int amount)
        {

        }

    }
}
