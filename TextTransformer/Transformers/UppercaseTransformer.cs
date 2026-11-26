using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class UppercaseTransformer : ITransformer
    {
        public string Name => "Uppercase";

        public Task<string> Transform(string input)
        {
            return Task.FromResult(input.ToUpper());
        }
    }
}