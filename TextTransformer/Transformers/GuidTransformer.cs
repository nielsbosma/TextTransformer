using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace TextTransformer.Transformers
{
    public class GuidTransformer : ITransformer
    {
        public string Name => "Guid";

        public Task<string> Transform(string input)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}
