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
        public string Name
        {
            get { return "UrlDecode"; }
        }

        public string Transform(string input)
        {
            return HttpUtility.UrlDecode(input);
        }
    }
}
