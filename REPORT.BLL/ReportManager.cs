using System;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
//using ASL.Hr.DAO;

namespace REPORT.BLL
{
   public class ReportManager
    {
       public DataSet GetCompany(String orgKey)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec spGetCompany @OrgKey = '{0}'", orgKey);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "spGetCompany";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
       public DataSet GetVoucherDataSources(String voucherNo)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;
           String spName = String.Empty;
           try
           {

               DataSet dsLoad = new DataSet();
               DataSet dsReturn = new DataSet();

               conManager.BeginTransaction();
               blnTranStarted = true;

               spName = String.Format("Exec spPreviewVoucher  @VoucherNo = '{0}'", voucherNo);
               conManager.OpenDataSetThroughAdapter(spName, ref dsLoad, true);
               dsLoad.Tables[0].TableName = "spPreviewVoucher";
               dsReturn.Tables.Add(dsLoad.Tables[0].Copy());

               conManager.CommitTransaction();
               blnTranStarted = false;
               return dsReturn;
           }
           catch (Exception ex)
           {
               if (blnTranStarted)
               {
                   conManager.RollBack();
               }
               throw (ex);
           }
       }
    }
}
