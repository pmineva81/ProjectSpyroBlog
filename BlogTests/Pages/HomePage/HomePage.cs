namespace BlogTests.Pages
{
    using OpenQA.Selenium;

    public partial class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base (driver)
        { }

        public void ClickOnFirstArticle()
        {
            FirstArticleLink.Click();
        }

        public void ClickOnRegisterButton()
        {
            RegisterButton.Click();
        }

        public void ClickOnLogInButton()
        {
            LogInButton.Click();
        }

        public void ClickOnCreateButton()
        {
            CreateButton.Click();
        }

        public void ClickOnCreatedArticleLink()
        {
            CreatedArticleLink.Click();
        }

        public void ClickOnLogOffButton()
        {
            LogOffButton.Click();
        }

        public void ClickOnEditedArticleLink()
        {
            EditedArticleLink.Click();
        }

        public void ClickOnWelcomeUserLink()
        {
            WelcomeUserLink.Click();
        }
    }
}
