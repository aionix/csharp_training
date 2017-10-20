using NUnit.Framework;


namespace WebAddressBookTests.tests
{
    [TestFixture]
    class ContactRemovalTests : TestBase
    {
        [Test]
        public void contactRemove() {
            app.contacts.Remove(5);            
        }
    }
}
