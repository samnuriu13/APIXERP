using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
    public class TransactionTypeManager
    {
        public CustomList<CmnTransactionType> GetAllReferenceType(Int32 DocListID)
        {
            return CmnTransactionType.GetAllReferenceType(DocListID);
        }
        public CustomList<CmnTransactionType> GetAllReferenceType()
        {
            return CmnTransactionType.GetAllReferenceType();
        }
        public CustomList<PopulateDropdownList> GetAllReferenceTransaction(Int32 DocListID,Int32 RefType)
        {
            return PopulateDropdownList.GetAllReferenceTransaction(DocListID, RefType);
        }
        public void SaveTransactionType(ref CustomList<CmnTransactionType> CmnTransactionTypeList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CmnTransactionTypeList);
                Int32 TransactionTypeKey = CmnTransactionTypeList[0].TransTypeID;
                blnTranStarted = true;
                if (CmnTransactionTypeList[0].IsAdded)
                    TransactionTypeKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, CmnTransactionTypeList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, CmnTransactionTypeList);

                CmnTransactionTypeList.AcceptChanges();

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
        private void ReSetSPName(CustomList<CmnTransactionType> CmnTransactionTypeList)
        {
            #region Bank
            CmnTransactionTypeList.InsertSpName = "spInsertCmnTransactionType";
            CmnTransactionTypeList.UpdateSpName = "spUpdateCmnTransactionType";
            CmnTransactionTypeList.DeleteSpName = "spDeleteCmnTransactionType";
            #endregion
            
        }
    }
}
