namespace BlogTests.Pages.ArticleDetailsPage
{
    using OpenQA.Selenium;

    public partial class ArticleDetailsPage
    {
        public IWebElement FirstArticleText => Wait.Until(d => { return d.FindElement(By.XPath(@"//article/p")); });

        public IWebElement ButtonEdit => Wait.Until(d => { return d.FindElement(By.PartialLinkText("Edit")); });

        public IWebElement ButtonDelete => Wait.Until(d => { return d.FindElement(By.PartialLinkText("Delete")); });


    }
}
