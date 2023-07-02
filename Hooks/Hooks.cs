using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using SpecFlowAppiumProject.Drivers;
using Allure.Commons;

namespace SpecFlowAppiumProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext _scenarioContext;
        static readonly AllureLifecycle allure = AllureLifecycle.Instance;
        private AndroidDriver<AppiumWebElement> Driver { get; set; }

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var androidDriver = new AndroidLocalDriver();
            _scenarioContext.Set(androidDriver.GetDriver());
            Driver = _scenarioContext.Get<AndroidDriver<AppiumWebElement>>();
        }

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
            Driver.StartRecordingScreen();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var video = Driver.StopRecordingScreen();
            byte[] ret = Convert.FromBase64String(video);
            FileInfo file = new($"C:\\videoRecords\\{DateTime.Now:yyyyMMddTHHmmss}.mp4");
            using Stream sw = file.OpenWrite();
            sw.Write(ret, 0, ret.Length);
            sw.Close();
        }
    }
}