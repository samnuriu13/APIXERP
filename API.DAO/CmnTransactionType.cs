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
	public class CmnTransactionType : BaseItem
	{
		public CmnTransactionType()
		{
			SetAdded();
		}
		
#region Properties

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

		private System.String _TransTypeName;
		[Browsable(true), DisplayName("TransTypeName")]
		public System.String TransTypeName 
		{
			get
			{
				return _TransTypeName;
			}
			set
			{
			if (PropertyChanged(_TransTypeName, value))
					_TransTypeName = value;
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

		private System.Boolean _IsStockUpdate;
		[Browsable(true), DisplayName("IsStockUpdate")]
		public System.Boolean IsStockUpdate 
		{
			get
			{
				return _IsStockUpdate;
			}
			set
			{
			if (PropertyChanged(_IsStockUpdate, value))
					_IsStockUpdate = value;
			}
		}

		private System.Boolean _IsAccountingUpdate;
		[Browsable(true), DisplayName("IsAccountingUpdate")]
		public System.Boolean IsAccountingUpdate 
		{
			get
			{
				return _IsAccountingUpdate;
			}
			set
			{
			if (PropertyChanged(_IsAccountingUpdate, value))
					_IsAccountingUpdate = value;
			}
		}

		private System.Boolean _IsCostingUpdate;
		[Browsable(true), DisplayName("IsCostingUpdate")]
		public System.Boolean IsCostingUpdate 
		{
			get
			{
				return _IsCostingUpdate;
			}
			set
			{
			if (PropertyChanged(_IsCostingUpdate, value))
					_IsCostingUpdate = value;
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
				parameterValues = new Object[] {_CustomCode,_TransTypeName,_DocListID,_IsStockUpdate,_IsAccountingUpdate,_IsCostingUpdate,_ProjectID,_CostCenterID,_CompanyID,_IsDeleted,_Transfer};
			else if (IsModified)
				parameterValues = new Object[] {_TransTypeID,_CustomCode,_TransTypeName,_DocListID,_IsStockUpdate,_IsAccountingUpdate,_IsCostingUpdate,_ProjectID,_CostCenterID,_CompanyID,_IsDeleted,_Transfer};
			else if (IsDeleted)
				parameterValues = new Object[] {_TransTypeID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_TransTypeID = reader.GetInt32("TransTypeID");
			_CustomCode = reader.GetString("CustomCode");
			_TransTypeName = reader.GetString("TransTypeName");
			_DocListID = reader.GetInt32("DocListID");
			_IsStockUpdate = reader.GetBoolean("IsStockUpdate");
			_IsAccountingUpdate = reader.GetBoolean("IsAccountingUpdate");
			_IsCostingUpdate = reader.GetBoolean("IsCostingUpdate");
			_ProjectID = reader.GetInt32("ProjectID");
			_CostCenterID = reader.GetInt32("CostCenterID");
			_CompanyID = reader.GetInt32("CompanyID");
			_IsDeleted = reader.GetBoolean("IsDeleted");
			_Transfer = reader.GetBoolean("Transfer");
			SetUnchanged();
		}
        private void SetDataForDropdown(IDataRecord reader)
        {
            _TransTypeID = reader.GetInt32("TransTypeID");
            _TransTypeName = reader.GetString("TransTypeName");
            SetUnchanged();
        }
		public static CustomList<CmnTransactionType> GetAllReferenceType(Int32 DocListID)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<CmnTransactionType> CmnTransactionTypeCollection = new CustomList<CmnTransactionType>();
			IDataReader reader = null;
            String sql = "spGetRefType "+DocListID;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					CmnTransactionType newCmnTransactionType = new CmnTransactionType();
                    newCmnTransactionType.SetDataForDropdown(reader);
					CmnTransactionTypeCollection.Add(newCmnTransactionType);
				}
				return CmnTransactionTypeCollection;
			}
			catch(Exception ex)
			{
				throw (ex);
			}
			finally
			{
				if (reader != null && !reader.IsClosed)
					reader.Close();
			}
		}
        public static CustomList<CmnTransactionType> GetAllReferenceType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnTransactionType> CmnTransactionTypeCollection = new CustomList<CmnTransactionType>();
            IDataReader reader = null;
            String sql = "select *from CmnTransactionType";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnTransactionType newCmnTransactionType = new CmnTransactionType();
                    newCmnTransactionType.SetData(reader);
                    CmnTransactionTypeCollection.Add(newCmnTransactionType);
                }
                return CmnTransactionTypeCollection;
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
