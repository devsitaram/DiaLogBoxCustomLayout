// See https://aka.ms/new-console-template for more information
using System;
class Calculator
{
    public static void Main(string[] args)
    {
        bool continueCalculating = true;

        while (continueCalculating)
        {
            Console.WriteLine("Enter the first number: ");
            int num1;
            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            }

            Console.WriteLine("\nEnter the second number:");
            int num2;
            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            }

            Console.WriteLine("\nWhat operation do you want to perform? (+, -, *, /)");
            string operation = Console.ReadLine();

            int result = 0;

            switch (operation)
            {
                case "+":
                    result = sum(num1, num2);
                    break;
                case "-":
                    result = subtract(num1, num2);
                    break;
                case "*":
                    result = multiplication(num1, num2);
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = division(num1, num2);
                    }
                    else
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation.\n");
                    // goto case 1..;
                    break;
            }

            Console.WriteLine("\nResult: " + result);

            Console.WriteLine("\nDo you want to perform another calculation? (yes/no)");
            string continueInput = Console.ReadLine().ToLower();
            if (continueInput != "yes")
            {
                continueCalculating = false;
            }
            Console.WriteLine("\n");
        }
        Console.WriteLine("Thank You!");
    }

    private static int sum(int num1, int num2)
    {
        return num1 + num2;
    }

    private static int subtract(int num1, int num2)
    {
        return num1 - num2;
    }

    private static int division(int num1, int num2)
    {
        return num1 / num2;
    }

    private static int multiplication(int num1, int num2)
    {
        return num1 * num2;
    }
}