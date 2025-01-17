#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;
using Dev2.Common;

namespace Dev2.Runtime.Configuration
{
    public interface ISettingsProvider
    {
        Settings.Configuration Configuration { get; }
    }
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Do NOT instantiate directly - use static <see cref="Instance" /> property instead; use for testing only!
    /// </summary>
    public class SettingsProvider : ISettingsProvider
    {
        public static string WebServerUri { get; set; }

        // Multi-threaded implementation - see http://msdn.microsoft.com/en-us/library/ff650316.aspx
        // This approach ensures that only one instance is created and only when the instance is needed. 
        // Also, the variable is declared to be volatile to ensure that assignment to the instance variable
        // completes before the instance variable can be accessed. Lastly, this approach uses a syncRoot 
        // instance to lock on, rather than locking on the type itself, to avoid deadlocks.
        static volatile SettingsProvider _instance;
        static readonly object SyncRoot = new Object();

        public static SettingsProvider Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(SyncRoot)
                    {
                        if(_instance == null)
                        {
                            _instance = new SettingsProvider();
                        }
                    }
                }
                return _instance;
            }
        }
     
        /// <summary>
        /// Do NOT instantiate directly - use static <see cref="Instance" /> property instead;
        /// </summary>
        public SettingsProvider()
        {
            AssemblyHashCode = GetAssemblyHashCode();
            Configuration = ReadConfiguration();
        }

        public string AssemblyHashCode { get; private set; }

        public Settings.Configuration Configuration { get; private set; }
       
        static string GetAssemblyHashCode()
        {
            var assemblyBytes = GetAssemblyBytes();

            var hashAlgorithm = SHA256.Create();
            var hash = hashAlgorithm.ComputeHash(assemblyBytes);
            var hex = BitConverter.ToString(hash).Replace("-", string.Empty);

            return hex;
        }

        static byte[] GetAssemblyBytes()
        {
            var assembly = Assembly.GetAssembly(typeof(IConfigurationAssemblyMarker));
            return File.ReadAllBytes(assembly.Location);
        }

        public static string GetFilePath()
        {
            var rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Path.Combine(rootDir, "Settings", "Application.xml");
        }

        Settings.Configuration ReadConfiguration()
        {
            var filePath = GetFilePath();
            if(File.Exists(filePath))
            {
                try
                {
                    var xml = XElement.Load(filePath);
                    xml.SetAttributeValue("WebServerUri", WebServerUri);
                    return new Settings.Configuration(xml);
                }
                catch(Exception ex)                
                {
                    Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                }
            }
            return new Settings.Configuration(WebServerUri);
        }
    }
}
