using System;
using Serilog;

namespace Sequences
{
    public class UI
    {
        public UserMode GetUserMode()
        {
            ShowHelp();

            string userInput = Console.ReadLine().ToLower();

            switch (userInput)
            {
                case TextMessages.SEQUENCE_OF_SQUARES_SELECT:

                    return UserMode.SequenceOfSquares;

                case TextMessages.FIBBONACHI_SELECT:

                    return UserMode.Fibbonachi;

                default:
                    Log.Logger.Information($"UI.Default({userInput})");

                    return GetUserMode();
            }
        }

        public string GetUserParametersFibbonachi()
        {
            Console.WriteLine(TextMessages.INPUT_PARAMETERS_FOR_FIBBONACHI);

            return Console.ReadLine();
        }

        public string GetUserParametersSequenceOfSquares()
        {
            Console.WriteLine(TextMessages.INPUT_PARAMETERS_FOR_SEQUENCE_OF_SQUARES);

            return Console.ReadLine();
        }

        public bool RunAgain()
        {
            string input;
            bool result;

            Console.WriteLine(TextMessages.RUN_AGAIN);
            input = Console.ReadLine();

            switch (input.ToLower())
            {
                case TextMessages.YES:
                case TextMessages.Y:
                    result = true;
                    break;

                case TextMessages.NO:
                case TextMessages.N:
                    result = false;
                    break;

                default:
                    Log.Logger.Information($"UI default. User input {input}");
                    Console.WriteLine(TextMessages.RUN_AGAIN);

                    return RunAgain();
            }

            return result;
        }

        public void ShowSequence(Sequence sequence)
        {
            foreach (int number in sequence)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine("\n" + new string('-', 50));
        }

        private void ShowHelp()
        {
            Console.WriteLine(TextMessages.HELP);
        }
    }
}
