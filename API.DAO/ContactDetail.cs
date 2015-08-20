using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;

namespace API.DAO
{
    [Serializable]
    public class ContactDetail : BaseItem
    {
        public ContactDetail()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ContactDetailID;
        [Browsable(true), DisplayName("ContactDetailID")]
        public System.Int32 ContactDetailID
        {
            get
            {
                return _ContactDetailID;
            }
            set
            {
                if (PropertyChanged(_ContactDetailID, value))
                    _ContactDetailID = value;
            }
        }

        private System.Int32 _ContactID;
        [Browsable(true), DisplayName("ContactID")]
        public System.Int32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                if (PropertyChanged(_ContactID, value))
                    _ContactID = value;
            }
        }

        private System.Int32 _ContactTypeID;
        [Browsable(true), DisplayName("ContactTypeID")]
        public System.Int32 ContactTypeID
        {
            get
            {
                return _ContactTypeID;
            }
            set
            {
                if (PropertyChanged(_ContactTypeID, value))
                    _ContactTypeID = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] {_ContactID, _ContactTypeID };
            else if (IsModified)
                parameterValues = new Object[] { _ContactDetailID, _ContactID, _ContactTypeID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ContactDetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ContactDetailID = reader.GetInt32("ContactDetailID");
            _ContactID = reader.GetInt32("ContactID");
            _ContactTypeID = reader.GetInt32("ContactTypeID");
            SetUnchanged();
        }
        public static CustomList<ContactDetail> GetAllContactDetail(Int32 contactID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactDetail> ContactDetailCollection = new CustomList<ContactDetail>();
            IDataReader reader = null;
            String sql = "select *from ContactDetail Where ContactID=" + contactID.ToString();
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactDetail newContactDetail = new ContactDetail();
                    newContactDetail.SetData(reader);
                    ContactDetailCollection.Add(newContactDetail);
                }
                ContactDetailCollection.InsertSpName = "spInsertContactDetail";
                ContactDetailCollection.UpdateSpName = "spUpdateContactDetail";
                ContactDetailCollection.DeleteSpName = "spDeleteContactDetail";
                return ContactDetailCollection;
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
    }
}