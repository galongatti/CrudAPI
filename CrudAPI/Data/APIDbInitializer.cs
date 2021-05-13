using CrudAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Data
{
   public class APIDbInitializer
   {
      public static void Initialize(APIContext context)
      {
         context.Database.EnsureCreated();

         if (context.Categorias.Any())
         {
            return;
         }

         if( context.Produtos.Any())
         {
            return;
         }

         if( context.Users.Any())
         {
            return;
         }


         List<Categoria> categoria = new() 
         {
            new Categoria { Descricao = "Smartphones" },
            new Categoria { Descricao = "Consoles" }         
         };

         List<Produto> produtos = new()
         {
            new Produto {
               Descricao = "iPhone X", 
               CategoriaID = 1, 
               Sobre = "O Apple iPhone X é um dos smartphones iOS mais avançados e completos que existem em circulação. Tem um grande display de 5.8 polegadas com uma resolução de 2436x1125 pixel. As funcionalidades oferecidas pelo Apple iPhone X são muitas e inovadoras. Começando pelo LTE 4G que permite a transferência de dados e excelente navegação na internet. Enfatizamos a excelente memória interna de 256 GB mas sem a possibilidade de expansão.Câmera discreta de 12 megapixel mas que permite ao Apple iPhone X tirar fotos de boa qualidade com uma resolução de 4608x2592 pixel e gravar vídeos em 4K a espantosa resolução de 3840x2160 pixels. A espessura de 7.7mm torna o Apple iPhone X um dos telefones mais completos e finos."},

            new Produto
            {
               Descricao = "XBOX ONE X",
               CategoriaID = 2,
               Sobre = "No Xbox One X os jogos rodam muito melhor. Com 40% mais poder do que qualquer outro console, experimente os verdadeiros jogos 4K. Os jogos ficam com uma ótima resolução, funcionam sem problemas e carregam rapidamente, mesmo em uma tela de 1080p. O Xbox One X também funciona com todos os seus jogos e acessórios do Xbox One, bem como o Xbox Live, uma rede multiplayer avançada, que lhe oferece mais maneiras de jogar. Conteúdo da embalagem: Console XBOX One X, Fonte de alimentação universal (Bivolt), Cabo HDMI, Manual de Instruções, Controle sem fio, HDD 1TB 4K."
            }


         };

         List<User> users = new()
         {
            new User { Username = "gerente1", Password = "123", Role = "Gerente" },
            new User { Username = "funcionario1", Password = "123", Role = "Funcionario" }
         };


         foreach(Categoria cat in categoria)
         {
            context.Add(cat);
         }

         foreach(Produto prod in produtos)
         {
            context.Add(prod);
         }

         foreach(User user in users)
         {
            context.Add(user);
         }

         context.SaveChanges();
      }
   }
}
