using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameCom.Api.DTOs;
using GameCom.Model.Entities;
using GameCom.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameCom.Api.Controllers
{
    [ApiController]
    [Route("api/producttype")]
    [Produces("application/json")]
    public class ProductTypeController : ControllerBase
    {
        //private readonly ILogger<ProductTypeController> _logger;

        //private readonly IMapperSession _session;

        //public ProductTypeController(ILogger<ProductTypeController> logger, IMapperSession session)        
        //{
        //    _logger = logger;
        //    _session = session;
        //}

        private readonly ProductTypeService service;
        private readonly IMapper mapper;

        public ProductTypeController(ProductTypeService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Permite recuperar todas las instancias
        /// </summary>
        /// <returns>Una colección de instancias</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductTypeDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<ProductTypeDTO>>(this.service.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una instancia mediante un identificador
        /// </summary>
        /// <param name="id">Identificador de la instancia a recuperar</param>
        /// <returns>Una instancia</returns>
        [HttpGet("{id}")]
        public ActionResult<ProductTypeDTO> Get(int id)
        {
            return this.mapper.Map<ProductTypeDTO>(this.service.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva instancia
        /// </summary>
        /// <param name="value">Una instancia</param>
        [HttpPost]
        public void Post([FromBody] ProductTypeDTO value)
        {
            TryValidateModel(value);
            this.service.Create(this.mapper.Map<ProductType>(value));
        }

        /// <summary>
        /// Permite editar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a editar</param>
        /// <param name="value">Una instancia con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductTypeDTO value)
        {
            var productType = this.service.Get(id);
            TryValidateModel(value);
            this.mapper.Map<ProductTypeDTO, ProductType>(value, productType);
            this.service.Update(productType);
        }

        /// <summary>
        /// Permite borrar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var productType = this.service.Get(id);
            this.service.Delete(productType);
        }
    }
}
