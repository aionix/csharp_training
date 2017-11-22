using System;
using System.Text;
using NUnit.Framework;


namespace WebAddressBookTests
{
    public class TestBase
    {
        protected ApplicationManager app;


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
            //    app.session.Login(new AccountData("admin", "secret"));
            //app = new ApplicationManager();
            //app.navigator.OpenHomepage();
            //app.session.Login(new AccountData("admin", "secret"));
        }
        //[TearDown]   option 2
        //public void StopApplicationManager()
        //{
        //    app.Stop();
        //}

        public static Random rnd = new Random();

        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

    }
}

