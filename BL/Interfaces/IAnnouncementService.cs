using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BL.Interfaces
{
    public interface IAnnouncementService : IService<Announcement>
    {
        Task<List<Announcement>> GetByTitle(string title);
        Task<List<Announcement>> GetSimilar(int id);
    }
}
