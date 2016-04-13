using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gapo_Permissionamento.Entities
{
    public class Perfil
    {
        
        public int ID { get; set; }
        public string Nome { get; set; }
        public virtual IList<Usuario> Usuarios { get; set; }

    }
}