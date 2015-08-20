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
    public class PODetail : BaseItem
    {
        public PODetail()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _PODetailID;
        [Browsable(true), DisplayName("PODetailID")]
        public System.Int64 PODetailID
        {
            get
            {
                return _PODetailID;
            }
            set
            {
                if (PropertyChanged(_PODetailID, value))
                    _PODetailID = value;
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

        private System.Decimal _TotalAmount;
        [Browsable(true), DisplayName("TotalAmount")]
        public System.Decimal TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                if (PropertyChanged(_TotalAmount, value))
                    _TotalAmount = value;
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

        private System.Decimal _ReciptQty;
        [Browsable(true), DisplayName("ReciptQty")]
        public System.Decimal ReciptQty
        {
            get
            {
                return _ReciptQty;
            }
            set
            {
                if (PropertyChanged(_ReciptQty, value))
                    _ReciptQty = value;
            }
        }

        private System.Decimal _Balance;
        [Browsable(true), DisplayName("Balance")]
        public System.Decimal Balance
        {
            get
            {
                return _Balance;
            }
            set
            {
                if (PropertyChanged(_Balance, value))
                    _Balance = value;
            }
        }

        private System.Boolean _IsSampleRequired;
        [Browsable(true), DisplayName("IsSampleRequired")]
        public System.Boolean IsSampleRequired
        {
            get
            {
                return _IsSampleRequired;
            }
            set
            {
                if (PropertyChanged(_IsSampleRequired, value))
                    _IsSampleRequired = value;
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
                parameterValues = new Object[] { _CustomCode, _POID, _ItemCode, _UOMID, _WeightPerUnit, _ItemQty, _SampleQty, _OverQty, _UnitPrice, _ReciptQty, _IsSampleRequired, _SourceReferenceTypeID, _SourceReferenceID, _SourceReferenceDetailID, _SourceReferenceNo, _SourceReferenceImage, _SourceReferecnceDate.Value(StaticInfo.DateFormat), _BaseReferenceTypeID, _BaseReferenceID, _BaseReferenceDetailID, _BaseReferenceNo, _BaseReferenceImage, _BaseReferecnceDate.Value(StaticInfo.DateFormat), _IsDeleted, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _PODetailID,_CustomCode, _POID, _ItemCode, _UOMID, _WeightPerUnit, _ItemQty, _SampleQty, _OverQty, _UnitPrice, _ReciptQty, _IsSampleRequired, _SourceReferenceTypeID, _SourceReferenceID, _SourceReferenceDetailID, _SourceReferenceNo, _SourceReferenceImage, _SourceReferecnceDate.Value(StaticInfo.DateFormat), _BaseReferenceTypeID, _BaseReferenceID, _BaseReferenceDetailID, _BaseReferenceNo, _BaseReferenceImage, _BaseReferecnceDate.Value(StaticInfo.DateFormat), _IsDeleted, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _PODetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _PODetailID = reader.GetInt64("PODetailID");
            _CustomCode = reader.GetString("CustomCode");
            _POID = reader.GetInt64("POID");
            _ItemCode = reader.GetString("ItemCode");
           _ItemGroupID = reader.GetInt32("ItemGroupID");
           _ItemSubGroupID = reader.GetInt32("ItemSubGroupID");
            _UOMID = reader.GetInt32("UOMID");
            _WeightPerUnit = reader.GetDecimal("WeightPerUnit");
            _ItemQty = reader.GetDecimal("ItemQty");
            _SampleQty = reader.GetDecimal("SampleQty");
            _OverQty = reader.GetDecimal("OverQty");
            _TotalQty = reader.GetDecimal("TotalQty");
            _TotalAmount = reader.GetDecimal("TotalAmount");
            _UnitPrice = reader.GetDecimal("UnitPrice");
            _ReciptQty = reader.GetDecimal("ReciptQty");
            _Balance = reader.GetDecimal("Balance");
            _IsSampleRequired = reader.GetBoolean("IsSampleRequired");
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
            _IsDeleted = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        public static CustomList<PODetail> GetAllPODetail(Int64 POID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<PODetail> PODetailCollection = new CustomList<PODetail>();
            IDataReader reader = null;
            String sql = "spGetPODetail " + POID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    PODetail newPODetail = new PODetail();
                    newPODetail.SetData(reader);
                    PODetailCollection.Add(newPODetail);
                }
                return PODetailCollection;
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
        public static CustomList<PODetail> GetAllPODetail()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<PODetail> PODetailCollection = new CustomList<PODetail>();
            IDataReader reader = null;
            const String sql = "select *from PODetail";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    PODetail newPODetail = new PODetail();
                    newPODetail.SetData(reader);
                    PODetailCollection.Add(newPODetail);
                }
                return PODetailCollection;
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
