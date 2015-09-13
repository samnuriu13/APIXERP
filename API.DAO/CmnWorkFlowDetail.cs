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
    public class CmnWorkFlowDetail : BaseItem
    {
        public CmnWorkFlowDetail()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _WorkFlowDetailID;
        [Browsable(true), DisplayName("WorkFlowDetailID")]
        public System.Int32 WorkFlowDetailID
        {
            get
            {
                return _WorkFlowDetailID;
            }
            set
            {
                if (PropertyChanged(_WorkFlowDetailID, value))
                    _WorkFlowDetailID = value;
            }
        }

        private System.Int32 _WorkFlowID;
        [Browsable(true), DisplayName("WorkFlowID")]
        public System.Int32 WorkFlowID
        {
            get
            {
                return _WorkFlowID;
            }
            set
            {
                if (PropertyChanged(_WorkFlowID, value))
                    _WorkFlowID = value;
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

        private System.String _UserID;
        [Browsable(true), DisplayName("UserID")]
        public System.String UserID
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

        private System.Decimal _AmountLimit;
        [Browsable(true), DisplayName("AmountLimit")]
        public System.Decimal AmountLimit
        {
            get
            {
                return _AmountLimit;
            }
            set
            {
                if (PropertyChanged(_AmountLimit, value))
                    _AmountLimit = value;
            }
        }

        private System.Int32 _Sequence;
        [Browsable(true), DisplayName("Sequence")]
        public System.Int32 Sequence
        {
            get
            {
                return _Sequence;
            }
            set
            {
                if (PropertyChanged(_Sequence, value))
                    _Sequence = value;
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
                parameterValues = new Object[] { _WorkFlowID, _StatusID, _UserID, _AmountLimit, _Sequence, _CompanyID, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _WorkFlowID, _StatusID, _UserID, _AmountLimit, _Sequence, _CompanyID, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _WorkFlowDetailID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _WorkFlowDetailID = reader.GetInt32("WorkFlowDetailID");
            _WorkFlowID = reader.GetInt32("WorkFlowID");
            _StatusID = reader.GetInt32("StatusID");
            _UserID = reader.GetString("UserID");
            _AmountLimit = reader.GetDecimal("AmountLimit");
            _Sequence = reader.GetInt32("Sequence");
            _CompanyID = reader.GetInt32("CompanyID");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        public static CustomList<CmnWorkFlowDetail> GetAllCmnWorkFlowDetail(Int32 WorkFlowID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnWorkFlowDetail> CmnWorkFlowDetailCollection = new CustomList<CmnWorkFlowDetail>();
            IDataReader reader = null;
            String sql = "select *from CmnWorkFlowDetail Where WorkFlowID="+WorkFlowID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnWorkFlowDetail newCmnWorkFlowDetail = new CmnWorkFlowDetail();
                    newCmnWorkFlowDetail.SetData(reader);
                    CmnWorkFlowDetailCollection.Add(newCmnWorkFlowDetail);
                }
                return CmnWorkFlowDetailCollection;
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
