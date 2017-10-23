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
        [SetUp]
        public void Preconditions()
        {
            if (!app.groups.IsThereAGroup())
            {
                app.groups.CreateGroup
                    (new GroupData("back up gr", "backup head", "backup foot"));
            }
        }

        [Test]
        public void GroupModificationTest() {
            GroupData newData = new GroupData("FFFFFFF", null, "GOOOOOOOOOOOOO");
            app.groups.Modify(1, newData);
        }
    }
}

