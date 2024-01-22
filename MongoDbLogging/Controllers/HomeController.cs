using Microsoft.AspNetCore.Mvc;
using MongoDbService.Service;

namespace MongoDbLogging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly LoggingService _loggingService;
        public HomeController(LoggingService loggingService)
        {
            _loggingService = loggingService;
        }
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                await _loggingService.CreateAsync(new MongoDbDatabase.Model.Loggings
                {
                    ActionName = "Index",
                    ControllerName = "Home",
                    Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),
                    LoggingDescription ="Success",
                    LoggingName = "Index action success log",
                    Status = MongoDbDatabase.Enums.Status.Success
                });
                return Ok();
            }
            catch (Exception ex)
            {
                await _loggingService.CreateAsync(new MongoDbDatabase.Model.Loggings
                {
                    ActionName = "Index",
                    ControllerName = "Home",
                    Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString(),
                    LoggingDescription = ex.Message.ToString(),
                    LoggingName = "Index action error log",
                    Status = MongoDbDatabase.Enums.Status.Error
                });
               throw new BadHttpRequestException(ex.Message.ToString());
            }
           
            

        }
    }
}
