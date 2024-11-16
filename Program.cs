class Program
{
    static void Main(string[] args)
    {
        // Greet the user and explain the purpose of the program
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine(
            $"Hello, {name}! This program is made for the Trimestral Activity 1 of 'Fundamentos de Programación'. Let's perform basic calculations with two numbers."
        );

        bool continueCalculations = true; // Control if calculations should continue

        // Main loop to perform calculations
        while (continueCalculations)
        {
            double number1 = GetValidNumber("Enter the first number (>= 0):");
            double number2 = GetValidNumber("Enter the second number (>= 0):");

            // Loop to perform calculations with the same numbers
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1. Sum (+)");
                Console.WriteLine("2. Subtract (-)");
                Console.WriteLine("3. Multiply (*)");
                Console.WriteLine("4. Divide (/)");
                Console.WriteLine("Type 'exit' to stop the program.");
                Console.WriteLine("==============");

                string operation = GetValidOperation(
                    "Choose an operation (+, -, *, /) or type 'exit' to leave:"
                );

                // Check if the user wants to exit
                if (operation.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    continueCalculations = false; // User decides to exit
                    break;
                }

                // Perform the calculation and display the result
                switch (operation)
                {
                    case "+":
                        Console.WriteLine($"{number1} + {number2} = {number1 + number2}");
                        break;
                    case "-":
                        Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
                        break;
                    case "*":
                        Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
                        break;
                    case "/":
                        while (number2 == 0)
                        {
                            Console.WriteLine("Division by zero is not allowed.");
                            number2 = GetValidNumber("Enter a new second number (must be >= 0):");
                        }
                        Console.WriteLine($"{number1} / {number2} = {number1 / number2}");
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }

                // Ask if the user wants to perform another calculation
                Console.WriteLine(
                    "\nDo you want to perform another calculation? Type 'yes' to continue or 'no' to exit."
                );
                string response = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

                if (response == "no")
                {
                    continueCalculations = false; // Exit the main loop
                    break;
                }
                else if (response == "yes")
                {
                    // Continue with new numbers
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Continuing with new numbers...");
                    break;
                }
            }
        }
        // Exit message
        Console.WriteLine($"Goodbye, {name}! See you soon.");
    }

    // Helper method to get valid input from the user
    private static double GetValidNumber(string message)
    {
        // Loop until the user enters a valid number
        while (true)
        {
            // Ask the user for a number
            Console.WriteLine(message);
            // Read the input and check if it is a valid number
            string input = Console.ReadLine() ?? string.Empty;
            // Check if the input is a valid number
            if (double.TryParse(input, out double number) && number >= 0)
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a non-negative number.");
            }
        }
    }

    // Helper method to get a valid operation from the user
    private static string GetValidOperation(string message)
    {
        // Loop until the user enters a valid operation
        while (true)
        {
            // Ask the user for an operation
            Console.WriteLine(message);
            // Read the input and check if it is a valid operation
            string input = Console.ReadLine() ?? string.Empty;
            if (
                input == "+"
                || input == "-"
                || input == "*"
                || input == "/"
                || input.Equals("exit", StringComparison.OrdinalIgnoreCase)
            )
            {
                return input;
            }
            else
            {
                Console.WriteLine(
                    "Invalid input. Enter a valid operation (+, -, *, /) or type 'exit' to leave."
                );
            }
        }
    }
}
