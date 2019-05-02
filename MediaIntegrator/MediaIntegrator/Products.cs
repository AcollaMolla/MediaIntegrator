using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaIntegrator
{
    class Products
    {
        private static List<Item> products;

        public Products()
        {
            products = new List<Item>();
        }
        public void setProductsList(List<Item> list)
        {
            products = list;
        }

        public List<Item> getProducts()
        {
            return products;
        }
    }
}
