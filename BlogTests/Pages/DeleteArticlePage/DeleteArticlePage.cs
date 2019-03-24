namespace BlogTests.Pages.DeleteArticlePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class DeleteArticlePage : BasePage
    {
        public DeleteArticlePage(IWebDriver driver) : base(driver)
        {
        }


        public void ClickSecondDeleteButton()
        {
            SecondDeleteButton.Click();
        }

    }
}
