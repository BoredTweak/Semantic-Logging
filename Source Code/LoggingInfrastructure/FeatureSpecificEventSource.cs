using System;
using System.Diagnostics.Tracing;

namespace LoggingInfrastructure
{
    /// <summary>
    /// A feature-specific event source. Each feature may necessarily have different logging needs, so event source implementations should be independently implemented.
    /// </summary>
    public class FeatureSpecificEventSource :EventSource
    {
        #region Singleton

        private static readonly Lazy<FeatureSpecificEventSource> log = new Lazy<FeatureSpecificEventSource>();

        private FeatureSpecificEventSource() { }

        public static FeatureSpecificEventSource Log = log.Value;

        #endregion

        public static class KeyWords
        {
            public const EventKeywords Diagnostic = (EventKeywords)0x01;
            public const EventKeywords Error = (EventKeywords)0x02;
            public const EventKeywords Warning = (EventKeywords)0x04;
        }

        private static class EventId
        {
            private const int Base = 100;

            public const int Diagnostic = Base + 0;
            public const int Error = Base + 1;
            public const int Warning = Base + 2;
        }

        private static class Messages
        {
            public const string Diagnostic = "Diagnostic";
            public const string Error = "Error";
            public const string Warning = "Warning";
        }

        [Event(EventId.Diagnostic, Message = Messages.Diagnostic, Level = EventLevel.Informational, Keywords = KeyWords.Diagnostic)]
        public void Diagnostic(string className, string methodName, string message) =>
            WriteEvent(EventId.Diagnostic, className, methodName, message);

        [Event(EventId.Error, Message = Messages.Error, Level = EventLevel.Error, Keywords = KeyWords.Error)]
        public void Error(string className, string methodName, string message) =>
            WriteEvent(EventId.Error, className, methodName, message);

        [Event(EventId.Warning, Message = Messages.Warning, Level = EventLevel.Warning, Keywords = KeyWords.Warning)]
        public void Warning(string className, string methodName, string message) =>
            WriteEvent(EventId.Warning, className, methodName, message);
    }
}
