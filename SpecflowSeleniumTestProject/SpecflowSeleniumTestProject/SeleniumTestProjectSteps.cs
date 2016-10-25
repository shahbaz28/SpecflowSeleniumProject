using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using SpecFlowPages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;





namespace SpecflowSeleniumTestProject
{
    [Binding]
    public class SeleniumTestProjectSteps
    {
        [BeforeScenario]
        public void Setup()
        {
            Driver.Initialize();
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);

        }
        [AfterScenario]
        public void Teardown()
        {
            Driver.Close();

        }

        [Given(@"I have navigated to webpage")]
        public void GivenIHaveNavigatedToWebpage()
        {
            Assert.AreEqual("Food Delivery | Try Our Recipe Kits | Gousto", SpecFlowPages.Driver.Instance.Title);
        }
       

        [When(@"I select the About Delivery Link")]
        public void WhenISelectTheAboutDeliveryLink()
        {
            // Driver.Instance.FindElement(By.ClassName("SubHeader__iconArrowDown___2RHFs")).Click();
            //IWebElement ele = Driver.Instance.FindElement(By.CssSelector(".SubHeader__iconArrowDown___2RHFs"));
            //ele.Click();
            //var asdsd = Driver.Instance.FindElement(By.CssSelector(".SubHeader__iconArrowDown___2RHFs"));
            var asdsd = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/div[1]/span/span"));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/div[1]/span/span")));
            wait.Until(ExpectedConditions.ElementToBeClickable(asdsd)).Click();

            // Driver.Instance.FindElement(By.CssSelector(".SubHeader__iconArrowDown___2RHFs")).Click();
            // Driver.Instance.FindElement(By.XPath("//*[contains(@class,'SubHeader__deliveryInfo__Hkhg8')]/span")).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

        }

        [Then(@"I can view the delivery information")]
        public void ThenICanViewTheDeliveryInformation()
        {
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Our special packaging will keep your food cool for 24h"));

        }

        [When(@"I select the new recipe of the week")]
        public void WhenISelectTheNewRecipeOfTheWeek()
        {
            var newRecipe = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[3]/div/span/div/picture/img"));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[3]/div/span/div/picture/img")));
            wait.Until(ExpectedConditions.ElementToBeClickable(newRecipe)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

        }
        [Then(@"I could view the recipe")]
        public void ThenICouldViewTheRecipe()
        {
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Thanks to that great institution"));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("British free range eggs"));

        }

        [When(@"I Select Set Delivery date")]
        public void WhenISelectSetDeliveryDate()
        {
            var SetDeliveryDate = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[1]/span/div[1]/div[2]"));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[1]/span/div[1]/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(SetDeliveryDate)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("We deliver for free 4+ days a week depending on where you live."));
        }

        [Then(@"I could enter a postcode")]
        public void ThenICouldEnterAPostcode()
        {
            var EnterPostcode = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/form/span/div[1]/span/input"));

            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/form/span/div[1]/span/input")));
            wait.Until(ExpectedConditions.ElementToBeClickable(EnterPostcode)).Click();
            EnterPostcode.Clear();
            EnterPostcode.SendKeys("G21bt");
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

            var SelectContinue = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/form/div[3]/div[2]"));
            var element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/form/div[3]/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectContinue)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Delivery Options"));

        }

        [Then(@"I could add the recipes")]
        public void ThenICouldAddTheRecipes()
        {
            var selectContinue = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/div/div[6]/div[2]"));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/div/div[6]/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(selectContinue)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Box Summary"));

            //Choose Ricpes

            var chooseRecipes = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/div/div/div/div[6]/div[2]"));
            var element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[2]/div/span/div[2]/div/div/div/div[6]/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(chooseRecipes)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Choose Recipes"));

            

            //Select Recipe 1

            var SelectRecipe1 = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[3]/div/div/div/div/div[2]"));
            var element3 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[3]/div/div/div/div/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectRecipe1)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

            //Select Recipe 2

            var SelectRecipe2 = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[4]/div/div/div/div/div[2]"));
            var element4 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[3]/div/div/div[4]/div/div/div/div/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectRecipe2)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

            //Checkout
            var selectCheckout = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[1]/span/div[2]/div/div/div[2]"));
            var element5 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[3]/div[1]/span/div[2]/div/div/div[2]")));
            wait.Until(ExpectedConditions.ElementToBeClickable(selectCheckout)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));
            Assert.IsTrue(Driver.Instance.PageSource.Contains("Order Summary"));



        }

        [When(@"I select the Vegetarian options icon")]
        public void WhenISelectTheVegetarianOptionsIcon()
        {
            var selectVeg = Driver.Instance.FindElement(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/div[2]/span"));
            WebDriverWait wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='react-root']/div/div[1]/div[1]/div[1]/div[1]/div[2]/div/div[2]/span")));
            wait.Until(ExpectedConditions.ElementToBeClickable(selectVeg)).Click();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Driver.Instance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(30));

        }

        [Then(@"I see a list of the Vegitarian recipes")]
        public void ThenISeeAListOfTheVegitarianRecipes()
        {

            Assert.IsTrue(Driver.Instance.PageSource.Contains("vegetarian-recipes"));
        }
    }
}
        
