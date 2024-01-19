namespace Develop02
{
    public class FileManeger
    {

        private string _filename;

        public void updateFilename(string filename)
        {
            _filename = filename;
        }
        public void saveFile(List<string> responses)
        {
            using (StreamWriter outputFile = new StreamWriter(_filename))
            {
                // You can add text to the file with the WriteLine method
                foreach (var item in responses)
                {
                    outputFile.WriteLine(item);
                    outputFile.WriteLine();
                }
            }
        }

        public List<string> loadFile(string filename)
        {
            try
            {
                var data = new List<string>();
                string[] lines = File.ReadAllLines(filename);
                foreach (var line in lines)
                {
                    data.Add(line);
                }

                return data;

            }
            catch (Exception)
            {
                Console.WriteLine($"Ops, {filename} can't be found or not exit, please try again.");
                return null;
            }
        }
    }
}
