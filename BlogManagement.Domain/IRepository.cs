using System;
using System.Collections.Generic;
using System.Linq.Expressions;

//
//  In Interface Bayad Dar IModelRepository ha Inherit Shavad
//


namespace BlogManagement.Domain
{
    public interface IRepository<TKey, TModel> where TModel : class
    {
        void Create(TModel model);

        TModel Get(TKey id);

        List<TModel> Get();

        bool IsExists(Expression<Func<TModel, bool>> expression);

        void Save();
    }
}
