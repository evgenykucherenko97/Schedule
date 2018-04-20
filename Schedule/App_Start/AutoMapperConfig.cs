using AutoMapper;
using Schedule.BLL.DTO;
using Schedule.Models;
using Schedule.Models.DTOs;
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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TeacherModel, TeacherDTO>()
                .ForMember
                    (dst => dst.Position, src => src.MapFrom(e => e.Position.Name))
                .ForMember
                    (dst => dst.Degree, src => src.MapFrom(e => e.Degree.Name));
                cfg.CreateMap<UserDTO, UserDisplayModel>();
                cfg.CreateMap<UserDTO, EditModel>();
                });
        }
    }
}