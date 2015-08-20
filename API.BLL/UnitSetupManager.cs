using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
  public class UnitSetupManager
    {
      public CustomList<UnitSetup> GetAllUnitSetup()
        {
            return UnitSetup.GetAllUnitSetup();
        }
      public void SaveUnitSetup(ref CustomList<UnitSetup> UnitSetup)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(UnitSetup);

                blnTranStarted = true;

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, UnitSetup);

                UnitSetup.AcceptChanges();

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
      private void ReSetSPName(CustomList<UnitSetup> UnitSetup)
        {
            #region Look Up Entity
            UnitSetup.InsertSpName = "spInsertUnitSetup";
            UnitSetup.UpdateSpName = "spUpdateUnitSetup";
            UnitSetup.DeleteSpName = "spDeleteUnitSetup";
            #endregion
        }
    }
}
