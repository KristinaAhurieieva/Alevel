public class Program
{
    public delegate int CalculationDelegate(int oneNumber, int twoNumber);
    public event CalculationDelegate CalculateEvent;

    public int MethodCalk(int oneNumber, int twoNumber)
    {
        int result = oneNumber + twoNumber;
        OnCalculateEvent(result);
        return result;
    }

    public void ProcessesCalculations()
    {
        CalculateEvent += (oneNumber, twoNumber) =>
        {
            Console.WriteLine($"Result: {oneNumber}");
            return oneNumber;
        };

        CalculateEvent += (oneNumber, twoNumber) =>
        {
            Console.WriteLine($"Handler: {oneNumber}");
            return oneNumber;
        };

        try
        {
            int resultSum = CalculateCatch(MethodCalk, 5, 3) +
                            CalculateCatch(MethodCalk, 10, 2);

            Console.WriteLine($"Sum result: {resultSum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static int CalculateCatch(CalculationDelegate method, int a, int b)
    {
        try
        {
            return method(a, b);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error method execution: {ex.Message}");
            return 0;
        }
    }

    protected virtual void OnCalculateEvent(int result)
    {
        CalculateEvent?.Invoke(result, 0);
    }

    static void Main()
    {
        Program calculator = new Program();
        calculator.ProcessesCalculations();
    }
}







public class Contact
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Number { get; set; }
}

class Program
{
    static void Main()
    {
        List<Contact> contacts = new List<Contact>();

        contacts.Add(new Contact { Name = "Anna", Age = 29, Number = 0501892927 });
        contacts.Add(new Contact { Name = "Kristina", Age = 26, Number = 0661892928 });
        contacts.Add(new Contact { Name = "Semen", Age = 27, Number = 0981892929 });
        contacts.Add(new Contact { Name = "Zhanna", Age = 45, Number = 0671892926 });


        Contact firstContact = contacts.FirstOrDefault()!;
        Console.WriteLine($"First contact: {firstContact?.Name}");

        var age = contacts
        .Where(contact => contact.Age >= 25);
        Console.WriteLine("Age:");
        foreach (var ages in age)
        {
            Console.WriteLine($"{ages.Name}, {ages.Age} years old");
        }

        var numberList = contacts
           .Select(contact => contact.Number)
           .Skip(2);

        Console.WriteLine("Number:");
        foreach (var number in numberList)
        {
            Console.WriteLine(number);
        }

        var sortedContacts = contacts.OrderBy(contact => contact.Name);
        Console.WriteLine("Sorted contacts:");
        foreach (var contact in sortedContacts)
        {
            Console.WriteLine($"{contact.Name}, {contact.Age} years old");
        }

        var reversedContacts = contacts.OrderByDescending(contact => contact.Name).ToList();
        Console.WriteLine("Reverse order of contacts:");
        foreach (var contact in reversedContacts)
        {
            Console.WriteLine($"{contact.Name} Name, {contact.Age} years old");
        }

        bool youngContacts = contacts.Any(contact => contact.Age < 25);
        Console.WriteLine($"Contact young: {youngContacts}");

    }
}



