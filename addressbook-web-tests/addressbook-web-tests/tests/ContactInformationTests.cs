using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void CompareTableAndEditPagesTest()
        {
            ContactData fromTable = app.contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address,      fromForm.Address);
            Assert.AreEqual(fromTable.Allphones,    fromForm.Allphones); //
            Assert.AreEqual(fromTable.Address,      fromForm.Address);
            Assert.AreEqual(fromTable.Allmails,     fromForm.Allmails);
        }

        [Test]
        public void GetdatafromTable()
        {
            ContactData fromTable = app.contacts.GetContactInformationFromDetailsPage(0);
            System.Console.WriteLine(fromTable.AllUserInfo);
        }
    }
}
