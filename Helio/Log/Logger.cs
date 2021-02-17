using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Log
{
    /// <summary>
    /// The different levels of the logger static class.
    /// The order is important because it's use to select which log should be write
    /// or not.
    /// </summary>
    public enum LoggerLevel
    {
        Trace = 0,
        Info = 1,
        Warn = 2,
        Error = 3,
        None = 4
    }
    
    /// <summary>
    /// Writing infomations into the console for debugging only. In release mode
    /// everything is ignored.
    /// </summary>
    public static class Logger
    {
        private static LoggerLevel _level = LoggerLevel.Error;

        /// <summary>
        /// You can define the minimum level required by the logger to 
        /// ouput the data in the console.
        /// </summary>
        /// <param name="level">enum that allow you to control the log output</param>
        [Conditional("DEBUG")]
        public static void SetLevel(LoggerLevel level)
        {
            _level = level;
        }

        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
            if (_level <= LoggerLevel.Trace)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"TRACE: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            if (_level <= LoggerLevel.Info)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"INFOS: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Warn(string message)
        {
            if (_level <= LoggerLevel.Warn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNG: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            if (_level <= LoggerLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {message}");
            }
        }
    }
}
