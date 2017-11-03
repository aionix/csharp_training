using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {     
        public GroupHelper(ApplicationManager manager) : base(manager)
        {                       
        }

        public GroupHelper CreateGroup( GroupData group) {
            manager.navigator.GoToGroupspage();
            InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupspage();
            return this;
        }

        public GroupHelper Modify(int n, GroupData newData)
        {
            manager.navigator.GoToGroupspage();
            SelectGroup(n);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupspage();
            return this;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupsList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.navigator.GoToGroupspage();
                ICollection<IWebElement> elements = driver.FindElements(By.ClassName("group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text){
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });                                       
                }                
            } return new List<GroupData>(groupCache);
        }

        public GroupHelper Remove(int p)
        {
            manager.navigator.GoToGroupspage();            
                SelectGroup(p)
                    .RemoveGroup()
                    .ReturnToGroupspage();                       
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            string time = GetCurTime();
            Type(By.Name("group_name"), group.Name); //+ " created:"+time);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);           
            return this;
        }

        

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        } 
            
        public GroupHelper ReturnToGroupspage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public bool IsThereAGroup()
        {
            manager.navigator.GoToGroupspage();
            return isElementPresent(By.CssSelector(".group>input"));
            }

        public int GetGroupCount()
        {
            return driver.FindElements(By.ClassName("group")).Count;
        }

        public List<GroupData> GetGroupsList2()
        {
                manager.navigator.GoToGroupspage();
                List<GroupData> groups = new List<GroupData>();
                ICollection<IWebElement> elements = driver.FindElements(By.ClassName("group"));
                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(element.Text);
                    group.Id = element.FindElement(By.TagName("input")).GetAttribute("value");
                    groups.Add(group);             
                }return groups;

        }
            

        }
    }
    

