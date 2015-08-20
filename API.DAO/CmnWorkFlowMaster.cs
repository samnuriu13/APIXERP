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
    public class CmnWorkFlowMaster : BaseItem
    {
        public CmnWorkFlowMaster()
        {
            SetAdded();
        }

        #region Properties

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

        private System.Boolean _IsAmountLimit;
        [Browsable(true), DisplayName("IsAmountLimit")]
        public System.Boolean IsAmountLimit
        {
            get
            {
                return _IsAmountLimit;
            }
            set
            {
                if (PropertyChanged(_IsAmountLimit, value))
                    _IsAmountLimit = value;
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

        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }

        private System.String _DocName;
        [Browsable(true), DisplayName("DocName")]
        public System.String DocName
        {
            get
            {
                return _DocName;
            }
            set
            {
                if (PropertyChanged(_DocName, value))
                    _DocName = value;
            }
        }

        private System.Int32 _ProjectID;
        [Browsable(true), DisplayName("ProjectID")]
        public System.Int32 ProjectID
        {
            get
            {
                return _ProjectID;
            }
            set
            {
                if (PropertyChanged(_ProjectID, value))
                    _ProjectID = value;
            }
        }

        private System.Int32 _DeptID;
        [Browsable(true), DisplayName("DeptID")]
        public System.Int32 DeptID
        {
            get
            {
                return _DeptID;
            }
            set
            {
                if (PropertyChanged(_DeptID, value))
                    _DeptID = value;
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
                parameterValues = new Object[] { _DocListID, _IsAmountLimit, _Sequence, _CostCenterID, _ProjectID, _DeptID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _WorkFlowID, _DocListID, _IsAmountLimit, _Sequence, _CostCenterID, _ProjectID, _DeptID, _CompanyID, _IsDeleted, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _WorkFlowID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _WorkFlowID = reader.GetInt32("WorkFlowID");
            _DocListID = reader.GetInt32("DocListID");
            _IsAmountLimit = reader.GetBoolean("IsAmountLimit");
            _Sequence = reader.GetInt32("Sequence");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _ProjectID = reader.GetInt32("ProjectID");
            _DeptID = reader.GetInt32("DeptID");
            _CompanyID = reader.GetInt32("CompanyID");
            _IsDeleted = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }

        private void SetDataFind(IDataRecord reader)
        {
            _WorkFlowID = reader.GetInt32("WorkFlowID");
            _DocListID = reader.GetInt32("DocListID");
            _Sequence = reader.GetInt32("Sequence");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _DeptID = reader.GetInt32("DeptID");
            _DocName = reader.GetString("DisplayMember");
            _Department = reader.GetString("Department");
            _CostCenter = reader.GetString("CostCenter");
            SetUnchanged();
        }
        public static CustomList<CmnWorkFlowMaster> GetAllCmnWorkFlowMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnWorkFlowMaster> CmnWorkFlowMasterCollection = new CustomList<CmnWorkFlowMaster>();
            IDataReader reader = null;
            const String sql = "select *from CmnWorkFlowMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnWorkFlowMaster newCmnWorkFlowMaster = new CmnWorkFlowMaster();
                    newCmnWorkFlowMaster.SetData(reader);
                    CmnWorkFlowMasterCollection.Add(newCmnWorkFlowMaster);
                }
                return CmnWorkFlowMasterCollection;
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
        public static CustomList<CmnWorkFlowMaster> GetAllCmnWorkFlowMasterFind()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnWorkFlowMaster> CmnWorkFlowMasterCollection = new CustomList<CmnWorkFlowMaster>();
            IDataReader reader = null;
            String sql = "spFindWorkFlow";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnWorkFlowMaster newCmnWorkFlowMaster = new CmnWorkFlowMaster();
                    newCmnWorkFlowMaster.SetDataFind(reader);
                    CmnWorkFlowMasterCollection.Add(newCmnWorkFlowMaster);
                }
                return CmnWorkFlowMasterCollection;
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
