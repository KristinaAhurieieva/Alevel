public class ValueDelegate
{
    public delegate bool BoolResult(int result);

    public int Multiply(int oneNumber, int twoNumber)
    {
        return oneNumber * twoNumber;
    }
}

public class ValueCalculation
{
    private int savingResult;

    public ValueDelegate.BoolResult Calc(ValueDelegate.BoolResult multiplyDelegate, int oneNumber, int twoNumber)
    {
        ValueDelegate valueDelegate = new ValueDelegate();
        int result = valueDelegate.Multiply(oneNumber, twoNumber);
        savingResult = result;

        return (parametr) => Result(parametr);
    }

    public bool Result(int number)
    {
        int remainder = savingResult % number;
        return remainder == 0;
    }
}

public class Program
{
    public static void Show(bool result)
    {
        Console.WriteLine($"Result: {result}");
    }

    static void Main(string[] args)
    {
        ValueDelegate valueDelegate = new ValueDelegate();
        ValueCalculation valueCalculation = new ValueCalculation();

        ValueDelegate.BoolResult multiplyDelegate = valueCalculation.Calc(null, 3, 4);

        Show(multiplyDelegate.Invoke(2));
    }
}

