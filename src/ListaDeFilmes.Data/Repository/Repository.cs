﻿using ListaDeFilmes.Business.Interfaces;
using ListaDeFilmes.Business.Models;
using ListaDeFilmes.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ListaDeFilmes.Data.Repository
{
    //abstract = nao pode ser instanciada, só posso usa-la se for Herdada 
    //Entity, new() = Significa que eu posso instanciar essa Entidade
    //todos os métodos estão como virtual para usar o override(sobescrever) quando for necessário.
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ListaDeFilmesContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(ListaDeFilmesContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            //AsNoTracking é ideal para consulta, o mesmo não faz o rastreio de todo o objeto, sendo assim é mais performatico
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> ObterPorId(Guid? id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            //Remove do banco sem precisar fazer a busca no banco.
            //ex: Não é necessário usar o metodo Find para encontrar o id, e devolver o objeto para remover. Com o "new TEntity" você passa somente o Id para remover.
            // E isso é possível porque todo mundo herda de TEntity

            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task<bool> IdExiste(Guid id)
        {
            return await DbSet.AnyAsync(x => x.Id == id);
        }

        public void Dispose()
        {
            //IDisposable serve para liberar memória
            //Db? = Se ele existir faça o Dispose, se nao exister não faça
            Db?.Dispose();
        }
    }
}
