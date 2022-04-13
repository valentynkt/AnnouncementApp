using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAnnouncementRep AnnouncementRep { get; }

        Task<int> SaveAsync();
    }
}
