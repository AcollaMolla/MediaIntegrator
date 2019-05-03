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
                if (e.GetBaseException().GetType() == typeof(System.IO.IOException))
                {
                    Console.WriteLine("[!]Multiple processes are trying to access this file. Trying to re-read...");
                }
                else if (e.GetBaseException().GetType() == typeof(CsvHelper.BadDataException))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR]Illegal CSV format! Aborting!");
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

        public void writeToCSV(List<Item> list)
        {
            try
            {
                if (list != null)
                {
                    using (var writer = new StreamWriter("tillMediaShop/store.csv"))
                    using (var csv = new CsvWriter(writer))
                    {
                        csv.WriteRecords(list);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[#]Conversion succesful!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }catch(Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR]Conversion failed!" + e);
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
