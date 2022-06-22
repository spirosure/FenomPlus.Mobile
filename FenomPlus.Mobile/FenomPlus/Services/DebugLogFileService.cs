/// adb -d shell "run-as com.caireinc.fenomplus ls -l /data/data/com.caireinc.fenomplus/files/.local/share/*"
/// adb -d shell "run-as com.caireinc.fenomplus cat /data/data/com.caireinc.fenomplus/files/.local/share/debug_6222022.txt"
/// adb -d shell "run-as com.caireinc.fenomplus rm /data/data/com.caireinc.fenomplus/files/.local/share/debug_6222022.txt"
using System;
using System.IO;
using System.Threading.Tasks;
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
            string LocalFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Services.LogCat.Print(LocalFolder);

            // make sure file
            string FileName = string.Format("debug_{0}.txt", DateTime.Now.ToShortDateString().Replace("/", "").Replace(",", "").Replace(" ", ""));
            Services.LogCat.Print(FileName);

            // Use Combine so that the correct file path slashes are used
            string filePath = Path.Combine(LocalFolder, FileName);
            
            File.AppendAllText(filePath, msg);
            File.AppendAllText(filePath, "\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void Write(byte[] msg)
        {
            Write(BitConverter.ToString(msg));
        }
    }
}
