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
	public class ItemGroupDeptMaping : BaseItem
	{
		public ItemGroupDeptMaping()
		{
			SetAdded();
		}
		
#region Properties

		private System.Int32 _ID;
		[Browsable(true), DisplayName("ID")]
		public System.Int32 ID 
		{
			get
			{
				return _ID;
			}
			set
			{
			if (PropertyChanged(_ID, value))
					_ID = value;
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

		private System.Int32 _DeptID;
		[Browsable(true), DisplayName("DeptID")]
		public System.Int32 DeptID 
		{
			get
			{
				return _DeptID;
			}
			set
			{
			if (PropertyChanged(_DeptID, value))
					_DeptID = value;
			}
		}


        private System.String _Department;
        [Browsable(true), DisplayName("Department")]
        public System.String Department
        {
            get
            {
                return _Department;
            }
            set
            {
                if (PropertyChanged(_Department, value))
                    _Department = value;
            }
        }

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

        private System.Boolean _IsChecked;
        [Browsable(true), DisplayName("IsChecked")]
        public System.Boolean IsChecked
        {
            get
            {
                return _IsChecked;
            }
            set
            {
                if (PropertyChanged(_IsChecked, value))
                    _IsChecked = value;
            }
        }
		#endregion

		public override Object[] GetParameterValues()
		{
			Object[] parameterValues = null;
			if (IsAdded)
				parameterValues = new Object[] {_ItemGroupID,_DeptID};
			else if (IsModified)
				parameterValues = new Object[] {_ID,_ItemGroupID,_DeptID};
			else if (IsDeleted)
				parameterValues = new Object[] {_ID};
			return parameterValues;
		}
		protected override void SetData(IDataRecord reader)
		{
			_ID = reader.GetInt32("ID");
			_ItemGroupID = reader.GetInt32("ItemGroupID");
			_DeptID = reader.GetInt32("DeptID");
			SetUnchanged();
		}
        private void SetDataDept(IDataRecord reader)
        {
            _DeptID = reader.GetInt32("DeptID");
            _Department = reader.GetString("Department");
            SetUnchanged();
        }
		public static CustomList<ItemGroupDeptMaping> GetAllItemGroupDeptMaping(String itemGroupID)
		{
			ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
			CustomList<ItemGroupDeptMaping> ItemGroupDeptMapingCollection = new CustomList<ItemGroupDeptMaping>();
			IDataReader reader = null;
            String sql = "select *from ItemGroupDeptMaping Where ItemGroupID=" + itemGroupID;
			try
			{
				conManager.OpenDataReader(sql, out reader);
				while (reader.Read())
				{
					ItemGroupDeptMaping newItemGroupDeptMaping = new ItemGroupDeptMaping();
					newItemGroupDeptMaping.SetData(reader);
					ItemGroupDeptMapingCollection.Add(newItemGroupDeptMaping);
				}
				return ItemGroupDeptMapingCollection;
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
        public static CustomList<ItemGroupDeptMaping> GetAllDept(Int32 entityID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemGroupDeptMaping> HouseKeepingValueCollection = new CustomList<ItemGroupDeptMaping>();
            IDataReader reader = null;
            String sql = "select HKID DeptID,HKName Department from HouseKeepingValue Where EntityID=" + entityID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemGroupDeptMaping newHouseKeepingValue = new ItemGroupDeptMaping();
                    newHouseKeepingValue.SetDataDept(reader);
                    HouseKeepingValueCollection.Add(newHouseKeepingValue);
                }
                return HouseKeepingValueCollection;
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
