using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
   public class ItemSubGroupManager
    {
       public CustomList<ItemSubGroup> GetAllItemSubGroup()
        {
            return ItemSubGroup.GetAllItemSubGroup();
        }
       public CustomList<ItemSubGroup> GetAllItemSubGroup(String itemGroupID)
       {
           return ItemSubGroup.GetAllItemSubGroup(itemGroupID);
       }
        public void SaveUnitSetup(ref CustomList<ItemSubGroup> lstItemSubGroup)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstItemSubGroup);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemSubGroup);

                lstItemSubGroup.AcceptChanges();

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
        private void ReSetSPName(CustomList<ItemSubGroup> lstlstItemSubGroup)
        {
            #region Look Up Entity
            lstlstItemSubGroup.InsertSpName = "spInsertItemSubGroup";
            lstlstItemSubGroup.UpdateSpName = "spUpdateItemSubGroup";
            lstlstItemSubGroup.DeleteSpName = "spDeleteItemSubGroup";
            #endregion
        }
    }
}
