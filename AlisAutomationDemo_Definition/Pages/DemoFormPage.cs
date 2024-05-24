using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisAutomationDemo_Definition.Pages
{
    public class DemoFormPage
    {
        private readonly IWebDriver _driver;
        public DemoFormPage(IWebDriver driver)
        {
            _driver = driver;
        }
        

        // General Navigation Elements

        // Form Action Fields
        private IWebElement FirstNameField_TextInput => _driver.FindElement(By.XPath("//input[@name='firstname' and @type='text']"));
        private IWebElement LastNameField_TextInput => _driver.FindElement(By.XPath("//input[@name='lastname' and @type='text']"));
        private IWebElement CompanyNameField_TextInput => _driver.FindElement(By.XPath("//input[@name='company' and @type='text']"));
        private IWebElement PhoneNumberField_TextInput => _driver.FindElement(By.XPath("//input[@name='phone' and @type='tel']"));
        private IWebElement EmailAddressField_TextInput => _driver.FindElement(By.XPath("//input[@name='email' and @type='email']"));
        private IWebElement CommunitiesNumberField_TextInput => _driver.FindElement(By.XPath("//input[@name='number_of_communities' and @type='number']"));
        private IWebElement BedsNumberField_TextInput => _driver.FindElement(By.XPath("//input[@name='number_of_beds' and @type='number']"));
        private IWebElement RequestMessageField_TextInput => _driver.FindElement(By.XPath("//textarea[@name='message']"));
        private IWebElement FormSendButton_Button => _driver.FindElement(By.XPath("//input[@type='submit' and @value='SEND']"));
        private IWebElement IFrameContainer_FormContainer => _driver.FindElement(By.XPath("//iframe[@id='hs-form-iframe-0' and @title='Form 0']"));

        // Form Validation Fields
        private IWebElement FirstNameFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_firstname hs-firstname hs-fieldtype-text field hs-form-field']//descendant::label[text()='Please complete this required field.']"));
        private IWebElement LastNameFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_lastname hs-lastname hs-fieldtype-text field hs-form-field']//descendant::label[text()='Please complete this required field.']"));
        private IWebElement CompanyNameFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_company hs-company hs-fieldtype-text field hs-form-field']//descendant::label[text()='Please complete this required field.']"));
        private IWebElement PhoneNumberFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_phone hs-phone hs-fieldtype-phonenumber field hs-form-field']//descendant::label[text()='A valid phone number may only contain numbers, +()-. or x']"));
        private IWebElement EmailAddressFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_email hs-email hs-fieldtype-text field hs-form-field']//descendant::label[text()='Email must be formatted correctly.']"));
        private IWebElement CommunitiesNumberFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_number_of_communities hs-number_of_communities hs-fieldtype-number field hs-form-field']//descendant::label[text()='Please complete this required field.']"));
        private IWebElement BedsNumberFieldValidationError_PageText => _driver.FindElement(By.XPath("//div[@class='hs_number_of_beds hs-number_of_beds hs-fieldtype-number field hs-form-field']//descendant::label[text()='Please complete this required field.']"));
        private IWebElement SubmitFormValidationError_PageText => _driver.FindElement(By.XPath("//label[text()='Please complete all required fields.']"));




        // Action Methods
        public void InputDemoFormFieldData_AllFormFieldsPopulated(string firstName, string lastName, string companyName, string phoneNumber, string emailAddress, string communitiesNumber, string bedsNumber, string requestMessage)
        {

            _driver.SwitchTo().Frame("hs-form-iframe-0");
            FirstNameField_TextInput.Click();
            FirstNameField_TextInput.SendKeys(firstName);

            LastNameField_TextInput.Click();
            LastNameField_TextInput.SendKeys(lastName);

            CompanyNameField_TextInput.Click();
            CompanyNameField_TextInput.SendKeys(companyName);

            PhoneNumberField_TextInput.Click();
            PhoneNumberField_TextInput.SendKeys(phoneNumber);

            new Actions(_driver)
                .ScrollToElement(RequestMessageField_TextInput)
                .Perform();

            EmailAddressField_TextInput.Click();
            EmailAddressField_TextInput.SendKeys(emailAddress);

            CommunitiesNumberField_TextInput.Click();
            CommunitiesNumberField_TextInput.SendKeys(communitiesNumber);

            BedsNumberField_TextInput.Click();
            BedsNumberField_TextInput.SendKeys(bedsNumber);

            RequestMessageField_TextInput.Click();
            RequestMessageField_TextInput.SendKeys(requestMessage);

        }

        public void ClickSendButton_DemoFormIsSubmitted()
        {
            FormSendButton_Button.Click();
            // _driver.SwitchTo().DefaultContent();
        }




        // Verification Methods
        public bool VerifyiFrameIsDisplayed_DemoFormPageLoaded()
        {
            if (IFrameContainer_FormContainer.Displayed == true)
                return true;
            else return false;

        }

        public bool VerifySendButtonIsDisplayed_DemoFormCanBeSubmitted()
        {
            if (FormSendButton_Button.Displayed == true)
                return true;
            else return false;

        }

        public bool VerifyValidationErrors_DemoFormCannotBeSubmitted()
        {
            if (PhoneNumberFieldValidationError_PageText.Displayed == true
                && EmailAddressFieldValidationError_PageText.Displayed == true
                && CommunitiesNumberFieldValidationError_PageText.Displayed == true
                && BedsNumberFieldValidationError_PageText.Displayed == true
                && SubmitFormValidationError_PageText.Displayed == true)
                return true;
            
            else return false;

        }

    }
}
