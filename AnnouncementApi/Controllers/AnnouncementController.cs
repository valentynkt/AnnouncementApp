using System.Text.Json;
using BL.DTO;
using BL.Extensions;
using BL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly ILogger<AnnouncementController> _logger;

        public AnnouncementController(IAnnouncementService announcementService,ILogger<AnnouncementController> logger)
        {
            _announcementService = announcementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Announcement>?> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all announcements");
                var announcements= await _announcementService.GetAll();
                _logger.LogInformation("Announcements count:@{announcementCount}", announcements.Count());
                return announcements;
            }
            catch (Exception e)
            {
                _logger.LogAppError(e, e.Message);
                return null;
            }
        }
        [HttpGet("getbytitle/{title}")]
        public async Task<IEnumerable<Announcement>?> GetByTitle(string title)
        {
            try
            {
                _logger.LogInformation("Getting announcement by title: {title}", title);
                var announcements = await _announcementService.GetByTitle(title);
                _logger.LogInformation("Announcements count:@{announcementCount}", announcements.Count());
                return announcements;
            }
            catch (Exception e)
            {
                _logger.LogAppError(e, e.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public async Task<AnnouncementDetails?> GetById(int id)
        {
            try
            {
                _logger.LogInformation("Getting announcement by id: {id}",id);
                var announcement = await _announcementService.GetById(id);
                _logger.LogInformation("Getting similar list of announcements by id: {id}", id);
                var similarList = await _announcementService.GetSimilar(id);
                var announcementDetails = new AnnouncementDetails(announcement, similarList);
                _logger.LogInformation("Announcement details by id:{id}:@{announcementDetails}", id, announcementDetails);
                return announcementDetails;
            }
            catch (Exception e)
            {
                _logger.LogAppError(e, e.Message);
                return null;
            }
        }

        [HttpPost("new")]
        public async Task<IActionResult> Add(Announcement item)
        {
            try
            {
                _logger.LogInformation("Creating announcement:@{announcement}", item);
                item.CreatedOn=DateTime.Now;
                await _announcementService.Add(item);
                _logger.LogInformation("Successfully Created");
                return CreatedAtAction(nameof(Add), new { id = item.Id }, item);

            }
            catch (Exception e)
            {
                _logger.LogAppError(e, e.Message);
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(int id,Announcement item)
        {
            try
            {
                _logger.LogInformation("Creating announcement:@{announcement}", item);
                item.Id = id;
                item.LastModifiedOn=DateTime.Now;
                await _announcementService.Update(item);
                return CreatedAtAction(nameof(Update), new { id = item.Id }, item);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Deleting announcement by id:{id}", id);
                await _announcementService.DeleteById(id);
                string respMsg = "Successfully Deleted";
                _logger.LogInformation(respMsg);
                return Ok(respMsg);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
