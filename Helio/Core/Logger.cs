using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Core
{
    /// <summary>
    /// The different levels of the logger static class.
    /// The order is important because it's use to select which log should be write
    /// or not.
    /// </summary>
    public enum LoggerLevel
    {
        Test = 0,
        Trace,
        Info,
        Warn,
        Error,
        None,
    }

    public enum LoggerColor
    {
        Green,
        Red,
        Blue,
        
        Black,
        White,
        
        Yellow,
        Magenta,
        Cyan,
    }
    
    /// <summary>
    /// Writing infomations into the console for debugging only. In release mode
    /// everything is ignored.
    /// </summary>
    public static class Logger
    {
        private static LoggerLevel _level = LoggerLevel.Trace;

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
        public static void Test(object message, LoggerColor color = LoggerColor.Green)
        {
            ConsoleColor consoleColor = ConsoleColor.Green;
            switch (color)
            {
                case LoggerColor.Red:
                    consoleColor = ConsoleColor.Red;
                    break;
                case LoggerColor.Green:
                    consoleColor = ConsoleColor.Green;
                    break;
                case LoggerColor.Blue:
                    consoleColor = ConsoleColor.Blue;
                    break;

                case LoggerColor.Black:
                    consoleColor = ConsoleColor.Black;
                    break;
                case LoggerColor.White:
                    consoleColor = ConsoleColor.White;
                    break;

                case LoggerColor.Cyan:
                    consoleColor = ConsoleColor.Cyan;
                    break;
                case LoggerColor.Magenta:
                    consoleColor = ConsoleColor.Magenta;
                    break;
                case LoggerColor.Yellow:
                    consoleColor = ConsoleColor.Yellow;
                    break;

                default:
                    break;
            }
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"TESTS: {message}");
        }

        [Conditional("DEBUG")]
        public static void Trace(object message)
        {
            if (_level <= LoggerLevel.Trace)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"TRACE: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Info(object message)
        {
            if (_level <= LoggerLevel.Info)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"INFOS: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Warn(object message)
        {
            if (_level <= LoggerLevel.Warn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WARNG: {message}");
            }
        }

        [Conditional("DEBUG")]
        public static void Error(object message)
        {
            if (_level <= LoggerLevel.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {message}");
            }
        }
    }
}
