using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using ACC.DAO;
using API.DAO;

namespace ACC.BLL
{
   public class BankAccountManager
    {
       public CustomList<CmnBankAccountType> GetAllCmnBankAccountType()
       {
           return CmnBankAccountType.GetAllCmnBankAccountType();
       }
       public CustomList<Bank_Branch> GetAllBank_Branch()
       {
           return Bank_Branch.GetAllBank_Branch();
       }
       public CustomList<CmnBankAccount> GetAllCmnBankAccount()
       {
           return CmnBankAccount.GetAllCmnBankAccount();
       }
       public void SaveBankAccount(ref CustomList<CmnBankAccount> BankAccountList)
       {
           ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
           Boolean blnTranStarted = false;

           try
           {
               conManager.BeginTransaction();

               ReSetSPName(BankAccountList);
               Int32 accountID = BankAccountList[0].AccountID;
               blnTranStarted = true;
               if (BankAccountList[0].IsAdded)
                   accountID = Convert.ToInt32(conManager.InsertData(blnTranStarted, BankAccountList));
               else
                   conManager.SaveDataCollectionThroughCollection(blnTranStarted, BankAccountList);

               BankAccountList.AcceptChanges();

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
       private void ReSetSPName(CustomList<CmnBankAccount> BankAccountList)
       {
           #region Bank
           BankAccountList.InsertSpName = "spInsertCmnBankAccount";
           BankAccountList.UpdateSpName = "spUpdateCmnBankAccount";
           BankAccountList.DeleteSpName = "spDeleteCmnBankAccount";
           #endregion
       }
    }
}
