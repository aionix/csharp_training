using NUnit.Framework;


namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            //    app.session.Login(new AccountData("admin", "secret"));
            //app = new ApplicationManager();
            //app.navigator.OpenHomepage();
            //app.session.Login(new AccountData("admin", "secret"));
        }
        //[TearDown]   option 2
        //public void StopApplicationManager()
        //{
        //    app.Stop();
        //}

    }
}

