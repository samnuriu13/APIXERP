using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
    public class MenuWiseTableMappingManager
    {
        //public CustomList<CmnDocListTableMapping> GetAllReferenceType(Int32 DocListID)
        //{
        //    return CmnDocListTableMapping.GetAllReferenceType(DocListID);
        //}
        //public CustomList<CmnDocListTableMapping> GetAllReferenceType()
        //{
        //    return CmnDocListTableMapping.GetAllReferenceType();
        //}
        public CustomList<CmnTransactionReference> GetAllReferenceMasterTable()
        {
            return CmnTransactionReference.GetAllReferenceMasterTable();
        }
        public CustomList<CmnTransactionReference> GetAllDetailForeignKey(string tableName)
        {
            return CmnTransactionReference.GetAllDetailForeignKey(tableName);
        }
        public CustomList<PopulateDropdownList> GetAllReferenceTransaction(Int32 DocListID,Int32 RefType)
        {
            return PopulateDropdownList.GetAllReferenceTransaction(DocListID, RefType);
        }

        public CustomList<CmnDocListTableMapping> GetAllCmnTransactionReferenceFind()
        {
            return CmnDocListTableMapping.GetAllCmnTransactionReferenceFind();
        }

        public void SaveCmnDocListTableMapping(ref CustomList<CmnDocListTableMapping> CmnDocListTableMappingList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CmnDocListTableMappingList);
                Int32 TransactionTypeKey = CmnDocListTableMappingList[0].DocListTableMappingID;
                blnTranStarted = true;
                if (CmnDocListTableMappingList[0].IsAdded)
                    TransactionTypeKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, CmnDocListTableMappingList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, CmnDocListTableMappingList);

                CmnDocListTableMappingList.AcceptChanges();

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
        private void ReSetSPName(CustomList<CmnDocListTableMapping> CmnDocListTableMappingList)
        {
            #region MenuWiseTableMappingSP
            CmnDocListTableMappingList.InsertSpName = "spInsertCmnDocListTableMapping";
            CmnDocListTableMappingList.UpdateSpName = "spUpdateCmnDocListTableMapping";
            CmnDocListTableMappingList.DeleteSpName = "spDeleteCmnDocListTableMapping";
            #endregion            
        }
    }
}
