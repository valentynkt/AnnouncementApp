using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Extensions;
using BL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BL.Services
{
    public class AnnouncementService:IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;

        private char[] seperators = new char[]
        {
            ' ',
            ',',
            '.',
            '?',
            '!'
        };
        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Announcement>> GetAll()
        {
            var list = await _unitOfWork.AnnouncementRep.Get();
            return list;
        }

        public async Task<Announcement> GetById(int id)
        {
            var item = await _unitOfWork.AnnouncementRep.FindById(id);
            return item;
        }

        public async Task Add(Announcement entity)
        {
            if (!AnnouncementServiceExtension.ModelCheck(entity))
            {
                throw new ArgumentNullException($"Entity is invalid,id: {entity.Id}");
            }
            _unitOfWork.AnnouncementRep.Create(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(Announcement entity)
        {
            if (!AnnouncementServiceExtension.ModelCheck(entity))
            {
                throw new ArgumentNullException($"Entity is invalid,id: {entity.Id}");
            }
            _unitOfWork.AnnouncementRep.Create(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task Delete(Announcement entity)
        {
            _unitOfWork.AnnouncementRep.Remove(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteById(int id)
        {
            var item=await _unitOfWork.AnnouncementRep.FindById(id);
            _unitOfWork.AnnouncementRep.Remove(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<Announcement>> GetByTitle(string title)
        {
            var allAnnouncement = await _unitOfWork.AnnouncementRep.Get();
            var list = new List<Announcement>();
            foreach (var item in allAnnouncement)
            {
                var words = item.Title.ToLower().Split(' ');
                if (words.Contains(title.ToLower()))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public async Task<List<Announcement>> GetSimilar(int id)
        {
            var mainItem = await GetById(id);
            var mainItemTitle = mainItem.Title.ToLower().Split(seperators);
            var mainItemDescription = mainItem.Description.ToLower().Split(seperators);
            Dictionary<Announcement, int> similarWords = new();
            var allAnnouncement = (await _unitOfWork.AnnouncementRep.Get()).ToList();
            for (int i = 1; i <= allAnnouncement.Count(); i++)
            {
                var currentItem = await GetById(i);
                var currentItemTitle = currentItem.Title.ToLower().Split(seperators);
                var currentItemDescription = currentItem.Description.ToLower().Split(seperators);
                similarWords.Add(currentItem, 0);
                foreach (var t in mainItemTitle) 
                {
                    if (currentItemTitle.Contains(t))
                    {
                        similarWords.Increment(currentItem);
                    }
                }
                foreach (var t in mainItemDescription)
                {
                    if (currentItemDescription.Contains(t))
                    {
                        similarWords.Increment(currentItem);
                    }
                }
            }

            similarWords.Remove(mainItem);
            var result = similarWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value).Keys.Take(3).ToList();

            return result;
        }
    }
}
