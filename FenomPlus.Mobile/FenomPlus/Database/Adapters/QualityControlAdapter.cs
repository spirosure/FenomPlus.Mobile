using System;
using FenomPlus.Database.Tables;
using FenomPlus.Models;

namespace FenomPlus.Database.Adapters
{
    public static class QualityControlAdapter
    {
        public static QualityControlDBModel Convert(this QualityControlTb input)
        {
            if (input == null) return null;
            return new QualityControlDBModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateTaken = input.DateTaken,
                SerialNumber = input.SerialNumber,
                TestResult = input.TestResult,
                QCStatus = input.QCStatus,
                User = input.User
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlTb Convert(this QualityControlDBModel input)
        {
            if (input == null) return null;
            return new QualityControlTb()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateTaken = input.DateTaken,
                SerialNumber = input.SerialNumber,
                TestResult = input.TestResult,
                QCStatus = input.QCStatus,
                User = input.User
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static QualityControlDataModel ConvertForGrid(this QualityControlTb input)
        {
            if (input == null) return null;
            return new QualityControlDataModel()
            {
                _id = input._id,
                //Id = input.Id != null ? input.Id : Guid.NewGuid().ToString(),
                DateTaken = input.DateTaken,
                SerialNumber = input.SerialNumber,
                TestResult = input.TestResult,
                QCStatus = input.QCStatus,
                User = input.User
            };
        }
    }
}
