namespace BlogTests.Pages.EditArticlePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;

    public partial class EditArticlePage : BasePage
    {
        public EditArticlePage(IWebDriver driver) : base(driver)
        {
        }
        public void EnterTitle(string title)
        {
            Title.Clear();
            Title.SendKeys(title);
        }

        public void EnterContent(string content)
        {
            Content.Clear();
            Content.SendKeys(content);
        }

        public void ClickSecondEditButton()
        {
            SecondEditButton.Click();
        }

    }
}
