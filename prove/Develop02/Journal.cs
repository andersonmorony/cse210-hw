
namespace Develop02
{
    public class Journal
    {
        public DateTime _currentDate = DateTime.Now;
        public List<string> _responses = new List<string>();

        public void AddResponse(Entry entry)
        {
            string currentDateFormated = entry._currentDate.ToString("MM/dd/yyyy");
            _responses.Add($"Date: {currentDateFormated} - Prompt: {entry._promptText} \n Response: {entry._entryText} ");
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
