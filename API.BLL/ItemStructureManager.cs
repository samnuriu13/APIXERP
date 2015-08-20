using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class ItemStructureManager
    {
        public CustomList<ItemStructure> GetAllItemStructure(Int32 itemGroupID)
        {
            return ItemStructure.GetAllItemStructure(itemGroupID);
        }
        public void SaveItemStructure(ref CustomList<ItemStructure> lstItemStructure)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstItemStructure);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemStructure);

                lstItemStructure.AcceptChanges();

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
        private void ReSetSPName(CustomList<ItemStructure> lstItemStructure)
        {
            #region Look Up Entity
            lstItemStructure.InsertSpName = "spInsertItemStructure";
            lstItemStructure.UpdateSpName = "spUpdateItemStructure";
            lstItemStructure.DeleteSpName = "spDeleteItemStructure";
            #endregion
        }
    }
}
