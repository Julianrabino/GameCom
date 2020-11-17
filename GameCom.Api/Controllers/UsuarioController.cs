using AutoMapper;
using GameCom.Api.Application;
using GameCom.Api.DTOs;
using GameCom.Common.Extensions;
using GameCom.Common.Resources;
using GameCom.Model.Base;
using GameCom.Model.Entities;
using GameCom.Service.Base;
using GameCom.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GameCom.Api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;

        private readonly IService<Producto, int> productoService;

        private readonly IMapper mapper;

        public UsuarioController(IUsuarioService service, IService<Producto, int> productoService, IMapper mapper)
        {
            this.usuarioService = service;
            this.productoService = productoService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Permite recuperar todas las instancias
        /// </summary>
        /// <returns>Una colección de instancias</returns>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return this.mapper.Map<IEnumerable<UsuarioDTO>>(this.usuarioService.GetAll()).ToList();
        }

        /// <summary>
        /// Permite recuperar una instancia mediante un identificador
        /// </summary>
        /// <param name="id">Identificador  de la instancia a recuperar</param>
        /// <returns>Una instancia</returns>
        [HttpGet("{id}")]
        public ActionResult<UsuarioDTO> Get(int id)
        {
            return this.mapper.Map<UsuarioDTO>(this.usuarioService.Get(id));
        }

        /// <summary>
        /// Permite crear una nueva instancia
        /// </summary>
        /// <param name="value">Una instancia</param>
        /// <returns>La instancia generada</returns>
        [HttpPost]
        public ActionResult<UsuarioDTO> Post([FromBody] UsuarioDTO value)
        {
            TryValidateModel(value);
            var entidadGenerada = this.usuarioService.Create(this.mapper.Map<Usuario>(value));
            return this.mapper.Map<UsuarioDTO>(entidadGenerada);
        }

        /// <summary>
        /// Permite editar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a editar</param>
        /// <param name="value">Una instancia con los nuevos datos</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UsuarioDTO value)
        {
            TryValidateModel(value);
            var entidad = this.usuarioService.Get(id);
            TryValidateVersionable(entidad);
            this.mapper.Map<UsuarioDTO, Usuario>(value, entidad);
            this.usuarioService.Update(entidad);
        }

        /// <summary>
        /// Permite borrar una instancia
        /// </summary>
        /// <param name="id">Identificador de la instancia a borrar</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entidad = this.usuarioService.Get(id);
            TryValidateVersionable(entidad);
            this.usuarioService.Delete(entidad);
        }


        /// <summary>
        /// Permite agregar un producto a un usuario
        /// </summary>
        /// <param name="idUsuario">Identificador del usuario</param>
        /// <param name="IdProducto">Identificador del producto</param>
        [HttpPut("agregarProducto/{idUsuario}/{idProducto}")]
        public void Put(int idUsuario, int IdProducto)
        {
            var usuario = this.usuarioService.Get(idUsuario);
            TryValidateVersionable(usuario);
            var producto = this.productoService.Get(IdProducto);
            this.usuarioService.AgregarProducto(usuario, producto);
            this.usuarioService.Update(usuario);
        }

        private void TryValidateVersionable(object entidad)
        {
            IVersionable versionable = entidad as IVersionable;
            if (versionable != null)
            {
                if (!this.Request.Headers.ContainsKey("if-match"))
                {
                    throw new InvalidVersionException(Mensajes._1);
                }
                else 
                {
                    if (versionable.Version != this.Request.Headers["if-match"].ToString().TryParseToInt())
                    {
                        throw new InvalidVersionException(Mensajes._2);
                    } 
                }
            }
        }
    }
}
