using System;
using System.Data;
using API.DAL;
using API.DATA;
using REPORT.DAO;

namespace REPORT.BLL
{

    public class ReportSuite
    {
        String ConName = String.Empty;
        public ReportSuite(String conName)
        {
            ConName = conName;
        }
        public CustomList<ReportSuiteMenu> GetReportSuiteMenu(string userCode)
        {
            return ReportSuiteMenu.GetReportSuiteMenu(userCode);
        }
        public CustomList<ReportSuiteMenu> GetReportSuiteMenu()
        {
            return ReportSuiteMenu.GetReportSuiteMenu();
        }
        public void LoadReportTreeInfo(ref DataSet dsRef)
        {
            ConnectionManager conManager = new ConnectionManager(ConName);
            IDataReader reader = null;
            try
            {
                const String spName = "spWebReportSuite";
                conManager.OpenDataReader(out reader, spName, 1, 0);
                dsRef = Util.DataReaderToDataSet(reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }

                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }
        public DataSet LoadReportParameterInfoFromDB(int ReportID)
        {
            ConnectionManager conManager = new ConnectionManager(ConName);
            IDataReader reader = null;
            try
            {
                DataSet dsRef = new DataSet();
                const String spName = "spWebReportSuite";
                conManager.OpenDataReader(out reader, spName, 0, ReportID);
                dsRef = Util.DataReaderToDataSet(reader);
                return dsRef;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }
                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }
        public Int32 CheckMailExist(string reportId)
        {
            ConnectionManager conManager = new ConnectionManager(ConName);

            Int32 ID = 0;
            try
            {
                String sql = "GetReportID " + reportId;
                Object id = conManager.ExecuteScalarWrapper(sql);
                ID = Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager.IsNotNull())
                {
                    conManager.Dispose();
                }
            }
            return ID;
        }

        public DataSet LoadMailInfo(Int32 ReportID)
        {
            ConnectionManager conManager = new ConnectionManager(ConName);
            IDataReader reader = null;
            try
            {
                DataSet dsRef = new DataSet();
                const String spName = "spGetMailInfo";
                conManager.OpenDataReader(out reader, spName, ReportID);
                dsRef = Util.DataReaderToDataSet(reader);
                return dsRef;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }
                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }
        public void LoadReportSourceDataSet(ref DataSet dsRef, CommandType cmdType, String strCmdText, IDbDataParameter[] sqlParam)
        {
            ConnectionManager conManager = new ConnectionManager(ConName);
            IDataReader reader = null;
            try
            {
                if (sqlParam.IsNull() || sqlParam.Length.IsZero())
                    conManager.OpenDataReader(strCmdText, out reader);
                else
                    conManager.OpenDataReader(out reader, strCmdText, sqlParam);
                //
                dsRef = Util.DataReaderToDataSet(reader);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (conManager != null)
                {
                    conManager.CloseConnection();
                    conManager.Dispose();
                }
                if (reader.IsNotNull() && reader.IsClosed.IsFalse())
                    reader.Close();
            }
        }
    }
}
