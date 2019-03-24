namespace BlogTests.Pages.ArticleDetailsPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class ArticleDetailsPage : BasePage
    {
        public ArticleDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickOnEditButton()
        {
            ButtonEdit.Click();
        }

        public void ClickOnDeleteButton()
        {
            ButtonDelete.Click();
        }


    }
}
