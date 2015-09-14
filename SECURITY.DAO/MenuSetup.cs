using System;
using System.ComponentModel;
using System.Data;
using API.DAL;
using API.DATA;
using STATIC;
using SECURITY.DAO;

namespace SECURITY.DAO
{
    public class MenuSetup : BaseItem
    {
        public MenuSetup()
        {
            SetAdded();
        }

        private System.String _MenuID;
        [Browsable(true), DisplayName("MenuID")]
        public System.String MenuID
        {
            get
            {
                return _MenuID;
            }
            set
            {
                if (PropertyChanged(_MenuID, value))
                    _MenuID = value;
            }
        }

        private System.String _ApplicationID;
        [Browsable(true), DisplayName("ApplicationID")]
        public System.String ApplicationID
        {
            get
            {
                return _ApplicationID;
            }
            set
            {
                if (PropertyChanged(_ApplicationID, value))
                    _ApplicationID = value;
            }
        }

        private System.Int32 _ValueMember;
        [Browsable(true), DisplayName("ValueMember")]
        public System.Int32 ValueMember
        {
            get
            {
                return _ValueMember;
            }
            set
            {
                if (PropertyChanged(_ValueMember, value))
                    _ValueMember = value;
            }
        }

        private System.String _DisplayMember;
        [Browsable(true), DisplayName("DisplayMember")]
        public System.String DisplayMember
        {
            get
            {
                return _DisplayMember;
            }
            set
            {
                if (PropertyChanged(_DisplayMember, value))
                    _DisplayMember = value;
            }
        }

        private System.Int32 _ParentID;
        [Browsable(true), DisplayName("ParentID")]
        public System.Int32 ParentID
        {
            get
            {
                return _ParentID;
            }
            set
            {
                if (PropertyChanged(_ParentID, value))
                    _ParentID = value;
            }
        }

        private System.Int32 _IsVisible;
        [Browsable(true), DisplayName("IsVisible")]
        public System.Int32 IsVisible
        {
            get
            {
                return _IsVisible;
            }
            set
            {
                if (PropertyChanged(_IsVisible, value))
                    _IsVisible = value;
            }
        }

        private System.Int32 _Type;
        [Browsable(true), DisplayName("Type")]
        public System.Int32 Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (PropertyChanged(_Type, value))
                    _Type = value;
            }
        }

        private System.String _Description;
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

        private System.String _FormName;
        [Browsable(true), DisplayName("FormName")]
        public System.String FormName
        {
            get
            {
                return _FormName;
            }
            set
            {
                if (PropertyChanged(_FormName, value))
                    _FormName = value;
            }
        }

        private System.String _MenuType;
        [Browsable(true), DisplayName("MenuType")]
        public System.String MenuType
        {
            get
            {
                return _MenuType;
            }
            set
            {
                if (PropertyChanged(_MenuType, value))
                    _MenuType = value;
            }
        }

        private System.Int32 _MenuSequence;
        [Browsable(true), DisplayName("MenuSequence")]
        public System.Int32 MenuSequence
        {
            get
            {
                return _MenuSequence;
            }
            set
            {
                if (PropertyChanged(_MenuSequence, value))
                    _MenuSequence = value;
            }
        }

        private System.String _DataType;
        [Browsable(true), DisplayName("DataType")]
        public System.String DataType
        {
            get
            {
                return _DataType;
            }
            set
            {
                if (PropertyChanged(_DataType, value))
                    _DataType = value;
            }
        }

        public override object[] GetParameterValues()
        {
            Object[] parameterValues = null;
            if (IsAdded)
                parameterValues = new Object[] { _ApplicationID, _ValueMember, _DisplayMember, _ParentID, _IsVisible, _Type, _Description, _FormName, _MenuType, _MenuSequence, _DataType };
            else if (IsModified)
                parameterValues = new Object[] { _MenuID, _ApplicationID, _ValueMember, _DisplayMember, _ParentID, _IsVisible, _Type, _Description, _FormName, _MenuType, _MenuSequence, _DataType };
            else if (IsDeleted)
                parameterValues = new Object[] { _MenuID };
            return parameterValues;
        }

        protected override void SetData(IDataRecord reader)
        {
            _MenuID = reader.GetString("MenuID");
            _DisplayMember = reader.GetString("DisplayMember");
            _ParentID = reader.GetInt32("ParentID");
            _IsVisible = reader.GetInt32("IsVisible");
            _Description = reader.GetString("Description");
            _FormName = reader.GetString("FormName");
            _MenuType = reader.GetString("MenuType");
            _MenuSequence = reader.GetInt32("MenuSequence");
            SetUnchanged();
        }

        private void SetDataMenu(IDataRecord reader)
        {
            _MenuID = reader.GetString("MenuID");
            _DisplayMember = reader.GetString("DisplayMember");
        }

        private void SetDataForMenuType(IDataRecord reader)
        {
            _MenuType = reader.GetString("MenuType");
        }

        public static CustomList<MenuSetup> GetAllMenuList()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<MenuSetup> MenuCollection = new CustomList<MenuSetup>();
            IDataReader reader = null;
            String sql = String.Format("Select MenuID,DisplayMember from Menu");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MenuSetup newMenu = new MenuSetup();
                    newMenu.SetDataMenu(reader);
                    MenuCollection.Add(newMenu);
                }
                return MenuCollection;
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

        public static CustomList<MenuSetup> GetAllMenu()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<MenuSetup> MenuCollection = new CustomList<MenuSetup>();
            IDataReader reader = null;
            String sql = String.Format("Select * from Menu");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MenuSetup newMenu = new MenuSetup();
                    newMenu.SetData(reader);
                    MenuCollection.Add(newMenu);
                }
                MenuCollection.InsertSpName = "spInsertMenu";
                MenuCollection.UpdateSpName = "spUpdateMenu";
                MenuCollection.DeleteSpName = "spDeleteMenu";
                return MenuCollection;
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

        public static CustomList<MenuSetup> GetMenuType()
        {
            ConnectionManager conManager = new ConnectionManager(ConnectionName.SysMan);
            CustomList<MenuSetup> MenuCollection = new CustomList<MenuSetup>();
            IDataReader reader = null;
            String sql = String.Format("Select distinct MenuType from Menu");
            try
            {
                conManager.OpenDataReader(sql, out reader);
                while (reader.Read())
                {
                    MenuSetup newMenu = new MenuSetup();
                    newMenu.SetDataForMenuType(reader);
                    MenuCollection.Add(newMenu);
                }
                return MenuCollection;
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
