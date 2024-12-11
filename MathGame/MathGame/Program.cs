using System.Collections;
using System.Diagnostics;

Console.WriteLine("Welcome to Math Game!");

string[] operations = { "+", "-", "*", "/" };
string chosenOperation = "";
bool validInput = false;
bool exitGame = false;
var chosenMenuOption = MenuOptions.MainMenu;
ArrayList gameHistory = new ArrayList();

while (!exitGame)
{
    Console.WriteLine($"Menu options: \n 1. {MenuOptions.Play} \n 2. {MenuOptions.History} \n 3. {MenuOptions.Exit} ");
    var input = Console.ReadLine();
    if (int.TryParse(input, out int selectedOptionInt) && Enum.IsDefined(typeof(MenuOptions), selectedOptionInt))
    {
        chosenMenuOption = (MenuOptions)selectedOptionInt;
        Console.WriteLine($"You chose: {chosenMenuOption}");
    }

    if (chosenMenuOption == MenuOptions.Exit)
    {
        exitGame = true;
        Console.WriteLine("Exiting game");
        break;
    }
   
    if (chosenMenuOption == MenuOptions.History)
    {
        Console.Clear();
        if (gameHistory.Capacity == 0)
        {
            Console.WriteLine("History is empty.");
        } else
        {
            Console.WriteLine($"Game history:");
            foreach (var game in gameHistory)
            {
                var index = gameHistory.IndexOf(game);
                Console.WriteLine($"[{index}] {game}");
            }
            
        }
        continue;
    }
    var time = new Stopwatch();
    if (chosenMenuOption == MenuOptions.Play)
    {
        while (!operations.Contains(chosenOperation))
        {
            Console.WriteLine("Choose operation: +, - , * , /");
            chosenOperation = Console.ReadLine();
            if (operations.Contains(chosenOperation))
            {
                Console.WriteLine("You chose: " + chosenOperation);
                
                validInput = true;
            }
            else
            {
                Console.Clear();
            }
        }

        Random rnd = new Random();
        time.Start();

        for (var i = 0; i <= 5; i++)
        {
            Console.Clear();
            Console.WriteLine($"Round {i} out of 5");
            int random1 = rnd.Next(0, 11);
            int random2 = rnd.Next(1, 11);

            while(random1 > random2 && chosenOperation == "/")
            {
                random1 = rnd.Next(0, 11);
            }

            while (random1 % 2 != 0 && chosenOperation == "/")
            {
                random1 = rnd.Next(0, 11);
            }

            Console.WriteLine($"{random1} {chosenOperation} {random2}");
            var userInputAnswer = int.TryParse(Console.ReadLine(), out int userAnswer);
            int actualAnswer = 0;

            switch(chosenOperation)
            {
                case "+":
                    actualAnswer = random1 + random2;
                    break;
                case "-":
                    actualAnswer = random1 - random2;
                    break;
                case "*":
                    actualAnswer = random1 * random2;
                    break;
                case "/" :
                    actualAnswer = random1 / random2;
                    break;
            }
            Console.WriteLine($"Your answer: {userInputAnswer}, Actual answer: {actualAnswer}");
            Console.ReadLine();
            Console.Clear();
        }
    }
    time.Stop();
    TimeSpan ts = time.Elapsed;
    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
    Console.WriteLine($"Time spent playing: {elapsedTime} \n Would you like to play again? (y/n)");
    if(Console.ReadLine() == "y")
    {
        Console.WriteLine(Console.ReadLine
            ());
        chosenMenuOption = MenuOptions.Play;
        if (Console.ReadLine() == "y")
        {
            chosenMenuOption = MenuOptions.MainMenu;
            chosenMenuOption = MenuOptions.Play;

        }
    }
    

}

public enum MenuOptions
{
    MainMenu = 0,
    Play = 1,
    History = 2,
    Exit = 3
}

public enum Difficulty
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

public enum Operations 
{
    Addition,
    Subtraction,
    Multiplication,
    Division,
}