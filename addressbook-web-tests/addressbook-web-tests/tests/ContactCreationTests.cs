using NUnit.Framework;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {       
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("created name");          
            contact.Middlename = "mid namme";
            contact.Lastname = "l name";
            app.contacts.CreateContact(contact);
        }
    }
}

