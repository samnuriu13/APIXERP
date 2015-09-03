using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using System.Data.SqlClient;

namespace API.DAO
{
    [Serializable]
    public class CmnTransactionReference : BaseItem
    {
        public CmnTransactionReference()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _TransRefID;
        [Browsable(true), DisplayName("TransRefID")]
        public System.Int32 TransRefID
        {
            get
            {
                return _TransRefID;
            }
            set
            {
                if (PropertyChanged(_TransRefID, value))
                    _TransRefID = value;
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

        private System.Int32 _TransRef;
        [Browsable(true), DisplayName("TransRef")]
        public System.Int32 TransRef
        {
            get
            {
                return _TransRef;
            }
            set
            {
                if (PropertyChanged(_TransRef, value))
                    _TransRef = value;
            }
        }

        private System.Int32 _TransTypeID;
        [Browsable(true), DisplayName("TransTypeID")]
        public System.Int32 TransTypeID
        {
            get
            {
                return _TransTypeID;
            }
            set
            {
                if (PropertyChanged(_TransTypeID, value))
                    _TransTypeID = value;
            }
        }

        private System.String _ReferenceMasterTable;
        [Browsable(true), DisplayName("ReferenceMasterTable")]
        public System.String ReferenceMasterTable
        {
            get
            {
                return _ReferenceMasterTable;
            }
            set
            {
                if (PropertyChanged(_ReferenceMasterTable, value))
                    _ReferenceMasterTable = value;
            }
        }

        private System.String _ReferenceDetailTable;
        [Browsable(true), DisplayName("ReferenceDetailTable")]
        public System.String ReferenceDetailTable
        {
            get
            {
                return _ReferenceDetailTable;
            }
            set
            {
                if (PropertyChanged(_ReferenceDetailTable, value))
                    _ReferenceDetailTable = value;
            }
        }

        private System.String _DetailForeignKey;
        [Browsable(true), DisplayName("DetailForeignKey")]
        public System.String DetailForeignKey
        {
            get
            {
                return _DetailForeignKey;
            }
            set
            {
                if (PropertyChanged(_DetailForeignKey, value))
                    _DetailForeignKey = value;
            }
        }

        private System.String _TransactionTypeColumn;
        [Browsable(true), DisplayName("TransactionTypeColumn")]
        public System.String TransactionTypeColumn
        {
            get
            {
                return _TransactionTypeColumn;
            }
            set
            {
                if (PropertyChanged(_TransactionTypeColumn, value))
                    _TransactionTypeColumn = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _TransRefID, _CustomCode, _TransRef, _TransTypeID, _ReferenceMasterTable, _ReferenceDetailTable, _DetailForeignKey, _TransactionTypeColumn, _CompanyID };
            else if (IsModified)
                parameterValues = new Object[] { _TransRefID, _CustomCode, _TransRef, _TransTypeID, _ReferenceMasterTable, _ReferenceDetailTable, _DetailForeignKey, _TransactionTypeColumn, _CompanyID };
            else if (IsDeleted)
                parameterValues = new Object[] { _TransRefID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _TransRefID = reader.GetInt32("TransRefID");
            _CustomCode = reader.GetString("CustomCode");
            _TransRef = reader.GetInt32("TransRef");
            _TransTypeID = reader.GetInt32("TransTypeID");
            _ReferenceMasterTable = reader.GetString("ReferenceMasterTable");
            _ReferenceDetailTable = reader.GetString("ReferenceDetailTable");
            _DetailForeignKey = reader.GetString("DetailForeignKey");
            _TransactionTypeColumn = reader.GetString("TransactionTypeColumn");
            _CompanyID = reader.GetInt32("CompanyID");
            SetUnchanged();
        }

        private void SetDataForDropdown(IDataRecord reader)
        {
            _TransRefID = reader.GetInt32("TransRefID");
            _TransRef = reader.GetInt32("TransRef");
            SetUnchanged();
        }

        public static CustomList<CmnTransactionReference> GetAllReferenceType(Int32 TransRefID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnTransactionReference> CmnTransactionReferenceCollection = new CustomList<CmnTransactionReference>();
            IDataReader reader = null;
            String sql = "spGetRefType " + TransRefID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnTransactionReference newCmnTransactionReference = new CmnTransactionReference();
                    newCmnTransactionReference.SetDataForDropdown(reader);
                    CmnTransactionReferenceCollection.Add(newCmnTransactionReference);
                }
                return CmnTransactionReferenceCollection;
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

        public static CustomList<CmnTransactionReference> GetAllReferenceType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnTransactionReference> CmnTransRefCollection = new CustomList<CmnTransactionReference>();
            IDataReader reader = null;
            const String sql = "select TABLE_NAME as ReferenceDetailTable,1 as TransRefID,'1' as CustomCode,1 as TransRef,1 as TransTypeID,'1' as ReferenceMasterTable,'1' as DetailForeignKey,'1' as TransactionTypeColumn, 1 as CompanyID from API.INFORMATION_SCHEMA.TABLES";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnTransactionReference newCmnTransactionReference = new CmnTransactionReference();
                    newCmnTransactionReference.SetData(reader);
                    CmnTransRefCollection.Add(newCmnTransactionReference);
                }
                CmnTransRefCollection.InsertSpName = "spInsertCmnTransRef";
                CmnTransRefCollection.UpdateSpName = "spUpdateCmnTransRef";
                CmnTransRefCollection.DeleteSpName = "spDeleteCmnTransRef";
                return CmnTransRefCollection;
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

        public static CustomList<CmnTransactionReference> GetAllDetailForeignKey(string referenceDetailTables)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnTransactionReference> CmnTransRefCollection = new CustomList<CmnTransactionReference>();
            IDataReader reader = null;
            string sql = "select '1' as ReferenceDetailTable,1 as TransRefID,'1' as CustomCode,1 as TransRef, 1 as TransTypeID,'1' as ReferenceMasterTable,COLUMN_NAME as DetailForeignKey,'1' as TransactionTypeColumn,  1 as CompanyID from API.INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + referenceDetailTables + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnTransactionReference newCmnTransactionReference = new CmnTransactionReference();
                    newCmnTransactionReference.SetData(reader);
                    CmnTransRefCollection.Add(newCmnTransactionReference);
                }
                CmnTransRefCollection.InsertSpName = "spInsertCmnTransRef";
                CmnTransRefCollection.UpdateSpName = "spUpdateCmnTransRef";
                CmnTransRefCollection.DeleteSpName = "spDeleteCmnTransRef";
                return CmnTransRefCollection;
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

        public CustomList<CmnTransactionReference> GetAllReferenceDetailTableList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnTransactionReference> CmnTransRefCollection = new CustomList<CmnTransactionReference>();
            IDataReader reader = null;
            const String sql = "select TABLE_NAME as ReferenceDetailTable from API.INFORMATION_SCHEMA.TABLES";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnTransactionReference newCmnTransactionReference = new CmnTransactionReference();
                    newCmnTransactionReference.SetData(reader);
                    CmnTransRefCollection.Add(newCmnTransactionReference);
                }
                CmnTransRefCollection.InsertSpName = "spInsertCmnTransRef";
                CmnTransRefCollection.UpdateSpName = "spUpdateCmnTransRef";
                CmnTransRefCollection.DeleteSpName = "spDeleteCmnTransRef";
                return CmnTransRefCollection;
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