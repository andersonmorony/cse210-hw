
namespace Develop02
{
    public class Entry
    {
        public DateTime _currentDate = DateTime.Now;
        public string _promptText;
        public string _entryText;

        public void Display()
        {
            string currentDateFormated = _currentDate.ToString("MM/dd/yyyy");
            Console.WriteLine($"Date: {currentDateFormated} - Prompt: {_promptText}");
            Console.WriteLine(_entryText);
        }
    }
}
