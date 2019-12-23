using System;
using Serilog;

namespace Sequences
{
    public class SequenceUI
    {
        public UserMode GetUserMode()
        {
            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case TextMessages.SEQUENCE_OF_SQUARES_SELECT:

                    return UserMode.SequenceOfSquares;

                case TextMessages.FIBBONACHI_SELECT:

                    return UserMode.Fibbonachi;

                default:
                    Log.Logger.Information($"UI.Default({userInput})");
                    Console.WriteLine(TextMessages.WRONG_INPUT);
                    return GetUserMode();
            }
        }

        public string GetUserParametersForSequence(string information)
        {
            Console.WriteLine(information);

            return Console.ReadLine();
        }

        public bool IsRunAgain()
        {
            bool reAsk = false;
            bool result = false;

            do
            {
                string input = string.Empty;

                Console.WriteLine(TextMessages.RUN_AGAIN);
                input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case TextMessages.YES:
                    case TextMessages.Y:
                        result = true;
                        reAsk = false;

                        break;

                    case TextMessages.NO:
                    case TextMessages.N:
                        result = false;
                        reAsk = false;

                        break;

                    default:
                        Log.Logger.Information($"UI default. RunAgain {input}");
                        Console.WriteLine(TextMessages.WRONG_INPUT);
                        Console.WriteLine();

                        reAsk = true;

                        break;
                }
            }
            while (reAsk);

            return result;
        }

        public void ShowSequence(Sequence sequence)
        {
            int counter = 0;

            Console.Write(TextMessages.SEQUENCE + " : ");

            foreach (int number in sequence)
            {
                Console.Write(number + " ");
                counter++;
            }

            if (counter == 0)
            {
                Console.Write(TextMessages.EMPTY_RESULT);
            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        public string ConvertSequenceToString(Sequence sequence)
        {
            string str = string.Empty;

            foreach (int number in sequence)
            {
                str += number.ToString() + " ";
            }

            return str;
        }

        public void ShowHelp()
        {
            Console.WriteLine(TextMessages.HELP);
        }
    }
}
