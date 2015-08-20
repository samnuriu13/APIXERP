using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
    public class TransactionTypeManager
    {
        public CustomList<CmnTransactionType> GetAllReferenceType(Int32 DocListID)
        {
            return CmnTransactionType.GetAllReferenceType(DocListID);
        }
        public CustomList<PopulateDropdownList> GetAllReferenceTransaction(Int32 DocListID,Int32 RefType)
        {
            return PopulateDropdownList.GetAllReferenceTransaction(DocListID, RefType);
        }
    }
}
