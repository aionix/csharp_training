using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;


namespace WebAddressBookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected HelperBase helperbase;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigation;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager() {
            Init();
            loginHelper = new LoginHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);

        }

        public void Init() {
            FirefoxOptions options = new FirefoxOptions();
            options.UseLegacyImplementation = true;
            options.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            driver = new FirefoxDriver(options);
            baseURL = "http://localhost/";

        }
        public IWebDriver Driver {
            get {
                return driver;
            }
        }

        public void Stop() {
            try { driver.Quit();
            } catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public LoginHelper session {
            get {
                return loginHelper;
            }
        }
        public NavigationHelper navigator {
            get {
                return navigation;
            }
        }
        public GroupHelper groups {
            get {
                return groupHelper;
            }
        }
        public ContactHelper contacts {
            get{
                return contactHelper;            
            }
        }

        
    }
}
