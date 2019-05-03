using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MediaIntegrator
{
    class XMLHandler
    {
        public List<Item> readFromXML(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    XmlRootAttribute root = new XmlRootAttribute();
                    root.ElementName = "Inventory";
                    //root.IsNullable = false;
                    XmlSerializer xml = new XmlSerializer(typeof(List<Item>), root);
                    List<Item> list = (List<Item>)xml.Deserialize(reader);
                    return list;
                }
            }
            catch (Exception e)
            {
                if (e.GetBaseException().GetType() == typeof(System.IO.IOException))
                {
                    Console.WriteLine("[!]Multiple processes are trying to access this file. Trying to re-read...");
                }
                else if (e.GetBaseException().GetType() == typeof(System.Xml.XmlException))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR]Illegal XML format! Aborting!");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR]The following error occured: " + e);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                return null;
            }
        }
        public void writeToXML(List<Item> list)
        {
            try
            {
                if (list != null)
                {
                    using (var writer = new StreamWriter("tillSimpleMedia/simplemedia.xml"))
                    {
                        XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                        ns.Add("", "");
                        XmlSerializer xml = new XmlSerializer(typeof(List<Item>), new XmlRootAttribute("Inventory"));
                        xml.Serialize(writer, list, ns);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[#]Conversion succesful!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR]Conversion failed!" + e);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
