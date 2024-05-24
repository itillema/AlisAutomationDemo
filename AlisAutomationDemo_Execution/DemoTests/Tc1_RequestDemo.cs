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
            Assert.That(homePage.VerifyButtonsAreDisplayed_HomePageLoaded() == true);
            homePage.ClickRequestDemo_UserNavigatedToDemoFormPage();

            DemoFormPage demoFormPage = new(GetDriver());
            Assert.That(demoFormPage.VerifyiFrameIsDisplayed_DemoFormPageLoaded() == true);
            demoFormPage.InputDemoFormFieldData_AllFormFieldsPopulated(firstName, lastName, companyName, phoneNumber, emailAddress, communitiesNumber, bedsNumber, requestMessage);

            Assert.That(demoFormPage.VerifySendButtonIsDisplayed_DemoFormCanBeSubmitted());
        }

        [TearDown]
        public void Cleanup()
        {
            TestCleanup();
        }
    }
}