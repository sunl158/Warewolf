/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Wrappers;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace Dev2.Common.Wrappers
{ // not required for code coverage this is simply a pass through required for unit testing
    public class FileWrapper : IFile
    {
        public string ReadAllText(string fileName) => File.ReadAllText(fileName);

        public void Move(string source, string destination)
        {
            File.Move(source, destination);
        }

        public bool Exists(string path) => File.Exists(path);

        public void Delete(string tmpFileName)
        {
            File.Delete(tmpFileName);
        }

        public void WriteAllText(string p1, string p2)
        {
            File.WriteAllText(p1, p2);
        }

        public void Copy(string source, string destination)
        {
            File.Copy(source, destination);
        }

        public void WriteAllBytes(string path, byte[] contents)
        {
            File.WriteAllBytes(path, contents);
        }

        public void AppendAllText(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }

        public byte[] ReadAllBytes(string path) => File.ReadAllBytes(path);

        public FileAttributes GetAttributes(string path) => File.GetAttributes(path);

        public void SetAttributes(string path, FileAttributes fileAttributes)
        {
            File.SetAttributes(path, fileAttributes);
        }

        public Stream OpenRead(string path) => File.OpenRead(path);

        //readonly static ConcurrentDictionary<string, Lazy<RefCountedStreamWriter>> cache = new ConcurrentDictionary<string, Lazy<RefCountedStreamWriter>>()
        public IDev2StreamWriter AppendText(string filePath)
        {

            var result = new RefCountedStreamWriter(File.AppendText(filePath));
            return result;
        }

        public DateTime GetLastWriteTime(string filePath)
        {
            return File.GetLastWriteTime(filePath).Date;
        }
    }

    class RefCountedStreamWriter : IDev2StreamWriter
    {
        public int count;
        public StreamWriter StreamWriter { get; private set; }

        public RefCountedStreamWriter(StreamWriter writer)
        {
            this.StreamWriter = writer;
        }

        void IDev2StreamWriter.WriteLine(string v)
        {
            this.StreamWriter.WriteLine(v);
        }

        void IDev2StreamWriter.WriteLine()
        {
            this.StreamWriter.WriteLine();
        }

        void IDev2StreamWriter.Flush()
        {
            this.StreamWriter.Flush();
        }

        public void Dispose()
        {
            lock (this.StreamWriter)
            {
                Interlocked.Decrement(ref count);
            }
            if (count <= 0)
            {
                this.StreamWriter.Dispose();
            }
        }
    }
}