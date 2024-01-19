namespace Develop02
{
    public class PromptGenerator
    {
        public PromptGenerator()
        {
            _optionsPrompt = new List<string>
            {
                "What was the most memorable or positive moment of your day? It could be a small achievement, a pleasant interaction, or a moment of joy.",
                "What was a significant challenge or obstacle you faced today?",
                "List three things you're grateful for today. Reflect on the positive aspects of these elements and how they contributed to your day.",
                "How did you prioritize self-care today? This could include activities that contribute to your well-being, such as exercise, relaxation, or spending time on hobbies",
                "What progress did you make towards your short-term or long-term goals today? Reflect on the steps you took and consider how they align with your overall objectives."
            };
        }
        public List<string> _optionsPrompt;

        public string DisplayRandomQuestionsPrompts()
        {
            string radomOption = _optionsPrompt.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            return radomOption;
        }
    }
}
