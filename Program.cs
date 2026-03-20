Journal journal = new Journal();
PromptGenerator promptGen = new PromptGenerator();

while (true)
{
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Save");
    Console.WriteLine("4. Load");
    Console.WriteLine("5. Exit");

    Console.Write("Choose: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.Write("> ");
        string response = Console.ReadLine();

        Entry entry = new Entry();
        entry._date = DateTime.Now.ToShortDateString();
        entry._promptText = prompt;
        entry._entryText = response;

        journal.AddEntry(entry);
    }
    else if (choice == "2")
    {
        journal.DisplayAll();
    }
    else if (choice == "3")
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in journal._entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }
    else if (choice == "4")
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        string[] lines = File.ReadAllLines(filename);
        journal._entries.Clear();

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];

            journal.AddEntry(entry);
        }
    }
    else if (choice == "5")
    {
        break;
    }
}