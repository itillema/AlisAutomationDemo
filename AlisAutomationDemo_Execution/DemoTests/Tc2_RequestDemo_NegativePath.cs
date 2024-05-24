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
            Assert.That(homePage.VerifyButtonsAreDisplayed_HomePageLoaded() == true);
            homePage.ClickRequestDemo_UserNavigatedToDemoFormPage();

            DemoFormPage demoFormPage = new(GetDriver());
            Assert.That(demoFormPage.VerifyiFrameIsDisplayed_DemoFormPageLoaded() == true);
            // Feeding the form invalid data to verify validation checking
            demoFormPage.InputDemoFormFieldData_AllFormFieldsPopulated(firstName, lastName, companyName, phoneNumber, emailAddress, communitiesNumber, bedsNumber, requestMessage);
            //Assert.That(demoFormPage.VerifyValidationErrors_AllFieldsAreCheckingValidation());
            demoFormPage.ClickSendButton_DemoFormIsSubmitted();
            //Assert.That(demoFormPage.VerifySendButtonIsDisplayed_DemoFormCanBeSubmitted() == true);
            //Assert.That(demoFormPage.VerifySubmissionError_DemoFormCannotBeSubmitted());
        }

        [TearDown]
        public void Cleanup()
        {
            TestCleanup();
        }
    }
}