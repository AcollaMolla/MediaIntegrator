using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaIntegrator
{
    class CSVHandler
    {
        public List<Item> ReadFromCSV(string fileName)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.Delimiter = ";";
                    var records = csv.GetRecords<Item>();
                    return records.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public void writeToCSV(List<Item> list)
        {
            if (list != null)
            {
                using (var writer = new StreamWriter("tillMediaShop/store.csv"))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(list);
                }
            }
        }
    }
}
