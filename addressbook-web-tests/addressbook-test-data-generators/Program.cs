using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using WebAddressBookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {// write data to csv file
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            
            string format = args[2];
            string type = args[3];
            List<ContactData> contacts = new List<ContactData>();
            List<GroupData> groups = new List<GroupData>();

            if (type == "groups")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(5),
                        Footer = TestBase.GenerateRandomString(5)
                    });
                }
            }
            else if (type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Lastname = TestBase.GenerateRandomString(25),
                        Middlename = TestBase.GenerateRandomString(25)
                    });
                }
            }
            else
            {
                System.Console.Out.WriteLine("no such type: "+ type);
            }
            
            if (format == "excel")
            {
                WriteToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    WriteToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    if (type == "groups")
                    {
                        WriteToXmlFile(groups, writer);
                    }
                    else if (type == "contacts")
                    { 
                        WriteToXmlFile(contacts, writer);  
                    }
                    else
                    {
                        System.Console.WriteLine("Fuuuuuuuuuuuuuuuuck");
                    }
                    
                }
                else if (format == "json")
                {
                    if (type == "groups")
                    {
                        WriteToJsonFile(groups, writer);
                    }
                    else if (type == "contacts")
                    {
                        WriteToJsonFile(contacts, writer);
                    }
                    
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format: " + format);
                }
                writer.Close();
            }
        }

        
        static void WriteToExcelFile(IList<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;
            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);
            wb.Close();
            app.Visible = false;
        }

        static void WriteToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups));
        }
        static void WriteToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts));
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
        static void WriteToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
    }

