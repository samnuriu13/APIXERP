using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
   public class POManager
    {
        private String customCode = String.Empty;
        public String CustomCode
        {
            get { return customCode; }
        }
        public CustomList<POMaster> GetAllPOMasterFind()
        {
            return POMaster.GetAllPOMasterFind();
        }
        public CustomList<PODetail> GetAllPODetail(Int64 POID)
        {
            return PODetail.GetAllPODetail(POID);
        }

        public void SavePO(ref CustomList<POMaster> lstPOMaster, ref CustomList<PODetail> lstPODetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstPOMaster, lstPODetail);
                GetNewPONo(ref conManager, ref lstPOMaster);
                Int64 POID = lstPOMaster[0].POID;
                blnTranStarted = true;
                if (lstPOMaster[0].IsAdded)
                    POID = Convert.ToInt32(conManager.InsertData(blnTranStarted, lstPOMaster));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstPOMaster);
                lstPODetail.ForEach(x => x.POID = POID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstPODetail);

                lstPOMaster.AcceptChanges();
                lstPODetail.AcceptChanges();

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
        public void deletePO(ref CustomList<POMaster> lstPOMaster, ref CustomList<PODetail> lstPODetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;
            try
            {
                conManager.BeginTransaction();
                lstPODetail.DeleteSpName = "spDeletePODetail";
                lstPOMaster.DeleteSpName = "spDeletePOMaster";
                blnTranStarted = true;
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstPODetail, lstPOMaster);

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
        private void ReSetSPName(CustomList<POMaster> lstPOMaster, CustomList<PODetail> lstPODetail)
        {
            #region Segment Name
            lstPOMaster.InsertSpName = "spInsertPOMaster";
            lstPOMaster.UpdateSpName = "spUpdatePOMaster";
            lstPOMaster.DeleteSpName = "spDeletePOMaster";
            #endregion
            #region Segment Value
            lstPODetail.InsertSpName = "spInsertPODetail";
            lstPODetail.UpdateSpName = "spUpdatePODetail";
            lstPODetail.DeleteSpName = "spDeletePODetail";
            #endregion
        }
        private void GetNewPONo(ref ConnectionManager conManager, ref CustomList<POMaster> lstPOMaster)
        {
            String newPONo = String.Empty;
            try
            {
                CustomList<POMaster> tempPOMaster = lstPOMaster.FindAll(f => f.IsAdded);
                if (tempPOMaster.Count != 0)
                {
                    newPONo = StaticInfo.MakeUniqueCode("CustomCode", 20, DateTime.Today.ToString(), "yy", "PO", "-", "");
                    lstPOMaster[0].CustomCode = newPONo;
                    customCode = newPONo;
                }
                else
                    customCode = lstPOMaster[0].CustomCode;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
