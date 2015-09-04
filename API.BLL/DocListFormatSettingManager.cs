using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
   public class DocListFormatSettingManager
    {
        //public CustomList<SegmentNames> GetAllSegmentNames()
        //{
        //    return SegmentNames.GetAllSegmentNames();
        //}
        //public CustomList<SegmentNames> GetGroupSegmentNames(String itemGroupID)
        //{
        //    return SegmentNames.GetGroupSegmentNames(itemGroupID);
        //}
        //public CustomList<SegmentValues> GetAllSegmentValues(Int32 segmentNameID)
        //{
        //    return SegmentValues.GetAllSegmentValues(segmentNameID);
        //}
       public CustomList<CmnDocListFormat> GetAllDocListFormatFind()
       {
          return CmnDocListFormat.GetAllDocListFormatFind();
       }
       public CustomList<CmnDocListFormatDetail> GetAllDocListFormat_Detail(Int32 docListFormatID)
       {
           return CmnDocListFormatDetail.GetAllDocListFormat_Detail(docListFormatID);
       }

       public void SaveDocListFormat(ref CustomList<CmnDocListFormat> DocListFormatList, ref CustomList<CmnDocListFormatDetail> DocListFormatDetailList)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(DocListFormatList, DocListFormatDetailList);
                Int32 docListFormatKey = DocListFormatList[0].DocListFormatID;
                blnTranStarted = true;
                if (DocListFormatList[0].IsAdded)
                    docListFormatKey = Convert.ToInt32(conManager.InsertData(blnTranStarted, DocListFormatList));
                 else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, DocListFormatList);
                var docListFormatDetail = (CustomList<CmnDocListFormatDetail>)DocListFormatDetailList;
                docListFormatDetail.ForEach(x => x.DocListFormatID = docListFormatKey);
                conManager.SaveDataCollectionThroughCollection(blnTranStarted, docListFormatDetail);

                DocListFormatList.AcceptChanges();
                DocListFormatDetailList.AcceptChanges();

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
       //private void GetNewDocListFormatID(ref ConnectionManager conManager, CustomList<CmnDocListFormat> lstCmnDocListFormat, CustomList<CmnDocListFormatDetail> lstCmnDocListFormatDetail)
       //{
       //    String newFormatID = String.Empty;
       //    try
       //    {
       //        CustomList<CmnDocListFormat> tempDocListFormatList = lstCmnDocListFormat.FindAll(f => f.IsAdded);
       //        if (tempDocListFormatList.Count != 0)
       //        {
       //            newFormatID = StaticInfo.MakeUniqueCode("SecurityRuleCode", 20, DateTime.Today.ToString(), "yy", "SR", "-", "");

       //            lstCmnDocListFormat[0].DocListFormatID = newFormatID;
       //        }
       //        else
       //        {
       //            newFormatID = lstCmnDocListFormat[0].DocListFormatID;
       //        }

       //        CustomList<RuleDetails> tempSecurityRuleDetailList = securityRuleDetailList.FindAll(f => f.IsAdded);
       //        foreach (RuleDetails sRO in tempSecurityRuleDetailList)
       //        {
       //            sRO.SecurityRuleCode = securityRuleList[0].SecurityRuleCode;
       //        }
       //    }
       //    catch (Exception ex)
       //    {

       //        throw ex;
       //    }

       //}
       private void ReSetSPName(CustomList<CmnDocListFormat> lstCmnDocListFormat, CustomList<CmnDocListFormatDetail> lstCmnDocListFormatDetail)
        {
            #region Segment Name
            lstCmnDocListFormat.InsertSpName = "spInsertCmnDocListFormat";
            lstCmnDocListFormat.UpdateSpName = "spUpdateCmnDocListFormat";
            lstCmnDocListFormat.DeleteSpName = "spDeleteCmnDocListFormat";
            #endregion
            #region Segment Value
            lstCmnDocListFormatDetail.InsertSpName = "spInsertCmnDocListFormatDetail";
            lstCmnDocListFormatDetail.UpdateSpName = "spUpdateCmnDocListFormatDetail";
            lstCmnDocListFormatDetail.DeleteSpName = "spDeleteCmnDocListFormatDetail";
            #endregion
        }
    }
}
