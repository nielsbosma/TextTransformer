using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public interface ITransformer
    {

        string Name { get; }

        Task<string> Transform(string input);

    }
}
