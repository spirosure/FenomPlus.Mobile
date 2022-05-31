using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Repository.Interfaces 
{
    public interface IQualityControlDevicesRepository : IGenericRepository<QualityControlDevicesTb>
    {
        // inserts
        QualityControlDevicesTb Insert(QualityControlDeviceDBModel model);
        QualityControlDevicesTb Insert(QualityControlDevicesDataModel model);

        // delete
        void Delete(QualityControlDeviceDBModel model);
        void Delete(QualityControlDevicesDataModel model);

        // updates
        QualityControlDevicesTb Update(QualityControlDeviceDBModel model);
        QualityControlDevicesTb Update(QualityControlDevicesDataModel model);

        // select
        QualityControlDevicesTb FindDevice(string serialNumber);
    }
}
