using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using ACC.DAO;

namespace ACC.BLL
{
   public class HeadCategoryManager
    {
       public CustomList<AccReportConfigurationHeadCategory> GetAllAccReportConfigurationHeadCategory()
       {
           return AccReportConfigurationHeadCategory.GetAllAccReportConfigurationHeadCategory();
       }
       public void SaveHeadCategory(ref CustomList<AccReportConfigurationHeadCategory> lstHeadCategory)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(lstHeadCategory);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstHeadCategory);

               lstHeadCategory.AcceptChanges();

               conManager.CommitTransaction();
               blnTranStarted = false;
               conManager.Dispose();
           }
           catch (Exception Ex)
           {
               conManager.RollBack();
               throw Ex;
           }
           finally
           {
               if (conManager.IsNotNull())
               {
                   conManager.Dispose();
               }
           }
       }
       private void ReSetSPName(CustomList<AccReportConfigurationHeadCategory> lstHeadCategory)
       {
           #region Head Category
           lstHeadCategory.InsertSpName = "spInsertAccReportConfigurationHeadCategory";
           lstHeadCategory.UpdateSpName = "spUpdateAccReportConfigurationHeadCategory";
           lstHeadCategory.DeleteSpName = "spDeleteAccReportConfigurationHeadCategory";
           #endregion
       }
    }
}
