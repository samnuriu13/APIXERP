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
    public class ItemStructure : BaseItem
    {
        public ItemStructure()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _StructureID;
        [Browsable(true), DisplayName("StructureID")]
        public System.Int32 StructureID
        {
            get
            {
                return _StructureID;
            }
            set
            {
                if (PropertyChanged(_StructureID, value))
                    _StructureID = value;
            }
        }

        private System.Int32 _GroupItemID;
        [Browsable(true), DisplayName("GroupItemID")]
        public System.Int32 GroupItemID
        {
            get
            {
                return _GroupItemID;
            }
            set
            {
                if (PropertyChanged(_GroupItemID, value))
                    _GroupItemID = value;
            }
        }

        private System.Int32 _SegNameID;
        [Browsable(true), DisplayName("SegNameID")]
        public System.Int32 SegNameID
        {
            get
            {
                return _SegNameID;
            }
            set
            {
                if (PropertyChanged(_SegNameID, value))
                    _SegNameID = value;
            }
        }

        private System.Int32 _SegSeq;
        [Browsable(true), DisplayName("SegSeq")]
        public System.Int32 SegSeq
        {
            get
            {
                return _SegSeq;
            }
            set
            {
                if (PropertyChanged(_SegSeq, value))
                    _SegSeq = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _GroupItemID, _SegNameID, _SegSeq };
            else if (IsModified)
                parameterValues = new Object[] {_StructureID, _GroupItemID, _SegNameID, _SegSeq };
            else if (IsDeleted)
                parameterValues = new Object[] { _StructureID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _StructureID = reader.GetInt32("StructureID");
            _GroupItemID = reader.GetInt32("GroupItemID");
            _SegNameID = reader.GetInt32("SegNameID");
            _SegSeq = reader.GetInt32("SegSeq");
            SetUnchanged();
        }
        public static CustomList<ItemStructure> GetAllItemStructure(Int32 itemGroupID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ItemStructure> ItemStructureCollection = new CustomList<ItemStructure>();
            IDataReader reader = null;
            String sql = "select *from ItemStructure Where GroupItemID=" + itemGroupID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ItemStructure newItemStructure = new ItemStructure();
                    newItemStructure.SetData(reader);
                    ItemStructureCollection.Add(newItemStructure);
                }
                return ItemStructureCollection;
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
