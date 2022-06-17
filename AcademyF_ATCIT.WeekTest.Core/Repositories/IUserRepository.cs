using AcademyF_ATCIT.WeekTest.Core.Core.Entities;
using AcademyF_ATCIT.WeekTest.Core.Entities;
using AcademyF_ATCIT.WeekTest.Core.Repositories.Common;

namespace AcademyF_ATCIT.WeekTest.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string userName);
    }
}