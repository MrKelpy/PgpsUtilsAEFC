﻿using PgpsUtilsAEFC.utils;
using System.IO;
using System.Linq;
// ReSharper disable MemberCanBePrivate.Global

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
        protected string OperationsTargetPath { get; set; }

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
        /// <returns>The section that was just added</returns>
        public Section AddSection(string section)
        {
            string sectionPath = Path.Combine(OperationsTargetPath, section);
            FileUtils.EnsurePath(sectionPath, FileAttributes.Directory);
            return new Section(sectionPath);
        }

        /// <summary>
        /// Removes a section (Directory) from the file system.
        /// </summary>
        /// <param name="section">The relative path of the section, relative to the root.</param>
        public void RemoveSection(string section)
        {
            string sectionPath = Path.Combine(OperationsTargetPath, section);
            if (Directory.Exists(sectionPath)) Directory.Delete(sectionPath, true);
        }

        /// <summary>
        /// Recursively searches for every section in the file system, and returns an array containing them.
        /// </summary>
        /// <returns>A Section[] containing the Section objects representing the directories.</returns>
        public Section[] GetAllSections()
        {
            string[] allSections = Directory.GetDirectories(OperationsTargetPath, "*", SearchOption.AllDirectories);
            return allSections.ToList().Select(x => new Section(x)).ToArray();
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
        /// Adds a document into the current Section if it doesn't exist.
        /// </summary>
        /// <param name="documentName">The name of the document to add into the section</param>
        /// <returns>The path of the document that was just added</returns>
        public string AddDocument(string documentName)
        {
            string filepath = Path.Combine(OperationsTargetPath, documentName);
            FileUtils.EnsurePath(filepath, FileAttributes.Normal);
            return filepath;
        }

        /// <summary>
        /// Deletes a document from within a section, based on its relative path.
        /// </summary>
        /// <param name="documentName">The name of the document to remove from the section</param>
        public void RemoveDocument(string documentName)
        {
            string path = Path.Combine(OperationsTargetPath, documentName);
            if (File.Exists(path)) File.Delete(path);
        }

        /// <summary>
        /// Iterates over every item stemming from the relative root used, filters out the files
        /// and returns an array with their full paths.
        /// </summary>
        /// <returns>A string[] containing every file stemming down from the root</returns>
        public string[] GetAllFiles() => Directory.GetFiles(OperationsTargetPath, "*.*", SearchOption.AllDirectories);

            /// <summary>
        /// Iterates over all the files stemming from the relative root and returns every name matched file.
        /// </summary>
        /// <param name="filename">The filename to match with</param>
        /// <returns>A string[] with all the files that matched the filename</returns>
        public string[] GetFilesNamed(string filename) =>
            this.GetAllFiles().ToList().Where(x => Path.GetFileName(x).Equals(filename)).ToArray();

        /// <summary>
        /// Iterates over all the files stemming from the relative root and returns the first name matched file.
        /// </summary>
        /// <param name="filename">The filename to match with</param>
        /// <returns>A string containing the full path of the first matched file</returns>
        public string GetFirstFileNamed(string filename) =>
            this.GetAllFiles().ToList().FirstOrDefault(x => Path.GetFileName(x).Equals(filename));
    }
}