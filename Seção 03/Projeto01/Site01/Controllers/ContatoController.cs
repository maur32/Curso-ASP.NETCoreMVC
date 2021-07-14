using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Library.Mail;
using System.Text.RegularExpressions;
using Site01.Models;

namespace Site01.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Contato = new Contato();
            return View(new Contato());
        }


        [HttpPost]
        public IActionResult ReceberContato([FromForm] Contato contato)
        {
            String theEmailPattern = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z";

            if (string.IsNullOrEmpty(contato.Nome))
            {
                ViewBag.Erro = "O campo 'Nome' é obrigatório!";

                return View("Index", contato);
            }
            else if (contato.Nome.Length > 50)
            {
                ViewBag.Erro = "O campo 'Nome' deve conter no máximo 50 caracteres!";

                return View("Index", contato);
            }
            else if (string.IsNullOrEmpty(contato.Email))
            {
                ViewBag.Erro = "O campo 'E-mail' é obrigatório!";

                return View("Index", contato);
            }
            else if (contato.Email.Length > 70)
            {
                ViewBag.Erro = "O campo 'E-mail' deve conter no máximo 70 caracteres!";

                return View("Index", contato);
            }
            else if (!Regex.IsMatch(contato.Email, theEmailPattern))
            {
                ViewBag.Erro = "O campo 'E-mail' é inválido!";

                return View("Index", contato);
            }
            else if (string.IsNullOrEmpty(contato.Assunto))
            {
                ViewBag.Erro = "O campo 'Assunto' é obrigatório!";

                return View("Index", contato);
            }
            else if (contato.Assunto.Length > 70)
            {
                ViewBag.Erro = "O campo 'Assunto' deve conter no máximo 70 caracteres!";

                return View("Index", contato);
            }
            else if (string.IsNullOrEmpty(contato.Mensagem))
            {
                ViewBag.Erro = "O campo 'Mensagem' é obrigatório!";

                return View("Index", contato);
            }
            else if (contato.Mensagem.Length > 2000)
            {
                ViewBag.Erro = "O campo 'Mensagem' deve conter no máximo 2000 caracteres!";

                return View("Index", contato);
            }

            else
            {
                EnviarEmail.EnviarMensagemContato(contato);
                ViewBag.Mensagem = "Mensagem enviada com sucesso!";
                return View("Index", new Contato());
            }


            /* if (ModelState.IsValid)
             {
                 string conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);
                 return new ContentResult() { Content = conteudo };

                 ViewBag.Contato = new Contato();
                 EnviarEmail.EnviarMensagemContato(contato);
                 ViewBag.Mensagem = "Mensagem enviada com sucesso!";
                 return View("Index");
             }
             else
             {
                 ViewBag.Contato = contato;

                 return View("Index");
             }
            */

        }

        /* Obter dados manualmente
        public IActionResult ReceberContato()
        {
            //POST - Request.Form
            //GET - Request.QueryString
            Contato contato = new Contato();
            contato.Nome = Request.Form["nome"];
            contato.Email = Request.Form["email"];
            contato.Assunto = Request.Form["assunto"];
            contato.Mensagem = Request.Form["mensagem"];
            string conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);
            return new ContentResult() { Content = conteudo };
        }
        */
    }
}