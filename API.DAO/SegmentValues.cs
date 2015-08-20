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
    public class SegmentValues : BaseItem
    {
        public SegmentValues()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _SegValueID;
        [Browsable(true), DisplayName("SegValueID")]
        public System.Int32 SegValueID
        {
            get
            {
                return _SegValueID;
            }
            set
            {
                if (PropertyChanged(_SegValueID, value))
                    _SegValueID = value;
            }
        }

        private System.String _SegValue;
        [Browsable(true), DisplayName("SegValue")]
        public System.String SegValue
        {
            get
            {
                return _SegValue;
            }
            set
            {
                if (PropertyChanged(_SegValue, value))
                    _SegValue = value;
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
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SegValue, _SegNameID };
            else if (IsModified)
                parameterValues = new Object[] { _SegValue, _SegNameID };
            else if (IsDeleted)
                parameterValues = new Object[] { _SegValueID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SegValueID = reader.GetInt32("SegValueID");
            _SegValue = reader.GetString("SegValue");
            _SegNameID = reader.GetInt32("SegNameID");
            SetUnchanged();
        }
        public static CustomList<SegmentValues> GetAllSegmentValues(Int32 segmentNameID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SegmentValues> SegmentValuesCollection = new CustomList<SegmentValues>();
            IDataReader reader = null;
            String sql = "select *from SegmentValues Where SegNameID=" + segmentNameID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SegmentValues newSegmentValues = new SegmentValues();
                    newSegmentValues.SetData(reader);
                    SegmentValuesCollection.Add(newSegmentValues);
                }
                return SegmentValuesCollection;
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
