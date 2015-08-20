using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class ItemMasterManager
    {
        public CustomList<ItemMaster> GetAllItemMaster()
        {
            return ItemMaster.GetAllItemMaster();
        }
        public CustomList<ItemMaster> FindAllItemMasterBySubGroup(String itemSubGroupID)
        {
            return ItemMaster.FindAllItemMasterBySubGroup(itemSubGroupID);
        }
        public CustomList<ItemMaster> FindAllItemMasterGroupWise()
        {
            return ItemMaster.FindAllItemMasterGroupWise();
        }
        public CustomList<ItemMaster> FindAllItemMaster()
        {
            return ItemMaster.FindAllItemMaster();
        }
        public CustomList<ItemMaster> GetAllItemMasterByItemCode(String itemCode)
        {
            return ItemMaster.GetAllItemMasterByItemCode(itemCode);
        }
        public void SaveItemMaster(ref CustomList<ItemMaster> ItemMasterList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(ItemMasterList);

                GetNewItemCode(ref conManager, ref ItemMasterList);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, ItemMasterList);

                ItemMasterList.AcceptChanges();

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
        private void ReSetSPName(CustomList<ItemMaster> lstItemMaster)
        {
            #region Item Master

            lstItemMaster.InsertSpName = "spInsertItemMaster";
            lstItemMaster.UpdateSpName = "spUpdateItemMaster";
            lstItemMaster.DeleteSpName = "spDeleteItemMaster";
            #endregion
        }
        private void GetNewItemCode(ref ConnectionManager conManager, ref CustomList<ItemMaster> lstItemMaster)
        {
            String newItemMasterID = String.Empty;
            try
            {
                CustomList<ItemMaster> tempItemMasterList = lstItemMaster.FindAll(f => f.IsAdded);
                if (tempItemMasterList.Count != 0)
                {
                    newItemMasterID = StaticInfo.MakeUniqueCode("ItemCode", 20, DateTime.Today.ToString(), "yy", "I", "-", "");
                    lstItemMaster[0].ItemCode = newItemMasterID;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
