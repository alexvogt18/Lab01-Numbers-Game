using System;

namespace Lab01_Numbers_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome!");
                StartSequence();
            }
            catch (Exception e)
            { 
                Console.WriteLine($"Oops! Error ~ Please try again: {e}");
            }
            finally
            { 
                Console.WriteLine("Program End");
            }    
        }

        public static void StartSequence()
        {
            try 
            {
                // =====The first function of the program is determining the array length based on user input=====
                int firstNumber;
                Console.WriteLine("Please enter a number greater than 0!");
                firstNumber = Convert.ToInt32(Console.ReadLine());
                int[] numberArray = new int[firstNumber];
                int numberAmount = numberArray.Length;
                //====== Below is the function that populates the array===========
                numberArray = Populate(numberArray);
                //====== Using the populated array, the program is now able to perform methods using inputted numbers
                int numberSum = GetSum(numberArray); 
                int numberMult = GetProduct(numberArray, numberSum);
                GetQuotient(numberMult);
                Console.WriteLine($"Your array is size: {numberArray.Length}");
                Console.Write("The numbers in the array are: ");
                //=============== In order to list array values, a for loop is used===========
                for(int i = 0; i < numberArray.Length; i++)
                {
                Console.Write($" {numberArray[i]}");
                }
                Console.WriteLine(" ");
                Console.WriteLine($"The sum of the array is {numberSum}");
            }
            catch(FormatException e)
            { 
                Console.WriteLine("Sorry, Format Trouble! Try again!");
            }
            catch(OverflowException e)
            { 
                Console.WriteLine("Sorry, Overflow! Try again!");
            }
        }

        public static decimal GetQuotient(int numberMult)
        {
            decimal numDenom;
            
            Console.WriteLine($"Please enter a number to divide {numberMult} by!");
            numDenom = Convert.ToDecimal(Console.ReadLine());
            decimal numDiv = decimal.Divide(numberMult, numDenom);
            try
            {
                return numDiv;
            }
            catch(DivideByZeroException e)
            { 
                Console.WriteLine("Sorry! You cannot divide by 0!");
                return 0;
            }
        }

        public static int GetProduct(int[] numberArray, int numberSum)
        {
            int numberMult;
            int arrayNum;
            Console.WriteLine($"Please select a number between 1 and {numberArray.Length}");
            arrayNum = Convert.ToInt32(Console.ReadLine());
            numberMult = numberSum * numberArray[arrayNum];
            try
            { 
                return numberMult;
            }
            catch(IndexOutOfRangeException e)
            { 
                throw new IndexOutOfRangeException("Sorry, the number you entered is out of range! Please try again!");
            }
        }

        public static int GetSum(int[] numberArray)
        {
            int numberSum = 0;
            for (int i = 0; i < numberArray.Length; i++)
            { 
                numberSum += numberArray[i];
            }
            //==========This is the custom exception used to exhibit custom error handling=======
            if (numberSum < 20)
            { 
                throw new Exception($"Value of {numberSum} is too low");
            }
            else
            { 
                return numberSum;
            }
            
        }

        public static int[] Populate(int[] args)
        {
            int questionCounter = 0;
            for( int i = 0; i < args.Length; i++)
            {
                while(questionCounter < args.Length)
                { 
                questionCounter++;
                Console.WriteLine($"Please enter a number {questionCounter} / {args.Length}");
                args[i] = Convert.ToInt32(Console.ReadLine());
                i++;
                }
            }
            return args;
        }
    }
}
