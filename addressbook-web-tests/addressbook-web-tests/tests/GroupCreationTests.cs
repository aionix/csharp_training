
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("header_name", "gr head", "gr foot");
            List<GroupData> oldGroup = app.groups.GetGroupsList();

            app.groups.CreateGroup(group);
            Assert.AreEqual(oldGroup.Count+1, app.groups.GetGroupCount());

            List<GroupData> newGroup = app.groups.GetGroupsList();
            oldGroup.Add(group);
            newGroup.Sort();
            oldGroup.Sort();
            
            Assert.AreEqual(oldGroup, newGroup);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {            
            GroupData group = new GroupData("", "", "");

            List<GroupData> oldGroup = app.groups.GetGroupsList();
            app.groups.CreateGroup(group);
                      
            List<GroupData> newGroup = app.groups.GetGroupsList();
            oldGroup.Add(group);
            newGroup.Sort();
            oldGroup.Sort();
            Assert.AreEqual(oldGroup, newGroup);
        }

        [Test]
        public void GetListOfGroups()
        {
            List<GroupData> gr = app.groups.GetGroupsList2();
            for (int i = 0; i < app.groups.GetGroupsList2().Count; i++) {                                
                System.Console.Out.WriteLine(gr[i].Id);
            }
           
        }
        









    }
    }

