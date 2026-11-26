using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace TextTransformer.Transformers
{
    public class CalculateTransformer : ITransformer
    {
        public string Name => "Calculate";

        public Task<string> Transform(string input)
        {
            var expr = new Expression(input);
            return Task.FromResult(expr.Evaluate().ToString());
        }
    }
}
