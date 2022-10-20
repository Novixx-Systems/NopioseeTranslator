namespace Nopioseev2
{
    /// <summary>
    /// Simple parse functions
    /// </summary>
    internal class BuildNopiosee
    {
        public List<string> ParseEnglish(string toParse /* The argument for parsing */)
        {
            if ( toParse != null)
            {
                toParse = toParse.Replace("t's", "t is");
                toParse = toParse.Replace("n't", " not");
                toParse = toParse.Replace("'t", " not");
                toParse = toParse.Replace("'m", " am");
                toParse = toParse.Replace("'re", " are");
                string[] split = SplitAndKeep(toParse, new Char[] { ' ' }).ToArray();
                return split.ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        // https://stackoverflow.com/questions/4680128/
        public static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
        //public List<string> ParseDots(string toParse /* The argument for parsing */)
        //{
        //    if (toParse != null)
        //    {
        //        string[] split = toParse.Split(new Char[] { '.' },
        //                         StringSplitOptions.RemoveEmptyEntries);
        //        return split.ToList();
        //    }
        //    else
        //    {
        //        return new List<string>();
        //    }
        //}
    }
}
