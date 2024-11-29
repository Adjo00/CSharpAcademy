Console.WriteLine("Welcome to Math Game!");

string[] operations = { "+", "-", "*", "/" };
string chosenOperation = "";
bool validInput = false;
bool exitGame = false;
var chosenMenuOption;



while (!exitGame)
{
    Console.WriteLine($"Menu options: \n 1. {MenuOptions.Play} \n 2. {MenuOptions.History} \n 3. {MenuOptions.Exit} ");
    while (!validInput && chosenMenuOption == MenuOptions.Play)
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


        Console.WriteLine("Input a number: ");
        var inputNr = Console.ReadLine();

        if (int.TryParse(inputNr, out int j))
        {
            Console.WriteLine($"You entered: {j}, Type: {j.GetType()}");
            validInput = true;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
            validInput = false;
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