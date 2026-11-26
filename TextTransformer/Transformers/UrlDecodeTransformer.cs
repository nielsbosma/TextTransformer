using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TextTransformer.Transformers
{
    public class UrlDecodeTransformer : ITransformer
    {
        public string Name => "UrlDecode";

        public Task<string> Transform(string input)
        {
            return Task.FromResult(HttpUtility.UrlDecode(input));
        }
    }
}
