using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TextTransformer.Transformers.Parameters
{
    public class TextParameterAttribute : AbstractParameterAttribute
    {

        public TextParameterAttribute(string header) : base(header)
        {
            
        }

        public override Control GetControl()
        {
            return new TextBox();
        }

    }
}
