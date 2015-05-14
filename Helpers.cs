public static class Helpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <param name="maxLength"></param>
        public static void CreateTextColumn(this SPWeb web, string group, string description, string name, string displayName, int maxLength = 255)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.Text, false);

                    SPFieldText field = (SPFieldText)web.Fields.GetField(name);

                    field.Group = group;
                    field.MaxLength = maxLength;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateTextColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ",ex.Message,ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <param name="decimals"></param>
        public static void CreateNumberColumn(this SPWeb web, string group, string description, string name, string displayName, SPNumberFormatTypes decimals = SPNumberFormatTypes.Automatic)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.Number, false);

                    SPFieldNumber field = (SPFieldNumber)web.Fields.GetField(name);

                    field.Group = group;
                    field.DisplayFormat = decimals;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateNumberColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <param name="urlList"></param>
        /// <param name="field"></param>
        public static void CreateLookupColumn(this SPWeb web, string group, string description, string name, string displayName, string urlList, string field)
        {
            try
            {
                SPList lookupList = web.GetList(urlList);

                web.Fields.AddLookup(name, lookupList.ID, lookupList.ParentWeb.ID, true);

                SPFieldLookup lkp = (SPFieldLookup)web.Fields[name];
                lkp.Description = description;
                lkp.Group = group;
                lkp.Title = displayName;
                lkp.LookupField = lookupList.Fields[field].InternalName;

                lkp.Update();
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateDateTimeColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        /// <param name="description"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        /// <param name="options"></param>
        /// <param name="defaultOption"></param>
        public static void CreateChoiceColumn(this SPWeb web, string group, string description, string name, string displayName, string [] options, string defaultOption = "")
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.Choice, false);

                    SPFieldChoice field = (SPFieldChoice)web.Fields.GetField(name);

                    field.Group = group;
                    field.Choices.AddRange(options);
                    field.DefaultValue = defaultOption;
                    field.FillInChoice = true;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateChoiceColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        public static void CreateNoteColumn(this SPWeb web, string group, string description, string name, string displayName, int numberOfLines, bool richText = true)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.Note, false);

                    SPFieldMultiLineText field = (SPFieldMultiLineText)web.Fields.GetField(name);

                    field.Group = group;
                    field.RichText = richText;
                    field.NumberOfLines = numberOfLines;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateNoteColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        public static void CreateUserColumn(this SPWeb web, string group, string description, string name, string displayName)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.User, false);

                    SPFieldUser field = (SPFieldUser)web.Fields.GetField(name);

                    field.Group = group;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateUserColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="group"></param>
        /// <param name="dscription"></param>
        /// <param name="name"></param>
        /// <param name="displayName"></param>
        public static void CreateBooleanColumn(this SPWeb web, string group, string description, string name, string displayName)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.Boolean, false);

                    SPFieldBoolean field = (SPFieldBoolean)web.Fields.GetField(name);

                    field.Group = group;
                    field.StaticName = name;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateBooleanColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        public static void CreateDateTimeColumn(this SPWeb web, string group, string description, string name, string displayName, SPDateTimeFieldFormatType format = SPDateTimeFieldFormatType.DateOnly)
        {
            try
            {
                if (!web.Fields.ContainsField(name))
                {
                    string fieldName = web.Fields.Add(name, SPFieldType.DateTime, false);

                    SPFieldDateTime field = (SPFieldDateTime)web.Fields.GetField(name);

                    field.Group = group;
                    field.StaticName = name;
                    field.DisplayFormat = format;
                    field.Title = displayName;
                    field.NoCrawl = false;
                    field.Description = description;

                    field.Update();

                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateDateTimeColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="parentId"></param>
        /// <param name="group"></param>
        /// <param name="name"></param>
        public static void CreateContentType(this SPWeb web, string parentId, string group, string name, string description)
        {
            try
            {
                if (web.AvailableContentTypes[name] == null)
                {
                    SPContentType itemCType = web.AvailableContentTypes[new SPContentTypeId(parentId)];

                    if (itemCType != null)
                    {
                        SPContentType contentType =
                            new SPContentType(itemCType, web.ContentTypes, name) { Group = @group };
                        web.ContentTypes.Add(contentType);
                        contentType.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateContentType. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="contentName"></param>
        /// <param name="column"></param>
        /// <param name="required"></param>
        /// <param name="readonlyField"></param>
        public static void AddColumntToContentType(this SPWeb web, string contentName, string column, bool required = false, bool readonlyField = false)
        {
            try
            {
                SPContentType contentType = web.ContentTypes[contentName];

                if (contentType != null)
                {
                    if (!contentType.Fields.ContainsField(column))
                    {
                        SPField field = web.Fields.GetField(column);

                        SPFieldLink fieldLink = new SPFieldLink(field);
                        fieldLink.Required = required;
                        fieldLink.ReadOnly = readonlyField;

                        contentType.FieldLinks.Add(fieldLink);
                        contentType.Update(true);
                    }
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:AddColumntToContentType. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="template"></param>
        public static void CreateList(this SPWeb web, string name, string description, SPListTemplateType template = SPListTemplateType.GenericList, bool allowModeration = false, bool allowVersioning = false)
        {
            try
            {
                if (web.Lists.TryGetList(name) == null)
                    web.Lists.Add(name, description, template);
                
                string listUrl = String.Format("Lists/{0}", name);
                SPList list = web.GetList(listUrl);

                list.EnableModeration = allowModeration;
                list.EnableVersioning = allowVersioning;

                list.Update();
                web.Update();
                
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateList. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listName"></param>
        /// <param name="contentTypeName"></param>
        public static void AddContentTypeToList(this SPWeb web, string listName, string contentTypeName)
        {
            try
            {              
                SPContentType contentTypes = web.AvailableContentTypes[contentTypeName];
                
                if (contentTypes != null)
                {
                    string listUrl = String.Format("Lists/{0}", listName);
                    SPList list = web.GetList(listUrl);

                    list.ContentTypesEnabled = true;       
                    list.ContentTypes.Add(contentTypes);

                    list.EnableFolderCreation = false;
                    list.Update();
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:AddContentTypeToList. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="p"></param>
        public static void DeleteList(this SPWeb web, string listName)
        {
            try
            {
                string listUrl = String.Format("Lists/{0}", listName);

                SPList list = web.GetList(listUrl);

                System.Guid listGuid = list.ID;
                web.Lists.Delete(listGuid);
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:DeleteList. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="contentTypeName"></param>
        public static void RemoveContentType(this SPWeb web, string contentTypeName)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                SPContentTypeCollection contentTypes = web.ContentTypes;

                contentTypes.Delete(contentTypes[contentTypeName].Id);
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:RemoveContentType. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
            finally
            {
                web.AllowUnsafeUpdates = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="siteColumnName"></param>
        public static void RemoveSiteColumn(this SPWeb web, string siteColumnName)
        {
            try
            {
                if (web.Fields.ContainsField(siteColumnName))
                    web.Fields.Delete(siteColumnName);
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:RemoveSiteColumn. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="page"></param>
        /// <param name="webPartZone"></param>
        /// <param name="order"></param>
        /// <param name="webpart"></param>
        public static void AddWebPartToPage(this SPWeb web, string page, string webPartZone, int order, System.Web.UI.WebControls.WebParts.WebPart webpart)
        {
            try
            {
                SPFile file = web.GetFile(page);

                if (!file.Exists)
                {
                    throw new SPException(string.Format("File '{0}' does not exist", file.ServerRelativeUrl));
                }

                SPLimitedWebPartManager partManager = file.GetLimitedWebPartManager(System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared);

                partManager.AddWebPart(webpart, webPartZone, order);
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:AddWebPartToPage. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void AddPropertyBag(this SPWeb web, string name, string value)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                if (!web.AllProperties.ContainsKey(name.ToLower()))
                    web.Properties.Add(name, value);
                else
                    web.AllProperties[name] = value;

                web.Properties.Update();
                web.AllowUnsafeUpdates = false;
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:AddPropertyBag. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="url"></param>
        /// <param name="name"></param>
        public static void RemovePropertyBag(this SPWeb web, string name)
        {
            try
            {
                web.AllowUnsafeUpdates = true;

                if (web.AllProperties.ContainsKey(name.ToLower()))
                    web.Properties.Remove(name);

                web.Properties.Update();
                web.AllowUnsafeUpdates = false;
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:RemovePropertyBag. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetPropertyBag(this SPWeb web, string name)
        {
            try
            {
                string property = "";

                if (web.AllProperties.ContainsKey(name.ToLower()))
                    property = web.Properties[name];
                else
                    property = "";

                return property;
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:GetPropertyBag. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
                throw ex;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="web"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public static void CreateDocumentLibrary(this SPWeb web, string name, string description, bool allowModeration = false, bool allowVersioning = false)
        {
            try
            {
                if (web.Lists.TryGetList(name) == null)
                    web.Lists.Add(name, description, SPListTemplateType.DocumentLibrary);

                string listUrl = String.Format("{0}", name);
                SPList list = web.GetList(listUrl);

                list.EnableModeration = allowModeration;
                list.EnableVersioning = allowVersioning;

                list.Update();
                web.Update();
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, String.Format("Exception happened in Helpers:CreateDocumentLibrary. MESSAGE: {0}. EXCEPTION TRACE: {1} ", ex.Message, ex.StackTrace), ex.StackTrace);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeUrl"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public static void AddSubSite(this SPSite site, string relativeUrl, string name, string description, uint lcid, string template = SPWebTemplate.WebTemplateSTS)
        {
            SPWeb newWebSite = null;

            try
            {
                using (newWebSite = site.AllWebs.Add(relativeUrl, name, description, lcid, template, false, false))
                {
                }
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("CORE:HELPERS", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, "Exception happened in Helpers:AddSubSite " + ex.Message, ex.StackTrace);
            }
            finally
            {
                if (newWebSite != null)
                    newWebSite.Dispose();
            }
        }
    }
