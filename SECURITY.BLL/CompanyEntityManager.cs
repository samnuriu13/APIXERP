using API.DATA;
using STATIC;


namespace SECURITY.BLL
{
    public class CompanyEntityManager
    {
        public CustomList<CompanyEntity> GetAllCompanyEntity()
        {
            return CompanyEntity.GetAllCompanyEntity();
        }
    }
}
