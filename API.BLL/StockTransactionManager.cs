using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
   public class StockTransactionManager
    {
        private String customCode = String.Empty;
        public String CustomCode
        {
            get { return customCode; }
        }
        public CustomList<StockTransactionMaster> GetAllStockTransactionMaster(Int32 TransType)
        {
            return StockTransactionMaster.GetAllStockTransactionMaster(TransType);
        }
        public CustomList<StockTransactionDetail> GetAllStockTransactionDetail(Int64 StockTransID)
        {
            return StockTransactionDetail.GetAllStockTransactionDetail(StockTransID);
        }

        public void SaveStockTransaction(ref CustomList<StockTransactionMaster> lstStockTransactionMaster, ref CustomList<StockTransactionDetail> lstStockTransactionDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstStockTransactionMaster, lstStockTransactionDetail);
                GetNewStockTransaction(ref conManager, ref lstStockTransactionMaster);
                Int64 StockTransID = lstStockTransactionMaster[0].StockTransID;
                blnTranStarted = true;
                if (lstStockTransactionMaster[0].IsAdded)
                    StockTransID = Convert.ToInt32(conManager.InsertData(blnTranStarted, lstStockTransactionMaster));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstStockTransactionMaster);
                lstStockTransactionDetail.ForEach(x => x.StockTransID = StockTransID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstStockTransactionDetail);

                lstStockTransactionMaster.AcceptChanges();
                lstStockTransactionDetail.AcceptChanges();

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
        public void deleteStockTransaction(ref CustomList<StockTransactionMaster> lstStockTransactionMaster, ref CustomList<StockTransactionDetail> lstStockTransactionDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                lstStockTransactionDetail.DeleteSpName = "spDeleteStockTransactionDetail";
                lstStockTransactionMaster.DeleteSpName = "spDeleteStockTransactionMaster";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstStockTransactionDetail, lstStockTransactionMaster);

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
        private void ReSetSPName(CustomList<StockTransactionMaster> lstStockTransactionMaster, CustomList<StockTransactionDetail> lstStockTransactionDetail)
        {
            #region Segment Name
            lstStockTransactionMaster.InsertSpName = "spInsertStockTransactionMaster";
            lstStockTransactionMaster.UpdateSpName = "spUpdateStockTransactionMaster";
            lstStockTransactionMaster.DeleteSpName = "spDeleteStockTransactionMaster";
            #endregion
            #region Segment Value
            lstStockTransactionDetail.InsertSpName = "spInsertStockTransactionDetail";
            lstStockTransactionDetail.UpdateSpName = "spUpdateStockTransactionDetail";
            lstStockTransactionDetail.DeleteSpName = "spDeleteStockTransactionDetail";
            #endregion
        }
        private void GetNewStockTransaction(ref ConnectionManager conManager, ref CustomList<StockTransactionMaster> lstStockTransactionMaster)
        {
            String newCustomCode = String.Empty;
            try
            {
                CustomList<StockTransactionMaster> tempStockTransactionMaster = lstStockTransactionMaster.FindAll(f => f.IsAdded);
                if (tempStockTransactionMaster.Count != 0)
                {
                    newCustomCode = StaticInfo.MakeUniqueCode("CustomCode", 20, DateTime.Today.ToString(), "yy", "ST", "-", "");
                    tempStockTransactionMaster[0].CustomCode = newCustomCode;
                    customCode = newCustomCode;
                }
                else
                    customCode = lstStockTransactionMaster[0].CustomCode;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
