using API.DATA;
using SECURITY.DAO;


namespace SECURITY.BLL
{
    public class ApplicationManager
    {
        public CustomList<Application> GetAllApplication()
        {
            return Application.GetAllApplication();
        }

        public CustomList<Menu> GetAllMenusForAnApplication(int applicaitonId)
        {
            return Menu.GetAllMenuByApplicationID(applicaitonId);
        }

        public CustomList<Menu> GetAllMenuList()
        {
            return Menu.GetAllMenuList();
        }

        public Users GetDefaultApplicationOfCurrentUser(string userCode)
        {
            return Users.GetDefaultApplicationByUserCode(userCode);
        }
        
        public SiteMaster GetCurrentSite()
        {
            return SiteMaster.GetCurrentSite();
        }
    }
}
