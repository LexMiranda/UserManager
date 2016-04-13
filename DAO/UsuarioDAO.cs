
using System.Collections;
using System.Linq;
using Gapo_Permissionamento.Context;
using Gapo_Permissionamento.Entities;


namespace Gapo_Permissionamento.DAO
{
    public class UsuarioDAO
    {
        private Contexto context;

        public UsuarioDAO()
        {
            this.context = new Contexto();
        }
        public IList Lista()
        {
            return this.context.Usuarios.ToList();
        }

        public void Adiciona(Usuario user)
        {
            this.context.Usuarios.Add(user);
            this.context.SaveChanges();

        }

        public void Remove(Usuario user)
        {
            this.context.Usuarios.Remove(user);
            this.context.SaveChanges();

        }

        public Usuario BuscaPorId(int id)
        {
            return this.context.Usuarios.Find(id);
        }

    }
}