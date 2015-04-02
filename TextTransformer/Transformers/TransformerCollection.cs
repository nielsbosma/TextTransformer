using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextTransformer.Transformers
{
    public class TransformerCollection : List<ITransformer>
    {

        public static TransformerCollection Load()
        {
            var result = new TransformerCollection();

            var type = typeof(ITransformer);

            var instances = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t.GetInterfaces().Contains(type) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(t => Activator.CreateInstance(t) as ITransformer);

            result.AddRange(instances.OrderBy(e => e.Name));

            return result;
        }

    }
}
