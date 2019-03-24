namespace BlogTests.Pages.ChangePasswordPage
{
    using OpenQA.Selenium;

    public partial class ChangePasswordPage
    {
        public IWebElement ChangePasswordPageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement CurrentPassword => Wait.Until(d => { return d.FindElement(By.Id("OldPassword")); });

        public IWebElement NewPassword => Wait.Until(d => { return d.FindElement(By.Id("NewPassword")); });

        public IWebElement ConfirmPassword => Wait.Until(d => { return d.FindElement(By.Id("ConfirmPassword")); });

        public IWebElement ChangePasswordButton=> Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Change password""]")); });
    }
}
