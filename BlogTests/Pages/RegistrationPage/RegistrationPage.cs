namespace BlogTests.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using BlogTests.Models;

    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillFormSuccessfulReg(RegistrationUser user)
        {
            //everytime the email should be different 
            //for successful registration
            string secondPartEmail = user.Email.Trim().Remove(0, user.Email.IndexOf('@'));
            string firstPartEmail = Utils.RandomString(5);
            FullName.SendKeys(user.FullName);
            EMail.SendKeys(firstPartEmail + secondPartEmail);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.ConfirmPassword);    
            RegisterButton.Click();
        }

        public void FillForm(RegistrationUser user)
        {
            FullName.SendKeys(user.FullName);
            EMail.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            ConfirmPassword.SendKeys(user.ConfirmPassword);
            RegisterButton.Click();
        }
    }
}
