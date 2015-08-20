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
    public class TreeGenerator : BaseItem
    {
        public TreeGenerator()
        {
            SetAdded();
        }

        #region Properties
        [Browsable(true), DisplayName("Parent")]
        public System.String Parent
        {
            get
            {
                return _Parent;
            }
            set
            {
                if (PropertyChanged(_Parent, value))
                    _Parent = value;
            }
        }
        private System.String _Parent;
        [Browsable(true), DisplayName("Nodekey")]
        public System.String Nodekey
        {
            get
            {
                return _Nodekey;
            }
            set
            {
                if (PropertyChanged(_Nodekey, value))
                    _Nodekey = value;
            }
        }
        private System.String _Nodekey;
        [Browsable(true), DisplayName("tag")]
        public System.String tag
        {
            get
            {
                return _tag;
            }
            set
            {
                if (PropertyChanged(_tag, value))
                    _tag = value;
            }
        }
        private System.String _tag;
        [Browsable(true), DisplayName("Description")]
        public System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                if (PropertyChanged(_Description, value))
                    _Description = value;
            }
        }
        private System.String _Description;
        [Browsable(true), DisplayName("ItemCode")]
        public System.String ItemCode
        {
            get
            {
                return _ItemCode;
            }
            set
            {
                if (PropertyChanged(_ItemCode, value))
                    _ItemCode = value;
            }
        }
        private System.String _ItemCode;
        [Browsable(true), DisplayName("Orderlevel")]
        public System.String Orderlevel
        {
            get
            {
                return _Orderlevel;
            }
            set
            {
                if (PropertyChanged(_Orderlevel, value))
                    _Orderlevel = value;
            }
        }
        private System.String _Orderlevel;
        #endregion

        public override Object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _Parent, _Nodekey, _tag, _Description, _Orderlevel };
            else if (IsModified)
                parameterValues = new Object[] { _Parent, _Nodekey, _tag, _Description, _Orderlevel };
            else if (IsDeleted)
                parameterValues = new Object[] { _tag };
            return parameterValues;
        }
        protected override void SetData(IDataRecord reader)
        {
            _Parent = reader.GetString("Parent");
            _Nodekey = reader.GetString("Nodekey");
            _tag = reader.GetString("tag");
            _Description = reader.GetString("Description");
            _Orderlevel = reader.GetString("Orderlevel");
            _ItemCode = reader.GetString("ItemCode");
            SetUnchanged();
        }
        private void SetDataRequisition(IDataRecord reader)
        {
            _Parent = reader.GetString("Parent");
            _Nodekey = reader.GetString("Nodekey");
            _tag = reader.GetString("tag");
            _Description = reader.GetString("Description");
            _Orderlevel = reader.GetString("Orderlevel");
            SetUnchanged();
        }
        public static CustomList<TreeGenerator> GetAllTreeGenerator()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TreeGenerator> TreeGeneratorCollection = new CustomList<TreeGenerator>();
            const String sql = "Select *from TreeGenerator";
            try
            {
                IDataReader reader;
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TreeGenerator newTreeGenerator = new TreeGenerator();
                    newTreeGenerator.SetData(reader);
                    TreeGeneratorCollection.Add(newTreeGenerator);
                }
                reader.Close();
                TreeGeneratorCollection.SelectSpName = "spSelectTreeGenerator";
                TreeGeneratorCollection.InsertSpName = "spInsertTreeGenerator";
                TreeGeneratorCollection.UpdateSpName = "spUpdateTreeGenerator";
                TreeGeneratorCollection.SelectSpName = "spDeleteTreeGenerator";
                return TreeGeneratorCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static CustomList<TreeGenerator> GetAllTreeGenerator(string projectCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TreeGenerator> TreeGeneratorCollection = new CustomList<TreeGenerator>();
            String sql = "EXEC spSWebTreeGenerator '" + projectCode + "'";
            try
            {
                IDataReader reader;
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TreeGenerator newTreeGenerator = new TreeGenerator();
                    newTreeGenerator.SetDataRequisition(reader);
                    TreeGeneratorCollection.Add(newTreeGenerator);
                }
                reader.Close();
                TreeGeneratorCollection.SelectSpName = "spSelectTreeGenerator";
                TreeGeneratorCollection.InsertSpName = "spInsertTreeGenerator";
                TreeGeneratorCollection.UpdateSpName = "spUpdateTreeGenerator";
                TreeGeneratorCollection.SelectSpName = "spDeleteTreeGenerator";
                return TreeGeneratorCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static CustomList<TreeGenerator> GetAllTreeGeneratorWithAdditionalWork(string TranId)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TreeGenerator> TreeGeneratorCollection = new CustomList<TreeGenerator>();
            String sql = "EXEC spSWebTreeGeneratorForAdditionalItem '" + TranId + "'";
            try //spSWebTreeGeneratorForAdditionalItem
            {
                IDataReader reader;
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TreeGenerator newTreeGenerator = new TreeGenerator();
                    newTreeGenerator.SetDataRequisition(reader);
                    TreeGeneratorCollection.Add(newTreeGenerator);
                }
                reader.Close();
                return TreeGeneratorCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static CustomList<TreeGenerator> GetAllTreeGeneratorWithOpeningAndWithoutPO()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TreeGenerator> TreeGeneratorCollection = new CustomList<TreeGenerator>();
            String sql = "EXEC spSWebTreeGeneratorWithAllItem";
            try
            {
                IDataReader reader;
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TreeGenerator newTreeGenerator = new TreeGenerator();
                    newTreeGenerator.SetData(reader);
                    TreeGeneratorCollection.Add(newTreeGenerator);
                }
                reader.Close();
                return TreeGeneratorCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public static CustomList<TreeGenerator> GetAllTreeGenerator(string location, string projectCode)
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.HR);
            CustomList<TreeGenerator> TreeGeneratorCollection = new CustomList<TreeGenerator>();
            String sql = "EXEC spSWebTreeGeneratorLocationWiseProjectItem '" + location + "','" + projectCode + "'";
            try
            {
                IDataReader reader;
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    TreeGenerator newTreeGenerator = new TreeGenerator();
                    newTreeGenerator.SetDataRequisition(reader);
                    TreeGeneratorCollection.Add(newTreeGenerator);
                }
                reader.Close();
                return TreeGeneratorCollection;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
