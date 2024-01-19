
namespace Develop02
{
    public class Journal
    {
        public List<string> _responses = new List<string>();

        public void AddResponse(string prompt, string response)
        {
            DateTime currentDate = DateTime.Now;
            string currentDateFormated = currentDate.ToString("MM/dd/yyyy");
            _responses.Add($"Date: {currentDateFormated} - Prompt: {prompt} \n Response: {response} ");
        }

        public void DisplayResponse()
        {
            foreach (var item in _responses)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

        public void updateResponse(List<string> data)
        {
            _responses = data;
        }
    }
}
