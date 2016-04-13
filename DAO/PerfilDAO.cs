using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gapo_Permissionamento.Context;
using Gapo_Permissionamento.Entities;

namespace Gapo_Permissionamento.DAO
{
    public class PerfilDAO
    {
        private Contexto context;

        public PerfilDAO()
        {
            this.context = new Contexto();
        }

        public IList Listar()
        {
            return this.context.Perfis.ToList();
        }

        public void Adiciona(Perfil perfil)
        {
            this.context.Perfis.Add(perfil);
            this.context.SaveChanges();


        }

        public void Remove(Perfil perfil)
        {
            this.context.Perfis.Remove(perfil);
            this.context.SaveChanges();
        }

        public Perfil BuscaPorId(int id)
        {
            return this.context.Perfis.Find(id);
        }



    }
}