using V10_13News.News;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace DiscordNews
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Legacy.Tests.DefaultTest());
        }
    }
}