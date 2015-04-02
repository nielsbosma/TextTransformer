using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class CapitalizeTransformer : ITransformer
    {
        public string Name
        {
            get { return "Capitalize"; }
        }

        public string Transform(string input)
        {
            char[] ca = input.ToCharArray();
            for (int i = 0, n = ca.Length; i < n; ++i)
            {
                ca[i] = (i == 0 || ca[i - 1] == ' ' || ca[i - 1] == '/' || ca[i - 1] == '-') ? char.ToUpper(ca[i]) : char.ToLower(ca[i]);
            }
            return (new String(ca));
        }
    }
}