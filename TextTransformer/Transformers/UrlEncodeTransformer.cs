using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TextTransformer.Transformers
{
    public class UrlEncodeTransformer : ITransformer
    {
        public string Name
        {
            get { return "UrlEncode"; }
        }

        public Task<string> Transform(string input)
        {
            return Task.FromResult(HttpUtility.UrlEncode(input));
        }
    }
}
