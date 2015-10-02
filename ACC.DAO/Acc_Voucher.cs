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
	public class Acc_Voucher : BaseItem
	{
		public Acc_Voucher()
		{
			SetAdded();
		}
		
#region Properties

        private System.Int64 _VoucherKey;
        [Browsable(true), DisplayName("VoucherKey")]
        public System.Int64 VoucherKey
        {
            get
            {
                return _VoucherKey;
            }
            set
            {
                if (PropertyChanged(_VoucherKey, value))
                    _VoucherKey = value;
            }
        }

        private System.Int32 _VoucherTypeKey;
        [Browsable(true), DisplayName("VoucherTypeKey")]
        public System.Int32 VoucherTypeKey
        {
            get
            {
                return _VoucherTypeKey;
            }
            set
            {
                if (PropertyChanged(_VoucherTypeKey, value))
                    _VoucherTypeKey = value;
            }
        }

        private System.DateTime _VoucherDate;
        [Browsable(true), DisplayName("VoucherDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime VoucherDate
        {
            get
            {
                return _VoucherDate;
            }
            set
            {
                if (PropertyChanged(_VoucherDate, value))
                    _VoucherDate = value;
            }
        }

        private System.String _VoucherNo;
        [Browsable(true), DisplayName("VoucherNo")]
        public System.String VoucherNo
        {
            get
            {
                return _VoucherNo;
            }
            set
            {
                if (PropertyChanged(_VoucherNo, value))
                    _VoucherNo = value;
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

        private System.String _VoucherDesc;
        [Browsable(true), DisplayName("VoucherDesc")]
        public System.String VoucherDesc
        {
            get
            {
                return _VoucherDesc;
            }
            set
            {
                if (PropertyChanged(_VoucherDesc, value))
                    _VoucherDesc = value;
            }
        }

        private System.String _VoucherRef;
        [Browsable(true), DisplayName("VoucherRef")]
        public System.String VoucherRef
        {
            get
            {
                return _VoucherRef;
            }
            set
            {
                if (PropertyChanged(_VoucherRef, value))
                    _VoucherRef = value;
            }
        }

        private System.String _CheckNo;
        [Browsable(true), DisplayName("CheckNo")]
        public System.String CheckNo
        {
            get
            {
                return _CheckNo;
            }
            set
            {
                if (PropertyChanged(_CheckNo, value))
                    _CheckNo = value;
            }
        }

        private System.DateTime _CheckDate;
        [Browsable(true), DisplayName("CheckDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime CheckDate
        {
            get
            {
                return _CheckDate;
            }
            set
            {
                if (PropertyChanged(_CheckDate, value))
                    _CheckDate = value;
            }
        }

        private System.Int32 _ChequeType;
        [Browsable(true), DisplayName("ChequeType")]
        public System.Int32 ChequeType
        {
            get
            {
                return _ChequeType;
            }
            set
            {
                if (PropertyChanged(_ChequeType, value))
                    _ChequeType = value;
            }
        }

        private System.Int32 _ChequeStatus;
        [Browsable(true), DisplayName("ChequeStatus")]
        public System.Int32 ChequeStatus
        {
            get
            {
                return _ChequeStatus;
            }
            set
            {
                if (PropertyChanged(_ChequeStatus, value))
                    _ChequeStatus = value;
            }
        }

        private System.Decimal _VoucherAmount;
        [Browsable(true), DisplayName("VoucherAmount")]
        public System.Decimal VoucherAmount
        {
            get
            {
                return _VoucherAmount;
            }
            set
            {
                if (PropertyChanged(_VoucherAmount, value))
                    _VoucherAmount = value;
            }
        }

        private System.Int32 _CurrencyID;
        [Browsable(true), DisplayName("CurrencyID")]
        public System.Int32 CurrencyID
        {
            get
            {
                return _CurrencyID;
            }
            set
            {
                if (PropertyChanged(_CurrencyID, value))
                    _CurrencyID = value;
            }
        }

        private System.String _ChequeTypeName;
        [Browsable(true), DisplayName("ChequeTypeName")]
        public System.String ChequeTypeName
        {
            get
            {
                return _ChequeTypeName;
            }
            set
            {
                if (PropertyChanged(_ChequeTypeName, value))
                    _ChequeTypeName = value;
            }
        }

        private System.String _Party;
        [Browsable(true), DisplayName("Party")]
        public System.String Party
        {
            get
            {
                return _Party;
            }
            set
            {
                if (PropertyChanged(_Party, value))
                    _Party = value;
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

        private System.Boolean _IsDelete;
        [Browsable(true), DisplayName("IsDelete")]
        public System.Boolean IsDelete
        {
            get
            {
                return _IsDelete;
            }
            set
            {
                if (PropertyChanged(_IsDelete, value))
                    _IsDelete = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CustomCode, _VoucherTypeKey, _VoucherDate.Value(StaticInfo.DateFormat), _VoucherNo, _VoucherDesc, _VoucherRef, _CurrencyID, _CheckNo, _CheckDate.Value(StaticInfo.DateFormat), _ChequeType, _ChequeStatus, _VoucherAmount,_CompanyID,_IsDelete };
            else if (IsModified)
                parameterValues = new Object[] { _VoucherKey, _CustomCode, _VoucherTypeKey, _VoucherDate.Value(StaticInfo.DateFormat), _VoucherNo, _VoucherDesc, _VoucherRef, _CurrencyID, _CheckNo, _CheckDate.Value(StaticInfo.DateFormat), _ChequeType, _ChequeStatus, _VoucherAmount,_CompanyID,_IsDelete };
            else if (IsDeleted)
                parameterValues = new Object[] { _VoucherKey };
            return parameterValues;

		}
		protected override void SetData(IDataRecord reader)
		{
            _VoucherKey = reader.GetInt64("VoucherKey");
            _VoucherTypeKey = reader.GetInt32("VoucherTypeKey");
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _VoucherNo = reader.GetString("VoucherNo");
            _VoucherDesc = reader.GetString("VoucherDesc");
            _VoucherRef = reader.GetString("VoucherRef");
            _CheckNo = reader.GetString("CheckNo");
            _CheckDate = reader.GetDateTime("CheckDate");
            _ChequeType = reader.GetInt32("ChequeType");
            _ChequeStatus = reader.GetInt32("ChequeStatus");
            //_VoucherAmount = reader.GetDecimal("VoucherAmount");
            _CurrencyID = reader.GetInt32("CurrencyID");
            SetUnchanged();

		}
        private void SetDataBankReconciliation(IDataRecord reader)
        {
            _VoucherKey = reader.GetInt64("VoucherKey");
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _VoucherNo = reader.GetString("VoucherNo");
            _VoucherDesc = reader.GetString("VoucherDesc");
            _CheckNo = reader.GetString("CheckNo");
            _CheckDate = reader.GetDateTime("CheckDate");
            _ChequeStatus = reader.GetInt32("ChequeStatus");
            _ChequeTypeName = reader.GetString("ChequeTypeName");
            _Party = reader.GetString("Party");
            SetUnchanged();

        }
		public static CustomList<Acc_Voucher> GetAllAcc_Voucher(Int32 VoucherTypeKey)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Acc_Voucher> Acc_VoucherCollection = new CustomList<Acc_Voucher>();
			IDataReader reader = null;
            String sql = "spFindVoucher "+VoucherTypeKey;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Acc_Voucher newAcc_Voucher = new Acc_Voucher();
					newAcc_Voucher.SetData(reader);
					Acc_VoucherCollection.Add(newAcc_Voucher);
				}
				return Acc_VoucherCollection;
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
        public static CustomList<Acc_Voucher> GetAllAcc_Voucher(Int32 CostCenterID, Int32 BranchOrUnit, Int32 bankBranch, String fromDate, String toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_Voucher> Acc_VoucherCollection = new CustomList<Acc_Voucher>();
            IDataReader reader = null;
            String sql = "spBankReconciliation " + CostCenterID + "," + BranchOrUnit + "," + bankBranch + "," + "'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetDataBankReconciliation(reader);
                    Acc_VoucherCollection.Add(newAcc_Voucher);
                }
                return Acc_VoucherCollection;
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
        public static Acc_Voucher GetAllAcc_Voucher(string voucherNo)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Acc_Voucher voucher = new Acc_Voucher();
            IDataReader reader = null;
            String sql = "select VoucherKey,VoucherTypeKey,FYKey,OrgKey,VoucherDate,VoucherNo,VoucherClient,PayRec,VoucherDesc,IsPost,PostDate,PostBy,EntryDate,EntryUserKey,LastUpdateDate,LastUpdateUserKey,NField_1,NField_2,TField_1,TField_2,TField_3,TField_4,TField_5,DField_1,DField_2,IField_1,BField_1,CheckNo,CheckDate from Acc_Voucher where VoucherNo='" + voucherNo + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetData(reader);
                    voucher = newAcc_Voucher;
                }
                return voucher;
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
        public static Acc_Voucher GetAllAcc_WorkFlowVoucher(string voucherKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Acc_Voucher voucher = new Acc_Voucher();
            IDataReader reader = null;
            String sql = "select * from Acc_Voucher where VoucherKey='" + voucherKey + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_Voucher newAcc_Voucher = new Acc_Voucher();
                    newAcc_Voucher.SetData(reader);
                    voucher = newAcc_Voucher;
                }
                return voucher;
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