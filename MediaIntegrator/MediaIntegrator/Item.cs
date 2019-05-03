using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MediaIntegrator
{
    [XmlRoot("Inventory")]
    public class Item
    {
        private string name;
        private int id;
        private string price;
        private int qty;

        public Item(string name, int id, string price, int qty)
        {
            this.name = name;
            this.id = id;
            this.price = price;
            this.qty = qty;
        }

        public Item()
        {

        }

        [XmlElement("Name")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [XmlElement("ProductID")]
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        [XmlElement("Price")]
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        [XmlElement("Count")]
        public int QTY
        {
            get
            {
                return qty;
            }
            set
            {
                qty = value;
            }
        }


    }
}
