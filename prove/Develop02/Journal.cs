
namespace Develop02
{
    public class Journal
    {
        public DateTime _currentDate = DateTime.Now;
        public List<Entry> _responses = new List<Entry>();

        public void AddResponse(Entry entry)
        {
            _responses.Add(entry);
        }

        public void DisplayResponse()
        {
            foreach (var item in _responses)
            {
                Console.WriteLine();
                item.Display();
                Console.WriteLine();
            }
        }

        public void updateResponse(List<Entry> data)
        {
            _responses = data;
        }
    }
}
