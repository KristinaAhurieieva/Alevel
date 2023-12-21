using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        int[] firstArray = new int[20];
        int[] secondArray = new int[20];

        for (int i = 0; i < firstArray.Length; i++)
        {
            firstArray[i] = new Random().Next(-1000, 1000);

            if (firstArray[i] <= 888)
            {
                secondArray[i] = firstArray[i];
            }

        }


        Array.Sort(secondArray) ;
        Array.Reverse(secondArray);
  

        Console.WriteLine($"Values of first array: {string.Join(",", firstArray)}");

        Console.WriteLine($"Values of second array: {string.Join(",", secondArray)}");

    }

}

