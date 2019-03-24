namespace BlogTests.Pages.ManagePage
{
    using OpenQA.Selenium;

    public partial class ManagePage
    {
        public IWebElement ManagePageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement LinkChangePassword => Wait.Until(d => { return d.FindElement(By.PartialLinkText("password")); });

        public IWebElement ManagePageSuccess => Wait.Until(d => { return d.FindElement(By.CssSelector(@"p.text-success")); });
    }
}
