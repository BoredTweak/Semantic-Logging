using System;
using System.Diagnostics.Tracing;

namespace LoggingInfrastructure
{
    /// <summary>
    /// A feature-specific event source. Each feature may necessarily have different logging needs, so event source implementations should be independently implemented.
    /// </summary>
    public class FeatureSpecificEventSource : EventSource
    {
        #region Singleton

        private static readonly FeatureSpecificEventSource log = new FeatureSpecificEventSource();

        private FeatureSpecificEventSource() { }

        public static FeatureSpecificEventSource Log = log;

        #endregion

        public static class KeyWords
        {
            public const EventKeywords Informational = (EventKeywords)0x10000000000000;
            public const EventKeywords Error = (EventKeywords)0x10000000000000;
            public const EventKeywords Warning = (EventKeywords)0x0;
        }

        private static class EventId
        {
            private const int Base = 100;

            public const int Informational = Base + 0;
            public const int Error = Base + 1;
            public const int Warning = Base + 2;
        }

        private static class Messages
        {
            public const string Informational = "Informational";
            public const string Error = "Error";
            public const string Warning = "Warning";
        }

        [Event(EventId.Informational, Message = Messages.Informational, Level = EventLevel.Informational, Keywords = KeyWords.Informational)]
        public void Informational(string className, string methodName, string message)
        {
            WriteEvent(EventId.Informational, className, methodName, message);
        }

        [Event(EventId.Error, Message = Messages.Error, Level = EventLevel.Error, Keywords = KeyWords.Error)]
        public void Error(string className, string methodName, string message)
        {
            WriteEvent(EventId.Error, className, methodName, message);
        }

        [Event(EventId.Warning, Message = Messages.Warning, Level = EventLevel.Warning, Keywords = KeyWords.Warning)]
        public void Warning(string className, string methodName, string message)
        {
            WriteEvent(EventId.Warning, className, methodName, message);
        }
    }
}
