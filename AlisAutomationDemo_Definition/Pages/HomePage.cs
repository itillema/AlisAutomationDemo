using OpenQA.Selenium;

namespace AlisAutomationDemo_Definition.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // General Navigation Elements
        private IWebElement RequestDemoButton_Button => _driver.FindElement(By.XPath("//ul[@id='primary-menu']//descendant::a[text()='Request Demo']"));


        // Action Methods
        public void ClickRequestDemo_UserNavigatedToDemoFormPage()
        {
            RequestDemoButton_Button.Click();
        }

        // Verification Methods
        public bool VerifyButtonsAreDisplayed_HomePageLoaded()
        {
            if (RequestDemoButton_Button.Displayed == true)
                return true;
            else return false;

        }
            
     


    }
}
