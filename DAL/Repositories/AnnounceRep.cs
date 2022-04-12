using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AnnounceRep : IAnnounceRep
    {
        private readonly AppDbContext _context;

        public AnnounceRep(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Announcement>> Get()
        {
            return await _context.Set<Announcement>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Announcement>> Get(Expression<Func<Announcement, bool>> predicate)
        {
            return await _context.Announcements.Where(predicate).AsNoTracking().ToListAsync();
        }
        public async Task<Announcement> FindById(int id)
        {
            return await _context.Announcements.FindAsync(id) ?? throw new ArgumentException($"There are no entity with this id:{id}");
        }

        public void Create(Announcement item)
        {
            _context.Announcements.Add(item);
        }
        public void Update(Announcement item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Remove(Announcement item)
        {
            _context.Announcements.Remove(item);
        }
    }
}
