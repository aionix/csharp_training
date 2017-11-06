using NUnit.Framework;
using System.Collections.Generic;

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
            List <ContactData> oldContacts = app.contacts.GetListOfContacts();
            ContactData toBeRemoved = oldContacts[0];
                        
            app.contacts.Remove(1);

            List<ContactData> newContacts = app.contacts.GetListOfContacts();
            Assert.AreEqual(oldContacts.Count -1, app.contacts.GetListOfContacts().Count);
            oldContacts.RemoveAt(0);
            foreach (ContactData contact in newContacts) {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }


        }
    }
}
