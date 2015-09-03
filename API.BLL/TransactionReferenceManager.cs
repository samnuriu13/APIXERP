using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;
using System.Data;

namespace API.BLL
{
    public class TransactionReferenceManager   
    {
        public CustomList<CmnTransactionReference> GetAllReferenceType(Int32 TransRefID)  
        {
            return CmnTransactionReference.GetAllReferenceType(TransRefID);
        }
        public CustomList<CmnTransactionReference> GetAllReferenceType()
        {
            return CmnTransactionReference.GetAllReferenceType();
        }
        public CustomList<CmnTransactionReference> GetAllReferenceMasterTable()
        {
            return CmnTransactionReference.GetAllReferenceMasterTable();
        }
        public CustomList<CmnTransactionReference> GetAllCmnTransactionReferenceFind()
        {
            return CmnTransactionReference.GetAllCmnTransactionReferenceFind();
        }
        public CustomList<PopulateDropdownList> GetAllReferenceTransaction(Int32 TransRefID,Int32 TransRef)   
        {
            return PopulateDropdownList.GetAllReferenceTransaction(TransRefID, TransRef);
        }
        public CustomList<CmnTransactionReference> GetAllDetailForeignKey(string referenceDetailTable)
        {
            return CmnTransactionReference.GetAllDetailForeignKey(referenceDetailTable);
        }

        public CustomList<CmnTransactionType> GetAllTransTypeName()
        {
            return CmnTransactionType.GetAllReferenceType();
        }


        //public CustomList<CmnTransactionReference> GetAllReferenceDetailTableList()
        //{
        //    return CmnTransactionReference.GetAllReferenceDetailTableList();
        //}
        
        public void SaveTransactionReference(ref CustomList<CmnTransactionReference> CmnTransactionReferenceList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CmnTransactionReferenceList);
                Int32 TransactionTypeKey = CmnTransactionReferenceList[0].TransRefID;
                blnTranStarted = true;
                if (CmnTransactionReferenceList[0].IsAdded)
                    TransactionTypeKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, CmnTransactionReferenceList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, CmnTransactionReferenceList);

                CmnTransactionReferenceList.AcceptChanges();

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
        private void ReSetSPName(CustomList<CmnTransactionReference> CmnTransactionReferenceList)
        {
            #region TransactionReference
            CmnTransactionReferenceList.InsertSpName = "spInsertCmnTransactionReference";
            CmnTransactionReferenceList.UpdateSpName = "spUpdateCmnTransactionReference";
            CmnTransactionReferenceList.DeleteSpName = "spDeleteCmnTransactionReference";
            #endregion
            
        }
    }
}
