﻿using System;
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
    public class GroupCreationTests : TestBase
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
        public void some() {
            app.groups.InitGroupCreation();
            app.groups.FillGroupForm(new GroupData("some test", "header", " footer"));
            app.groups.SubmitGroupCreation();


        }







    }
    }
