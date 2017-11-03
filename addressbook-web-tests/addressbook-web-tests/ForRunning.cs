using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace WebAddressBookTests.tests

{[TestClass]
    public class ForRunning
    {
        //public static void Main(String[] args)
        //{
        //thread.sleep(2000);
        //console.writeline("asd");
        //console.readkey();

        [TestMethod]
        public void methodForTesting()
        {

            DateTime thisDay = DateTime.Now;
            String hour = thisDay.Hour.ToString();
            String time = thisDay.Minute.ToString();
            String sec = thisDay.Second.ToString();
            String TheTime = "Hr_" + hour + ":" + time + "." + sec;
            // System.Console.Out.WriteLine(TheTime);
        }

        [TestMethod]
        public void looops() {
            string[] a = new string[] { "asd", "s", "a" };

            foreach (string el in a)
            {
                System.Console.Out.WriteLine(el);
            }
                

              
            }
        }


    }



