using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace TextTransformer.Transformers
{
    public class Md5Transformer : ITransformer
    {
        public string Name
        {
            get { return "Md5"; }
        }

        public string Transform(string input)
        {
            byte[] encodedInput = new UTF8Encoding().GetBytes(input);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedInput);
            string encoded = BitConverter.ToString(hash)
                .Replace("-", string.Empty)
                .ToLower();
            return encoded;
        }
    }
}
