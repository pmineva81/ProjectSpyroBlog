namespace BlogTests.Pages
{
    using OpenQA.Selenium;

    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void FillEmail(string email)
        {
            EMail.SendKeys(email);
        }

        public void FillPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void ClickLogIn()
        {
            LogInButton.Click();
        }
    }
}
