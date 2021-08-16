using DiscountManagement.Application.Constracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UtilityFreamwork.Application;
using UtilityFreamwork.Repository;
using shopContext = ShopManagement.Infrastructure.EFCore.Context;

namespace DiscountManagement.Infrastructure.Repositories
{
    public class CustomerDiscountRepository : Repository<long, CustomerDiscount>, ICustomerDiscoutRepository
    {
        private readonly Context context;
        private readonly shopContext _shopContext;

        public CustomerDiscountRepository(Context context , shopContext shopContext) : base(context)
        {
            this.context = context;
            _shopContext = shopContext;
        }

        public void Active(long id)
        {
            var dis = context.CustomerDiscounts.Find(id);
            dis.Active();
        }

        public void DeActive(long id)
        {
            var dis = context.CustomerDiscounts.Find(id);
            dis.DeActive();
        }

        public void Edit(EditCustomerDiscount editCustomer)
        {
            var dis = context.CustomerDiscounts.FirstOrDefault(x => x.Id == editCustomer.Id);
            if (dis != null)
            {
                dis.Edit(editCustomer.ProductId, editCustomer.DiscountPercent, editCustomer.Reason, editCustomer.StartDate.ToGeorgianDateTime(), editCustomer.EndDate.ToGeorgianDateTime());
            }
        }

        public List<CustomerDiscountVM> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = context.CustomerDiscounts
                .Select(x => new CustomerDiscountVM
                {
                    Id = x.Id,
                    DiscountPercent = x.DiscountPercent,
                    Reason = x.Reason,
                    ProductId = x.ProductId,
                    StartDate = x.StartDate.ToFarsi(),
                    EndDate = x.EndDate.ToFarsi(),
                    StartDateEN = x.StartDate,
                    EndDateEN = x.EndDate,
                    IsActive = x.IsActive
                });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                query = query.Where(x => x.StartDateEN > searchModel.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                var enddate = DateTime.Now;
                query = query.Where(x => x.EndDateEN < searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount => discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
        }

        public List<EditCustomerDiscount> GetAllDetails()
        {
            return context.CustomerDiscounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountPercent = x.DiscountPercent,
                    Reason = x.Reason,
                    StartDate = x.StartDate.ToFarsi(),
                    EndDate = x.EndDate.ToFarsi()
                })
                .ToList();
        }

        public EditCustomerDiscount GetDetail(long id)
        {
            return context.CustomerDiscounts
                .Select(x => new EditCustomerDiscount
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    DiscountPercent = x.DiscountPercent,
                    Reason = x.Reason,
                    StartDate = x.StartDate.ToString(CultureInfo.InvariantCulture),
                    EndDate = x.EndDate.ToString(CultureInfo.InvariantCulture),
                })
                .FirstOrDefault(x=>x.Id == id);
        }
    }
}
