using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace BeepEmulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Marshal.PrelinkAll(typeof(Program));

            ThreadPool.SetMinThreads(0, 0);
            ThreadPool.SetMaxThreads(0, 0);

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].ToLower() == "--help")
                {
                    i++;
                    Console.WriteLine("This is a experimental beep emulator.");
                    Console.WriteLine("List of commands: ");
                    Console.WriteLine("--help                              Get a help");
                    Console.WriteLine("--load        Loads and play file example.beep");
                    //Console.WriteLine("--load          Loads and play file with beeps");
                }
                /*if (args.Length > 0)
                {
                    i++;
                    string beepEntry;
                    foreach (string loadVar in args)
                    {
                        using (var streamReader = new StreamReader($"{loadVar}", Encoding.UTF8))
                        {
                            beepEntry = streamReader.ReadToEnd();
                        }
                    }
                }*/
                if (args[i].ToLower() == "--load")
                {
                    i++;
                    string beepEntry;
                    using (var streamReader = new StreamReader(@".\beeps\example.beep", Encoding.UTF8))
                    {
                        beepEntry = streamReader.ReadToEnd();
                    }
                }
            }
            Console.WriteLine("Launch with \"--help\" arguments to see info.");
            Console.WriteLine("Press any key to exit emulator.");
            Console.ReadKey();
        }
    }
}
