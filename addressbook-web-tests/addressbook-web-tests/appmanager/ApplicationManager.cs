using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Chrome;

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
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager() {
            Init2();
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
            baseURL = "http://localhost:8090/";
        }

        public void Init2()
        {
                driver = new ChromeDriver(@"C:\drivers\");
            //  Driver.Navigate().GoToUrl("http://localhost:8080/#/kendoPoc");
            Driver.Navigate().GoToUrl("http://localhost:8090/addressbook/");

            //baseURL = "http://localhost:8090/";
        }

         ~ApplicationManager()
        {          
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }            
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.navigator.OpenHomepage();
                app.Value = newInstance;
               
            }
            return app.Value;
        }
        public IWebDriver Driver {
            get {
                return driver;
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
