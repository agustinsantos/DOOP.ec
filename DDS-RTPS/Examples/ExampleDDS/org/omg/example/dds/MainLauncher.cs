using ExampleDDS.Common;
using org.omg.example.dds.helloworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleDDS
{
    class MainLauncher
    {
        public static void Main(string[] args)
        {
            ExampleApp app = new MainSharedMem();
             app.RunExample(args);
        }
    }
}
