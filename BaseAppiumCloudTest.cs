using NUnit.Framework;
using NUnit.Allure.Core;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Newtonsoft.Json.Linq;

namespace SpecFlowAppiumProject
{
    [AllureNUnit]
    [TestFixture]

    public class BaseAppiumCloudTest
    {
        private AppiumDriver<AppiumWebElement> Driver;

        [SetUp]
        public void Setup()
        {
            var myJsonString = File.ReadAllText("test_settings.json"); 
            var myJObject = JObject.Parse(myJsonString);
            string momentumUser = myJObject.SelectToken("CLOUD.momentumUser").Value<string>();
            string momentumToken = myJObject.SelectToken("CLOUD.momentumToken").Value<string>();
            string momentumHost = myJObject.SelectToken("CLOUD.momentumHost").Value<string>();
            string momentumApp = myJObject.SelectToken("CLOUD.android.momentumApp").Value<string>();
            JArray momentumDeviceList = (JArray)myJObject["CLOUD"]["android"]["momentumDeviceList"];
            JToken momentumDeviceId = momentumDeviceList[0];

            AppiumOptions caps = new AppiumOptions();
            Dictionary<string, object> momentumOptions = new Dictionary<string, object>();
            caps.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            caps.AddAdditionalCapability("appium:autoGrantPermissions", true);
            caps.AddAdditionalCapability("appium:language", "en");
            caps.AddAdditionalCapability("appium:locale", "en");
            caps.AddAdditionalCapability("appium:deviceName", "");
            caps.AddAdditionalCapability("appium:udid", "");
            caps.AddAdditionalCapability("appium:app", momentumApp);
            caps.AddAdditionalCapability("appium:fullReset", true);
            caps.AddAdditionalCapability("appium:noReset", false);
            momentumOptions.Add("user",momentumUser);
            momentumOptions.Add("token", momentumToken);
            momentumOptions.Add("gw", momentumDeviceId);
            caps.AddAdditionalCapability("momentum:options", momentumOptions);
            Driver = new AndroidDriver<AppiumWebElement>(new Uri(momentumHost), caps);
            Console.WriteLine("Android First Test");
        }

        [Test]
        public void TestFirstAndroidLogin()
        {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(e => e.FindElement(By.Id("username_txt"))).SendKeys("first@mobven.com");
                Driver.FindElement(By.Id("password_txt")).SendKeys("Pass321*");
                Driver.FindElement(By.Id("login_btn")).Click();
                Thread.Sleep(1000);
                wait.Until(e => e.FindElement(By.Id("account_layout")).Displayed);
        }

        [TearDown]
        public void AfterTest()
        {
            Driver.Quit();
        }
    }
}
