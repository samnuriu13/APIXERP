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
    public class StockTransactionDetail : BaseItem
    {
        public StockTransactionDetail()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _StockTransDetailID;
        [Browsable(true), DisplayName("StockTransDetailID")]
        public System.Int64 StockTransDetailID
        {
            get
            {
                return _StockTransDetailID;
            }
            set
            {
                if (PropertyChanged(_StockTransDetailID, value))
                    _StockTransDetailID = value;
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

        private System.Int32 _PhaseID;
        [Browsable(true), DisplayName("PhaseID")]
        public System.Int32 PhaseID
        {
            get
            {
                return _PhaseID;
            }
            set
            {
                if (PropertyChanged(_PhaseID, value))
                    _PhaseID = value;
            }
        }

        private System.Int32 _TaskID;
        [Browsable(true), DisplayName("TaskID")]
        public System.Int32 TaskID
        {
            get
            {
                return _TaskID;
            }
            set
            {
                if (PropertyChanged(_TaskID, value))
                    _TaskID = value;
            }
        }

        private System.Int64 _ProductionLineID;
        [Browsable(true), DisplayName("ProductionLineID")]
        public System.Int64 ProductionLineID
        {
            get
            {
                return _ProductionLineID;
            }
            set
            {
                if (PropertyChanged(_ProductionLineID, value))
                    _ProductionLineID = value;
            }
        }

        private System.Int64 _MachineID;
        [Browsable(true), DisplayName("MachineID")]
        public System.Int64 MachineID
        {
            get
            {
                return _MachineID;
            }
            set
            {
                if (PropertyChanged(_MachineID, value))
                    _MachineID = value;
            }
        }

        private System.Int32 _ShiftID;
        [Browsable(true), DisplayName("ShiftID")]
        public System.Int32 ShiftID
        {
            get
            {
                return _ShiftID;
            }
            set
            {
                if (PropertyChanged(_ShiftID, value))
                    _ShiftID = value;
            }
        }

        private System.Int32 _EmployeeID;
        [Browsable(true), DisplayName("EmployeeID")]
        public System.Int32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                if (PropertyChanged(_EmployeeID, value))
                    _EmployeeID = value;
            }
        }

        private System.DateTime _FromDateTime;
        [Browsable(true), DisplayName("FromDateTime"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime FromDateTime
        {
            get
            {
                return _FromDateTime;
            }
            set
            {
                if (PropertyChanged(_FromDateTime, value))
                    _FromDateTime = value;
            }
        }

        private System.DateTime _ToDateTime;
        [Browsable(true), DisplayName("ToDateTime"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime ToDateTime
        {
            get
            {
                return _ToDateTime;
            }
            set
            {
                if (PropertyChanged(_ToDateTime, value))
                    _ToDateTime = value;
            }
        }




        private System.String _ItemCode;
        [Browsable(true), DisplayName("ItemCode")]
        public System.String ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                if (PropertyChanged(_ItemCode, value))
                    _ItemCode = value;
            }
        }

        private System.Int32 _ItemGroupID;
        [Browsable(true), DisplayName("ItemGroupID")]
        public System.Int32 ItemGroupID
        {
            get
            {
                return _ItemGroupID;
            }
            set
            {
                if (PropertyChanged(_ItemGroupID, value))
                    _ItemGroupID = value;
            }
        }

        private System.Int32 _ItemSubGroupID;
        [Browsable(true), DisplayName("ItemSubGroupID")]
        public System.Int32 ItemSubGroupID
        {
            get
            {
                return _ItemSubGroupID;
            }
            set
            {
                if (PropertyChanged(_ItemSubGroupID, value))
                    _ItemSubGroupID = value;
            }
        }

        private System.Int32 _UOMID;
        [Browsable(true), DisplayName("UOMID")]
        public System.Int32 UOMID
        {
            get
            {
                return _UOMID;
            }
            set
            {
                if (PropertyChanged(_UOMID, value))
                    _UOMID = value;
            }
        }

        private System.Decimal _WeightPerUnit;
        [Browsable(true), DisplayName("WeightPerUnit")]
        public System.Decimal WeightPerUnit
        {
            get
            {
                return _WeightPerUnit;
            }
            set
            {
                if (PropertyChanged(_WeightPerUnit, value))
                    _WeightPerUnit = value;
            }
        }

        private System.String _SourceReference;
        [Browsable(true), DisplayName("SourceReference")]
        public System.String SourceReference
        {
            get
            {
                return _SourceReference;
            }
            set
            {
                if (PropertyChanged(_SourceReference, value))
                    _SourceReference = value;
            }
        }

        private System.String _SourceReferenceType;
        [Browsable(true), DisplayName("SourceReferenceType")]
        public System.String SourceReferenceType
        {
            get
            {
                return _SourceReferenceType;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceType, value))
                    _SourceReferenceType = value;
            }
        }

        private System.Int32 _SourceReferenceTypeID;
        [Browsable(true), DisplayName("SourceReferenceTypeID")]
        public System.Int32 SourceReferenceTypeID
        {
            get
            {
                return _SourceReferenceTypeID;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceTypeID, value))
                    _SourceReferenceTypeID = value;
            }
        }

        private System.Int64 _SourceReferenceID;
        [Browsable(true), DisplayName("SourceReferenceID")]
        public System.Int64 SourceReferenceID
        {
            get
            {
                return _SourceReferenceID;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceID, value))
                    _SourceReferenceID = value;
            }
        }

        private System.Int64 _SourceReferenceDetailID;
        [Browsable(true), DisplayName("SourceReferenceDetailID")]
        public System.Int64 SourceReferenceDetailID
        {
            get
            {
                return _SourceReferenceDetailID;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceDetailID, value))
                    _SourceReferenceDetailID = value;
            }
        }

        private System.String _SourceReferenceNo;
        [Browsable(true), DisplayName("SourceReferenceNo")]
        public System.String SourceReferenceNo
        {
            get
            {
                return _SourceReferenceNo;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceNo, value))
                    _SourceReferenceNo = value;
            }
        }

        private System.Int32 _SourceReferenceImage;
        [Browsable(true), DisplayName("SourceReferenceImage")]
        public System.Int32 SourceReferenceImage
        {
            get
            {
                return _SourceReferenceImage;
            }
            set
            {
                if (PropertyChanged(_SourceReferenceImage, value))
                    _SourceReferenceImage = value;
            }
        }

        private System.DateTime _SourceReferecnceDate;
        [Browsable(true), DisplayName("SourceReferecnceDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime SourceReferecnceDate
        {
            get
            {
                return _SourceReferecnceDate;
            }
            set
            {
                if (PropertyChanged(_SourceReferecnceDate, value))
                    _SourceReferecnceDate = value;
            }
        }

        private System.Int32 _BaseReferenceTypeID;
        [Browsable(true), DisplayName("BaseReferenceTypeID")]
        public System.Int32 BaseReferenceTypeID
        {
            get
            {
                return _BaseReferenceTypeID;
            }
            set
            {
                if (PropertyChanged(_BaseReferenceTypeID, value))
                    _BaseReferenceTypeID = value;
            }
        }

        private System.Int64 _BaseReferenceID;
        [Browsable(true), DisplayName("BaseReferenceID")]
        public System.Int64 BaseReferenceID
        {
            get
            {
                return _BaseReferenceID;
            }
            set
            {
                if (PropertyChanged(_BaseReferenceID, value))
                    _BaseReferenceID = value;
            }
        }

        private System.Int64 _BaseReferenceDetailID;
        [Browsable(true), DisplayName("BaseReferenceDetailID")]
        public System.Int64 BaseReferenceDetailID
        {
            get
            {
                return _BaseReferenceDetailID;
            }
            set
            {
                if (PropertyChanged(_BaseReferenceDetailID, value))
                    _BaseReferenceDetailID = value;
            }
        }

        private System.String _BaseReferenceNo;
        [Browsable(true), DisplayName("BaseReferenceNo")]
        public System.String BaseReferenceNo
        {
            get
            {
                return _BaseReferenceNo;
            }
            set
            {
                if (PropertyChanged(_BaseReferenceNo, value))
                    _BaseReferenceNo = value;
            }
        }

        private System.Int32 _BaseReferenceImage;
        [Browsable(true), DisplayName("BaseReferenceImage")]
        public System.Int32 BaseReferenceImage
        {
            get
            {
                return _BaseReferenceImage;
            }
            set
            {
                if (PropertyChanged(_BaseReferenceImage, value))
                    _BaseReferenceImage = value;
            }
        }

        private System.DateTime _BaseReferecnceDate;
        [Browsable(true), DisplayName("BaseReferecnceDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime BaseReferecnceDate
        {
            get
            {
                return _BaseReferecnceDate;
            }
            set
            {
                if (PropertyChanged(_BaseReferecnceDate, value))
                    _BaseReferecnceDate = value;
            }
        }

        private System.Boolean _IsQCPending;
        [Browsable(true), DisplayName("IsQCPending")]
        public System.Boolean IsQCPending
        {
            get
            {
                return _IsQCPending;
            }
            set
            {
                if (PropertyChanged(_IsQCPending, value))
                    _IsQCPending = value;
            }
        }

        private System.String _ItemTrackingID;
        [Browsable(true), DisplayName("ItemTrackingID")]
        public System.String ItemTrackingID
        {
            get
            {
                return _ItemTrackingID;
            }
            set
            {
                if (PropertyChanged(_ItemTrackingID, value))
                    _ItemTrackingID = value;
            }
        }

        private System.Decimal _ItemQty;
        [Browsable(true), DisplayName("ItemQty")]
        public System.Decimal ItemQty
        {
            get
            {
                return _ItemQty;
            }
            set
            {
                if (PropertyChanged(_ItemQty, value))
                    _ItemQty = value;
            }
        }

        private System.Decimal _SampleQty;
        [Browsable(true), DisplayName("SampleQty")]
        public System.Decimal SampleQty
        {
            get
            {
                return _SampleQty;
            }
            set
            {
                if (PropertyChanged(_SampleQty, value))
                    _SampleQty = value;
            }
        }

        private System.Decimal _OverQty;
        [Browsable(true), DisplayName("OverQty")]
        public System.Decimal OverQty
        {
            get
            {
                return _OverQty;
            }
            set
            {
                if (PropertyChanged(_OverQty, value))
                    _OverQty = value;
            }
        }

        private System.Decimal _TotalQty;
        [Browsable(true), DisplayName("TotalQty")]
        public System.Decimal TotalQty
        {
            get
            {
                return _TotalQty;
            }
            set
            {
                if (PropertyChanged(_TotalQty, value))
                    _TotalQty = value;
            }
        }

        private System.Decimal _UnitPrice;
        [Browsable(true), DisplayName("UnitPrice")]
        public System.Decimal UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                if (PropertyChanged(_UnitPrice, value))
                    _UnitPrice = value;
            }
        }

        private System.Decimal _Amount;
        [Browsable(true), DisplayName("Amount")]
        public System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                if (PropertyChanged(_Amount, value))
                    _Amount = value;
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
                parameterValues = new Object[] { _CustomCode, _StockTransID, _PhaseID, _TaskID, _ProductionLineID, _MachineID, _ShiftID, _EmployeeID, _FromDateTime.Value(StaticInfo.DateFormat), _ToDateTime.Value(StaticInfo.DateFormat), _ItemCode, _UOMID, _WeightPerUnit, _SourceReferenceTypeID, _SourceReferenceID, _SourceReferenceDetailID, _SourceReferenceNo, _SourceReferenceImage, _SourceReferecnceDate.Value(StaticInfo.DateFormat), _BaseReferenceTypeID, _BaseReferenceID, _BaseReferenceDetailID, _BaseReferenceNo, _BaseReferenceImage, _BaseReferecnceDate.Value(StaticInfo.DateFormat), _IsQCPending, _ItemTrackingID, _ItemQty, _SampleQty, _OverQty, _UnitPrice, _IsDeleted, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _StockTransDetailID, _CustomCode, _StockTransID, _PhaseID, _TaskID, _ProductionLineID, _MachineID, _ShiftID, _EmployeeID, _FromDateTime.Value(StaticInfo.DateFormat), _ToDateTime.Value(StaticInfo.DateFormat), _ItemCode, _UOMID, _WeightPerUnit, _SourceReferenceTypeID, _SourceReferenceID, _SourceReferenceDetailID, _SourceReferenceNo, _SourceReferenceImage, _SourceReferecnceDate.Value(StaticInfo.DateFormat), _BaseReferenceTypeID, _BaseReferenceID, _BaseReferenceDetailID, _BaseReferenceNo, _BaseReferenceImage, _BaseReferecnceDate.Value(StaticInfo.DateFormat), _IsQCPending, _ItemTrackingID, _ItemQty, _SampleQty, _OverQty, _UnitPrice, _IsDeleted, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _StockTransDetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _StockTransDetailID = reader.GetInt64("StockTransDetailID");
            _CustomCode = reader.GetString("CustomCode");
            _StockTransID = reader.GetInt64("StockTransID");
            _PhaseID = reader.GetInt32("PhaseID");
            _TaskID = reader.GetInt32("TaskID");
            _ProductionLineID = reader.GetInt64("ProductionLineID");
            _MachineID = reader.GetInt64("MachineID");
            _ShiftID = reader.GetInt32("ShiftID");
            _EmployeeID = reader.GetInt32("EmployeeID");
            _FromDateTime = reader.GetDateTime("FromDateTime");
            _ToDateTime = reader.GetDateTime("ToDateTime");
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            _ItemSubGroupID = reader.GetInt32("ItemSubGroupID");
            _ItemCode = reader.GetString("ItemCode");
            _UOMID = reader.GetInt32("UOMID");
            _WeightPerUnit = reader.GetDecimal("WeightPerUnit");
            _SourceReferenceTypeID = reader.GetInt32("SourceReferenceTypeID");
            _SourceReferenceID = reader.GetInt64("SourceReferenceID");
            _SourceReferenceDetailID = reader.GetInt64("SourceReferenceDetailID");
            _SourceReferenceNo = reader.GetString("SourceReferenceNo");
            _SourceReferenceImage = reader.GetInt32("SourceReferenceImage");
            _SourceReferecnceDate = reader.GetDateTime("SourceReferecnceDate");
            _BaseReferenceTypeID = reader.GetInt32("BaseReferenceTypeID");
            _BaseReferenceID = reader.GetInt64("BaseReferenceID");
            _BaseReferenceDetailID = reader.GetInt64("BaseReferenceDetailID");
            _BaseReferenceNo = reader.GetString("BaseReferenceNo");
            _BaseReferenceImage = reader.GetInt32("BaseReferenceImage");
            _BaseReferecnceDate = reader.GetDateTime("BaseReferecnceDate");
            _IsQCPending = reader.GetBoolean("IsQCPending");
            _ItemTrackingID = reader.GetString("ItemTrackingID");
            _ItemQty = reader.GetDecimal("ItemQty");
            _SampleQty = reader.GetDecimal("SampleQty");
            _OverQty = reader.GetDecimal("OverQty");
            _UnitPrice = reader.GetDecimal("UnitPrice");
            _IsDeleted = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        public static CustomList<StockTransactionDetail> GetAllStockTransactionDetail(Int64 StockTransID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<StockTransactionDetail> StockTransactionDetailCollection = new CustomList<StockTransactionDetail>();
            IDataReader reader = null;
            String sql = "spGetStockTransDetail " + StockTransID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    StockTransactionDetail newStockTransactionDetail = new StockTransactionDetail();
                    newStockTransactionDetail.SetData(reader);
                    StockTransactionDetailCollection.Add(newStockTransactionDetail);
                }
                return StockTransactionDetailCollection;
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