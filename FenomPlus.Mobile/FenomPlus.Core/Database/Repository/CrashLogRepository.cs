using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FenomPlus.Core.Database.Repository.Interfaces;
using FenomPlus.Core.Database.Tables;
using FenomPlus.Core.Models;

namespace FenomPlus.Core.Database.Repository
{
    public class CrashLogRepository : GenericRepository<CrashlogsTb>, ICrashlogsRepository
    {
        private static string TblName = "crashlog";

        public CrashLogRepository() : base(TblName)
        {
        }

        public CrashLogRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public CrashLogRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public CrashLogRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public async Task Insert(Exception ex, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            await Insert(new Crashlog(ex, callerFilePath, callerLineNumber, callerMemberName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerLineNumber"></param>
        /// <param name="callerMemberName"></param>
        /// <returns></returns>
        public async Task Insert(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "")
        {
            await Insert(new Crashlog(message, callerFilePath, callerLineNumber, callerMemberName));
        }

        /// <summary>
        /// Insert new crashlog
        /// </summary>
        /// <param name="crashlog"></param>
        /// <returns></returns>
        public async Task Insert(Crashlog crashlog)
        {
            CrashlogsTb crashLogTb = crashlog.Convert();
            try
            {
                if (crashlog != null)
                {
                    this.Collection.Insert(crashLogTb);
                }
            }
            catch (Exception ex)
            {
                IOC.Services.LogCat.Print(ex);
            }
        }

        /// <summary>
        /// return null if none found, now adaptor will return null model if table is null as well.
        /// </summary>
        /// <returns></returns>
        public async Task<CrashlogsTb> GetCrashlog()
        {
            CrashlogsTb crashlogsTb = this.Collection.FindOne(sr => sr.Uploaded == false);
            return await Task.FromResult<CrashlogsTb>(crashlogsTb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CrashlogsTb>> GetAllCrashlog(Expression<Func<CrashlogsTb, bool>> predicate = null)
        {
            List<CrashlogsTb> crashlogs = new List<CrashlogsTb>();
            IEnumerable<CrashlogsTb> crashlogsTbs = (predicate != null) ?
                this.Collection.Find(predicate) :
                this.Collection.FindAll();
            if (crashlogsTbs != null)
            {
                foreach (CrashlogsTb crashlogsTb in crashlogsTbs)
                {
                    crashlogs.Add(crashlogsTb);
                }
            }
            return await Task.FromResult<List<CrashlogsTb>>(crashlogs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crashlog"></param>
        /// <returns></returns>
        public async Task<CrashlogsTb> Update(Crashlog crashlog)
        {
            CrashlogsTb crashlogsTb = crashlog.Convert();
            if (crashlogsTb != null)
            {
                crashlogsTb.Uploaded = true;
                this.Collection.Update(crashlogsTb);
            }
            return await Task.FromResult<CrashlogsTb>(crashlogsTb);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crashlogsTb"></param>
        /// <returns></returns>
        public async Task<CrashlogsTb> Update(CrashlogsTb crashlogsTb)
        {
            if (crashlogsTb != null)
            {
                crashlogsTb.Uploaded = true;
                this.Collection.Update(crashlogsTb);
            }
            return await Task.FromResult<CrashlogsTb>(crashlogsTb);
        }
    }
}