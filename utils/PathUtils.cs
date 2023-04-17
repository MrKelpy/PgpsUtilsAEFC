using System.IO;

namespace PgpsUtilsAEFC.utils
{
    /// <summary>
    /// This class aims to provide a set of utilities to work with paths.
    /// </summary>
    public static class PathUtils
    {
        
        /// <summary>
        /// Normalizes a path, changing it to a common format.
        /// Every path should be formatted as such.: "path/to/directory"
        /// </summary>
        /// <param name="path">The path to normalize.</param>
        /// <returns>The normalized path.</returns>
        public static string NormalizePath(string path)
        {
            path = path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            path = path.Replace("\\", @"/");
            path = path.Replace(@"\", @"/");
            path = path.Replace(@"/./", @"/");
            return path;
        }
    }
}