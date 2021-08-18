using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

//
//  In Class Dar ModelRepository ha Inherit Mishavad ...
//  Injectione Contexte Classe farzand bayad be In class Ferestade shavad ...            : base (context)
//  

namespace InventoryManagement.Infrastructure.EFCore.Repositories
{
    public class Repository<TKey, TModel> : IRepository<TKey, TModel> where TModel : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Create(TModel model)
        {
            context.Add<TModel>(model);
        }

        public TModel Get(TKey id)
        {
            return context.Find<TModel>(id);
        }

        public List<TModel> Get()
        {
            return context.Set<TModel>().ToList();
        }

        public bool IsExists(Expression<Func<TModel, bool>> expression)
        {
            return context.Set<TModel>().Any(expression);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
