using AlisAutomationDemo_Definition.Data;
using AlisAutomationDemo_Definition.Pages;
using AlisAutomationDemo_Utility.Configurations;

namespace AlisAutomationDemo_Execution.DemoTests
{
    public class Tc2_RequestDemo_NegativePath : UtilityBase
    {
        [SetUp]
        public void TestSetup()
        {
            TestConfigStandrd();
        }

        [Test]
        [TestCaseSource(typeof(ContactData), nameof(ContactData.ContactDemoRequestData_NegativePath))]
        public void Tc2_RequestPlatformDemo_NegativePath(string firstName, string lastName, string companyName, string phoneNumber, string emailAddress, string communitiesNumber, string bedsNumber, string requestMessage)
        {
            HomePage homePage = new(GetDriver());

            // Verifying Home page loaded by looking for specific buttons on the page
            Assert.That(homePage.VerifyButtonsAreDisplayed_HomePageLoaded() == true);

            // Navigating from the Home page to the Demo Form page
            homePage.ClickRequestDemo_UserNavigatedToDemoFormPage();
            DemoFormPage demoFormPage = new(GetDriver());

            // Verifying the Demo Form page loaded by looking for the iFrame that the form is contained in
            Assert.That(demoFormPage.VerifyiFrameIsDisplayed_DemoFormPageLoaded() == true);

            // Feeding the form invalid data to verify validation checking, and then attempting to submit the form
            demoFormPage.InputDemoFormFieldData_AllFormFieldsPopulated(firstName, lastName, companyName, phoneNumber, emailAddress, communitiesNumber, bedsNumber, requestMessage);
            demoFormPage.ClickSendButton_DemoFormIsSubmitted();

            // Verifying validation checks for Phone Number field, Email field, Communities field, Beds field, and SEND (submit) button
            Assert.That(demoFormPage.VerifyValidationErrors_DemoFormCannotBeSubmitted());

        }

        [TearDown]
        public void Cleanup()
        {
            TestCleanup();
        }
    }
}