using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nopioseev2
{
    static class StringExtensions
    {
        public static int IndexOf(this string self, Predicate<char> predicate)
        {
            for (int index = 0; index < self.Length; ++index)
            {
                if (predicate(self[index]))
                {
                    return index;
                }
            }
            return -1;
        }
    }
}
