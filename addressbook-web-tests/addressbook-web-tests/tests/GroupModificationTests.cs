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
            GroupData newData = new GroupData("modified F1", null, "GOOOOOOOOOOOOO");
            List<GroupData> oldGroup = app.groups.GetGroupsList();
            GroupData olddata = oldGroup[0];

            app.groups.Modify(1, newData);

            List<GroupData> newGroup = app.groups.GetGroupsList();
            oldGroup[0].Name = newData.Name;
            newGroup.Sort();
            oldGroup.Sort();
            Assert.AreEqual(oldGroup, newGroup);

            foreach (GroupData group in newGroup) {
                if (group.Id == olddata.Id ) {
                    Assert.AreEqual(group.Name, newData.Name);

                }
            }
        
        }
    }
}

