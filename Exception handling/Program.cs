using System;

namespace Exception_handling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("         1-Check for duplicate numbers      \n");
            try
            {
                Console.WriteLine("Enter numbers separated by spaces:");
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');


                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            throw new Exception("Duplicate number found: " + numbers[i]);
                        }
                    }
                }

                Console.WriteLine(" All numbers are unique!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


            Console.WriteLine("**************************************************\n");

            Console.WriteLine("     2- Check for vowels             \n");

            try
            {
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();
                bool hasVowel = false;

                for (int i = 0; i < input.Length; i++)
                {
                    char c = char.ToLower(input[i]);
                    if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
                    {
                        hasVowel = true;
                        break;
                    }
                }

                if (!hasVowel)
                {
                    throw new Exception("No vowels found in the string!");
                }

                Console.WriteLine(" The string contains vowels!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: " + ex.Message);
            }













        }
    }
}





        










        
    

