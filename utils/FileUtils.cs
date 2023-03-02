using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PgpsUtilsAEFC.utils
{
    /// <summary>
    /// This class provides a wide variety of methods for quick and easy writing/reading from files.
    /// </summary>
    public class FileUtils
    {
        
        /// <summary>
        /// Writes all the given data in bulk to the specified filepath.
        /// </summary>
        /// <param name="path">The filepath to dump the data into</param>
        /// <param name="data">A List(string) containing the lines to write into the file.</param>
        public static void DumpToFile(string path, List<string> data) => File.WriteAllLines(path, data.ToArray());

        /// <summary>
        /// Appends a given line to the end of the file.
        /// </summary>
        /// <param name="path">The filepath to append the data into</param>
        /// <param name="data">A string containing the line to write into the file.</param>
        public static void AppendToFile(string path, string data) => File.AppendAllLines(path, new[] { data });

        /// <summary>
        /// Reads all the lines from a file and returns them in the form of a list.
        /// </summary>
        /// <param name="path">The filepath to read the data from</param>
        /// <returns>A list containing all the lines in the file</returns>
        public static List<string> ReadFromFile(string path) => File.ReadAllLines(path).ToList().Select(x => x.Trim()).ToList();
        
        /// <summary>
        /// Writes all the given data in bulk, as binary information, into the specified filepath.
        /// </summary>
        /// <param name="path">The path to write into</param>
        /// <param name="data">The primitive values to write into the file.</param>
        public static void DumpToFileBinary(string path, List<string> data)
        {
            using (BinaryWriter s = new BinaryWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write)))
                data.ForEach(x => s.Write(x));
        }
        
        /// <summary>
        /// Reads the data in the specified filepath and returns it in the form of a list with
        /// all the values as strings.
        /// </summary>
        /// <param name="path">The filepath to read the data from</param>
        public static List<string> ReadFromFileBinary(string path)
        {
            List<string> values = new List<string>();

            using (BinaryReader s = new BinaryReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read)))
                while (s.PeekChar() != -1) values.Add(s.ReadString());

            return values;
        }
    }
}