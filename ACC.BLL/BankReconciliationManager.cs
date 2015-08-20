using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using ACC.DAO;
using API.DAO;

namespace ACC.BLL
{
    public class BankReconciliationManager
    {
        public CustomList<AccChequeStatusList> GetAllAccChequeStatusList()
        {
            return AccChequeStatusList.GetAllAccChequeStatusList();
        }
        public CustomList<Acc_Voucher> GetAllAcc_Voucher(Int32 CostCenterID, Int32 DeptID, Int32 bankBranch, String fromDate, String toDate)
        {
            return Acc_Voucher.GetAllAcc_Voucher(CostCenterID, DeptID, bankBranch, fromDate, toDate);
        }
        public void SaveBankReconciliation(ref CustomList<Acc_Voucher> VoucherList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();
                VoucherList.UpdateSpName = "spUpdateAcc_VoucherBankReconciliation";
                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, VoucherList);

                VoucherList.AcceptChanges();

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
    }
}
