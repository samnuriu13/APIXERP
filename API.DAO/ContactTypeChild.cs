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
    public class ContactTypeChild : BaseItem
    {
        public ContactTypeChild()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ContactTypeChildID;
        [Browsable(true), DisplayName("ContactTypeChildID")]
        public System.Int32 ContactTypeChildID
        {
            get
            {
                return _ContactTypeChildID;
            }
            set
            {
                if (PropertyChanged(_ContactTypeChildID, value))
                    _ContactTypeChildID = value;
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

        private System.String _ContactTypeChildName;
        [Browsable(true), DisplayName("ContactTypeChildName")]
        public System.String ContactTypeChildName
        {
            get
            {
                return _ContactTypeChildName;
            }
            set
            {
                if (PropertyChanged(_ContactTypeChildName, value))
                    _ContactTypeChildName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ContactTypeChildID, _ContactTypeID, _ContactTypeChildName };
            else if (IsModified)
                parameterValues = new Object[] { _ContactTypeChildID, _ContactTypeID, _ContactTypeChildName };
            else if (IsDeleted)
                parameterValues = new Object[] { _ContactTypeChildID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ContactTypeChildID = reader.GetInt32("ContactTypeChildID");
            _ContactTypeID = reader.GetInt32("ContactTypeID");
            _ContactTypeChildName = reader.GetString("ContactTypeChildName");
            SetUnchanged();
        }
        public static CustomList<ContactTypeChild> GetAllContactTypeChild()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactTypeChild> ContactTypeChildCollection = new CustomList<ContactTypeChild>();
            IDataReader reader = null;
            const String sql = "select *from ContactTypeChild";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactTypeChild newContactTypeChild = new ContactTypeChild();
                    newContactTypeChild.SetData(reader);
                    ContactTypeChildCollection.Add(newContactTypeChild);
                }
                ContactTypeChildCollection.InsertSpName = "spInsertContactTypeChild";
                ContactTypeChildCollection.UpdateSpName = "spUpdateContactTypeChild";
                ContactTypeChildCollection.DeleteSpName = "spDeleteContactTypeChild";
                return ContactTypeChildCollection;
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
