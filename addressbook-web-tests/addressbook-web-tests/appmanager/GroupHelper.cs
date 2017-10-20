using System;
using OpenQA.Selenium;


namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {     
        public GroupHelper(ApplicationManager manager) : base(manager)
        {                       
        }

        public GroupHelper CreateGroup( GroupData group) {
            //      NavigationHelper navig = new NavigationHelper(driver, "http://localhost/");
            manager.navigator.GoToGroupspage();
            InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupspage();
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.navigator.GoToGroupspage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupspage();
            return this;
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
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);           
            return this;
        }

        

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
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
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
