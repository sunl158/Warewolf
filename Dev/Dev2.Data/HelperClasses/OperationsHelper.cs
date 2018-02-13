﻿using Dev2.Data.Interfaces;
using System;
using System.IO;

namespace Dev2.Data.HelperClasses
{
    public static class OperationsHelper
    {        
        public static bool FileExist(IActivityIOPath path) => File.Exists(path.Path);
        public static string ExtractUserName(IPathAuth path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            var idx = path.Username.IndexOf("\\", StringComparison.Ordinal);
            var result = idx > 0 ? path.Username.Substring(idx + 1) : path.Username;
            return result;
        }

        public static string ExtractDomain(IActivityIOPath path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
            var result = string.Empty;

            var idx = path.Username.IndexOf("\\", StringComparison.Ordinal);

            if (idx > 0)
            {
                result = path.Username.Substring(0, idx);
            }

            return result;
        }
    }
}
