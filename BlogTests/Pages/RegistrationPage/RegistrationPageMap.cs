namespace BlogTests.Pages.RegistrationPage
{
    using OpenQA.Selenium;

    public partial class RegistrationPage
    {
        public IWebElement EMail => Wait.Until (d => { return d.FindElement(By.Id("Email"));  });

        public IWebElement FullName => Wait.Until(d => { return d.FindElement(By.Id("FullName")); });

        public IWebElement Password => Wait.Until(d => { return d.FindElement(By.Id("Password")); });

        public IWebElement ConfirmPassword => Wait.Until(d => { return d.FindElement(By.Id("ConfirmPassword")); });

        public IWebElement RegistrationPageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement RegisterButton => Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Register""]")); });

        public IWebElement UnsuccessfulRegistrationMessage => Wait.Until(d => { return d.FindElement(By.XPath(@"//div[contains(@class,'text-danger')]/ul/li")); });

    }
}
