using System;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using API.DATA;
using API.DAO;
using API.BLL;
using System.Text;

namespace API.GridHelperClasses
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MultiDropdownSource : IHttpHandler, IRequiresSessionState
    {
        public Boolean IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                String response = GenerateReturnString();
                context.Response.Clear();
                context.Response.ContentType = "text/plain";
                context.Response.Write(response);
                context.Response.Flush();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private String GenerateReturnString()
        {
            try
            {
                String mode = HttpContext.Current.Request.QueryString["mode"];
                String thisval = "";
                ItemMasterManager manager1 = new ItemMasterManager();
                switch (mode)
                {
                    case "onSelectMode_SubGroup":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        ItemSubGroupManager manager = new ItemSubGroupManager();
                        CustomList<ItemSubGroup> SubGroupList = (CustomList<ItemSubGroup>)HttpContext.Current.Session["ItemRequisition_ItemSubGroupList"];
                        return MakeStringSubGroup(SubGroupList.FindAll(f=>f.ItemGroupID==Convert.ToInt32(thisval)));
                    case "onSelectMode_Item":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        CustomList<ItemMaster> ItemMasterList = (CustomList<ItemMaster>)HttpContext.Current.Session["ItemRequisition_ItemMasterList"];
                        return MakeStringItem(ItemMasterList.FindAll(f => f.ItemGroupID == Convert.ToInt32(thisval)));
                    case "onSelectMode_ItemBySubGroup":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        CustomList<ItemMaster> ItemMasterList1 = (CustomList<ItemMaster>)HttpContext.Current.Session["ItemRequisition_ItemMasterList"];;
                        return MakeStringItem(ItemMasterList1.FindAll(f => f.ItemSubGroupID == Convert.ToInt32(thisval)));

                    case "onSelectMode_SubGroupStock":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        ItemSubGroupManager managerStock = new ItemSubGroupManager();
                        CustomList<ItemSubGroup> SubGroupListStock = (CustomList<ItemSubGroup>)HttpContext.Current.Session["StockTransaction_ItemSubGroupList"];
                        return MakeStringSubGroup(SubGroupListStock.FindAll(f => f.ItemGroupID == Convert.ToInt32(thisval)));
                    case "onSelectMode_ItemStock":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        CustomList<ItemMaster> ItemMasterListStock = (CustomList<ItemMaster>)HttpContext.Current.Session["StockTransaction_ItemMasterList"];
                        return MakeStringItem(ItemMasterListStock.FindAll(f => f.ItemGroupID == Convert.ToInt32(thisval)));
                    case "onSelectMode_ItemBySubGroupStock":
                        thisval = HttpContext.Current.Request.QueryString["thisval"];
                        CustomList<ItemMaster> ItemMasterList1Stock = (CustomList<ItemMaster>)HttpContext.Current.Session["StockTransaction_ItemMasterList"]; ;
                        return MakeStringItem(ItemMasterList1Stock.FindAll(f => f.ItemSubGroupID == Convert.ToInt32(thisval)));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return "";
        }

        private String MakeStringSubGroup(CustomList<ItemSubGroup> retDataFiltered)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=-1>--Select--</option>");

            foreach (ItemSubGroup item in retDataFiltered)
            {
                if ((item.ItemSubGroupID == null) || (item.ItemSubGroupID.ToString() == String.Empty)) continue;
                if (item.SubGroupName == null)
                    item.SubGroupName = String.Empty;

                sb.Append("<option value=");
                sb.Append(item.ItemSubGroupID);
                sb.Append(">");
                sb.Append(item.SubGroupName);
                sb.Append("</option>");
            }

            return sb.ToString();
        }
        private String MakeStringItem(CustomList<ItemMaster> retDataFiltered)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<option value=-1>--Select--</option>");

            foreach (ItemMaster item in retDataFiltered)
            {
                if ((item.ItemCode == null) || (item.ItemCode.ToString() == String.Empty)) continue;
                if (item.ItemDescription == null)
                    item.ItemDescription = String.Empty;

                sb.Append("<option value=");
                sb.Append(item.ItemCode);
                sb.Append(">");
                sb.Append(item.ItemDescription);
                sb.Append("</option>");
            }

            return sb.ToString();
        }
    }
}