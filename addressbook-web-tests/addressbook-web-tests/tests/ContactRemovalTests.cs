using NUnit.Framework;


namespace WebAddressBookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [SetUp]
        public void Preconditions()
        {
            app.session.Login(new AccountData("admin", "secret"));
            if (!app.contacts.IsThereAContact())
            {
                ContactData contact = new ContactData("created name backup");
                contact.Middlename = "mid namme";
                contact.Lastname = "l name";
                app.contacts.CreateContact(contact);
            }
        }

        [Test]
        public void contactRemove() {
            app.contacts.Remove(1);            
        }
    }
}
