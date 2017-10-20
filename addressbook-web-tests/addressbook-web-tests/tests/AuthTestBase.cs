using NUnit.Framework;


namespace WebAddressBookTests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {           
            app.session.Login(new AccountData("admin", "secret"));
            //app = new ApplicationManager();
            //app.navigator.OpenHomepage();
            //app.session.Login(new AccountData("admin", "secret"));
        }
    }
}
