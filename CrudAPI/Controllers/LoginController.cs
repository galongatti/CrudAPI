using CrudAPI.Data;
using CrudAPI.Model;
using CrudAPI.Services;
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
      public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
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
   }
}
