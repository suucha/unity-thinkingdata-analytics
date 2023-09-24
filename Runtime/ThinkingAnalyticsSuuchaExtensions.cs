using SuuchaStudio.Unity.Core;
using System.Collections.Generic;
using ThinkingData.Analytics;

namespace SuuchaStudio.Unity.LogEvents.Thinking.Analytics
{
    public static class ThinkingAnalyticsSuuchaExtensions
    {
        public static Suucha InitThinkingAnalytics(this Suucha suucha, string appId, string server)
        {
            TDAnalytics.Init(appId, server);
            if (!string.IsNullOrEmpty(suucha.CustomerUserId))
            {
                TDAnalytics.Login(suucha.CustomerUserId);
            }
            else
            {

                suucha.OnCustomerUserIdChanged += OnCustomerUserIdChanged;
                if (!string.IsNullOrEmpty(suucha.CustomerUserId))
                {
                    TDAnalytics.Login(suucha.CustomerUserId);
                }
            }
            return suucha;
        }

        private static void OnCustomerUserIdChanged(string oldId, string newId)
        {
            TDAnalytics.Login(newId);
        }
        private static bool thinkingAnalyticsLogEventAdded = false;
        private static ThinkingAnalyticsLogEventReporter reporter;
        public static ThinkingAnalyticsLogEventReporter InitThinkingAnalyticsReporter(this Suucha suucha,
            List<string> allowedEventNames = null,
            List<string> excludedEventNames = null,
            Dictionary<string, string> eventNameMap = null,
            Dictionary<string, string> eventParameterNameMap = null)
        {
            if (!thinkingAnalyticsLogEventAdded)
            {
                reporter = new ThinkingAnalyticsLogEventReporter(allowedEventNames,
                    excludedEventNames, 
                    eventNameMap,
                    eventParameterNameMap);
                thinkingAnalyticsLogEventAdded = true;
            }
            return reporter;
        }

    }
}
