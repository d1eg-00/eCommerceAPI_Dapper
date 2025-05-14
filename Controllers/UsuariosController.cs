using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.API.Models;
using eCommerce.API.Repositories;
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _repository;
        public UsuariosController()
        {
            _repository = new UsuarioRepository();
        }

        /*
        GET - Obter lista de usuarios;
        GET - Obter lista de usuarios por Id;
        POST - Cadastrar usuario;
        PUT - Atualizar usuario;
        DELETE - Remover usuario;

        METODO HTTP www.minhaapi.com.br/api/Usuarios
        METODO POR ID www.minhaapi.com.br/api/Usuarios/Id do usuario

        */
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Usuario = _repository.Get(id); // pega a lista e armazena na variavel

            if(Usuario == null)
            {
                return NotFound();
            }
            return Ok(Usuario);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]Usuario usuario)
        {
            _repository.Insert(usuario);
            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _repository.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }
}