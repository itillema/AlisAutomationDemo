using AlisAutomationDemo_Definition.Data;
using AlisAutomationDemo_Definition.Pages;
using AlisAutomationDemo_Utility.Configurations;

namespace AlisAutomationDemo_Execution.DemoTests
{
    public class Tc1_RequestDemo : UtilityBase
    {
        [SetUp]
        public void TestSetup()
        {
            TestConfigStandrd();
        }

        [Test]
        [TestCaseSource(typeof(ContactData), nameof(ContactData.ContactDemoRequestData))]
        public void Tc1_RequestPlatformDemo(string firstName, string lastName, string companyName, string phoneNumber, string emailAddress, string communitiesNumber, string bedsNumber, string requestMessage)
        {
            HomePage homePage = new(GetDriver());

            // Verifying Home page loaded by looking for specific buttons on the page
            Assert.That(homePage.VerifyButtonsAreDisplayed_HomePageLoaded() == true);

            // Navigating from the Home page to the Demo Form page
            homePage.ClickRequestDemo_UserNavigatedToDemoFormPage();
            DemoFormPage demoFormPage = new(GetDriver());

            // Verifying the Demo Form page loaded by looking for the iFrame that the form is contained in
            Assert.That(demoFormPage.VerifyiFrameIsDisplayed_DemoFormPageLoaded() == true);

            // Inputting dynamic data into the form
            demoFormPage.InputDemoFormFieldData_AllFormFieldsPopulated(firstName, lastName, companyName, phoneNumber, emailAddress, communitiesNumber, bedsNumber, requestMessage);

            // Verifying the SEND button is displayed, to ensure the form can be submitted
            Assert.That(demoFormPage.VerifySendButtonIsDisplayed_DemoFormCanBeSubmitted());
        }

        [TearDown]
        public void Cleanup()
        {
            TestCleanup();
        }
    }
}