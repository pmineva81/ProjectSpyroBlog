namespace BlogTests.Pages.CreateArticlePage
{
    using OpenQA.Selenium;

    public partial class CreateArticlePage
    {
        public IWebElement CreateArticlePageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement Title => Wait.Until(d => { return d.FindElement(By.Id("Title")); });

        public IWebElement Content => Wait.Until(d => { return d.FindElement(By.Id("Content")); });

        public IWebElement CancelButton => Wait.Until(d => { return d.FindElement(By.PartialLinkText("Cancel")); });

        public IWebElement CreateButton => Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Create""]")); });

    }
}
