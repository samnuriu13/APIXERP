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
    public class ItemGroup : BaseItem
    {
        public ItemGroup()
        {
            SetAdded();
        }

        #region Properties

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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _GroupName, _UOMID };
            else if (IsModified)
                parameterValues = new Object[] { _GroupName, _UOMID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ItemGroupID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            _GroupName = reader.GetString("GroupName");
            _UOMID = reader.GetInt32("UOMID");
            SetUnchanged();
        }
        private void SetDataItemGroup(IDataRecord reader)
        {
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            _GroupName = reader.GetString("GroupName");
            SetUnchanged();
        }
        public static CustomList<ItemGroup> DeptWiseItemGroup(Int32 DeptID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemGroup> ItemGroupDeptMapingCollection = new CustomList<ItemGroup>();
            IDataReader reader = null;
            String sql = "EXEC spDeptWiseItemGroup " + DeptID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemGroup newItemGroupDeptMaping = new ItemGroup();
                    newItemGroupDeptMaping.SetDataItemGroup(reader);
                    ItemGroupDeptMapingCollection.Add(newItemGroupDeptMaping);
                }
                return ItemGroupDeptMapingCollection;
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
        public static CustomList<ItemGroup> GetAllItemGroup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemGroup> ItemGroupCollection = new CustomList<ItemGroup>();
            IDataReader reader = null;
            const String sql = "select *from ItemGroup";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemGroup newItemGroup = new ItemGroup();
                    newItemGroup.SetData(reader);
                    ItemGroupCollection.Add(newItemGroup);
                }
                ItemGroupCollection.InsertSpName = "spInsertItemGroup";
                ItemGroupCollection.UpdateSpName = "spUpdateItemGroup";
                ItemGroupCollection.DeleteSpName = "spDeleteItemGroup";
                return ItemGroupCollection;
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
