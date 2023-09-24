using System.Collections.Generic;
using SuuchaStudio.Unity.Core.LogEvents;
using Cysharp.Threading.Tasks;
using ThinkingData.Analytics;

namespace SuuchaStudio.Unity.LogEvents.Thinking.Analytics
{
    public class ThinkingAnalyticsLogEventReporter : LogEventReporterAbstract
    {
        public override string Name => "ThinkingAnalytics";
        public ThinkingAnalyticsLogEventReporter():base()
        {

        }
        public ThinkingAnalyticsLogEventReporter(List<string> allowedEventNames,
            List<string> excludedEventNames,
            Dictionary<string, string> eventNameMap,
            Dictionary<string, string> eventParameterNameMap)
            :base(allowedEventNames, excludedEventNames,eventNameMap, eventParameterNameMap)
        {

        }

        protected override UniTask LogEventInternal(string name, Dictionary<string, string> eventParameters)
        {
            var parameters = ConvertParameters(eventParameters);
            TDAnalytics.Track(name, parameters);
            return UniTask.CompletedTask;
        }
        private Dictionary<string, object> ConvertParameters(Dictionary<string, string> eventParameters)
        {
            var parameters = new Dictionary<string, object>();
            foreach (var key in eventParameters.Keys)
            {
                parameters.Add(key, eventParameters[key]);
            }
            return parameters;
        }
    }
}
