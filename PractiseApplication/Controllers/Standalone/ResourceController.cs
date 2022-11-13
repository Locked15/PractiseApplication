using System;
using System.IO;
using System.Linq;

namespace PractiseApplication.Controllers.Standalone
{
    /// <summary>
    /// Resource controller (helper) class.
    /// It allows to get (or set) some information about resources of this project.
    /// </summary>
    class ResourceController
    {
        /// <summary>
        /// Gets current working directory and go upper, until found target directory with project home.
        /// It REQUIRES original project structure and if it corrupted, this one will throw an exceptions.
        /// <br />
        /// Especially, it requires "Resources" directory, cause it placed inside "Resource" controller.
        /// May be useful, if you need to create Uri object.
        /// </summary>
        /// <returns>Absolute path to project home directory.</returns>
        /// <exception cref="Exception">Project structure has been corrupted.</exception>
        public static string GetProjectDirectory()
        {
            string path = Environment.CurrentDirectory;
            while (!Directory.GetDirectories(path).Any(dir => dir.EndsWith("Resources")))
            {
                path = Directory.GetParent(path)?.FullName ?? throw new Exception("Project structure has been corrupted.");
            }

            return path;
        }
    }
}
