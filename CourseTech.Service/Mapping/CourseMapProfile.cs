﻿using AutoMapper;
using CourseTech.Core.DTOs.Course;
using CourseTech.Core.Models;

namespace CourseTech.Service.Mapping
{
    public class CourseMapProfile : Profile
    {
        public CourseMapProfile()
        {
            //
            CreateMap<Course, CourseDTO>()
              .ConstructUsing(src => new CourseDTO(
                  src.Id,
                  src.Title,
                  src.Description,
                  src.ImageUrl,
                  src.Level,
                  src.Language,
                  src.Price,
                  src.Duration,
                  src.PublishedAt,
                  $"{src.Instructor.FirstName} {src.Instructor.LastName}",
                  src.Category.Name
              ));

            CreateMap<Course, CourseSummaryDTO>()
                .ConstructUsing(src => new CourseSummaryDTO(
                    src.Id,
                    src.Title,
                    src.Price,
                    $"{src.Instructor.FirstName} {src.Instructor.LastName}",
                    src.ImageUrl
                ));

            CreateMap<CourseCreateDTO, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsPublished, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Enrollments, opt => opt.Ignore());

            CreateMap<CourseUpdateDTO, Course>()
                .ForMember(dest => dest.IsPublished, opt => opt.Ignore()) 
                .ForMember(dest => dest.PublishedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Enrollments, opt => opt.Ignore());
        }
    }
}