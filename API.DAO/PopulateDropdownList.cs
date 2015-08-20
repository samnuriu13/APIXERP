using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;


namespace API.DAO
{
   public class PopulateDropdownList:BaseItem
    {
        private String text;
        public String Text
        {
            get { return text; }
            set { text = value; }
        }
        private Int32 valueField;
        public Int32 ValueField
        {
            get { return valueField; }
            set { valueField = value; }
        }
        private String valueDoc;
        public String ValueDoc
        {
            get { return valueDoc; }
            set { valueDoc = value; }
        }

        private System.Int64 _ID;
        [Browsable(true), DisplayName("ID")]
        public System.Int64 ID
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

        private System.String _CustomCode;
        [Browsable(true), DisplayName("CustomCode")]
        public System.String CustomCode
        {
            get
            {
                return _CustomCode;
            }
            set
            {
                if (PropertyChanged(_CustomCode, value))
                    _CustomCode = value;
            }
        }
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            //if (IsAdded)
            //    parameterValues = new Object[] { _GradeName, _Remarks };
            //else if (IsModified)
            //    parameterValues = new Object[] { _GradeName, _Remarks };
            //else if (IsDeleted)
            //    parameterValues = new Object[] { _GradeKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _CustomCode = reader.GetString("CustomCode");
            _ID = reader.GetInt64("ID");
            SetUnchanged();
        }
        public static CustomList<PopulateDropdownList> GetAllReferenceTransaction(Int32 DocListID,Int32 RefType)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<PopulateDropdownList> CmnTransactionCollection = new CustomList<PopulateDropdownList>();
            IDataReader reader = null;
            String sql = "spGetReferenceMasterTableData " + DocListID+","+RefType;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    PopulateDropdownList newCmnTransaction = new PopulateDropdownList();
                    newCmnTransaction.SetData(reader);
                    CmnTransactionCollection.Add(newCmnTransaction);
                }
                return CmnTransactionCollection;
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
