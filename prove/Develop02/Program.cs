using Develop02;
using System;

class Program
{
    static void Main(string[] args)
    {
        // initial variable
        string choose;
        string filename;
        Journal currentJornal = new Journal();
        FileManeger fileManager = new FileManeger();
        PromptGenerator promptGenerator = new PromptGenerator();

        // start the flow
        Console.WriteLine("Welcome to Journal Program");
        do
        {
            Console.WriteLine("Choose one of option bellow:");
            Console.WriteLine("1 - Write");
            Console.WriteLine("2 - Read");
            Console.WriteLine("3 - Open File");
            Console.WriteLine("4 - Save File");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Which option would like to do:");
            choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    writeJournal();
                    break;
                case "2":
                    displayJournal();
                    break;
                case "3":
                    readFile();
                    break;
                case "4":
                    saveFile();
                    break;
            }

        } while (choose != "5");

        void displayJournal()
        {
            currentJornal.DisplayResponse();
        }

        void saveFile()
        {
            Console.Write("Prompt the filename:");
            filename = Console.ReadLine();
            fileManager.updateFilename(filename);
            fileManager.saveFile(currentJornal._responses);
        }

        void readFile()
        {
            Console.Write("Prompt the filename:");
            filename = Console.ReadLine();
            var data = fileManager.loadFile(filename);
            if (data is not null)
            {
                currentJornal.updateResponse(data);
            }
        }

        void writeJournal()
        {
            var entry = new Entry();
            var prompt = promptGenerator.DisplayRandomQuestionsPrompts();
            Console.WriteLine(prompt);
            entry._promptText = prompt;
            entry._entryText = Console.ReadLine();
            Console.WriteLine();
            currentJornal.AddResponse(entry);
        }

    }
}