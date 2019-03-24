namespace BlogTests.Pages
{
    using OpenQA.Selenium;

    public partial class LoginPage : BasePage
    {
        public IWebElement LoginPageTitle=> Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement EMail => Wait.Until(d => { return d.FindElement(By.Id("Email")); });

        public IWebElement Password => Wait.Until(d => { return d.FindElement(By.Id("Password")); });

        public IWebElement LogInButton => Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Log in""]")); });

        public IWebElement InvalidLoginMessage => Wait.Until(d => { return d.FindElement(By.CssSelector(@"div.well ul>li")); });


    }
}
