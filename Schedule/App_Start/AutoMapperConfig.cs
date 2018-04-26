using AutoMapper;
using Schedule.BLL.DTO;
using Schedule.Models;
using Schedule.Models.DTOs;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            ScheduleContext db = new ScheduleContext();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TeacherModel, TeacherDTO>()
                .ForMember
                    (dst => dst.Position, src => src.MapFrom(e => db.Positions.Find(e.IdPosition).Name))
                .ForMember
                    (dst => dst.Degree, src => src.MapFrom(e => db.Degrees.Find(e.IdDegree).Name));
                cfg.CreateMap<UserDTO, UserDisplayModel>();
                cfg.CreateMap<UserDTO, EditModel>();
            });
        }
    }
}


