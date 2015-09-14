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
    public class ContactInfo : BaseItem
    {
        public ContactInfo()
        {
            SetAdded();
        }

        #region Properties

        private System.Int32 _ContactID;
        [Browsable(true), DisplayName("ContactID")]
        public System.Int32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                if (PropertyChanged(_ContactID, value))
                    _ContactID = value;
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

        private System.String _ShortName;
        [Browsable(true), DisplayName("ShortName")]
        public System.String ShortName
        {
            get
            {
                return _ShortName;
            }
            set
            {
                if (PropertyChanged(_ShortName, value))
                    _ShortName = value;
            }
        }

        private System.String _ContactImage;
        [Browsable(true), DisplayName("ContactImage")]
        public System.String ContactImage
        {
            get
            {
                return _ContactImage;
            }
            set
            {
                if (PropertyChanged(_ContactImage, value))
                    _ContactImage = value;
            }
        }

        private System.String _AgentName;
        [Browsable(true), DisplayName("AgentName")]
        public System.String AgentName
        {
            get
            {
                return _AgentName;
            }
            set
            {
                if (PropertyChanged(_AgentName, value))
                    _AgentName = value;
            }
        }

        private System.String _OfficeAddress;
        [Browsable(true), DisplayName("OfficeAddress")]
        public System.String OfficeAddress
        {
            get
            {
                return _OfficeAddress;
            }
            set
            {
                if (PropertyChanged(_OfficeAddress, value))
                    _OfficeAddress = value;
            }
        }

        private System.String _FactoryAddress;
        [Browsable(true), DisplayName("FactoryAddress")]
        public System.String FactoryAddress
        {
            get
            {
                return _FactoryAddress;
            }
            set
            {
                if (PropertyChanged(_FactoryAddress, value))
                    _FactoryAddress = value;
            }
        }

        private System.String _PhoneNo;
        [Browsable(true), DisplayName("PhoneNo")]
        public System.String PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                if (PropertyChanged(_PhoneNo, value))
                    _PhoneNo = value;
            }
        }

        private System.String _IndustryType;
        [Browsable(true), DisplayName("IndustryType")]
        public System.String IndustryType
        {
            get
            {
                return _IndustryType;
            }
            set
            {
                if (PropertyChanged(_IndustryType, value))
                    _IndustryType = value;
            }
        }

        private System.String _FaxNo;
        [Browsable(true), DisplayName("FaxNo")]
        public System.String FaxNo
        {
            get
            {
                return _FaxNo;
            }
            set
            {
                if (PropertyChanged(_FaxNo, value))
                    _FaxNo = value;
            }
        }

        private System.String _ContactPerson;
        [Browsable(true), DisplayName("ContactPerson")]
        public System.String ContactPerson
        {
            get
            {
                return _ContactPerson;
            }
            set
            {
                if (PropertyChanged(_ContactPerson, value))
                    _ContactPerson = value;
            }
        }

        private System.String _Origin;
        [Browsable(true), DisplayName("Origin")]
        public System.String Origin
        {
            get
            {
                return _Origin;
            }
            set
            {
                if (PropertyChanged(_Origin, value))
                    _Origin = value;
            }
        }

        private System.String _EmailNo;
        [Browsable(true), DisplayName("EmailNo")]
        public System.String EmailNo
        {
            get
            {
                return _EmailNo;
            }
            set
            {
                if (PropertyChanged(_EmailNo, value))
                    _EmailNo = value;
            }
        }

        private System.String _ParentCompany;
        [Browsable(true), DisplayName("ParentCompany")]
        public System.String ParentCompany
        {
            get
            {
                return _ParentCompany;
            }
            set
            {
                if (PropertyChanged(_ParentCompany, value))
                    _ParentCompany = value;
            }
        }

        private System.String _InterCompanyID;
        [Browsable(true), DisplayName("InterCompanyID")]
        public System.String InterCompanyID
        {
            get
            {
                return _InterCompanyID;
            }
            set
            {
                if (PropertyChanged(_InterCompanyID, value))
                    _InterCompanyID = value;
            }
        }

        private System.String _TINNO;
        [Browsable(true), DisplayName("TINNO")]
        public System.String TINNO
        {
            get
            {
                return _TINNO;
            }
            set
            {
                if (PropertyChanged(_TINNO, value))
                    _TINNO = value;
            }
        }

        private System.String _CSTNO;
        [Browsable(true), DisplayName("CSTNO")]
        public System.String CSTNO
        {
            get
            {
                return _CSTNO;
            }
            set
            {
                if (PropertyChanged(_CSTNO, value))
                    _CSTNO = value;
            }
        }

        private System.String _VATCode;
        [Browsable(true), DisplayName("VATCode")]
        public System.String VATCode
        {
            get
            {
                return _VATCode;
            }
            set
            {
                if (PropertyChanged(_VATCode, value))
                    _VATCode = value;
            }
        }

        private System.Int64? _CostCenterId;
        [Browsable(true), DisplayName("CostCenterId")]
        public System.Int64? CostCenterId
        {
            get
            {
                return _CostCenterId;
            }
            set
            {
                if (PropertyChanged(_CostCenterId, value))
                    _CostCenterId = value;
            }
        }

        private System.Int64? _DepartmentId;
        [Browsable(true), DisplayName("DepartmentId")]
        public System.Int64? DepartmentId
        {
            get
            {
                return _DepartmentId;
            }
            set
            {
                if (PropertyChanged(_DepartmentId, value))
                    _DepartmentId = value;
            }
        }
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Name, _ShortName, _AgentName, _OfficeAddress, _FactoryAddress, _PhoneNo, _IndustryType, _FaxNo, _ContactPerson, _Origin, _EmailNo, _ParentCompany, _InterCompanyID, _TINNO, _CSTNO, _VATCode, _CostCenterId, _DepartmentId,_ContactImage };
            else if (IsModified)
                parameterValues = new Object[] { _ContactID, _Name, _ShortName, _AgentName, _OfficeAddress, _FactoryAddress, _PhoneNo, _IndustryType, _FaxNo, _ContactPerson, _Origin, _EmailNo, _ParentCompany, _InterCompanyID, _TINNO, _CSTNO, _VATCode, _CostCenterId, _DepartmentId,_ContactImage };
            else if (IsDeleted)
                parameterValues = new Object[] { _ContactID };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _ContactID = reader.GetInt32("ContactID");
            _Name = reader.GetString("Name");
            _ShortName = reader.GetString("ShortName");
            _AgentName = reader.GetString("AgentName");
            _OfficeAddress = reader.GetString("OfficeAddress");
            _FactoryAddress = reader.GetString("FactoryAddress");
            _PhoneNo = reader.GetString("PhoneNo");
            _IndustryType = reader.GetString("IndustryType");
            _FaxNo = reader.GetString("FaxNo");
            _ContactPerson = reader.GetString("ContactPerson");
            _Origin = reader.GetString("Origin");
            _EmailNo = reader.GetString("EmailNo");
            _ParentCompany = reader.GetString("ParentCompany");
            _InterCompanyID = reader.GetString("InterCompanyID");
            _TINNO = reader.GetString("TINNO");
            _CSTNO = reader.GetString("CSTNO");
            _VATCode = reader.GetString("VATCode");
            _CostCenterId = reader.GetNulableInt64("CostCenterId");
            _DepartmentId = reader.GetNulableInt64("DepartmentId");
            _ContactImage = reader.GetString("ContactImage");
            SetUnchanged();
        }
        public void SetDataForDropdown(IDataRecord reader)
        {
            _ContactID = reader.GetInt32("ContactID");
            _Name = reader.GetString("Name");
        }
        private void SetDataSupplier(IDataRecord reader)
        {
            _ContactID = reader.GetInt32("ContactID");
            _Name = reader.GetString("Name");
        }
        public static CustomList<ContactInfo> GetAllSupplier()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactInfo> ContactInfoCollection = new CustomList<ContactInfo>();
            IDataReader reader = null;
            const String sql = "select ContactID,Name from Supplier";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactInfo newContactInfo = new ContactInfo();
                    newContactInfo.SetDataSupplier(reader);
                    ContactInfoCollection.Add(newContactInfo);
                };
                return ContactInfoCollection;
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
        public static CustomList<ContactInfo> GetAllEmployee()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactInfo> ContactInfoCollection = new CustomList<ContactInfo>();
            IDataReader reader = null;
            const String sql = "select ContactID,Name from Employee";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactInfo newContactInfo = new ContactInfo();
                    newContactInfo.SetDataSupplier(reader);
                    ContactInfoCollection.Add(newContactInfo);
                };
                return ContactInfoCollection;
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
        public static CustomList<ContactInfo> GetAllContactInfo()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactInfo> ContactInfoCollection = new CustomList<ContactInfo>();
            IDataReader reader = null;
            const String sql = "select *from ContactInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactInfo newContactInfo = new ContactInfo();
                    newContactInfo.SetData(reader);
                    ContactInfoCollection.Add(newContactInfo);
                }
                return ContactInfoCollection;
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
        public static CustomList<ContactInfo> GetAllContactInfoForDropDown()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<ContactInfo> ContactInfoCollection = new CustomList<ContactInfo>();
            IDataReader reader = null;
            const String sql = "select *from ContactInfo";
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    ContactInfo newContactInfo = new ContactInfo();
                    newContactInfo.SetDataForDropdown(reader);
                    ContactInfoCollection.Add(newContactInfo);
                }
                return ContactInfoCollection;
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
