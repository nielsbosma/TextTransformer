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
        public string Name
        {
            get { return "Guid"; }
        }

        public string Transform(string input)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
