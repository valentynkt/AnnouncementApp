using BL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnounceController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnounceController> _logger;

        public AnnounceController(IAnnouncementService announcementService,ILogger<AnnounceController> logger)
        {
            _announcementService = announcementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await _announcementService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Announcement> GetById(int id)
        {
            return await _announcementService.GetById(id);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Announcement item)
        {
            try
            {
                await _announcementService.Update(item);
                return new EmptyResult();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
