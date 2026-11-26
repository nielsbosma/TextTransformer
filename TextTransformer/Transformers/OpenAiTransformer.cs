using System.Threading.Tasks;
using TextTransformer.Services;

namespace TextTransformer.Transformers
{
    public class OpenAiTransformer : ITransformer
    {
        private readonly string _instruction;

        public OpenAiTransformer(string name, string instruction)
        {
            Name = name;
            _instruction = instruction;
        }

        public string Name { get; }
        
        public async Task<string> Transform(string input)
        {
            var service = new OpenAiService();
            return await service.GetEdit(input, _instruction);
        }
    }
}