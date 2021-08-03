using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class GenericRepository<TKey, TModel> : IGenericRepository<TKey, TModel> where TModel : class
    {
        private readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(TModel model)
        {
            context.Add<TModel>(model);
            Save();
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
