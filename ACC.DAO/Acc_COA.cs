using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;

namespace ACC.DAO
{
    [Serializable]
    public class Acc_COA : BaseItem
    {
        public Acc_COA()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _COAKey;
        [Browsable(true), DisplayName("COAKey")]
        public System.Int64 COAKey
        {
            get
            {
                return _COAKey;
            }
            set
            {
                if (PropertyChanged(_COAKey, value))
                    _COAKey = value;
            }
        }

        private System.Int64? _ParentKey;
        [Browsable(true), DisplayName("ParentKey")]
        public System.Int64? ParentKey
        {
            get
            {
                return _ParentKey;
            }
            set
            {
                if (PropertyChanged(_ParentKey, value))
                    _ParentKey = value;
            }
        }

        private System.String _COACode;
        [Browsable(true), DisplayName("COACode")]
        public System.String COACode
        {
            get
            {
                return _COACode;
            }
            set
            {
                if (PropertyChanged(_COACode, value))
                    _COACode = value;
            }
        }

        private System.String _COACodeClient;
        [Browsable(true), DisplayName("COACodeClient")]
        public System.String COACodeClient
        {
            get
            {
                return _COACodeClient;
            }
            set
            {
                if (PropertyChanged(_COACodeClient, value))
                    _COACodeClient = value;
            }
        }

        private System.String _COAName;
        [Browsable(true), DisplayName("COAName")]
        public System.String COAName
        {
            get
            {
                return _COAName;
            }
            set
            {
                if (PropertyChanged(_COAName, value))
                    _COAName = value;
            }
        }

        private System.Int32 _COALevel;
        [Browsable(true), DisplayName("COALevel")]
        public System.Int32 COALevel
        {
            get
            {
                return _COALevel;
            }
            set
            {
                if (PropertyChanged(_COALevel, value))
                    _COALevel = value;
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

        private System.Boolean _IsPostingHead;
        [Browsable(true), DisplayName("IsPostingHead")]
        public System.Boolean IsPostingHead
        {
            get
            {
                return _IsPostingHead;
            }
            set
            {
                if (PropertyChanged(_IsPostingHead, value))
                    _IsPostingHead = value;
            }
        }

        private System.DateTime _EntryDate;
        [Browsable(true), DisplayName("EntryDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime EntryDate
        {
            get
            {
                return _EntryDate;
            }
            set
            {
                if (PropertyChanged(_EntryDate, value))
                    _EntryDate = value;
            }
        }

        private System.Int64 _EntryUserKey;
        [Browsable(true), DisplayName("EntryUserKey")]
        public System.Int64 EntryUserKey
        {
            get
            {
                return _EntryUserKey;
            }
            set
            {
                if (PropertyChanged(_EntryUserKey, value))
                    _EntryUserKey = value;
            }
        }

        private System.DateTime _LastUpdateDate;
        [Browsable(true), DisplayName("LastUpdateDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LastUpdateDate
        {
            get
            {
                return _LastUpdateDate;
            }
            set
            {
                if (PropertyChanged(_LastUpdateDate, value))
                    _LastUpdateDate = value;
            }
        }

        private System.Int64 _LastUpdateUserKey;
        [Browsable(true), DisplayName("LastUpdateUserKey")]
        public System.Int64 LastUpdateUserKey
        {
            get
            {
                return _LastUpdateUserKey;
            }
            set
            {
                if (PropertyChanged(_LastUpdateUserKey, value))
                    _LastUpdateUserKey = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ParentKey, _COACode, _COACodeClient, _COAName, _COALevel, _IsActive, _IsPostingHead};
            else if (IsModified)
                parameterValues = new Object[] { _COAKey, _ParentKey, _COACode, _COACodeClient, _COAName, _COALevel, _IsActive, _IsPostingHead};
            else if (IsDeleted)
                parameterValues = new Object[] { _COAKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _COAKey = reader.GetInt64("COAKey");
            _ParentKey = reader.GetNulableInt64("ParentKey");
            _COACode = reader.GetString("COACode");
            _COACodeClient = reader.GetString("COACodeClient");
            _COAName = reader.GetString("COAName");
            _COALevel = reader.GetInt32("COALevel");
            _IsActive = reader.GetBoolean("IsActive");
            _IsPostingHead = reader.GetBoolean("IsPostingHead");
            SetUnchanged();
        }
        public static CustomList<Acc_COA> GetAllAcc_COA(bool isAll = false)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_COA> Acc_COACollection = new CustomList<Acc_COA>();
            IDataReader reader = null;
            String sql = string.Empty;

            if (isAll == true)
                sql = "Select * From Acc_COA Where IsActive = 1 Order by COAName ASC";
            else
                sql = "Select * From Acc_COA Where IsActive = 1 And COALevel=5 Order by COAName ASC";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_COA newAcc_COA = new Acc_COA();
                    newAcc_COA.SetData(reader);
                    Acc_COACollection.Add(newAcc_COA);
                }
                return Acc_COACollection;
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

        public static CustomList<Acc_COA> GetAllAcc_COA_ByLevel(int level)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_COA> Acc_COACollection = new CustomList<Acc_COA>();
            IDataReader reader = null;
            String sql = string.Format("Select * From Acc_COA Where IsActive = 1 And COALevel = {0} Order by COAName ASC", level);
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_COA newAcc_COA = new Acc_COA();
                    newAcc_COA.SetData(reader);
                    Acc_COACollection.Add(newAcc_COA);
                }
                return Acc_COACollection;
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