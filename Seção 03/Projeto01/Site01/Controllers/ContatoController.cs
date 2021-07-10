﻿using System;
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
            return View();
        }


        [HttpPost]
        public IActionResult ReceberContato([FromForm] Contato contato)
        {
            if (string.IsNullOrEmpty(contato.Nome))
            {
                ViewBag.Erro = "O campo 'Nome' é obrigatório!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (contato.Nome.Length > 50)
            {
                ViewBag.Erro = "O campo 'Nome' deve conter no máximo 50 caracteres!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (string.IsNullOrEmpty(contato.Email))
            {
                ViewBag.Erro = "O campo 'E-mail' é obrigatório!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (contato.Email.Length > 70)
            {
                ViewBag.Erro = "O campo 'E-mail' deve conter no máximo 70 caracteres!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (string.IsNullOrEmpty(contato.Assunto))
            {
                ViewBag.Erro = "O campo 'Assunto' é obrigatório!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (contato.Assunto.Length > 70)
            {
                ViewBag.Erro = "O campo 'Assunto' deve conter no máximo 70 caracteres!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (string.IsNullOrEmpty(contato.Mensagem))
            {
                ViewBag.Erro = "O campo 'Mensagem' é obrigatório!";
                ViewBag.Contato = contato;

                return View("Index");
            }
            else if (contato.Mensagem.Length > 2000)
            {
                ViewBag.Erro = "O campo 'Mensagem' deve conter no máximo 2000 caracteres!";
                ViewBag.Contato = contato;

                return View("Index");
            }

            else
            {
                ViewBag.Contato = new Contato();
                EnviarEmail.EnviarMensagemContato(contato);
                ViewBag.Mensagem = "Mensagem enviada com sucesso!";
                return View("Index");
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