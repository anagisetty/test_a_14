namespace Test_A_14.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityExchangeProcessController : ControllerBase
    {
        private readonly SecurityExchangeProcessService _securityExchangeProcessService;

        public SecurityExchangeProcessController(SecurityExchangeProcessService securityExchangeProcessService)
        {
            _securityExchangeProcessService = securityExchangeProcessService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var processes = _securityExchangeProcessService.GetAll();
            return Ok(processes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var process = _securityExchangeProcessService.Get(id);
            return Ok(process);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SecurityExchangeProcessDTO processDTO)
        {
            _securityExchangeProcessService.Create(processDTO);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] SecurityExchangeProcessDTO processDTO)
        {
            _securityExchangeProcessService.Update(processDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _securityExchangeProcessService.Delete(id);
            return Ok();
        }
    }
}