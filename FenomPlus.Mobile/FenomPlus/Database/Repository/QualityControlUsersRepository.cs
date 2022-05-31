using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class QualityControlUsersRepository : GenericRepository<QualityControlUsersTb>, IQualityControlUsersRepository
    {
        private static string TblName = "QualityControlUsersRepository";

        public QualityControlUsersRepository() : base(TblName)
        {
        }

        public QualityControlUsersRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public QualityControlUsersRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public QualityControlUsersRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlUsersDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlUsersDataModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public QualityControlUsersTb FindUser(string user)
        {
            return this.Collection.FindOne(x => x.User.Equals(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlUsersTb Insert(QualityControlUsersDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlUsersTb Insert(QualityControlUsersDataModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlUsersTb Update(QualityControlUsersDBModel model)
        {
            return Update(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlUsersTb Update(QualityControlUsersDataModel model)
        {
            return Update(model.Convert());
        }
    }
}