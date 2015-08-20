using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using ACC.DAO;

namespace ACC.DAO
{
    [Serializable]
    public class AccChequeStatusList : BaseItem
    {
        public AccChequeStatusList()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ChequeStatusID;
        [Browsable(true), DisplayName("ChequeStatusID")]
        public System.Int32 ChequeStatusID
        {
            get
            {
                return _ChequeStatusID;
            }
            set
            {
                if (PropertyChanged(_ChequeStatusID, value))
                    _ChequeStatusID = value;
            }
        }

        private System.String _ChequeStatusName;
        [Browsable(true), DisplayName("ChequeStatusName")]
        public System.String ChequeStatusName
        {
            get
            {
                return _ChequeStatusName;
            }
            set
            {
                if (PropertyChanged(_ChequeStatusName, value))
                    _ChequeStatusName = value;
            }
        }

        private System.Boolean _IsActive;
        [Browsable(true), DisplayName("IsActive")]
        public System.Boolean IsActive
        {
            get
            {
                return _IsActive;
            }
            set
            {
                if (PropertyChanged(_IsActive, value))
                    _IsActive = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ChequeStatusID, _ChequeStatusName, _IsActive };
            else if (IsModified)
                parameterValues = new Object[] { _ChequeStatusID, _ChequeStatusName, _IsActive };
            else if (IsDeleted)
                parameterValues = new Object[] { _ChequeStatusID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ChequeStatusID = reader.GetInt32("ChequeStatusID");
            _ChequeStatusName = reader.GetString("ChequeStatusName");
            _IsActive = reader.GetBoolean("IsActive");
            SetUnchanged();
        }
        public static CustomList<AccChequeStatusList> GetAllAccChequeStatusList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<AccChequeStatusList> AccChequeStatusListCollection = new CustomList<AccChequeStatusList>();
            IDataReader reader = null;
            const String sql = "select *from AccChequeStatusList";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    AccChequeStatusList newAccChequeStatusList = new AccChequeStatusList();
                    newAccChequeStatusList.SetData(reader);
                    AccChequeStatusListCollection.Add(newAccChequeStatusList);
                }
                return AccChequeStatusListCollection;
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
