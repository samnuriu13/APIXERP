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
	public class AccReportConfigurationHead : BaseItem
	{
		public AccReportConfigurationHead()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _HeadID;
		[Browsable(true), DisplayName("HeadID")]
		public System.Int32 HeadID 
		{
			get
			{
				return _HeadID;
			}
			set
			{
			if (PropertyChanged(_HeadID, value))
					_HeadID = value;
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

		private System.String _HeadName;
		[Browsable(true), DisplayName("HeadName")]
		public System.String HeadName 
		{
			get
			{
				return _HeadName;
			}
			set
			{
			if (PropertyChanged(_HeadName, value))
					_HeadName = value;
			}
		}

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

		private System.String _OperationOperator;
		[Browsable(true), DisplayName("OperationOperator")]
		public System.String OperationOperator 
		{
			get
			{
				return _OperationOperator;
			}
			set
			{
			if (PropertyChanged(_OperationOperator, value))
					_OperationOperator = value;
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
				parameterValues = new Object[] {_HeadName,_HeadCategoryID,_Sequence,_CostCenterID,_OperationOperator,_ReportTypeID,_IsActive,_CompanyID};
			else if (IsModified)
                parameterValues = new Object[] { _HeadID,_HeadName, _HeadCategoryID, _Sequence, _CostCenterID, _OperationOperator, _ReportTypeID, _IsActive, _CompanyID };
			else if (IsDeleted)
				parameterValues = new Object[] {_HeadID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_HeadID = reader.GetInt32("HeadID");
            _HeadCategoryName = reader.GetString("HeadCategoryName");
			_HeadName = reader.GetString("HeadName");
			_HeadCategoryID = reader.GetInt32("HeadCategoryID");
			_Sequence = reader.GetInt32("Sequence");
			_CostCenterID = reader.GetInt32("CostCenterID");
			_OperationOperator = reader.GetString("OperationOperator");
			_ReportTypeID = reader.GetInt32("ReportTypeID");
			_IsActive = reader.GetBoolean("IsActive");
			_CompanyID = reader.GetInt32("CompanyID");
			SetUnchanged();
		}
		public static CustomList<AccReportConfigurationHead> GetAllAccReportConfigurationHead(Int32 ReportTypeID)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AccReportConfigurationHead> AccReportConfigurationHeadCollection = new CustomList<AccReportConfigurationHead>();
			IDataReader reader = null;
            String sql = "Exec spGetHeadCategoryMap "+ReportTypeID;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AccReportConfigurationHead newAccReportConfigurationHead = new AccReportConfigurationHead();
					newAccReportConfigurationHead.SetData(reader);
					AccReportConfigurationHeadCollection.Add(newAccReportConfigurationHead);
				}
				return AccReportConfigurationHeadCollection;
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
