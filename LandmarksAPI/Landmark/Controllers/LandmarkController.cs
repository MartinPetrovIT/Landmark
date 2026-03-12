using LandmarksAPI.Landmark.Mappings;
using LandmarksAPI.Services.Landmark.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace LandmarksAPI.Landmark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LandmarkController(ILandmarkService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Models.Landmark>>> GetAll()
        {
            List<Services.Landmark.Models.Landmark> landmarks =
                await service.GetAllLandmarksAsync();

            List<Models.Landmark> result =
                [.. landmarks.Select(LandmarkMapper.Map)];

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Models.Landmark landmark)
        {
            Services.Landmark.Models.Landmark newLandmark = 
                LandmarkMapper.Map(landmark);

            await service.AddLandmarkAsync(newLandmark);

            return Ok(new { message = "Обектът е добавен успешно!" });
        }
    }
}
