using LoggingInfrastructure;
using System;

namespace LoggableApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sampling diagnostic logging");
            ExcitingMethod(false);

            Console.WriteLine("Sampling error logging");
            ExcitingMethod(true);
        }

        private static void ExcitingMethod(bool doesThrowException)
        {
            if(doesThrowException)
            {
                var message = "ExcitingMethod threw an error.";
                FeatureSpecificEventSource.Log.Error(nameof(LoggableApplication), nameof(ExcitingMethod), message);
                throw new InvalidOperationException(message);
            }
            else
            {
                var message = "ExcitingMethod did not throw an error.";
                FeatureSpecificEventSource.Log.Diagnostic(nameof(LoggableApplication), nameof(ExcitingMethod), message);
            }
        }
    }
}
