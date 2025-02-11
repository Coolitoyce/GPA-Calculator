using System;
using System.Linq;
using System.Threading;

internal class GPACalculator 
{
    const string ANOTHER_GPA_PROMPT = "Do you want to calculate another GPA? [Y/N]: ";

    // For printing text with a typewriter effect, just for fun ;)
    static void PrintWithDelay(string text, int time = 5) 
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(time); // delay in ms between each character
        }
    }

    // Calculate subject points and rating (letter grade) based on grade percentage and credit hours of each subject
    static (double, string) GetPoints(int grade, int hours)
    {
        double points;
        string rating;
        if (grade >= 96)
        {
            points = 4 * hours;
            rating = "A+";
        }
        else if (grade >= 92)
        {
            points = 3.7 * hours;
            rating = "A";
        }
        else if (grade >= 88)
        {
            points = 3.4 * hours;
            rating = "A-";
        }
        else if (grade >= 84)
        {
            points = 3.2 * hours;
            rating = "B+";
        }
        else if (grade >= 80)
        {
            points = 3 * hours;
            rating = "B";
        }
        else if (grade >= 76)
        {
            points = 2.8 * hours;
            rating = "B-";
        }
        else if (grade >= 72)
        {
            points = 2.6 * hours;
            rating = "C+";
        }
        else if (grade >= 68)
        {
            points = 2.4 * hours;
            rating = "C";
        }
        else if (grade >= 64)
        {
            points = 2.2 * hours;
            rating = "C-";
        }
        else if (grade >= 60)
        {
            points = 2 * hours;
            rating = "D+";
        }
        else if (grade >= 55)
        {
            points = 1.5 * hours;
            rating = "D";
        }
        else if (grade >= 50)
        {
            points = 1 * hours;
            rating = "D-";
        }
        else
        {
            points = 0;
            rating = "F";
        }
        return (points, rating);
    }

    // The main method of the program
    static void Main()
    {
        while (true)
        {
            // Don't mind the colors, it's just a nice touch :)
            ConsoleColor inputColor = ConsoleColor.Green; // Color for user input
            ConsoleColor errorColor = ConsoleColor.Red; // Color for error messages
            ConsoleColor lineColor = ConsoleColor.DarkMagenta; // Color for separator line
            ConsoleColor headerColor = ConsoleColor.Yellow; // Color for headers
            ConsoleColor cyan = ConsoleColor.Cyan;

            Console.ForegroundColor = cyan;
            Console.Write("**************************\n*     ");
            Console.ResetColor();
            Console.Write("GPA Calculator");
            Console.ForegroundColor = cyan;
            Console.WriteLine("     *\n**************************\n");
            Console.ResetColor();
            PrintWithDelay("Enter number of subjects: ");
            Console.ForegroundColor = inputColor;
            int N; // Number of subjects
            while (!int.TryParse(Console.ReadLine(), out N) || N <= 0) // Validate number of subjects
            {
                Console.ForegroundColor = errorColor;
                Console.WriteLine("Enter a valid number. (>0)");
                Console.ResetColor();
                Console.Write("Enter number of subjects: ");
                Console.ForegroundColor = inputColor;
            }
            Console.ResetColor();
            string[] subjects = new string[N]; // Array to stor e subject names
            int[] hours = new int[N]; // Array to store credit hours of each subject
            int[] grades = new int[N]; // Array to store grades in percentage of each subject
            double[] points = new double[N]; // Array to store grade points (GPA equivalent) of each subject
            string[] rating = new string[N]; // Array to store grade rating (letter grade) of each subject

            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n===== Subject Names =====");
            Console.ResetColor();

            // Loop through each subject to get subject names
            for (int i = 0; i < N; i++) 
            {
                while (true)
                {
                    Console.ResetColor(); 
                    Console.Write($"Enter Subject #{i + 1}: "); 
                    Console.ForegroundColor = inputColor;
                    subjects[i] = Console.ReadLine();
                    Console.ResetColor();
                    // Validate subject name
                    if (string.IsNullOrWhiteSpace(subjects[i])) // Check if subject name is empty or only spaces
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine("Subject name cannot be empty or only spaces.");
                    }
                    else if (!subjects[i].All(c => char.IsLetter(c) || char.IsWhiteSpace(c) || char.IsDigit(c))) // Check if subject name contains special characters (not letters, digits or spaces)
                    {
                        Console.ForegroundColor = errorColor;
                        Console.WriteLine("Subject name cannot contain special characters.");
                    }
                    else
                    {
                        subjects[i] = subjects[i].Trim(); // Remove leading and trailing spaces
                        break;
                    }
                }
            }

            int totalHrs = 0; // Total credit hours
            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n===== Subject Credit Hours =====");
            Console.ResetColor();

            // Loop through each subject to get credit hours for each subject
            for (int i = 0; i < N; i++)
            {
                Console.ResetColor();
                Console.Write($"Enter number of credit hours for {subjects[i]}: ");
                Console.ForegroundColor = inputColor;
                while (!int.TryParse(Console.ReadLine(), out hours[i]) || hours[i] <= 0 || hours[i] > 6) // Validate credit hours
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Enter a valid number. (1 - 6)");
                    Console.ResetColor();
                    Console.Write($"Enter number of credit hours for {subjects[i]}: ");
                    Console.ForegroundColor = inputColor;
                }
                totalHrs += hours[i];
            }

            Console.ForegroundColor = headerColor;
            Console.WriteLine("\n===== Subject Grades =====");
            double totalPoints = 0; 
            
            // Loop through each subject to get percentage for each subject
            for (int i = 0; i < N; i++)
            {
                Console.ResetColor();
                Console.Write($"Enter your percentage for {subjects[i]}: ");
                Console.ForegroundColor = inputColor;
                while (!int.TryParse(Console.ReadLine(), out grades[i]) || grades[i] < 0 || grades[i] > 100) // Validate percentage
                {
                    Console.ForegroundColor = errorColor;
                    Console.WriteLine("Enter a valid number. (0 - 100)");
                    Console.ResetColor();
                    Console.Write($"Enter your percentage for {subjects[i]}: ");
                    Console.ForegroundColor = inputColor;
                }
                (double subjectPoints, string gradeRating) = GetPoints(grades[i], hours[i]); // Get points and rating for each subject
                totalPoints += subjectPoints; // Add each subject points to total points
                points[i] = subjectPoints / hours[i]; // Assign grade points (GPA equivalent) to each subject
                rating[i] = gradeRating; // Assign rating (letter grade) to each subject
            }

            // Column headers
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            PrintWithDelay($"\n{"Subject",-23}"); // Display subject name with a width of 23 characters
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PrintWithDelay($"{"Grade",-10}"); // Display rating with a width of 10 characters
            Console.ForegroundColor = ConsoleColor.White;
            PrintWithDelay($"{"Grade Points",-15}"); // Display grade with a width of 15 characters
            Console.ForegroundColor = ConsoleColor.Red;
            PrintWithDelay($"{"Percentage",-12}"); // Display percentage with a width of 12 characters
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintWithDelay($"{"Credit Hours",-12}"); // Display credit hours with a width of 12 characters
            Console.WriteLine();
            Console.ForegroundColor = lineColor;
            PrintWithDelay($"{new string('*', 72)}\n"); // Separator line

            // Display results in a table
            for (int i = 0; i < N; i++)
            {
                Console.ForegroundColor = cyan;
                PrintWithDelay($"{subjects[i],-23}");
                Console.ForegroundColor = ConsoleColor.Green;
                PrintWithDelay($"{rating[i],-10}");
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintWithDelay($"{points[i],-15:F2}");
                Console.ForegroundColor = ConsoleColor.Blue;
                string perc = $"{grades[i]}%";
                PrintWithDelay($"{perc,-12}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                PrintWithDelay($"{hours[i],-12}\n");
            }
            Console.ForegroundColor = lineColor;
            PrintWithDelay($"{new string('*', 72)}\n"); // Separator line

            // Calculate and display final GPA
            double gpa = totalPoints / totalHrs;
            Console.ResetColor();
            PrintWithDelay($"\nYour Final GPA is ");
            Console.ForegroundColor = ConsoleColor.Green;
            PrintWithDelay($"{gpa:F2}\n"); // Display GPA with 2 decimal places
            Console.ResetColor();

            // Ask user if they want to calculate another GPA
            PrintWithDelay($"\n{ANOTHER_GPA_PROMPT}");
            Console.ForegroundColor = ConsoleColor.Gray;
            string response = Console.ReadLine().Trim().ToLower();
            while (string.IsNullOrWhiteSpace(response) || response is not ("no" or "n" or "yes" or "y")) // Validate user response (cannot be empty)
            {
                Console.ForegroundColor = errorColor;
                Console.WriteLine("Invalid response.");
                Console.ResetColor();
                Console.Write(ANOTHER_GPA_PROMPT);
                Console.ForegroundColor = ConsoleColor.Gray;
                response = Console.ReadLine().Trim().ToLower();
            }

            if (response == "n" || response == "no") // If user response is not "Y" or "Yes", exit the program
                {
                    Console.ResetColor();
                    PrintWithDelay("\nGoodbye... ");
                    Console.ReadKey(); // Wait for user to press a key before closing the console window
                    break;
                }
            
            Console.Clear(); // Clear console window for next operation
        }
    }
}
