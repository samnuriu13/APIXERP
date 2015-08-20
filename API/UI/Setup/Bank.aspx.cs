﻿using System;
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

namespace API.UI.Setup
{
    public partial class Bank : PageBase
    {
        BankManager manager = new BankManager();
        #region Constructur
        public Bank()
        {
            RequiresAuthorization = true;
        }
        #endregion
        #region Session Event
        private CustomList<Gen_Bank> BankMasterList
        {
            get
            {
                if (Session["Bank_BankMasterList"] == null)
                    return new CustomList<Gen_Bank>();
                else
                    return (CustomList<Gen_Bank>)Session["Bank_BankMasterList"];
            }
            set
            {
                Session["Bank_BankMasterList"] = value;
            }
        }

        private CustomList<Bank_Branch> BankBranchList
        {
            get
            {
                if (Session["Bank_BankBranchList"] == null)
                    return new CustomList<Bank_Branch>();
                else
                    return (CustomList<Bank_Branch>)Session["Bank_BankBranchList"];
            }
            set
            {
                Session["Bank_BankBranchList"] = value;
            }
        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack.IsFalse())
                {
                    //InitializeCombo();
                    InitializeSession();
                }
                else
                {
                    Page.ClientScript.GetPostBackEventReference(this, String.Empty);
                    String eventTarget = Request["__EVENTTARGET"].IsNullOrEmpty() ? String.Empty : Request["__EVENTTARGET"];
                    if (Request["__EVENTTARGET"] == "SearchBank")
                    {
                        BankMasterList = new CustomList<Gen_Bank>();
                        Gen_Bank searchBank = Session[STATIC.StaticInfo.SearchSessionVarName] as Gen_Bank;
                        BankMasterList.Add(searchBank);
                        if (searchBank.IsNotNull())
                        {
                            PopulateBankInformation(searchBank);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region All Methods
        private void PopulateBankInformation(Gen_Bank bank)
        {
            try
            {
                txtBankName.Text = bank.BnakName;
                txtBankSName.Text = bank.BankSName;
                txtAddress.Text = bank.Address;
                txtContactPerson.Text = bank.ContactPerson;
                BankBranchList = manager.GetAllBank_Branch(bank.BankKey);
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        private void InitializeSession()
        {
            try
            {
                BankMasterList = new CustomList<Gen_Bank>();
                BankBranchList = new CustomList<Bank_Branch>();
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
        private void SetDataFromControlToObj(ref CustomList<Gen_Bank> lstBank)
        {
            try
            {
                Gen_Bank obj = lstBank[0];
                obj.BnakName = txtBankName.Text;
                obj.BankSName = txtBankSName.Text;
                obj.Address = txtAddress.Text;
                obj.ContactPerson = txtContactPerson.Text;
                //if (obj.ShiftID != 0) obj.SetModified();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        #endregion
        #region Button Event
        protected void btnFind_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                CustomList<Gen_Bank> items = manager.GetAllGen_Bank();
                Dictionary<string, string> columns = new Dictionary<string, string>();

                columns.Add("BnakName", "Bank Name");

                StaticInfo.SearchItem(items, "Bank", "SearchBank", FRAMEWORK.SearchColumnConfig.GetColumnConfig(typeof(Gen_Bank), columns), 500);
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
                CustomList<Gen_Bank> lstBank = BankMasterList;
                if (lstBank.Count == 0)
                {
                    Gen_Bank newBank = new Gen_Bank();
                    lstBank.Add(newBank);
                }
                SetDataFromControlToObj(ref lstBank);
                CustomList<Bank_Branch> lstBankBranch = (CustomList<Bank_Branch>)BankBranchList;

                if (!CheckUserAuthentication(lstBank, lstBankBranch)) return;
                manager.SaveBank(ref lstBank, ref lstBankBranch);
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
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        #endregion
    }
}