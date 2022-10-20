// NOvixx Professional Input/Output Simple English Encoder (Nopiosee)


using System.Reflection.Emit;

namespace Nopioseev2
{
    internal class Program
    {
        static Translator translator = new Translator();

        // Main Nopiosee function
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                askTranslate:
                    Console.WriteLine("Translate: ");
                    string totranslate = Console.ReadLine() + "";
                    string output = translator.Translate(totranslate);
                    Console.WriteLine(output);
                    goto askTranslate;      // oh no, a label!!
                
            }
            else
            {
                string text = File.ReadAllText(args[0]);
                translator.Translate(text);
            }
        }
    }
}