using System;
using FenomPlus.Core.Database.Repository;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Repository.Interfaces;
using FenomPlus.Database.Tables;
using FenomPlus.Interfaces;
using FenomPlus.Models;
using LiteDB;

namespace FenomPlus.Database.Repository
{
    public class QualityControlDevicesRepository : GenericRepository<QualityControlDevicesTb>, IQualityControlDevicesRepository
    {
        private static string TblName = "QualityControlDevicesRepository";

        public QualityControlDevicesRepository() : base(TblName)
        {
        }

        public QualityControlDevicesRepository(LiteDatabase db) : base(TblName, db)
        {
        }

        public QualityControlDevicesRepository(IAppServices _services) : base(TblName, _services)
        {
        }

        public QualityControlDevicesRepository(IAppServices _services, LiteDatabase db) : base(TblName, _services, db)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlDeviceDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlDevicesDataModel model)
        {
            Delete(model.Convert());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DevicesTb"></param>
        /// <returns></returns>
        public QualityControlDevicesTb FindDevice(string serialNumber)
        {
            return this.Collection.FindOne(x => x.SerialNumber.Equals(serialNumber));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Insert(QualityControlDeviceDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Insert(QualityControlDevicesDataModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Update(QualityControlDeviceDBModel model)
        {
            return Update(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Update(QualityControlDevicesDataModel model)
        {
            return Update(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public QualityControlDevicesTb UpdateDateOrAdd(string serialNumber)
        {
            QualityControlDevicesTb device = FindDevice(serialNumber);
            if (device == null)
            {
                device = new QualityControlDevicesTb()
                {
                    LastConnected = DateTime.Now,
                    SerialNumber = serialNumber
                };
                Insert(device);
            }
            else
            {
                device.LastConnected = DateTime.Now;
                Update(device);
            }
            return device;
        }
    }
}