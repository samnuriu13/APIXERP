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
    public class StockTransactionMaster : BaseItem
    {
        public StockTransactionMaster()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _StockTransID;
        [Browsable(true), DisplayName("StockTransID")]
        public System.Int64 StockTransID
        {
            get
            {
                return _StockTransID;
            }
            set
            {
                if (PropertyChanged(_StockTransID, value))
                    _StockTransID = value;
            }
        }

        private System.String _CustomCode;
        [Browsable(true), DisplayName("CustomCode")]
        public System.String CustomCode
        {
            get
            {
                return _CustomCode;
            }
            set
            {
                if (PropertyChanged(_CustomCode, value))
                    _CustomCode = value;
            }
        }

        private System.Int32 _TransType;
        [Browsable(true), DisplayName("TransType")]
        public System.Int32 TransType
        {
            get
            {
                return _TransType;
            }
            set
            {
                if (PropertyChanged(_TransType, value))
                    _TransType = value;
            }
        }

        private System.DateTime _TransDate;
        [Browsable(true), DisplayName("TransDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime TransDate
        {
            get
            {
                return _TransDate;
            }
            set
            {
                if (PropertyChanged(_TransDate, value))
                    _TransDate = value;
            }
        }

        private System.Int32 _FromBranchID;
        [Browsable(true), DisplayName("FromBranchID")]
        public System.Int32 FromBranchID
        {
            get
            {
                return _FromBranchID;
            }
            set
            {
                if (PropertyChanged(_FromBranchID, value))
                    _FromBranchID = value;
            }
        }

        private System.Int32 _FromCostCenterID;
        [Browsable(true), DisplayName("FromCostCenterID")]
        public System.Int32 FromCostCenterID
        {
            get
            {
                return _FromCostCenterID;
            }
            set
            {
                if (PropertyChanged(_FromCostCenterID, value))
                    _FromCostCenterID = value;
            }
        }

        private System.Int32 _FromStockLocationID;
        [Browsable(true), DisplayName("FromStockLocationID")]
        public System.Int32 FromStockLocationID
        {
            get
            {
                return _FromStockLocationID;
            }
            set
            {
                if (PropertyChanged(_FromStockLocationID, value))
                    _FromStockLocationID = value;
            }
        }

        private System.Int32 _ToBranchID;
        [Browsable(true), DisplayName("ToBranchID")]
        public System.Int32 ToBranchID
        {
            get
            {
                return _ToBranchID;
            }
            set
            {
                if (PropertyChanged(_ToBranchID, value))
                    _ToBranchID = value;
            }
        }

        private System.Int32 _ToCostCenterID;
        [Browsable(true), DisplayName("ToCostCenterID")]
        public System.Int32 ToCostCenterID
        {
            get
            {
                return _ToCostCenterID;
            }
            set
            {
                if (PropertyChanged(_ToCostCenterID, value))
                    _ToCostCenterID = value;
            }
        }

        private System.Int32 _ToStockLocationID;
        [Browsable(true), DisplayName("ToStockLocationID")]
        public System.Int32 ToStockLocationID
        {
            get
            {
                return _ToStockLocationID;
            }
            set
            {
                if (PropertyChanged(_ToStockLocationID, value))
                    _ToStockLocationID = value;
            }
        }

        private System.Int32 _PartyID;
        [Browsable(true), DisplayName("PartyID")]
        public System.Int32 PartyID
        {
            get
            {
                return _PartyID;
            }
            set
            {
                if (PropertyChanged(_PartyID, value))
                    _PartyID = value;
            }
        }

        private System.Int32 _CurrencyID;
        [Browsable(true), DisplayName("CurrencyID")]
        public System.Int32 CurrencyID
        {
            get
            {
                return _CurrencyID;
            }
            set
            {
                if (PropertyChanged(_CurrencyID, value))
                    _CurrencyID = value;
            }
        }

        private System.Decimal _CurrencyRate;
        [Browsable(true), DisplayName("CurrencyRate")]
        public System.Decimal CurrencyRate
        {
            get
            {
                return _CurrencyRate;
            }
            set
            {
                if (PropertyChanged(_CurrencyRate, value))
                    _CurrencyRate = value;
            }
        }

        private System.String _Description;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }

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

        private System.Int32 _CompanyID;
        [Browsable(true), DisplayName("CompanyID")]
        public System.Int32 CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                if (PropertyChanged(_CompanyID, value))
                    _CompanyID = value;
            }
        }

        private System.Boolean _IsDeleted;
        [Browsable(true), DisplayName("IsDeleted")]
        public System.Boolean IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                if (PropertyChanged(_IsDeleted, value))
                    _IsDeleted = value;
            }
        }

        private System.Boolean _Transfer;
        [Browsable(true), DisplayName("Transfer")]
        public System.Boolean Transfer
        {
            get
            {
                return _Transfer;
            }
            set
            {
                if (PropertyChanged(_Transfer, value))
                    _Transfer = value;
            }
        }

        private System.String _FromCostCenter;
        [Browsable(true), DisplayName("FromCostCenter")]
        public System.String FromCostCenter
        {
            get
            {
                return _FromCostCenter;
            }
            set
            {
                if (PropertyChanged(_FromCostCenter, value))
                    _FromCostCenter = value;
            }
        }

        private System.String _ToCostCenter;
        [Browsable(true), DisplayName("ToCostCenter")]
        public System.String ToCostCenter
        {
            get
            {
                return _ToCostCenter;
            }
            set
            {
                if (PropertyChanged(_ToCostCenter, value))
                    _ToCostCenter = value;
            }
        }

        private System.String _FromBranch;
        [Browsable(true), DisplayName("FromBranch")]
        public System.String FromBranch
        {
            get
            {
                return _FromBranch;
            }
            set
            {
                if (PropertyChanged(_FromBranch, value))
                    _FromBranch = value;
            }
        }

        private System.String _ToBranch;
        [Browsable(true), DisplayName("ToBranch")]
        public System.String ToBranch
        {
            get
            {
                return _ToBranch;
            }
            set
            {
                if (PropertyChanged(_ToBranch, value))
                    _ToBranch = value;
            }
        }


        private System.String _NatureOfTrans;
        [Browsable(true), DisplayName("NatureOfTrans")]
        public System.String NatureOfTrans
        {
            get
            {
                return _NatureOfTrans;
            }
            set
            {
                if (PropertyChanged(_NatureOfTrans, value))
                    _NatureOfTrans = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CustomCode, _TransType,_NatureOfTrans, _TransDate.Value(StaticInfo.DateFormat),_FromBranchID, _FromCostCenterID,_FromStockLocationID,_ToBranchID, _ToCostCenterID,_ToStockLocationID, _PartyID, _CurrencyID, _CurrencyRate, _Description, _StatusID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _StockTransID, _CustomCode, _TransType,_NatureOfTrans, _TransDate.Value(StaticInfo.DateFormat),_FromBranchID, _FromCostCenterID,_FromStockLocationID,_ToBranchID, _ToCostCenterID,_ToStockLocationID, _PartyID, _CurrencyID, _CurrencyRate, _Description, _StatusID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _StockTransID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _StockTransID = reader.GetInt64("StockTransID");
            _CustomCode = reader.GetString("CustomCode");
            _TransType = reader.GetInt32("TransType");
            _NatureOfTrans = reader.GetString("NatureOfTrans");
            _TransDate = reader.GetDateTime("TransDate");
            _FromBranchID = reader.GetInt32("FromBranchID");
            _FromCostCenterID = reader.GetInt32("FromCostCenterID");
            _FromStockLocationID = reader.GetInt32("FromStockLocationID");
            _ToBranchID = reader.GetInt32("ToBranchID");
            _ToCostCenterID = reader.GetInt32("ToCostCenterID");
            _ToStockLocationID = reader.GetInt32("ToStockLocationID");
            _PartyID = reader.GetInt32("PartyID");
            _CurrencyID = reader.GetInt32("CurrencyID");
            _CurrencyRate = reader.GetDecimal("CurrencyRate");
            _Description = reader.GetString("Description");
            _StatusID = reader.GetInt32("StatusID");
            _CompanyID = reader.GetInt32("CompanyID");
            _IsDeleted = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        private void SetDataFind(IDataRecord reader)
        {
            _StockTransID = reader.GetInt64("StockTransID");
            _CustomCode = reader.GetString("CustomCode");
            _TransDate = reader.GetDateTime("TransDate");
            _Description = reader.GetString("Description");
            _FromCostCenter = reader.GetString("FromCostCenter");
            _ToCostCenter = reader.GetString("ToCostCenter");
            _FromBranch = reader.GetString("FromBranch");
            _ToBranch = reader.GetString("ToBranch");
            _FromBranchID = reader.GetInt32("FromBranchID");
            _FromCostCenterID = reader.GetInt32("FromCostCenterID");
            _FromStockLocationID = reader.GetInt32("FromStockLocationID");
            _ToBranchID = reader.GetInt32("ToBranchID");
            _ToCostCenterID = reader.GetInt32("ToCostCenterID");
            _ToStockLocationID = reader.GetInt32("ToStockLocationID");
            _PartyID = reader.GetInt32("PartyID");
            _CurrencyID = reader.GetInt32("CurrencyID");
            SetUnchanged();
        }
        public static CustomList<StockTransactionMaster> GetAllStockTransactionMaster(Int32 TransType)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<StockTransactionMaster> StockTransactionMasterCollection = new CustomList<StockTransactionMaster>();
            IDataReader reader = null;
            String sql = "spFindStockTransaction " + TransType;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    StockTransactionMaster newStockTransactionMaster = new StockTransactionMaster();
                    newStockTransactionMaster.SetDataFind(reader);
                    StockTransactionMasterCollection.Add(newStockTransactionMaster);
                }
                return StockTransactionMasterCollection;
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
        public static CustomList<StockTransactionMaster> GetAllStockTransactionMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<StockTransactionMaster> StockTransactionMasterCollection = new CustomList<StockTransactionMaster>();
            IDataReader reader = null;
            const String sql = "select *from StockTransactionMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    StockTransactionMaster newStockTransactionMaster = new StockTransactionMaster();
                    newStockTransactionMaster.SetData(reader);
                    StockTransactionMasterCollection.Add(newStockTransactionMaster);
                }
                return StockTransactionMasterCollection;
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
