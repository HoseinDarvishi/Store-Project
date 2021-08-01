using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopManagement.Domain
{
    public interface IGenericRepository<TKey, TModel> where TModel : class
    {
        void Create(TModel model);

        TModel Get(TKey id);

        List<TModel> Get();

        bool IsExists(Expression<Func<TModel, bool>> expression);

        void Save();
    }
}
