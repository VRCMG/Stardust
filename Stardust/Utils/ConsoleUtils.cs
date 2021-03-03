using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardust.Utils
{
    public static class ConsoleUtils
    {
        public static void Write(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("root@stardust");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("$ ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("root@stardust");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("$ ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InputWrite(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"root@stardust ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{text}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("$ ");
        }

        public static void InputWrite(string login, string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{login}@stardust ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"[{text}]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(":");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("~");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("$ ");
        }
    }
}
