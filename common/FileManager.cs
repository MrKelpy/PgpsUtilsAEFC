using System;
using System.IO;
using System.Linq;
using System.Reflection;
using PgpsUtilsAEFC.common.abstraction;
using PgpsUtilsAEFC.utils;

namespace PgpsUtilsAEFC.common
{
    /// <summary>
    /// This class implements an interface to interact with a program's file structure
    /// in a more convenient way.
    /// </summary>
    public class FileManager : AbstractBaseOperations
    {
        /// <summary>
        /// The root path of the file system.
        /// </summary>
        private string RootPath { get; set; }
    
        /// <summary>
        /// Main constructor for the FileManager class. Sets the root path to the specified value.
        /// If not specified, use the AppData/.PROGRAM-NAME folder.
        /// </summary>
        /// <param name="root">The path to the root directory of the file system.</param>
        public FileManager(string root = null) : base(root)
        {
            // If the root isn't specified, use the AppData/.PROGRAM-NAME folder.
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            RootPath = root ?? Path.Combine(appDataPath, $".{Assembly.GetCallingAssembly().GetName().Name}");
            FileUtils.EnsurePath(RootPath);
        }
    }
}