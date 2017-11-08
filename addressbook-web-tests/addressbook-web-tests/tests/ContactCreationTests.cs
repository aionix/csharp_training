using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {       
        [Test]
        public void ContactCreationTest()
        {   //prepare data
            ContactData contact = new ContactData("aabbcdeff");          
            contact.Middlename = "mid4 namme";
            contact.Lastname = "l name";
           
            List<ContactData> oldContacts = app.contacts.GetListOfContacts();
            app.contacts.CreateContact(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.contacts.GetListOfContacts().Count);

            List<ContactData> newContacts = app.contacts.GetListOfContacts();

            oldContacts.Add(contact);
            newContacts.Sort();
            oldContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
            
        [Test]
        public void GetListOfGroups()
        {
            System.Console.Out.Write(app.contacts.GetNumberOfSearchResults());

        }
    }
}

