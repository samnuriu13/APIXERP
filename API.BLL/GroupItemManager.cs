using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class GroupItemManager
    {
        public CustomList<ItemGroup> GetAllItemGroup()
        {
            return ItemGroup.GetAllItemGroup();
        }
        //
        public CustomList<ItemGroup> GetAllSubGroupApplicableItemGroup()
        {
            return ItemGroup.GetAllSubGroupApplicableItemGroup();
        }

        public bool IsSubgroupApplicable(int groupId)
        {
            return ItemGroup.IsSubgroupApplicable(groupId);
        }

        public CustomList<ItemGroup> DeptWiseItemGroup(Int32 DeptID)
        {
            return ItemGroup.DeptWiseItemGroup(DeptID);
        }
        public void SaveUnitSetup(ref CustomList<ItemGroup> lstItemGroup)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstItemGroup);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemGroup);

                lstItemGroup.AcceptChanges();

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
        private void ReSetSPName(CustomList<ItemGroup> lstlstItemGroup)
        {
            #region Look Up Entity
            lstlstItemGroup.InsertSpName = "spInsertItemGroup";
            lstlstItemGroup.UpdateSpName = "spUpdateItemGroup";
            lstlstItemGroup.DeleteSpName = "spDeleteItemGroup";
            #endregion
        }
    }
}
