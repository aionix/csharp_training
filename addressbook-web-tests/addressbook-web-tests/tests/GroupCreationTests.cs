using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebAddressBookTests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("header_name");
            group.Header = "gr_header";
            group.Footer = "gr_fooot";
            app.groups.CreateGroup(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            app.groups.CreateGroup(new GroupData("", "", ""));
        }
        [Test]
        public void EmptyGroupCreationTest2()
        {
            app.groups.CreateGroup(new GroupData("ddd", null, ""));
        }









    }
    }

