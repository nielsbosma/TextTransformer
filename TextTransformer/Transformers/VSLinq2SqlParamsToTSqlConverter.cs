using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NCalc;

namespace TextTransformer.Transformers
{
    public class VSLinq2SqlParamsToTSqlConverter : ITransformer
    {
        public string Name
        {
            get { return "VSLinq2SqlParamsToTSql"; }
        }

        
        public string Transform(string input)
        {
            string[] lines = input.Split('\n').Select(e => e.Trim()).Where(e => !string.IsNullOrEmpty(e)).ToArray();

            var builder = new StringBuilder();

            foreach (string line in lines)
            {
                var regex = new Regex(@"^-- (@p\d+): Input (\w+)[^/[]*\[(.*)]");
                var match = regex.Match(line);

                if (match.Success)
                {
                    string type = match.Groups[2].Value;
                    if (type.Equals("NText"))
                    {
                        type = "NVarChar";
                    }

                    builder.AppendLine(string.Format("DECLARE {0} {1}; SET {0} = {2};", match.Groups[1].Value, type,
                        FormatValue(match.Groups[3].Value, type)));
                }
            }

            return builder.ToString();
        }

        private readonly string[] _textTypes = { "NText", "NVarChar", "VarChar", "UniqueIdentifier", "DateTime" };

        private string FormatValue(string value, string type)
        {
            return _textTypes.Contains(type) ? "'" + value + "'" : value;
        }

    }
}
