using System;
using Serilog;

namespace Sequences
{
    class SequenceApp
    {
        private Sequence _sequence;
        private UI _userInterface = new UI();


        public void Start()
        {
            RunMode(_userInterface.GetUserMode());

            if (_userInterface.RunAgain())
            {
                Start();
            }
        }

        private void RunMode(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.SequenceOfSquares:

                    string parameter = _userInterface.GetUserParametersSequenceOfSquares();

                    try
                    {
                        _sequence = new NumericalSequenceOfSquares(Convert.ToDouble(parameter));
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                        Log.Logger.Error($"{ex.Message} SequenceApp.RunMode");
                        return;
                    }

                    ShowSequence();

                    break;

                case UserMode.Fibbonachi:

                    string [] split = _userInterface.GetUserParametersFibbonachi().Split(' ');

                    try
                    {
                        _sequence = new FibbonachiSequence(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                        Log.Logger.Error($"{ex.Message} SequenceApp.RunMode");
                        return;
                    }

                    ShowSequence();
                    
                    break;

                default:
                    Log.Logger.Information($"Sequence.RunMode({userMode}) Default");
                    break;
            }
        }

        private void ShowSequence()
        {
            foreach (int number in _sequence)
            {
                Console.Write(number + ", ");
            }

            Console.WriteLine("\n" + new string('-', 50));
        }
    }
}
