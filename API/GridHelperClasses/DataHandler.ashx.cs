using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using API.DATA;
using System.Data.SqlClient;
using SECURITY.BLL;
using SECURITY.DAO;
using STATIC;
using API.DAO;
using API.BLL;
using REPORT.BLL;
using REPORT.DAO;
using FRAMEWORK;
using System.Text.RegularExpressions;
using Enc = STATIC.EncDec;
using API.DAL;
using ACC.BLL;
using ACC.DAO;


namespace API.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class DataHandler : IHttpHandler, IRequiresSessionState
    {
        private String SessionVarName { get; set; }
        private DataCallBackMode callBackMode;
        private DataCallBackMode DataCallMode
        {
            get
            {
                ResolveCallBackMode();
                return callBackMode;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                CallbackFunction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ResolveCallBackMode()
        {
            try
            {
                String callMode = HttpContext.Current.Request.QueryString["CallMode"];
                callBackMode = (DataCallBackMode)StaticInfo.GetEnumValue(typeof(DataCallBackMode), callMode);
                if (callMode.CompareTo("DuplicateBankNameCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateBankNameCheck;
                }
                else if (callMode.CompareTo("getRowCount").IsZero())
                {
                    callBackMode = DataCallBackMode.getRowCount;
                }
                else if (callMode.CompareTo("AllSelectOrUnselect").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectOrUnselect;
                }
                else if (callMode.CompareTo("ShowAllCheckOrUncheck").IsZero())
                {
                    callBackMode = DataCallBackMode.ShowAllCheckOrUncheck;
                }
                else if (callMode.CompareTo("PopulateGrideWithMenu").IsZero())
                {
                    callBackMode = DataCallBackMode.PopulateGrideWithMenu;
                }
                else if (callMode.CompareTo("AllSelectCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllSelectCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllInsertCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllInsertCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllUpdateCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllUpdateCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("AllDeleteCheckedOrUnchecked").IsZero())
                {
                    callBackMode = DataCallBackMode.AllDeleteCheckedOrUnchecked;
                }
                else if (callMode.CompareTo("MenuAllCheckOrUncheck").IsZero())
                {
                    callBackMode = DataCallBackMode.MenuAllCheckOrUncheck;
                }
                else if (callMode.CompareTo("DateDifference").IsZero())
                {
                    callBackMode = DataCallBackMode.DateDifference;
                }
                else if (callMode.CompareTo("FilterByEntityType").IsZero())
                {
                    callBackMode = DataCallBackMode.FilterByEntityType;
                }
                else if (callMode.CompareTo("DuplicateEntityNameCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateEntityNameCheck;
                }
                else if (callMode.CompareTo("GetFromDateAndToDate").IsZero())
                {
                    callBackMode = DataCallBackMode.GetFromDateAndToDate;
                }
                else if (callMode.CompareTo("LatestNews").IsZero())
                {
                    callBackMode = DataCallBackMode.LatestNews;
                }
                else if (callMode.CompareTo("ChangePassword").IsZero())
                {
                    callBackMode = DataCallBackMode.ChangePassword;
                }
                else if (callMode.CompareTo("DuplicateFiscalYearCheck").IsZero())
                {
                    callBackMode = DataCallBackMode.DuplicateFiscalYearCheck;
                }
                else if (callMode.CompareTo("CheckAllIndividual").IsZero())
                {
                    callBackMode = DataCallBackMode.CheckAllIndividual;
                }
                else if (callMode.CompareTo("_SearchByEmpCodeToSetEmail").IsZero())
                {
                    callBackMode = DataCallBackMode._SearchByEmpCodeToSetEmail;
                }
                else if (callMode.CompareTo("CheckAllSupervisor").IsZero())
                {
                    callBackMode = DataCallBackMode.CheckAllSupervisor;
                }
                else if (callMode.CompareTo("ItemSegment").IsZero())
                {
                    callBackMode = DataCallBackMode.ItemSegment;
                }
                else if (callMode.CompareTo("ItemStructure").IsZero())
                {
                    callBackMode = DataCallBackMode.ItemStructure;
                }
                else if (callMode.CompareTo("deptWiseGroup").IsZero())
                {
                    callBackMode = DataCallBackMode.deptWiseGroup;
                }
                else if (callMode.CompareTo("GetRequisitionDetail").IsZero())
                {
                    callBackMode = DataCallBackMode.GetRequisitionDetail;
                }
                else if (callMode.CompareTo("GetRefTransDetail").IsZero())
                {
                    callBackMode = DataCallBackMode.GetRefTransDetail;
                }
                else if (callMode.CompareTo("GetRefDetail").IsZero())
                {
                    callBackMode = DataCallBackMode.GetRefDetail;
                }
                else if (callMode.CompareTo("ParentList").IsZero())
                {
                    callBackMode = DataCallBackMode.ParentList;
                }
                else if (callMode.CompareTo("CheckTransaction").IsZero())
                {
                    callBackMode = DataCallBackMode.CheckTransaction;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CallbackFunction()
        {
            try
            {
                switch (DataCallMode)
                {
                    case DataCallBackMode.getRowCount:
                        getRowCount();
                        return;
                    case DataCallBackMode.SetSelectedParameterValueInParameterGrid:
                        SetSelectedParameterValueInParameterGrid();
                        return;
                    case DataCallBackMode.InitParameterTableValue:
                        InitParameterTableValue();
                        return;
                    case DataCallBackMode.PopulateGrideWithMenu:
                        PopulateGrideWithMenu();
                        return;
                    case DataCallBackMode.AllSelectCheckedOrUnchecked:
                        AllSelectCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllInsertCheckedOrUnchecked:
                        AllInsertCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllUpdateCheckedOrUnchecked:
                        AllUpdateCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.AllDeleteCheckedOrUnchecked:
                        AllDeleteCheckedOrUnchecked();
                        return;
                    case DataCallBackMode.MenuAllCheckOrUncheck:
                        MenuAllCheckOrUncheck();
                        return;
                    case DataCallBackMode.DateDifference:
                        DateDifference();
                        return;
                    case DataCallBackMode.DuplicateEntityNameCheck:
                        DuplicateEntityNameCheck();
                        return;
                    case DataCallBackMode.AllSelectOrAllClearEmp:
                        AllSelectOrAllClearEmp();
                        return;
                    case DataCallBackMode.ShowAllCheckOrUncheck:
                        ShowAllCheckOrUncheck();
                        return;
                    case DataCallBackMode.FilterByEntityType:
                        FilterByEntityType();
                        return;
                    case DataCallBackMode.LatestNews:
                        LatestNews();
                        return;
                    case DataCallBackMode.ChangePassword:
                        ChangePassword();
                        return;
                    case DataCallBackMode.DuplicateFiscalYearCheck:
                        DuplicateFiscalYearCheck();
                        return;
                    case DataCallBackMode.CheckAllIndividual:
                        CheckAllIndividual();
                        return;
                    case DataCallBackMode._SearchByEmpCodeToSetEmail:
                        _SearchByEmpCodeToSetEmail();
                        return;
                    case DataCallBackMode.CheckAllSupervisor:
                        CheckAllSupervisor();
                        return;
                    case DataCallBackMode.ItemSegment:
                        ItemSegment();
                        return;
                    case DataCallBackMode.ItemStructure:
                        ItemStructure();
                        return;
                    case DataCallBackMode.ItemGroupWiseDeptMaping:
                        ItemGroupWiseDeptMaping();
                        return;
                    case DataCallBackMode.deptWiseGroup:
                        deptWiseGroup();
                        return;
                    case DataCallBackMode.GetRequisitionDetail:
                        GetRequisitionDetail();
                        return;
                    case DataCallBackMode.GetRefTransDetail:
                        GetRefTransDetail();
                        return;
                    case DataCallBackMode.GetRefDetail:
                        GetRefDetail();
                        return;
                    case DataCallBackMode.ParentList:
                        ParentList();
                        return;
                    case DataCallBackMode.CheckTransaction:
                        CheckTransaction();
                        return;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CheckTransaction()
        {
            try
            {
                String retString = "";
                String menuName = HttpContext.Current.Request.QueryString["menuName"];
                CustomList<Acc_VoucherDet> voucherDetList = (CustomList<Acc_VoucherDet>)HttpContext.Current.Session[menuName+"_AccVoucherDetList"];
                retString = voucherDetList.Count.ToString();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(retString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetRefDetail()
        {
            try
            {
                String test = String.Empty;
                Int64 stockID = Convert.ToInt64(HttpContext.Current.Request.QueryString["stockID"]);
                String stockTest = HttpContext.Current.Request.QueryString["stockTest"];
                String menuName = HttpContext.Current.Request.QueryString["menuName"];
                String transTypeID = HttpContext.Current.Request.QueryString["transTypeID"];
                String refTypeTest = HttpContext.Current.Request.QueryString["refTypeTest"];
                String refNo = HttpContext.Current.Request.QueryString["refNo"];


                CustomList<StockTransactionDetail> ExistingTransDetailList = (CustomList<StockTransactionDetail>)HttpContext.Current.Session[menuName + "_StockTransactionDetailList"];
                if (transTypeID == "3")
                {
                    POManager manager = new POManager();
                    CustomList<PODetail> PODetailList = manager.GetAllPODetail(stockID);
                    foreach (PODetail IR in PODetailList)
                    {
                        StockTransactionDetail obj = new StockTransactionDetail();
                        obj.ItemGroupID = IR.ItemGroupID;
                        obj.ItemSubGroupID = IR.ItemSubGroupID;
                        obj.ItemCode = IR.ItemCode;
                        obj.UOMID = IR.UOMID;
                        obj.ItemQty = IR.ItemQty;
                        obj.UnitPrice = IR.UnitPrice;
                        if (transTypeID.IsNotNullOrEmpty())
                            obj.SourceReferenceTypeID = transTypeID.ToInt();
                        obj.SourceReferenceType = refTypeTest;
                        obj.SourceReference = stockTest;
                        obj.SourceReferenceID = stockID;
                        obj.SourceReferenceNo = refNo;
                        ExistingTransDetailList.Add(obj);
                    }
                }
                else
                {
                    StockTransactionManager manager = new StockTransactionManager();
                    CustomList<StockTransactionDetail> DetailList = manager.GetAllStockTransactionDetail(stockID);
                    foreach (StockTransactionDetail RD in DetailList)
                    {
                        if (transTypeID.IsNotNullOrEmpty())
                            RD.SourceReferenceTypeID = transTypeID.ToInt();
                        RD.SourceReferenceType = refTypeTest;
                        RD.SourceReference = stockTest;
                        RD.SourceReferenceID = stockID;
                        RD.SourceReferenceNo = refNo;
                        RD.SetAdded();
                        ExistingTransDetailList.Add(RD);
                    }
                }
                HttpContext.Current.Session[menuName + "_StockTransactionDetailList"] = ExistingTransDetailList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(test);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetRefTransDetail()
        {
            try
            {
                String test = String.Empty;
                RequisitionManager manager = new RequisitionManager();
                Int64 RefID = Convert.ToInt64(HttpContext.Current.Request.QueryString["RefID"]);
                String POTest = HttpContext.Current.Request.QueryString["POTest"];
                String refTypeID = HttpContext.Current.Request.QueryString["refTypeID"];
                String refTypeTest = HttpContext.Current.Request.QueryString["refTypeTest"];
                String refNo = HttpContext.Current.Request.QueryString["refNo"];
                CustomList<ItemRequisitionDetail> ItemRequisitionDetailList = manager.GetAllItemRequisitionDetail(RefID);
                CustomList<PODetail> ExistingPODetailList = (CustomList<PODetail>)HttpContext.Current.Session["PO_PODetailList"];
                foreach (ItemRequisitionDetail IR in ItemRequisitionDetailList)
                {
                    PODetail obj = new PODetail();
                    obj.ItemGroupID = IR.ItemGroupID;
                    obj.ItemSubGroupID = IR.ItemSubGroupID;
                    obj.ItemCode = IR.ItemCode;
                    obj.UOMID = IR.UOMID;
                    obj.ItemQty = IR.ItemQty;
                    obj.UnitPrice = IR.UnitPrice;

                    if (refTypeID.IsNotNullOrEmpty())
                        obj.SourceReferenceTypeID = refTypeID.ToInt();
                    obj.SourceReferenceType = refTypeTest;
                    obj.SourceReference = POTest;
                    obj.SourceReferenceID = RefID;
                    obj.SourceReferenceNo = refNo;
                    ExistingPODetailList.Add(obj);
                }
                HttpContext.Current.Session["PO_PODetailList"] = ExistingPODetailList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(test);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void GetRequisitionDetail()
        {
            try
            {
                String test = String.Empty;
                RequisitionManager manager = new RequisitionManager();
                Int64 requisitionID = Convert.ToInt64(HttpContext.Current.Request.QueryString["requisitionID"]);
                String menuName = HttpContext.Current.Request.QueryString["menuName"];
                String requisitionTest = HttpContext.Current.Request.QueryString["requisitionTest"];
                String refTypeID = HttpContext.Current.Request.QueryString["refTypeID"];
                String refTypeTest = HttpContext.Current.Request.QueryString["refTypeTest"];
                String refNo = HttpContext.Current.Request.QueryString["refNo"];

                CustomList<ItemRequisitionDetail> RequisitionDetailList = manager.GetAllItemRequisitionDetail(requisitionID);
                CustomList<ItemRequisitionDetail> ExistingRequisitionDetailList = (CustomList<ItemRequisitionDetail>)HttpContext.Current.Session[menuName + "_ItemRequisitionDetailList"];
                foreach (ItemRequisitionDetail RD in RequisitionDetailList)
                {
                    if (refTypeID.IsNotNullOrEmpty())
                        RD.SourceReferenceTypeID = refTypeID.ToInt();
                    RD.SourceReferenceType = refTypeTest;
                    RD.SourceReference = requisitionTest;
                    RD.SourceReferenceID = requisitionID;
                    RD.SourceReferenceNo = refNo;
                    RD.SetAdded();
                    ExistingRequisitionDetailList.Add(RD);
                }
                HttpContext.Current.Session[menuName + "_ItemRequisitionDetailList"] = ExistingRequisitionDetailList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(test);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void deptWiseGroup()
        {
            try
            {
                String test = String.Empty;
                GroupItemManager manager = new GroupItemManager();
                String deptID = HttpContext.Current.Request.QueryString["deptID"];
                CustomList<ItemGroup> lstItemGroupDeptMaping = manager.DeptWiseItemGroup(Convert.ToInt32(deptID));
                HttpContext.Current.Session["ItemRequisition_ItemGroupList"] = lstItemGroupDeptMaping;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(test);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ItemGroupWiseDeptMaping()
        {
            try
            {
                String test = String.Empty;
                ItemGroupDeptMapingManager manager = new ItemGroupDeptMapingManager();
                String itemGroupID = HttpContext.Current.Request.QueryString["itemGroupID"];
                CustomList<ItemGroupDeptMaping> lstItemGroupDeptMaping = manager.GetAllItemGroupDeptMaping(itemGroupID);
                CustomList<ItemGroupDeptMaping> ItemGroupDeptMapingList = (CustomList<ItemGroupDeptMaping>)HttpContext.Current.Session["ItemGroup_DetpMaping_ItemGroupDeptMapingList"];
                foreach (ItemGroupDeptMaping iGDM in lstItemGroupDeptMaping)
                {
                    ItemGroupDeptMaping obj = ItemGroupDeptMapingList.Find(f => f.DeptID == iGDM.DeptID);
                    if (obj.IsNotNull())
                    {
                        obj.IsChecked = true;
                        obj.ItemGroupID = iGDM.ItemGroupID;
                        obj.ID = iGDM.ID;
                    }
                }
                HttpContext.Current.Session["ItemGroup_DetpMaping_ItemGroupDeptMapingList"] = ItemGroupDeptMapingList;
                HttpContext.Current.Session["ItemGroup_DetpMaping_GroupWiseSavedList"] = lstItemGroupDeptMaping;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(test);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ItemStructure()
        {
            String refSourceString = String.Empty;
            ItemStructureManager manager = new ItemStructureManager();
            String itemGroupID = HttpContext.Current.Request.QueryString["itemGroupID"];
            HttpContext.Current.Session["Item_Structure_ItemStructureList"] = manager.GetAllItemStructure(Convert.ToInt32(itemGroupID));

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Write(refSourceString);
            HttpContext.Current.Response.Flush();
        }
        private void ItemSegment()
        {
            String refSourceString = String.Empty;
            ItemSegmentManager manager = new ItemSegmentManager();
            String segmentNameID = HttpContext.Current.Request.QueryString["SegmentNameID"];
            HttpContext.Current.Session["ItemSegments_SegmentValuesList"] = manager.GetAllSegmentValues(Convert.ToInt32(segmentNameID));

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "text/plain";
            HttpContext.Current.Response.Write(refSourceString);
            HttpContext.Current.Response.Flush();
        }
        private void CheckAllHOD()
        {
            try
            {
                String response = String.Empty;

                MailSetupManager manager = new MailSetupManager();
                CustomList<MailSetup> EmailList = (CustomList<MailSetup>)HttpContext.Current.Session["MailSetup_MailSetupList"];
                CustomList<MailSetup> HODList = manager.GetAllHOD();
                String isHOD = HttpContext.Current.Request.QueryString["IsHOD"];
                EmailList.ForEach(s => s.IsChecked = false);
                if (isHOD == "true")
                {
                    foreach (MailSetup mS in EmailList)
                    {
                        MailSetup objMailSetup = HODList.Find(f => f.EmpKey == mS.EmpKey);
                        if (mS.EmailAddress.Trim().IsNotNullOrEmpty() && objMailSetup.IsNotNull())
                        {
                            mS.IsChecked = true;
                        }
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CheckAllSupervisor()
        {
            try
            {
                String response = String.Empty;

                MailSetupManager manager = new MailSetupManager();
                CustomList<MailSetup> EmailList = (CustomList<MailSetup>)HttpContext.Current.Session["MailSetup_MailSetupList"];
                CustomList<MailSetup> SupervisorList = manager.GetAllSupervisor();
                String isSupervisor = HttpContext.Current.Request.QueryString["IsSupervisor"];
                EmailList.ForEach(s => s.IsChecked = false);
                if (isSupervisor == "true")
                {
                    foreach (MailSetup mS in EmailList)
                    {
                        MailSetup objMailSetup = SupervisorList.Find(f => f.EmpKey == mS.EmpKey);
                        if (mS.EmailAddress.Trim().IsNotNullOrEmpty() && objMailSetup.IsNotNull())
                        {
                            mS.IsChecked = true;
                        }
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void CheckAllIndividual()
        {
            try
            {
                String response = String.Empty;

                CustomList<MailSetup> EmailList = (CustomList<MailSetup>)HttpContext.Current.Session["MailSetup_MailSetupList"];
                String isIndividual = HttpContext.Current.Request.QueryString["IsIndividual"];
                EmailList.ForEach(s => s.IsChecked = false);
                if (isIndividual == "true")
                {
                    foreach (MailSetup mS in EmailList)
                    {
                        if (mS.EmailAddress.Trim().IsNotNullOrEmpty())
                            mS.IsChecked = true;
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateFiscalYearCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String FYName = HttpContext.Current.Request.QueryString["FYName"];
                String VID = HttpContext.Current.Request.QueryString["VID"];
                String Orgkey = HttpContext.Current.Request.QueryString["Orgkey"];
                String SDate = HttpContext.Current.Request.QueryString["SDate"];
                String EDate = HttpContext.Current.Request.QueryString["EDate"];
                CustomList<Gen_FY> List = (CustomList<Gen_FY>)HttpContext.Current.Session["FiscalYear_Gen_FYList"];


                CustomList<Gen_FY> objlist;
                if (VID == "-1")

                    objlist = List.FindAll(p =>
                                (p.OrgKey == Orgkey.ToInt())
                                &&
                                (
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                                 )
                            );
                else
                    objlist = List.FindAll(p =>
                                (p.OrgKey == Orgkey.ToInt())
                                &&
                                (p.VID != VID.ToInt())
                                &&
                                (
                                    (p.FYName == FYName)
                                    ||
                                    (
                                        ((SDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate) && (SDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                        ||
                                    //(EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate) && EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate)
                                        ((EDate.ToDateTime(StaticInfo.GridDateFormat) >= p.SDate)) && (EDate.ToDateTime(StaticInfo.GridDateFormat) <= p.EDate))
                                    )
                             );

                if (objlist.Count > 0)
                {
                    refSourceString = "Duplicate";
                }


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ChangePassword()
        {
            String refSourceString = String.Empty;
            try
            {
                User currentUser = (User)HttpContext.Current.Session["CurrentUserSession"];

                String oldPass = HttpContext.Current.Request.QueryString["OldPassword"];
                String newPass = HttpContext.Current.Request.QueryString["NewPassword"];

                string passwordOld = Enc.Encrypt(oldPass.Trim(), STATIC.StaticInfo.encString);
                string passwordNew = Enc.Encrypt(newPass.Trim(), STATIC.StaticInfo.encString);

                String savedPassword = currentUser.Password;

                if (savedPassword == passwordOld)
                {
                    ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
                    String sql = "Update [User] Set Password = '" + passwordNew + "' where UserCode = '" + currentUser.UserCode + "'";
                    conManager.ExecuteNonQueryWrapper(sql);
                    refSourceString = "True," + "Saved Successfully.";
                }
                else
                {
                    refSourceString = "False," + "Old password do not match.";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                refSourceString = "False," + ex.Message;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
                //throw ex;
            }
        }
        private void LatestNews()
        {
            try
            {
                String refSourceString = String.Empty;
                LatestNewsManager manager = new LatestNewsManager();
                CustomList<LatestNews> LatestNewsList = new CustomList<LatestNews>();
                LatestNewsList = manager.GetAllLatestNewsForDisplay();
                foreach (LatestNews lN in LatestNewsList)
                {
                    if (refSourceString.IsNullOrEmpty())
                        refSourceString = lN.NewsDetails;
                    else
                        refSourceString = refSourceString + "," + lN.NewsDetails;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void FilterByEntityType()
        {
            try
            {
                String refSourceString = String.Empty;

                String entityType = HttpContext.Current.Request.QueryString["EntityType"];
                CustomList<Gen_LookupEnt> LookupEntListByEntityTypte = new CustomList<Gen_LookupEnt>();
                CustomList<Gen_LookupEnt> LookupEntList = (CustomList<Gen_LookupEnt>)HttpContext.Current.Session["LookupEnt_LookupEntList"];
                LookupEntListByEntityTypte = LookupEntList.FindAll(f => f.EntityKey == entityType.ToInt());
                HttpContext.Current.Session["LookupEnt_LookupEntListByEntityType"] = LookupEntListByEntityTypte;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void _SearchByEmpCodeToSetEmail()
        {
            try
            {
                String refSourceString = String.Empty;
                String selectionCriteria = HttpContext.Current.Request.QueryString["SelectionCriteria"];
                String empCode = HttpContext.Current.Request.QueryString["EmpCode"];
                CustomList<MailSetup> MailSetupList = (CustomList<MailSetup>)HttpContext.Current.Session["MailSetup_MailSetupList"];
                MailSetup item = new MailSetup();
                switch (selectionCriteria)
                {
                    case "EmpCode":
                        item = MailSetupList.Find(f => f.EmpCode.ToUpper() == empCode.ToUpper());
                        if (item.EmailAddress.Trim() == "")
                            break;
                        MailSetupList.Remove(item);
                        MailSetupList.Insert(0, item);
                        break;
                }
                if (item.IsNull() || item.EmailAddress.Trim() == "")
                    refSourceString = "false";
                else
                    item.IsChecked = true;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ShowAllCheckOrUncheckUserWiseEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                String sessionVarNameSubGrid = HttpContext.Current.Request.QueryString["SessionVarNameSubGrid"];
                String userCode = HttpContext.Current.Request.QueryString["UserCode"];
                IEnumerable Items = (IEnumerable)HttpContext.Current.Session[sessionVarName];
                IList SubGridEmpList = (IList)HttpContext.Current.Session[sessionVarNameSubGrid];
                CustomList<BaseItem> baseItems = Items.ToCustomList<BaseItem>();
                foreach (BaseItem bi in baseItems)
                {
                    object check = bi.GetType().GetProperty("IsChecked").GetValue(bi, null);
                    object addedBy = bi.GetType().GetProperty("UserCode").GetValue(bi, null);
                    if (addedBy.ToString() == userCode)
                    {
                        foreach (Object O in SubGridEmpList)
                        {
                            object addedBySubGrid = O.GetType().GetProperty("AddedBy").GetValue(O, null);
                            if (addedBySubGrid.ToString() == userCode)
                            {
                                O.GetType().GetProperty("IsChecked").SetValue(O, Convert.ToBoolean(check), null);
                                //object checkSubGrid = O.GetType().GetProperty("IsChecked").GetValue(O, null);
                                //if (!Convert.ToBoolean(checkSubGrid))
                                //{
                                //    refSourceString = "False";
                                //}
                            }
                        }
                    }
                    if (!Convert.ToBoolean(check))
                    {
                        refSourceString = "True";
                    }

                }


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void ShowAllCheckOrUncheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                IEnumerable Items = (IEnumerable)HttpContext.Current.Session[sessionVarName];
                CustomList<BaseItem> baseItems = Items.ToCustomList<BaseItem>();
                foreach (BaseItem bi in baseItems)
                {
                    object check = bi.GetType().GetProperty("IsChecked").GetValue(bi, null);
                    if (!Convert.ToBoolean(check))
                    {
                        refSourceString = "True";
                        break;
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void AllSelectOrAllClearEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                //CustomList<HRM_Emp> EmpList = (CustomList<HRM_Emp>)HttpContext.Current.Session[StaticInfo.EmpListSessionVarName];
                IList EmpList = (IList)HttpContext.Current.Session[sessionVarName];
                foreach (Object O in EmpList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                HttpContext.Current.Session[sessionVarName] = EmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllSelectOrAllClearUserWiseEmp()
        {
            try
            {
                String refSourceString = String.Empty;
                String status = HttpContext.Current.Request.QueryString["Status"];
                String sessionVarName = HttpContext.Current.Request.QueryString["SessionVarName"];
                String sessionVarNameSubGrid = HttpContext.Current.Request.QueryString["SessionVarNameSubGrid"];
                IList ParentUserList = (IList)HttpContext.Current.Session[sessionVarName];
                IList SubGridEmpList = (IList)HttpContext.Current.Session[sessionVarNameSubGrid];
                foreach (Object O in ParentUserList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                foreach (Object O in SubGridEmpList)
                {
                    O.GetType().GetProperty("IsChecked").SetValue(O, status.ToBoolean(), null);
                }
                HttpContext.Current.Session[sessionVarName] = ParentUserList;
                HttpContext.Current.Session[sessionVarNameSubGrid] = SubGridEmpList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void InitParameterTableValue()
        {
            try
            {
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                ParameterValueManager manager = new ParameterValueManager();
                String response = "TRUE";

                //Filter
                CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                CustomList<ParameterFilterValue> filterValueList = new CustomList<ParameterFilterValue>();
                SetValue();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Response.Write(ex);
            }
        }
        private void SetValue()
        {
            try
            {
                DataTable dtParamValues = null;
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                String displayColumnName = String.Format("{0}DisplayMember", columnName);
                String actualValuesColumnName = String.Format("{0}ActualValues", columnName);
                CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                if (columnName.IsNotNullOrEmpty())
                {
                    CustomList<ParameterFilterValue> filterValueList = new CustomList<ParameterFilterValue>();
                    DataSet ParameterValues = (DataSet)HttpContext.Current.Session["ReportViewer_ParameterValues"];
                    if (ParameterValues.Tables["ParameterValues"].Columns.Contains(columnName))
                    {
                        if (ParameterValues.Tables["ParameterValues"].Columns.Contains(actualValuesColumnName))
                            dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName, actualValuesColumnName);
                        else
                        {
                            dtParamValues = ParameterValues.Tables["ParameterValues"].DefaultView.ToTable(true, columnName);
                            displayColumnName = columnName;
                        }
                        foreach (DataRow dr in dtParamValues.Rows)
                        {
                            filterValueList.Add(new ParameterFilterValue { Values = dr[columnName].ToString(), DisplayMember = dr[columnName].ToString(), ActualValues = dr[actualValuesColumnName].ToString() });
                        }
                    }
                    HttpContext.Current.Session["ReportViewer_FilterValueList"] = filterValueList;
                }
                return;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetSelectedParameterValueInParameterGrid()
        {
            try
            {
                String vid = HttpContext.Current.Request.QueryString["vid"];
                String selectedVids = HttpContext.Current.Request.QueryString["SelectedVids"];
                String response = "TRUE";
                String selectedValues = String.Empty;
                String selectedActualValues = String.Empty;
                if (vid.IsNotNullOrEmpty() && selectedVids.IsNotNullOrEmpty())
                {
                    CustomList<FilterSets> filterSetList = (CustomList<FilterSets>)HttpContext.Current.Session["ReportViewer_FilterSetList"];
                    CustomList<ParameterFilterValue> FilterValueList = (CustomList<ParameterFilterValue>)HttpContext.Current.Session["ReportViewer_FilterValueList"];

                    FilterSets filterItem = filterSetList.Find(item => item.VID == vid.ToInt());
                    if (filterItem.IsNotNull())
                    {
                        String[] vidList = selectedVids.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        CustomList<ParameterFilterValue> searchList = FilterValueList.FindAll(p => vidList.Contains(p.VID.ToString()));
                        if (searchList.Count > 1)
                        {
                            foreach (ParameterFilterValue param in searchList)
                            {
                                selectedValues += String.Format("{0},", param.Values);
                                selectedActualValues += String.Format("{0},", param.ActualValues);
                            }
                            filterItem.Operators = "In";
                            if (selectedValues.IsNotNullOrEmpty())
                                selectedValues = selectedValues.Substring(0, selectedValues.Length - 1);
                            if (selectedActualValues.IsNotNullOrEmpty())
                                selectedActualValues = selectedActualValues.Substring(0, selectedActualValues.Length - 1);
                        }
                        else
                        {
                            foreach (ParameterFilterValue param in searchList)
                            {
                                selectedValues = param.Values;
                                selectedActualValues = param.ActualValues;
                            }
                        }
                        filterItem.ColumnValue = selectedValues;
                        filterItem.ColumnActualValue = selectedActualValues;
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ParentList()
        {
            try
            {
                String refSourceString = String.Empty;
                String entityKey = HttpContext.Current.Request.QueryString["EntityKey"];
                HKEntryManager manager = new HKEntryManager();
                //CustomList<HouseKeepingValue> HKValueList = new CustomList<HouseKeepingValue>();
                //HttpContext.Current.Session["HouseKeepingEntry_ParentList"] = HKValueList;

                //Int32 parent = manager.GetAllEntityList(entityKey);
                //if (parent != 0)
                //{
                CustomList<HouseKeepingValue> HKList = manager.GetAllHouseKeepingValue(entityKey);
                HttpContext.Current.Session["HouseKeepingEntry_ParentList"] = HKList;
                //}

                // refSourceString = parent.ToString();

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void DuplicateEntityNameCheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String entityName = HttpContext.Current.Request.QueryString["EntityName"];
                String vid = HttpContext.Current.Request.QueryString["VID"];
                CustomList<EntityList> EntityList = (CustomList<EntityList>)HttpContext.Current.Session["Entity_EntityList"];

                EntityList entityNameObj = EntityList.Find(f => f.EntityName.ToLower() == entityName.ToLower() && f.VID != vid.ToInt());
                EntityList chkAdded = EntityList.Find(f => f.EntityName.ToLower() == entityName.ToLower() && f.VID != vid.ToInt() && f.IsAdded);
                if ((entityNameObj.IsNotNull() && !entityNameObj.IsDeleted) || (entityNameObj.IsNotNull() && chkAdded.IsNotNull()))
                {
                    refSourceString = "True";
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #region DateDifference
        private void DateDifference()
        {
            try
            {
                String response = "";
                String strStartDate = HttpContext.Current.Request.QueryString["StartDate"];
                String strEndDate = HttpContext.Current.Request.QueryString["EndDate"];

                if (String.IsNullOrEmpty(strStartDate) == false && String.IsNullOrEmpty(strEndDate) == false)
                {
                    if (strStartDate != "" && strEndDate != "")
                    {
                        TimeSpan ts = (strEndDate.ToDateTime(STATIC.StaticInfo.GridDateFormat) - strStartDate.ToDateTime(STATIC.StaticInfo.GridDateFormat));
                        response = ts.Days.ToString();
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
        private void MenuAllCheckOrUncheck()
        {
            try
            {
                String refSourceString = String.Empty;
                String columnName = HttpContext.Current.Request.QueryString["ColumnName"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                if (columnName == "CanInsert")
                {
                    Menu objInsert = MenuList.Find(f => f.CanInsert == false);
                    if (objInsert.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanSelect")
                {
                    Menu objSelect = MenuList.Find(f => f.CanSelect == false);
                    if (objSelect.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanUpdate")
                {
                    Menu objUpdate = MenuList.Find(f => f.CanUpdate == false);
                    if (objUpdate.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }
                else if (columnName == "CanDelete")
                {
                    Menu objDelete = MenuList.Find(f => f.CanDelete == false);
                    if (objDelete.IsNotNull())
                    {
                        refSourceString = "True";
                    }
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllDeleteCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanDelete = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void AllUpdateCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanUpdate = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void AllInsertCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanInsert = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void AllSelectCheckedOrUnchecked()
        {
            try
            {
                String refSourceString = String.Empty;
                String chkOrUnUnchk = HttpContext.Current.Request.QueryString["ChkOrUnchk"];
                CustomList<Menu> MenuList = (CustomList<Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                foreach (Menu m in MenuList)
                {
                    m.CanSelect = chkOrUnUnchk.ToBoolean();
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
        }
        private void PopulateGrideWithMenu()
        {
            try
            {
                SecurityManager manager = new SecurityManager();
                String response = String.Empty;
                String applicationID = HttpContext.Current.Request.QueryString["ApplicationID"];
                CustomList<SECURITY.DAO.Menu> menu = manager.GetAllMenuByApplicationID(applicationID.ToString());
                CustomList<Menu> MenuList = new CustomList<Menu>();
                MenuList = menu.FindAll(f => f.FormName != "");
                CustomList<RuleDetails> SecurityRuleDetailList = (CustomList<RuleDetails>)HttpContext.Current.Session["SecurityRule_SecurityRuleDetailList"];
                foreach (SECURITY.DAO.Menu m in MenuList)
                {
                    CustomList<RuleDetails> tSROList = SecurityRuleDetailList.FindAll(f => f.ObjectID == m.MenuID && f.ApplicationID == m.ApplicationID);
                    foreach (RuleDetails tSRO in tSROList)
                    {
                        m.CanInsert = tSRO.CanInsert;
                        m.CanSelect = tSRO.CanSelect;
                        m.CanUpdate = tSRO.CanUpdate;
                        m.CanDelete = tSRO.CanDelete;
                    }
                }
                HttpContext.Current.Session["SecurityRule_MenuList"] = MenuList;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(response);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void getRowCount()
        {
            try
            {
                int retVal = 0;
                String sessionname = HttpContext.Current.Request.QueryString["sessionName"];
                IEnumerable ien = (IEnumerable)HttpContext.Current.Session[sessionname];

                if (ien == null)
                {
                    retVal = 0;
                }
                else
                {
                    CustomList<BaseItem> obj = ien.ToCustomList<BaseItem>();
                    retVal = obj.Count;
                }

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(retVal + 1);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void ProManSys_Checked()
        {
            try
            {
                String refSourceString = String.Empty;
                CustomList<RuleDetails> SecurityRuleDetailList = new CustomList<RuleDetails>();
                CustomList<SECURITY.DAO.Menu> MenuList = (CustomList<SECURITY.DAO.Menu>)HttpContext.Current.Session["SecurityRule_MenuList"];
                CustomList<TempRuleDetails> TempSecurityRuleDetailList = (CustomList<TempRuleDetails>)HttpContext.Current.Session["SecurityRule_TempSecurityRuleDetailList"];
                string hfApplicationID = (string)HttpContext.Current.Session["ApplicationID"];
                string PersonName = (string)HttpContext.Current.Session["PersonName"];
                string CompanyID = (string)HttpContext.Current.Session["CompanyID"];
                CustomList<SECURITY.DAO.Menu> SelectedMenuList = MenuList.FindAll(f => f.IsModified);
                foreach (SECURITY.DAO.Menu M in SelectedMenuList)
                {
                    if (M.CanInsert || M.CanSelect || M.CanUpdate || M.CanDelete)
                    {
                        RuleDetails objNewSRO = new RuleDetails();
                        objNewSRO.ApplicationID = M.ApplicationID;
                        objNewSRO.ObjectID = M.MenuID;
                        objNewSRO.ObjectType = "Menu";
                        objNewSRO.CanInsert = M.CanInsert;
                        objNewSRO.CanSelect = M.CanSelect;
                        objNewSRO.CanUpdate = M.CanUpdate;
                        objNewSRO.CanDelete = M.CanDelete;
                        SecurityRuleDetailList.Add(objNewSRO);
                    }
                }

                CustomList<Application> ApplicationList = (CustomList<Application>)HttpContext.Current.Session["SecurityRule_ApplicationList"];
                foreach (Application a in ApplicationList)
                {
                    CustomList<RuleDetails> upDate = SecurityRuleDetailList.FindAll(f => f.ApplicationID == a.ApplicationID);
                    CustomList<RuleDetails> newUpdate = new CustomList<RuleDetails>();
                    newUpdate = upDate.FindAll(f => f.CanInsert == true || f.CanSelect == true || f.CanUpdate == true || f.CanDelete == true);
                    if (newUpdate.Count != 0)
                        a.IsSaved = true;
                    else
                        a.IsSaved = false;
                }

                HttpContext.Current.Session["SecurityRule_MenuList"] = MenuList;
                HttpContext.Current.Session["SecurityRule_SecurityRuleDetailList"] = SecurityRuleDetailList;
                HttpContext.Current.Session["SecurityRule_TempSecurityRuleDetailList"] = TempSecurityRuleDetailList;
                HttpContext.Current.Session["SecurityRule_ApplicationList"] = ApplicationList;

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.Write(refSourceString);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
