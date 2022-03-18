using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;

namespace ToolsQA
{
    internal class LoginTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\ChromeDriver");
        }

        [Test]
        public void Test()
        {
            
            driver.Url = "https://qa-easyvend.dgcdn.net/Identity/Account/Login?ReturnUrl=%2F";

            LoginPage loginPage = new LoginPage(driver);
            PageFactory.InitElements(driver, loginPage);

            Homepage homePage = loginPage.Login("***", "***");
            homePage.ClickSites();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }
    }
}
