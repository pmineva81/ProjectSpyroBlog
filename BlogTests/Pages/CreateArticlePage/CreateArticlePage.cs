namespace BlogTests.Pages.CreateArticlePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class CreateArticlePage : BasePage
    {
        public CreateArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterTitle(string title)
        {
            Title.SendKeys(title);
        }

        public void EnterContent(string content)
        {
            Content.SendKeys(content);
        }

        public void ClickCreateButton()
        {
            CreateButton.Click();
        }

        public void ClickCancelButton()
        {
            CancelButton.Click();
        }

    }
}
