using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IDutchRepository repository;
        private readonly ILogger logger;

        public ProductsController(IDutchRepository repository, ILogger logger )
        {
            this.repository = repository;
            this.logger = logger;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            }
            
        }
    }
}
