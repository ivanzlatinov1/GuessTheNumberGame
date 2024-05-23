Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Guess the number (1 - 100): ");
Console.ResetColor();
var command = Console.ReadLine();

while (command != "yes")
{
   //Checking for invalid input

    int playerNumber;
    bool isValidNumber = int.TryParse(command, out playerNumber);

    while (!isValidNumber)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input!");
        Console.ResetColor();
        command = Console.ReadLine();
        isValidNumber = int.TryParse(command, out playerNumber);
    }

    //Creating logic for player's number choice

    playerNumber = int.Parse(command);

    if (playerNumber is < 1 or > 100)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid guess!");
        Console.WriteLine("Choose a number between 1 and 100");
        Console.ResetColor();
        command = Console.ReadLine();
        continue;
    }

    //Creating logic for the computer's number choice

    Random randomNumber = new();
    var computerNumber = randomNumber.Next(1, 101);

    //Creating logic for guessing the number

    while (playerNumber != computerNumber)
    {
        isValidNumber = int.TryParse(command, out playerNumber);
        while (!isValidNumber)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input!");
            Console.ResetColor();
            command = Console.ReadLine();
            isValidNumber = int.TryParse(command, out playerNumber);
        }
        playerNumber = int.Parse(command);
        if (playerNumber is < 1 or > 100)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choose a number between 1 and 100!");
            Console.ResetColor();
            command = Console.ReadLine();
            continue;
        }
        if (playerNumber < computerNumber - 30)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Too far! Go higher!");
            Console.ResetColor();
        }
        else if (playerNumber < computerNumber)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Higher!");
            Console.ResetColor();
        }
        else if (playerNumber > computerNumber + 30)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Too far! Go lower!");
            Console.ResetColor();
        }
        else if (playerNumber > computerNumber)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Lower!");
            Console.ResetColor();
        }
        else if (playerNumber == computerNumber)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You guessed the number!");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Play again? (yes/no)");
            Console.ResetColor();
            string? decision = Console.ReadLine();
            if (decision == "yes")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Guess another number:");
                Console.ResetColor();
                command = Console.ReadLine();
                break;
            }
            if (decision == "no")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Thank you for playing!");
                Console.ResetColor();
                return;
            }
            while (decision != "yes" || decision != "no")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ResetColor();
                decision = Console.ReadLine();
            }
        }
        command = Console.ReadLine();
    }
}