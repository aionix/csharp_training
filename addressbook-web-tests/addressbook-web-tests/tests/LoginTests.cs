using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.session.Logout();
            AccountData account = new AccountData("admin", "secret"); ;
            app.session.Login(account);
            Assert.IsTrue(app.session.IsLoggedInWithExpectedUser(account));

        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            app.session.Logout();
            AccountData account = new AccountData("admin", "asd"); ;
            app.session.Login(account);
            Assert.IsFalse(app.session.IsLoggedInWithExpectedUser(account));

        }
    }
}
