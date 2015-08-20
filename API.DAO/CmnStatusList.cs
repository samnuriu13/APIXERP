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
    public class CmnStatusList : BaseItem
    {
        public CmnStatusList()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _StatusID;
        [Browsable(true), DisplayName("StatusID")]
        public System.Int32 StatusID
        {
            get
            {
                return _StatusID;
            }
            set
            {
                if (PropertyChanged(_StatusID, value))
                    _StatusID = value;
            }
        }

        private System.String _StatusName;
        [Browsable(true), DisplayName("StatusName")]
        public System.String StatusName
        {
            get
            {
                return _StatusName;
            }
            set
            {
                if (PropertyChanged(_StatusName, value))
                    _StatusName = value;
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
                parameterValues = new Object[] { _StatusName, _IsActive };
            else if (IsModified)
                parameterValues = new Object[] { _StatusName, _IsActive };
            else if (IsDeleted)
                parameterValues = new Object[] { _StatusID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _StatusID = reader.GetInt32("StatusID");
            _StatusName = reader.GetString("StatusName");
            _IsActive = reader.GetBoolean("IsActive");
            SetUnchanged();
        }
        public static CustomList<CmnStatusList> GetAllCmnStatusList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnStatusList> CmnStatusListCollection = new CustomList<CmnStatusList>();
            IDataReader reader = null;
            const String sql = "select *from CmnStatusList";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnStatusList newCmnStatusList = new CmnStatusList();
                    newCmnStatusList.SetData(reader);
                    CmnStatusListCollection.Add(newCmnStatusList);
                }
                return CmnStatusListCollection;
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
