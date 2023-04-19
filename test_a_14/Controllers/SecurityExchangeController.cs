using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_a_14.SecurityExchangeProcess;

namespace test_a_14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityExchangeController : ControllerBase
    {
        private readonly ISecurityExchangeService _securityExchangeService;

        public SecurityExchangeController(ISecurityExchangeService securityExchangeService)
        {
            _securityExchangeService = securityExchangeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SecurityExchange>> GetSecurityExchangeData()
        {
            var result = _securityExchangeService.GetSecurityExchangeData();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSecurityExchange(SecurityExchange securityExchange)
        {
            await _securityExchangeService.CreateSecurityExchange(securityExchange);
            return Ok();
        }
    }
}