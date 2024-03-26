// See https://aka.ms/new-console-template for more information

Boolean calculate = true;

while (calculate)
{
    int num1;
    while (true)
    {
        try
        {
            Console.WriteLine("Enter the first numner: ");
            num1 = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    //while (!int.Parse(Console.ReadLine()))
    //{

    //}

    int num2;
    while (true)
    {
        try
        {
            Console.WriteLine("Enter the second numner: ");
            num2 = int.Parse(Console.ReadLine());
            break;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    int @result = 0;
    bool validOperatior = true;
    do
    {
        Console.WriteLine("Enter operator: +, -, *, /, >, <");
        string @operator = Console.ReadLine();

        switch (@operator)
        {
            case "+":
                result = num1 + num2;
                validOperatior = false;
                break;

            case "-":
                result = num1 - num2;
                validOperatior = false;
                break;

            case "*":
                result = num1 * num2;
                validOperatior = false;
                break;

            case "/":
                result = num1 / num2;
                validOperatior = false;
                break;

            case ">":
                var isGratter = (num1 > num2) ? "Grater" : "Not Grater";
                Console.WriteLine($"The First number is {isGratter} then seecond number.");
                validOperatior = false;
                break;

            case "<":
                var isLess = (num1 > num2) ? "Lesss" : "Not Less";
                Console.WriteLine($"The First number is {isLess} then seecond number.");
                validOperatior = false;
                break;

            default:
                Console.WriteLine("Invalid operator!");
                validOperatior = true;
                break;

        }
    } while (validOperatior);

    Console.WriteLine("Result is: " + @result);


    Console.WriteLine("Do yo want to calculate again: (y or n)");
    string ask = Console.ReadLine().ToLower();
    if (ask == "n")
    {
        calculate = false;
        Console.WriteLine("Thank You!");
    }
}
