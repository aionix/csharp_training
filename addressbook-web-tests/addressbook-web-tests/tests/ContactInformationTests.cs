using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInfoCompareTest()
        {
            ContactData fromTable = app.contacts.GetContactInformationFromTable(4);
            ContactData fromForm = app.contacts.GetContactInformationFromEditForm(4);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address,      fromForm.Address);
            Assert.AreEqual(fromTable.Allphones,    fromForm.Allphones); //
            Assert.AreEqual(fromTable.Address,      fromForm.Address);
            Assert.AreEqual(fromTable.Allmails,     fromForm.Allmails);
        }

        [Test]
        public void getdatafromTable()
        {
            ContactData fromTable = app.contacts.GetContactInformationFromTable(0);
            System.Console.WriteLine(fromTable.Allmails);
        }
    }
}
