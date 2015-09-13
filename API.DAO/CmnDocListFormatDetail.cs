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
	public class CmnDocListFormatDetail : BaseItem
	{
		public CmnDocListFormatDetail()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _RecordID;
		[Browsable(true), DisplayName("RecordID")]
		public System.Int32 RecordID 
		{
			get
			{
				return _RecordID;
			}
			set
			{
			if (PropertyChanged(_RecordID, value))
					_RecordID = value;
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

		private System.String _ParameterName;
		[Browsable(true), DisplayName("ParameterName")]
		public System.String ParameterName 
		{
			get
			{
				return _ParameterName;
			}
			set
			{
			if (PropertyChanged(_ParameterName, value))
					_ParameterName = value;
			}
		}

		private System.Int32 _Length;
		[Browsable(true), DisplayName("Length")]
		public System.Int32 Length 
		{
			get
			{
				return _Length;
			}
			set
			{
			if (PropertyChanged(_Length, value))
					_Length = value;
			}
		}

		private System.String _Seperator;
		[Browsable(true), DisplayName("Seperator")]
		public System.String Seperator 
		{
			get
			{
				return _Seperator;
			}
			set
			{
			if (PropertyChanged(_Seperator, value))
					_Seperator = value;
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
				parameterValues = new Object[] {_CustomCode,_DocListFormatID,_ParameterName,_Length,_Seperator,_Sequence,_CompanyID,_IsDeleted,_Transfer};
			else if (IsModified)
				parameterValues = new Object[] {_RecordID,_CustomCode,_DocListFormatID,_ParameterName,_Length,_Seperator,_Sequence,_CompanyID,_IsDeleted,_Transfer};
			else if (IsDeleted)
				parameterValues = new Object[] {_RecordID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_RecordID = reader.GetInt32("RecordID");
			_CustomCode = reader.GetString("CustomCode");
			_DocListFormatID = reader.GetInt32("DocListFormatID");
			_ParameterName = reader.GetString("ParameterName");
			_Length = reader.GetInt32("Length");
			_Seperator = reader.GetString("Seperator");
			_Sequence = reader.GetInt32("Sequence");
			_CompanyID = reader.GetInt32("CompanyID");
			_IsDeleted = reader.GetBoolean("IsDeleted");
			_Transfer = reader.GetBoolean("Transfer");
			SetUnchanged();
		}

        public static CustomList<CmnDocListFormatDetail> GetAllDocListFormat_Detail(Int32 docListFormatID)   
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<CmnDocListFormatDetail> DocListFormat_DetailCollection = new CustomList<CmnDocListFormatDetail>();
            IDataReader reader = null;
            String sql = "Select * from CmnDocListFormatDetail";// where BankKey=" + bankKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    CmnDocListFormatDetail newCmnDocListFormat_Detail = new CmnDocListFormatDetail();
                    newCmnDocListFormat_Detail.SetData(reader);
                    DocListFormat_DetailCollection.Add(newCmnDocListFormat_Detail);
                }
                return DocListFormat_DetailCollection;
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
		public static CustomList<CmnDocListFormatDetail> GetAllCmnDocListFormatDetail()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<CmnDocListFormatDetail> CmnDocListFormatDetailCollection = new CustomList<CmnDocListFormatDetail>();
			IDataReader reader = null;
			const String sql = "select *from CmnDocListFormatDetail";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					CmnDocListFormatDetail newCmnDocListFormatDetail = new CmnDocListFormatDetail();
					newCmnDocListFormatDetail.SetData(reader);
					CmnDocListFormatDetailCollection.Add(newCmnDocListFormatDetail);
				}
				return CmnDocListFormatDetailCollection;
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
