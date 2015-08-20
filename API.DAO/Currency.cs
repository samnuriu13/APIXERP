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
    public class Gen_Currency : BaseItem
    {
        public Gen_Currency()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _CurrencyKey;
        [Browsable(true), DisplayName("CurrencyKey")]
        public System.Int32 CurrencyKey
        {
            get
            {
                return _CurrencyKey;
            }
            set
            {
                if (PropertyChanged(_CurrencyKey, value))
                    _CurrencyKey = value;
            }
        }

        private System.String _CurrencyName;
        [Browsable(true), DisplayName("CurrencyName")]
        public System.String CurrencyName
        {
            get
            {
                return _CurrencyName;
            }
            set
            {
                if (PropertyChanged(_CurrencyName, value))
                    _CurrencyName = value;
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

        private System.Boolean _IsLocalCurrency;
        [Browsable(true), DisplayName("IsLocalCurrency")]
        public System.Boolean IsLocalCurrency
        {
            get
            {
                return _IsLocalCurrency;
            }
            set
            {
                if (PropertyChanged(_IsLocalCurrency, value))
                    _IsLocalCurrency = value;
            }
        }

        private System.Decimal _ConversionFactor;
        [Browsable(true), DisplayName("ConversionFactor")]
        public System.Decimal ConversionFactor
        {
            get
            {
                return _ConversionFactor;
            }
            set
            {
                if (PropertyChanged(_ConversionFactor, value))
                    _ConversionFactor = value;
            }
        }

        private System.DateTime _DateAdded;
        [Browsable(true), DisplayName("DateAdded"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateAdded
        {
            get
            {
                return _DateAdded;
            }
            set
            {
                if (PropertyChanged(_DateAdded, value))
                    _DateAdded = value;
            }
        }

        private System.String _AddedBy;
        [Browsable(true), DisplayName("AddedBy")]
        public System.String AddedBy
        {
            get
            {
                return _AddedBy;
            }
            set
            {
                if (PropertyChanged(_AddedBy, value))
                    _AddedBy = value;
            }
        }

        private System.DateTime _DateUpdate;
        [Browsable(true), DisplayName("DateUpdate"), CustomAttributes.FormatString(StaticInfo.GridDateFormat)]
        public System.DateTime DateUpdate
        {
            get
            {
                return _DateUpdate;
            }
            set
            {
                if (PropertyChanged(_DateUpdate, value))
                    _DateUpdate = value;
            }
        }

        private System.String _UpdateBy;
        [Browsable(true), DisplayName("UpdateBy")]
        public System.String UpdateBy
        {
            get
            {
                return _UpdateBy;
            }
            set
            {
                if (PropertyChanged(_UpdateBy, value))
                    _UpdateBy = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _CurrencyName, _Description, _IsLocalCurrency, _ConversionFactor };
            else if (IsModified)
                parameterValues = new Object[] {_CurrencyKey, _CurrencyName, _Description, _IsLocalCurrency, _ConversionFactor };
            else if (IsDeleted)
                parameterValues = new Object[] { _CurrencyKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CurrencyKey = reader.GetInt32("CurrencyKey");
            _CurrencyName = reader.GetString("CurrencyName");
            _Description = reader.GetString("Description");
            _IsLocalCurrency = reader.GetBoolean("IsLocalCurrency");
            _ConversionFactor = reader.GetDecimal("ConversionFactor");
            SetUnchanged();
        }
        public static CustomList<Gen_Currency> GetAllGen_Currency()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<Gen_Currency> Gen_CurrencyCollection = new CustomList<Gen_Currency>();
            IDataReader reader = null;
            const String sql = "Select *from Gen_Currency";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    Gen_Currency newGen_Currency = new Gen_Currency();
                    newGen_Currency.SetData(reader);
                    Gen_CurrencyCollection.Add(newGen_Currency);
                }
                return Gen_CurrencyCollection;
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