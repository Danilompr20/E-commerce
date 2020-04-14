using EComerce.Dominios.Contratos;
using EComerce.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EComerce.Repositorio.Repositorio
{
    public class BaseRepositorio<TEntity> : IBaseRepositorio<TEntity> where TEntity : class

    {

        //metodos padrões  como inserir , deletar são feitos no baseRepositoios, metodo especificos são feito dentro propria classe
        protected readonly EcommerceContexto EcommerceContexto;
        protected DbSet<TEntity> DbSet;
       
        public BaseRepositorio(EcommerceContexto ecommerceContexto)
        {
            //variavel EcommerceContexto recebe oque tem em ecommerceContexto via enjeção de dependencia
            EcommerceContexto = ecommerceContexto;
            DbSet = EcommerceContexto.Set<TEntity>();

        }


       
        public void Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            EcommerceContexto.SaveChanges();
            
        }

        public void Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            EcommerceContexto.SaveChanges();

        }



        public TEntity ObterPorId(int id)
        {
            return DbSet.Find(id);

        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Remover(TEntity entity)
        {
            EcommerceContexto.Remove(entity);
            EcommerceContexto.SaveChanges();

        }

        public void Dispose()
        {
            EcommerceContexto.Dispose();
        }
    }
}
