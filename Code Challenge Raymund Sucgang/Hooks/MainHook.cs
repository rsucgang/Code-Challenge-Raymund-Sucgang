using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Code_Challenge_Raymund_Sucgang.Helper;

namespace Code_Challenge_Raymund_Sucgang.Hooks
{
    [Binding]
    public sealed class MainHook
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            ScenarioContext.Current.Add(Constants.KEY_DRIVER, driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver;
            ScenarioContext.Current.TryGetValue<IWebDriver>(Constants.KEY_DRIVER, out driver);
            if (driver != null)
            {
                driver.Close();
            }
        }
    }
}
