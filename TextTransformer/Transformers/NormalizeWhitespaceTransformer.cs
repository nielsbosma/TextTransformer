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
        public string Name => "NormalizeWhitespace";

        public Task<string> Transform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return Task.FromResult(input);
            }
            return Task.FromResult((new Regex("[\\s]{1,}")).Replace(input.Trim().Replace("/n", " ").Replace("/r", " ").Replace("/t", " "), " "));
        }
    }
}