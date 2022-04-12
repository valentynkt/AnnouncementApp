using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRep<Announcement> _announcementRep;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IGenericRep<Announcement> AnnouncementRep
        {
            get
            {
                if (this._announcementRep == null)
                {
                    this._announcementRep = new GenericRep<Announcement>(_context);
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