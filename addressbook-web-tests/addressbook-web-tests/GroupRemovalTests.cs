using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupremovalTests : TestBase
    {       

        [Test]
        public void GroupRemovalTest()
        {
            OpenHomepage();
            Login(new AccountData("admin","secret"));
            GoToGroupspage();
            SelectGroup(1);
            RemoveGroup();
            Thread.Sleep(1000);
            ReturnToGroupspage();
        }         
     
        }
    }

