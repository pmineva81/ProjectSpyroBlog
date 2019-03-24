namespace BlogTests.Pages.EditArticlePage
{
    using OpenQA.Selenium;

    public partial class EditArticlePage
    {
        public IWebElement EditArticlePageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });

        public IWebElement Title => Wait.Until(d => { return d.FindElement(By.Id("Title")); });

        public IWebElement Content => Wait.Until(d => { return d.FindElement(By.Id("Content")); });

        public IWebElement SecondEditButton => Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Edit""]")); });

    }
}
