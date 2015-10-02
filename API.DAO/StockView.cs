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
   public class StockView: BaseItem
    {
       public StockView()
		{
			SetAdded();
		}
		
#region Properties

       private System.String _BranchName;
        [Browsable(true), DisplayName("BranchName")]
       public System.String BranchName 
		{
			get
			{
                return _BranchName;
			}
			set
			{
                if (PropertyChanged(_BranchName, value))
                    _BranchName = value;
			}
		}

        private System.String _CostCenterName;
        [Browsable(true), DisplayName("CostCenterName")]
        public System.String CostCenterName 
		{
			get
			{
                return _CostCenterName;
			}
			set
			{
                if (PropertyChanged(_CostCenterName, value))
                    _CostCenterName = value;
			}
		}

        private System.String _LocationName;
        [Browsable(true), DisplayName("LocationName")]
        public System.String LocationName
        {
            get
            {
                return _LocationName;
            }
            set
            {
                if (PropertyChanged(_LocationName, value))
                    _LocationName = value;
            }
        }

        private System.String _ItemCode;
        [Browsable(true), DisplayName("ItemCode")]
        public System.String ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                if (PropertyChanged(_ItemCode, value))
                    _ItemCode = value;
            }
        }

        private System.String _ItemDescription;
        [Browsable(true), DisplayName("ItemDescription")]
        public System.String ItemDescription
        {
            get
            {
                return _ItemDescription;
            }
            set
            {
                if (PropertyChanged(_ItemDescription, value))
                    _ItemDescription = value;
            }
        }

        private System.Decimal _TotalReceived;
        [Browsable(true), DisplayName("TotalReceived")]
        public System.Decimal TotalReceived
        {
            get
            {
                return _TotalReceived;
            }
            set
            {
                if (PropertyChanged(_TotalReceived, value))
                    _TotalReceived = value;
            }
        }

        private System.Decimal _TotalIssued;
        [Browsable(true), DisplayName("TotalIssued")]
        public System.Decimal TotalIssued
        {
            get
            {
                return _TotalIssued;
            }
            set
            {
                if (PropertyChanged(_TotalIssued, value))
                    _TotalIssued = value;
            }
        }

        private System.Decimal _TotalReturn;
        [Browsable(true), DisplayName("TotalReturn")]
        public System.Decimal TotalReturn
        {
            get
            {
                return _TotalReturn;
            }
            set
            {
                if (PropertyChanged(_TotalReturn, value))
                    _TotalReturn = value;
            }
        }

        private System.Decimal _CurrentStock;
        [Browsable(true), DisplayName("CurrentStock")]
        public System.Decimal CurrentStock
        {
            get
            {
                return _CurrentStock;
            }
            set
            {
                if (PropertyChanged(_CurrentStock, value))
                    _CurrentStock = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
            _BranchName = reader.GetString("BranchName");
            _CostCenterName = reader.GetString("CostCenterName");
            _LocationName = reader.GetString("LocationName");
            _ItemCode = reader.GetString("ItemCode");
            _ItemDescription = reader.GetString("ItemDescription");
            _TotalReceived = reader.GetDecimal("TotalReceived");
            _TotalIssued = reader.GetDecimal("TotalIssued");
            _TotalReturn = reader.GetDecimal("TotalReturn");
            _CurrentStock = reader.GetDecimal("CurrentStock");
			SetUnchanged();
		}
		public static CustomList<StockView> StockView1()
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<StockView> StockViewCollection = new CustomList<StockView>();
			IDataReader reader = null;
            String sql = "EXEC spGetStockView";
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
                    StockView newStockView = new StockView();
                    newStockView.SetData(reader);
                    StockViewCollection.Add(newStockView);
				}
                return StockViewCollection;
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
