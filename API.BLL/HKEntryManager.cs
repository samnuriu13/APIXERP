using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class HKEntryManager
    {
        public CustomList<EntityList> GetAllEntityList()
        {
            return EntityList.GetAllEntityList();
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeeping(Int32 entityID)
        {
            return HouseKeepingValue.GetAllHouseKeeping(entityID);
        }

        public CustomList<EntityList> GetAllEntityListForHouseKeeping()
        {
            return EntityList.GetAllEntityListForHouseKeeping();
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue(string entityKey)
        {
            return HouseKeepingValue.GetAllHouseKeepingValue(entityKey);
        }
        public Int32 GetAllEntityList(string entityKey)
        {
            return EntityList.GetAllEntityList(entityKey);
        }
        public CustomList<HousekeepingHierarchy> GetAllHousekeepingHierarchy(Int32 hKID)
        {
            return HousekeepingHierarchy.GetAllHousekeepingHierarchy(hKID);
        }
        public CustomList<HouseKeepingValue> GetAllHouseKeepingValue(Int32 entityID)
        {
            return HouseKeepingValue.GetAllHouseKeepingValue(entityID);
        }
        public void DeleteHKEntry(ref CustomList<HouseKeepingValue> HKList, ref CustomList<HousekeepingHierarchy> lstChild)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();

                ReSetSPName(HKList, lstChild);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstChild, HKList);

                lstChild.AcceptChanges();
                HKList.AcceptChanges();

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
        public void SaveHKEntry(ref CustomList<HouseKeepingValue> HKList, ref CustomList<HousekeepingHierarchy> lstChild)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(HKList, lstChild);

                blnTranStarted = true;

                Int32 HKID = HKList[0].HKID;
                blnTranStarted = true;
                if (HKList[0].IsAdded)
                    HKID = Convert.ToInt32(conManager.InsertData(blnTranStarted, HKList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, HKList);
                lstChild.ForEach(x => x.HKID = HKID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstChild);

                HKList.AcceptChanges();
                lstChild.AcceptChanges();

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
        private void ReSetSPName(CustomList<HouseKeepingValue> HKVList, CustomList<HousekeepingHierarchy> lstChild)
        {
            #region HK

            HKVList.InsertSpName = "spInsertHouseKeepingValue";
            HKVList.UpdateSpName = "spUpdateHouseKeepingValue";
            HKVList.DeleteSpName = "spDeleteHouseKeepingValue";
            #endregion
            #region HK Hierarchy
            lstChild.InsertSpName = "spInsertHousekeepingHierarchy";
            lstChild.UpdateSpName = "spUpdateHousekeepingHierarchy";
            lstChild.DeleteSpName = "spDeleteHousekeepingHierarchy";
            #endregion
        }
    }
}
