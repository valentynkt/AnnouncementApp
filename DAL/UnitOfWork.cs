using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IAnnouncementRep _announcementRep;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IAnnouncementRep AnnouncementRep
        {
            get
            {
                if (this._announcementRep == null)
                {
                    this._announcementRep = new AnnouncementRep(_context);
                }

                return _announcementRep;
            }
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}