using Serilog;
using System;

namespace Sequences
{
    public class SequenceApplication
    {
        private const int SEQUENCE_OF_SQUARES = 1;
        private const int FIBBONACHI = 2;

        private Sequence _sequence;
        private readonly SequenceUI _userInterface;

        public SequenceApplication()
        {
            _userInterface = new SequenceUI();
        }

        public void Start(string[] args)
        {
            do
            {
                try
                {
                    UserMode userMode;

                    if (args.Length != 0)
                    {
                        if (args.Length != 1)
                        {
                            throw new ArgumentException();
                        }
                        else
                        {
                            if(Convert.ToInt32(args[0]) == SEQUENCE_OF_SQUARES)
                            {
                                userMode = UserMode.SequenceOfSquares;
                            }
                            else if(Convert.ToInt32(args[0]) == FIBBONACHI)
                            {
                                userMode = UserMode.Fibbonachi;
                            }
                            else
                            {
                                throw new ArgumentException();
                            }
                        }
                    }
                    else
                    {
                        _userInterface.ShowHelp();
                        userMode = _userInterface.GetUserMode();
                    }

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

                Array.Clear(args, 0, args.Length);
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
                        (TextMessages.INPUT_PARAMETERS_FOR_FIBBONACHI).Split(' ');

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
