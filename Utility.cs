public static class Utility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        public static void RemoveContentTypesByGroup(this SPWeb web, string group)
        {
            try
            {
                List<SPContentType> contentTypes = web.AvailableContentTypes.Cast<SPContentType>().Where(p => p.Group == group).ToList();

                foreach(SPContentType contentType in contentTypes)
                {
                    web.RemoveContentType(contentType.Name);
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:UTILITY", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:RemoveContentTypesByGroup. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        public static void RemoveSiteColumnsByGroup(this SPWeb web, string group)
        {
            try
            {
                List<SPField> fields = web.AvailableFields.Cast<SPField>().Where(f => f.Group == group).ToList();

                foreach (SPField field in fields)
                {
                    web.RemoveSiteColumn(field.Title);
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:UTILITY", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:RemoveSiteColumnsByGroup. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }
    }
