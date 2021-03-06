using System;
using System.Collections.Generic;
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
        private ILiteCollection<QualityControlDevicesTb> Collection => db.GetCollection<QualityControlDevicesTb>(TblName);

        public QualityControlDevicesRepository() : base(TblName)
        {

        }

        public QualityControlDevicesRepository(LiteDatabase db) : base(TblName, db)
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
                    LastConnected = DateTime.Now.ToString(),
                    SerialNumber = serialNumber
                };
                Insert(device);
            }
            else
            {
                device.LastConnected = DateTime.Now.ToString();
                Update(device);
            }
            return device;
        }

        /// <summary>
        /// Common Delete
        /// </summary>
        /// <param name="model"></param>
        public void Delete(QualityControlDevicesTb model)
        {
            try
            {
                if (model != null)
                {
                    this.Collection.Delete(model._id);
                }
            }
            catch (Exception ex)
            {
                Services.LogCat.Print(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteAll()
        {
            try
            {
                this.Collection.DeleteAll();
            }
            catch (Exception ex)
            {
                Services.LogCat.Print(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public QualityControlDevicesTb FindById(BsonValue _id)
        {
            return this.Collection.FindOne(x => x._id == _id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Insert(QualityControlDevicesTb model)
        {
            if (model != null)
            {
                try
                {
                    if (FindById(model._id) == null)
                    {
                        this.Collection.Insert(model);
                    }
                }
                catch (Exception ex)
                {
                    Services.LogCat.Print(ex);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<QualityControlDevicesTb> SelectAll()
        {
            return this.Collection.FindAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public QualityControlDevicesTb Update(QualityControlDevicesTb model)
        {
            if (model != null)
            {
                try
                {
                    if (FindById(model._id) != null)
                    {
                        this.Collection.Update(model);
                    }
                }
                catch (Exception ex)
                {
                    Services.LogCat.Print(ex);
                }
            }
            return model;
        }
    }
}