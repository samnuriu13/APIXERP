using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class WorkFlowManager
    {
        private Int32 workFlowID = 0;
        public Int32 WorkFlowID
        {
            get { return workFlowID; }
        }
        public CustomList<CmnWorkFlowMaster> GetAllCmnWorkFlowMasterFind()
        {
            return CmnWorkFlowMaster.GetAllCmnWorkFlowMasterFind();
        }
        public CustomList<CmnWorkFlowDetail> GetAllCmnWorkFlowDetail(Int32 WorkFlowID)
        {
            return CmnWorkFlowDetail.GetAllCmnWorkFlowDetail(WorkFlowID);
        }
        public void SaveWorkFlow(ref CustomList<CmnWorkFlowMaster> CmnWorkFlowMasterList, ref CustomList<CmnWorkFlowDetail> CmnWorkFlowDetailList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(CmnWorkFlowMasterList, CmnWorkFlowDetailList);
                  workFlowID = CmnWorkFlowMasterList[0].WorkFlowID;
                blnTranStarted = true;
                if (CmnWorkFlowMasterList[0].IsAdded)
                    workFlowID = Convert.ToInt32(conManager.InsertData(blnTranStarted, CmnWorkFlowMasterList));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, CmnWorkFlowMasterList);

                CmnWorkFlowDetailList.ForEach(x => x.WorkFlowID = workFlowID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, CmnWorkFlowDetailList);

                CmnWorkFlowMasterList.AcceptChanges();
                CmnWorkFlowDetailList.AcceptChanges();

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
        private void ReSetSPName(CustomList<CmnWorkFlowMaster> CmnWorkFlowMasterList, CustomList<CmnWorkFlowDetail> CmnWorkFlowDetailList)
        {
            #region Work Flow Master
            CmnWorkFlowMasterList.InsertSpName = "spInsertCmnWorkFlowMaster";
            CmnWorkFlowMasterList.UpdateSpName = "spUpdateCmnWorkFlowMaster";
            CmnWorkFlowMasterList.DeleteSpName = "spDeleteCmnWorkFlowMaster";
            #endregion
            #region Work Flow Detail
            CmnWorkFlowDetailList.InsertSpName = "spInsertCmnWorkFlowDetail";
            CmnWorkFlowDetailList.UpdateSpName = "spUpdateCmnWorkFlowDetail";
            CmnWorkFlowDetailList.DeleteSpName = "spDeleteCmnWorkFlowDetail";
            #endregion
        }
        public void deleteWrokFlow(ref CustomList<CmnWorkFlowMaster> lstCmnWorkFlowMaster, ref CustomList<CmnWorkFlowDetail> lstCmnWorkFlowDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                lstCmnWorkFlowDetail.DeleteSpName = "spDeleteCmnWorkFlowDetail";
                lstCmnWorkFlowMaster.DeleteSpName = "spDeleteCmnWorkFlowMaster";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstCmnWorkFlowDetail, lstCmnWorkFlowMaster);

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
