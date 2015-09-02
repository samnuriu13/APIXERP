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
    public class ItemRequisitionMaster : BaseItem
    {
        public ItemRequisitionMaster()
        {
            SetAdded();
        }

        #region Properties

        private System.Int64 _RequisitionID;
        [Browsable(true), DisplayName("RequisitionID")]
        public System.Int64 RequisitionID
        {
            get
            {
                return _RequisitionID;
            }
            set
            {
                if (PropertyChanged(_RequisitionID, value))
                    _RequisitionID = value;
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

        private System.DateTime _RequisitionDate;
        [Browsable(true), DisplayName("RequisitionDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime RequisitionDate
        {
            get
            {
                return _RequisitionDate;
            }
            set
            {
                if (PropertyChanged(_RequisitionDate, value))
                    _RequisitionDate = value;
            }
        }

        private System.Int32 _RequisitionTypeID;
        [Browsable(true), DisplayName("RequisitionTypeID")]
        public System.Int32 RequisitionTypeID
        {
            get
            {
                return _RequisitionTypeID;
            }
            set
            {
                if (PropertyChanged(_RequisitionTypeID, value))
                    _RequisitionTypeID = value;
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

        private System.Boolean _IsDeleted1;
        [Browsable(true), DisplayName("IsDeleted1")]
        public System.Boolean IsDeleted1
        {
            get
            {
                return _IsDeleted1;
            }
            set
            {
                if (PropertyChanged(_IsDeleted1, value))
                    _IsDeleted1 = value;
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
                parameterValues = new Object[] { _CustomCode, _RequisitionDate.Value(StaticInfo.DateFormat), _RequisitionTypeID, _MachineID, _UserID, _CostCenterID, _ProjectID, _DeptID, _Description, _StatusID, _CompanyID, _IsDeleted1, _Transfer };
            else if (IsModified)
                parameterValues = new Object[] { _RequisitionID,_CustomCode, _RequisitionDate.Value(StaticInfo.DateFormat), _RequisitionTypeID, _MachineID, _UserID, _CostCenterID, _ProjectID, _DeptID, _Description, _StatusID, _CompanyID, _IsDeleted1, _Transfer };
            else if (IsDeleted)
                parameterValues = new Object[] { _RequisitionID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _RequisitionID = reader.GetInt64("RequisitionID");
            _CustomCode = reader.GetString("CustomCode");
            _RequisitionDate = reader.GetDateTime("RequisitionDate");
            _RequisitionTypeID = reader.GetInt32("RequisitionTypeID");
            _MachineID = reader.GetInt64("MachineID");
            _UserID = reader.GetInt32("UserID");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _ProjectID = reader.GetInt32("ProjectID");
            _DeptID = reader.GetInt32("DeptID");
            _Description = reader.GetString("Description");
            _StatusID = reader.GetInt32("StatusID");
            _CompanyID = reader.GetInt32("CompanyID");
            _IsDeleted1 = reader.GetBoolean("IsDeleted");
            _Transfer = reader.GetBoolean("Transfer");
            SetUnchanged();
        }
        private void SetDataFind(IDataRecord reader)
        {
            _RequisitionID = reader.GetInt64("RequisitionID");
            _CustomCode = reader.GetString("CustomCode");
            _RequisitionDate = reader.GetDateTime("RequisitionDate");
            _Description = reader.GetString("Description");
            _CostCenter = reader.GetString("CostCenter");
            _Department = reader.GetString("Department");
            _CostCenterID = reader.GetInt32("CostCenterID");
            _DeptID = reader.GetInt32("DeptID");
            SetUnchanged();
        }
        public static CustomList<ItemRequisitionMaster> GetAllItemRequisitionMaster(Int32 TransType)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemRequisitionMaster> ItemRequisitionMasterCollection = new CustomList<ItemRequisitionMaster>();
            IDataReader reader = null;
            String sql = "spFindRequisition " + TransType;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemRequisitionMaster newItemRequisitionMaster = new ItemRequisitionMaster();
                    newItemRequisitionMaster.SetDataFind(reader);
                    ItemRequisitionMasterCollection.Add(newItemRequisitionMaster);
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
        public static CustomList<ItemRequisitionMaster> GetAllItemRequisitionMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemRequisitionMaster> ItemRequisitionMasterCollection = new CustomList<ItemRequisitionMaster>();
            IDataReader reader = null;
            const String sql = "select *from ItemRequisitionMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemRequisitionMaster newItemRequisitionMaster = new ItemRequisitionMaster();
                    newItemRequisitionMaster.SetData(reader);
                    ItemRequisitionMasterCollection.Add(newItemRequisitionMaster);
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
    }
}
