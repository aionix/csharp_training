using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInfo()
        {
            ContactData fromTable = app.contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromTable);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.Allphones, fromForm.Allphones);
        }

        [Test]
        public void getdatafromTable()
        {
            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(0);
            System.Console.WriteLine(fromForm);
        }
    }
}
