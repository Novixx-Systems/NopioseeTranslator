using System.Text;
using System.Text.RegularExpressions;

namespace Nopioseev2
{
    /// <summary>
    /// The translator LITERALLY replaces English with Nopiosee
    /// Note that this is basically the main file
    /// </summary>
    internal class Translator
    {
        /// <summary>
        /// Translates English to Nopiosee
        /// </summary>
        /// <param name="strToTranslate">The english string to translate</param>
        /// <returns></returns>
        public string Translate(string strToTranslate)
        {
            BuildNopiosee builder = new BuildNopiosee();
            TranslateIgnore ignoreList = new TranslateIgnore();
            Words words = new Words();
            bool split = false;
            int amountDone = 0;
            int needed = 0;
            string[] splitted = strToTranslate.Split(" ");
            if (splitted.Length > 500)
            {
                needed = splitted.Length;
                split = true;
            }
            // VARIABLES
            string toRet = "";
            List<string> lst = builder.ParseEnglish(strToTranslate.Replace("?", " ?").Replace("!", " !").Replace(".", " .").Replace(",", " ,").Replace("(", " (").Replace(")", " )").Replace(":", " :"));
            for (int i = 0; i < lst.Count; i++)
            {
                string str  = lst[i].Trim() + " ";
                string strToCompare = Regex.Replace(str.ToLower(), @"[^\w\d\s]", "");
                //
                //      NOTE: Use +2, not +1
                //
                if (lst.Count - 1 > (i+1) && BuiltIn.BuiltIns.ContainsKey(strToCompare + lst[i + 2].Trim().ToLower() + " "))
                {
                    string IgnoreString1 = lst[i+2].Trim();
                    lst.RemoveAt(i);
                    lst.RemoveAt(i);
                    lst.RemoveAt(i);
                    lst.Insert(i, Replacer.ReplaceCaseInsensitive(str, Regex.Replace(str, @"[^\w\d\s]", ""), BuiltIn.BuiltIns[strToCompare + IgnoreString1.ToLower() + " "]));
                    ignoreList.toIgnore.Add(str);
                    ignoreList.toIgnore.Add(IgnoreString1);
                }
                else if (BuiltIn.BuiltIns.ContainsKey(strToCompare))
                {
                    lst.RemoveAt(i);
                    foreach (string str2 in BuiltIn.BuiltIns[strToCompare].Split(" "))
                    {
                        ignoreList.toIgnore.Add(str2);
                    }
                    foreach (string str2 in BuiltIn.BuiltIns[strToCompare].Split(" "))
                    {
                        if (str2 != "")
                        {
                            string stro = Replacer.ReplaceCaseInsensitive(str, Regex.Replace(str, @"[^\w\d\s]", ""), str2);
                            // BUG: "ta mei play" gets set as "tae mei play"
                            //      so we have to hard code it here.
                            if (stro == "tae")
                            {
                                stro = "ta";
                            }
                            lst.Insert(i, stro);
                            lst.Insert(i+1, " ");
                            i++;
                            i++;
                        }
                    }
                }
                if (split)
                {
                    amountDone++;
                    Console.WriteLine(amountDone + "/" + needed);
                }
            }
            amountDone = 0;
            foreach (string str in lst)
            {
                string chk = Regex.Replace(str.ToLower(), @"[^\w\d\s]", "");
                string strRet = str;
                if (!words.toTranslate.Contains(chk, StringComparer.OrdinalIgnoreCase)) // If not an english word
                {
                    toRet += str;
                    continue;
                }
                if (ignoreList.toIgnore.Contains(chk, StringComparer.OrdinalIgnoreCase))  // If it's a (company-)name
                {
                    toRet += str;
                    continue;
                }
                // Remember when I said it literally replaces? Well...
                // PHASE 1. ENCODE [ DO NOT TOUCH UNLESS REQUIRED ]
                strRet = ReplaceCaseInsensitive(strRet, "llion", "lleon");
                strRet = ReplaceCaseInsensitive(strRet, "or", "zeek");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "aa", "o");        // Using the one in the "replaces" class so we can have shorter words
                strRet = ReplaceCaseInsensitive(strRet, "li", "va");
                strRet = ReplaceCaseInsensitive(strRet, "her", "zov");
                strRet = ReplaceCaseInsensitive(strRet, "come", "here");
                strRet = ReplaceCaseInsensitive(strRet, "wel", "wy");
                strRet = ReplaceCaseInsensitive(strRet, "an", "oo");
                strRet = ReplaceCaseInsensitive(strRet, "tha", "deq");
                strRet = ReplaceCaseInsensitive(strRet, "et", "ja");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "mes", "go");
                strRet = ReplaceCaseInsensitive(strRet, "lo", "ze");
                strRet = ReplaceCaseInsensitive(strRet, "ag", "jo");
                strRet = ReplaceCaseInsensitive(strRet, "nee", "qe");
                strRet = ReplaceCaseInsensitive(strRet, "ima", "nes");
                strRet = ReplaceCaseInsensitive(strRet, "am", "yogo");
                strRet = ReplaceCaseInsensitive(strRet, "zer", "qoo");
                strRet = ReplaceCaseInsensitive(strRet, "ser", "ee");
                strRet = ReplaceCaseInsensitive(strRet, "do", "kel");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "lion", "lez");
                strRet = ReplaceCaseInsensitive(strRet, "te", "too");
                strRet = ReplaceCaseInsensitive(strRet, "bro", "bla");
                strRet = ReplaceCaseInsensitive(strRet, "th", "do");
                strRet = ReplaceCaseInsensitive(strRet, "mp", "ve");
                strRet = ReplaceCaseInsensitive(strRet, "you", "yas");
                strRet = ReplaceCaseInsensitive(strRet, "so", "zo");
                strRet = ReplaceCaseInsensitive(strRet, "rry", "se");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "know", "nó");        // Using the one in the "replaces" class so we can have shorter words
                strRet = ReplaceCaseInsensitive(strRet, "ing", "le");
                strRet = ReplaceCaseInsensitive(strRet, "ing", "le");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "to", "y");        // Using the one in the "replaces" class so we can have shorter words
                strRet = ReplaceCaseInsensitive(strRet, "ne", "ay");
                strRet = ReplaceCaseInsensitive(strRet, "ar", "qu");
                strRet = ReplaceCaseInsensitive(strRet, "sur", "ul");
                strRet = ReplaceCaseInsensitive(strRet, "app", "ap");
                strRet = ReplaceCaseInsensitive(strRet, "py", "e");
                strRet = ReplaceCaseInsensitive(strRet, "liv", "qaz");
                strRet = ReplaceCaseInsensitive(strRet, "vi", "una");
                strRet = ReplaceCaseInsensitive(strRet, "web", "weg");
                strRet = ReplaceCaseInsensitive(strRet, "ma", "losi");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "dest", "des");        // Using the one in the "replaces" class so we can have shorter words
                strRet = ReplaceCaseInsensitive(strRet, "ina", "oh");
                strRet = ReplaceCaseInsensitive(strRet, "true", "verdad");
                strRet = ReplaceCaseInsensitive(strRet, "fals", "unk");
                strRet = ReplaceCaseInsensitive(strRet, "ell", "alse");
                strRet = ReplaceCaseInsensitive(strRet, "truth", "verdad");
                strRet = ReplaceCaseInsensitive(strRet, "use", "uz");
                strRet = ReplaceCaseInsensitive(strRet, "id", "a");
                strRet = ReplaceCaseInsensitive(strRet, "how", "qoo");
                strRet = ReplaceCaseInsensitive(strRet, "ver", "klas");
                strRet = ReplaceCaseInsensitive(strRet, "fil", "fis");
                strRet = ReplaceCaseInsensitive(strRet, "rr", "lor");
                strRet = ReplaceCaseInsensitive(strRet, "hqu", "hya");
                // PHASE 2. FINAL MODIFICATIONS
                strRet = ReplaceCaseInsensitive(strRet, "cze", "zeg");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "eee", "e");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "ee", "o");
                strRet = ReplaceCaseInsensitive(strRet, "lj", "el");
                strRet = ReplaceCaseInsensitive(strRet, "zl", "zh");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "óo", "ó");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "dj", "d");
                strRet = ReplaceCaseInsensitive(strRet, "isl", "oel");
                strRet = Replacer.ReplaceCaseInsensitive(strRet, "drj", "d");
                strRet = strRet.Replace("erzeo", "", StringComparison.OrdinalIgnoreCase);        // For pronounciation
                // PHASE 3. MODIFY ENDING
                string strRetReg = Regex.Replace(strRet, @"[^\w\d\s]", "");
                if (strRetReg.EndsWith("s", StringComparison.OrdinalIgnoreCase))
                {
                    StringBuilder changeChar = new StringBuilder(strRet);
                    changeChar[strRet.LastIndexOf("s", StringComparison.OrdinalIgnoreCase)] = (strRet.Substring(strRet.Length - 1).Any(char.IsUpper) ? 'E' : 'e');
                    strRet = changeChar.ToString();
                }
                else if (strRetReg.EndsWith("ing", StringComparison.OrdinalIgnoreCase))
                {
                    strRet = strRet.Substring(0, strRet.Length - 3) + (strRet.Substring(strRet.Length - 3).Any(char.IsUpper) ? "A" : "a");
                }
                // Put ending
                toRet += strRet;
                if (split)
                {
                    amountDone++;
                    Console.WriteLine(amountDone + "/" + needed);
                    if ((amountDone % 250) == 0)
                    {
                        Console.Clear();
                    }
                    if ((amountDone % 50000) == 0)
                    {
                        File.WriteAllText("out.see", toRet);
                    }
                }
            }
            // Simple reversereplace
            toRet = Replacer.ReverseReplace(toRet, "yogo", "mei").Trim();

            toRet = toRet.Replace(" ?", "?").Replace(" !", "!").Replace(" .", ".").Replace(" ,", ",").Replace(" (", "(").Replace(" )", ")").Replace(" :", ":");
            toRet = toRet.Replace(" ?", "?").Replace(" !", "!").Replace(" .", ".").Replace(" ,", ",").Replace(" (", "(").Replace(" )", ")").Replace(" :", ":");            // Could probably be optimized
            if (split)
            {
                File.WriteAllText("out.see", toRet);
            }
            return toRet.Replace("  ", " ").Replace("  ", " ");
        }
        private string ReplaceCaseInsensitive(string Text, string Find, string Replace)
        {
            List<char> NewText = Text.ToCharArray().ToList();
            int ReplaceLength = Replace.Length;
            int LastIndex = -1;
            while (true)
            {
                LastIndex = Text.IndexOf(Find, LastIndex + 1, StringComparison.OrdinalIgnoreCase);

                // Done?
                if (LastIndex == -1)
                {
                    // Yes.
                    break;
                }
                else
                {
                    for (int i = 0; i < ReplaceLength; i++)
                    {
                        if ((i + LastIndex) > Text.Length - 1)
                        {
                            NewText.Add(' ');
                            Text += " ";
                        }
                        if (char.IsUpper(Text[i + LastIndex]))
                        {
                            NewText[i + LastIndex] = char.ToUpper(Replace[i]);
                        }
                        else if (IsAllUpper(Text))
                        {
                            NewText[i + LastIndex] = char.ToUpper(Replace[i]);
                        }
                        else
                        {
                            NewText[i + LastIndex] = char.ToLower(Replace[i]);
                        }
                    }
                }
            }
            string toRet = new string(NewText.ToArray());
            return toRet;
        }
        // Checks if a string contains only uppercase chars
        public static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) && !char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }
    }
}
