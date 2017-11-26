using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressBookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {// write data to csv file
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }
            if (format == "csv")
            {
                WriteToCsvFile(groups, writer);
            }
            else if (format == "xml")
            {
                WriteToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteToJsonFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format: " + format);
            }
            
            writer.Close();
        }

        static void WriteToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }

        static void WriteToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData gr  in groups)
            {
                writer.WriteLine(String.Format("${0},${1},{2}",
                    gr.Name, gr.Header, gr.Footer));
            }
        }
        static void WriteToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

    }
    }

