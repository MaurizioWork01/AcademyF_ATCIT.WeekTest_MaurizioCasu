using AcademyF_ATCIT.WeekTest.RepositoryMock.Repositories.Common;
using AcademyF_ATCIT.WeekTest.Core.Entities;
using AcademyF_ATCIT.WeekTest.Core.Repositories;

namespace AcademyF_ATCIT.WeekTest.RepositoryMock.Repositories
{
    /// <summary>
    /// Repository of "Dipendente" with in-memory engine
    /// </summary>
    public class InMemoryGiftCardRepository : InMemoryRepositoryBase<GiftCard>, IGiftCardRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public InMemoryGiftCardRepository()
            : base(storage => storage.GiftCards) { }
    }
}
