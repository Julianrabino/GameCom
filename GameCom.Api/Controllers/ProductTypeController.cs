using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameCom.Api.Controllers
{
    [ApiController]
    [Route("api/producttype")]
    [Produces("application/json")]
    public class ProductTypeController : ControllerBase
    {
        private readonly ILogger<ProductTypeController> _logger;

        private readonly IMapperSession _session;

        public ProductTypeController(ILogger<ProductTypeController> logger, IMapperSession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpGet]
        public IEnumerable<ProductType> Get()
        {
            var list =_session.ProductTypes.ToList();
            if (list.Any())
            {
                //var productType = new ProductType();
                //productType.Initials = "P22";
                //productType.Description = "prueba 2020";
                var productType = _session.ProductTypes.Where(p => p.Id == 12).FirstOrDefault();
                productType.Description = "prueba 2020 ED";
                _session.BeginTransaction();
                _session.Save(productType);
                _session.Commit();
            }
            return list.ToList();
        }
    }
}
