using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using API.DAO;
using STATIC;

namespace API.BLL
{
    public class ContactInfoManager
    {
        public CustomList<ContactInfo> GetAllContactInfo()
        {
            return ContactInfo.GetAllContactInfo();
        }
        public CustomList<ContactInfo> GetAllEmployee()
        {
            return ContactInfo.GetAllEmployee();
        }
        public CustomList<ContactType> GetAllContactType()
        {
            return ContactType.GetAllContactType();
        }
        public CustomList<ContactDetail> GetAllContactDetail(Int32 ContactID)
        {
            return ContactDetail.GetAllContactDetail(ContactID);
        }
        public CustomList<ContactInfo> GetAllSupplier()
        {
            return ContactInfo.GetAllSupplier();
        }

        public void SaveContactInfo(ref CustomList<ContactInfo> ContactInfoList, ref CustomList<ContactType> ContactTypeList, ref CustomList<ContactTypeChild> ContactTypeChildList, ref CustomList<ContactDetail> lstContactDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                ReSetSPName(ContactInfoList, ContactTypeList, ContactTypeChildList);
                Int32 contactID = ContactInfoList[0].ContactID;
                blnTranStarted = true;
                if (ContactInfoList[0].IsAdded)
                {
                    contactID = Convert.ToInt32(conManager.InsertData(blnTranStarted, ContactInfoList));
                    ContactInfoList[0].ContactID = contactID;
                }
                else
                    conManager.SaveDataCollectionThroughCollection(blnTranStarted, ContactInfoList);

                foreach (ContactType cT in ContactTypeList)
                {
                    CustomList<ContactType> ContactType_List = new CustomList<ContactType>();
                    if (cT.IsAdded)
                    {
                        Int32 contactTypeID = 0;
                        ContactType_List.Add(cT);
                        ContactType_List.InsertSpName = "spInsertContactType";
                        contactTypeID = Convert.ToInt32(conManager.InsertData(blnTranStarted, ContactType_List));
                        cT.ContactTypeID = contactTypeID;
                    }
                    if (cT.IsModified)
                    {
                        cT.SetModified();
                        ContactType_List.Add(cT);
                        ContactType_List.UpdateSpName = "spUpdateContactType";
                        conManager.SaveDataCollectionThroughCollection(blnTranStarted, ContactType_List);
                    }
                }
                CustomList<ContactDetail> ContactDetailList = new CustomList<ContactDetail>();
                foreach (ContactType cT in ContactTypeList)
                {
                    if (cT.IsChecked)
                    {
                        ContactDetail contactDetail = new ContactDetail();
                        contactDetail.ContactTypeID = cT.ContactTypeID;
                        contactDetail.ContactID = contactID;
                        ContactDetailList.Add(contactDetail);
                    }
                }
                foreach (ContactDetail cD in lstContactDetail)
                {
                    ContactDetail obj = ContactDetailList.Find(f => f.ContactTypeID == cD.ContactTypeID);
                    if (obj.IsNotNull())
                        obj.SetModified();
                    else
                    {
                        cD.Delete();
                        ContactDetailList.Add(cD);
                    }

                }

                ReSetSPName(ContactDetailList);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, ContactDetailList);

                ContactInfoList.AcceptChanges();
                ContactTypeList.AcceptChanges();
                ContactTypeChildList.AcceptChanges();
                ContactDetailList.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }
        public void SaveContactInfo(ref CustomList<ContactInfo> ContactInfoList, ref CustomList<ContactDetail> lstContactDetail)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            Boolean blnTranStarted = false;

            try
            {
                conManager.BeginTransaction();

                blnTranStarted = true;

                ReSetSPName(ContactInfoList, lstContactDetail);

                conManager.SaveDataCollectionThroughCollection(blnTranStarted, lstContactDetail, ContactInfoList);

                lstContactDetail.AcceptChanges();
                ContactInfoList.AcceptChanges();

                conManager.CommitTransaction();
                blnTranStarted = false;
            }
            catch (Exception Ex)
            {
                conManager.RollBack();
                throw Ex;
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
        }
        private void ReSetSPName(CustomList<ContactInfo> ContactInfoList, CustomList<ContactDetail> ContactDetailList)
        {
            #region Contact Info
            ContactInfoList.InsertSpName = "spInsertContactInfo";
            ContactInfoList.UpdateSpName = "spUpdateContactInfo";
            ContactInfoList.DeleteSpName = "spDeleteContactInfo";
            #endregion
            #region Contact Type Detail
            ContactDetailList.InsertSpName = "spInsertContactDetail";
            ContactDetailList.UpdateSpName = "spUpdateContactDetail";
            ContactDetailList.DeleteSpName = "spDeleteContactDetail";
            #endregion
        }
        private void ReSetSPName(CustomList<ContactInfo> ContactInfoList, CustomList<ContactType> ContactTypeList, CustomList<ContactTypeChild> ContactTypeChildList)
        {
            #region Contact Info
            ContactInfoList.InsertSpName = "spInsertContactInfo";
            ContactInfoList.UpdateSpName = "spUpdateContactInfo";
            ContactInfoList.DeleteSpName = "spDeleteContactInfo";
            #endregion
            #region Contact Type
            ContactTypeList.InsertSpName = "spInsertContactType";
            ContactTypeList.UpdateSpName = "spUpdateContactType";
            ContactTypeList.DeleteSpName = "spDeleteContactType";
            #endregion
            #region Contact Type Detail
            ContactTypeChildList.InsertSpName = "spInsertContactTypeChild";
            ContactTypeChildList.UpdateSpName = "spUpdateContactTypeChild";
            ContactTypeChildList.DeleteSpName = "spDeleteContactTypeChild";
            #endregion
        }
        private void ReSetSPName(CustomList<ContactDetail> ContactDetailList)
        {
            #region Contact Type Detail
            ContactDetailList.InsertSpName = "spInsertContactDetail";
            ContactDetailList.UpdateSpName = "spUpdateContactDetail";
            ContactDetailList.DeleteSpName = "spDeleteContactDetail";
            #endregion
        }
    }
}
