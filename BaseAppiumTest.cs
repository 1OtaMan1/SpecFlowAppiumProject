using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace Mobile_test_project
{
    [TestFixture]
    public class BaseAppiumTest
    {
        public AndroidDriver<AppiumWebElement> Driver;

        [SetUp]
        public void Setup()
        {
            var myJsonString = File.ReadAllText("test_settings.json");
            var myJObject = JObject.Parse(myJsonString);
            var appiumHost = myJObject.SelectToken("$.LOCAL.host").Value<string>();
            var androidApp = myJObject.SelectToken("$.LOCAL.android.app").Value<string>();
            var androidDevice = myJObject.SelectToken("$.LOCAL.android.deviceName").Value<string>();

            AppiumOptions caps = new AppiumOptions();
            caps.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            caps.AddAdditionalCapability("appium:deviceName", androidDevice);
            caps.AddAdditionalCapability("appium:app", androidApp);
            caps.AddAdditionalCapability("appium:autoGrantPermissions", true);
            caps.AddAdditionalCapability("appium:language", "en");
            caps.AddAdditionalCapability("appium:locale", "en");
            caps.AddAdditionalCapability("appium:fullReset", true);
            caps.AddAdditionalCapability("appium:noReset", false);
            Driver = new AndroidDriver<AppiumWebElement>(new Uri(appiumHost), caps);
            Console.WriteLine("Android Local Test");

            Driver.StartRecordingScreen();
        }

        [TearDown]
        public void StopScreenRecord()
        {
            var video = Driver.StopRecordingScreen();
            byte[] ret = Convert.FromBase64String(video);
            FileInfo file = new($"H:\\videoRecords\\{DateTime.Now:yyyyMMddTHHmmss}.mp4");
            using Stream sw = file.OpenWrite();
            sw.Write(ret, 0, ret.Length);
            sw.Close();
        }
    }
}