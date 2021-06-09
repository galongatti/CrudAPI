using CrudAPI.Data;
using CrudAPI.Model;
using CrudAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers{

   [Route("api/[controller]")]
   [ApiController]
   public class CategoriaController : ControllerBase
   {
      private readonly CategoriaRepository _categoriaRepository;


      public CategoriaController(APIContext context)
      {
         _categoriaRepository = new CategoriaRepository(context);
      }


      [HttpGet("GetAllCategoria")]
      public IActionResult GetAllCategoria()
      {

         try
         {
            List<Categoria> listaCategorias = _categoriaRepository.All().ToList();
            return Ok(listaCategorias);
         }
         catch (Exception)
         {
            return BadRequest("Erro ao buscar por todas as categorias");
         }
      }

      [HttpGet("GetCategoria/{id}")]
      public IActionResult GetCategoria(long? id)
      {

         try
         {
            if (id == null)
            {
               return NotFound();
            }

            Categoria categoria = _categoriaRepository.Find(id);

            if (categoria == null)
            {
               return NotFound();
            }

            return Ok(categoria);

         }
         catch (Exception)
         {
            return BadRequest("Erro ao realizar a busca pela categorias");
         }
      }


      [HttpPost("PostCategoria")]
      public IActionResult PostCategoria([FromBody] Categoria categoria)
      {

         try
         {
            if (!ModelState.IsValid || categoria is null)
            {
               return BadRequest();
            }

            _categoriaRepository.Insert(categoria);

            return Ok();
         }
         catch (Exception)
         {
            return BadRequest("Erro ao cadastrar categoria");
         }
      }

      [HttpPut("PutCategoria/{id}")]
      public IActionResult PutCategoria(long? id, [FromBody] Categoria categoria)
      {

         try
         {
            if (!ModelState.IsValid || categoria is null || categoria.CategoriaID != id)
            {
               return BadRequest();
            }

            _categoriaRepository.Update(categoria);

            return Ok();
         }
         catch (Exception)
         {
            return BadRequest("Erro ao atualizar a categoria");
         }
      }

      [HttpDelete("DeleteCategoria/{id}")]
      public IActionResult DeleteCategoria(long? id)
      {
         try
         {
            if (id <= 0 || id == null)
            {
               return NotFound();
            }

            _categoriaRepository.Delete(id);

            return Ok();
         }
         catch (Exception)
         {
            return BadRequest("Erro ao excluir a categoria");
         }
      }

   }
}
