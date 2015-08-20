using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
    public class StatusListManager
    {
        public CustomList<CmnStatusList> GetAllCmnStatusList()
        {
            return CmnStatusList.GetAllCmnStatusList();
        }
    }
}
