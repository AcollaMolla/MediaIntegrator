using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaIntegrator
{
    class Translator
    {
        private Products products;
        private CSVHandler csvhandler;
        private XMLHandler xmlhandler;
        public Translator()
        {
            products = new Products();
            csvhandler = new CSVHandler();
            xmlhandler = new XMLHandler();
        }
        public void translateFromCSV(string fileName)
        {
            Console.WriteLine("[!]Found CSV file. Converting to XML...");
            products.setProductsList(csvhandler.ReadFromCSV(fileName));
            xmlhandler.writeToXML(products.getProducts());
        }

        public void translateFromXML(string fileName)
        {
            Console.WriteLine("[!]Found XML file. Converting to CSV...");
            products.setProductsList(xmlhandler.readFromXML(fileName));
            csvhandler.writeToCSV(products.getProducts());
        }
    }
}
