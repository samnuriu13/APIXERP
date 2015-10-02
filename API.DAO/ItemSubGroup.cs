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
    public class ItemSubGroup : BaseItem
    {
        public ItemSubGroup()
        {
            SetAdded();
        }

        #region Properties

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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SubGroupName, _ItemGroupID };
            else if (IsModified)
                parameterValues = new Object[] {_ItemSubGroupID, _SubGroupName, _ItemGroupID };
            else if (IsDeleted)
                parameterValues = new Object[] { _ItemSubGroupID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ItemSubGroupID = reader.GetInt32("ItemSubGroupID");
            _SubGroupName = reader.GetString("SubGroupName");
            _ItemGroupID = reader.GetInt32("ItemGroupID");
            SetUnchanged();
        }
        public static CustomList<ItemSubGroup> GetAllItemSubGroup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemSubGroup> ItemSubGroupCollection = new CustomList<ItemSubGroup>();
            IDataReader reader = null;
            const String sql = "select S.ItemGroupID, S.ItemSubGroupID, S.SubGroupName from ItemGroup I inner join ItemSubGroup S on S.ItemGroupID=I.ItemGroupID order by I.GroupName desc";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemSubGroup newItemSubGroup = new ItemSubGroup();
                    newItemSubGroup.SetData(reader);
                    ItemSubGroupCollection.Add(newItemSubGroup);
                }
                ItemSubGroupCollection.InsertSpName = "spInsertItemSubGroup";
                ItemSubGroupCollection.UpdateSpName = "spUpdateItemSubGroup";
                ItemSubGroupCollection.DeleteSpName = "spDeleteItemSubGroup";
                return ItemSubGroupCollection;
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
        public static CustomList<ItemSubGroup> GetAllItemSubGroup(String itemGroupID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemSubGroup> ItemSubGroupCollection = new CustomList<ItemSubGroup>();
            IDataReader reader = null;
            String sql = "select *from ItemSubGroup Where ItemGroupID=" + itemGroupID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemSubGroup newItemSubGroup = new ItemSubGroup();
                    newItemSubGroup.SetData(reader);
                    ItemSubGroupCollection.Add(newItemSubGroup);
                }
                return ItemSubGroupCollection;
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