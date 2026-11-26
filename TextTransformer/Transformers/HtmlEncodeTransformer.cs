using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TextTransformer.Transformers
{
    public class HtmlEncodeTransformer : ITransformer
    {
        public string Name => "HtmlEncode";

        public Task<string> Transform(string input)
        {
            return Task.FromResult(HttpUtility.HtmlEncode(input));
        }
    }
}
