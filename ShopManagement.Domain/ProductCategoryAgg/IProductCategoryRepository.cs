﻿using _01_Farmework.Domain;
using ShopManagement.Application.Contracts.Productctaegory;
using System.Collections.Generic;



namespace ShopManagement.Domain.ProductCategoryAgg
{
    public  interface IProductCategoryRepository: IRepository<long, ProductCategory>
    {
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategoryShearchModel shearchModel);
        List<ProductCategoryViewModel> Getlist();
        string GetSlugCategoryby(long id);
    }
}
