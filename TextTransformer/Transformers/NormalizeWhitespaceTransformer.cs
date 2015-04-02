using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class NormalizeWhitespaceTransformer : ITransformer
    {
        public string Name
        {
            get { return "NormalizeWhitespace"; }
        }

        public string Transform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return (new Regex("[\\s]{1,}")).Replace(input.Trim().Replace("/n", " ").Replace("/r", " ").Replace("/t", " "), " ");
        }
    }
}