using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BL.DTO
{
    public class AnnouncementDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public List<Announcement> SimilarAnnouncement;
        public int[] SimilarAnnouncementIds;

        public AnnouncementDetails(Announcement announcement,List<Announcement> list)
        {
            Id = announcement.Id;
            Title= announcement.Title;
            Description= announcement.Description;
            CreatedOn = announcement.CreatedOn;
            LastModifiedOn = announcement.LastModifiedOn;
            SimilarAnnouncement = list;
            SimilarAnnouncementIds = list.Select(x => x.Id).ToArray();
        }

    }
}
