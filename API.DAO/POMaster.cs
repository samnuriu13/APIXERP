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
    public class POMaster : BaseItem
    {
        public POMaster()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _POID;
        [Browsable(true), DisplayName("POID")]
        public System.Int64 POID
        {
            get
            {
                return _POID;
            }
            set
            {
                if (PropertyChanged(_POID, value))
                    _POID = value;
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

        private System.DateTime _PODate;
        [Browsable(true), DisplayName("PODate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime PODate
        {
            get
            {
                return _PODate;
            }
            set
            {
                if (PropertyChanged(_PODate, value))
                    _PODate = value;
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

        private System.Int32 _SupplierID;
        [Browsable(true), DisplayName("SupplierID")]
        public System.Int32 SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                if (PropertyChanged(_SupplierID, value))
                    _SupplierID = value;
            }
        }

        private System.Int32 _Agent;
        [Browsable(true), DisplayName("Agent")]
        public System.Int32 Agent
        {
            get
            {
                return _Agent;
            }
            set
            {
                if (PropertyChanged(_Agent, value))
                    _Agent = value;
            }
        }

        private System.DateTime _ExpectedReceiptDate;
        [Browsable(true), DisplayName("ExpectedReceiptDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ExpectedReceiptDate
        {
            get
            {
                return _ExpectedReceiptDate;
            }
            set
            {
                if (PropertyChanged(_ExpectedReceiptDate, value))
                    _ExpectedReceiptDate = value;
            }
        }

        private System.Int32 _PaymentModeID;
        [Browsable(true), DisplayName("PaymentModeID")]
        public System.Int32 PaymentModeID
        {
            get
            {
                return _PaymentModeID;
            }
            set
            {
                if (PropertyChanged(_PaymentModeID, value))
                    _PaymentModeID = value;
            }
        }

        private System.String _BillTo;
        [Browsable(true), DisplayName("BillTo")]
        public System.String BillTo
        {
            get
            {
                return _BillTo;
            }
            set
            {
                if (PropertyChanged(_BillTo, value))
                    _BillTo = value;
            }
        }

        private System.String _ShipTo;
        [Browsable(true), DisplayName("ShipTo")]
        public System.String ShipTo
        {
            get
            {
                return _ShipTo;
            }
            set
            {
                if (PropertyChanged(_ShipTo, value))
                    _ShipTo = value;
            }
        }

        private System.Int32 _ShipMode;
        [Browsable(true), DisplayName("ShipMode")]
        public System.Int32 ShipMode
        {
            get
            {
                return _ShipMode;
            }
            set
            {
                if (PropertyChanged(_ShipMode, value))
                    _ShipMode = value;
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

        private System.Int32 _OfferingCurrencyID;
        [Browsable(true), DisplayName("OfferingCurrencyID")]
        public System.Int32 OfferingCurrencyID
        {
            get
            {
                return _OfferingCurrencyID;
            }
            set
            {
                if (PropertyChanged(_OfferingCurrencyID, value))
                    _OfferingCurrencyID = value;
            }
        }

        private System.Decimal _CurrencyOfferingRate;
        [Browsable(true), DisplayName("CurrencyOfferingRate")]
        public System.Decimal CurrencyOfferingRate
        {
            get
            {
                return _CurrencyOfferingRate;
            }
            set
            {
                if (PropertyChanged(_CurrencyOfferingRate, value))
                    _CurrencyOfferingRate = value;
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

        private System.Int32 _BranchID;
        [Browsable(true), DisplayName("BranchID")]
        public System.Int32 BranchID
        {
            get
            {
                return _BranchID;
            }
            set
            {
                if (PropertyChanged(_BranchID, value))
                    _BranchID = value;
            }
        }

        private System.String _Branch;
        [Browsable(true), DisplayName("Branch")]
        public System.String Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                if (PropertyChanged(_Branch, value))
                    _Branch = value;
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

        private System.String _CostCenter;
        [Browsable(true), DisplayName("CostCenter")]
        public System.String CostCenter
        {
            get
            {
                return _CostCenter;
            }
            set
            {
                if (PropertyChanged(_CostCenter, value))
                    _CostCenter = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CustomCode, _TransType, _PODate.Value(StaticInfo.DateFormat), _Description, _SupplierID, _Agent, _ExpectedReceiptDate.Value(StaticInfo.DateFormat), _PaymentModeID, _BillTo, _ShipTo, _ShipMode, _CurrencyID, _OfferingCurrencyID, _CurrencyOfferingRate, _StatusID,_BranchID, _CostCenterID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _POID, _CustomCode, _TransType, _PODate.Value(StaticInfo.DateFormat), _Description, _SupplierID, _Agent, _ExpectedReceiptDate.Value(StaticInfo.DateFormat), _PaymentModeID, _BillTo, _ShipTo, _ShipMode, _CurrencyID, _OfferingCurrencyID, _CurrencyOfferingRate, _StatusID,_BranchID, _CostCenterID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _POID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _POID = reader.GetInt64("POID");
            _CustomCode = reader.GetString("CustomCode");
            _TransType = reader.GetInt32("TransType");
            _PODate = reader.GetDateTime("PODate");
            _Description = reader.GetString("Description");
            _SupplierID = reader.GetInt32("SupplierID");
            _Agent = reader.GetInt32("Agent");
            _ExpectedReceiptDate = reader.GetDateTime("ExpectedReceiptDate");
            _PaymentModeID = reader.GetInt32("PaymentModeID");
            _BillTo = reader.GetString("BillTo");
            _ShipTo = reader.GetString("ShipTo");
            _ShipMode = reader.GetInt32("ShipMode");
            _CurrencyID = reader.GetInt32("CurrencyID");
            _OfferingCurrencyID = reader.GetInt32("OfferingCurrencyID");
            _CurrencyOfferingRate = reader.GetDecimal("CurrencyOfferingRate");
            _StatusID = reader.GetInt32("StatusID");
            _BranchID = reader.GetInt32("BranchID");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _CompanyID = reader.GetInt32("CompanyID");
            _IsDeleted = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        private void SetDataFind(IDataRecord reader)
        {
            _POID = reader.GetInt64("POID");
            _CustomCode = reader.GetString("CustomCode");
            _PODate = reader.GetDateTime("PODate");
            _Description = reader.GetString("Description");
            _CostCenter = reader.GetString("CostCenter");
            _Branch = reader.GetString("Branch");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _BranchID = reader.GetInt32("BranchID");
            _ShipTo = reader.GetString("ShipTo");
            _BillTo = reader.GetString("BillTo");
            _SupplierID = reader.GetInt32("SupplierID");
            _ExpectedReceiptDate = reader.GetDateTime("ExpectedReceiptDate");
            SetUnchanged();
        }
        public static CustomList<POMaster> GetAllPOMasterFind()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<POMaster> ItemRequisitionMasterCollection = new CustomList<POMaster>();
            IDataReader reader = null;
            String sql = "spFindPO";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    POMaster newPOMaster = new POMaster();
                    newPOMaster.SetDataFind(reader);
                    ItemRequisitionMasterCollection.Add(newPOMaster);
                }
                return ItemRequisitionMasterCollection;
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
        public static CustomList<POMaster> GetAllPOMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<POMaster> POMasterCollection = new CustomList<POMaster>();
            IDataReader reader = null;
            const String sql = "select *from POMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    POMaster newPOMaster = new POMaster();
                    newPOMaster.SetData(reader);
                    POMasterCollection.Add(newPOMaster);
                }
                return POMasterCollection;
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
