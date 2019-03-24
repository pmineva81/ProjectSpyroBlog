namespace BlogTests.Pages.DeleteArticlePage
{
    using OpenQA.Selenium;

    public partial class DeleteArticlePage
    {
        public IWebElement DeleteArticlePageTitle => Wait.Until(d => { return d.FindElement(By.TagName("h2")); });
      
        public IWebElement SecondDeleteButton => Wait.Until(d => { return d.FindElement(By.CssSelector(@"input[value=""Delete""]")); });
    }
}
