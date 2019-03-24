namespace BlogTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using BlogTests.Models;
    using BlogTests.Pages;
    using BlogTests.Pages.RegistrationPage;
    using BlogTests.Pages.ArticleDetailsPage;
    using BlogTests.Pages.CreateArticlePage;
    using System;
    using System.IO;
    using System.Reflection;
    using FluentAssertions;
    using BlogTests.Pages.DeleteArticlePage;
    using BlogTests.Pages.EditArticlePage;
    using BlogTests.Pages.ChangePasswordPage;
    using BlogTests.Pages.ManagePage;

    [TestFixture]
    public class Automation
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private HomePage homePage;
        private LoginPage loginPage;
        private RegistrationPage regPage;
        private BasePage basePage;
        private ArticleDetailsPage articleDetailsPage;
        private CreateArticlePage createArticlePage;
        private DeleteArticlePage deleteArticlePage;
        private EditArticlePage editArticlePage;
        private ChangePasswordPage changePasswordPage;
        private ManagePage managePage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            basePage = new BasePage(driver);
            driver.Navigate().GoToUrl(basePage.BaseUrl);
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            regPage = new RegistrationPage(driver);
            articleDetailsPage = new ArticleDetailsPage(driver);
            createArticlePage = new CreateArticlePage(driver);
            deleteArticlePage = new DeleteArticlePage(driver);
            editArticlePage = new EditArticlePage(driver);
            changePasswordPage = new ChangePasswordPage(driver);
            managePage = new ManagePage(driver);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckWeAreOnHomePage()
        {
            Assert.AreEqual("SOFTUNI BLOG", homePage.HomePageLogo.Text);
        }

        [Test]
        public void CheckFirstArticleCantBeEditedWhenUserIsNotRegistered()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnFirstArticle();
            Assert.AreEqual("Hello I am new here and try functionality!!!!!!!", articleDetailsPage.FirstArticleText.Text);
            articleDetailsPage.ClickOnEditButton();
            Assert.AreEqual("Log in", loginPage.LoginPageTitle.Text);
        }

        [Test]
        public void CheckSuccessfulRegistration()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnRegisterButton();
            Assert.AreEqual("Register", regPage.RegistrationPageTitle.Text);

            var path = Path.GetFullPath(
               Directory.GetCurrentDirectory() +
               "/../../../Jsons/UserRegistrationWithAllData.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            regPage.FillFormSuccessfulReg(user);
            CheckWeAreOnHomePage();
            Assert.IsNotNull(homePage.CreateButton);
        }

        [Test]
        public void CheckUnsuccessfulRegistrationWithInvalidMailFormat()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnRegisterButton();
            Assert.AreEqual("Register", regPage.RegistrationPageTitle.Text);

            var path = Path.GetFullPath(
               Directory.GetCurrentDirectory() +
               "/../../../Jsons/UserRegistrationWithInvalidMailFormat.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            regPage.FillForm(user);
            Assert.AreEqual("Register", regPage.RegistrationPageTitle.Text);
            Assert.AreEqual("The Email field is not a valid e-mail address.", regPage.UnsuccessfulRegistrationMessage.Text);
        }

        [Test]
        public void CheckSuccessfulSignIn()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnLogInButton();
            Assert.AreEqual("Log in", loginPage.LoginPageTitle.Text);
            loginPage.FillEmail("bbb@abv.bg");
            loginPage.FillPassword("test");
            loginPage.ClickLogIn();
            CheckWeAreOnHomePage();
            Assert.IsNotNull(homePage.CreateButton);
        }

        [Test]
        public void CheckUnsuccessfulSignIn()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnLogInButton();
            Assert.AreEqual("Log in", loginPage.LoginPageTitle.Text);
            loginPage.FillEmail("ttt@abv.bg");
            loginPage.FillPassword("test");
            loginPage.ClickLogIn();
            Assert.AreEqual("Log in", loginPage.LoginPageTitle.Text);
            Assert.AreEqual("Invalid login attempt.", loginPage.InvalidLoginMessage.Text);
        }

        [Test]
        public void CreateArticle()
        {
            CheckSuccessfulSignIn();
            homePage.ClickOnCreateButton();
            Assert.AreEqual("Create Article", createArticlePage.CreateArticlePageTitle.Text);
            createArticlePage.EnterTitle("bbb");
            createArticlePage.EnterContent("description");
            createArticlePage.ClickCreateButton();
            CheckWeAreOnHomePage();
            homePage.CreatedArticleLink.Text.Should().Be("bbb");
        }


        [Test]
        public void CreateArticleAndDeleteIt()
        {
            CheckSuccessfulSignIn();
            homePage.ClickOnCreateButton();
            Assert.AreEqual("Create Article", createArticlePage.CreateArticlePageTitle.Text);
            createArticlePage.EnterTitle("test");
            createArticlePage.EnterContent("test test test");
            createArticlePage.ClickCreateButton();
            CheckWeAreOnHomePage();
            homePage.CreatedArticleLink.Text.Should().Be("test");
            homePage.ClickOnCreatedArticleLink();
            Assert.AreEqual("test test test", articleDetailsPage.FirstArticleText.Text);
            articleDetailsPage.ClickOnDeleteButton();
            deleteArticlePage.ClickSecondDeleteButton();
            CheckWeAreOnHomePage();
            try
            {
                homePage.CreatedArticleLink.Text.Should().Be("test");
                Assert.Fail("The article is on homepage");
            }
            catch (Exception ex)
            {
                if (ex is WebDriverTimeoutException || ex is NoSuchElementException)
                {
                    Assert.Pass("The deleted article is not on homepage");
                    return;
                }
                throw;    
            }
        }

        [Test]
        public void SuccessfulLogOff()
        {
            CheckSuccessfulSignIn();
            homePage.ClickOnLogOffButton();
            CheckWeAreOnHomePage();
            Assert.IsNotNull(homePage.LogInButton);
            
        }

        [Test]
        public void CreateEditDeleteArticle()
        {
            CreateArticle();
            homePage.ClickOnCreatedArticleLink();
            Assert.AreEqual("test test test", articleDetailsPage.FirstArticleText.Text);
            articleDetailsPage.ClickOnEditButton();
            Assert.AreEqual("Edit Article", editArticlePage.EditArticlePageTitle.Text);
            editArticlePage.EnterTitle("edit");
            editArticlePage.EnterContent("edit edit");
            editArticlePage.ClickSecondEditButton();
            CheckWeAreOnHomePage();
            homePage.ClickOnEditedArticleLink();
            Assert.AreEqual("edit edit", articleDetailsPage.FirstArticleText.Text);
            articleDetailsPage.ClickOnDeleteButton();
            deleteArticlePage.ClickSecondDeleteButton();
            CheckWeAreOnHomePage();
            //Assert.IsNull(homePage.EditedArticleLink);
            //to-do check the new article is NOT on home page
        }

        [Test]
        public void ChangePassword()
        {
            CheckWeAreOnHomePage();
            homePage.ClickOnLogInButton();
            Assert.AreEqual("Log in", loginPage.LoginPageTitle.Text);
            loginPage.FillEmail("test@abv.bg");
            loginPage.FillPassword("test");
            loginPage.ClickLogIn();
            CheckWeAreOnHomePage();
            homePage.ClickOnWelcomeUserLink();
            Assert.AreEqual("Manage", managePage.ManagePageTitle.Text);
            managePage.ClickOnChangePasswordLink();
            Assert.AreEqual("Change Password", changePasswordPage.ChangePasswordPageTitle.Text);
            changePasswordPage.FillCurrentPassword("test");
            changePasswordPage.FillNewPassword("test");
            changePasswordPage.FillConfirmPassword("test");
            changePasswordPage.ClickChangePasswordButton();
            Assert.AreEqual("Your password has been changed.", managePage.ManagePageSuccess.Text);
        }
    }
}
