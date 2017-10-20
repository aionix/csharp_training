using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests.tests
{ 
    
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest() {
            GroupData newData = new GroupData("FFFFFFF", null, "GOOOOOOOOOOOOO");
            app.groups.Modify(1, newData);
        }
    }
}

