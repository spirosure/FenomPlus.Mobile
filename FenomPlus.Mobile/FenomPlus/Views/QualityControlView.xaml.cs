using System;
using System.Collections.Generic;
using FenomPlus.Database.Adapters;
using FenomPlus.Database.Tables;
using FenomPlus.Helpers;
using FenomPlus.Models;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class QualityControlView : BaseContentPage
    {
        private QualityControlViewModel model;

        /// <summary>
        /// 
        /// </summary>
        public QualityControlView()
        {
            InitializeComponent();
            BindingContext = model = new QualityControlViewModel();
            dataGrid.GridStyle = new CustomGridStyle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnAddNew(System.Object sender, System.EventArgs e)
        {
            IEnumerable<QualityControlUsersTb> records = QCUsersRepo.SelectAll();
            List<string> userRecords = new List<string>();
            foreach (QualityControlUsersTb userRecord in records)
            {
                userRecords.Add(userRecord.User);
            }

            if (userRecords.Count <= 0) return;

            string userName = await DisplayActionSheet("Select User", "Cancel", "", userRecords.ToArray());
            if (string.IsNullOrEmpty(userName)) return;

            // ok goto test, for now create random
            Services.Cache.QCUsername = userName;

            //ok goto test now.


            /*
            // try to find if user is already in database
            QualityControlDBModel testDBModel = new Models.QualityControlDBModel()
            {
                SerialNumber = "SerialNumber",
                DateTaken = DateTime.Now,
                QCExpiration = "QCExpiration",
                QCStatus = "QCStatus",
                TestResult = 1.00,
                User = userName
            };
            QualityControlTb record = QCRepo.Insert(testDBModel);
            testDBModel = record.Convert();
            */
            model.UpdateGrid();
        }
    }
}
