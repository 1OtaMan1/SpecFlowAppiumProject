using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace SpecFlowAppiumProject.StepDefinitions
{
    [Binding]
    public class YouTubeStepDefinitions
    {
        public AndroidDriver<AppiumWebElement> Driver { get; set; }
        private readonly ScenarioContext _scenarioContext;

        public YouTubeStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            Driver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
        }

        [Given(@"the opened Tepegram App")]
        public void GivenTheOpenedTepegramApp()
        {
            Driver.FindElementByXPath("//hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[4]/android.widget.ScrollView/android.widget.FrameLayout/android.widget.TextView");
        }

        [When(@"the Home button clicked")]
        public void WhenTheHomeButtonClicked()
        {
            Driver.PressKeyCode(AndroidKeyCode.Home);
        }

        [Then(@"the Youtube App Label is visible")]
        public void ThenTheYoutubeAppLabelIsVisible()
        {
            Thread.Sleep(2000);
            Driver.FindElementByXPath("//android.widget.TextView[@content-desc=\"YouTube\"]");
        }
    }
}
