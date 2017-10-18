using NUnit.Framework;


namespace WebAddressBookTests.tests
{
    [TestFixture]
    class ContactModification : TestBase
    {
        [Test]
        public void contactModificationTest()
        {
            ContactData contact = new ContactData("modified name");
            app.contacts.Modify(2, contact);

        }

    }
}
