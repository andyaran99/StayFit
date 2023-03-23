﻿using StayFit.StayFit_Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayFit.StayFit_Data.Model.ProductDto;

namespace StayFit.StayFit_Data.Extension;

public static class ProductExtension
{
    public static Product ToProductEntity(this ProductViewDto productView)
    {
        return new Product
        {
            Id = productView.Id,
            Description = productView.Description,
            Title = productView.Title,
            Price = productView.Price
            
        };
    }

    public static Product ToProductEntity(this ProductCreateDto productView)
    {
        return new Product
        {
            Description = productView.Description,
            Title = productView.Title,
            Price = productView.Price

        };
    }

    public static ProductViewDto ToProductViewDto(this Product productEntity)
    {
        return new ProductViewDto
        {
            Id = productEntity.Id,
            Description = productEntity.Description,
            Title = productEntity.Title,
            Price = productEntity.Price
        };
    }
    
    public static List<ProductViewDto> ToListProductViewDto(this List<Product> productEntities)
    {
        List<ProductViewDto> result = new List<ProductViewDto>();
        foreach (var productEntity in productEntities)
        {
            result.Add(ToProductViewDto(productEntity));
        }
        return result;
    }
}