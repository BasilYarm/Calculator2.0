using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2._0
{
    class Calculator
    {
        // Storing the first value.
        static double firstValue;

        // Storing the second value.
        static double secondValue;

        // Storing the result.
        static double result;

        // Operation sign storage. 
        static char operation;

        // If the square root is being calculated, then only one value is needed.
        static int counterOper = 0;

        // When starting a new calculation and when repeating an operation in 
        // the old one, you must reset the possibility of repeating the operation.
        static int counterRepit = 0;

        public static void Menu()
        {
            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\npress 1 for new calculation;");
            Console.WriteLine("press 2 to display the results of recent operations;");
            Console.WriteLine("press 3 for program information;");
            Console.WriteLine("press 4 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static string Continue()
        {
            Console.Write("Continue? y/n ");

            string contin = Console.ReadLine();

            while (true)
            {
                // If we start a new calculation, then we need to remove the repetition of the operation.
                if (contin.ToLower() == "n" || contin.ToLower() == "y")
                {
                    counterRepit = 0;

                    Console.Clear();

                    break;
                }
                else
                {
                    Console.Write("Enter y/n: ");

                    contin = Console.ReadLine();

                    continue;
                }
            }

            return contin;
        }

        public static string SaveResult()
        {
            string save = "";

            Console.Write("Save the result? y/n ");

            save = Console.ReadLine();

            // The cycle is tied to the value of the flag.
            bool flag = true;

            while (flag)
            {
                // Always cast save to lowercase, if it is equal to n,
                // then we make it possible to enter the first number and exit the loop.
                if (save.ToLower() == "n")
                {
                    counterOper = 0;

                    Console.Clear();

                    break;
                }

                // Do not exit the loop until we enter "y" or "n".
                else if (save.ToLower() != "y")
                {
                    Console.Clear();

                    Console.Write("Enter y/n: ");

                    save = Console.ReadLine();

                }
                else
                {
                    Console.Clear();

                    // The first number we assign the current result.
                    firstValue = result;

                    // Prohibition of entering the first number.
                    counterOper++;

                    flag = false;
                }
            }
            return save;
        }

        public static string RepeatOperation()
        {
            // Almost everything is like in the SaveResult() method.
            string repit = "";

            Console.Write("Repit the operation? y/n ");

            repit = Console.ReadLine();

            bool flag = true;

            while (flag)
            {
                if (repit.ToLower() == "n")
                {
                    counterRepit = 0;

                    Console.Clear();

                    break;
                }
                else if (repit.ToLower() != "y")
                {
                    Console.Clear();

                    Console.Write("Enter y/n: ");

                    repit = Console.ReadLine();
                }
                else
                {
                    Console.Clear();

                    counterRepit++;

                    Console.Clear();

                    flag = false;
                }
            }
            return repit;
        }

        public double Calculetion()
        {
            Console.Clear();

            // Input values.
            AllRead();

            // Performing the desired operation with the entered values.
            switch (operation)
            {
                case '+': result = firstValue + secondValue; break;
                case '-': result = firstValue - secondValue; break;
                case '*': result = firstValue * secondValue; break;
                case '/': result = firstValue / secondValue; break;
                case '%': result = (firstValue / 100) * secondValue; break;
                case '^': result = Math.Pow(firstValue, secondValue); break;
                case 'v': result = Math.Sqrt(firstValue); break;
            }

            return result;
        }

        public void ShowResult()
        {
            Console.Clear();

            // All operations have two operands, the sign of the operation and the result. 
            if (operation != 'v' && operation != '%')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{firstValue} {operation} {secondValue} = {result}");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // In the operation of finding the root - the sign of the operation, the number and the result.
            else if (operation != '%')
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{operation}{firstValue} = {result}");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // When finding a percentage, for example 10% of 100 = 10 
            // (second number, operation sign, first number, result).
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Your result: ");
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"{secondValue} {operation} of {firstValue} = {result}");

                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        void ShowMenuOperation()
        {
            // A prompt to enter a character for the operation being performed (v - most like a root).
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\nEnter the sign of the operation");
            Console.WriteLine("\tfor plus     - '+'");
            Console.WriteLine("\tfor minus    - '-'");
            Console.WriteLine("\tfor multiply - '*'");
            Console.WriteLine("\tfor divide   - '/'");
            Console.WriteLine("\tfor percent  - '%'");
            Console.WriteLine("\tfor power    - '^'");
            Console.Write("\tfor square   - 'v': ");
        }

        void ReadOperation()
        {
            if (counterRepit == 0)
            {
                // Endlessly catching exceptions until we enter one character.
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        operation = Char.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;

                        ShowMenuOperation();
                        continue;
                    }
                }

                // Endless input of characters until we enter one of the required.
                while (true)
                {
                    bool condition = operation == '+' || operation == '-' || operation == '*' || operation == '/' || operation == '%' || operation == '^' || operation == 'v';

                    Console.Clear();

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Enter the sign ('+' or '-' or '*' or '/' or '%' or '^' or 'v'): ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Char.TryParse(Console.ReadLine(), out operation);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        void ReadFirstValue()
        {
            while (true)
            {
                if (counterOper == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("Enter the first value: ");

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        firstValue = Double.Parse(Console.ReadLine());

                        // When entering the operation of taking a root, 
                        // I ensure the prohibition of entering negative values.
                        if (operation == 'v' && firstValue < 0)
                            // Closest exception.
                            throw new InvalidOperationException();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;
                    }
                    catch (OverflowException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);

                        continue;
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message + "\nEnter value >= 0.");

                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                        continue;
                    }
                }
                // If the first number is not entered, then its value is displayed.
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("First value = ");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(firstValue);
                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
            }
        }

        void ReadSecondValue()
        {
            Console.Clear();

            Console.Write("FirstValue = ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(firstValue);

            Console.WriteLine();

            // The second number should not be entered when finding the square root.
            if (operation != 'v')
            {
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write("Enter the second value: ");

                    // Plus handling zero input when performing a division operation.
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        secondValue = Double.Parse(Console.ReadLine());

                        if (secondValue == 0)
                            throw new DivideByZeroException();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        break;

                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(firstValue);

                        Console.WriteLine("\n" + ex.Message + "\nEnter an integer or real value (such as 7 or 3.14) that is not zero.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        continue;
                    }
                    catch (OverflowException ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(firstValue);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n" + ex.Message);

                        continue;
                    }
                    catch (Exception ex)
                    {
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("FirstValue = ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(firstValue);

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n" + ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                        continue;
                    }
                }
            }
        }

        void AllRead()
        {
            // When the operation is repeated, the operation selection menu should not be displayed.
            if (counterRepit == 0)
            {
                ShowMenuOperation();
            }

            ReadOperation();

            ReadFirstValue();

            ReadSecondValue();
        }
    }
}
