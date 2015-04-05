using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TextTransformer.Transformers.Parameters
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class AbstractParameterAttribute : Attribute
    {

        protected AbstractParameterAttribute(string header)
        {
            this.Header = header;
        }

        public string Header { get; set; }

        public abstract Control GetControl();

    }
}
