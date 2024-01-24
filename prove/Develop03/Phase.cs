
namespace Develop03
{
    public class Phase
    {
        private string _text;
        private int _counter;
        private List<string> _wordsRemoved = new List<string>();

        public Phase(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
        public void SetText(string text)
        {
            _text = text;
        }
        public int GetCounter()
        {
            return _counter;
        }
        public List<string> GetWordsHiden()
        {
            return _wordsRemoved;
        }

        public string HideWords()
        {

            if(_counter == 0)
            {
                _counter++;
                return _text;
            }

            string returnText = "";

            var words = _text.Split(' ')
                .ToList();

            var wordsNotFounded = _text
                .Split(' ')
                .Where(x => !x.Contains('_'))
                .Where(x => x is not "")
                .ToList();

            if(wordsNotFounded.Any())
            {
                Random random = new Random();
                var rdm = random.Next(wordsNotFounded.Count);
                var rdm2 = random.Next(wordsNotFounded.Count);


                var firstRandomWord = wordsNotFounded[rdm];
                _wordsRemoved.Add(firstRandomWord);
                var secondRandomWord = wordsNotFounded[rdm2];
                _wordsRemoved.Add(secondRandomWord);



                foreach ( var word in words )
                {
               
                    returnText += ChangeTextToUnder(word, firstRandomWord, secondRandomWord);
                }
                SetText(returnText);
            }
            
            _counter++;
            return wordsNotFounded.Any() ? returnText : _text;
        }

        private string ChangeTextToUnder(string word, string firstRandomWord, string secondRandomWord)
        {
            string newWord;

            if (word == firstRandomWord)
            {
                newWord = LoopToChangeWord(word);
            }
            else if (word == secondRandomWord)
            {
                newWord = LoopToChangeWord(word);
            }
            else
            {
                newWord = word + " ";
            }
            return newWord;
        }

        string LoopToChangeWord(string word)
        {
            var newWord = "";
            for (int i = 0; i < word.Length; i++)
            {
                newWord += "_";
            }
            newWord += " ";
            return newWord;
        }
    }
}
