using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MediaIntegrator;

namespace MediaIntegrator
{
    class Program
    {
        private Translator translator;
        private FileWatcher filewatcher;
        public Program()
        {
            translator = new Translator();
            filewatcher = new FileWatcher();
        }
        static void Main(string[] args)
        {
            var p = new Program();
            p.initialize();
            Console.ReadLine();
        }

        private void initialize()
        {
            listenOnOutputFolders();
        }

        private void listenOnOutputFolders()//This method will listen for changes in ../frMediaShop or ../frSimpleMedia
        {
            filewatcher.initialize();
        }
    }
}
