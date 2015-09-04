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
    public class CmnDocListTableMapping : BaseItem
    {
        public CmnDocListTableMapping()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _DocListTableMappingID;
        [Browsable(true), DisplayName("DocListTableMappingID")]
        public System.Int32 DocListTableMappingID
        {
            get
            {
                return _DocListTableMappingID;
            }
            set
            {
                if (PropertyChanged(_DocListTableMappingID, value))
                    _DocListTableMappingID = value;
            }
        }

        private System.Int32 _DocListID;
        [Browsable(true), DisplayName("DocListID")]
        public System.Int32 DocListID
        {
            get
            {
                return _DocListID;
            }
            set
            {
                if (PropertyChanged(_DocListID, value))
                    _DocListID = value;
            }
        }

        private System.String _TableType;
        [Browsable(true), DisplayName("TableType")]
        public System.String TableType
        {
            get
            {
                return _TableType;
            }
            set
            {
                if (PropertyChanged(_TableType, value))
                    _TableType = value;
            }
        }

        private System.String _TableName;
        [Browsable(true), DisplayName("TableName")]
        public System.String TableName
        {
            get
            {
                return _TableName;
            }
            set
            {
                if (PropertyChanged(_TableName, value))
                    _TableName = value;
            }
        }

        private System.String _ColumnType;
        [Browsable(true), DisplayName("ColumnType")]
        public System.String ColumnType
        {
            get
            {
                return _ColumnType;
            }
            set
            {
                if (PropertyChanged(_ColumnType, value))
                    _ColumnType = value;
            }
        }

        private System.String _ColumnName;
        [Browsable(true), DisplayName("ColumnName")]
        public System.String ColumnName
        {
            get
            {
                return _ColumnName;
            }
            set
            {
                if (PropertyChanged(_ColumnName, value))
                    _ColumnName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _DocListTableMappingID, _DocListID, _TableType, _TableName, _ColumnType, _ColumnName };
            else if (IsModified)
                parameterValues = new Object[] { _DocListTableMappingID, _DocListID, _TableType, _TableName, _ColumnType, _ColumnName };
            else if (IsDeleted)
                parameterValues = new Object[] { _DocListTableMappingID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _DocListTableMappingID = reader.GetInt32("DocListTableMappingID");
            _DocListID = reader.GetInt32("DocListID");
            _TableType = reader.GetString("TableType");
            _TableName = reader.GetString("TableName");
            _ColumnType = reader.GetString("ColumnType");
            _ColumnName = reader.GetString("ColumnName");
            SetUnchanged();
        }
        public static CustomList<CmnDocListTableMapping> GetAllCmnDocListTableMapping()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnDocListTableMapping> CmnDocListTableMappingCollection = new CustomList<CmnDocListTableMapping>();
            IDataReader reader = null;
            const String sql = "select * from CmnDocListTableMapping";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnDocListTableMapping newCmnDocListTableMapping = new CmnDocListTableMapping();
                    newCmnDocListTableMapping.SetData(reader);
                    CmnDocListTableMappingCollection.Add(newCmnDocListTableMapping);
                }
                CmnDocListTableMappingCollection.InsertSpName = "spInsertCmnDocListTableMapping";
                CmnDocListTableMappingCollection.UpdateSpName = "spUpdateCmnDocListTableMapping";
                CmnDocListTableMappingCollection.DeleteSpName = "spDeleteCmnDocListTableMapping";
                return CmnDocListTableMappingCollection;
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
