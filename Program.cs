using System;

namespace Calculator2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculator";

            // Setting the height and width of the console window.
            Console.WindowWidth = 90;
            Console.WindowHeight = 30;

            // Greeting output.
            ShowGreeting();

            // Save result yes/no.
            string save = "";

            // Repeat operation.
            string reapit = "";

            // Continuation of calculations.
            string contin = "";
            int numberMenu = 0;
            double result = 0.0;

            // Array for storing 5 latest results
            // in the program it increases from 1 to 5.
            double[] results = new double[1];

            // Creating an instance of a calculator.
            Calculator calculator = new Calculator();

            // Cycle of work with the program (performing actions from the menu).
            while (true)
            {
                // Menu call.
                Calculator.Menu();

                // Operation of the menu action selection method.
                numberMenu = EnterNumberMenu();

                // New calculation is selected.
                if (numberMenu == 1)
                {
                    while (true)
                    {
                        // To write the result to the first element of the array.
                        double temp;

                        // Calculating and returning the result.
                        result = calculator.Calculetion();

                        // With different lengths of the array, it is necessary to write to it in different ways
                        // the last result is written to the first element of the array,
                        // the rest of the results are shifted one position further in the array
                        // if there are more than 5 results, then the older ones are destroyed.
                        if (results.Length == 1)
                        {
                            results[0] = result;
                        }
                        else
                        {
                            temp = result;

                            for (int i = results.Length - 1; i > 0; i--)
                            {
                                results[i] = results[i - 1];
                            }
                            results[0] = temp;
                        }

                        // Increasing array size.
                        if (results.Length < 5)
                        {
                            Array.Resize(ref results, results.Length + 1);
                        }

                        // Result output.
                        calculator.ShowResult();

                        Console.WriteLine();

                        // Actions to save, redo or continue.
                        save = Calculator.SaveResult();

                        if (save == "y")
                        {
                            reapit = Calculator.RepeatOperation();
                            continue;
                        }
                        else
                        {
                            contin = Calculator.Continue();

                            if (contin == "y")
                            {
                                reapit = Calculator.RepeatOperation();
                            }
                            else
                            {
                                break;
                            }
                            continue;
                        }
                    }

                    continue;
                }
                // Displaying the latest results on the screen
                // if the results are less than 5, then only they are displayed.
                else if (numberMenu == 2)
                {
                    Console.Clear();

                    if (results.Length < 5)
                    {
                        for (int i = 0; i < results.Length - 1; i++)
                            Console.WriteLine($"result{i + 1} = {results[i]}");
                    }
                    else
                    {
                        for (int i = 0; i < results.Length; i++)
                            Console.WriteLine($"result{i + 1} = {results[i]}");
                    }

                    Console.WriteLine();

                    continue;
                }
                // Displaying information about the program.
                else if (numberMenu == 3)
                {
                    Console.Clear();

                    AboutProgram();

                    continue;
                }
                // Exit application.
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        static void ShowGreeting()
        {
            // Greeting output.
            // Output of the inscription approximately to the middle of the window.
            Console.Write("\t\t\t");

            // Change font and background color.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello! Welcome to the calculator program.");

            // Return color and background.
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }
        static int EnterNumberMenu()
        {
            int numberMenu = 0;

            // Cycle until one of the menu item numbers is entered.
            while (true)
            {
                // Entering the action number from the menu.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Check for correspondence of the number from the menu to the entered number.
                if (numberMenu > 0 && numberMenu < 5)
                {
                    break;
                }
                else
                {
                    Console.Clear();

                    Calculator.Menu();

                    Console.Write("\nenter a number from 1 to 4: ");

                    continue;
                }
            }

            return numberMenu;
        }
        static void AboutProgram()
        {
            Console.WriteLine("Console CALCULATOR program, version 2.0");

            Console.WriteLine("\nAllows you to perform the following operations:");
            Console.WriteLine("- addition;");
            Console.WriteLine("- subtraction;");
            Console.WriteLine("- multiplication;");
            Console.WriteLine("- division;");
            Console.WriteLine("- exponentiation;");
            Console.WriteLine("- finding the square root.");
            Console.WriteLine("It allows you to save the result of the operation and use it in other");
            Console.WriteLine("calculations; after completing each block of calculations, it is");
            Console.WriteLine("possible to start a new block of calculations without leaving the program.");

            Console.WriteLine("\nDeveloper - Yarmalkevich V.I.");

            Console.WriteLine();
        }
    }
}
