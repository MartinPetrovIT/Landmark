using LandmarksAPI.Checkin.Mappings;
using LandmarksAPI.Services.Checkin.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace LandmarksAPI.Checkin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckinController(ICheckinService checkinService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(Models.CheckinRequest request)
        {
            var requestMapped = CheckinMapper.Map(request);

            var response = await checkinService.ProcessCheckinAsync(requestMapped);

            var responseMapped = CheckinMapper.Map(response);

            if (responseMapped.IsSuccess)
            {
                return Ok(responseMapped);
            }

            return BadRequest(responseMapped);
        }
    }
}
