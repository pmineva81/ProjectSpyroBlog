namespace BlogTests.Pages.ChangePasswordPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class ChangePasswordPage : BasePage
    {
        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
        }
        public void FillCurrentPassword(string currentpass)
        {
            CurrentPassword.SendKeys(currentpass);
        }

        public void FillNewPassword(string newpassword)
        {
            NewPassword.SendKeys(newpassword);
        }

        public void FillConfirmPassword(string confirmpassword)
        {
            ConfirmPassword.SendKeys(confirmpassword);
        }
        public void ClickChangePasswordButton()
        {
            ChangePasswordButton.Click();
        }
    }
}
