using System;
using System.Collections.Generic;
using API.DATA;
using API.DAL;
using REPORT.DAO;
using STATIC;
using API.DAO;

namespace API.BLL
{
   public class StockViewManager
    {
       public CustomList<StockView> StockView1()
       {
           //StockView obj = new StockView();
           return StockView.StockView1();
       }
    }
}
