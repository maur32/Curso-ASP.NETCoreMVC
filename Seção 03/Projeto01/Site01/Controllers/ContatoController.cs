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
            Contato contato = new Contato();
            List<UF> ufs = new List<UF>();
            ufs.Add(new UF() { uf = "SP" });
            ufs.Add(new UF() { uf = "RO" });
            ufs.Add(new UF() { uf = "AC" });
            ufs.Add(new UF() { uf = "AM" });
            ufs.Add(new UF() { uf = "RR" });
            ufs.Add(new UF() { uf = "PA" });
            ufs.Add(new UF() { uf = "AP" });
            ufs.Add(new UF() { uf = "TO" });
            ufs.Add(new UF() { uf = "MA" });
            ufs.Add(new UF() { uf = "PI" });
            ufs.Add(new UF() { uf = "CE" });
            ufs.Add(new UF() { uf = "RN" });
            ufs.Add(new UF() { uf = "PB" });
            ufs.Add(new UF() { uf = "PE" });
            ufs.Add(new UF() { uf = "AL" });
            ufs.Add(new UF() { uf = "SE" });
            ufs.Add(new UF() { uf = "BA" });
            ufs.Add(new UF() { uf = "MG" });
            ufs.Add(new UF() { uf = "ES" });
            ufs.Add(new UF() { uf = "RJ" });
            ufs.Add(new UF() { uf = "PR" });
            ufs.Add(new UF() { uf = "SC" });
            ufs.Add(new UF() { uf = "MS" });
            ufs.Add(new UF() { uf = "MT" });
            ufs.Add(new UF() { uf = "GO" });
            ufs.Add(new UF() { uf = "DF" });

            List<Cidades> cidades = new List<Cidades>();
            cidades.Add(new Cidades() { cidade = "São Paulo", uf = new UF() { uf = "SP" } });
            cidades.Add(new Cidades() { cidade = "Blumenau", uf = new UF() { uf = "SC" } });
            cidades.Add(new Cidades() { cidade = "Balneário Camboriú", uf = new UF() { uf = "SC" } });
            cidades.Add(new Cidades() { cidade = "Itupeva", uf = new UF() { uf = "SP" } });
            cidades.Add(new Cidades() { cidade = "Manaus", uf = new UF() { uf = "AM" } });
            contato.Ufs = ufs;
            contato.cidades = cidades;
            return View(contato);
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