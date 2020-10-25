using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;

namespace __LibAstral
{
    class Program
    {
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        static void Main(string[] args)
        {
            Marshal.PrelinkAll(typeof(Program));

            IntPtr hProv = (IntPtr)0;
            
            [System.Runtime.InteropServices.DllImport("advapi32.dll")]
            static extern bool CryptGenRandom(IntPtr hProv, int dwLen, byte[] pbBuffer);

            byte[] newRandom = new byte[10];

            [DllImport("kernel32")]
            static extern int HeapSize(int hHeap, int flags);

            Guid guid = Guid.NewGuid();
            ulong blyat = 2147483647;
            var cyka = guid.ToString().Split((char)blyat);

            var random = new Random();
            int number = random.Next(Int32.MinValue, Int32.MaxValue);
            uint uintNumber = (uint)(number + (uint)Int32.MaxValue);

            if (!CryptGenRandom(hProv, (int)(uint)(newRandom.Length), newRandom))
            {
                while (true)
                {
                    Console.ForegroundColor = GetRandomConsoleColor();
                    //Console.Write(Marshal.ReadInt32((IntPtr)HeapSize(Convert.ToInt32(cyka),0)));

                    Console.Write(Marshal.ReadInt32((IntPtr)HeapSize(number, 0)));
                }
            }
        }

        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    }
}
