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
    public class ContactType : BaseItem
    {
        public ContactType()
        {
            SetAdded();
        }

        #region Properties

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

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }

        private System.String _ContactTypeName;
        [Browsable(true), DisplayName("ContactTypeName")]
        public System.String ContactTypeName
        {
            get
            {
                return _ContactTypeName;
            }
            set
            {
                if (PropertyChanged(_ContactTypeName, value))
                    _ContactTypeName = value;
            }
        }

        private System.String _ContactTypeDisplayName;
        [Browsable(true), DisplayName("ContactTypeDisplayName")]
        public System.String ContactTypeDisplayName
        {
            get
            {
                return _ContactTypeDisplayName;
            }
            set
            {
                if (PropertyChanged(_ContactTypeDisplayName, value))
                    _ContactTypeDisplayName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ContactTypeName, _ContactTypeDisplayName };
            else if (IsModified)
                parameterValues = new Object[] { _ContactTypeID, _ContactTypeName, _ContactTypeDisplayName };
            else if (IsDeleted)
                parameterValues = new Object[] { _ContactTypeID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ContactTypeID = reader.GetInt32("ContactTypeID");
            _ContactTypeName = reader.GetString("ContactTypeName");
            _ContactTypeDisplayName = reader.GetString("ContactTypeDisplayName");
            SetUnchanged();
        }
        public static CustomList<ContactType> GetAllContactType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactType> ContactTypeCollection = new CustomList<ContactType>();
            IDataReader reader = null;
            const String sql = "select *from ContactType";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactType newContactType = new ContactType();
                    newContactType.SetData(reader);
                    ContactTypeCollection.Add(newContactType);
                }
                ContactTypeCollection.InsertSpName = "spInsertContactType";
                ContactTypeCollection.UpdateSpName = "spUpdateContactType";
                ContactTypeCollection.DeleteSpName = "spDeleteContactType";
                return ContactTypeCollection;
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
