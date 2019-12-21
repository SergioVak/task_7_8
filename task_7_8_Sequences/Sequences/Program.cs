using System;
using Serilog;

namespace Sequences
{
    public class Program
    {
        static void Main(string[] args)
        {
            SequenceApplication _app = new SequenceApplication();

            Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
               .WriteTo.File("log.txt").CreateLogger();

            try
            {
                _app.Start();
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message} Main");
            }
        }
    }
}
