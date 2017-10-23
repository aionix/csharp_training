using NUnit.Framework;


namespace WebAddressBookTests.tests
{
    [TestFixture]
    class ContactModification : AuthTestBase
    {
        [SetUp]
        public void Preconditions()
        {            
            if (!app.contacts.IsThereAContact())
            {
                ContactData contact = new ContactData("created name backup");
                contact.Middlename = "mid namme";
                contact.Lastname = "l name";
                app.contacts.CreateContact(contact);
            }
        }

        [Test]
        public void contactModificationTest()
        {
            ContactData contact = new ContactData("modified name");
            app.contacts.Modify(1, contact);

        }

    }
}
