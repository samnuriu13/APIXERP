using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
    public class RequisitionManager
    {
        private String customCode = String.Empty;
        public String CustomCode
        {
            get { return customCode; }
        }
        public CustomList<ItemRequisitionMaster> GetAllItemRequisitionMaster(Int32 TransType)
        {
            return ItemRequisitionMaster.GetAllItemRequisitionMaster(TransType);
        }
        public CustomList<ItemRequisitionDetail> GetAllItemRequisitionDetail(Int64 RequisitionID)
        {
            return ItemRequisitionDetail.GetAllItemRequisitionDetail(RequisitionID);
        }

        public void SaveRequisition(ref CustomList<ItemRequisitionMaster> lstItemRequisitionMaster, ref CustomList<ItemRequisitionDetail> lstItemRequisitionDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstItemRequisitionMaster, lstItemRequisitionDetail);
                GetNewRequisitionNo(ref conManager, ref lstItemRequisitionMaster);
                Int64 RequisitionID = lstItemRequisitionMaster[0].RequisitionID;
                blnTranStarted = true;
                if (lstItemRequisitionMaster[0].IsAdded)
                    RequisitionID = Convert.ToInt32(conManager.InsertData(blnTranStarted, lstItemRequisitionMaster));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemRequisitionMaster);
                //var ItemRequisitionDetailList = (CustomList<ItemRequisitionDetail>)lstItemRequisitionDetail;
                lstItemRequisitionDetail.ForEach(x => x.RequisitionID = RequisitionID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemRequisitionDetail);

                lstItemRequisitionMaster.AcceptChanges();
                lstItemRequisitionDetail.AcceptChanges();

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
        public void deleteRequisition(ref CustomList<ItemRequisitionMaster> lstItemRequisitionMaster, ref CustomList<ItemRequisitionDetail> lstItemRequisitionDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                lstItemRequisitionDetail.DeleteSpName = "spDeleteItemRequisitionDetail";
                lstItemRequisitionMaster.DeleteSpName = "spDeleteItemRequisitionMaster";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstItemRequisitionDetail, lstItemRequisitionMaster);

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
        private void ReSetSPName(CustomList<ItemRequisitionMaster> lstItemRequisitionMaster, CustomList<ItemRequisitionDetail> lstItemRequisitionDetail)
        {
            #region Segment Name
            lstItemRequisitionMaster.InsertSpName = "spInsertItemRequisitionMaster";
            lstItemRequisitionMaster.UpdateSpName = "spUpdateItemRequisitionMaster";
            lstItemRequisitionMaster.DeleteSpName = "spDeleteItemRequisitionMaster";
            #endregion
            #region Segment Value
            lstItemRequisitionDetail.InsertSpName = "spInsertItemRequisitionDetail";
            lstItemRequisitionDetail.UpdateSpName = "spUpdateItemRequisitionDetail";
            lstItemRequisitionDetail.DeleteSpName = "spDeleteItemRequisitionDetail";
            #endregion
        }
        private void GetNewRequisitionNo(ref ConnectionManager conManager, ref CustomList<ItemRequisitionMaster> lstItemRequisitionMaster)
        {
            String newRequisitionNo = String.Empty;
            try
            {
                CustomList<ItemRequisitionMaster> tempItemRequisitionMaster = lstItemRequisitionMaster.FindAll(f => f.IsAdded);
                if (tempItemRequisitionMaster.Count != 0)
                {
                    newRequisitionNo = StaticInfo.MakeUniqueCode("CustomCode", 20, DateTime.Today.ToString(), "yy", "RNO", "-", "");
                    lstItemRequisitionMaster[0].CustomCode = newRequisitionNo;
                    customCode = newRequisitionNo;
                }
                else
                    customCode = lstItemRequisitionMaster[0].CustomCode;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
