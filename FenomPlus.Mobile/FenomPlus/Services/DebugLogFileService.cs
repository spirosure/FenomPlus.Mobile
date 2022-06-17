using System;
using System.IO;
using FenomPlus.Interfaces;

namespace FenomPlus.Services
{
    public class DebugLogFileService : BaseService, IDebugLogFileService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public DebugLogFileService(IAppServices services) : base(services)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Write(string msg)
        {
            using (var writer = File.CreateText(CreateFileName()))
            {
                writer.WriteLine(msg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Write(byte[] msg)
        {
            using (var writer = File.CreateText(CreateFileName()))
            {
                writer.WriteLine(msg);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string CreateFileName()
        {
            string debugFilename = DateTime.Now.ToShortDateString().Replace("/", "").Replace(",", "").Replace(" ", "");
            debugFilename = string.Format("debug_{0}.txt", debugFilename);
            debugFilename = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, debugFilename);
            Services.LogCat.Print(debugFilename);
            return debugFilename;
        }
    }
}
