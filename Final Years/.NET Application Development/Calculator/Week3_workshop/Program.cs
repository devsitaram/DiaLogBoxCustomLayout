// See https://aka.ms/new-console-template for more information
using Week3_workshop;

internal class Program
{
    private static void Main(string[] args)
    {
        Class2 class2 = new Class2();
        string userRespone;
        int index = 0;
        do
        {   
            Console.WriteLine("Enter the your name:");
            string name = Console.ReadLine() ?? "Manjil";

            class2.AddValue(name, index++);

            Console.WriteLine("Do you want to add. Y/N");
            userRespone = Console.ReadLine().ToLower();
        } while (userRespone == "y");
        class2.PrintValue();

        DemoClass demoClass = new DemoClass();
        var newName = demoClass.FullName = "New Name";
        Console.WriteLine(demoClass.CollegeName);

        demoClass.NonReturnMethod();
        var NethodReturn = demoClass.ReturnableMethod();

        demoClass.ParemMethod("New Name");
        demoClass.OutParameterMethod("First Name", "Last Name", out string updateName);
        Console.WriteLine(updateName);

        demoClass.OptionalParameterMethod(collegeName: "Isllington College");

        try
        {

        } catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}