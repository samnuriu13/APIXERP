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
	public class Acc_VoucherDet : BaseItem
	{
		public Acc_VoucherDet()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int64 _VoucherDetKey;
		[Browsable(true), DisplayName("VoucherDetKey")]
		public System.Int64 VoucherDetKey 
		{
			get
			{
				return _VoucherDetKey;
			}
			set
			{
			if (PropertyChanged(_VoucherDetKey, value))
					_VoucherDetKey = value;
			}
		}

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

		private System.Int64 _COAKey;
		[Browsable(true), DisplayName("COAKey")]
		public System.Int64 COAKey 
		{
			get
			{
				return _COAKey;
			}
			set
			{
			if (PropertyChanged(_COAKey, value))
					_COAKey = value;
			}
		}

        private System.Int64 _PartyKey;
        [Browsable(true), DisplayName("PartyKey")]
        public System.Int64 PartyKey
        {
            get
            {
                return _PartyKey;
            }
            set
            {
                if (PropertyChanged(_PartyKey, value))
                    _PartyKey = value;
            }
        }

		private System.Decimal _Dr;
		[Browsable(true), DisplayName("Dr")]
		public System.Decimal Dr 
		{
			get
			{
				return _Dr;
			}
			set
			{
			if (PropertyChanged(_Dr, value))
					_Dr = value;
			}
		}

		private System.Decimal _Cr;
		[Browsable(true), DisplayName("Cr")]
		public System.Decimal Cr 
		{
			get
			{
				return _Cr;
			}
			set
			{
			if (PropertyChanged(_Cr, value))
					_Cr = value;
			}
		}

        private System.String _COAName;
        [Browsable(true), DisplayName("COAName")]
        public System.String COAName
        {
            get
            {
                return _COAName;
            }
            set
            {
                if (PropertyChanged(_COAName, value))
                    _COAName = value;
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

        private System.Int32 _SL;
        [Browsable(true), DisplayName("SL")]
        public System.Int32 SL
        {
            get
            {
                return _SL;
            }
            set
            {
                if (PropertyChanged(_SL, value))
                    _SL = value;
            }
        }

        private System.Decimal _Bal;
        [Browsable(true), DisplayName("Bal")]
        public System.Decimal Bal
        {
            get
            {
                return _Bal;
            }
            set
            {
                if (PropertyChanged(_Bal, value))
                    _Bal = value;
            }
        }

        private System.String _COACode;
        [Browsable(true), DisplayName("COACode")]
        public System.String COACode
        {
            get
            {
                return _COACode;
            }
            set
            {
                if (PropertyChanged(_COACode, value))
                    _COACode = value;
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

        private System.String _PayRec;
        [Browsable(true), DisplayName("PayRec")]
        public System.String PayRec
        {
            get
            {
                return _PayRec;
            }
            set
            {
                if (PropertyChanged(_PayRec, value))
                    _PayRec = value;
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

        private System.String _Flag;
        [Browsable(true), DisplayName("Flag")]
        public System.String Flag
        {
            get
            {
                return _Flag;
            }
            set
            {
                if (PropertyChanged(_Flag, value))
                    _Flag = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_VoucherKey,_COAKey,_PartyKey,_Dr,_Cr};
			else if (IsModified)
				parameterValues = new Object[] {_VoucherDetKey, _VoucherKey,_COAKey,_PartyKey,_Dr,_Cr};
			else if (IsDeleted)
				parameterValues = new Object[] {_VoucherDetKey};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_VoucherDetKey = reader.GetInt64("VoucherDetKey");
			_VoucherKey = reader.GetInt64("VoucherKey");
			_COAKey = reader.GetInt64("COAKey");
            _PartyKey = reader.GetInt64("PartyKey");
			_Dr = reader.GetDecimal("Dr");
			_Cr = reader.GetDecimal("Cr");
			SetUnchanged();
		}
        private void SetDataTransaction(IDataRecord reader)
        {
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _VoucherNo = reader.GetString("VoucherNo");
            _PayRec = reader.GetString("PayRec");
            _VoucherDesc = reader.GetString("VoucherDesc");
            _Dr = reader.GetDecimal("Dr");
            _Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
        private void SetDataTransaction1(IDataRecord reader)
        {
            _VoucherDate = reader.GetDateTime("VoucherDate");
            _COAName = reader.GetString("COAName");
            _Dr = reader.GetDecimal("Dr");
            _Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
        private void SetDataBS(IDataRecord reader)
        {
            //_SL = reader.GetInt32("SL");
            _COAName = reader.GetString("COAName");
            _COACode = reader.GetString("COACode");
            _Bal = reader.GetDecimal("Bal");
            SetUnchanged();
        }
        private void SetDataTB(IDataRecord reader)
        {

            _COAName = reader.GetString("COAName");
            _Bal = reader.GetDecimal("Bal");
           // _VoucherDate = reader.GetDateTime("VoucherDate");
            //_Dr = reader.GetDecimal("Dr");
            //_Cr = reader.GetDecimal("Cr");
            SetUnchanged();
        }
		public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
			IDataReader reader = null;
			const String sql = "select *from Acc_VoucherDet";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
					newAcc_VoucherDet.SetData(reader);
					Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
				}
				Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
				Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
				Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
				return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "select VoucherDetKey,VoucherKey,COAKey,PartyKey,Convert(Decimal(18,2),Dr)Dr,Convert(Decimal(18,2),Cr)Cr from Acc_VoucherDet Where VoucherKey=" + voucherKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetData(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
                Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
                Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int64 voucherKey, string fromDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spGetVoucherDet " + voucherKey + ",'" + fromDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetData(reader);
                    newAcc_VoucherDet._Bal = reader.GetDecimal("Bal");
                    //newAcc_VoucherDet._Flag = reader.GetString("Flag");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                Acc_VoucherDetCollection.InsertSpName = "spInsertAcc_VoucherDet";
                Acc_VoucherDetCollection.UpdateSpName = "spUpdateAcc_VoucherDet";
                Acc_VoucherDetCollection.DeleteSpName = "spDeleteAcc_VoucherDet";
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> CheckBankAndCashVoucher(string searchStr)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "EXEC spCheckCashAndBank " + searchStr;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet._VoucherNo = reader.GetString("VoucherNo");
                    newAcc_VoucherDet._Cr = reader.GetDecimal("Cr");
                    newAcc_VoucherDet._Bal = reader.GetDecimal("Bal");
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, Int32 isPost,string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_PeriodicTrans " + orgKey + ",'" + fromDate+"','"+toDate+"',"+isPost;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTransaction1(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetTB(Int32 orgKey, string fromDate, string toDate)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_TB " + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTB(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate,Int32 head)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_Ledger " + head + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataTransaction(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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
        public static Decimal GetAllAcc_VoucherDet(Int32 orgKey, string fromDate, string toDate, Int32 head,string spName)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Decimal balance = 0.0M;
            string search = "";
            search = head + "," + orgKey + ",'" + fromDate + "','" + toDate+"'";
            try
            {
                String sql = "EXEC "+spName+" "+ search + "";
                Object oppBal = conManager.ExecuteScalarWrapper(sql);
                balance = Convert.ToDecimal(oppBal);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return balance;
        }
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetPL(Int32 orgKey, string fromDate, string toDate, Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_PL " + fYKey + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataBS(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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
        public static CustomList<Acc_VoucherDet> GetAllAcc_VoucherDetBS(Int32 orgKey, string fromDate, string toDate, Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Acc_VoucherDet> Acc_VoucherDetCollection = new CustomList<Acc_VoucherDet>();
            IDataReader reader = null;
            String sql = "Exec Acc_Rpt_BS " + fYKey + "," + orgKey + ",'" + fromDate + "','" + toDate + "'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Acc_VoucherDet newAcc_VoucherDet = new Acc_VoucherDet();
                    newAcc_VoucherDet.SetDataBS(reader);
                    Acc_VoucherDetCollection.Add(newAcc_VoucherDet);
                }
                return Acc_VoucherDetCollection;
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

        public static void GetAllYearEndProcess(Int32 fYKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            //CustomList<HRM_Emp> HRM_EmpCollection = new CustomList<HRM_Emp>();


            IDataReader reader = null;
            try
            {
                String sql = "EXEC Acc_YearEnd " + fYKey + "";
                conManager.OpenDataReader(sql, out reader);
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
