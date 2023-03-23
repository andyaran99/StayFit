using StayFit.StayFit_Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StayFit.StayFit_Data.Model.DetailsDto;


namespace StayFit.StayFit_Data.Extension;


public static class DetailsExtension
{
    public static Details ToDetailsEntity(this DetailsViewDto detailsView)
    {
        return new Details
        {
            Id = detailsView.Id,
            BodyType = detailsView.BodyType,
            RoutineType = detailsView.RoutineType,
            DateTime = detailsView.DateTime,
            
        };
    }

    public static Details ToDetailsEntity(this DetailsCreateDto detailsView)
    {
        return new Details()
        {
            BodyType = detailsView.BodyType,
            RoutineType = detailsView.RoutineType,
            DateTime = detailsView.DateTime,

        };
    }

    public static DetailsViewDto ToDetailsViewDto(this Details detailsEntity)
    {
        return new DetailsViewDto
        {
            Id = detailsEntity.Id,
            BodyType = detailsEntity.BodyType,
            RoutineType = detailsEntity.RoutineType,
            DateTime = detailsEntity.DateTime,
        };
    }
    
    public static List<DetailsViewDto> ToListProductViewDto(this List<Details> productEntities)
    {
        List<DetailsViewDto> result = new List<DetailsViewDto>();
        foreach (var productEntity in productEntities)
        {
            result.Add(ToDetailsViewDto(productEntity));
        }
        return result;
    }
}