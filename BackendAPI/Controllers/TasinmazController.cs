namespace BackendAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Business;
    using Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class TasinmazController : ControllerBase
    {
        private readonly TasinmazService _service;

        public TasinmazController(TasinmazService service)
        {
            _service = service;
        }

        // GET: api/Tasinmaz
        [HttpGet]
        public IActionResult GetTasinmazlar()
        {
            return Ok(_service.GetAllTasinmaz());
        }

        // POST: api/Tasinmaz
        [HttpPost]
        public IActionResult AddTasinmaz([FromBody] Tasinmaz tasinmaz)
        {
            _service.AddTasinmaz(tasinmaz);
            return Ok("Taşınmaz eklendi.");
        }
    }

}
