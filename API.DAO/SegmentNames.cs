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
    public class SegmentNames : BaseItem
    {
        public SegmentNames()
        {
            SetAdded();
        }

        #region Properties

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

        private System.String _SegName;
        [Browsable(true), DisplayName("SegName")]
        public System.String SegName
        {
            get
            {
                return _SegName;
            }
            set
            {
                if (PropertyChanged(_SegName, value))
                    _SegName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _SegName };
            else if (IsModified)
                parameterValues = new Object[] { _SegNameID,_SegName };
            else if (IsDeleted)
                parameterValues = new Object[] { _SegNameID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _SegNameID = reader.GetInt32("SegNameID");
            _SegName = reader.GetString("SegName");
            SetUnchanged();
        }
        public static CustomList<SegmentNames> GetAllSegmentNames()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SegmentNames> SegmentNamesCollection = new CustomList<SegmentNames>();
            IDataReader reader = null;
            const String sql = "select *from SegmentNames";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SegmentNames newSegmentNames = new SegmentNames();
                    newSegmentNames.SetData(reader);
                    SegmentNamesCollection.Add(newSegmentNames);
                }
                return SegmentNamesCollection;
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
        public static CustomList<SegmentNames> GetGroupSegmentNames(String itemGroupID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<SegmentNames> SegmentNamesCollection = new CustomList<SegmentNames>();
            IDataReader reader = null;
            String sql = "EXEC spGetGroupWiseSegment " + itemGroupID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    SegmentNames newSegmentNames = new SegmentNames();
                    newSegmentNames.SetData(reader);
                    SegmentNamesCollection.Add(newSegmentNames);
                }
                return SegmentNamesCollection;
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
