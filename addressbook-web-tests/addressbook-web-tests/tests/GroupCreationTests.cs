
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1], Footer = parts[2]
                });
            }
            return groups;
        }

        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {         
         
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
            Assert.AreEqual(oldGroup.Count + 1, app.groups.GetGroupCount());

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

