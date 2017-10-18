using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests
{ 
    
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest() {
            GroupData newData = new GroupData("new name", "new string", "new footer");
            app.groups.Modify(1, newData);
        }
    }
}

