using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlisAutomationDemo_Utility.Configurations
{
    public class UtilityBase
    {
        private IWebDriver driver;

        public void TestConfigStandrd()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.medtelligent.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("document.body.style.zoom='90%'");

        }

        public IWebDriver GetDriver() 
        { 
            return this.driver;
        }

        public void TestCleanup()
        {
            this.driver.Quit();
        }



    }
}
