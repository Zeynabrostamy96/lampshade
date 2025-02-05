﻿using _01_Farmework.Application;
using _01_Farmework.Infrastructure;
using ShopManagement.Application.Contracts.Productctaegory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;



namespace Infrastructure.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;
        public ProductCategoryRepository(ShopContext shopContext):base(shopContext)
        {
            _shopContext = shopContext;
        }

        

        public EditProductCategory GetDetails(long id)
        {
            return _shopContext.ProductCategories.Select(x => new EditProductCategory
            {
                id = x.id,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                //Picture = x.Picture,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.id == id);
        }

        public List<ProductCategoryViewModel> Getlist()
        {
            var category = GetAll();
            return category.Select(x => new ProductCategoryViewModel
            {
                id=x.id,
                Name=x.Name,
            }).OrderByDescending(x=>x.id).ToList();

                
        }

        public string GetSlugCategoryby(long id)
        {
            return _shopContext.ProductCategories.Select(x => new { x.id, x.Slug }).FirstOrDefault(x => x.id == id).Slug;
        }

        public List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel)
        {
            var query = _shopContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                Name = x.Name,
                Crationdate = x.Crationdate.ToFarsi(),
                id = x.id,
                Picture = x.Picture,

            });
            if (!string.IsNullOrWhiteSpace(shearchModel.Name))
                query = query.Where(x => x.Name.Contains(shearchModel.Name));
            return query.OrderByDescending(x => x.id).ToList();

        }
    }
}
