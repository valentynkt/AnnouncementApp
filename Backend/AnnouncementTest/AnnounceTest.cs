using System;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using NUnit.Framework;

namespace AnnouncementTest
{
    [TestFixture]
    public class Tests
    {
        private static string dateOfCreation = "2005-05-05 22:12 PM";
        private static string dateOfChange = "2005-05-05 22:25 PM";

        private Announcement announcement = new Announcement()
        {
            Id = 1,
            Title = "Yet remarkably appearance get him his projection",
            Description =
                "Improve ashamed married expense bed her comfort pursuit mrs. " +
                "Four time took ye your as fail lady. Up greatest am exertion or marianne. Shy occasional terminated insensible and inhabiting gay." +
                " So know do fond to half on. Now who promise was justice new winding. In finished on he speaking suitable advanced if. " +
                "Boy happiness sportsmen say prevailed offending concealed nor was provision. " +
                "Provided so as doubtful on striking required. Waiting we to compass assured." +
                "\r\n\r\nSo delightful up dissimilar by unreserved it connection frequently. Do an high room so in paid. Up on cousin ye dinner should in. " +
                "Stood tried walls manor truth shy and three his. Their to years so child truth. Honoured peculiar families sensible up likewise by on in.\r\n",
            CreatedOn = Convert.ToDateTime(dateOfCreation),
            LastModifiedOn = Convert.ToDateTime(dateOfChange)
    };

        [Test]
        public async Task AnnouncementRep_GetAll_ReturnsAllValues()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);

            var elements = await repository.Get();

            Assert.AreEqual(6, elements.Count());
        }

        [Test]
        public async Task AnnouncementRep_GetById_ReturnsSingleValue()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);

            var element = await repository.FindById(1);

            Assert.AreEqual(1, element.Id);
            Assert.AreEqual(announcement.Title, element.Title);
            Assert.AreEqual(announcement.Description, element.Description);
            Assert.AreEqual(announcement.CreatedOn, element.CreatedOn);
            Assert.AreEqual(announcement.LastModifiedOn, element.LastModifiedOn);
        }

        [Test]
        public async Task AnnouncementRep_AddAsync_AddsValueToDatabase()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);
            var element = new Announcement() {Id = 7};

             repository.Create(element);
            await context.SaveChangesAsync();
            var actual = context.Announcements.Count();
            Assert.AreEqual(7, actual);
        }

        [Test]
        public async Task AnnouncementRep_DeleteAsync_DeletesEntity()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);
            var element = new Announcement() {Id = 1};
            repository.Remove(element);
            await context.SaveChangesAsync();

            Assert.AreEqual(5, context.Announcements.Count());
        }

        [Test]
        public async Task AnnouncementRep_Update_UpdatesEntity()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);

            var element = new Announcement() {Id = 1, Description = "NewText"};

            repository.Update(element);
            await context.SaveChangesAsync();

            Assert.AreEqual("NewText", element.Description);
        }

        [Test]
        public async Task AnnouncementRep_FindByCondition_ReturnsValues()
        {
            await using var context = new AppDbContext(UnitTestHelper.GetUnitTestDbOptions());
            var repository = new AnnouncementRep(context);

            var elements = (await repository.Get(x => x.Id == 1)).ToList();
            Assert.AreEqual(1, elements[0].Id);
        }
    }
}