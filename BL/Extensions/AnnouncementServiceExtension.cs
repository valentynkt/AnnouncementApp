using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BL.Extensions
{
    public static class AnnouncementServiceExtension
    {
        public static bool ModelCheck(Announcement entity)
        {
            if (string.IsNullOrEmpty(entity.Title) || string.IsNullOrEmpty(entity.Description))
            {
                return false;
            }

            return true;
        }
    }
}
