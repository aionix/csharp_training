

using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void CompareDetailsAndEditPagesTest()
        {
            ContactData fromEditPage = app.contacts.GetContactInformationFromEditForm(0);
            ContactData fromDetailPage = app.contacts.GetContactInformationFromDetailsPage(0);

            Assert.AreEqual(fromEditPage.AllUserInfo, fromDetailPage.AllUserInfo);
        }

        [Test]
        public void GetContdetails()
        {
            ContactData fromDetails = app.contacts.GetContactInformationFromDetailsPage(0);
            System.Console.WriteLine(fromDetails.AllUserInfo);
        }
    }
}
