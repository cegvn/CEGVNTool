#region Namespaces

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Autodesk.Revit.DB;
using Newtonsoft.Json;

#endregion

namespace CEGVNTool
{
    public class Gen
    {
        /// <summary>
        ///     Get setting
        /// </summary>
        /// <typeparam name="T">Type of setting</typeparam>
        /// <param name="filePath">file name</param>
        /// <returns>T setting</returns>
        public static T GetSetting<T>(string filePath)
        {
            var setting = default(T);
            try
            {
                if (File.Exists(filePath))
                    using (var file = File.OpenText(filePath))
                    {
                        var serializer = new JsonSerializer();
                        setting = (T) serializer.Deserialize(file, typeof(T));
                    }
            }
            catch (Exception e)
            {

            }

            return setting;
        }

        /// <summary>
        ///     Get setting
        /// </summary>
        /// <typeparam name="T">Type of setting</typeparam>
        /// <param name="folder">folder name</param>
        /// <param name="fileName">file name</param>
        /// <returns>T setting</returns>
        public static T GetSetting<T>(string folder, string fileName)
        {
            var setting = default(T);
            var path = GetPath() + "\\CEGSetting";
            var path1 = path + "\\" + folder;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            if (!Directory.Exists(path1)) Directory.CreateDirectory(path1);
            var f = path1 + "\\" + fileName;
            if (File.Exists(f))
                using (var file = File.OpenText(f))
                {
                    var serializer = new JsonSerializer();
                    setting = (T) serializer.Deserialize(file, typeof(T));
                }

            return setting;
        }

        /// <summary>
        ///     Save setting
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="setting">class to save</param>
        /// <param name="filePath">file name</param>
        public static void SaveSetting<T>(T setting, string filePath)
        {
            // save setting)
            var s = string.Empty;
            s = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(filePath, s);
        }

        /// <summary>
        ///     Save setting
        /// </summary>
        /// <typeparam name="T">class</typeparam>
        /// <param name="setting">class to save</param>
        /// <param name="folder">folder name</param>
        /// <param name="fileName">file name</param>
        public static void SaveSetting<T>(T setting, string folder, string fileName)
        {
            var path = GetPath() + "\\CEGSetting" + "\\" + folder;
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            var f = path + "\\" + fileName;
            // save setting)
            var s = string.Empty;
            s = JsonConvert.SerializeObject(setting, Formatting.Indented);
            File.WriteAllText(f, s);
        }

        /// <summary>
        ///     Path for setting file: C:\Users\Home\AppData\Roaming\CEGCustomMenu
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = path + "\\CEGCustomMenu";
            return path;
        }

        /// <summary>
        ///     Path for setting file: C:\Users\Home\AppData\Roaming\CEGCustomMenu\CEGSetting
        /// </summary>
        /// <returns></returns>
        public static string GetSettingPath()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = path + "\\CEGCustomMenu\\CEGSetting";
            return path;
        }

        // Function to write txt file
        public static void WriteToTxtFile(string textFile, IList<string> texts)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = path + "\\" + textFile + ".txt";
            using (var file =
                new StreamWriter(path, false))
            {
                foreach (var text in texts) file.WriteLine(text);
            }
        }

        public static void WriteToTxtFile(string path, string textFile, IList<string> texts)
        {
            var fileName = path + "\\" + textFile + ".txt";
            using (var file =
                new StreamWriter(fileName, false))
            {
                foreach (var text in texts) file.WriteLine(text);
            }
        }

        public static void WriteToTxtFile(string path, string textFile, IList<int> ints)
        {
            var fileName = path + "\\" + textFile + ".txt";
            using (var file =
                new StreamWriter(fileName, false))
            {
                foreach (var i in ints) file.WriteLine(i.ToString());
            }
        }

        // Function to write txt file
        public static void WriteToTxtFile(string textFile, string text)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            path = path + "\\" + textFile + ".txt";
            using (var file =
                new StreamWriter(path, true))
            {
                file.WriteLine(text);
            }
        }

        public static void WriteToTxtFile(string path, string textFile, string text)
        {
            var fileName = path + "\\" + textFile;
            using (var file =
                new StreamWriter(fileName, true))
            {
                file.WriteLine(text);
            }
        }

        // Function to write a list of familyinstance
        public static void WriteListFamily(string textFile, List<FamilyInstance> instances)
        {
            foreach (var instance in instances)
            {
                if (instance.LookupParameter("CONTROL_MARK") == null) continue;
                var text = instance.Id + "-" + instance.LookupParameter("CONTROL_MARK").AsString();
                WriteToTxtFile(textFile, text);
            }
        }

        public static Image GetResourcesImage(string name)
        {
            var folderPath = Environment.ExpandEnvironmentVariables("%ProgramW6432%") +
                             "\\Autodesk\\CEGCustomMenu\\Resources\\";
            var filePath = folderPath + name;
            if (File.Exists(filePath)) return new Bitmap(filePath);
            return null;
        }

        public static void RunUpdate()
        {
            // Prepare the process to run
            ProcessStartInfo start = new ProcessStartInfo();
            // Enter in the command line arguments, everything you would enter after the executable name itself
            //start.Arguments = arguments;
            // Enter the executable to run, including the complete path
            start.FileName = @"C:\Users\CEG User\Desktop\Test\AutoUpdater\CegAutoUpdater.exe";
            // Do you want to show a console window?
            start.WindowStyle = ProcessWindowStyle.Normal;
            start.CreateNoWindow = true;
            int exitCode;


            // Run the external process & wait for it to finish

            using (Process proc = Process.Start(start))
            {
                //proc.
                proc.WaitForExit();

                // Retrieve the app's exit code
                exitCode = proc.ExitCode;
            }
        }
    }

    public interface ICegSetting
    {
        /// <summary>
        ///     Get full folder path
        /// </summary>
        /// <returns>folder path</returns>
        string GetFolderPath();

        /// <summary>
        ///     Get file name
        /// </summary>
        /// <returns>File name</returns>
        string GetFileName();

        /// <summary>
        ///     Get full file name path
        /// </summary>
        /// <returns>File name path</returns>
        string GetFullFileName();

        /// <summary>
        ///     Save setting
        /// </summary>
        void SaveSetting();
    }
}