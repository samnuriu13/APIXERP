using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
   public class MailSetupManager
    {
       public CustomList<ReportSuiteMenu> GetReportList()
       {
           return ReportSuiteMenu.GetReportList();
       }
       public CustomList<MailSetup> GetAllMailSetup(Int32 reportID)
       {
           return MailSetup.GetAllMailSetup(reportID);
       }
       public CustomList<MailSetup> GetAllSupervisor()
       {
           return MailSetup.GetAllSupervisor();
       }
       public CustomList<MailSetup> GetAllHOD()
       {
           return MailSetup.GetAllHOD();
       }
       public void SaveMailSetup(CustomList<MailSetup> MailSetupList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();
               blnTranStarted = true;
               ReSetSPName(ref MailSetupList);

               conManager.SaveDataCollectionThroughCollection(blnTranStarted, MailSetupList);

               MailSetupList.AcceptChanges();

               conManager.CommitTransaction();
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
       private void ReSetSPName(ref CustomList<MailSetup> MailSetupList)
       {
           #region Mail Setup
           MailSetupList.InsertSpName = "spInsertMailSetup";
           MailSetupList.UpdateSpName = "spUpdateMailSetup";
           MailSetupList.DeleteSpName = "spDeleteMailSetup";
           #endregion
       }
    }
}
