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
    public class GroupremovalTests : AuthTestBase
    {       

        [Test]
        public void GroupRemovalTest()
        {
            app.groups.Remove(1);
        }         
     
        }
    }

