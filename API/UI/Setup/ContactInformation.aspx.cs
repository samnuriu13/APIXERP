using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using API.BLL;
using API.DAO;
using STATIC;
using API.DATA;
using FRAMEWORK;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace API.UI.Setup
{
    public partial class ContactInformation : PageBase
    {
        ContactInfoManager manager = new ContactInfoManager();
        HKEntryManager hkManager = new HKEntryManager();
        #region Constructur
        public ContactInformation()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Variable
        private CustomList<ContactInfo> ContactInfoList
        {
            get
            {
                if (Session["ContactInfo_ContactInfoList"] == null)
                    return new CustomList<ContactInfo>();
                else
                    return (CustomList<ContactInfo>)Session["ContactInfo_ContactInfoList"];
            }
            set
            {
                Session["ContactInfo_ContactInfoList"] = value;
            }
        }
        private CustomList<ContactType> ContactTypeList
        {
            get
            {
                if (Session["ContactInfo_ContactTypeList"] == null)
                    return new CustomList<ContactType>();
                else
                    return (CustomList<ContactType>)Session["ContactInfo_ContactTypeList"];
            }
            set
            {
                Session["ContactInfo_ContactTypeList"] = value;
            }
        }
        private CustomList<ContactTypeChild> ContactTypeChildList
        {
            get
            {
                if (Session["ContactInfo_ContactTypeChildList"] == null)
                    return new CustomList<ContactTypeChild>();
                else
                    return (CustomList<ContactTypeChild>)Session["ContactInfo_ContactTypeChildList"];
            }
            set
            {
                Session["ContactInfo_ContactTypeChildList"] = value;
            }
        }
        private CustomList<ContactDetail> ContactDetailList
        {
            get
            {
                if (Session["ContactInfo_ContactDetailList"] == null)
                    return new CustomList<ContactDetail>();
                else
                    return (CustomList<ContactDetail>)Session["ContactInfo_ContactDetailList"];
            }
            set
            {
                Session["ContactInfo_ContactDetailList"] = value;
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack.IsFalse())
            {
                InitializeSession();
                PopulateDropdown();
            }
            else
            {
                Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                if (Request["__EVENTTARGET"] == "SearchContactInfo")
                {
                    ContactInfoList = new CustomList<ContactInfo>();
                    ContactInfo searchContactInfo = Session[STATIC.StaticInfo.SearchSessionVarName] as ContactInfo;
                    ContactInfoList.Add(searchContactInfo);
                    if (searchContactInfo.IsNotNull())
                    {
                        PopulateContactInfo(searchContactInfo);
                        ContactDetailList = manager.GetAllContactDetail(searchContactInfo.ContactID);
                        foreach (ContactDetail cD in ContactDetailList)
                        {
                            ContactType cT = ContactTypeList.Find(f=>f.ContactTypeID==cD.ContactTypeID);
                            cT.IsChecked = true;
                        }
                    }
                }
            }
        }
        private void PopulateDropdown()
        {
            ddlCostCentre.DataSource = hkManager.GetAllHouseKeeping(3);
            ddlCostCentre.DataTextField = "HKName";
            ddlCostCentre.DataValueField = "HKID";
            ddlCostCentre.DataBind();
            ddlCostCentre.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlCostCentre.SelectedIndex = 0;

            ddlBranch.DataSource = hkManager.GetAllHouseKeeping(31);
            ddlBranch.DataTextField = "HKName";
            ddlBranch.DataValueField = "HKID";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddlBranch.SelectedIndex = 0;
        }
        private void PopulateContactInfo(ContactInfo contactInfo)
        {
            try
            {
                txtContactID.Text = contactInfo.ContactID.ToString();
                txtContactName.Text = contactInfo.Name;
                txtShortName.Text = contactInfo.ShortName;
                txtAgentName.Text = contactInfo.AgentName;
                txtOfficeAddress.Text = contactInfo.OfficeAddress;
                txtFactoryAddress.Text = contactInfo.FactoryAddress;
                txtPhoneNo.Text = contactInfo.PhoneNo;
                txtFaxNo.Text = contactInfo.FaxNo;
                txtEmail.Text = contactInfo.EmailNo;
                txtContactPerson.Text = contactInfo.ContactPerson;
                txtTinNo.Text = contactInfo.TINNO;
                txtVATCode.Text = contactInfo.VATCode;
                ddlCostCentre.SelectedValue = contactInfo.CostCenterId.ToString();
                ddlBranch.SelectedValue = contactInfo.BranchID.ToString();
                if (contactInfo.ContactImage.IsNotNullOrEmpty())
                {
                    imgContactImage.ImageUrl = ResolveUrl(contactInfo.ContactImage);
                }
            }
            catch (Exception ex)
            {
                
                throw(ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                ContactTypeList = new CustomList<ContactType>();
                ContactTypeList = manager.GetAllContactType();
                ContactTypeChildList = new CustomList<ContactTypeChild>();
                ContactInfoList = new CustomList<ContactInfo>();
                ContactDetailList = new CustomList<ContactDetail>();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                FormUtil.ClearForm(this, FormClearOptions.ClearAll, false);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void SetDataFromControlToObj(ref CustomList<ContactInfo> lstContactInfo)
        {
            try
            {
                ContactInfo obj = lstContactInfo[0];
                obj.Name = txtContactName.Text;
                obj.ShortName = txtShortName.Text;
                obj.AgentName = txtAgentName.Text;
                obj.OfficeAddress = txtOfficeAddress.Text;
                obj.FactoryAddress = txtFactoryAddress.Text;
                obj.PhoneNo = txtPhoneNo.Text;
                obj.FaxNo = txtFaxNo.Text;
                obj.EmailNo = txtEmail.Text;
                obj.ContactPerson = txtContactPerson.Text;
                obj.TINNO = txtTinNo.Text;
                obj.VATCode = txtVATCode.Text;
                if(ddlBranch.SelectedValue!="")
                    obj.BranchID =Convert.ToInt32(ddlBranch.SelectedValue);
                if(ddlCostCentre.SelectedValue!="")
                    obj.CostCenterId = Convert.ToInt32(ddlCostCentre.SelectedValue);
                obj.ContactImage = GetPicture() == string.Empty ? imgContactImage.ImageUrl : GetPicture();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private string GetPicture()
        {
            var picture = fuContactImage;

            if (picture != null && !string.IsNullOrEmpty(picture.FileName))
            {
                var fileInfo = new FileInfo(picture.FileName);
                var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                var path = Server.MapPath(ConfigurationManager.AppSettings["empImagePath"]) + fileName;
                var dbPath = ConfigurationManager.AppSettings["empImagePath"] + fileName;
                File.WriteAllBytes(path, picture.FileBytes);
                return dbPath;
            }
            return string.Empty;
        }
        #region Button Event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<ContactInfo> items = manager.GetAllContactInfo();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("Name", "Name");
                columns.Add("PhoneNo", "Phone No");

                StaticInfo.SearchItem(items, "ContactInfo", "SearchContactInfo", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(ContactInfo), columns), 500);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ContactInfo> lstContactInfo = ContactInfoList;
                if (lstContactInfo.Count == 0)
                {
                    ContactInfo newContactInfo = new ContactInfo();
                    lstContactInfo.Add(newContactInfo);
                }
                SetDataFromControlToObj(ref lstContactInfo);
                CustomList<ContactType> lstContactType = (CustomList<ContactType>)ContactTypeList;
                CustomList<ContactTypeChild> lstContactTypeChild = (CustomList<ContactTypeChild>)ContactTypeChildList;
                CustomList<ContactDetail> lstContactDetail = (CustomList<ContactDetail>)ContactDetailList;


                if (!CheckUserAuthentication(lstContactInfo)) return;
                manager.SaveContactInfo(ref lstContactInfo, ref lstContactType, ref lstContactTypeChild, ref lstContactDetail);
                ((PageBase)this.Page).SuccessMessage = (StaticInfo.SavedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }
        }
        protected void btnNew_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                InitializeSession();
               // PopulateDropdown();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {

                ClearControls();
                InitializeSession();
                //PopulateDropdown();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                CustomList<ContactInfo> lstContactInfo = (CustomList<ContactInfo>)ContactInfoList;
                lstContactInfo.ForEach(f => f.Delete());
                CustomList<ContactDetail> lstContactDetail = (CustomList<ContactDetail>)ContactDetailList;
                lstContactDetail.ForEach(s=>s.Delete());
                if (CheckUserAuthentication(lstContactInfo).IsFalse()) return;
                manager.SaveContactInfo(ref lstContactInfo, ref lstContactDetail);
                ClearControls();
                InitializeSession();
                this.ErrorMessage = (StaticInfo.DeletedSuccessfullyMsg);
            }
            catch (SqlException ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getSqlExceptionMessage(ex));
            }
            catch (Exception ex)
            {
                ((PageBase)this.Page).ErrorMessage = (ExceptionHelper.getExceptionMessage(ex));
            }

        }
        #endregion
    }
}