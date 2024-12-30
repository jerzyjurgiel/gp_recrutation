namespace GP_Chatbot.Logic.Ai
{
    public interface IAiService
    {
        public Task<string> GenerateResponseFromPrompt(string prompt);
    }
}
