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
        public void translateFromCSV()
        {
            products.setProductsList(csvhandler.ReadFromCSV());
            xmlhandler.writeToXML(products.getProducts());
        }

        public void translateFromXML()
        {
            products.setProductsList(xmlhandler.readFromXML());
            csvhandler.writeToCSV(products.getProducts());
        }
    }
}
