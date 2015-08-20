using System;
using System.Collections.Generic;
using API.DAL;
using API.DATA;
using SECURITY.DAO;
using STATIC;
namespace SECURITY.BLL
{
    public class SecurityRuleManager
    {
        public CustomList<SecurityRule> GetAlltblSecurityRule()
        {
            return SecurityRule.doSearch(String.Empty);
        }
    }
}
