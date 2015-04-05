using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextTransformer.Transformers.Parameters;

namespace TextTransformer.Transformers
{
    public class ReplaceTransformer : ITransformer
    {

        public ReplaceTransformer()
        {
            ReplaceThis = "a";
            ReplaceWith = "b";
        }

        [TextParameter("Replace")]
        public string ReplaceThis { get; set; }

        [TextParameter("With")]
        public string ReplaceWith { get; set; }

        public string Name
        {
            get { return "Replace"; }
        }

        public string Transform(string input)
        {
            return input.Replace(ReplaceThis, ReplaceWith);
        }

    }
}
