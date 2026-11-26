using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class LowercaseTransformer : ITransformer
    {
        public string Name => "Lowercase";

        public Task<string> Transform(string input)
        {
            return Task.FromResult(input.ToLower());
        }
    }
}
