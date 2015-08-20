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
    public class UnitSetup : BaseItem
    {
        public UnitSetup()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _UnitID;
        [Browsable(true), DisplayName("UnitID")]
        public System.Int32 UnitID
        {
            get
            {
                return _UnitID;
            }
            set
            {
                if (PropertyChanged(_UnitID, value))
                    _UnitID = value;
            }
        }

        private System.String _Name;
        [Browsable(true), DisplayName("Name")]
        public System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (PropertyChanged(_Name, value))
                    _Name = value;
            }
        }

        private System.String _Description;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Name, _Description };
            else if (IsModified)
                parameterValues = new Object[] { _Name, _Description };
            else if (IsDeleted)
                parameterValues = new Object[] { _UnitID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _UnitID = reader.GetInt32("UnitID");
            _Name = reader.GetString("Name");
            _Description = reader.GetString("Description");
            SetUnchanged();
        }
        public static CustomList<UnitSetup> GetAllUnitSetup()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<UnitSetup> UnitSetupCollection = new CustomList<UnitSetup>();
            IDataReader reader = null;
            const String sql = "select *from UnitSetup";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    UnitSetup newUnitSetup = new UnitSetup();
                    newUnitSetup.SetData(reader);
                    UnitSetupCollection.Add(newUnitSetup);
                }
                UnitSetupCollection.InsertSpName = "spInsertUnitSetup";
                UnitSetupCollection.UpdateSpName = "spUpdateUnitSetup";
                UnitSetupCollection.DeleteSpName = "spDeleteUnitSetup";
                return UnitSetupCollection;
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
