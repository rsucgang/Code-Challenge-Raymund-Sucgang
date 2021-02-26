using System;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit;
using Code_Challenge_Raymund_Sucgang.Pages;
using Code_Challenge_Raymund_Sucgang.Helper;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Code_Challenge_Raymund_Sucgang.Steps
{
    [Binding]
    public class ManageContactsSteps
    {
        readonly IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>(Constants.KEY_DRIVER);

        [Given(@"I login as admin in VoterVoice")]
        public void GivenILoginAsAdminInVoterVoice()
        {
            driver.Navigate().GoToUrl("https://www.votervoice.net/AdminSite");
            LoginPage vvLogin = new LoginPage();
            vvLogin.Login();
            Thread.Sleep(1000);
        }

        [Given(@"I navigate to the Manage Contacts page")]
        public void GivenINavigateToTheManageContactsPage()
        {
            driver.Navigate().GoToUrl("https://www.votervoice.net/AdminSite/xhAAAA/Contacts#/Lists");
            Thread.Sleep(1000);
        }


        [Given(@"I click ""(.*)""")]
        [When(@"I click ""(.*)""")]
        public void WhenIClick(string linkText)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement link = wait.Until(driver => driver.FindElement(By.LinkText(linkText)));
            link.Click();
            Thread.Sleep(1000);
        }


        [When(@"I enter contact details")]
        public void WhenIEnterContactDetails(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            driver.FindElement(By.Id("Honorific")).SendKeys(dictionary["Prefix"]);
            driver.FindElement(By.XPath("//input[@ng-model='profile.givenNames']")).SendKeys(dictionary["Firstname"]);
            driver.FindElement(By.XPath("//input[@ng-model='profile.surname']")).SendKeys(dictionary["Lastname"]);
            driver.FindElement(By.XPath("//input[@ng-model='profile.homeAddress.streetAddress1']")).SendKeys(dictionary["Street"]);
            driver.FindElement(By.XPath("//input[@ng-model='profile.homeAddress.city']")).SendKeys(dictionary["City"]);
            var state = driver.FindElement(By.XPath("//select[@ng-model='profile.homeAddress.state']"));
            var selectState = new SelectElement(state);
            selectState.SelectByText(dictionary["State"]);
            Thread.Sleep(1000);
        }

        [When(@"I verify that zipcode is ""(.*)""")]
        public void WhenIVerifyThatZipcodeIs(string zipcode)
        {
            IWebElement zipcodeInput = driver.FindElement(By.XPath("//input[@ng-model='profile.homeAddress.zipCode']"));
            Assert.AreEqual(zipcode, zipcodeInput.GetAttribute("value"));
            Thread.Sleep(1000);
        }


        [When(@"I verify that ""(.*)"" is already set to ""(.*)""")]
        public void WhenIVerifyThatIsAlreadySetTo(string groupList, string defaultList)
        {
            IWebElement groupListOption = driver.FindElement(By.XPath("//select[@ng-model='profile.membership.groupList']/option[text() = '"+ defaultList +"']"));
            string optionSelected = groupListOption.GetAttribute("selected");
            Assert.AreEqual("true", optionSelected);
            Thread.Sleep(1000);
        }

        [When(@"I press ""(.*)""")]
        public void WhenIPress(string label)
        {
            driver.FindElement(By.XPath("//button[text()='" + label + "']")).Click();
        }

        [Given(@"I see the text ""(.*)""")]
        [Then(@"I see the text ""(.*)""")]
        public void ThenISeeTheText(string text)
        {
            try
            {
                driver.FindElement(By.XPath("//*[text()='" + text + "']"));
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        [When(@"I delete user ""(.*)"" from the contacts")]
        public void WhenIDeleteUserFromTheContacts(string name)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            IWebElement userDelete = wait.Until(driver => driver.FindElement(By.XPath("//td[@title='" + name + "']/../td/div/a[@title='Delete']")));
            userDelete.Click();
            driver.FindElement(By.XPath("//button/span[text()='OK']")).Click();
        }

        [Then(@"I do not see the text ""(.*)""")]
        public void ThenIDoNotSeeTheText(string text)
        {
            try
            {
                driver.FindElement(By.XPath("//*[text()='" + text + "']"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
