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
	public class AccReportConfigurationHeadCOAMap : BaseItem
	{
		public AccReportConfigurationHeadCOAMap()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _HeadCOAMapID;
		[Browsable(true), DisplayName("HeadCOAMapID")]
		public System.Int32 HeadCOAMapID 
		{
			get
			{
				return _HeadCOAMapID;
			}
			set
			{
			if (PropertyChanged(_HeadCOAMapID, value))
					_HeadCOAMapID = value;
			}
		}

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

		private System.Int32 _COAID;
		[Browsable(true), DisplayName("COAID")]
		public System.Int32 COAID 
		{
			get
			{
				return _COAID;
			}
			set
			{
			if (PropertyChanged(_COAID, value))
					_COAID = value;
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
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_HeadID,_COAID,_IsActive};
			else if (IsModified)
				parameterValues = new Object[] {_HeadID,_COAID,_IsActive};
			else if (IsDeleted)
				parameterValues = new Object[] {_HeadCOAMapID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_HeadCOAMapID = reader.GetInt32("HeadCOAMapID");
			_HeadID = reader.GetInt32("HeadID");
			_COAID = reader.GetInt32("COAID");
			_IsActive = reader.GetBoolean("IsActive");
			SetUnchanged();
		}
		public static CustomList<AccReportConfigurationHeadCOAMap> GetAllAccReportConfigurationHeadCOAMap()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<AccReportConfigurationHeadCOAMap> AccReportConfigurationHeadCOAMapCollection = new CustomList<AccReportConfigurationHeadCOAMap>();
			IDataReader reader = null;
			const String sql = "select *from AccReportConfigurationHeadCOAMap";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					AccReportConfigurationHeadCOAMap newAccReportConfigurationHeadCOAMap = new AccReportConfigurationHeadCOAMap();
					newAccReportConfigurationHeadCOAMap.SetData(reader);
					AccReportConfigurationHeadCOAMapCollection.Add(newAccReportConfigurationHeadCOAMap);
				}
				return AccReportConfigurationHeadCOAMapCollection;
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
