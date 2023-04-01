internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            GetMenuInstructions();
            var menuChoice = Convert.ToString(Console.ReadLine());
            switch (menuChoice)
            {
                case "1":
                    GetAmountOfWords();
                    break;
                case "2":
                    MathOperations();
                    break;
                case "esc":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Something went wrong.. Choose the right option from menu");
                    GetMenuInstructions();
                    break;
            }
        }
    }

    // Method outputs certain amount of words from text file "Lorem ipsum"
    private static void GetAmountOfWords()
    {
        Console.Write("How many words should be output?: ");
        var wordCount = Convert.ToInt32(Console.ReadLine());

        var pathFile = @"C:\UNIVERCITY\6 SEMESTER\ASP.net\Lab1\ConsoleApp1\ConsoleApp1\lorem.txt";
        var text = File.ReadAllText(pathFile);

        var outputString = text.Split(' ');
        for (var i = 0; i < wordCount; i++) {
            Console.Write(outputString[i] + " ");
        }
    }

    private static void GetMenuInstructions()
    {
        Console.WriteLine("\nMENU");
        Console.WriteLine("\n1 - get amount of words from text file 'Lorem Ipsum'");
        Console.WriteLine("2 - do math operation");
        Console.WriteLine("esc - stop program");
        Console.Write("Select menu option: ");
    }


    private static void GetMathInstructions()
    {
        Console.WriteLine("\nMATH");
        Console.WriteLine("\nadd - addition");
        Console.WriteLine("sub - subtraction");
        Console.WriteLine("mult - multiplication");
        Console.WriteLine("div - division");
        Console.Write("Select math operation: ");
    }


    // Method provides 4 basic mathematical operations - addition, subtraction, multiplication and division.
    private static void MathOperations()
    {
        GetMathInstructions();
        var operation = Convert.ToString(Console.ReadLine());

        Console.Write("Enter number #1: ");
        var firstNumber = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter number #2: ");
        var secondNumber = Convert.ToDouble(Console.ReadLine());

        double operationResult = 0;
        switch (operation)
        {
            case "add":
                operationResult = firstNumber + secondNumber;
                Console.WriteLine($"{firstNumber} + {secondNumber} = {operationResult}");
                break;
            case "sub":
                operationResult = firstNumber - secondNumber;
                Console.WriteLine($"{firstNumber} - {secondNumber} = {operationResult}");
                break;
            case "mult":
                operationResult = firstNumber * secondNumber;
                Console.WriteLine($"{firstNumber} * {secondNumber} = {operationResult}");
                break;
            case "div":
                Console.WriteLine($"{firstNumber} / {secondNumber} = {operationResult}");
                break;
            default:
                Console.WriteLine("Something went wrong.. Choose the right option from menu");
                MathOperations();
                break;
        }
    }
}