using CrudAPI.Data;
using CrudAPI.Model;
using CrudAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LoginController : ControllerBase
   {

      private readonly UserRepository _userRepository;

      public LoginController(APIContext context)
      {
         _userRepository = new UserRepository(context);
      }
      [HttpPost]
      [Route("login")]
      [AllowAnonymous]
      public ActionResult<dynamic> Authenticate([FromBody] User model)
      {
        
         var user = _userRepository.FindByUserName(model.Username);
        
         if (user == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

         bool credenciasValidas = _userRepository.VerificarLogin(model.Username, model.Password, user);

         if (credenciasValidas == false)
            return Unauthorized(new { message = "Usuário ou senha inválidos" });

         // Gera o Token
         var token = TokenService.GenerateToken(user);

         // Oculta a senha
         user.Password = "";

         // Retorna os dados
         return new
         {
            user = user,
            token = token
         };
      }

      [HttpPost]
      [Route("CadastrarUser")]
      [Authorize(Roles = "Gerente")]
      public ActionResult<dynamic> CadastrarUser([FromBody] User model)
      {
         if (model == null)
         {
            return NotFound(new { message = "Usuário ou senha inválidos" });
         }

         if (model.UserId > 0)
         {
            return NotFound(new { message = "O campo UserId não deve ser informado" });
         }


         try
         {
            bool isOk = _userRepository.Insert(model);
            return Ok("Usuário cadastrado com sucesso!");
         }
         catch (Exception)
         {
            return BadRequest("Erro ao cadastrar usuário");
            throw;
         }



      }
   }
}
