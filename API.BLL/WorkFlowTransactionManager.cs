using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using API.DAO;


namespace API.BLL
{
   public class WorkFlowTransactionManager
    {
       public void InsertWorkFlowTransaction(int DocListID,Int32 StatusID, String UserID, int CompanyID, long TransactionID = 0,bool IsApprove=true, String Comment = "", bool IsUpdate = false, bool IsDelete = false)
       {

            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            IDataReader reader = null;
            String sql = "EXEC spInsertCmnWorkFlowTransaction " + DocListID+","+StatusID+",'"+UserID+"',"+CompanyID+","+TransactionID+","+IsApprove+",'"+Comment+"',"+IsUpdate+","+IsDelete;
            try
            {
                conManager.OpenDataReader(sql, out reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
       }
       public CustomList<WFApprovalPendingList> GetWFApprovalPendingList(int DocListID, String UserID, int CompanyID)
       {
           return WFApprovalPendingList.GetAllWFApprovalPendingList(DocListID,UserID,CompanyID);
       }
    }
}
