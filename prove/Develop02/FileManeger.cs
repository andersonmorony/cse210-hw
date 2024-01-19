namespace Develop02
{
    public class FileManeger
    {

        private string _filename;

        public void updateFilename(string filename)
        {
            _filename = filename;
        }
        public void saveFile(List<Entry> responses)
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            {
                // You can add text to the file with the WriteLine method
                foreach (var item in responses)
                {
                    string currentDateFormated = item._currentDate.ToString("MM/dd/yyyy");
                    outputFile.WriteLine($"Date: {currentDateFormated} - Prompt: {item._promptText}");
                    outputFile.WriteLine(item._entryText);
                }
            }
        }

        public List<Entry> loadFile(string filename)
        {
            try
            {
                var data = new List<Entry>();
                var currentEntry =  new Entry();
                string[] lines = File.ReadAllLines(filename);

                for (int i = 0; i < lines.Length; i+=2)
                {
                    data.Add(new Entry { _promptText = lines[i], _entryText = lines[i + 1] });
                }

                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //Console.WriteLine($"Ops, {filename} can't be found or not exit, please try again.");
                return null;
            }
        }
    }
}
