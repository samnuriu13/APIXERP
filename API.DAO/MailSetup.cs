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
    public class MailSetup : BaseItem
    {
        public MailSetup()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ReportID;
        [Browsable(true), DisplayName("ReportID")]
        public System.Int32 ReportID
        {
            get
            {
                return _ReportID;
            }
            set
            {
                if (PropertyChanged(_ReportID, value))
                    _ReportID = value;
            }
        }

        private System.Int64 _EmpKey;
        [Browsable(true), DisplayName("EmpKey")]
        public System.Int64 EmpKey
        {
            get
            {
                return _EmpKey;
            }
            set
            {
                if (PropertyChanged(_EmpKey, value))
                    _EmpKey = value;
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

        private System.Boolean _IsIndividual;
        [Browsable(true), DisplayName("IsIndividual")]
        public System.Boolean IsIndividual
        {
            get
            {
                return _IsIndividual;
            }
            set
            {
                if (PropertyChanged(_IsIndividual, value))
                    _IsIndividual = value;
            }
        }

        private System.Boolean _IsDirector;
        [Browsable(true), DisplayName("IsDirector")]
        public System.Boolean IsDirector
        {
            get
            {
                return _IsDirector;
            }
            set
            {
                if (PropertyChanged(_IsDirector, value))
                    _IsDirector = value;
            }
        }

        private System.Boolean _IsOptional;
        [Browsable(true), DisplayName("IsOptional")]
        public System.Boolean IsOptional
        {
            get
            {
                return _IsOptional;
            }
            set
            {
                if (PropertyChanged(_IsOptional, value))
                    _IsOptional = value;
            }
        }

        private System.String _EmailAddress;
        [Browsable(true), DisplayName("EmailAddress")]
        public System.String EmailAddress
        {
            get
            {
                return _EmailAddress;
            }
            set
            {
                if (PropertyChanged(_EmailAddress, value))
                    _EmailAddress = value;
            }
        }

        private System.String _EmpCode;
        [Browsable(true), DisplayName("EmpCode")]
        public System.String EmpCode
        {
            get
            {
                return _EmpCode;
            }
            set
            {
                if (PropertyChanged(_EmpCode, value))
                    _EmpCode = value;
            }
        }

        private System.String _EmpName;
        [Browsable(true), DisplayName("EmpName")]
        public System.String EmpName
        {
            get
            {
                return _EmpName;
            }
            set
            {
                if (PropertyChanged(_EmpName, value))
                    _EmpName = value;
            }
        }

        private System.String _Subject;
        [Browsable(true), DisplayName("Subject")]
        public System.String Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                if (PropertyChanged(_Subject, value))
                    _Subject = value;
            }
        }

        private System.String _FileName;
        [Browsable(true), DisplayName("FileName")]
        public System.String FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                if (PropertyChanged(_FileName, value))
                    _FileName = value;
            }
        }

        private System.String _Body;
        [Browsable(true), DisplayName("Body")]
        public System.String Body
        {
            get
            {
                return _Body;
            }
            set
            {
                if (PropertyChanged(_Body, value))
                    _Body = value;
            }
        }

        private System.Boolean _IsSubjectYM;
        [Browsable(true), DisplayName("IsSubjectYM")]
        public System.Boolean IsSubjectYM
        {
            get
            {
                return _IsSubjectYM;
            }
            set
            {
                if (PropertyChanged(_IsSubjectYM, value))
                    _IsSubjectYM = value;
            }
        }

        private System.Boolean _IsFileNameYM;
        [Browsable(true), DisplayName("IsFileNameYM")]
        public System.Boolean IsFileNameYM
        {
            get
            {
                return _IsFileNameYM;
            }
            set
            {
                if (PropertyChanged(_IsFileNameYM, value))
                    _IsFileNameYM = value;
            }
        }

        private System.String _NickName;
        [Browsable(true), DisplayName("NickName")]
        public System.String NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                if (PropertyChanged(_NickName, value))
                    _NickName = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ReportID, _EmpKey, _EmailAddress,_Subject,_FileName,_Body, _IsIndividual, _IsDirector, _IsOptional,_IsSubjectYM,_IsFileNameYM };
            else if (IsModified)
                parameterValues = new Object[] { _ReportID, _EmpKey, _EmailAddress, _Subject, _FileName, _Body, _IsIndividual, _IsDirector, _IsOptional, _IsSubjectYM, _IsFileNameYM };
            else if (IsDeleted)
                parameterValues = new Object[] { _ReportID, _EmpKey };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ReportID = reader.GetInt32("ReportID");
            _EmpKey = reader.GetInt64("EmpKey");
            _EmpCode = reader.GetString("EmpCode");
            _EmpName = reader.GetString("EmpName");
            _EmailAddress = reader.GetString("EmailAddress");
            _Subject = reader.GetString("Subject");
            _FileName = reader.GetString("FileName");
            _Body = reader.GetString("Body");
            _IsIndividual = reader.GetBoolean("IsIndividual");
            _IsDirector = reader.GetBoolean("IsDirector");
            _IsOptional = reader.GetBoolean("IsOptional");
            _IsChecked = reader.GetBoolean("IsChecked");
            _IsSubjectYM = reader.GetBoolean("IsSubjectYM");
            _IsFileNameYM = reader.GetBoolean("IsFileNameYM");
            SetUnchanged();
        }
        public static CustomList<MailSetup> GetAllMailSetup(Int32 reportID)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MailSetup> MailSetupCollection = new CustomList<MailSetup>();
            IDataReader reader = null;
            String sql = "EXEC spGetMail " + reportID;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MailSetup newMailSetup = new MailSetup();
                    newMailSetup.SetData(reader);
                    MailSetupCollection.Add(newMailSetup);
                }
                return MailSetupCollection;
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
        public static CustomList<MailSetup> GetAllSupervisor()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MailSetup> MailSetupCollection = new CustomList<MailSetup>();
            IDataReader reader = null;
            String sql = "select Distinct Supervisor from EmployeeInfoDetails Where Supervisor is not null";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MailSetup newMailSetup = new MailSetup();
                    newMailSetup.EmpKey = reader.GetInt64("Supervisor");
                    MailSetupCollection.Add(newMailSetup);
                }
                return MailSetupCollection;
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
        public static CustomList<MailSetup> GetAllHOD()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MailSetup> MailSetupCollection = new CustomList<MailSetup>();
            IDataReader reader = null;
            String sql = "select Distinct FunctionalBoss from EmployeeInfoDetails Where FunctionalBoss is not null ";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MailSetup newMailSetup = new MailSetup();
                    newMailSetup.EmpKey = reader.GetInt64("FunctionalBoss");
                    MailSetupCollection.Add(newMailSetup);
                }
                return MailSetupCollection;
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
        public static CustomList<MailSetup> GetSupervisorForLeave(string empKey)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MailSetup> MailSetupCollection = new CustomList<MailSetup>();
            IDataReader reader = null;
            String sql = "spGetSupervisorMailAddress " + empKey;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MailSetup newMailSetup = new MailSetup();
                    newMailSetup.EmailAddress = reader.GetString("EmailAddress");
                    newMailSetup.Subject = reader.GetString("Subject");
                    newMailSetup.FileName = reader.GetString("FileName");
                    newMailSetup.Body = reader.GetString("Body");
                    newMailSetup.NickName = reader.GetString("NickName");
                    MailSetupCollection.Add(newMailSetup);
                }
                return MailSetupCollection;
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
        public static CustomList<MailSetup> GetApprovedEmpForLeave(string empKey, Boolean IsForwarded, Boolean IsRecomended, Boolean IsApproved, Boolean IsRejected)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<MailSetup> MailSetupCollection = new CustomList<MailSetup>();
            IDataReader reader = null;
            String sql = "spGetApprovedEmpMailAddress " + empKey + "," + IsForwarded + "," + IsRecomended + "," + IsApproved + "," + IsRejected;
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MailSetup newMailSetup = new MailSetup();
                    newMailSetup.EmailAddress = reader.GetString("EmailAddress");
                    newMailSetup.Subject = reader.GetString("Subject");
                    newMailSetup.FileName = reader.GetString("FileName");
                    newMailSetup.Body = reader.GetString("Body");
                    newMailSetup.NickName = reader.GetString("NickName");
                    MailSetupCollection.Add(newMailSetup);
                }
                return MailSetupCollection;
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
