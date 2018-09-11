using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Projeto.DAL.Repositories;

namespace Projeto.WEB.Validations
{
    public class EmailUnicoValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // verificar se o objeto não está vazio e se é do tipo string
            if (value != null && value is string)
            {
                // converter para string
                string email = (string)  value;

                // verificar na base de dados se o email existe
                ClienteRepositorio repo = new ClienteRepositorio();
                // retornar se o email não exite
                return !repo.HasEmail(email);

            }
            return false;
        }
    }
}