

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void CompareDetailsAndEditPagesTest()
        {
            ContactData fromEditPage = app.contacts.GetContactInformationFromEditForm(2);
            ContactData fromDetailPage = app.contacts.GetContactInformationFromDetailsPage(2);

            Assert.AreEqual(fromEditPage.AllUserInfo, fromDetailPage.AllUserInfo);
        }


    }
}

