using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaIntegrator
{
    class FileWatcher
    {
        FileSystemWatcher[] watcher;
        string pathForCSV = "frMediaShop";
        string pathForXML = "frSimpleMedia";
        string filterForCSV = "*.csv";
        string filterForXML = "*.xml";

        public FileWatcher()
        {
            watcher = new FileSystemWatcher[2];
        }
        public void initialize()
        {
            createFolders();
            CreateFileWatcher();
        }
        private void CreateFileWatcher()
        {
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    watcher[i] = new FileSystemWatcher();
                    watcher[i].Path = pathForCSV;
                    watcher[i].NotifyFilter = NotifyFilters.LastWrite;
                    watcher[i].Filter = filterForCSV;
                }

                else if (i == 1)
                {
                    watcher[i] = new FileSystemWatcher();
                    watcher[i].Path = pathForXML;
                    watcher[i].NotifyFilter = NotifyFilters.LastWrite;
                    watcher[i].Filter = filterForXML;
                }
                watcher[i].Changed += new FileSystemEventHandler(onChanged);

                watcher[i].EnableRaisingEvents = true;
            }
        }

        private static void onChanged(object source, FileSystemEventArgs e)
        {
            var translator = new Translator();
            var src = (FileSystemWatcher)source;
            if (src.Path.Equals("frMediaShop")) translator.translateFromCSV(e.FullPath);
            else if (src.Path.Equals("frSimpleMedia")) translator.translateFromXML(e.FullPath);
        }

        private void createFolders()//Check if all required folders exist. If not, create them.
        {
            if (!Directory.Exists("frMediaShop")) Directory.CreateDirectory("frMediaShop");
            if (!Directory.Exists("tillMediaShop")) Directory.CreateDirectory("tillMediaShop");
            if (!Directory.Exists("frSimpleMedia")) Directory.CreateDirectory("frSimpleMedia");
            if (!Directory.Exists("tillSimpleMedia")) Directory.CreateDirectory("tillSimpleMedia");
        }
    }
}
