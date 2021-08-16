using DiscountManagement.Application;
using DiscountManagement.Application.Constracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityFreamwork.Application;
using UtilityFreamwork.Repository;

namespace DiscountManagement.Infrastructure.Repositories
{
    public class ColleagueDiscountRepository : Repository<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountContext context;
        private readonly ShopContext shopContext;

        public ColleagueDiscountRepository(DiscountContext context , ShopContext shopContext) : base(context)
        {
            this.context = context;
            this.shopContext = shopContext;
        }

        public void Edit(EditColleagueDiscount editColleague)
        {
            var coll = context.ColleagueDiscounts.Find(editColleague.Id);
            coll.Edit(editColleague.DiscountPercent, editColleague.ProductId);
        }

        public void Active(long id)
        {
            context.ColleagueDiscounts.Find(id).Active();
        }

        public void DeActive(long id)
        {
            context.ColleagueDiscounts.Find(id).DeActive();
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            return context.ColleagueDiscounts
                .Select(x => new EditColleagueDiscount 
                {
                    Id = x.Id,
                    DiscountPercent = x.DiscountPercent,
                    ProductId = x.ProductId
                })
                .FirstOrDefault(x=>x.Id == id);
        }

        public List<ColleagueDiscountVM> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products = shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = context.ColleagueDiscounts.Select(x=> new ColleagueDiscountVM
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountPercent = x.DiscountPercent,
                IsActive = x.IsActive,
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
        }

        ColleagueDiscountVM IColleagueDiscountRepository.Get(long id)
        {
            var products = shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var colleague = context.ColleagueDiscounts
                .Select(x => new ColleagueDiscountVM
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    DiscountPercent = x.DiscountPercent,
                    IsActive = x.IsActive
                })
                .FirstOrDefault(x=>x.Id == id);

            colleague.Product = products.FirstOrDefault(x => x.Id == colleague.ProductId)?.Name;

            return colleague;
        }
    }
}
