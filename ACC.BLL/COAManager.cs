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
    public class COAManager
    {
        public CustomList<Acc_COA> GetAllAcc_COA_ByLevel(int level)
        {
            return Acc_COA.GetAllAcc_COA_ByLevel(level);
        }
        public void Save(ref CustomList<Acc_COA> list)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                list.InsertSpName = "spInsertAcc_COA";
                list.UpdateSpName = "spUpdateAcc_COA";
                list.DeleteSpName = "spDeleteAcc_COA";

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, list);

                conManager.CommitTransaction();
                list.AcceptChanges();

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
    }
}
