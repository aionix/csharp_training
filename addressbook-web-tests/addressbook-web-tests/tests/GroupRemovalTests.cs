using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupremovalTests : AuthTestBase
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
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroup = app.groups.GetGroupsList();
            GroupData toBeRemoved = oldGroup[0];
            app.groups.Remove(1);
            List<GroupData> newGroup = app.groups.GetGroupsList();
            foreach (GroupData group in newGroup)
            {
                Assert.AreNotEqual(toBeRemoved.Id, group.Id);
            }

        }
    }
}
    

