using System;
using Serilog;

namespace Sequences
{
    public class SequenceApp
    {
        private Sequence _sequence;
        private UI _userInterface;

        public SequenceApp()
        {
            _userInterface = new UI();
        }

        public void Start()
        {
            do
            {
                try
                {
                    UserMode userMode = _userInterface.GetUserMode();
                    _sequence = GetSequence(userMode);
                    _userInterface.ShowSequence(_sequence);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_PARAMETERS);
                    Log.Logger.Error($"{ex.Message} SequenceApp.Start");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(TextMessages.WRONG_FORMAT);
                    Log.Logger.Error($"{ex.Message} SequenceApp.Start");
                }
            }
            while (_userInterface.IsRunAgain());
        }

        private Sequence GetSequence(UserMode userMode)
        {
            switch (userMode)
            {
                case UserMode.SequenceOfSquares:

                    string parameter = _userInterface.
                        GetUserParametersForSequence(TextMessages.INPUT_PARAMETERS_FOR_SEQUENCE_OF_SQUARES);

                    _sequence = new NumericalSequenceOfSquares(Convert.ToDouble(parameter));

                    break;

                case UserMode.Fibbonachi:

                    string [] split = _userInterface.GetUserParametersForSequence
                        (TextMessages.INPUT_PARAMETERS_FOR_SEQUENCE_OF_SQUARES).Split(' ');

                    _sequence= new FibbonachiSequence(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]));

                    break;

                default:

                    Log.Logger.Information($"Sequence.RunMode({userMode}) Default");
                    break;
            }

            return _sequence;
        }      
    }
}
