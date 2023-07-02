using Mobile_test_project;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace SpecFlowAppiumProject
{
    [AllureNUnit]
    [TestFixture]
    public class AppTests : BaseAppiumTest
    {
        [Test]
        public void OpenedAppTest()
        {
            var startMessageButton = Driver.FindElementByXPath("//hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout[4]/android.widget.ScrollView/android.widget.FrameLayout/android.widget.TextView");

            startMessageButton.Click();

            
        }

        [Test]
        public void YoutubeTest()
        {
            Driver.PressKeyCode(AndroidKeyCode.Home);

            Thread.Sleep(2000);
            var youTubeIcon = Driver.FindElementByXPath("//android.widget.TextView[@content-desc=\"YouTube\"]");

            Thread.Sleep(2000);
            youTubeIcon.Click();
            Thread.Sleep(2000);

            var pdateButton = Driver.FindElementByXPath("//hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.TextView");
            pdateButton.Click();
            Thread.Sleep(2000);

            var signInButton = Driver.FindElementByXPath("//hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/android.widget.Button");
            Assert.AreEqual("Sign in", signInButton.Text, "Sign in button should have proper Label");
        }

        [Test]
        public void TestMethod2()
        {
            var backButton = Driver.FindElementByXPath("//android.widget.ImageButton[@content-desc=\"Back\"]");

            Thread.Sleep(2000);
            backButton.Click();
            Thread.Sleep(2000);

            var privacyMenuOption = Driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[2]/android.widget.LinearLayout/android.widget.ImageView");

            privacyMenuOption.Click();
            Thread.Sleep(2000);

        }
    }
}