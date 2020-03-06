using System;
// I would add this but the neither the source code nor the executable get's pushed to GitHub.
//using RLWUtil;  // On GitHub.  Just makes printing and reading user input cooler.  Just has Fancy.cs right now.

namespace AskForAge
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = true;
            while (restart)
            {
                Console.WriteLine("Hello there!");
                System.Threading.Thread.Sleep(1000);

                try
                {
                    bool invalidAnswer = true;
                    int age = 1;
                    while (invalidAnswer)
                    {
                        Console.Write("How many years old are you?  ");
                        invalidAnswer = !int.TryParse(Console.ReadLine(), out age);
                        if (invalidAnswer) Console.WriteLine("I need just the number, please.");
                        else
                        {
                            if (age <= 0) throw new TooYoungException();
                            if (age > 200) throw new TooOldException();
                        }
                    }

                    Console.Write("Have you had your birthday yet? (y or n)  ");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y" || choice == "yes" || choice == "ya" || choice == "yup" || choice == "yep") Console.WriteLine("That's cool.  Happy Birthday!");
                    else if (choice == "n" || choice == "no" || choice == "nah" || choice == "negative" || choice == "nope") age += 1;
                    else
                    {
                        Console.WriteLine("Ummm... I don't know what thay means so I'll just assume that's a no.");
                        age += 1;
                    }


                    Console.WriteLine($"Looks like you were born in {DateTime.Now.Year - age} then.");
                    System.Threading.Thread.Sleep(2000);
                    Console.Write("\nWell... Uh... Good talk.  Gotta go!");

                }
                catch (TooYoungException ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Threading.Thread.Sleep(2000);
                    Console.Write("\nWell... Uh... Good talk.  Gotta go!");
                }
                catch (TooOldException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine($"An exception got past me! Sorry.  Try again later maybe.");
                }


                Console.WriteLine("\n\nRestart Program? (y or n) ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "y") restart = false;
            }
            
            Console.ReadLine();
        }
    }

    public class TooYoungException : Exception
    {
        public TooYoungException()
            : base() { }
        public TooYoungException(string message)
            : base(message) { }

        public override string Message => "You are not allowed to be that young!!  Unless... You're from the future?!?";
    }

    public class TooOldException : Exception
    {
        public TooOldException()
            : base() { }
        public TooOldException(string message)
            : base(message) { }

        public override string Message => "Nobody is that old!  Wait... Are you a vampire!?!  RUN!!";
    }
}
