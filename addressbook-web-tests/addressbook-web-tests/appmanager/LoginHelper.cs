using System;
using OpenQA.Selenium;


namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                if (IsLoggedInWithExpectedUser(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            Click(By.CssSelector("input[type=\"submit\"]"));
        }
        
        public bool isLoggedIn()
        {
            return isElementPresent(By.Name("logout"));
        }
        
        public bool IsLoggedInWithExpectedUser(AccountData account)
        {
            System.Console.Out.WriteLine(GetLoggedUserName());
            return isLoggedIn() 
                && GetLoggedUserName() == account.Username;
        }
        public string GetLoggedUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public void Logout()
        {
            if (isLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }return;
            
        }
    }
}
