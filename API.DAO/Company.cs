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
	public class Company : BaseItem
	{
		public Company()
		{
			SetAdded();
		}
		
#region Properties

		private System.String _Company_Name;
		[Browsable(true), DisplayName("Company_Name")]
		public System.String Company_Name 
		{
			get
			{
				return _Company_Name;
			}
			set
			{
			if (PropertyChanged(_Company_Name, value))
					_Company_Name = value;
			}
		}

		private System.String _Company_Address;
		[Browsable(true), DisplayName("Company_Address")]
		public System.String Company_Address 
		{
			get
			{
				return _Company_Address;
			}
			set
			{
			if (PropertyChanged(_Company_Address, value))
					_Company_Address = value;
			}
		}

		private System.String _CompanyID;
		[Browsable(true), DisplayName("CompanyID")]
		public System.String CompanyID 
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
				parameterValues = new Object[] {_Company_Name,_Company_Address,_CompanyID};
			else if (IsModified)
				parameterValues = new Object[] {_Company_Name,_Company_Address,_CompanyID};
			else if (IsDeleted)
				parameterValues = new Object[] {_Company_Name};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_Company_Name = reader.GetString("Company_Name");
			_Company_Address = reader.GetString("Company_Address");
			_CompanyID = reader.GetString("CompanyID");
			SetUnchanged();
		}
		public static CustomList<Company> GetAllCompany()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Company> CompanyCollection = new CustomList<Company>();
			IDataReader reader = null;
			const String sql = "Select *from Company";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Company newCompany = new Company();
					newCompany.SetData(reader);
					CompanyCollection.Add(newCompany);
				}
				CompanyCollection.InsertSpName = "spInsertCompany";
				CompanyCollection.UpdateSpName = "spUpdateCompany";
				CompanyCollection.DeleteSpName = "spDeleteCompany";
				return CompanyCollection;
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
