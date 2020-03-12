using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxFileNumberValidationApp
{
    [ApiController]
    [Route("[controller]")]
    public class ValidateTFNController : ControllerBase
    {
        private readonly IValidationService _validationService;

        private readonly ILogger<ValidateTFNController> _logger;

        public ValidateTFNController(ILogger<ValidateTFNController> logger, IValidationService validationService)
        {
            _logger = logger;
            _validationService = validationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Web API for validating Tax file numbers");
        }
        
        [HttpGet("{Tfn}")]
        public IActionResult Get(string Tfn)
        {
            return Ok(_validationService.ValidateTFN(Tfn));
        }
    }
}
