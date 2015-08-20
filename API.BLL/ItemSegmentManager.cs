using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
   public class ItemSegmentManager
    {
       public CustomList<SegmentNames> GetAllSegmentNames()
        {
            return SegmentNames.GetAllSegmentNames();
        }
       public CustomList<SegmentNames> GetGroupSegmentNames(String itemGroupID)
       {
           return SegmentNames.GetGroupSegmentNames(itemGroupID);
       }
       public CustomList<SegmentValues> GetAllSegmentValues(Int32 segmentNameID)
       {
           return SegmentValues.GetAllSegmentValues(segmentNameID);
       }
       public void SaveItemSegment(ref CustomList<SegmentNames> lstSegmentNames, ref CustomList<SegmentValues> lstSegmentValues)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(lstSegmentNames, lstSegmentValues);
                Int32 SegNameID = lstSegmentNames[0].SegNameID;
                blnTranStarted = true;
                if (lstSegmentNames[0].IsAdded)
                    SegNameID = Convert.ToInt32(conManager.InsertData(blnTranStarted, lstSegmentNames));
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstSegmentNames);
                var SegmentValues = (CustomList<SegmentValues>)lstSegmentValues;
                SegmentValues.ForEach(x => x.SegNameID = SegNameID);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, SegmentValues);

                lstSegmentNames.AcceptChanges();
                lstSegmentValues.AcceptChanges();

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
       private void ReSetSPName(CustomList<SegmentNames> lstSegmentNames, CustomList<SegmentValues> lstSegmentValues)
        {
            #region Segment Name
            lstSegmentNames.InsertSpName = "spInsertSegmentNames";
            lstSegmentNames.UpdateSpName = "spUpdateSegmentNames";
            lstSegmentNames.DeleteSpName = "spDeleteSegmentNames";
            #endregion
            #region Segment Value
            lstSegmentValues.InsertSpName = "spInsertSegmentValues";
            lstSegmentValues.UpdateSpName = "spUpdateSegmentValues";
            lstSegmentValues.DeleteSpName = "spDeleteSegmentValues";
            #endregion
        }
    }
}
