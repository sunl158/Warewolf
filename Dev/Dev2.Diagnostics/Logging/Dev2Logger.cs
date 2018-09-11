/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace Dev2.Common
{
    public static class Dev2Logger
    {
        static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Debug(object message, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Debug(customMessage);
        }

        public static void Debug(object message, Exception exception, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Debug(customMessage, exception);
        }

        public static void Error(object message, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Error(customMessage);
        }

        public static void Error(object message, Exception exception, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Error(customMessage, exception);

        }

        public static void Warn(object message, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Warn(customMessage);
        }

        public static void Warn(object message, Exception exception, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Warn(customMessage, exception);

        }

        public static void Fatal(object message, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Fatal(customMessage);
        }

        public static void Fatal(object message, Exception exception, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Fatal(customMessage, exception);
        }

        public static void Info(object message, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Info(customMessage);
        }

        public static void Info(object message, Exception exception, string executionId)
        {
            var customMessage = UpdateCustomMessage(message, executionId);
            _log.Info(customMessage, exception);
        }

        static string UpdateCustomMessage(object message, string executionId) => $"[{executionId}] - {message}";

        public static void UpdateLoggingConfig(string level)
        {

            var repository = LogManager.GetAllRepositories().First();
            repository.Threshold = repository.LevelMap[level];
            var hier = (Hierarchy)repository;
            var loggers = hier.GetCurrentLoggers();
            foreach (var logger in loggers)
            {
                ((Logger)logger).Level = hier.LevelMap[level];
            }
            var h = (Hierarchy)LogManager.GetRepository();
            var rootLogger = h.Root;
            rootLogger.Level = h.LevelMap[level];
        }

        public static string GetFileLogLevel()
        {
            var h = (Hierarchy)LogManager.GetRepository();
            var rootLogger = h.Root;
            return rootLogger.Level.DisplayName;
        }
        public static string GetEventLogLevel()
        {
            var h = (Hierarchy)LogManager.GetRepository();
            var rootLogger = h.Root;

            if (rootLogger?.GetAppender("EventLogLogger") is EventLogAppender appender && appender.Threshold != null)
            {
                return appender.Threshold.DisplayName;
            }
            return "";
        }

        public static int GetLogMaxSize()
        {
            var h = (Hierarchy)LogManager.GetRepository();
            var rootLogger = h.Root;
            if (rootLogger.GetAppender("LogFileAppender") is RollingFileAppender appender)
            {
                var logSize = appender.MaxFileSize / 1024 / 1024;
                return (int)Math.Round((decimal)logSize, 0);
            }
            return 0;
        }

        public static string GetAuditsFilePath()
        {
            var h = (Hierarchy)LogManager.GetRepository();
            var rootLogger = h.Root;

            if (rootLogger?.GetAppender("Audits") is FileAppender appender)
            {
                return appender.File;
            }
            return "";
        }

        public static void UpdateFileLoggerToProgramData(string settingsConfigFile)
        {
            var settingsDocument = XDocument.Load(settingsConfigFile);
            var log4netElement = settingsDocument.Element("log4net");
            if (log4netElement != null)
            {
                var appenderElements = log4netElement.Elements("appender");
                var appenders = appenderElements as IList<XElement> ?? appenderElements.ToList();
                var fileAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "LogFileAppender");
                var fileElement = fileAppender?.Element("file");
                if (fileElement != null)
                {
                    var valueAttrib = fileElement.Attribute("value");
                    if (valueAttrib != null)
                    {
                        valueAttrib.SetValue("%envFolderPath{CommonApplicationData}\\Warewolf\\Server Log\\wareWolf-Server.log");
                        settingsDocument.Save(settingsConfigFile);
                    }
                }
                var layoutElement = fileAppender?.Element("layout");
                if (layoutElement != null)
                {
                    UpdateConversionPattern(settingsConfigFile, settingsDocument, layoutElement);
                }
                var eventLogAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "EventLogLogger");
                var eventLayoutElement = eventLogAppender?.Element("layout");
                if (eventLayoutElement != null)
                {
                    UpdateConversionPattern(settingsConfigFile, settingsDocument, eventLayoutElement);
                }

                var auditLogAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "Audits");

                var auditsElement = auditLogAppender?.Element("file");
                var valuesAttrib = auditsElement?.Attribute("value");
                if (valuesAttrib != null)
                {
                    valuesAttrib.SetValue(Path.Combine(EnvironmentVariables.AppDataPath, "Audits\\"));
                    settingsDocument.Save(settingsConfigFile);
                }

            }
        }

        static void UpdateConversionPattern(string settingsConfigFile, XDocument settingsDocument, XElement layoutElement)
        {
            var conversionPatternElement = layoutElement.Element("conversionPattern");
            if (conversionPatternElement != null)
            {
                var valueAttrib = conversionPatternElement.Attribute("value");
                if (valueAttrib != null)
                {
                    valueAttrib.SetValue("%date %-5level - %message%newline");
                    settingsDocument.Save(settingsConfigFile);
                }
            }
        }

        public static void WriteLogSettings(string maxLogSize, string fileLogLevel, string eventLogLevel, string settingsConfigFile, string applicationNameForEventLog, string auditsFilePath)
        {
            var settingsDocument = XDocument.Load(settingsConfigFile);
            var log4netElement = settingsDocument.Element("log4net");
            if (log4netElement != null)
            {
                var appenderElements = log4netElement.Elements("appender");
                var appenders = appenderElements as IList<XElement> ?? appenderElements.ToList();
                UpdateFileSizeForFileLogAppender(maxLogSize, appenders);

                var eventAppender = appenders.FirstOrDefault(element => element.Attribute("type").Value == "log4net.Appender.EventLogAppender");
                var rootElement = log4netElement.Element("root");
                if (eventAppender == null)
                {
                    ConfigureEventLoggerAppender(applicationNameForEventLog, eventLogLevel, rootElement);
                }
                SetupLogLevels(fileLogLevel, eventLogLevel, rootElement, eventAppender);

                var auditsEventAppender = appenders.FirstOrDefault(element => element.Attribute("type").Value == "log4net.Appender.FileAppender");
                rootElement = log4netElement.Element("root");
                if (auditsEventAppender == null)
                {
                    ConfigureAuditsAppender(auditsFilePath, rootElement);
                }
                else
                {
                    var fileElement = auditsEventAppender.Element("file");
                    var valueAttrib = fileElement.Attribute("value");
                    if (valueAttrib != null)
                    {
                        valueAttrib.SetValue(auditsFilePath);
                    }
                }
                settingsDocument.Save(settingsConfigFile);
            }
        }


        public static void AddEventLogging(string settingsConfigFile, string applicationNameForEventLog)
        {
            var settingsDocument = XDocument.Load(settingsConfigFile);
            var log4netElement = settingsDocument.Element("log4net");
            if (log4netElement != null)
            {
                var appenderElements = log4netElement.Elements("appender");
                var appenders = appenderElements as IList<XElement> ?? appenderElements.ToList();

                var eventAppender = appenders.FirstOrDefault(element => element.Attribute("type").Value == "log4net.Appender.EventLogAppender");
                if (eventAppender == null)
                {

                    var fileAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "LogFileAppender");
                    ConfigureEventLoggerAppender(applicationNameForEventLog, "ERROR", fileAppender);
                    var rootElement = log4netElement.Element("root");
                    AddEventLogLogger(rootElement);
                    settingsDocument.Save(settingsConfigFile);
                }
                var auditsAppender = appenders.FirstOrDefault(element => element.Attribute("type").Value == "log4net.Appender.FileAppender");
                if (auditsAppender == null)
                {
                    var faAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "LogFileAppender");
                    var fileAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "Audits");
                    if (fileAppender == null)
                    {
                        ConfigureAuditsAppender(Path.Combine(EnvironmentVariables.AppDataPath, "Audits\\"), faAppender);
                        var rootElement = log4netElement.Element("root");
                        AddAuditLogger(rootElement);
                        settingsDocument.Save(settingsConfigFile);
                    }
                }
            }
        }

        static void UpdateFileSizeForFileLogAppender(string maxLogSize, IList<XElement> appenders)
        {

            var fileAppender = appenders.FirstOrDefault(element => element.Attribute("name").Value == "LogFileAppender");
            var maxFileSizeElement = fileAppender?.Element("maximumFileSize");
            var maxFileSizeElementValueAttrib = maxFileSizeElement?.Attribute("value");
            if (maxFileSizeElementValueAttrib != null)
            {
                maxFileSizeElementValueAttrib.Value = maxLogSize + "MB";
            }
        }

        static void SetupLogLevels(string fileLogLevel, string eventLogLevel, XElement rootElement, XElement log4netElement)
        {
            if (rootElement != null)
            {
                SetLogLogLevel(fileLogLevel, rootElement);
            }
            var eventLogElement = log4netElement.Element("threshold");
            if (eventLogElement != null)
            {
                SetEventLogLogLevel(eventLogLevel, eventLogElement);
            }
            else
            {
                AddEventLogLogger(log4netElement);
            }
        }

        static void SetLogLogLevel(string eventLogLevel, XElement eventLogElement)
        {

            var levelElement = eventLogElement.Element("level");
            var levelElementValueAttrib = levelElement?.Attribute("value");
            if (levelElementValueAttrib != null)
            {
                levelElementValueAttrib.Value = eventLogLevel;
            }
        }

        static void SetEventLogLogLevel(string eventLogLevel, XElement eventLogElement)
        {

            eventLogElement.SetAttributeValue("value", eventLogLevel);
        }

        static void AddEventLogLogger(XElement rootElement)
        {
            rootElement.Add(new XElement("appender-ref", new XAttribute("ref", "EventLogLogger")));
        }
        static void AddAuditLogger(XElement rootElement)
        {
            rootElement.Add(new XElement("appender-ref", new XAttribute("ref", "Audits")));
        }

        static void ConfigureEventLoggerAppender(string applicationNameForEventLog, string logLevel, XElement element)
        {
            var eventAppenderElement = new XElement("appender");
            eventAppenderElement.SetAttributeValue("name", "EventLogLogger");
            eventAppenderElement.SetAttributeValue("type", "log4net.Appender.EventLogAppender");
            eventAppenderElement.Add(new XElement("threshold", new XAttribute("value", logLevel)));
            eventAppenderElement.Add(GetMappingElement("ERROR", "Error"));
            eventAppenderElement.Add(GetMappingElement("DEBUG", "Information"));
            eventAppenderElement.Add(GetMappingElement("INFO", "Information"));
            eventAppenderElement.Add(GetMappingElement("WARN", "Warning"));

            var logNameElement = new XElement("logName");
            logNameElement.SetAttributeValue("value", "Warewolf");
            eventAppenderElement.Add(logNameElement);
            var applicationNameElement = new XElement("applicationName");
            applicationNameElement.SetAttributeValue("value", applicationNameForEventLog);
            eventAppenderElement.Add(applicationNameElement);
            var layoutElement = new XElement("layout");
            layoutElement.SetAttributeValue("type", "log4net.Layout.PatternLayout");
            var conversionPattenElement = new XElement("conversionPattern");
            conversionPattenElement.SetAttributeValue("value", "%date [%thread] %-5level - %message%newline");
            layoutElement.Add(conversionPattenElement);
            eventAppenderElement.Add(layoutElement);
            element.AddAfterSelf(eventAppenderElement);
        }

        static void ConfigureAuditsAppender(string auditsFilePath, XElement element)
        {
            var eventAppenderElement = new XElement("appender");
            eventAppenderElement.SetAttributeValue("name", "Audits");
            eventAppenderElement.SetAttributeValue("type", "log4net.Appender.FileAppender");


            var auditsFilePathElement = new XElement("file");
            auditsFilePathElement.SetAttributeValue("value", auditsFilePath);
            eventAppenderElement.Add(auditsFilePathElement);

            element.AddAfterSelf(eventAppenderElement);
        }

        static XElement GetMappingElement(string levelValue, string eventLogType)
        {
            var errorMappingElement = new XElement("mapping");
            errorMappingElement.Add(new XElement("level", new XAttribute("value", levelValue)));
            errorMappingElement.Add(new XElement("eventLogEntryType", new XAttribute("value", eventLogType)));
            return errorMappingElement;
        }
    }
}
