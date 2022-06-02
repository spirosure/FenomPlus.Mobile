using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class QualityControlRepository : GenericRepository<QualityControlTb>, IQualityControlRepository
    {
        private static string TblName = "QualityControlRepository";

        public QualityControlRepository() : base(TblName)
        {
        }

        public QualityControlRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public QualityControlRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public QualityControlRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlDataModel model)
        {
            Delete(model.Convert());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public QualityControlTb FindDevice(string serialNumber)
        {
            return this.Collection.FindOne(x => x.SerialNumber.Equals(serialNumber));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlTb Insert(QualityControlDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlTb Insert(QualityControlDataModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlTb Update(QualityControlDBModel model)
        {
            return Update(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlTb Update(QualityControlDataModel model)
        {
            return Update(model.Convert());
        }
    }
}