using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;


namespace ACC.DAO
{
	[Serializable]
	public class CmnBankAccountType : BaseItem
	{
		public CmnBankAccountType()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _AccountTypeID;
		[Browsable(true), DisplayName("AccountTypeID")]
		public System.Int32 AccountTypeID 
		{
			get
			{
				return _AccountTypeID;
			}
			set
			{
			if (PropertyChanged(_AccountTypeID, value))
					_AccountTypeID = value;
			}
		}

		private System.String _AccountTypeName;
		[Browsable(true), DisplayName("AccountTypeName")]
		public System.String AccountTypeName 
		{
			get
			{
				return _AccountTypeName;
			}
			set
			{
			if (PropertyChanged(_AccountTypeName, value))
					_AccountTypeName = value;
			}
		}
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_AccountTypeID,_AccountTypeName};
			else if (IsModified)
				parameterValues = new Object[] {_AccountTypeID,_AccountTypeName};
			else if (IsDeleted)
				parameterValues = new Object[] {_AccountTypeID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_AccountTypeID = reader.GetInt32("AccountTypeID");
			_AccountTypeName = reader.GetString("AccountTypeName");
			SetUnchanged();
		}
		public static CustomList<CmnBankAccountType> GetAllCmnBankAccountType()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<CmnBankAccountType> CmnBankAccountTypeCollection = new CustomList<CmnBankAccountType>();
			IDataReader reader = null;
			const String sql = "select * from CmnBankAccountType";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					CmnBankAccountType newCmnBankAccountType = new CmnBankAccountType();
					newCmnBankAccountType.SetData(reader);
					CmnBankAccountTypeCollection.Add(newCmnBankAccountType);
				}
				return CmnBankAccountTypeCollection;
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
