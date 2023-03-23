using PgpsUtilsAEFC.utils;
using System.IO;
using System.Linq;

namespace PgpsUtilsAEFC.common.abstraction
{
    /// <summary>
    /// This abstract class implements every method that is used by both the FileManager and Section classes,
    /// due to a similarity in functionality.
    /// </summary>
    public class AbstractBaseOperations
    {
        /// <summary>
        /// The target path to perform these operations on. This will act as the "root" of all operations.
        /// </summary>
        private string OperationsTargetPath { get; set; }

        /// <summary>
        /// Main constructor for the AbstractBaseOperations class. Defines the
        /// operations target path.
        /// </summary>
        /// <param name="operationsTargetPath">@link{AbstractBaseOperations.OperationsTargetPath}</param>
        internal AbstractBaseOperations(string operationsTargetPath) => this.OperationsTargetPath = operationsTargetPath;

        /// <summary>
        /// Adds a new section (Directory) into the file system.
        /// </summary>
        /// <param name="section">The relative path of the section, relative to the root.</param>
        public void AddSection(string section)
        {
            string sectionPath = Path.Combine(OperationsTargetPath, section);
            if (!File.Exists(sectionPath)) Directory.CreateDirectory(sectionPath);
        }

        /// <summary>
        /// Removes a section (Directory) from the file system.
        /// </summary>
        /// <param name="section">The relative path of the section, relative to the root.</param>
        public void RemoveSection(string section)
        {
            string sectionPath = Path.Combine(OperationsTargetPath, section);
            if (File.Exists(sectionPath)) Directory.Delete(sectionPath, true);
        }

        /// <summary>
        /// Recursively searches for every section in the file system, and returns an array containing them.
        /// </summary>
        /// <returns>A Section[] containing the Section objects representing the directories.</returns>
        public Section[] GetAllSections()
        {
            string[] allFiles = Directory.GetFiles(OperationsTargetPath, "*.*", SearchOption.AllDirectories);
            return allFiles.ToList().Where(Directory.Exists).Select(x => new Section(x)).ToArray();
        }

        /// <summary>
        /// Gets all the sections (Directories) in the file system, and returns the ones matching
        /// the specified name.
        /// </summary>
        /// <param name="name">The name of the sections to search for.</param>
        /// <returns>A Section[] containing the objects representing each directory in the file system.</returns>
        public Section[] GetSectionsNamed(string name) =>
            this.GetAllSections().ToList().Where(x => x.Name == name).ToArray();

        /// <summary>
        /// Gets all the sections (Directories) in the file system, and returns the first one with a matching name.
        /// </summary>
        /// <param name="name">The name of the sections to search for.</param>
        /// <returns>A Section object representing the directory in the file system.</returns>
        public Section GetFirstSectionNamed(string name) =>
            this.GetAllSections().ToList().FirstOrDefault(x => x.Name == name);

        /// <summary>
        /// Returns a section based on the relative path provided, relative to the root.
        /// </summary>
        /// <param name="path">The relative path to the section from the root</param>
        /// <returns>The Section object</returns>
        public Section GetSectionFromPath(string path)
        {
            string sectionPath = Path.Combine(OperationsTargetPath, path);
            FileUtils.EnsurePath(sectionPath);
            return new Section(path);
        }

        /// <summary>
        /// Adds a document into the current Section.
        /// </summary>
        /// <param name="documentName">The name of the document to add into the section</param>
        public void AddDocument(string documentName) => 
            File.Create(Path.Combine(OperationsTargetPath, documentName));

        /// <summary>
        /// Deletes a document from within a section, based on its relative path.
        /// </summary>
        /// <param name="documentName">The name of the document to remove from the section</param>
        public void RemoveDocument(string documentName) =>
            File.Delete(Path.Combine(OperationsTargetPath, documentName));

        /// <summary>
        /// Iterates over every item stemming from the relative root used, filters out the files
        /// and returns an array with their full paths.
        /// </summary>
        /// <returns>A string[] containing every file stemming down from the root</returns>
        public string[] GetAllFiles()
        {
            string[] allFiles = Directory.GetFiles(OperationsTargetPath, "*.*", SearchOption.AllDirectories);
            return allFiles.ToList().Where(File.Exists).ToArray();
        }

        /// <summary>
        /// Iterates over all the files stemming from the relative root and returns every name matched file.
        /// </summary>
        /// <param name="filename">The filename to match with</param>
        /// <returns>A string[] with all the files that matched</returns>
        public string[] GetFilesNamed(string filename) =>
            this.GetAllFiles().ToList().Where(x => x == filename).ToArray();

        /// <summary>
        /// Iterates over all the files stemming from the relative root and returns the first name matched file.
        /// </summary>
        /// <param name="filename">The filename to match with</param>
        /// <returns>A string containing the full path of the first matched file</returns>
        public string GetFirstFileNamed(string filename) =>
            this.GetAllFiles().ToList().FirstOrDefault(x => x == filename);
    }
}