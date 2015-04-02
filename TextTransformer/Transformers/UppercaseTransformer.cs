using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class UppercaseTransformer : ITransformer
    {
        public string Name
        {
            get { return "Uppercase"; }
        }

        public string Transform(string input)
        {
            return input.ToUpper();
        }
    }
}