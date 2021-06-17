using CrudAPI.Data;
using CrudAPI.Model;
using CrudAPI.Repositories.RepositoryProduto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ProdutoController : ControllerBase
   {


      private readonly ProdutoRepository produtoRepository;


      public ProdutoController(APIContext context)
      {
         produtoRepository = new ProdutoRepository(context);
      }


      [HttpGet("GetAllProduto")]
      public ActionResult GetAllProduto()
      {
         
         try
         {
            List<Produto> produtos = produtoRepository.All().ToList();
            return Ok(produtos);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.InnerException);
            return BadRequest("Erro ao buscar por todos os produtos");
         }
         
      }

      // GET api/<ProdutoController>/5
      [HttpGet("GetProdutoByID/{id}")]
      public ActionResult GetProdutoByID(int? id)
      {
         try
         {
            if (!id.HasValue)
            {
               return BadRequest("O id do produto deve ser informado");
            }

            Produto produto = produtoRepository.Find(id.Value);
            return Ok(produto);
         }
         catch (Exception)
         {
            return BadRequest("Erro ao buscar pelo produto");       
         }
      }

      [HttpPost("CadastrarProduto")]
      public ActionResult CadastrarProduto([FromBody] Produto produto)
      {
         try
         {
            if (!ModelState.IsValid)
               return BadRequest("Parametros incorretos");

            bool isOk = produtoRepository.Insert(produto);
            if (isOk)
               return Ok();
            else
               return BadRequest("Ocorreu um erro ao cadastrar o produto");
         }
         catch (Exception)
         {
            return BadRequest("Ocorreu um erro ao cadastrar o produto");            
         }
      }

      // PUT api/<ProdutoController>/5
      [HttpPut("AtualizarProduto/{id}")]
      public ActionResult AtualizarProduto(int id, [FromBody] Produto produto)
      {        
         try
         {
            if (id <= 0 || id != produto.ProdutoID)
               return BadRequest("ID do produto inválido");


            bool existe = produtoRepository.ProdutoExist(id);
            bool atualizado = false;
            if (existe)
               atualizado = produtoRepository.Update(produto);
            else
               return BadRequest("Esse produto não existe");

            if (atualizado)
               return Ok("Produto atualizado com sucesso");
            else
               return BadRequest("Não foi possível atualizar o produto");
         }
         catch (Exception)
         {
            return BadRequest("Erro ao atualizar o produto");
         }

      }

      // DELETE api/<ProdutoController>/5
      [HttpDelete("DeletarProduto/{id}")]
      public ActionResult DeletarProduto(int id)
      {

         try
         {
            if (id <= 0)
               return BadRequest("ID inválido");

            bool deletado = produtoRepository.Delete(id);

            if (deletado)
               return Ok("Produto excluido com sucesso");
            else
               return BadRequest("Não foi possível excluir o produto");

         }
         catch (Exception)
         {
            return BadRequest("Não foi possível excluir o produto");
         }


      }
   }
}
