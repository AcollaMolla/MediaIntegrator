﻿using System;
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
        public List<Item> readFromXML()
        {
            try
            {
                using (var reader = new StreamReader("frSimpleMedia/store.xml"))
                {
                    XmlRootAttribute root = new XmlRootAttribute();
                    root.ElementName = "Inventory";
                    root.IsNullable = true;
                    XmlSerializer xml = new XmlSerializer(typeof(List<Item>), root);
                    List<Item> list = (List<Item>)xml.Deserialize(reader);
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public void writeToXML(List<Item> list)
        {
            if (list != null)
            {
                using (var writer = new StreamWriter("tillSimpleMedia/store.xml"))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlSerializer xml = new XmlSerializer(typeof(List<Item>), new XmlRootAttribute("Inventory"));
                    xml.Serialize(writer, list, ns);
                    Console.Out.WriteLine(writer.ToString());
                }
            }
        }
    }
}