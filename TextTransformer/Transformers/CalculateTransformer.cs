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
        public string Name
        {
            get { return "Calculate"; }
        }

        public string Transform(string input)
        {
            var expr = new Expression(input);
            return expr.Evaluate().ToString();
        }
    }
}
