using System;
using TranslateLib;

namespace ConsoleUI
{
    class Program
    {
        static Translator translator = new Translator(new PhoneTypeDetector());
        static void Main(string[] args)
        {
            Console.WriteLine("Input string: ");
            string input = Console.ReadLine();
            Console.WriteLine("Output string: ");
            Console.WriteLine(translator.Translate(input));
            Console.ReadKey();
        }
    }
}
