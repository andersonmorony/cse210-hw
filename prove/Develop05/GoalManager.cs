
namespace Develop05
{
    public class GoalManager
    {
        private List<Goal> _listOfGoals = new();
        private double _score;
        private bool _saved = true;

        public GoalManager()
        {
        }

        public void Start()
        {
            string choose = string.Empty;
            Console.WriteLine("Welcome to the Gamification Goals");
            while (choose != "0")
            {
                DisplayPlayInfo();
                Console.WriteLine("\nMenu Option:");
                Console.WriteLine("1 - Create Goal");
                Console.WriteLine("2 - List Goals");
                Console.WriteLine("3 - Save Goals");
                Console.WriteLine("4 - Read Goals");
                Console.WriteLine("5 - Record Goals");
                Console.WriteLine("0 - Exit");
                Console.Write("Select one choice from the menu:");
                choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        CreateGoals();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        ReadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "0":
                        if (!_saved)
                        {
                            SaveGame();
                        }
                        break;
                }
            }
        }
        private void DisplayPlayInfo()
        {

            Console.WriteLine($"\nYour Score: {_score} points");
            if(!_saved)
            {
                Console.WriteLine("Game didn't save, don't forgot to save you progress T_T");
            }
        }
        private void CreateGoals()
        {
            Console.Clear();
            Console.WriteLine("\nMenu Option:");
            Console.WriteLine("1 - Simple Goal");
            Console.WriteLine("2 - Eternal Goal");
            Console.WriteLine("3 - Checklist Goal");
            Console.WriteLine("0 - Exit");
            Console.Write("Which type of goal would you like to create? ");
            string choose = Console.ReadLine();
            string name, description;
            int times;
            double score, bonus;
            switch (choose)
            {
                case "1":
                    Console.Write("\nWhat is the name of your goal? ");
                    name = Console.ReadLine();
                    Console.Write("\nWhat is a short description of it? ");
                    description = Console.ReadLine();
                    Console.Write("\nWhat is the amount of points associated with this goal? ");
                    score = double.Parse(Console.ReadLine());
                    _listOfGoals.Add(new SimpleGoal(name, description, score));
                    break;
                case "2":
                    Console.Write("\nWhat is the name of your goal? ");
                    name = Console.ReadLine();
                    Console.Write("\nWhat is a short description of it? ");
                    description = Console.ReadLine();
                    Console.Write("\nWhat is the amount of points associated with this goal? ");
                    score = double.Parse(Console.ReadLine());
                    _listOfGoals.Add(new EternalGoal(name, description, score));
                    break;
                case "3":
                    Console.Write("\nWhat is the name of your goal? ");
                    name = Console.ReadLine();
                    Console.Write("\nWhat is a short description of it? ");
                    description = Console.ReadLine();
                    Console.Write("\nWhat is the amount of points associated with this goal? ");
                    score = double.Parse(Console.ReadLine());
                    Console.Write("\nHow many times does this goal need to be accomplished for a bonus? ");
                    times = int.Parse(Console.ReadLine());
                    Console.Write("\nWhat is the bonus for accomplishing it that many times? ");
                    bonus = double.Parse(Console.ReadLine());
                    _listOfGoals.Add(new ChecklistGoal(name, description, score, times, bonus));
                    break;
            }
            _saved = false;
        }
        private void ListGoals()
        {
            Console.Clear();
            foreach (var goal in _listOfGoals)
            {
                goal.DisplayGoal();
                Console.WriteLine();
            }
        }
        private void SaveGoals()
        {
            Console.Write("Prompt the file name: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (var item in _listOfGoals)
                {
                    outputFile.WriteLine(item.WriteInFile());
                }
            }
            _saved = true;
        }
        private void ReadGoals()
        {
            try
            {
                Console.Clear();
                Console.Write("Prompt the filename to be reading: ");
                string filename = Console.ReadLine();

                string[] lines = File.ReadAllLines(filename);
                _score = int.Parse(lines[0]);

                int len = lines.Length;
                for (int i = 1; i < len; i++)
                {
                    string[] parts = lines[i].Split(",");
                    if (parts[0] == "ChecklistGoal")
                    {
                        string title = parts[1];
                        string description = parts[2];
                        double score = double.Parse(parts[3]);
                        DateTime dateTime = DateTime.Parse(parts[4]);
                        bool isComplete = bool.Parse(parts[5]);
                        double bonus = double.Parse(parts[6]);
                        int time = int.Parse(parts[7]);
                        int timeCompleted = int.Parse(parts[8]);

                        var item = new ChecklistGoal(title, description, score, dateTime, isComplete, bonus, time, timeCompleted);
                        _listOfGoals.Add(item);
                    }
                    else if (parts[0] == "SimpleGoal")
                    {
                        string title = parts[1];
                        string description = parts[2];
                        double score = double.Parse(parts[3]);
                        DateTime dateTime = DateTime.Parse(parts[4]);
                        bool isComplete = bool.Parse(parts[5]);
                        var item = new SimpleGoal(title, description, score, dateTime, isComplete);
                        _listOfGoals.Add(item);
                    }
                    else
                    {
                        string title = parts[1];
                        string description = parts[2];
                        double score = double.Parse(parts[3]);
                        DateTime dateTime = DateTime.Parse(parts[4]);
                        var item = new EternalGoal(title, description, score, dateTime);
                        _listOfGoals.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("File not found, please, try again and do certain that the file exist");
            }
        }
        private void RecordEvent()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose the Goal you did today:");
                int len = _listOfGoals.Count;
                for (int i = 0; i < len; i++)
                {
                    Console.Write($"{i + 1} - ");
                    _listOfGoals[i].DisplayGoal();
                }
                Console.Write("Which goal would you like to record? ");
                int respInput = int.Parse(Console.ReadLine());
                _score += _listOfGoals[respInput - 1].SetDone();
                _saved = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Goal not found, please try again");
            }
        }
        private void SaveGame()
        {
            Console.WriteLine("Before you go, would you like save the game? [Y] or [N]");
            string choose = Console.ReadLine();

            if(choose.ToLower() == "y")
            {
                SaveGoals();
                Console.WriteLine("\nGame Saved!\n");
            }
        }
    }
}
