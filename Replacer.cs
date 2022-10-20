using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nopioseev2
{
    // Misc replaces
    internal class Replacer
    {
        public static string ReplaceCaseInsensitive(string Text, string Find, string Replace)
        {
            List<char> NewText = Text.ToCharArray().ToList();

            int LastIndex = -1;
            LastIndex = Text.IndexOf(Find, LastIndex + 1, StringComparison.CurrentCultureIgnoreCase);
            if (LastIndex == -1)
            {
                return Text;
            }
            NewText.RemoveRange(LastIndex, Find.Length);
            for (int i = 0; i < Replace.Length; i++)
            {
                try
                {
                    if (Translator.IsAllUpper(Text) && Text.Length != 2) // != 2: checks if the string is not 1 character long (not not 2!)
                    {
                        NewText.Insert(LastIndex + i, char.ToUpper(Replace[i]));
                        continue;
                    }
                    if (char.IsUpper(Text[i + LastIndex]))
                        NewText.Insert(LastIndex + i, char.ToUpper(Replace[i]));
                    else
                        NewText.Insert(LastIndex +i, char.ToLower(Replace[i]));
                }
                catch
                {
                    NewText.Insert(LastIndex + i, char.ToLower(Replace[i]));
                }
            }
            return new string(NewText.ToArray()).Trim();
        }
        public static string ReverseReplace(string str, string one, string two)
        {
            if (str.Contains(one, StringComparison.OrdinalIgnoreCase) && str.Contains(two, StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    // Warning! Ugly/messy/buggy code ahead!
                    List<string> strings = str.Split(" ").ToList();
                    List<string> tempList = str.Split(" ").ToList();
                    int index1 = strings.FindIndex(n => n.Equals(one, StringComparison.OrdinalIgnoreCase));
                    int index2 = strings.FindIndex(n => n.Equals(two, StringComparison.OrdinalIgnoreCase));
                    strings.RemoveAt(strings.FindIndex(n => n.Equals(one, StringComparison.OrdinalIgnoreCase)));
                    strings.RemoveAt(strings.FindIndex(n => n.Equals(two, StringComparison.OrdinalIgnoreCase)));
                    strings.Insert(index1, str.Substring(str.IndexOf(two, StringComparison.OrdinalIgnoreCase), two.Length));
                    strings.Insert(index2, str.Substring(str.IndexOf(one, StringComparison.OrdinalIgnoreCase), one.Length));
                    string toRet = "";
                    foreach (string s in strings)
                    {
                        toRet += s + " ";
                    }
                    toRet = toRet.Remove(toRet.Length - 1);
                    return toRet;
                }
                catch
                {
                    return str;
                }
            }
            else
            {
                return str;
            }
        }
    }
}
