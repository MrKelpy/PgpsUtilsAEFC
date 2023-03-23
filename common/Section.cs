﻿using System.IO;
using PgpsUtilsAEFC.common.abstraction;

namespace PgpsUtilsAEFC.common
{
    /// <summary>
    /// This class represents a Section inside the File System provided by the FileManager class. It can't
    /// be instantiated by the user, and will only be accessible through the FileManager.
    /// </summary>
    public class Section : AbstractBaseOperations
    {
        /// <summary>
        /// The full path for the section.
        /// </summary>
        public string SectionFullPath { get; set; }

        /// <summary>
        /// The section name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Main constructor for the Section class. Takes in the root of the file system and the full
        /// path of the section.
        /// </summary>
        /// <param name="sectionPath">The full path of the section.</param>
        internal Section(string sectionPath) : base(sectionPath)
        {
            this.SectionFullPath = sectionPath;
            this.Name = Path.GetDirectoryName(sectionPath);
        }

        /// <summary>
        /// Remove the current section from the file system, and invalidates the current class.
        /// </summary>
        public void Delete()
        {
            Directory.Delete(this.SectionFullPath, true);
            this.SectionFullPath = this.Name = null;
        }
    }
}