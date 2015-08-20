using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
   public class ItemGroupDeptMapingManager
    {
       public CustomList<ItemGroupDeptMaping> GetAllItemGroupDeptMaping(String itemGroupID)
       {
           return ItemGroupDeptMaping.GetAllItemGroupDeptMaping(itemGroupID);
       }
       public CustomList<ItemGroupDeptMaping> GetAllDept(Int32 entityID)
       {
           return ItemGroupDeptMaping.GetAllDept(entityID);
       }
       public void SaveItemGroupDeptMaping(ref CustomList<ItemGroupDeptMaping> lstItemGroupDeptMaping)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(lstItemGroupDeptMaping);

               blnTranStarted = true;

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemGroupDeptMaping);

               lstItemGroupDeptMaping.AcceptChanges();

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
       private void ReSetSPName(CustomList<ItemGroupDeptMaping> lstItemGroupDeptMaping)
       {
           #region Look Up Entity
           lstItemGroupDeptMaping.InsertSpName = "spInsertItemGroupDeptMaping";
           lstItemGroupDeptMaping.UpdateSpName = "spUpdateItemGroupDeptMaping";
           lstItemGroupDeptMaping.DeleteSpName = "spDeleteItemGroupDeptMaping";
           #endregion
       }
    }
}
