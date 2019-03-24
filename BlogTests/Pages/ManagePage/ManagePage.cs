namespace BlogTests.Pages.ManagePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class ManagePage : BasePage
    {
        public ManagePage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnChangePasswordLink()
        {
            LinkChangePassword.Click();
        }
    }
}
