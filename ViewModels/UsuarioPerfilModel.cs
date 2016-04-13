using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Gapo_Permissionamento.Entities;

namespace Gapo_Permissionamento.ViewModels
{
    public class UsuarioPerfilModel
    {
        [Required]
        public string Nome { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public IList<Perfil> Perfis { get; set; }
        [Required]
        public string Senha { get; set; }
        [Compare("Senha")]
        public string ConfirmarSenha { get; set; }

    }
}