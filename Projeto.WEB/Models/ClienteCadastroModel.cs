using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.WEB.Validations;

namespace Projeto.WEB.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }


        [EmailUnicoValidation(ErrorMessage = "E-mail já cadastrado!")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório!")]
        public string Email { get; set; }
    }
}