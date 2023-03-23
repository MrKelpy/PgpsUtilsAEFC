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
    /// <remarks>
    /// This class should probably be implemented making use of either dependency injection or singletons.
    /// </remarks>
    /// </summary>
    public class FileManager : AbstractBaseOperations
    {
        private string RootPath { get; set; }

        /// <summary>
        /// Main constructor for the FileManager class. Sets the root path.
        /// </summary>
        /// <param name="root">The path to the root directory of the file system.</param>
        public FileManager(string root = null) : base(root)
        {
            // If the root isn't specified, use the AppData/.PROGRAM-NAME folder.
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            RootPath = root ?? Path.Combine(appDataPath, $".{Assembly.GetCallingAssembly().GetName().Name}");
            FileUtils.EnsurePath(root);
        }
    }
}