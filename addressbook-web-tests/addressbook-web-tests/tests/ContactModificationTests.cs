using NUnit.Framework;
using System.Collections.Generic;

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
            ContactData contact = new ContactData("modified name", null);
            List<ContactData> oldGroup = app.contacts.GetListOfContacts();
            ContactData toBeModified = oldGroup[0];
            app.contacts.Modify(1, contact);

            List<ContactData> newGroup = app.contacts.GetListOfContacts();
            
            foreach (ContactData group in newGroup) {
                if (group.Id.Equals(toBeModified.Id))
                {
                    Assert.AreNotEqual(group.Firstname, toBeModified.Firstname);
                }
            }


        }

    }
}
