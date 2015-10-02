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
    public class CmnBankAccount : BaseItem
    {
        public CmnBankAccount()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _AccountID;
        [Browsable(true), DisplayName("AccountID")]
        public System.Int32 AccountID
        {
            get
            {
                return _AccountID;
            }
            set
            {
                if (PropertyChanged(_AccountID, value))
                    _AccountID = value;
            }
        }

        private System.String _AccountName;
        [Browsable(true), DisplayName("AccountName")]
        public System.String AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                if (PropertyChanged(_AccountName, value))
                    _AccountName = value;
            }
        }

        private System.String _AccountNo;
        [Browsable(true), DisplayName("AccountNo")]
        public System.String AccountNo
        {
            get
            {
                return _AccountNo;
            }
            set
            {
                if (PropertyChanged(_AccountNo, value))
                    _AccountNo = value;
            }
        }

        private System.Int32 _AccountTypeID;
        [Browsable(true), DisplayName("AccountTypeID")]
        public System.Int32 AccountTypeID
        {
            get
            {
                return _AccountTypeID;
            }
            set
            {
                if (PropertyChanged(_AccountTypeID, value))
                    _AccountTypeID = value;
            }
        }

        private System.Int32 _BankBranchID;
        [Browsable(true), DisplayName("BankBranchID")]
        public System.Int32 BankBranchID
        {
            get
            {
                return _BankBranchID;
            }
            set
            {
                if (PropertyChanged(_BankBranchID, value))
                    _BankBranchID = value;
            }
        }

        private System.Int32 _BranchOrUnitID;
        [Browsable(true), DisplayName("BranchOrUnitID")]
        public System.Int32 BranchOrUnitID
        {
            get
            {
                return _BranchOrUnitID;
            }
            set
            {
                if (PropertyChanged(_BranchOrUnitID, value))
                    _BranchOrUnitID = value;
            }
        }

        private System.Int32 _UserID;
        [Browsable(true), DisplayName("UserID")]
        public System.Int32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                if (PropertyChanged(_UserID, value))
                    _UserID = value;
            }
        }

        private System.Int32 _COAID;
        [Browsable(true), DisplayName("COAID")]
        public System.Int32 COAID
        {
            get
            {
                return _COAID;
            }
            set
            {
                if (PropertyChanged(_COAID, value))
                    _COAID = value;
            }
        }

        private System.Int32 _CostCenterID;
        [Browsable(true), DisplayName("CostCenterID")]
        public System.Int32 CostCenterID
        {
            get
            {
                return _CostCenterID;
            }
            set
            {
                if (PropertyChanged(_CostCenterID, value))
                    _CostCenterID = value;
            }
        }

        private System.Boolean _IsCompany;
        [Browsable(true), DisplayName("IsCompany")]
        public System.Boolean IsCompany
        {
            get
            {
                return _IsCompany;
            }
            set
            {
                if (PropertyChanged(_IsCompany, value))
                    _IsCompany = value;
            }
        }

        private System.String _AccountTypeName;
        [Browsable(true), DisplayName("AccountTypeName")]
        public System.String AccountTypeName
        {
            get
            {
                return _AccountTypeName;
            }
            set
            {
                if (PropertyChanged(_AccountTypeName, value))
                    _AccountTypeName = value;
            }
        }

        private System.String _BranchName;
        [Browsable(true), DisplayName("BranchName")]
        public System.String BranchName
        {
            get
            {
                return _BranchName;
            }
            set
            {
                if (PropertyChanged(_BranchName, value))
                    _BranchName = value;
            }
        }
        
        private System.String _Name;
        [Browsable(true), DisplayName("Name")]
        public System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (PropertyChanged(_Name, value))
                    _Name = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] {_AccountName, _AccountNo, _AccountTypeID, _BankBranchID, _UserID, _COAID,_BranchOrUnitID, _CostCenterID, _IsCompany };
            else if (IsModified)
                parameterValues = new Object[] { _AccountID, _AccountName, _AccountNo, _AccountTypeID, _BankBranchID, _UserID, _COAID, _BranchOrUnitID, _CostCenterID, _IsCompany };
            else if (IsDeleted)
                parameterValues = new Object[] { _AccountID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _AccountID = reader.GetInt32("AccountID");
            _AccountName = reader.GetString("AccountName");
            _AccountNo = reader.GetString("AccountNo");
            _AccountTypeID = reader.GetInt32("AccountTypeID");
            _BankBranchID = reader.GetInt32("BankBranchID");
            _UserID = reader.GetInt32("UserID");
            _COAID = reader.GetInt32("COAID");
            _BranchOrUnitID = reader.GetInt32("BranchOrUnitID");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _IsCompany = reader.GetBoolean("IsCompany");
            _AccountTypeName = reader.GetString("AccountTypeName");
            _BranchName = reader.GetString("BranchName");
            _Name = reader.GetString("Name");
            _COAName = reader.GetString("COAName");
            SetUnchanged();
        }
        public static CustomList<CmnBankAccount> GetAllCmnBankAccount()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnBankAccount> CmnBankAccountCollection = new CustomList<CmnBankAccount>();
            IDataReader reader = null;
            String sql = "spFindBankAccount";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnBankAccount newCmnBankAccount = new CmnBankAccount();
                    newCmnBankAccount.SetData(reader);
                    CmnBankAccountCollection.Add(newCmnBankAccount);
                }
                return CmnBankAccountCollection;
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
