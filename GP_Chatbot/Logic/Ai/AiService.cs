
using System.Text;

namespace GP_Chatbot.Logic.Ai
{
    public class AiService : IAiService
    {
        private const string LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private readonly Random _random;
        public AiService()
        {
            _random = new Random();
        }
        public Task<string> GenerateResponseFromPrompt(string prompt)
        {
            var words = _random.Next(5, 150);
            var lorem = LoremIpsum.Split(" ");
            var result = new StringBuilder();
            var wordIndex = 0;
            for (var i = 0; i < words; i++)
            {
                if (wordIndex >= lorem.Count())
                {
                    wordIndex = 0;
                }
                result.Append(lorem[wordIndex++] + " ");
            }
            return Task.FromResult(result.ToString());
        }
    }
}
