using NUnit.Framework;


namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.navigator.OpenHomepage();
            app.session.Login(new AccountData("admin", "secret"));
                                
            
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}
