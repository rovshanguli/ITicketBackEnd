using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.Category;
using ServiceLayer.DTOs.Event;
using ServiceLayer.DTOs.Hall;
using ServiceLayer.DTOs.Seans;
using ServiceLayer.DTOs.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Slider, SliderDto>().ReverseMap();
            CreateMap<Slider, SliderEditDto>().ReverseMap();
            CreateMap<Hall, HallDto>().ReverseMap();
            CreateMap<Hall, HallEditDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryEditDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventEditDto>().ReverseMap();
            CreateMap<Seans, SeansDto>().ReverseMap();
            CreateMap<Seans, SeansEditDto>().ReverseMap();
        }
    }
}
