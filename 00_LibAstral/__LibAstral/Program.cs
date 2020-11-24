using System;
using System.ComponentModel;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace __LibAstral
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Marshal.PrelinkAll(typeof(Program));
            while (true)
            {
                Console.BackgroundColor = GetRandomConsoleColor();
                Console.ForegroundColor = GetRandomConsoleColor();
                Console.Write(GenRandomString(Guid.NewGuid().ToString("n").Substring(0, 8), 1));
            }
        }

        private static string GenRandomString(string Alphabet, int Length)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;

            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }

            return sb.ToString();
        }

        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    }
}
