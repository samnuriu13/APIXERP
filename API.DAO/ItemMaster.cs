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
    public class ItemMaster : BaseItem
    {
        public ItemMaster()
        {
            SetAdded();
        }

        #region Properties
        private System.String _GroupName;
        [Browsable(true), DisplayName("GroupName")]
        public System.String GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                if (PropertyChanged(_GroupName, value))
                    _GroupName = value;
            }
        }

        private System.String _SubGroupName;
        [Browsable(true), DisplayName("SubGroupName")]
        public System.String SubGroupName
        {
            get
            {
                return _SubGroupName;
            }
            set
            {
                if (PropertyChanged(_SubGroupName, value))
                    _SubGroupName = value;
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

        private System.Int32 _ItemGroupID;
        [Browsable(true), DisplayName("ItemGroupID")]
        public System.Int32 ItemGroupID
        {
            get
            {
                return _ItemGroupID;
            }
            set
            {
                if (PropertyChanged(_ItemGroupID, value))
                    _ItemGroupID = value;
            }
        }

        private System.Int32 _ItemSubGroupID;
        [Browsable(true), DisplayName("ItemSubGroupID")]
        public System.Int32 ItemSubGroupID
        {
            get
            {
                return _ItemSubGroupID;
            }
            set
            {
                if (PropertyChanged(_ItemSubGroupID, value))
                    _ItemSubGroupID = value;
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

        private System.Int32 _ValueIDSeg1;
        [Browsable(true), DisplayName("ValueIDSeg1")]
        public System.Int32 ValueIDSeg1
        {
            get
            {
                return _ValueIDSeg1;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg1, value))
                    _ValueIDSeg1 = value;
            }
        }

        private System.Int32 _ValueIDSeg2;
        [Browsable(true), DisplayName("ValueIDSeg2")]
        public System.Int32 ValueIDSeg2
        {
            get
            {
                return _ValueIDSeg2;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg2, value))
                    _ValueIDSeg2 = value;
            }
        }

        private System.Int32 _ValueIDSeg3;
        [Browsable(true), DisplayName("ValueIDSeg3")]
        public System.Int32 ValueIDSeg3
        {
            get
            {
                return _ValueIDSeg3;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg3, value))
                    _ValueIDSeg3 = value;
            }
        }

        private System.Int32 _ValueIDSeg4;
        [Browsable(true), DisplayName("ValueIDSeg4")]
        public System.Int32 ValueIDSeg4
        {
            get
            {
                return _ValueIDSeg4;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg4, value))
                    _ValueIDSeg4 = value;
            }
        }

        private System.Int32 _ValueIDSeg5;
        [Browsable(true), DisplayName("ValueIDSeg5")]
        public System.Int32 ValueIDSeg5
        {
            get
            {
                return _ValueIDSeg5;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg5, value))
                    _ValueIDSeg5 = value;
            }
        }

        private System.Int32 _ValueIDSeg6;
        [Browsable(true), DisplayName("ValueIDSeg6")]
        public System.Int32 ValueIDSeg6
        {
            get
            {
                return _ValueIDSeg6;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg6, value))
                    _ValueIDSeg6 = value;
            }
        }

        private System.Int32 _ValueIDSeg7;
        [Browsable(true), DisplayName("ValueIDSeg7")]
        public System.Int32 ValueIDSeg7
        {
            get
            {
                return _ValueIDSeg7;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg7, value))
                    _ValueIDSeg7 = value;
            }
        }

        private System.Int32 _ValueIDSeg8;
        [Browsable(true), DisplayName("ValueIDSeg8")]
        public System.Int32 ValueIDSeg8
        {
            get
            {
                return _ValueIDSeg8;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg8, value))
                    _ValueIDSeg8 = value;
            }
        }

        private System.Int32 _ValueIDSeg9;
        [Browsable(true), DisplayName("ValueIDSeg9")]
        public System.Int32 ValueIDSeg9
        {
            get
            {
                return _ValueIDSeg9;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg9, value))
                    _ValueIDSeg9 = value;
            }
        }

        private System.Int32 _ValueIDSeg10;
        [Browsable(true), DisplayName("ValueIDSeg10")]
        public System.Int32 ValueIDSeg10
        {
            get
            {
                return _ValueIDSeg10;
            }
            set
            {
                if (PropertyChanged(_ValueIDSeg10, value))
                    _ValueIDSeg10 = value;
            }
        }

        private System.Int32 _UOMID;
        [Browsable(true), DisplayName("UOMID")]
        public System.Int32 UOMID
        {
            get
            {
                return _UOMID;
            }
            set
            {
                if (PropertyChanged(_UOMID, value))
                    _UOMID = value;
            }
        }

        private System.Decimal _LastReceivePrice;
        [Browsable(true), DisplayName("LastReceivePrice")]
        public System.Decimal LastReceivePrice
        {
            get
            {
                return _LastReceivePrice;
            }
            set
            {
                if (PropertyChanged(_LastReceivePrice, value))
                    _LastReceivePrice = value;
            }
        }

        private System.DateTime _LastReceiveDate;
        [Browsable(true), DisplayName("LastReceiveDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LastReceiveDate
        {
            get
            {
                return _LastReceiveDate;
            }
            set
            {
                if (PropertyChanged(_LastReceiveDate, value))
                    _LastReceiveDate = value;
            }
        }

        private System.DateTime _LastIssueDate;
        [Browsable(true), DisplayName("LastIssueDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime LastIssueDate
        {
            get
            {
                return _LastIssueDate;
            }
            set
            {
                if (PropertyChanged(_LastIssueDate, value))
                    _LastIssueDate = value;
            }
        }

        private System.Decimal _LastIssueRate;
        [Browsable(true), DisplayName("LastIssueRate")]
        public System.Decimal LastIssueRate
        {
            get
            {
                return _LastIssueRate;
            }
            set
            {
                if (PropertyChanged(_LastIssueRate, value))
                    _LastIssueRate = value;
            }
        }

        private System.Decimal _MinQtyLevel;
        [Browsable(true), DisplayName("MinQtyLevel")]
        public System.Decimal MinQtyLevel
        {
            get
            {
                return _MinQtyLevel;
            }
            set
            {
                if (PropertyChanged(_MinQtyLevel, value))
                    _MinQtyLevel = value;
            }
        }

        private System.Decimal _MaxQtyLevel;
        [Browsable(true), DisplayName("MaxQtyLevel")]
        public System.Decimal MaxQtyLevel
        {
            get
            {
                return _MaxQtyLevel;
            }
            set
            {
                if (PropertyChanged(_MaxQtyLevel, value))
                    _MaxQtyLevel = value;
            }
        }

        private System.Decimal _MinQtyReached;
        [Browsable(true), DisplayName("MinQtyReached")]
        public System.Decimal MinQtyReached
        {
            get
            {
                return _MinQtyReached;
            }
            set
            {
                if (PropertyChanged(_MinQtyReached, value))
                    _MinQtyReached = value;
            }
        }

        private System.DateTime _MinQtyReachedDate;
        [Browsable(true), DisplayName("MinQtyReachedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime MinQtyReachedDate
        {
            get
            {
                return _MinQtyReachedDate;
            }
            set
            {
                if (PropertyChanged(_MinQtyReachedDate, value))
                    _MinQtyReachedDate = value;
            }
        }

        private System.Decimal _MaxQtyReached;
        [Browsable(true), DisplayName("MaxQtyReached")]
        public System.Decimal MaxQtyReached
        {
            get
            {
                return _MaxQtyReached;
            }
            set
            {
                if (PropertyChanged(_MaxQtyReached, value))
                    _MaxQtyReached = value;
            }
        }

        private System.DateTime _MaxQtyReachedDate;
        [Browsable(true), DisplayName("MaxQtyReachedDate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime MaxQtyReachedDate
        {
            get
            {
                return _MaxQtyReachedDate;
            }
            set
            {
                if (PropertyChanged(_MaxQtyReachedDate, value))
                    _MaxQtyReachedDate = value;
            }
        }

        private System.Decimal _ReOrderLevel;
        [Browsable(true), DisplayName("ReOrderLevel")]
        public System.Decimal ReOrderLevel
        {
            get
            {
                return _ReOrderLevel;
            }
            set
            {
                if (PropertyChanged(_ReOrderLevel, value))
                    _ReOrderLevel = value;
            }
        }

        private System.Decimal _OpeningStock;
        [Browsable(true), DisplayName("OpeningStock")]
        public System.Decimal OpeningStock
        {
            get
            {
                return _OpeningStock;
            }
            set
            {
                if (PropertyChanged(_OpeningStock, value))
                    _OpeningStock = value;
            }
        }

        private System.Decimal _CurrentRate;
        [Browsable(true), DisplayName("CurrentRate")]
        public System.Decimal CurrentRate
        {
            get
            {
                return _CurrentRate;
            }
            set
            {
                if (PropertyChanged(_CurrentRate, value))
                    _CurrentRate = value;
            }
        }

        private System.Decimal _CurrentStockValue;
        [Browsable(true), DisplayName("CurrentStockValue")]
        public System.Decimal CurrentStockValue
        {
            get
            {
                return _CurrentStockValue;
            }
            set
            {
                if (PropertyChanged(_CurrentStockValue, value))
                    _CurrentStockValue = value;
            }
        }

        private System.String _RackNo;
        [Browsable(true), DisplayName("RackNo")]
        public System.String RackNo
        {
            get
            {
                return _RackNo;
            }
            set
            {
                if (PropertyChanged(_RackNo, value))
                    _RackNo = value;
            }
        }

        private System.String _SelfNo;
        [Browsable(true), DisplayName("SelfNo")]
        public System.String SelfNo
        {
            get
            {
                return _SelfNo;
            }
            set
            {
                if (PropertyChanged(_SelfNo, value))
                    _SelfNo = value;
            }
        }

        private System.String _BoxNo;
        [Browsable(true), DisplayName("BoxNo")]
        public System.String BoxNo
        {
            get
            {
                return _BoxNo;
            }
            set
            {
                if (PropertyChanged(_BoxNo, value))
                    _BoxNo = value;
            }
        }

        private System.String _HSCODE;
        [Browsable(true), DisplayName("HSCODE")]
        public System.String HSCODE
        {
            get
            {
                return _HSCODE;
            }
            set
            {
                if (PropertyChanged(_HSCODE, value))
                    _HSCODE = value;
            }
        }

        private System.String _SegValue1;
        [Browsable(true), DisplayName("SegValue1")]
        public System.String SegValue1
        {
            get
            {
                return _SegValue1;
            }
            set
            {
                if (PropertyChanged(_SegValue1, value))
                    _SegValue1 = value;
            }
        }

        private System.String _SegValue2;
        [Browsable(true), DisplayName("SegValue2")]
        public System.String SegValue2
        {
            get
            {
                return _SegValue2;
            }
            set
            {
                if (PropertyChanged(_SegValue2, value))
                    _SegValue2 = value;
            }
        }

        private System.String _SegValue3;
        [Browsable(true), DisplayName("SegValue3")]
        public System.String SegValue3
        {
            get
            {
                return _SegValue3;
            }
            set
            {
                if (PropertyChanged(_SegValue3, value))
                    _SegValue3 = value;
            }
        }

        private System.String _SegValue4;
        [Browsable(true), DisplayName("SegValue4")]
        public System.String SegValue4
        {
            get
            {
                return _SegValue4;
            }
            set
            {
                if (PropertyChanged(_SegValue4, value))
                    _SegValue4 = value;
            }
        }

        private System.String _SegValue5;
        [Browsable(true), DisplayName("SegValue5")]
        public System.String SegValue5
        {
            get
            {
                return _SegValue5;
            }
            set
            {
                if (PropertyChanged(_SegValue5, value))
                    _SegValue5 = value;
            }
        }

        private System.String _SegValue6;
        [Browsable(true), DisplayName("SegValue6")]
        public System.String SegValue6
        {
            get
            {
                return _SegValue6;
            }
            set
            {
                if (PropertyChanged(_SegValue6, value))
                    _SegValue6 = value;
            }
        }

        private System.String _SegValue7;
        [Browsable(true), DisplayName("SegValue7")]
        public System.String SegValue7
        {
            get
            {
                return _SegValue7;
            }
            set
            {
                if (PropertyChanged(_SegValue7, value))
                    _SegValue7 = value;
            }
        }

        private System.String _SegValue8;
        [Browsable(true), DisplayName("SegValue8")]
        public System.String SegValue8
        {
            get
            {
                return _SegValue8;
            }
            set
            {
                if (PropertyChanged(_SegValue8, value))
                    _SegValue8 = value;
            }
        }

        private System.String _SegValue9;
        [Browsable(true), DisplayName("SegValue9")]
        public System.String SegValue9
        {
            get
            {
                return _SegValue9;
            }
            set
            {
                if (PropertyChanged(_SegValue9, value))
                    _SegValue9 = value;
            }
        }

        private System.String _SegValue10;
        [Browsable(true), DisplayName("SegValue10")]
        public System.String SegValue10
        {
            get
            {
                return _SegValue10;
            }
            set
            {
                if (PropertyChanged(_SegValue10, value))
                    _SegValue10 = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ItemCode, _ItemGroupID, _ItemSubGroupID, _ItemDescription, _ValueIDSeg1, _ValueIDSeg2, _ValueIDSeg3, _ValueIDSeg4, _ValueIDSeg5, _ValueIDSeg6, _ValueIDSeg7, _ValueIDSeg8, _ValueIDSeg9, _ValueIDSeg10, _UOMID, _LastReceivePrice, _LastReceiveDate.Value(StaticInfo.DateFormat), _LastIssueDate.Value(StaticInfo.DateFormat), _LastIssueRate, _MinQtyLevel, _MaxQtyLevel, _MinQtyReached, _MinQtyReachedDate.Value(StaticInfo.DateFormat), _MaxQtyReached, _MaxQtyReachedDate.Value(StaticInfo.DateFormat), _ReOrderLevel, _OpeningStock, _CurrentRate, _CurrentStockValue, _RackNo, _SelfNo, _BoxNo, _HSCODE };
            else if (IsModified)
                parameterValues = new Object[] { _ItemCode, _ItemGroupID, _ItemSubGroupID, _ItemDescription, _ValueIDSeg1, _ValueIDSeg2, _ValueIDSeg3, _ValueIDSeg4, _ValueIDSeg5, _ValueIDSeg6, _ValueIDSeg7, _ValueIDSeg8, _ValueIDSeg9, _ValueIDSeg10, _UOMID, _LastReceivePrice, _LastReceiveDate.Value(StaticInfo.DateFormat), _LastIssueDate.Value(StaticInfo.DateFormat), _LastIssueRate, _MinQtyLevel, _MaxQtyLevel, _MinQtyReached, _MinQtyReachedDate.Value(StaticInfo.DateFormat), _MaxQtyReached, _MaxQtyReachedDate.Value(StaticInfo.DateFormat), _ReOrderLevel, _OpeningStock, _CurrentRate, _CurrentStockValue, _RackNo, _SelfNo, _BoxNo, _HSCODE };
            else if (IsDeleted)
                parameterValues = new Object[] { _ItemCode };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ItemCode = reader.GetString("ItemCode");
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            _ItemSubGroupID = reader.GetInt32("ItemSubGroupID");
            _ItemDescription = reader.GetString("ItemDescription");
            _ValueIDSeg1 = reader.GetInt32("ValueIDSeg1");
            _ValueIDSeg2 = reader.GetInt32("ValueIDSeg2");
            _ValueIDSeg3 = reader.GetInt32("ValueIDSeg3");
            _ValueIDSeg4 = reader.GetInt32("ValueIDSeg4");
            _ValueIDSeg5 = reader.GetInt32("ValueIDSeg5");
            _ValueIDSeg6 = reader.GetInt32("ValueIDSeg6");
            _ValueIDSeg7 = reader.GetInt32("ValueIDSeg7");
            _ValueIDSeg8 = reader.GetInt32("ValueIDSeg8");
            _ValueIDSeg9 = reader.GetInt32("ValueIDSeg9");
            _ValueIDSeg10 = reader.GetInt32("ValueIDSeg10");
            _UOMID = reader.GetInt32("UOMID");
            _LastReceivePrice = reader.GetDecimal("LastReceivePrice");
            _LastReceiveDate = reader.GetDateTime("LastReceiveDate");
            _LastIssueDate = reader.GetDateTime("LastIssueDate");
            _LastIssueRate = reader.GetDecimal("LastIssueRate");
            _MinQtyLevel = reader.GetDecimal("MinQtyLevel");
            _MaxQtyLevel = reader.GetDecimal("MaxQtyLevel");
            _MinQtyReached = reader.GetDecimal("MinQtyReached");
            _MinQtyReachedDate = reader.GetDateTime("MinQtyReachedDate");
            _MaxQtyReached = reader.GetDecimal("MaxQtyReached");
            _MaxQtyReachedDate = reader.GetDateTime("MaxQtyReachedDate");
            _ReOrderLevel = reader.GetDecimal("ReOrderLevel");
            _OpeningStock = reader.GetDecimal("OpeningStock");
            _CurrentRate = reader.GetDecimal("CurrentRate");
            _CurrentStockValue = reader.GetDecimal("CurrentStockValue");
            _RackNo = reader.GetString("RackNo");
            _SelfNo = reader.GetString("SelfNo");
            _BoxNo = reader.GetString("BoxNo");
            _HSCODE = reader.GetString("HSCODE");
            SetUnchanged();
        }
        private void SetDataFindItem(IDataRecord reader)
        {
            _ItemCode = reader.GetString("ItemCode");
            _ItemDescription = reader.GetString("ItemDescription");
            _GroupName = reader.GetString("GroupName");
            _SubGroupName = reader.GetString("SubGroupName");
            _SegValue1 = reader.GetString("SegValue1");
            _SegValue2 = reader.GetString("SegValue2");
            _SegValue3 = reader.GetString("SegValue3");
            _SegValue4 = reader.GetString("SegValue4");
            _SegValue5 = reader.GetString("SegValue5");
            _SegValue6 = reader.GetString("SegValue6");
            _SegValue7 = reader.GetString("SegValue7");
            _SegValue8 = reader.GetString("SegValue8");
            _SegValue9 = reader.GetString("SegValue9");
            _SegValue10 = reader.GetString("SegValue10");
            SetUnchanged();
        }
        private void SetDataItem(IDataRecord reader)
        {
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            _ItemSubGroupID = reader.GetInt32("ItemSubGroupID");
            _ItemCode = reader.GetString("ItemCode");
            _ItemDescription = reader.GetString("ItemDescription");
            SetUnchanged();
        }
        public static CustomList<ItemMaster> FindAllItemMasterBySubGroup(String ItemSubGroup)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemMaster> ItemMasterCollection = new CustomList<ItemMaster>();
            IDataReader reader = null;
            String sql = "select ItemCode,ItemDescription from ItemMaster Where ItemSubGroupID=" + ItemSubGroup;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    newItemMaster.SetDataItem(reader);
                    ItemMasterCollection.Add(newItemMaster);
                }
                return ItemMasterCollection;
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
        public static CustomList<ItemMaster> FindAllItemMasterGroupWise()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemMaster> ItemMasterCollection = new CustomList<ItemMaster>();
            IDataReader reader = null;
            String sql = "select ItemCode,ItemDescription,ItemGroupID,ItemSubGroupID from ItemMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    newItemMaster.SetDataItem(reader);
                    ItemMasterCollection.Add(newItemMaster);
                }
                return ItemMasterCollection;
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
        public static CustomList<ItemMaster> GetAllItemMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemMaster> ItemMasterCollection = new CustomList<ItemMaster>();
            IDataReader reader = null;
            const String sql = "select *from ItemMaster";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    newItemMaster.SetData(reader);
                    ItemMasterCollection.Add(newItemMaster);
                }
                return ItemMasterCollection;
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
        public static CustomList<ItemMaster> FindAllItemMaster()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemMaster> ItemMasterCollection = new CustomList<ItemMaster>();
            IDataReader reader = null;
            const String sql = "spFindItem";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    newItemMaster.SetDataFindItem(reader);
                    ItemMasterCollection.Add(newItemMaster);
                }
                return ItemMasterCollection;
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
        public static CustomList<ItemMaster> GetAllItemMasterByItemCode(String itemCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemMaster> ItemMasterCollection = new CustomList<ItemMaster>();
            IDataReader reader = null;
            String sql = "select *from ItemMaster Where ItemCode='"+itemCode+"'";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemMaster newItemMaster = new ItemMaster();
                    newItemMaster.SetData(reader);
                    ItemMasterCollection.Add(newItemMaster);
                }
                return ItemMasterCollection;
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
