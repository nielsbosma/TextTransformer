using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class LowercaseTransformer : ITransformer
    {
        public string Name
        {
            get { return "Lowercase"; }
        }

        public string Transform(string input)
        {
            return input.ToLower();
        }
    }
}
