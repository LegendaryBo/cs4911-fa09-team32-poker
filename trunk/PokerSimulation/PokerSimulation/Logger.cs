using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PokerSimulation
{
    public class Logger
    {
        private static string _logPath = @"poker.log";
        private static StreamWriter _logStream;
        private static Logger _instance = null;

        private StreamWriter Log
        {
            get
            {
                if (_logStream == null)
                {
                    try
                    {
                        // open/create the file, and set writes to append
                        // change the boolean argument to false if a new log should be created
                        _logStream = new StreamWriter(LogPath, false);
                        _logStream.AutoFlush = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Exception:\n" + e);
                        return null;
                    }
                }
                
                return _logStream;
            }
            set
            {
                _logStream = value;
            }
        }
        public string LogPath
        {
            get
            {
                return _logPath;
            }
            set
            {
                _logPath = value;
            }
        }
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        private Logger()
        {
            // get the log path setting from the config file
            string storedPath = Properties.Settings.Default.LogPath;

            // if the stored log path isn't an empty string, use it instead of the
            // hard-coded default
            if (storedPath.Length > 0)
            {
                LogPath = storedPath;
            }
        }
        
        /// <summary>
        /// Writes a string to the end of the log file.
        /// </summary>
        /// <param name="someString">
        /// The string to append to the log file.
        /// </param>
        /// <returns>
        /// the string written to the log file, or null if the string couldn't be written
        /// </returns>
        public string Write(string someString)
        {
            string newString = DateTime.Now + "\t" + someString;
            Log.WriteLine(newString);

            return newString;
        }

        public string WriteCritical(string someString)
        {
            return Write("CRITICAL:\t" + someString);
        }

        public string WriteInfo(string someString)
        {
            return Write("INFO:\t" + someString);
        }

        public string WriteError(string someString)
        {
            return Write("ERROR:\t" + someString);
        }

        /// <summary>
        /// Print the log file to the console.
        /// </summary>
        /// <returns>
        /// a string containing the contents of the log file
        /// </returns>
        public string Print()
        {
            CloseLogFile();

            using (StreamReader sr = new StreamReader(LogPath))
            {
                StringBuilder sb = new StringBuilder();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    sb.AppendLine(line);
                    Console.WriteLine(line);
                }

                return sb.ToString();
            }
        }

        public void MakeNewLog()
        {
            CloseLogFile();
            DeleteFile(LogPath);
        }

        private void SetWriteFile(string logPath)
        {
            LogPath = logPath;
            CloseLogFile();
        }

        public void CloseLogFile()
        {
            if (_logStream != null)
            {
                _logStream.Flush();
                _logStream.Close();
            }
            _logStream = null;
        }

        private void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
