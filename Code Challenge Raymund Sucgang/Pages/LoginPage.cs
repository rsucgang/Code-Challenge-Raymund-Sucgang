using Code_Challenge_Raymund_Sucgang.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Xml;
using TechTalk.SpecFlow;

namespace Code_Challenge_Raymund_Sucgang.Pages
{
    public class LoginPage
    {
        readonly IWebDriver driver = ScenarioContext.Current.Get<IWebDriver>(Constants.KEY_DRIVER);

        public void Login()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("credentials.xml");
            string username = doc.SelectSingleNode("/Credentials/Username").InnerText;
            string password = doc.SelectSingleNode("/Credentials/Password").InnerText;
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@name='username']")).SendKeys(username);
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys(password);
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }
    }
}
