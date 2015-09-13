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
	public class AccReportConfigurationHeadCategory : BaseItem
	{
		public AccReportConfigurationHeadCategory()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _HeadCategoryID;
		[Browsable(true), DisplayName("HeadCategoryID")]
		public System.Int32 HeadCategoryID 
		{
			get
			{
				return _HeadCategoryID;
			}
			set
			{
			if (PropertyChanged(_HeadCategoryID, value))
					_HeadCategoryID = value;
			}
		}

		private System.String _HeadCategoryName;
		[Browsable(true), DisplayName("HeadCategoryName")]
		public System.String HeadCategoryName 
		{
			get
			{
				return _HeadCategoryName;
			}
			set
			{
			if (PropertyChanged(_HeadCategoryName, value))
					_HeadCategoryName = value;
			}
		}

		private System.Int32 _ParentID;
		[Browsable(true), DisplayName("ParentID")]
		public System.Int32 ParentID 
		{
			get
			{
				return _ParentID;
			}
			set
			{
			if (PropertyChanged(_ParentID, value))
					_ParentID = value;
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

		private System.String _TotalTitle;
		[Browsable(true), DisplayName("TotalTitle")]
		public System.String TotalTitle 
		{
			get
			{
				return _TotalTitle;
			}
			set
			{
			if (PropertyChanged(_TotalTitle, value))
					_TotalTitle = value;
			}
		}

		private System.Int32 _ReportTypeID;
		[Browsable(true), DisplayName("ReportTypeID")]
		public System.Int32 ReportTypeID 
		{
			get
			{
				return _ReportTypeID;
			}
			set
			{
			if (PropertyChanged(_ReportTypeID, value))
					_ReportTypeID = value;
			}
		}

		private System.String _OperatorType;
		[Browsable(true), DisplayName("OperatorType")]
		public System.String OperatorType 
		{
			get
			{
				return _OperatorType;
			}
			set
			{
			if (PropertyChanged(_OperatorType, value))
					_OperatorType = value;
			}
		}

		private System.Boolean _IsActive;
		[Browsable(true), DisplayName("IsActive")]
		public System.Boolean IsActive 
		{
			get
			{
				return _IsActive;
			}
			set
			{
			if (PropertyChanged(_IsActive, value))
					_IsActive = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_HeadCategoryName,_ParentID,_Sequence,_TotalTitle,_ReportTypeID,_OperatorType,_IsActive,_CostCenterID,_CompanyID};
			else if (IsModified)
                parameterValues = new Object[] { _HeadCategoryID,_HeadCategoryName, _ParentID, _Sequence, _TotalTitle, _ReportTypeID, _OperatorType, _IsActive, _CostCenterID, _CompanyID };
			else if (IsDeleted)
				parameterValues = new Object[] {_HeadCategoryID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_HeadCategoryID = reader.GetInt32("HeadCategoryID");
			_HeadCategoryName = reader.GetString("HeadCategoryName");
			_ParentID = reader.GetInt32("ParentID");
			_Sequence = reader.GetInt32("Sequence");
			_TotalTitle = reader.GetString("TotalTitle");
			_ReportTypeID = reader.GetInt32("ReportTypeID");
			_OperatorType = reader.GetString("OperatorType");
			_IsActive = reader.GetBoolean("IsActive");
			_CostCenterID = reader.GetInt32("CostCenterID");
			_CompanyID = reader.GetInt32("CompanyID");
			SetUnchanged();
		}
		public static CustomList<AccReportConfigurationHeadCategory> GetAllAccReportConfigurationHeadCategory()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AccReportConfigurationHeadCategory> AccReportConfigurationHeadCategoryCollection = new CustomList<AccReportConfigurationHeadCategory>();
			IDataReader reader = null;
			const String sql = "select *from AccReportConfigurationHeadCategory";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AccReportConfigurationHeadCategory newAccReportConfigurationHeadCategory = new AccReportConfigurationHeadCategory();
					newAccReportConfigurationHeadCategory.SetData(reader);
					AccReportConfigurationHeadCategoryCollection.Add(newAccReportConfigurationHeadCategory);
				}
				return AccReportConfigurationHeadCategoryCollection;
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
	}
}
