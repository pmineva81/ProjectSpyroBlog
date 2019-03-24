namespace BlogTests.Pages
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public IWebElement HomePageLogo => Wait.Until(d => { return d.FindElement(By.PartialLinkText("SOFTUNI")); });

        public IWebElement FirstArticleLink => Wait.Until(d => { return d.FindElement(By.XPath(@"//a[contains(@href, '/Article/Details/1')]")); });

        public IWebElement RegisterButton => Wait.Until(d => { return d.FindElement(By.Id("registerLink")); });

        public IWebElement LogInButton => Wait.Until(d => { return d.FindElement(By.Id("loginLink")); });

        public IWebElement CreateButton => Wait.Until(d => { return d.FindElement(By.XPath(@"//a[contains(@href, '/Article/Create')]")); });

        public IWebElement CreatedArticleLink => Wait.Until(d => { return d.FindElement(By.PartialLinkText("test")); });

        public IWebElement LogOffButton => Wait.Until(d => { return d.FindElement(By.PartialLinkText("Log off")); });

        public IWebElement EditedArticleLink => Wait.Until(d => { return d.FindElement(By.PartialLinkText("edit")); });

        public IWebElement WelcomeUserLink => Wait.Until(d => { return d.FindElement(By.CssSelector(@"a[title=""Manage""]")); });
    }
}
