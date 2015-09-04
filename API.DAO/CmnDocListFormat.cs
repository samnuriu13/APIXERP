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
	public class CmnDocListFormat : BaseItem
	{
		public CmnDocListFormat()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _DocListFormatID;
		[Browsable(true), DisplayName("DocListFormatID")]
		public System.Int32 DocListFormatID 
		{
			get
			{
				return _DocListFormatID;
			}
			set
			{
			if (PropertyChanged(_DocListFormatID, value))
					_DocListFormatID = value;
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

		private System.Int32 _DocListId;
		[Browsable(true), DisplayName("DocListId")]
		public System.Int32 DocListId 
		{
			get
			{
				return _DocListId;
			}
			set
			{
			if (PropertyChanged(_DocListId, value))
					_DocListId = value;
			}
		}

		private System.String _Prefix;
		[Browsable(true), DisplayName("Prefix")]
		public System.String Prefix 
		{
			get
			{
				return _Prefix;
			}
			set
			{
			if (PropertyChanged(_Prefix, value))
					_Prefix = value;
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

		private System.String _Suffix;
		[Browsable(true), DisplayName("Suffix")]
		public System.String Suffix 
		{
			get
			{
				return _Suffix;
			}
			set
			{
			if (PropertyChanged(_Suffix, value))
					_Suffix = value;
			}
		}

		private System.String _PeriodType;
		[Browsable(true), DisplayName("PeriodType")]
		public System.String PeriodType 
		{
			get
			{
				return _PeriodType;
			}
			set
			{
			if (PropertyChanged(_PeriodType, value))
					_PeriodType = value;
			}
		}

		private System.Int32 _Project;
		[Browsable(true), DisplayName("Project")]
		public System.Int32 Project 
		{
			get
			{
				return _Project;
			}
			set
			{
			if (PropertyChanged(_Project, value))
					_Project = value;
			}
		}

		private System.Int32 _CostCentre;
		[Browsable(true), DisplayName("CostCentre")]
		public System.Int32 CostCentre 
		{
			get
			{
				return _CostCentre;
			}
			set
			{
			if (PropertyChanged(_CostCentre, value))
					_CostCentre = value;
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
				parameterValues = new Object[] {_DocListFormatID,_CustomCode,_DocListId,_Prefix,_Suffix,_PeriodType,_Project,_CostCentre,_CompanyID,_IsDeleted,_Transfer};
			else if (IsModified)
				parameterValues = new Object[] {_DocListFormatID,_CustomCode,_DocListId,_Prefix,_Suffix,_PeriodType,_Project,_CostCentre,_CompanyID,_IsDeleted,_Transfer};
			else if (IsDeleted)
				parameterValues = new Object[] {_DocListFormatID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_DocListFormatID = reader.GetInt32("DocListFormatID");
			_CustomCode = reader.GetString("CustomCode");
			_DocListId = reader.GetInt32("DocListId");
            _Description = reader.GetString("Description");
			_Prefix = reader.GetString("Prefix");
			_Suffix = reader.GetString("Suffix");
			_PeriodType = reader.GetString("PeriodType");
			_Project = reader.GetInt32("Project");
			_CostCentre = reader.GetInt32("CostCentre");
			_CompanyID = reader.GetInt32("CompanyID");
			_IsDeleted = reader.GetBoolean("IsDeleted");
			_Transfer = reader.GetBoolean("Transfer");
			SetUnchanged();
		}
        public static CustomList<CmnDocListFormat> GetAllDocListFormatFind()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnDocListFormat> CmnDocListFormatCollection = new CustomList<CmnDocListFormat>();
            IDataReader reader = null;
            const String sql = "SELECT a.DocListFormatID,a.CustomCode,a.DocListId,a.Prefix,a.Suffix,a.PeriodType,a.Project,a.CostCentre,a.CompanyID, a.IsDeleted,a.Transfer, b.Description FROM API.dbo.CmnDocListFormat a inner join  APISysMan.dbo.Menu b  ON a.DocListId=b.MenuID";    
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnDocListFormat newCmnDocListFormat = new CmnDocListFormat();
                    newCmnDocListFormat.SetData(reader);
                    CmnDocListFormatCollection.Add(newCmnDocListFormat);
                }
               // CmnDocListFormatCollection.InsertSpName = "spInsertCmnDocListFormat";
               // CmnDocListFormatCollection.UpdateSpName = "spUpdateCmnDocListFormat";
               // CmnDocListFormatCollection.DeleteSpName = "spDeleteCmnDocListFormat";
                return CmnDocListFormatCollection;
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

		public static CustomList<CmnDocListFormat> GetAllCmnDocListFormat()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<CmnDocListFormat> CmnDocListFormatCollection = new CustomList<CmnDocListFormat>();
			IDataReader reader = null;
            const String sql = "Select DocListFormatID,CustomCode,DocListId,Prefix,Suffix,PeriodType,Project,CostCentre,CompanyID, IsDeleted,Transfer,'' Description from CmnDocListFormat";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					CmnDocListFormat newCmnDocListFormat = new CmnDocListFormat();
					newCmnDocListFormat.SetData(reader);
					CmnDocListFormatCollection.Add(newCmnDocListFormat);
				}
				return CmnDocListFormatCollection;
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
