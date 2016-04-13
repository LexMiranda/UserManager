using System.Collections.Generic;
namespace Gapo_Permissionamento.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            this.Perfis = new List<Perfil>();
        }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual IList<Perfil> Perfis { get; set; }
        
    }
}