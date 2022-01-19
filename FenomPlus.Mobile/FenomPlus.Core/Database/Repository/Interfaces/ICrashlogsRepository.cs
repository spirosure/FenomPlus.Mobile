using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FenomPlus.Core.Database.Tables;
using FenomPlus.Core.Models;

namespace FenomPlus.Core.Database.Repository.Interfaces
{
    public interface ICrashlogsRepository
    {
        Task Insert(Exception ex, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");
        Task Insert(string message, [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0, [CallerMemberName] string callerMemberName = "");
        Task Insert(Crashlog crashlog);
        Task<CrashlogsTb> GetCrashlog();
        Task<List<CrashlogsTb>> GetAllCrashlog(Expression<Func<CrashlogsTb, bool>> predicate = null);
        Task<CrashlogsTb> Update(CrashlogsTb crashlog);
    }
}