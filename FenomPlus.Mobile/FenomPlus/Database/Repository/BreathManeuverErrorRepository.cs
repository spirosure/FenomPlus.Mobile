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
    public class BreathManeuverErrorRepository : GenericRepository<BreathManeuverErrorTb>, IBreathManeuverErrorRepository
    {
        private static string TblName = "BreathManeuverErrorRepository";
        private ILiteCollection<BreathManeuverErrorTb> Collection => db.GetCollection<BreathManeuverErrorTb>(TblName);

        public BreathManeuverErrorRepository() : base(TblName)
        {

        }

        public BreathManeuverErrorRepository(LiteDatabase db) : base(TblName, db)
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BreathManeuverErrorDBModel model)
        {
            Delete(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Insert(BreathManeuverErrorDBModel model)
        {
            return Insert(model.Convert());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Update(BreathManeuverErrorDBModel model)
        {
            return Update(model.Convert());
        }

        /// <summary>
        /// Common Delete
        /// </summary>
        /// <param name="model"></param>
        public void Delete(BreathManeuverErrorTb model)
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
        public BreathManeuverErrorTb FindById(BsonValue _id)
        {
            return this.Collection.FindOne(x => x._id == _id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Insert(BreathManeuverErrorTb model)
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
        public IEnumerable<BreathManeuverErrorTb> SelectAll()
        {
            return this.Collection.FindAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BreathManeuverErrorTb Update(BreathManeuverErrorTb model)
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