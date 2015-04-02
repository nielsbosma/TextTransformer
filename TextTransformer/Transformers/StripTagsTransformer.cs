using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class StripTagsTransformer : ITransformer
    {
        public string Name
        {
            get { return "StripTags"; }
        }

        public string Transform(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            return Regex.Replace(input, @"(<[^ ])(.|\n)*?>", string.Empty);  
        }
    }
}