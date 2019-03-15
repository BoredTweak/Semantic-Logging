using System;
using LoggingInfrastructure;

namespace LoggableApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sampling diagnostic logging");
            for (var i = 0; i < 200; i++)
            {
                ExcitingMethod(false, $"diagnostic log {i}");
            }

            Console.WriteLine("Sampling error logging");
            for (var i = 0; i < 2000; i++)
            {
                ExcitingMethod(true, $"error log {i}");
            }
        }

        private static void ExcitingMethod(bool doesThrowException, string message = "")
        {
            if (doesThrowException)
            {
                message = string.IsNullOrEmpty(message) ? "ExcitingMethod threw an error." : message;
                FeatureSpecificEventSource.Log.Error(nameof(LoggableApplication), nameof(ExcitingMethod), message);
            }
            else
            {
                message = string.IsNullOrEmpty(message) ? "ExcitingMethod did not throw an error." : message;
                FeatureSpecificEventSource.Log.Warning(nameof(LoggableApplication), nameof(ExcitingMethod), message);
            }
        }
    }
}
