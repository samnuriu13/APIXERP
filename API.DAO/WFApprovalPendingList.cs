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
   public class WFApprovalPendingList : BaseItem
    {
         #region Properties

        private System.Int64 _TransactionID;
        [Browsable(true), DisplayName("TransactionID")]
        public System.Int64 TransactionID
        {
            get
            {
                return _TransactionID;
            }
            set
            {
                if (PropertyChanged(_TransactionID, value))
                    _TransactionID = value;
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

        private System.Boolean _IsApprove;
        [Browsable(true), DisplayName("IsApprove")]
        public System.Boolean IsApprove
        {
            get
            {
                return _IsApprove;
            }
            set
            {
                if (PropertyChanged(_IsApprove, value))
                    _IsApprove = value;
            }
        }

         private System.String _Comment;
        [Browsable(true), DisplayName("Comment")]
        public System.String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                if (PropertyChanged(_Comment, value))
                    _Comment = value;
            }
        }

         private System.String _CurrentUserID;
        [Browsable(true), DisplayName("CurrentUserID")]
        public System.String CurrentUserID
        {
            get
            {
                return _CurrentUserID;
            }
            set
            {
                if (PropertyChanged(_CurrentUserID, value))
                    _CurrentUserID = value;
            }
        }

        private System.String _PreviousUserID;
        [Browsable(true), DisplayName("PreviousUserID")]
        public System.String PreviousUserID
        {
            get
            {
                return _PreviousUserID;
            }
            set
            {
                if (PropertyChanged(_PreviousUserID, value))
                    _PreviousUserID = value;
            }
        }

        private System.DateTime _TransactionDate;
        [Browsable(true), DisplayName("TransactionDate")]
        public System.DateTime TransactionDate
        {
            get
            {
                return _TransactionDate;
            }
            set
            {
                if (PropertyChanged(_TransactionDate, value))
                    _TransactionDate = value;
            }
        }

        private System.Int32 _PreviousStatusID;
        [Browsable(true), DisplayName("PreviousStatusID")]
        public System.Int32 PreviousStatusID
        {
            get
            {
                return _PreviousStatusID;
            }
            set
            {
                if (PropertyChanged(_PreviousStatusID, value))
                    _PreviousStatusID = value;
            }
        }

         private System.Int32 _StatusID;
        [Browsable(true), DisplayName("StatusID")]
        public System.Int32 StatusID
        {
            get
            {
                return _StatusID;
            }
            set
            {
                if (PropertyChanged(_StatusID, value))
                    _StatusID = value;
            }
        }

        private System.String _Status;
        [Browsable(true), DisplayName("Status")]
        public System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                if (PropertyChanged(_Status, value))
                    _Status = value;
            }
        }
        protected override void SetData(IDataRecord reader)
        {
            _TransactionID = reader.GetInt64("TransactionID");
            _CustomCode = reader.GetString("CustomCode");
            _IsApprove = reader.GetBoolean("IsApprove");
            _Comment = reader.GetString("Comment");
            _CurrentUserID = reader.GetString("CurrentUserID");
            _PreviousUserID = reader.GetString("PreviousUserID");
            _TransactionDate = reader.GetDateTime("TransactionDate");
            _PreviousStatusID = reader.GetInt32("PreviousStatusID");
            _StatusID = reader.GetInt32("StatusID");
            _Status = reader.GetString("Status");
            SetUnchanged();
        }
        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] {  };
            else if (IsModified)
                parameterValues = new Object[] {};
            else if (IsDeleted)
                parameterValues = new Object[] {};
            return parameterValues;
        }
        public static CustomList<WFApprovalPendingList> GetAllWFApprovalPendingList(Int32 DocListID,String UserID, Int32 CompanyID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<WFApprovalPendingList> WFApprovalPendingListCollection = new CustomList<WFApprovalPendingList>();
            IDataReader reader = null;
            String sql = "EXEC spGetWFApprovalPendingList "+DocListID+",'"+UserID+"',"+CompanyID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    WFApprovalPendingList newWFApprovalPendingList = new WFApprovalPendingList();
                    newWFApprovalPendingList.SetData(reader);
                    WFApprovalPendingListCollection.Add(newWFApprovalPendingList);
                }
                return WFApprovalPendingListCollection;
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
        #endregion
    }
}
