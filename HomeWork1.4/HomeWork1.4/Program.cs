using System;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Enter the size of the array: ");
        string elements = Console.ReadLine();

        if (int.TryParse(elements, out int number))
        {
            Console.WriteLine($"Result size: {number}");
        }

        int[] myArray = new int[number];
        Console.WriteLine($"Lenght array: {myArray.Length}");

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = new Random().Next(1, 26);
        }

        int[] even = new int[myArray.Length];
        int[] odd = new int[myArray.Length];

        for (int i = 0; i < myArray.Length; i++)
        {
            if (myArray[i] % 2 == 0)
            {
                even[i] = myArray[i];

            }

            else
            {
                odd[i] = myArray[i];
            }
        }
        char[] evenLetters = ReplaceNumbersWithLetters(even);
        char[] oddLetters = ReplaceNumbersWithLetters(odd);
        int uppercaseEven = CalcUppercaseLetters(evenLetters);
        int uppercaseOdd = CalcUppercaseLetters(oddLetters);

        Console.WriteLine($"Generated array: {string.Join(",", myArray)}");
        Console.WriteLine($"Array with even values: {string.Join(",", even)}");
        Console.WriteLine($"Array with odd values: {string.Join(",", odd)}");
        Console.WriteLine($"Even array with letters: " + string.Join(" ", evenLetters));
        Console.WriteLine("Odd array with letters: " + string.Join(" ", oddLetters));
        Console.WriteLine("Count of uppercase letters in even array: " + uppercaseEven);
        Console.WriteLine("Count of uppercase letters in odd array: " + uppercaseOdd);

        if(uppercaseEven > uppercaseOdd)
        {
            Console.WriteLine("Even bigger than odd");
        } else if(uppercaseEven == uppercaseOdd)
        {
            Console.WriteLine("Even and odd is equal");
        } else
        {
            Console.WriteLine("Odd bigger than even");

        }

        static int CalcUppercaseLetters(char[] lettersArray)
        {
            int counter = 0;
            for(int idx = 0; idx < lettersArray.Length; idx++)
            {
                if (char.IsUpper(lettersArray[idx]))
                {
                    counter++;
                }
            }

            return counter;
        }

        static char[] ReplaceNumbersWithLetters(int[] numbers)
        {
            char[] lettersArray = new char[numbers.Length];
            char[] wordArray = { 'A', 'b', 'c', 'D', 'E', 'f', 'g', 'H', 'I', 'J', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] >= 1 && numbers[i] <= 26)
                {
                    lettersArray[i] = wordArray[numbers[i] - 1];
                }
            }
            return lettersArray;
        }
    }
}