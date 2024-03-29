﻿using StayFit.StayFit_Data.Entity;
using StayFit.StayFit_Data.Model.RoutineDTO;

namespace StayFit.StayFit_Data.Extension;

public static class RoutineExtension
{
    public static Routine ToRoutineEntity(this RoutineViewDto routineView)
    {
        return new Routine
        {
            Id = routineView.Id,
            Name = routineView.Name,
            RoutineType = routineView.RoutineType,
            BodyType = routineView.BodyType,
            DateTime = routineView.DateTime

        };
    }

    public static Routine ToRoutineEntity(this RoutineCreateDto routineView)
    {
        return new Routine
        {
            Name = routineView.Name,
            RoutineType = routineView.RoutineType,
            BodyType = routineView.BodyType,
            DateTime = routineView.DateTime
            

        };
    }

    public static RoutineViewDto ToRoutineViewDto(this Routine routineEntity)
    {
        return new RoutineViewDto
        {
            Id = routineEntity.Id,
            Name = routineEntity.Name,
            RoutineType = routineEntity.RoutineType,
            BodyType = routineEntity.BodyType,
            DateTime = routineEntity.DateTime,
            Exercices = routineEntity.Exercices
            
        };
    }
    
    public static List<RoutineViewDto> ToListRoutineViewDto(this List<Routine> routineEntities)
    {
        List<RoutineViewDto> result = new List<RoutineViewDto>();
        foreach (var routineEntity in routineEntities)
        {
            result.Add(ToRoutineViewDto(routineEntity));
        }
        return result;
    }
}