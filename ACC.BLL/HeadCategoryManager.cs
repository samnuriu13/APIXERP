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
       //public CustomList<AccReportConfigurationHeadCategory> GetHeadCategory()
       //{
       //    return AccReportConfigurationHeadCategory.GetAllAccReportConfigurationHeadCategory();
       //}
       public CustomList<AccReportConfigurationHead> GetAllAccReportConfigurationHead()
       {
           return AccReportConfigurationHead.GetAllAccReportConfigurationHead();
       }

       public void SaveAccReportConfigurationHead(ref CustomList<AccReportConfigurationHead> AccReportConfigurationHeadList, ref CustomList<AccReportConfigurationHeadCOAMap> AccReportConfigurationHeadCOAMapList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);      
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPNameForAccReportConfigurationHead(AccReportConfigurationHeadList, AccReportConfigurationHeadCOAMapList);
               Int32 headID = AccReportConfigurationHeadList[0].HeadID;
               blnTranStarted = true;
               if (AccReportConfigurationHeadList[0].IsAdded)
                   headID = Convert.ToInt32(conManager.InsertData(blnTranStarted, AccReportConfigurationHeadList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccReportConfigurationHeadList);
               var accReportConfigurationHeadCOAMap = (CustomList<AccReportConfigurationHeadCOAMap>)AccReportConfigurationHeadCOAMapList;
               accReportConfigurationHeadCOAMap.ForEach(x => x.HeadID = headID);
               conManager.SaveDataCollectionThroughCollection(blnTranStarted, accReportConfigurationHeadCOAMap);

               AccReportConfigurationHeadList.AcceptChanges();
               AccReportConfigurationHeadCOAMapList.AcceptChanges();

               conManager.CommitTransaction();
               blnTranStarted = false;
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
       private void ReSetSPNameForAccReportConfigurationHead(CustomList<AccReportConfigurationHead> AccReportConfigurationHeadList, CustomList<AccReportConfigurationHeadCOAMap> AccReportConfigurationHeadCOAMapList)
       {
           #region AccReportConfigurationHead
           AccReportConfigurationHeadList.InsertSpName = "spInsertAccReportConfigurationHead";
           AccReportConfigurationHeadList.UpdateSpName = "spUpdateAccReportConfigurationHead";
           AccReportConfigurationHeadList.DeleteSpName = "spDeleteAccReportConfigurationHead";
           #endregion
           #region AccReportConfigurationHeadCOAMap
           AccReportConfigurationHeadCOAMapList.InsertSpName = "spInsertAccReportConfigurationHeadCOAMap";
           AccReportConfigurationHeadCOAMapList.UpdateSpName = "spUpdateAccReportConfigurationHeadCOAMap";
           AccReportConfigurationHeadCOAMapList.DeleteSpName = "spDeleteAccReportConfigurationHeadCOAMap";
           #endregion
       }
       public CustomList<AccReportConfigurationHeadCOAMap> GetAllAccReportConfigurationHeadCOAMap(Int32 headID)
       {
           return AccReportConfigurationHeadCOAMap.GetAllAccReportConfigurationHeadCOAMap(headID);
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
