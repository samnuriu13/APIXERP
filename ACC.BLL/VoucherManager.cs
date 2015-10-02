using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using ACC.DAO;


namespace ACC.BLL
{
    public class VoucherManager
    {
        private String voucherID = String.Empty;
        public String VoucherID
        {
            get { return voucherID; }
        }
        public CustomList<Acc_COA> GetAllAcc_COA()
        {
            return Acc_COA.GetAllAcc_COA();
        }

        public CustomList<Acc_COA> GetAllAcc_COA_ByLevel(int level)
        {
            return Acc_COA.GetAllAcc_COA_ByLevel(level);
        }

        public CustomList<Acc_COA> GetAllCashOrBankCOA(String menuName)
        {
            return Acc_COA.GetAllCashOrBankCOA(menuName);
        }

        

        ////public CustomList<Organization> GetAllCompany(string empCode, Int32 isAdmin)
        ////{
        ////    return Organization.GetAllOrganization(empCode, isAdmin);
        ////}
        ////public CustomList<Organization> GetAllCompany()
        ////{
        ////    return Organization.GetAllOrganization(2);
        ////}
        public CustomList<Acc_VoucherType> GetAllAcc_VoucherType()
        {
            return Acc_VoucherType.GetAllAcc_VoucherType();
        }
        public CustomList<Acc_Voucher> GetAllAcc_Voucher(Int32 VoucherTypeKey)
        {
            return Acc_Voucher.GetAllAcc_Voucher(VoucherTypeKey);
        }
        public Acc_Voucher GetAllAcc_Voucher(string voucherNo)
        {
            return Acc_Voucher.GetAllAcc_Voucher(voucherNo);
        }
        public Acc_Voucher GetAllAcc_WorkFlowVoucher(string voucherKey)
        {
            return Acc_Voucher.GetAllAcc_WorkFlowVoucher(voucherKey);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey,string fromDate)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(voucherKey,fromDate);
        }
        public CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey)
        {
            return Acc_VoucherDet.GetAllAcc_VoucherDet(voucherKey);
        }
        //Posting Voucher
        //public CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr)
        //{
        //    return Acc_Voucher.GetAllAcc_VoucherSearch(searchStr);
        //}
        public CustomList<Acc_VoucherDet> CheckBankAndCashVoucher(string searchStr)
        {
            return Acc_VoucherDet.CheckBankAndCashVoucher(searchStr);
        }
        //End
        //Search Voucher
        //public CustomList<Acc_Voucher> GetAllAcc_VoucherSearch(string searchStr, string blank)
        //{
        //    return Acc_Voucher.GetAllAcc_VoucherSearch(searchStr, blank);
        //}
        //end
        public void SavePFVoucher(ref CustomList<Acc_Voucher> AccVoucherList, ref CustomList<Acc_VoucherDet> AccVoucherDetList, string prifix)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                blnTranStarted = true;
                conManager.BeginTransaction();

                ReSetSPName(ref AccVoucherList, ref AccVoucherDetList);
                if (AccVoucherList[0].VoucherNo.IsNullOrEmpty())
                {
                    GetNewVoucherID(ref conManager, blnTranStarted, ref AccVoucherList, prifix);
                }
                else
                {
                    string[] items = AccVoucherList[0].VoucherNo.Split('-');
                    if (prifix != items[0])
                    {
                        string prifix1 = prifix + "-" + items[1];
                        voucherID = prifix1;
                        AccVoucherList[0].VoucherNo = prifix1;
                    }
                    else
                        voucherID = AccVoucherList[0].VoucherNo;
                }
                blnTranStarted = true;

                if (AccVoucherList[0].IsAdded)
                {
                    object scope_Identity = conManager.InsertData(blnTranStarted, AccVoucherList);
                    AccVoucherList[0].VoucherKey = Convert.ToInt64(scope_Identity);
                }
                else
                {
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherList);
                }
                CustomList<Acc_VoucherDet> AddedVoucherDetList = AccVoucherDetList.FindAll(f => f.IsAdded);
                foreach (Acc_VoucherDet aVD in AddedVoucherDetList)
                {
                    aVD.VoucherKey = AccVoucherList[0].VoucherKey;
                }
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherDetList);

                conManager.CommitTransaction();
                AccVoucherList.AcceptChanges();
                AccVoucherDetList.AcceptChanges();
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
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        private void ReSetSPName(ref CustomList<Acc_Voucher> AccVoucherList, ref CustomList<Acc_VoucherDet> AccVoucherDetList)
        {
            #region Acc Voucher
            AccVoucherList.InsertSpName = "spInsertAcc_Voucher";
            AccVoucherList.UpdateSpName = "spUpdateAcc_Voucher";
            AccVoucherList.DeleteSpName = "spDeleteAcc_Voucher";
            #endregion
            #region Acc Voucher Det
            AccVoucherDetList.InsertSpName = "spInsertAcc_VoucherDet";
            AccVoucherDetList.UpdateSpName = "spUpdateAcc_VoucherDet";
            AccVoucherDetList.DeleteSpName = "spDeleteAcc_VoucherDet";
            #endregion
        }
        private void GetNewVoucherID(ref ConnectionManager conManager, bool requiredTransaction, ref CustomList<Acc_Voucher> AccVoucherList, string prifix)
        {
            String newAccVoucherID = String.Empty;
            try
            {
                CustomList<Acc_Voucher> tempAccVoucherList = AccVoucherList.FindAll(f => f.IsAdded);
                if (tempAccVoucherList.Count != 0)
                {
                    string prifix1 = prifix + "-";
                    newAccVoucherID = Convert.ToString(StaticInfo.GetUniqueCodeWithoutSignature(ref conManager, requiredTransaction, "Acc_Voucher", "VoucherNo", prifix1));
                    tempAccVoucherList[0].VoucherNo = prifix1 + newAccVoucherID;
                    voucherID = prifix1 + newAccVoucherID;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void DeleteVoucher(ref CustomList<Acc_VoucherDet> VoucherDetList, ref CustomList<Acc_Voucher> VoucherList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                ReSetSPName(ref VoucherList, ref VoucherDetList);

                conManager.BeginTransaction();
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, VoucherDetList, VoucherList);
                conManager.CommitTransaction();
                VoucherDetList.AcceptChanges();
                VoucherList.AcceptChanges();
            }
            catch (Exception ex)
            {
                conManager.RollBack();
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        //Posting Voucher
        public void SavePostVoucher(ref CustomList<Acc_Voucher> AccVoucherList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                //ReSetSPName(ref AccVoucherList); spUpdateAcc_VoucherPost
                AccVoucherList.UpdateSpName = "spUpdateAcc_VoucherPost";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, AccVoucherList);

                conManager.CommitTransaction();
                AccVoucherList.AcceptChanges();
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
                    blnTranStarted = false;
                    conManager.Dispose();
                }
            }
        }
        //end
    }
}

