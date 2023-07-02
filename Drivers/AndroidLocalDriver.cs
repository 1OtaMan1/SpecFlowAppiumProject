using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace SpecFlowAppiumProject.Drivers
{
    public class AndroidLocalDriver
    {
        public AndroidDriver<AppiumWebElement> Driver { get; set; }

        public AndroidDriver<AppiumWebElement> GetDriver()
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

            return new AndroidDriver<AppiumWebElement>(new Uri(appiumHost), caps);
        }
    }
}
